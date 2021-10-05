using LC.Core.Shared.ModelViews.Customer;
using LC.Core.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LC.Manager.Interfaces.Managers
{
    public interface ICustomerManager
    {
        Task<CustomerView> GetCustomerAsync(int id);
        Task<IEnumerable<CustomerView>> GetCustomersAsync();
        Task<CustomerView> InsertCustomerAsync(NewCustomer customer);
        Task<CustomerView> UpdateCustomerAsync(UpdateCustomer customer);
        Task<CustomerView> DeleteCustomerAsync(int id);
    }
}
