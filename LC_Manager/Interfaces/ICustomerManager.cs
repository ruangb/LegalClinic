using LC_Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LC.Manager.Interfaces
{
    public interface ICustomerManager
    {
        Task<Customer> GetCustomerAsync(int id);
        Task<IEnumerable<Customer>> GetCustomersAsync();
    }
}
