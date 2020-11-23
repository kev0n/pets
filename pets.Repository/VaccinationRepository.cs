using pets.Data;
using pets.Data.Interfaces;
using pets.Data.Models;

namespace pets.Repository
{
    public class VaccinationRepository : RepositoryBase<Vaccination>, IVaccinationRepository
    {
        public VaccinationRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
