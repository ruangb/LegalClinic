using LC.Core;
using LC.Manager.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LC.Data.Repository
{
    public class SpecialtyRepository : ISpecialtyRepository
    {
        private readonly LCContext context;

        public SpecialtyRepository(LCContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Specialty>> GetSpecialtiesAsync()
        {
            return await context.Specialties
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Specialty> GetSpecialtyAsync(int id)
        {
            return await context.Specialties
                .SingleOrDefaultAsync(p => p.Id == id);
        } 

        public async Task<Specialty> InsertSpecialtyAsync(Specialty customer)
        {
            await context.Specialties.AddAsync(customer);
            await context.SaveChangesAsync();

            return customer;
        }

        public async Task<Specialty> UpdateSpecialtyAsync(Specialty customer)
        {
            var searchedSpecialty = await context.Specialties.FindAsync(customer.Id);

            if (searchedSpecialty == null)
                return null;

            context.Entry(searchedSpecialty).CurrentValues.SetValues(customer);

            await context.SaveChangesAsync();

            return searchedSpecialty;
        }

        public async Task DeleteSpecialtyAsync(int id)
        {
            var searchedSpecialty = await context.Specialties.FindAsync(id);

            context.Specialties.Remove(searchedSpecialty);

            await context.SaveChangesAsync();
        }

        public Task<IEnumerable<Specialty>> GetSpecialtysAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
