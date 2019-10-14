using ag.DbData.Abstraction.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ag.DbData.SqlServer.Services
{
    /// <summary>
    /// Represents <see cref="SqlServerStringProviderFactory"/> object.
    /// </summary>
    public class SqlServerStringProviderFactory : IDbDataStringProviderFactory<SqlServerStringProvider>
    {
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// Creates new instance of <see cref="SqlServerStringProviderFactory"/>.
        /// </summary>
        /// <param name="serviceProvider"><see cref="IServiceProvider"/>.</param>
        public SqlServerStringProviderFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// Creates object of type <see cref="SqlServerStringProvider"/>.
        /// </summary>
        /// <returns>Object of type <see cref="SqlServerStringProvider"/>.</returns>
        public SqlServerStringProvider Get()
        {
            return _serviceProvider.GetService<SqlServerStringProvider>();
        }
    }
}
