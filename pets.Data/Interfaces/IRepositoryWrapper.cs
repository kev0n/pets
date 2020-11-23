using System.Threading.Tasks;

namespace pets.Data.Interfaces
{
    public interface IRepositoryWrapper
    {
        IOwnerRepository Owner { get; }
        IUserRepository User { get; }
        IPetRepository Pet { get;  }
        IVaccineRepository Vaccine { get; }
        IVaccinationRepository Vaccination { get; }
        void Save();
        Task SaveAsync();
    }
}