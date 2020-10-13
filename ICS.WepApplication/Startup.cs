using ICS.Domain.Registries;
using ICS.WebApplication.Commands.Registries;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Text;
using LightInject;
using ICS.Domain.Data.Adapters;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using Microsoft.Net.Http.Headers;

namespace ICS.WebAppCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {

            // Set to false. This will be the default in v5.x and going forward.
            //_container.Options.ResolveUnregisteredConcreteTypes = false;

            Configuration = configuration;

        }

        public IConfiguration Configuration { get; }

        // Use this method to add services directly to LightInject
        // Important: This method must exist in order to replace the default provider.
        public void ConfigureContainer(IServiceContainer container)
        {
            var jwtTokenConfig = Configuration.GetSection("jwtTokenConfig").Get<JwtTokenConfig>();

            container.RegisterSingleton(factory => jwtTokenConfig);
            container.RegisterSingleton<JwtRefreshTokenCache>();
            container.Register<IUserService, UserService>();
            container.Register<IJwtAuthService, JwtAuthService>();

            container.RegisterFrom<AdapterCompositionRoot>();
            container.RegisterFrom<RepositoryCompositionRoot>();
            container.RegisterFrom<ServiceCompositionRoot>();
            container.RegisterFrom<CommandCompositionRoot>();
        }

        // Use this method to add services to the container.
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var jwtTokenConfig = Configuration.GetSection("jwtTokenConfig").Get<JwtTokenConfig>();

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = true;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = jwtTokenConfig.Issuer,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtTokenConfig.Secret)),
                    ValidAudience = jwtTokenConfig.Audience,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(1)
                };
            });

            services.AddMvc(option => 
            {
                option.FormatterMappings.SetMediaTypeMappingForFormat("octet-stream", MediaTypeHeaderValue.Parse("application/octet-stream"));
            }).AddControllersAsServices();

            var builder = new NpgsqlConnectionStringBuilder
            {
                Username = "postgres",
                Password = "47H8Ms5a",
                Host = "localhost",
                Port = 5432,
                Database = "postgres",
                IntegratedSecurity = true,
                Pooling = true
            };


            var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");

            services.AddEntityFrameworkProxies();
            services.AddEntityFrameworkNpgsql()
                .AddDbContext<DomainContext>(opt =>
                {
                    opt.UseNpgsql(connectionString);
                    opt.UseLazyLoadingProxies(true);
                })
                .AddDbContext<SystemContext>(opt =>
                {
                    opt.UseNpgsql(connectionString);
                    opt.UseLazyLoadingProxies(true);
                });

            // Web API middleware which will register all the controllers (classes derived from ControllerBase)
            /// <see cref="https://medium.com/imaginelearning/asp-net-core-3-1-microservice-quick-start-c0c2f4d6c7fa"/>
            services.AddControllers();

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "JWT Auth Demo", Version = "v1" });

                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "JWT Authentication",
                    Description = "Enter JWT Bearer token **_only_**",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer", // must be lower case
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };
                c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {securityScheme, new string[] { }}
                });
            });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder => 
                { 
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); 
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // Default ASP.NET middleware
            // app.UseHttpsRedirection();
            app.UseStaticFiles();

            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseCors("AllowAll");
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            // Here is code to add your custom Simple Injector-created middleware to the pipeline.

            // ASP.NET Core (or MVC) default stuff here
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    // spa.UseAngularCliServer(npmScript: "start");
                    spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
                }
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("swagger/v1/swagger.json", "JWT Auth Demo V1");
                c.DocumentTitle = "JWT Auth Demo";
                c.RoutePrefix = string.Empty;
            });
        }
    }
}
