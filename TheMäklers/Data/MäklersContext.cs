using Microsoft.EntityFrameworkCore;
using TheMäklersAPI.Data.Models;

namespace TheMäklersAPI.Data
{
    public class MäklersContext : DbContext
    {
        public DbSet<Housing> Housing { get; set; }
        public DbSet<Agency> Agency { get; set; }
        public DbSet<Broker> Broker { get; set; }
        public DbSet<Municipality> Municipality { get; set; }



        public MäklersContext(DbContextOptions<MäklersContext> options)
            : base(options)
        {
        }
       




    }
}
