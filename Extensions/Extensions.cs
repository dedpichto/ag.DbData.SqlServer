using ag.DbData.Abstraction;
using ag.DbData.Abstraction.Services;
using ag.DbData.SqlServer.Factories;
using ag.DbData.SqlServer.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ag.DbData.SqlServer.Extensions
{
    /// <summary>
    /// Represents <see cref="ag.DbData.SqlServer"/> extensions
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Appends the registration of <see cref="SqlServerDbDataFactory"/> and <see cref="SqlServerDbDataObject"/> services to <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
        /// <returns><see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddAgSqlServer(this IServiceCollection services)
        {
            services.AddSingleton<SqlServerStringProvider>();
            services.AddSingleton<IDbDataStringProviderFactory<SqlServerStringProvider>, SqlServerStringProviderFactory>();
            services.AddSingleton<ISqlServerDbDataFactory, SqlServerDbDataFactory>();
            services.AddTransient<SqlServerDbDataObject>();
            return services;
        }

        /// <summary>
        /// Appends the registration of <see cref="SqlServerDbDataFactory"/> and <see cref="SqlServerDbDataObject"/> services to <see cref="IServiceCollection"/> and registers a configuration instance.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
        /// <param name="configurationSection">The <see cref="IConfigurationSection"/> being bound.</param>
        /// <returns><see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddAgSqlServer(this IServiceCollection services, IConfigurationSection configurationSection)
        {
            services.AddAgSqlServer();
            services.Configure<DbDataSettings>(configurationSection);
            return services;
        }

        /// <summary>
        /// Appends the registration of <see cref="SqlServerDbDataFactory"/> and <see cref="SqlServerDbDataObject"/> services to <see cref="IServiceCollection"/> and configures the options.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
        /// <param name="configureOptions">The action used to configure the options.</param>
        /// <returns><see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddAgSqlServer(this IServiceCollection services,
            Action<DbDataSettings> configureOptions)
        {
            services.AddAgSqlServer();
            services.Configure(configureOptions);
            return services;
        }
    }
}
