namespace BernardBawakA8.Models
{
    public class House
    {
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
        public double Price { get; set; }
        public int TimeOnMarket { get; set; }

        public override string ToString()
        {
            string fullAddress = $"{Address}, {City}, {State} {ZipCode}";
            return $"House: {fullAddress} - Listed at: ${Price:N2} - On Market: {TimeOnMarket} Months";
        }
    }
}

