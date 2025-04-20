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
        string[] cropVarieties = new string[]{    "Hybrid Maize SC719",    "PAN 6479",    "Bainsvlei Groundnut",    "Rooibos Tea Red Bush",    "Kikuyu Grass",    "Tomato Money Maker",
        "Beauregard Sweet Potato",    "California Wonder (Green Pepper)",    "Carrot Kuroda",    "Texas Grano Onion",    "Greenfeast Peas",
        "Gem Squash Star 6001",    "Red Russian Kale",    "Spinach Fordhook Giant"};
        string[] healthNotes = new string[] {    "Routine check-up, all vitals normal.",    "Minor cut observed on front leg.",    "Loss of appetite for 2 days.",    "Exhibiting signs of heat stress.",    "Vaccination administered, no side effects.",
         "Minor infection treated, under observation.",    "Increased weight gain, healthy condition.",    "Mild coughing, vitamin booster given.",
         "Hoof trimmed and cleaned.",    "Wound from fencing, disinfected and bandaged."};


        string[] healthTreatments = new string[]{ "Deworming",    "Vitamin B12 Injection",    "Antibiotics (Oxytetracycline)",    "Tick and Flea Dip",
    "Foot Rot Treatment",
    "Multivitamin Supplement",
    "Vaccination (Anthrax)",
    "Fly Repellent Spray",
    "Electrolytes Added to Water",
    "Anti-inflammatory Injection"
};




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


        public List<Crop> GenerateCrops(List<Farm> farms, int cropsPerFarm = 3)
        {
            var cropList = new List<Crop>();
            int id = 1;

            foreach (var farm in farms)
            {
                for (int i = 0; i < cropsPerFarm; i++)
                {
                    var planting = RandomDate(2023, 2024);
                    cropList.Add(new Crop
                    {
                        CropID = id++,
                        FarmerID = farm.FarmerID,
                        CropType = cropTypes[rand.Next(cropTypes.Length)],
                        Variety = cropVarieties[rand.Next(cropVarieties.Length)],
                        PlantingDate = planting,
                        ExpectedHarvestDate = planting.AddMonths(4),
                        ActualHarvestDate = planting.AddMonths(4).AddDays(rand.Next(-5, 10)),
                        AreaPlanted = Math.Round((decimal)(rand.NextDouble() * 5 + 1), 2)
                    });
                }
            }

            return cropList;
        }

        public List<IrrigationLog> GenerateIrrigationLogs(List<Crop> crops)
        {
            var list = new List<IrrigationLog>();
            int id = 1;

            foreach (var crop in crops)
            {
                for (int i = 0; i < 3; i++)
                {
                    list.Add(new IrrigationLog
                    {
                        IrrigationID = id++,
                        CropID = crop.CropID,
                        IrrigationDate = crop.PlantingDate.AddDays(i * 14),
                        Method = irrigationMethods[rand.Next(irrigationMethods.Length)],
                        WaterLitres = Math.Round((decimal)(rand.NextDouble() * 200 + 100), 2)
                    });
                }
            }

            return list;
        }

        public List<SoilTest> GenerateSoilTests(List<Farm> farms)
        {
            var list = new List<SoilTest>();
            int id = 1;

            foreach (var farm in farms)
            {
                list.Add(new SoilTest
                {
                    SoilTestID = id++,
                    FarmID = farm.FarmID,
                    TestDate = RandomDate(2023, 2024),
                    PH = Math.Round((decimal)(rand.NextDouble() * 2 + 5.5), 1), // 5.5 to 7.5
                    Nitrogen = Math.Round((decimal)(rand.NextDouble() * 20 + 10), 2),
                    Phosphorus = Math.Round((decimal)(rand.NextDouble() * 15 + 5), 2),
                    Potassium = Math.Round((decimal)(rand.NextDouble() * 20 + 10), 2),
                    Moisture = Math.Round((decimal)(rand.NextDouble() * 15 + 10), 1)
                });
            }

            return list;
        }

        public List<PestTreatment> GeneratePestTreatments(List<Crop> crops)
        {
            var list = new List<PestTreatment>();
            int id = 1;

            foreach (var crop in crops)
            {
                if (rand.Next(0, 2) == 1) // 50% chance of pest issue
                {
                    list.Add(new PestTreatment
                    {
                        PestTreatmentID = id++,
                        CropID = crop.CropID,
                        TreatmentDate = crop.PlantingDate.AddDays(rand.Next(10, 60)),
                        PestDetected = pests[rand.Next(pests.Length)],
                        ChemicalUsed = chemicals[rand.Next(chemicals.Length)],
                        Dosage = $"{rand.Next(5, 20)}ml per litre"
                    });
                }
            }

            return list;
        }

        public List<Harvest> GenerateHarvests(List<Crop> crops)
        {
            var list = new List<Harvest>();
            int id = 1;

            foreach (var crop in crops)
            {
                list.Add(new Harvest
                {
                    HarvestID = id++,
                    CropID = crop.CropID,
                    HarvestDate = crop.ActualHarvestDate ?? crop.ExpectedHarvestDate,
                    QuantityKg = Math.Round((decimal)(rand.NextDouble() * 500 + 200), 2),
                    QualityGrade = grades[rand.Next(grades.Length)]
                });
            }

            return list;
        }

        public List<HealthRecord> GenerateHealthRecords(List<Livestock> livestockList)
        {
            var list = new List<HealthRecord>();
            int id = 1;

            foreach (var animal in livestockList)
            {
                list.Add(new HealthRecord
                {
                    HealthRecordID = id++,
                    LivestockID = animal.LivestockID,
                    CheckDate = animal.BirthDate.AddMonths(6),
                    Notes = healthNotes[rand.Next(healthNotes.Length)],
                    Treatment = healthTreatments[rand.Next(healthTreatments.Length)]
                });
            }

            return list;
        }



    }

    //Crop class
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

    //IrrigationLog clas
    public class IrrigationLog
    {
        public int IrrigationID { get; set; }
        public int CropID { get; set; }
        public DateTime IrrigationDate { get; set; }
        public string Method { get; set; }
        public decimal WaterLitres { get; set; }
    }

    //SoilTest class
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
