using ag.DbData.Abstraction;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Data.SqlClient;

namespace ag.DbData.SqlServer.Factories
{
    /// <summary>
    /// Represents SqlDbDataFactory object.
    /// </summary>
    public class SqlServerDbDataFactory : ISqlServerDbDataFactory
    {
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// Creates object of type <see cref="SqlServerDbDataObject"/>.
        /// </summary>
        /// <param name="connectionString">Database connection string.</param>
        /// <returns><see cref="SqlServerDbDataObject"/> implementation of <see cref="IDbDataObject"/> interface.</returns>
        public IDbDataObject Create(string connectionString)
        {
            var dbObject = _serviceProvider.GetService<SqlServerDbDataObject>();
            dbObject.Connection = new SqlConnection(connectionString);
            return dbObject;
        }


        /// <summary>
        /// Creates new SqlServerDbDataFactory object.
        /// </summary>
        /// <param name="serviceProvider"><see cref="IServiceProvider"/>.</param>
        public SqlServerDbDataFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
    }
}
