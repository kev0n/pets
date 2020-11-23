using pets.Data;
using pets.Data.Interfaces;
using pets.Data.Models;

namespace pets.Repository
{
    public class VaccineRepository : RepositoryBase<Vaccine>, IVaccineRepository
    {
        public VaccineRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
