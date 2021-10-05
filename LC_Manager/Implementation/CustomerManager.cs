using AutoMapper;
using LC.Core.Domain;
using LC.Core.Shared.ModelViews.Customer;
using LC.Manager.Interfaces.Repositories;
using LC.Manager.Interfaces.Managers;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace LC.Manager.Implementation
{
    public class CustomerManager : ICustomerManager
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IMapper mapper;
        private readonly ILogger<CustomerManager> logger;

        public CustomerManager(ICustomerRepository customerRepository, IMapper mapper, ILogger<CustomerManager> logger)
        {
            this.customerRepository = customerRepository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<IEnumerable<CustomerView>> GetCustomersAsync()
        {
            return mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerView>>(await customerRepository.GetCustomersAsync());
        }

        public async Task<CustomerView> GetCustomerAsync(int id)
        {
            return mapper.Map<CustomerView>(await customerRepository.GetCustomerAsync(id));
        }

        public async Task<CustomerView> InsertCustomerAsync(NewCustomer newCustomer)
        {
            logger.LogInformation("Chamada de negócio para inserir um cliente.");

            var customer = mapper.Map<Customer>(newCustomer);

            customer = await customerRepository.InsertCustomerAsync(customer);

            return mapper.Map<CustomerView>(customer);
        }

        public async Task<CustomerView> UpdateCustomerAsync(UpdateCustomer updateCustomer)
        {
            var customer = mapper.Map<Customer>(updateCustomer);

            customer = await customerRepository.UpdateCustomerAsync(customer);

            return mapper.Map<CustomerView>(customer);
        }

        public async Task<CustomerView> DeleteCustomerAsync(int id)
        {
            var cliente = await customerRepository.DeleteCustomerAsync(id);

            return mapper.Map<CustomerView>(cliente);
        }
    }
}
