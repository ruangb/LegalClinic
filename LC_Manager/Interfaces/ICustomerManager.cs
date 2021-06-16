using LC.Core.Shared.ModelViews;
using LC.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LC.Manager.Interfaces
{
    public interface ICustomerManager
    {
        Task<Customer> GetCustomerAsync(int id);
        Task<IEnumerable<Customer>> GetCustomersAsync();
        Task<Customer> InsertCustomerAsync(MvCustomer customer);
        Task<Customer> UpdateCustomerAsync(Customer customer);
        Task DeleteCustomerAsync(int id);
    }
}
