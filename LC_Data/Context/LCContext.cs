using LC.Core;
using LC.Data.Configuration;
using Microsoft.EntityFrameworkCore;

namespace LC.Data
{
    public class LCContext : DbContext
    {
        public DbSet<Customer> Customers {get; set;}
        public DbSet<Address> Addresses {get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Specialty> Specialties { get; set; }

        public LCContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new AddressConfiguration());
            modelBuilder.ApplyConfiguration(new PhonesConfiguration());
        }
    }
}
