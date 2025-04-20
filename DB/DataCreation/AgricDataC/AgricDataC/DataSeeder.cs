using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgricDataC
{
    public class DataSeeder
    {
        private static readonly Random rand = new Random();

        // Sample data
        private static readonly string[] firstNames = { "Thabo", "Lerato", "Sipho", "Nomsa", "Tshepo", "Ayanda", "Kagiso", "Buhle", "Sibusiso", "Dineo" };
        private static readonly string[] lastNames = { "Mokoena", "Moloto", "Nkosi", "Dlamini", "Ngcobo", "Mahlangu", "Khumalo", "Ndlovu", "Baloyi", "Sithole" };
        private static readonly string[] locations = { "Limpopo", "Free State", "Eastern Cape", "KZN", "Mpumalanga", "North West", "Gauteng", "Northern Cape", "Western Cape" };
        private static readonly string[] soilTypes = { "Loamy", "Clay Loam", "Silty Clay", "Black Cotton Soil", "Red Loam", "Alluvial Soil" };
        private static readonly string[] species = { "Cattle", "Goat", "Sheep" };
        private static readonly string[] breeds = { "Nguni", "Boer Goat", "Merino", "Bonsmara", "Dorper" };
        private static readonly string[] feedTypes = { "Grass", "Silage", "Maize", "Lucerne" };
        private static readonly string[] cropTypes = { "Maize", "Wheat", "Sorghum", "Sunflower" };
        private static readonly string[] irrigationMethods = { "Drip", "Sprinkler", "Center Pivot" };
        private static readonly string[] pests = { "Aphids", "Armyworm", "Cutworms", "Weevils" };
        private static readonly string[] chemicals = { "Pesticide A", "Pesticide B", "Neem Oil", "Insecticide Z" };
        private static readonly string[] grades = { "A", "B", "C" };

        public List<Farmer> GenerateFarmers(int count)
        {
            var farmers = new List<Farmer>();
            for (int i = 1; i <= count; i++)
            {
                var fullName = $"{firstNames[rand.Next(firstNames.Length)]} {lastNames[rand.Next(lastNames.Length)]}";
                var contact = $"07{rand.Next(0, 9)}{rand.Next(1000000, 9999999)}";
                var location = locations[rand.Next(locations.Length)];

                farmers.Add(new Farmer
                {
                    FarmerID = i,
                    FullName = fullName,
                    Contact = contact,
                    Location = location
                });
            }
            return farmers;
        }

        public List<Farm> GenerateFarms(List<Farmer> farmers, int farmsPerFarmer = 2)
        {
            var farms = new List<Farm>();
            int farmId = 1;
            foreach (var farmer in farmers)
            {
                for (int i = 0; i < farmsPerFarmer; i++)
                {
                    farms.Add(new Farm
                    {
                        FarmID = farmId++,
                        FarmerID = farmer.FarmerID,
                        Name = $"{farmer.FullName.Split(' ')[0]}'s Farm {i + 1}",
                        Location = farmer.Location,
                        SizeHectares = Math.Round(rand.NextDouble() * 40 + 10, 2),
                        SoilType = soilTypes[rand.Next(soilTypes.Length)]
                    });
                }
            }
            return farms;
        }

        // More methods to follow in next steps

        public List<Livestock> GenerateLivestock(List<Farmer> farmers, int animalsPerFarmer = 10)
        {
            var livestockList = new List<Livestock>();
            int livestockId = 1;

                foreach (var farmer in farmers)
                {
                    for (int i = 0; i < animalsPerFarmer; i++)
                    {
                        var birth = RandomDate(2020, 2023);
                    livestockList.Add(new Livestock
                        {
                         LivestockID = livestockId,
                          FarmerID = farmer.FarmerID,
                          TagNumber = $"TAG-{farmer.FarmerID}-{i + 1}",
                             Species = species[rand.Next(species.Length)],
                             Breed = breeds[rand.Next(breeds.Length)],
                            BirthDate = birth,
                            RegistrationDate = birth.AddMonths(2)
                         });
                      livestockId++;
                      }
                  }

             return livestockList;
        }

            private DateTime RandomDate(int startYear, int endYear)
            {
                int year = rand.Next(startYear, endYear + 1);
                int month = rand.Next(1, 13);
                int day = rand.Next(1, 28); // avoid invalid dates
                return new DateTime(year, month, day);
            }
        

        public List<LivestockWeight> GenerateLivestockWeights(List<Livestock> livestockList, int recordsPerAnimal = 5)
{
    var weights = new List<LivestockWeight>();
    int weightId = 1;

    foreach (var livestock in livestockList)
    {
        var startDate = livestock.BirthDate.AddMonths(3);
        for (int i = 0; i < recordsPerAnimal; i++)
        {
            weights.Add(new LivestockWeight
            {
                LivestockWeightID = weightId++,
                LivestockID = livestock.LivestockID,
                RecordedOn = startDate.AddMonths(i),
                WeightKg = Math.Round(30 + (decimal)(rand.NextDouble() * 300), 2)
            });
        }
    }

    return weights;
}

public List<FeedingLog> GenerateFeedingLogs(List<Livestock> livestockList, int logsPerAnimal = 5)
{
    var feedLogs = new List<FeedingLog>();
    int logId = 1;

    foreach (var livestock in livestockList)
    {
        for (int i = 0; i < logsPerAnimal; i++)
        {
            feedLogs.Add(new FeedingLog
            {
                FeedingLogID = logId++,
                LivestockID = livestock.LivestockID,
                FeedType = feedTypes[rand.Next(feedTypes.Length)],
                QuantityKg = Math.Round((decimal)(rand.NextDouble() * 10 + 5), 2),
                FedOn = livestock.BirthDate.AddDays(rand.Next(90, 730))
            });
        }
    }

    return feedLogs;
}

    }


    public class Crop
    {
        public int CropID { get; set; }
        public int FarmerID { get; set; }
        public string CropType { get; set; }
        public string Variety { get; set; }
        public DateTime PlantingDate { get; set; }
        public DateTime ExpectedHarvestDate { get; set; }
        public DateTime? ActualHarvestDate { get; set; }
        public decimal AreaPlanted { get; set; } // in hectares
    }

    public class IrrigationLog
    {
        public int IrrigationID { get; set; }
        public int CropID { get; set; }
        public DateTime IrrigationDate { get; set; }
        public string Method { get; set; }
        public decimal WaterLitres { get; set; }
    }

    public class SoilTest
    {
        public int SoilTestID { get; set; }
        public int FarmID { get; set; }
        public DateTime TestDate { get; set; }
        public decimal PH { get; set; }
        public decimal Nitrogen { get; set; }
        public decimal Phosphorus { get; set; }
        public decimal Potassium { get; set; }
        public decimal Moisture { get; set; }
    }

    //PestTreatment Class
    public class PestTreatment
    {
        public int PestTreatmentID { get; set; }
        public int CropID { get; set; }
        public DateTime TreatmentDate { get; set; }
        public string PestDetected { get; set; }
        public string ChemicalUsed { get; set; }
        public string Dosage { get; set; }
    }

    //Harvest class
    public class Harvest
    {
        public int HarvestID { get; set; }
        public int CropID { get; set; }
        public DateTime HarvestDate { get; set; }
        public decimal QuantityKg { get; set; }
        public string QualityGrade { get; set; }
    }

    //Health Record class
    public class HealthRecord
    {
        public int HealthRecordID { get; set; }
        public int LivestockID { get; set; }
        public DateTime CheckDate { get; set; }
        public string Notes { get; set; }
        public string Treatment { get; set; }
    }
    // Farmer class
    public class Farmer
    {
        public int FarmerID { get; set; }
        public string FullName { get; set; }
        public string Contact { get; set; }
        public string Location { get; set; }
    }

    // Farm class
    public class Farm
    {
        public int FarmID { get; set; }
        public int FarmerID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public double SizeHectares { get; set; }
        public string SoilType { get; set; }
    }
    public class Livestock
    {
        public int LivestockID { get; set; }
        public int FarmerID { get; set; }
        public string TagNumber { get; set; }
        public string Species { get; set; }
        public string Breed { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime RegistrationDate { get; set; }
    }

    public class LivestockWeight
    {
        public int LivestockWeightID { get; set; }
        public int LivestockID { get; set; }
        public DateTime RecordedOn { get; set; }
        public decimal WeightKg { get; set; }
    }

    public class FeedingLog
    {
        public int FeedingLogID { get; set; }
        public int LivestockID { get; set; }
        public string FeedType { get; set; }
        public decimal QuantityKg { get; set; }
        public DateTime FedOn { get; set; }
    }
}
