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

            CreateFarmers(10);
            CreateFarms(5);
            CreateLivestock(20);
            CreateWeightLogs(50);
            CreateHealthRecords(30);
            CreateFeedingLogs(60);
            CreateCrops(15);
            CreateIrrigationLogs(30);
            CreateSoilTests(10);
            CreatePestTreatments(15);
            CreateHarvests(15);

            Console.WriteLine("✅ Done seeding data!");
        }
    }
}
