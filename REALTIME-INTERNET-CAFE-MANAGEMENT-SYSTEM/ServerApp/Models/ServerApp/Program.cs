using System;
using ServerApp.Database;

namespace ServerApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DatabaseInitializer database = new DatabaseInitializer();
                database.Initialize();

                if (args.Length > 0 && args[0].Equals("seed", StringComparison.OrdinalIgnoreCase))
                {
                    SeedData seedData = new SeedData();
                    seedData.InsertSampleData();
                    Console.WriteLine("da tao du lieu roi nhen.");
                }
                else
                {
                    Console.WriteLine("Chạy duoc roi nhen.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error initializing database: " + ex.Message);
            }
        }
    }
}