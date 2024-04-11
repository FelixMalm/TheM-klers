namespace TheMäklersAPI.Data.Models
{
    public class Agency
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Presentation { get; set; }
        public string LogoUrl { get; set; }

        // Navigation properties
        public List<Broker> Brokers { get; set; }
        public List<Housing> Housings { get; set; }
    }
}
