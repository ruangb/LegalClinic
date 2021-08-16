using LC.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LC.Manager.Interfaces.Repositories
{
    public interface ISpecialtyRepository
    {
        Task<IEnumerable<Specialty>> GetSpecialtysAsync();
        Task<Specialty> GetSpecialtyAsync(int id);
        Task<Specialty> InsertSpecialtyAsync(Specialty doctor);
        Task<Specialty> UpdateSpecialtyAsync(Specialty doctor);
        Task DeleteSpecialtyAsync(int id);
    }
}
