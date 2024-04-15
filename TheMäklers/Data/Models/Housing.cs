using System.ComponentModel.DataAnnotations;

namespace TheMäklersAPI.Data.Models
{
    public class Housing //Author Kim
    {
        [Key]
        public int Id { get; set; }
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
        public List<string> Images { get; set; } = new List<string>();

        public int CategoryId { get; set; }
        public int BrokerId { get; set; }
        public int MunicipalityId { get; set; }
        public Broker Broker { get; set; }
        public Municipality Municipality { get; set; }
        public Category Category { get; set; }
    }
}
