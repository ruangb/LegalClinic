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
            return await customerRepository.GetCustomersAsync();
        }

        public async Task<Customer> GetCustomerAsync(int id)
        {
            return await customerRepository.GetCustomerAsync(id);
        }

        public async Task<Customer> InsertCustomerAsync(Customer customer)
        {
            return await customerRepository.InsertCustomerAsync(customer);
        }

        public async Task<Customer> UpdateCustomerAsync(Customer customer)
        {
            return await customerRepository.UpdateCustomerAsync(customer);
        }

        public async Task DeleteCustomerAsync(int id)
        {
            await customerRepository.DeleteCustomerAsync(id);
        }
    }
}
