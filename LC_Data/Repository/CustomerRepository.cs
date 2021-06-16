using LC.Core;
using LC.Core.Shared.ModelViews;
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

        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            return await context.Customers.AsNoTracking().ToListAsync();
        }

        public async Task<Customer> GetCustomerAsync(int id)
        {
            return await context.Customers.FindAsync(id);
        } 

        public async Task<Customer> InsertCustomerAsync(Customer customer)
        {
            await context.Customers.AddAsync(customer);
            await context.SaveChangesAsync();

            return customer;
        }

        public async Task<Customer> UpdateCustomerAsync(Customer customer)
        {
            var foundCustomer = await context.Customers.FindAsync(customer.Id);

            if (foundCustomer == null)
                return null;

            context.Entry(foundCustomer).CurrentValues.SetValues(customer);

            await context.SaveChangesAsync();

            return foundCustomer;
        }

        public async Task DeleteCustomerAsync(int id)
        {
            var foundCustomer = await context.Customers.FindAsync(id);

            context.Customers.Remove(foundCustomer);

            await context.SaveChangesAsync();
        }

    }
}
