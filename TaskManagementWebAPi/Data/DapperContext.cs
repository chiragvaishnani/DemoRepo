using Microsoft.Data.SqlClient;
using System.Data;

namespace TaskManagementWebAPI.Data
{
    public class DapperContext
    {
        private readonly string _connectionString;

        public DapperContext()
        {
            var configurations = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            _connectionString = configurations["ConnectionStrings:DefaultConnection"];
        }
        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
