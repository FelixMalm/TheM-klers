namespace TheMäklersAPI.Data.Models
{
    public class Housing
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Address { get; set; }
        public string Municipality { get; set; }
        public decimal InitialPrice { get; set; }
        public double LivingArea { get; set; }
        public double AdditionalArea { get; set; }
        public double PlotArea { get; set; }
        public string Description { get; set; }
        public int NumberOfRooms { get; set; }
        public decimal MonthlyFee { get; set; }
        public decimal AnnualOperatingCost { get; set; }
        public int YearBuilt { get; set; }
        public List<string> Images { get; set; }

        // Foreign keys
        public int BrokerId { get; set; }
        public int AgencyId { get; set; }

        // Navigation properties
        public Broker Broker { get; set; }
        public Agency Agency { get; set; }
    }
}
