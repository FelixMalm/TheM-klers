using System.ComponentModel.DataAnnotations;

namespace TheMäklersAPI.Data.Models
{
    public class Agency //Author Kim
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Presentation { get; set; }
        public string LogoUrl { get; set; }
        public List<Broker> Brokers { get; set; }
    }
}
