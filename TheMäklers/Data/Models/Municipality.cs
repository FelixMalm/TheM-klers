namespace TheMäklersAPI.Data.Models
{
    public class Municipality
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation properties
        public List<Housing> Housings { get; set; }
    }
}
