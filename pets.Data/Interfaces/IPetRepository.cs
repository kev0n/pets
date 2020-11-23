using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pets.Data.Models;

namespace pets.Data.Interfaces
{
    public interface IPetRepository : IRepositoryBase<Pet>
    {
        IQueryable<Pet> GetAllPets();
        Task<IEnumerable<Pet>> GetAllPetsAsync();

        Pet GetByPetId(int id);
        Task<Pet> GetByPetIdAsync(int id);
    }
}
