using LC.Core;
using Microsoft.EntityFrameworkCore;

namespace LC.Data
{
    public class LCContext : DbContext
    {
        public DbSet<Customer> Customers {get; set;}

        public LCContext(DbContextOptions options) : base(options)
        {

        }
    }
}
