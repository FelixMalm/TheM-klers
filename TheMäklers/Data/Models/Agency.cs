namespace TheMäklersAPI.Data.Models
{
    public class Agency //Author Kim
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Presentation { get; set; }
        public string LogoUrl { get; set; }
        public List<Broker> Brokers { get; set; }

    }
}
