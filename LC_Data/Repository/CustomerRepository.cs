using LC.Core;
using LC.Manager.Interfaces.Repositories;
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
            return await context.Customers
                .Include(p => p.Address)
                .Include(p => p.Phones)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Customer> GetCustomerAsync(int id)
        {
            return await context.Customers
                .Include(p => p.Address)
                .Include(p => p.Phones)
                .SingleOrDefaultAsync(p => p.Id == id);
        } 

        public async Task<Customer> InsertCustomerAsync(Customer customer)
        {
            await context.Customers.AddAsync(customer);
            await context.SaveChangesAsync();

            return customer;
        }

        public async Task<Customer> UpdateCustomerAsync(Customer customer)
        {
            var searchedCustomer = await context.Customers.FindAsync(customer.Id);

            if (searchedCustomer == null)
                return null;

            context.Entry(searchedCustomer).CurrentValues.SetValues(customer);

            await context.SaveChangesAsync();

            return searchedCustomer;
        }

        public async Task DeleteCustomerAsync(int id)
        {
            var searchedCustomer = await context.Customers.FindAsync(id);

            context.Customers.Remove(searchedCustomer);

            await context.SaveChangesAsync();
        }

    }
}
