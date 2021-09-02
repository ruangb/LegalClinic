using LC.Core.Domain;
using LC.Manager.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LC.Data.Repository
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly LCContext context;

        public DoctorRepository(LCContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Doctor>> GetDoctorsAsync()
        {
            return await context.Doctors
                .Include(p => p.Specialties)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Doctor> GetDoctorAsync(int id)
        {
            return await context.Doctors
                .Include(p => p.Specialties)
                .SingleOrDefaultAsync(p => p.Id == id);
        } 

        public async Task<Doctor> InsertDoctorAsync(Doctor doctor)
        {
            await context.Doctors.AddAsync(doctor);
            await InsertDoctorSpecialties(doctor);
            await context.SaveChangesAsync();

            return doctor;
        }

        private async Task InsertDoctorSpecialties(Doctor doctor)
        {
            foreach (var specialty in doctor.Specialties)
            {
                var searchedSpecialty = await context.Specialties.AsNoTracking().FirstAsync(p => p.Id == specialty.Id);
                context.Entry(specialty).CurrentValues.SetValues(searchedSpecialty);
            }
        }

        public async Task<Doctor> UpdateDoctorAsync(Doctor doctor)
        {
            var searchedDoctor = await context.Doctors.Include(p => p.Specialties).SingleOrDefaultAsync(p => p.Id == doctor.Id);

            if (searchedDoctor == null)
                return null;

            context.Entry(searchedDoctor).CurrentValues.SetValues(doctor);

            await UpdateDoctorSpecialties(doctor, searchedDoctor);

            await context.SaveChangesAsync();

            return searchedDoctor;
        }

        private async Task UpdateDoctorSpecialties(Doctor doctor, Doctor searchedDoctor)
        {
            searchedDoctor.Specialties.Clear();

            foreach (var specialty in doctor.Specialties)
            {
                var searchedSpecialty = await context.Specialties.FindAsync(specialty.Id);
                searchedDoctor.Specialties.Add(searchedSpecialty);
            }
        }

        public async Task DeleteDoctorAsync(int id)
        {
            var searchedDoctor = await context.Doctors.FindAsync(id);

            context.Doctors.Remove(searchedDoctor);

            await context.SaveChangesAsync();
        }

    }
}
