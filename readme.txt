
// add section to settings file (optional)
{
  "DbDataSettings": {
    "AllowExceptionLogging": false // default is "true" 
  }
}

***************************************************************************************************

// add appropriate usings
using ag.DbData.SqlServer.Extensions;
using ag.DbData.SqlServer.Factories;

***************************************************************************************************

// register services with one of overloaded extension methods

		// ...
		services.AddAgSqlServer();
		// or
		services.AddAgSqlServer(config.GetSection("DbDataSettings"));
		// or
		services.AddAgSqlServer(opts =>
        {
            opts.AllowExceptionLogging = false; 
        });

***************************************************************************************************

// inject ISqlServerDbDataFactory into your classes

        private readonly ISqlServerDbDataFactory _sqlServerFactory;

        public MyClass(ISqlServerDbDataFactory sqlServerFactory)
        {
            _sqlServerFactory = sqlServerFactory;
        }

***************************************************************************************************

// SqlServerDbDataObject implements IDisposable interface, so use it into 'using' directive

        using (var sqlServerDbData = _sqlServerFactory.Create(YOUR_CONNECTION_STRING))
        {
            using (var t = sqlServerDbData.FillDataTable("SELECT * FROM YOUR_TABLE"))
            {
                foreach (DataRow r in t.Rows)
                {
                    Console.WriteLine(r[0]);
                }
            }
        }

***************************************************************************************************