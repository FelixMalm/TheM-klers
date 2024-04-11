namespace TheMäklersAPI.Data.Models
{
    public class Housing
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Address { get; set; }
        public double InitialPrice { get; set; }
        public double LivingArea { get; set; }
        public double AdditionalArea { get; set; }
        public double PlotArea { get; set; }
        public string Description { get; set; }
        public int NumberOfRooms { get; set; }
        public double MonthlyFee { get; set; }
        public double AnnualOperatingCost { get; set; }
        public int YearBuilt { get; set; }
        public List<string> Images { get; set; }

        // Foreign keys
        public int MunicipalityId { get; set; }
        public int BrokerId { get; set; }
        

        // Navigation properties
        public Municipality Municipality { get; set; }
        public Broker Broker { get; set; }
        
    }
}
