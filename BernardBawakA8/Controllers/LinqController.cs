using BernardBawakA8.Models;

namespace BernardBawakA8.Controllers
{
    public class LinqController
    {
        private List<House> _houses;

        public LinqController(List<House> houses)
        {
            _houses = houses ?? new List<House>();
        }

        public void QueryHousesOnMarketLongerThanFiveMonths()
        {
            Console.WriteLine("\n=== Houses on Market Longer Than 5 Months (LINQ) ===");
            var result = from house in _houses
                         where house.TimeOnMarket > 5
                         select house;

            foreach (var house in result)
            {
                Console.WriteLine(house.ToString());
            }
        }

        public void QueryHousesOnMarketLongerThanFiveMonthsAndPriceLessThan175k()
        {
            Console.WriteLine("\n=== Houses on Market > 5 Months AND Price < $175,000 (LINQ) ===");
            var result = from house in _houses
                         where house.TimeOnMarket > 5 && house.Price < 175000
                         select house;

            foreach (var house in result)
            {
                Console.WriteLine(house.ToString());
            }
        }

        public void QueryHousesInSelectedStatesPriceMoreThan140kOrderedByPrice()
        {
            Console.WriteLine("\n=== Houses in GA, NY, TX with Price > $140,000 Ordered by Price Ascending (LINQ) ===");
            var result = from house in _houses
                         where (house.State == "GA" || house.State == "NY" || house.State == "TX")
                            && house.Price > 140000
                         orderby house.Price ascending
                         select house;

            foreach (var house in result)
            {
                Console.WriteLine(house.ToString());
            }
        }

        public void QueryZipCodesPriceMoreThan140kOrderedByZipDescending()
        {
            Console.WriteLine("\n=== Zip Codes with Price > $140,000 Ordered by Zip Descending (LINQ) ===");
            var result = from house in _houses
                         where house.Price > 140000
                         orderby house.ZipCode descending
                         select house.ZipCode;

            foreach (var zipCode in result.Distinct())
            {
                Console.WriteLine(zipCode);
            }
        }

        public void QueryHousesGroupedByStateOrderedByPriceDescending()
        {
            Console.WriteLine("\n=== Houses from GA, NY, TX Grouped by State, Ordered by Price Descending (LINQ) ===");
            var result = from house in _houses
                         where house.State == "GA" || house.State == "NY" || house.State == "TX"
                         orderby house.Price descending
                         group house by house.State into stateGroup
                         orderby stateGroup.Key
                         select stateGroup;

            foreach (var group in result)
            {
                Console.WriteLine($"\nState: {group.Key}");
                foreach (var house in group)
                {
                    Console.WriteLine($"  {house.ToString()}");
                }
            }
        }

        public void QueryCustomLinqQuery()
        {
            Console.WriteLine("\n=== Custom Query: Houses with Price > $200,000 AND TimeOnMarket > 10 Months, Grouped by State, Ordered by Average Price Descending (LINQ) ===");
            var result = from house in _houses
                         where house.Price > 200000 && house.TimeOnMarket > 10
                         group house by house.State into stateGroup
                         orderby stateGroup.Average(h => h.Price) descending
                         select stateGroup;

            foreach (var group in result)
            {
                Console.WriteLine($"\nState: {group.Key} (Average Price: ${group.Average(h => h.Price):N2})");
                foreach (var house in group.OrderByDescending(h => h.Price))
                {
                    Console.WriteLine($"  {house.ToString()}");
                }
            }
        }
    }
}
