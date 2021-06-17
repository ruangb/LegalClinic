using AutoMapper;
using LC.Core;
using LC.Core.Shared.ModelViews;
using LC.Manager.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LC.Manager.Implementation
{
    public class CustomerManager : ICustomerManager
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IMapper mapper;

        public CustomerManager(ICustomerRepository customerRepository, IMapper mapper)
        {
            this.customerRepository = customerRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            return await customerRepository.GetCustomersAsync();
        }

        public async Task<Customer> GetCustomerAsync(int id)
        {
            return await customerRepository.GetCustomerAsync(id);
        }

        public async Task<Customer> InsertCustomerAsync(NewCustomer newCustomer)
        {
            var customer = mapper.Map<Customer>(newCustomer);

            return await customerRepository.InsertCustomerAsync(customer);
        }

        public async Task<Customer> UpdateCustomerAsync(UpdateCustomer updateCustomer)
        {
            var customer = mapper.Map<Customer>(updateCustomer);
         
            return await customerRepository.UpdateCustomerAsync(customer);
        }

        public async Task DeleteCustomerAsync(int id)
        {
            await customerRepository.DeleteCustomerAsync(id);
        }
    }
}
