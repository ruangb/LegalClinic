namespace LC.Data.Repository
{
    public class CustomerRepositoryBase
    {

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