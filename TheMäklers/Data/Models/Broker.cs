namespace TheMäklersAPI.Data.Models
{
    public class Broker //Author Kim
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string ImageUrl { get; set; }
        public int AgencyId { get; set; }
        public Agency Agency { get; set; }
    }
}
