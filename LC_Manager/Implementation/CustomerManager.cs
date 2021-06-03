using LC.Core;
using LC.Manager.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LC.Manager.Implementation
{
    public class CustomerManager : ICustomerManager
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerManager(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            return await customerRepository.GetCustomerAsync();
        }

        public async Task<Customer> GetCustomerAsync(int id)
        {
            return await customerRepository.GetCustomerAsync(id);
        }
    }
}
