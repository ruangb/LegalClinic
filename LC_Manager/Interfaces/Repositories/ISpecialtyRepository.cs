using System.Threading.Tasks;

namespace LC.Manager.Interfaces.Repositories
{
    public interface ISpecialtyRepository
    {
        Task<bool> Exists(int id);
    }
}
