using pets.Data;
using pets.Data.Interfaces;
using pets.Data.Models;

namespace pets.Repository
{
   public  class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
