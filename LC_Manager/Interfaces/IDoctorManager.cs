using LC.Core.Shared.ModelViews;
using LC.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LC.Manager.Interfaces
{
    public interface IDoctorManager
    {
        Task<DoctorView> GetDoctorAsync(int id);
        Task<IEnumerable<DoctorView>> GetDoctorsAsync();
        Task<Doctor> InsertDoctorAsync(NewDoctor customer);
        Task<Doctor> UpdateDoctorAsync(UpdateDoctor customer);
        Task DeleteDoctorAsync(int id);
    }
}
