using ICS.Domain.Configurations;
using Microsoft.EntityFrameworkCore;

namespace ICS.Domain.Data.Adapters
{
    /// <summary>
    /// Контекст домена
    /// </summary>
    public sealed class DomainContext : DbContext
    {
        /// <summary>
        /// Конструктор контекста домена
        /// </summary>
        /// <param name="connectionString">Строка подключения</param>
        public DomainContext(DbContextOptions<DomainContext> options)
            : base(options)
        {
            /*
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(nameOrConnectionString, nameof(nameOrConnectionString));
            ConnectionStringName = nameOrConnectionString;
            */

            SchemaName = Constants.Schemes.Domain;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies(true);

            base.OnConfiguring(optionsBuilder);
        }

        /*protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseNpgsql(ConnectionStringName);*/

        /// <summary>
        /// Наименование схемы
        /// </summary>
        public string SchemaName { get; private set; }

        /// <summary>
        /// Наименование строки подключения
        /// </summary>
        public string ConnectionStringName { get; private set; }

        /// <summary>
        /// Вызов после создания модели
        /// </summary>
        /// <param name="modelBuilder">Построитель модели</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            RegisterDomainModels(modelBuilder);
        }

        /// <summary>
        /// Зарегистрировать доменные модели
        /// </summary>
        /// <param name="modelBuilder">Построитель модели</param>
        private void RegisterDomainModels(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AlienConfiguration(SchemaName));
            modelBuilder.ApplyConfiguration(new ContactConfiguration(SchemaName));
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration(SchemaName));
            modelBuilder.ApplyConfiguration(new DocumentConfiguration(SchemaName));
            modelBuilder.ApplyConfiguration(new PassportConfiguration(SchemaName));
            modelBuilder.ApplyConfiguration(new InvitationConfiguration(SchemaName));
            modelBuilder.ApplyConfiguration(new VisitDetailConfiguration(SchemaName));
            modelBuilder.ApplyConfiguration(new OrganizationConfiguration(SchemaName));
            modelBuilder.ApplyConfiguration(new StateRegistrationConfiguration(SchemaName));
            modelBuilder.ApplyConfiguration(new ForeignParticipantConfiguration(SchemaName));
        }
    }
}