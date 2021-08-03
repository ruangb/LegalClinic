using LC.Core;
using LC.Manager.Interfaces;
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
            await context.SaveChangesAsync();

            return doctor;
        }

        public async Task<Doctor> UpdateDoctorAsync(Doctor doctor)
        {
            var foundDoctor = await context.Doctors.FindAsync(doctor.Id);

            if (foundDoctor == null)
                return null;

            context.Entry(foundDoctor).CurrentValues.SetValues(doctor);

            await context.SaveChangesAsync();

            return foundDoctor;
        }

        public async Task DeleteDoctorAsync(int id)
        {
            var foundDoctor = await context.Doctors.FindAsync(id);

            context.Doctors.Remove(foundDoctor);

            await context.SaveChangesAsync();
        }

    }
}
