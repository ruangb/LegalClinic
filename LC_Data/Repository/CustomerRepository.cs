using LC_Core;
using LC_Data;
using LC.Manager.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LC.Data.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly LCContext context;

        public CustomerRepository(LCContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Customer>> GetCustomerAsync()
        {
            return await context.Customers.AsNoTracking().ToListAsync();
        }

        public async Task<Customer> GetCustomerAsync(int id)
        {
            return await context.Customers.FindAsync(id);
        } 
    }
}
