using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace AgricDataC
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("🌿 Starting Agricultural Data Seeding...");

            int numberOfFarmers = 1000;
            int numberOfFarmsPerFarmer = 2;
            int numberOfLivestockPerFarm = 10;
            int numberOfCropsPerFarm = 5;
            var seeder = new DataSeeder();

            // Seed all data
            var farmers = seeder.GenerateFarmers(numberOfFarmers);
            var farms = seeder.GenerateFarms(farmers, numberOfFarmsPerFarmer);
            var livestock = seeder.GenerateLivestock(farmers, numberOfLivestockPerFarm);
            var livestockWeights = seeder.GenerateLivestockWeights(livestock);
            var healthRecords = seeder.GenerateHealthRecords(livestock);
            var feedingLogs = seeder.GenerateFeedingLogs(livestock);
            var crops = seeder.GenerateCrops(farms, numberOfCropsPerFarm);
            var irrigationLogs = seeder.GenerateIrrigationLogs(crops);
            var soilTests = seeder.GenerateSoilTests(farms);
            var pestTreatments = seeder.GeneratePestTreatments(crops);
            var harvests = seeder.GenerateHarvests(crops);

            // Export to CSV
            string exportFolder = Path.Combine(Environment.CurrentDirectory, "csv_exports");
            Directory.CreateDirectory(exportFolder);

            CsvExporter.ExportToCsv(farmers, Path.Combine(exportFolder, "Farmers.csv"));
            CsvExporter.ExportToCsv(farms, Path.Combine(exportFolder, "Farms.csv"));
            CsvExporter.ExportToCsv(livestock, Path.Combine(exportFolder, "Livestock.csv"));
            CsvExporter.ExportToCsv(livestockWeights, Path.Combine(exportFolder, "LivestockWeights.csv"));
            CsvExporter.ExportToCsv(healthRecords, Path.Combine(exportFolder, "HealthRecords.csv"));
            CsvExporter.ExportToCsv(feedingLogs, Path.Combine(exportFolder, "FeedingLogs.csv"));
            CsvExporter.ExportToCsv(crops, Path.Combine(exportFolder, "Crops.csv"));
            CsvExporter.ExportToCsv(irrigationLogs, Path.Combine(exportFolder, "IrrigationLogs.csv"));
            CsvExporter.ExportToCsv(soilTests, Path.Combine(exportFolder, "SoilTests.csv"));
            CsvExporter.ExportToCsv(pestTreatments, Path.Combine(exportFolder, "PestTreatments.csv"));
            CsvExporter.ExportToCsv(harvests, Path.Combine(exportFolder, "Harvests.csv"));

            Console.WriteLine("✅ Data seeding and CSV export complete.");
        }
    }
}
