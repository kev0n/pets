using System.Linq;
using Microsoft.AspNetCore.Mvc;
using pets.Data.Interfaces;

namespace pets.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private IRepositoryWrapper _repositoryWrapper;
        public UserController(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        [HttpGet]
        public string Get()
        {
            var cnt = _repositoryWrapper.User.GetAll().Count();
            return cnt.ToString();
        }
    }
}
