using System.Threading.Tasks;
using pets.Data;
using pets.Data.Interfaces;

namespace pets.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repositoryContext;
        private IOwnerRepository _owner;
        private IUserRepository _user;
        private IPetRepository _pet;
        private IVaccineRepository _vaccine;
        private IVaccinationRepository _vaccination;

        public IOwnerRepository Owner => _owner ??= new OwnerRepository(_repositoryContext);
        public IUserRepository User => _user ??= new UserRepository(_repositoryContext);
        public IPetRepository Pet => _pet ??= new PetRepository(_repositoryContext);
        public IVaccineRepository Vaccine => _vaccine ??= new VaccineRepository(_repositoryContext);
        public IVaccinationRepository Vaccination => _vaccination ??= new VaccinationRepository(_repositoryContext);

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        public void Save()
        {
            _repositoryContext.SaveChanges();
        }
        public async Task SaveAsync()
        {
           await _repositoryContext.SaveChangesAsync();
        }
    }
}
