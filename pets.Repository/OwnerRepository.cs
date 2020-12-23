using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using pets.Data;
using pets.Data.Interfaces;
using pets.Data.Models;

namespace pets.Repository {
    public class OwnerRepository : RepositoryBase<Owner>, IOwnerRepository {
        public OwnerRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }


        public async Task<IEnumerable<Owner>> GetAllOwnersAsync() {
            return await RepositoryContext.Set<Owner>()
                .Include(o => o.Pets)
                .ToListAsync();
        }

        public async Task<IEnumerable<Owner>> GetAllOwnersAsync(SearchParameters parameters) {
            var dbSet = RepositoryContext.Set<Owner>();
            return await dbSet.Where(o => o.FirstName.Contains(parameters.SearchText))
                .Union(dbSet.Where(o => o.LastName.Contains(parameters.SearchText)))
                .Union(dbSet.Where(o => o.PhoneNumber.Contains(parameters.SearchText)))
                .Include(o => o.Pets)
                .ToListAsync();
        }

        public IQueryable<Owner> GetAllOwners() {
            return RepositoryContext.Set<Owner>()
                .Include(o => o.Pets).AsNoTracking();
        }

        public Owner GetOwnerById(int id) {
            return RepositoryContext.Set<Owner>().Include(o => o.Pets).FirstOrDefault(o => o.Id == id);
        }

        public async Task<Owner> GetByOwnerIdAsync(int id) {
            return await RepositoryContext.Set<Owner>().Include(o => o.Pets).FirstOrDefaultAsync(o => o.Id == id);
        }
    }
}