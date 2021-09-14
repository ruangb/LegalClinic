using LC.Core.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LC.Manager.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetCustomersAsync();
        Task<Customer> GetCustomerAsync(int id);
        Task<Customer> InsertCustomerAsync(Customer customer);
        Task<Customer> UpdateCustomerAsync(Customer customer);
        Task DeleteCustomerAsync(int id);
    }
}
