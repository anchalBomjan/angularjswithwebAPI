using Microsoft.Data.SqlClient;
using System.Data;

namespace TodoList.Data
{
    public class DapperContext
    {
        private readonly IConfiguration configuration;
        private readonly string connectionString;
        public DapperContext(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.connectionString = this.configuration.GetConnectionString("ToDo");
        }
        public IDbConnection CreateConnection() => new SqlConnection(connectionString);
    }
}
