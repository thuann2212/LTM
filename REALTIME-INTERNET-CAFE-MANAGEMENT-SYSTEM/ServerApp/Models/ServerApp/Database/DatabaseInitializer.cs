using Microsoft.Data.Sqlite;

namespace ServerApp.Database
{
    public class DatabaseInitializer
    {
        private DatabaseManager databaseManager;

        public DatabaseInitializer()
        {
            databaseManager = new DatabaseManager();
        }

        public void Initialize()
        {
            using (SqliteConnection connection = databaseManager.GetConnection())
            {
                connection.Open();
                string query = @"
                CREATE TABLE IF NOT EXISTS Users
                (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Username TEXT NOT NULL UNIQUE,
                    Password TEXT NOT NULL,
                    Role TEXT NOT NULL,
                    IsLocked INTEGER DEFAULT 0,
                    LastLogin TEXT
                );

                CREATE TABLE IF NOT EXISTS Machines
                (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    MachineName TEXT NOT NULL,
                    IpAddress TEXT,
                    Status TEXT,
                    LastHeartbeat TEXT
                );

                CREATE TABLE IF NOT EXISTS Sessions
                (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    UserId INTEGER,
                    MachineId INTEGER,
                    StartTime TEXT,
                    EndTime TEXT,
                    IsActive INTEGER DEFAULT 1
                );

                ";
                SqliteCommand command =new SqliteCommand( query, connection);
                command.ExecuteNonQuery();
            }
        }
    }
}