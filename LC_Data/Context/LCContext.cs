using LC_Core;
using Microsoft.EntityFrameworkCore;

namespace LC_Data
{
    public class LCContext : DbContext
    {
        public DbSet<Customer> Customers {get; set;}

        public LCContext(DbContextOptions options) : base(options)
        {

        }
    }
}
