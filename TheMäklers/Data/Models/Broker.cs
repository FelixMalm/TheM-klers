using System.ComponentModel.DataAnnotations;

namespace TheMäklersAPI.Data.Models
{
    public class Broker //Author Kim
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        public string ImageUrl { get; set; }
        [Required]
        //public int AgencyId { get; set; }
        public Agency Agency { get; set; }
    }
}
