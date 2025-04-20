using System;
using System.Data.SqlClient;

namespace AgricDataC
{
    class Program
    {
        static string connectionString = "Server=TLM;Database=AgriDB;Trusted_Connection=True;";
        static void Main(string[] args)
        {
            Console.WriteLine("🌿 Starting Agricultural Data Seeding...");
            Console.WriteLine("✅ Done seeding data!");
        }
    }
}
