namespace TheMäklersAPI.Data.Models
{
    public class Broker
    {
        public int Id { get; set; }
        public int AgencyId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string ImageUrl { get; set; }

        // Navigation properties
        public Agency Agency { get; set; }
        public List<Housing> Housings { get; set; }
    }
}
