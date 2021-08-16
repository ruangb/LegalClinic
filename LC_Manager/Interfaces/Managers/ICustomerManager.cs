using LC.Core.Shared.ModelViews;
using LC.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LC.Manager.Interfaces.Managers
{
    public interface ICustomerManager
    {
        Task<Customer> GetCustomerAsync(int id);
        Task<IEnumerable<Customer>> GetCustomersAsync();
        Task<Customer> InsertCustomerAsync(NewCustomer customer);
        Task<Customer> UpdateCustomerAsync(UpdateCustomer customer);
        Task DeleteCustomerAsync(int id);
    }
}
