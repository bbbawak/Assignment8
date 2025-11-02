using System.Text.Json;
using System.Text.Json.Serialization;
using BernardBawakA8.Models;

namespace BernardBawakA8
{
    public class DataImporter
    {
        public static List<House> ImportHouses(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"JSON file not found at: {filePath}");
            }

            string jsonContent = File.ReadAllText(filePath);
            
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var jsonHouses = JsonSerializer.Deserialize<List<JsonHouse>>(jsonContent, options);
            
            if (jsonHouses == null)
            {
                return new List<House>();
            }

            return jsonHouses.Select(jh => new House
            {
                Address = jh.Address ?? string.Empty,
                City = jh.City ?? string.Empty,
                State = jh.State ?? string.Empty,
                ZipCode = jh.ZipCode ?? string.Empty,
                Price = jh.Price,
                TimeOnMarket = jh.TimeOnMarket
            }).ToList();
        }

        private class JsonHouse
        {
            public string? Address { get; set; }
            public string? City { get; set; }
            public string? State { get; set; }
            [JsonPropertyName("zip_code")]
            public string? ZipCode { get; set; }
            public double Price { get; set; }
            [JsonPropertyName("time_on_market")]
            public int TimeOnMarket { get; set; }
        }
    }
}

