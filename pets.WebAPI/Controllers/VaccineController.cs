using System.Linq;
using Microsoft.AspNetCore.Mvc;
using pets.Data.Interfaces;

namespace pets.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VaccineController : ControllerBase
    {
        private IRepositoryWrapper _repositoryWrapper;
        public VaccineController(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        [HttpGet]
        public string Get()
        {
            var cnt = _repositoryWrapper.Vaccine.GetAll().Count();
            return cnt.ToString();
        }
    }
}
