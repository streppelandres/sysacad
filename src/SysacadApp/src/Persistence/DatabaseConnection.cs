using System.Configuration;
using System.Data.SqlClient;

namespace Persistence
{
    public class DatabaseConnection
    {
        private static DatabaseConnection? conecction;

        private DatabaseConnection() { }

        public SqlConnection CreateConnection() =>
             new(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString);

        public static DatabaseConnection GetInstance()
        {
            conecction ??= new DatabaseConnection();
            return conecction;
        }
    }
}
