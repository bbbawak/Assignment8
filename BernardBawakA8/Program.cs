using BernardBawakA8.Controllers;
using BernardBawakA8.Models;

namespace BernardBawakA8
{
    class Program
    {
        static void Main(string[] args)
        {
            string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "assignment8Data.json");
            
            if (!File.Exists(jsonFilePath))
            {
                jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "assignment8Data.json");
            }

            if (!File.Exists(jsonFilePath))
            {
                Console.WriteLine($"Error: Could not find JSON file at {jsonFilePath}");
                Console.WriteLine("Please ensure the assignment8Data.json file is in the Data folder.");
                return;
            }

            List<House> houses = DataImporter.ImportHouses(jsonFilePath);
            
            if (houses.Count == 0)
            {
                Console.WriteLine("No houses were imported from the JSON file.");
                return;
            }

            LinqController controller = new LinqController(houses);

            Console.WriteLine("======================================");
            Console.WriteLine("LINQ Query Demonstrations");
            Console.WriteLine("======================================");

            controller.QueryHousesOnMarketLongerThanFiveMonths();
            controller.QueryHousesOnMarketLongerThanFiveMonthsAndPriceLessThan175k();
            controller.QueryHousesInSelectedStatesPriceMoreThan140kOrderedByPrice();
            controller.QueryZipCodesPriceMoreThan140kOrderedByZipDescending();
            controller.QueryHousesGroupedByStateOrderedByPriceDescending();
            controller.QueryCustomLinqQuery();

            Console.WriteLine("\n\n======================================");
            Console.WriteLine("Lambda LINQ Query Demonstrations");
            Console.WriteLine("======================================");

            controller.QueryHousesOnMarketLongerThanFiveMonthsLambda();
            controller.QueryHousesOnMarketLongerThanFiveMonthsAndPriceLessThan175kLambda();
            controller.QueryHousesInSelectedStatesPriceMoreThan140kOrderedByPriceLambda();
            controller.QueryZipCodesPriceMoreThan140kOrderedByZipDescendingLambda();
            controller.QueryHousesGroupedByStateOrderedByPriceDescendingLambda();
            controller.QueryCustomLambdaQuery();

            Console.WriteLine("\n\nAll queries completed. Press any key to exit...");
            Console.ReadKey();
        }
    }
}

