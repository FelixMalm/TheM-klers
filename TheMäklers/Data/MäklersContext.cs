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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the relationship between Housing and Broker
            modelBuilder.Entity<Housing>()
                .HasOne(h => h.Broker)
                .WithMany(b => b.Housings)
                .HasForeignKey(h => h.BrokerId)
                .OnDelete(DeleteBehavior.Restrict); // Disable cascade delete for this relationship

            // Configure the relationship between Housing and Agency
            modelBuilder.Entity<Housing>()
                .HasOne(h => h.Agency)
                .WithMany(a => a.Housings)
                .HasForeignKey(h => h.AgencyId)
                .OnDelete(DeleteBehavior.Cascade); // Allow cascade delete for this relationship

            // Other configurations...

            base.OnModelCreating(modelBuilder);
        }




    }
}
