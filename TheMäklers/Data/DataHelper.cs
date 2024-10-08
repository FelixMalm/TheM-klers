﻿using TheMäklersAPI.Data.Models;

namespace TheMäklersAPI.Data
{
    public static class SeedHelper //Author Kim Jonsson
    {
        public static async Task DataHelper(MäklersContext context)
        {
            if (!context.Broker.Any())
            {
                // Create Agency instances
                var agency1 = new Agency
                {
                    Name = "Bill Robertson",
                    Presentation = "Luxury Living Experts",
                    LogoUrl = "https://cdn.logojoy.com/wp-content/uploads/2018/05/30150844/1415.png",
                };

                var agency2 = new Agency
                {
                    Name = "Real Estate",
                    Presentation = "Your Urban Lifestyle Specialists",
                    LogoUrl = "https://img.freepik.com/free-vector/real-estate-logo-template_1195-19.jpg",
                };

                var agency3 = new Agency
                {
                    Name = "Modern Home",
                    Presentation = "Coastal Living at Its Finest",
                    LogoUrl = "https://marketplace.canva.com/EAE2plelYDk/1/0/1600w/canva-modern-real-estate-agency-logo-template-l-8rw0yv5RA.jpg",
                };

                var broker1 = new Broker
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john.doe@example.com",
                    PhoneNumber = "123-456-7890",
                    ImageUrl = "https://bilder.hemnet.se/images/broker_profile_large/16/91/1691d7d43132f638d416b814532bc989.jpg",
                    Agency = agency1
                };

                var broker2 = new Broker
                {
                    FirstName = "Emily",
                    LastName = "Smith",
                    Email = "emily.smith@example.com",
                    PhoneNumber = "234-567-8901",
                    ImageUrl = "https://bilder.hemnet.se/images/broker_profile_large/f5/da/f5da602bc40d3fdaedaa2412398deba3.jpg",
                    Agency = agency1
                };

                var broker3 = new Broker
                {
                    FirstName = "Michael",
                    LastName = "Johnson",
                    Email = "michael.johnson@example.com",
                    PhoneNumber = "345-678-9012",
                    ImageUrl = "https://bilder.hemnet.se/images/broker_profile_large/22/05/2205a46acb2ce4570505ffa72f8d8df0.png",
                    Agency = agency2
                };

                var broker4 = new Broker
                {
                    FirstName = "Jessica",
                    LastName = "Brown",
                    Email = "jessica.brown@example.com",
                    PhoneNumber = "456-789-0123",
                    ImageUrl = "https://bilder.hemnet.se/images/broker_profile_large/8a/07/8a0797543b3d208e789583211d4e091a.jpg",
                    Agency = agency2
                };

                var broker5 = new Broker
                {
                    FirstName = "David",
                    LastName = "Martinez",
                    Email = "david.martinez@example.com",
                    PhoneNumber = "567-890-1234",
                    ImageUrl = "https://bilder.hemnet.se/images/broker_profile_large/3f/87/3f87ed4178955da1f8f699c1b27f4033.jpg",
                    Agency = agency2
                };

                var broker6 = new Broker
                {
                    FirstName = "Jennifer",
                    LastName = "Garcia",
                    Email = "jennifer.garcia@example.com",
                    PhoneNumber = "678-901-2345",
                    ImageUrl = "https://bilder.hemnet.se/images/broker_profile_large/b2/4e/b24e75cdd8f1d95e25321da17607058c.jpg",
                    Agency = agency3
                };

                var broker7 = new Broker
                {
                    FirstName = "Christopher",
                    LastName = "Wilson",
                    Email = "christopher.wilson@example.com",
                    PhoneNumber = "789-012-3456",
                    ImageUrl = "https://bilder.hemnet.se/images/broker_profile_large/da/73/da73431cec8b93e979ebea305ef6675c.jpg",
                    Agency = agency3
                };

                var broker8 = new Broker
                {
                    FirstName = "Ashley",
                    LastName = "Anderson",
                    Email = "ashley.anderson@example.com",
                    PhoneNumber = "890-123-4567",
                    ImageUrl = "https://bilder.hemnet.se/images/broker_profile_large/7b/82/7b82dcc7354c9f67c4a4da81675ce89f.jpg",
                    Agency = agency3
                };

                var broker9 = new Broker
                {
                    FirstName = "Matthew",
                    LastName = "Taylor",
                    Email = "matthew.taylor@example.com",
                    PhoneNumber = "901-234-5678",
                    ImageUrl = "https://bilder.hemnet.se/images/broker_profile_large/10/8d/108de1efe4f487cefd817d47cb0b6f66.jpg",
                    Agency = agency3
                };

                var broker10 = new Broker
                {
                    FirstName = "Jessica",
                    LastName = "Thomas",
                    Email = "jessica.thomas@example.com",
                    PhoneNumber = "012-345-6789",
                    ImageUrl = "https://bilder.hemnet.se/images/broker_profile_large/1b/92/1b9206e0d8fc0a6e7bbb75400172e85d.jpg",
                    Agency = agency3
                };

                var municipality1 = new Municipality { Name = "Ale" };
                var municipality2 = new Municipality { Name = "Alingsås" };
                var municipality3 = new Municipality { Name = "Alvesta" };
                var municipality4 = new Municipality { Name = "Aneby" };
                var municipality5 = new Municipality { Name = "Arboga" };
                var municipality6 = new Municipality { Name = "Arjeplog" };
                var municipality7 = new Municipality { Name = "Arvidsjaur" };
                var municipality8 = new Municipality { Name = "Arvika" };
                var municipality9 = new Municipality { Name = "Askersund" };
                var municipality10 = new Municipality { Name = "Avesta" };

                var category1 = new Category { Name = "Apartment" };
                var category2 = new Category { Name = "Villas" };
                var category3 = new Category { Name = "Leisure house" };
                var category4 = new Category { Name = "New production" };


                var housing1 = new Housing
                {
                    Address = "Storgatan 555",
                    InitialPrice = 250000,
                    LivingArea = 200,
                    AdditionalArea = 50,
                    PlotArea = 500,
                    Description = "Beautiful house with garden",
                    NumberOfRooms = 5,
                    MonthlyFee = 100,
                    AnnualOperatingCost = 2000,
                    YearBuilt = 2000,
                    Images = new List<string> { "https://bilder.hemnet.se/images/itemgallery_cut/f9/f4/f9f4298330076bc60e7731cc5af0ed7a.jpg", "https://bilder.hemnet.se/images/itemgallery_cut/8b/31/8b316314aad2956a958e0e61ee77e0a2.jpg" },
                    Municipality = municipality1,
                    Broker = broker1,
                    Category = category1

                };
                var housing2 = new Housing
                {
                    Address = "Stenvägen 4",
                    InitialPrice = 250000,
                    LivingArea = 200,
                    AdditionalArea = 50,
                    PlotArea = 500,
                    Description = "Beautiful cottage with garden",
                    NumberOfRooms = 5,
                    MonthlyFee = 100,
                    AnnualOperatingCost = 2000,
                    YearBuilt = 2000,
                    Images = new List<string> { "image_url1", "image_url2" },
                    Municipality = municipality2,
                    Broker = broker2,
                    Category = category2

                };
                var housing3 = new Housing
                {
                    Address = "Grusvägen 123",
                    InitialPrice = 250000,
                    LivingArea = 200,
                    AdditionalArea = 50,
                    PlotArea = 500,
                    Description = "Beautiful Condo with garden",
                    NumberOfRooms = 5,
                    MonthlyFee = 100,
                    AnnualOperatingCost = 2000,
                    YearBuilt = 2000,
                    Images = new List<string> { "image_url1", "image_url2" },
                    Municipality = municipality3,
                    Broker = broker3,
                    Category = category3

                };
                var housing4 = new Housing
                {
                    Address = "Mittivägen 55",
                    InitialPrice = 250000,
                    LivingArea = 200,
                    AdditionalArea = 50,
                    PlotArea = 500,
                    Description = "This is definitely a place where you can live",
                    NumberOfRooms = 5,
                    MonthlyFee = 100,
                    AnnualOperatingCost = 2000,
                    YearBuilt = 2000,
                    Images = new List<string> { "image_url1", "image_url2" },
                    Municipality = municipality4,
                    Broker = broker4,
                    Category = category4

                };
                var housing5 = new Housing
                {
                    Address = "Mittivägen 56",
                    InitialPrice = 100231,
                    LivingArea = 300,
                    AdditionalArea = 30,
                    PlotArea = 400,
                    Description = "Perfect place to live",
                    NumberOfRooms = 4,
                    MonthlyFee = 100,
                    AnnualOperatingCost = 3000,
                    YearBuilt = 2003,
                    Images = new List<string> { "image_url1", "image_url2" },
                    Municipality = municipality5,
                    Broker = broker5,
                    Category = category1
                };

                await context.AddRangeAsync(new List<Agency> { agency1, agency2, agency3 });
                await context.AddRangeAsync(new List<Broker> { broker1, broker2, broker3, broker4, broker5, broker6, broker7, broker8, broker9, broker10 });
                await context.AddRangeAsync(new List<Municipality> { municipality1, municipality2, municipality3, municipality4, municipality5, municipality6, municipality7, municipality8, municipality9, municipality10 });
                await context.AddRangeAsync(new List<Category> { category1, category2, category3, category4 });
                await context.AddRangeAsync(new List<Housing> { housing1, housing2, housing3, housing4, housing5 });
                await context.SaveChangesAsync();
            }
        }
    }
}