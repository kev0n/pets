using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using pets.Data;
using pets.Data.Interfaces;
using pets.Data.Models;

namespace pets.Repository
{
    public class OwnerRepository : RepositoryBase<Owner>, IOwnerRepository
    {
        public OwnerRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }


        public async Task<IEnumerable<Owner>> GetAllOwnersAsync()
        {
            return await RepositoryContext.Set<Owner>()
                .Include(x => x.Pets).ToListAsync();
        }

        public IQueryable<Owner> GetAllOwners()
        {
            return RepositoryContext.Set<Owner>()
                .Include(x=>x.Pets).AsNoTracking();
        }

        public Owner GetByOwnerId(int id)
        {
            return RepositoryContext.Set<Owner>().Include(x=>x.Pets).FirstOrDefault(x => x.Id == id);
        }

        public async Task<Owner> GetByOwnerIdAsync(int id)
        {
            return await RepositoryContext.Set<Owner>().Include(x => x.Pets).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
