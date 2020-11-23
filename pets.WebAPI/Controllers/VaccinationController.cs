using System.Linq;
using Microsoft.AspNetCore.Mvc;
using pets.Data.Interfaces;

namespace pets.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VaccinationController : ControllerBase
    {
        private IRepositoryWrapper _repositoryWrapper;
        public VaccinationController(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        [HttpGet]
        public string Get()
        {
            var cnt = _repositoryWrapper.Vaccination.GetAll().Count();
            return cnt.ToString();
        }
    }
}
