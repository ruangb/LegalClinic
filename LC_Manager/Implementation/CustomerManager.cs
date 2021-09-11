using AutoMapper;
using LC.Core.Domain;
using LC.Core.Shared.ModelViews.Customer;
using LC.Manager.Interfaces.Repositories;
using LC.Manager.Interfaces.Managers;
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

        public async Task<IEnumerable<CustomerView>> GetCustomersAsync()
        {
            return mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerView>>(await customerRepository.GetCustomersAsync());
        }

        public async Task<CustomerView> GetCustomerAsync(int id)
        {
            return mapper.Map<CustomerView>(await customerRepository.GetCustomerAsync(id));
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
