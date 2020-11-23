using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using pets.Data;
using pets.Data.Interfaces;
using pets.Data.Models;

namespace pets.Repository
{
   public  class PetRepository : RepositoryBase<Pet>, IPetRepository
    {
        public PetRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
          
        }

        public IQueryable<Pet> GetAllPets()
        {
            return RepositoryContext.Set<Pet>()
                .Include(x => x.Owner)
                .Include(x=>x.Vaccinations).AsNoTracking();
        }

        public async Task<IEnumerable<Pet>> GetAllPetsAsync()
        {
            return await RepositoryContext.Set<Pet>()
                .Include(x => x.Owner)
                .Include(x => x.Vaccinations).ToListAsync();
        }

        public Pet GetByPetId(int id)
        {
            return RepositoryContext.Set<Pet>().Include(x => x.Owner)
                .Include(x => x.Vaccinations).FirstOrDefault(x => x.Id == id);
        }

        public async Task<Pet> GetByPetIdAsync(int id)
        {
            return await RepositoryContext.Set<Pet>().Include(x => x.Owner)
                .Include(x => x.Vaccinations).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
