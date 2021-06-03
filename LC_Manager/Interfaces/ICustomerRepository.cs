using LC.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LC.Manager.Interfaces
{
    public interface ICustomerRepository
    {
       Task<IEnumerable<Customer>> GetCustomerAsync();
       Task<Customer> GetCustomerAsync(int id);
    }
}
