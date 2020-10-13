using ICS.Domain.Configurations;
using ICS.Shared;
using Microsoft.EntityFrameworkCore;

namespace ICS.Domain.Data.Adapters
{
    /// <summary>
    /// Контекст системы
    /// </summary>
    public sealed class SystemContext : DbContext
    {
        /// <summary>
        /// Конструктор контекста системы
        /// </summary>
        /// <param name="connectionString">Строка подключения</param>
        public SystemContext(DbContextOptions<SystemContext> options)
            : base(options)
        {
            /*Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(nameOrConnectionString, nameof(nameOrConnectionString));*/

            SchemaName = Constants.Schemes.System;
        }

        /*protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseNpgsql(ConnectionStringName);*/

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies(true);

            base.OnConfiguring(optionsBuilder);
        }

        /// <summary>
        /// Наименование строки подключения
        /// </summary>
        public string ConnectionStringName { get; private set; }

        /// <summary>
        /// Наименование схемы
        /// </summary>
        public string SchemaName { get; private set; }

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
        /// Зарегистрировать системные модели
        /// </summary>
        /// <param name="modelBuilder">Построитель модели</param>
        private void RegisterDomainModels(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration(SchemaName));
            modelBuilder.ApplyConfiguration(new ProfileConfiguration(SchemaName));
        }
    }
}