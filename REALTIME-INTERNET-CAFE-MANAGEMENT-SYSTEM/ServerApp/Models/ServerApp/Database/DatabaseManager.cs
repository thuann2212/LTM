using Microsoft.Data.Sqlite;

namespace ServerApp.Database
{
    public class DatabaseManager
    {
        private string connectionString =
            "Data Source=internet_cafe.db";

        public SqliteConnection GetConnection()
        {
            return new SqliteConnection(
                connectionString);
        }
    }
}