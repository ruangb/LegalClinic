using AutoMapper;
using LC.Core.Domain;
using LC.Core.Shared.ModelViews;
using LC.Manager.Interfaces.Repositories;
using LC.Manager.Interfaces.Managers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LC.Manager.Implementation
{
    public class DoctorManager : IDoctorManager
    {
        private readonly IDoctorRepository doctorRepository;
        private readonly IMapper mapper;

        public DoctorManager(IDoctorRepository doctorRepository, IMapper mapper)
        {
            this.doctorRepository = doctorRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<DoctorView>> GetDoctorsAsync()
        {
            return mapper.Map<IEnumerable<Doctor>, IEnumerable<DoctorView>>(await doctorRepository.GetDoctorsAsync());
        }

        public async Task<DoctorView> GetDoctorAsync(int id)
        {
            return mapper.Map<DoctorView>(await doctorRepository.GetDoctorAsync(id));
        }

        public async Task<Doctor> InsertDoctorAsync(NewDoctor newDoctor)
        {
            var doctor = mapper.Map<Doctor>(newDoctor);

            return await doctorRepository.InsertDoctorAsync(doctor);
        }

        public async Task<Doctor> UpdateDoctorAsync(UpdateDoctor updateDoctor)
        {
            var doctor = mapper.Map<Doctor>(updateDoctor);
         
            return await doctorRepository.UpdateDoctorAsync(doctor);
        }

        public async Task DeleteDoctorAsync(int id)
        {
            await doctorRepository.DeleteDoctorAsync(id);
        }
    }
}
