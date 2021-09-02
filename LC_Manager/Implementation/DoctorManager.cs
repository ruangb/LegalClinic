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
        private readonly IDoctorRepository customerRepository;
        private readonly IMapper mapper;

        public DoctorManager(IDoctorRepository customerRepository, IMapper mapper)
        {
            this.customerRepository = customerRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<DoctorView>> GetDoctorsAsync()
        {
            return mapper.Map<IEnumerable<Doctor>, IEnumerable<DoctorView>>(await customerRepository.GetDoctorsAsync());
        }

        public async Task<DoctorView> GetDoctorAsync(int id)
        {
            return mapper.Map<DoctorView>(await customerRepository.GetDoctorAsync(id));
        }

        public async Task<Doctor> InsertDoctorAsync(NewDoctor newDoctor)
        {
            var customer = mapper.Map<Doctor>(newDoctor);

            return await customerRepository.InsertDoctorAsync(customer);
        }

        public async Task<Doctor> UpdateDoctorAsync(UpdateDoctor updateDoctor)
        {
            var customer = mapper.Map<Doctor>(updateDoctor);
         
            return await customerRepository.UpdateDoctorAsync(customer);
        }

        public async Task DeleteDoctorAsync(int id)
        {
            await customerRepository.DeleteDoctorAsync(id);
        }
    }
}
