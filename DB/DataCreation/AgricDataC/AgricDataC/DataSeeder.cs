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
}
