namespace TheMäklersBlazor.Models
{

    public class Rootobject
    {
        public Housing[] Housings { get; set; }
    }

    public class Housing
    {
        public int id { get; set; }
        public string address { get; set; }
        public int initialPrice { get; set; }
        public int livingArea { get; set; }
        public int additionalArea { get; set; }
        public int plotArea { get; set; }
        public string description { get; set; }
        public int numberOfRooms { get; set; }
        public int monthlyFee { get; set; }
        public int annualOperatingCost { get; set; }
        public int yearBuilt { get; set; }
        public string[] images { get; set; }
        public int categoryId { get; set; }
        public int brokerId { get; set; }
        public int municipalityId { get; set; }
        public Broker broker { get; set; }
        public Municipality municipality { get; set; }
        public Category category { get; set; }
    }

    public class Broker
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string imageUrl { get; set; }
        public Agency agency { get; set; }
    }

    public class Agency
    {
        public int id { get; set; }
        public string name { get; set; }
        public string presentation { get; set; }
        public string logoUrl { get; set; }
        public Broker1[] brokers { get; set; }
    }

    public class Broker1
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string imageUrl { get; set; }
    }

    public class Municipality
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Category
    {
        public int id { get; set; }
        public string name { get; set; }
    }




}
