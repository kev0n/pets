using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pets.Data.Models;

namespace pets.Data.Interfaces
{
    public interface IOwnerRepository : IRepositoryBase<Owner>
    {
        IQueryable<Owner> GetAllOwners();
        Task<IEnumerable<Owner>> GetAllOwnersAsync();

        Owner GetByOwnerId(int id);
        Task<Owner> GetByOwnerIdAsync(int id);

    }
}
