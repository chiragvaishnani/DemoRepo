using System.Data;
using System.Data.SqlClient;

namespace TaskManagement.Data
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
