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

        public async Task<bool> Exists(int id)
        {
            return await context.Specialties.FindAsync(id) != null;
        }
    }
}
