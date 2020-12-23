using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pets.Data.Interfaces;
using pets.Data.Models;

namespace pets.WebAPI.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class OwnerController : ControllerBase {
        private IRepositoryWrapper _repositoryWrapper;

        public OwnerController(IRepositoryWrapper repositoryWrapper) {
            _repositoryWrapper = repositoryWrapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Owner>>> GetAll([FromQuery(Name = "searchText")] string searchText) {
            return string.IsNullOrEmpty(searchText)
                ? Ok(await _repositoryWrapper.Owner.GetAllOwnersAsync())
                : Ok(await _repositoryWrapper.Owner.GetAllOwnersAsync(new SearchParameters {SearchText = searchText}));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<User>> GetById(int id) {
            var owner = await _repositoryWrapper.Owner.GetByOwnerIdAsync(id);
            if (owner == null)
                return NotFound();
            return new ObjectResult(owner);
        }

        [HttpPost]
        public async Task<ActionResult<Owner>> Create(Owner owner) {
            if (owner == null) return BadRequest();
            await _repositoryWrapper.Owner.CreateAsync(owner);
            await _repositoryWrapper.SaveAsync();
            return Ok(owner);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Owner owner) {
            try {
                await _repositoryWrapper.Owner.UpdateAsync(owner);
            }
            catch (DbUpdateConcurrencyException) {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Owner>> Delete(int id) {
            Owner owner = await _repositoryWrapper.Owner.GetByIdAsync(id);
            if (owner == null) {
                return NotFound();
            }

            await _repositoryWrapper.Owner.DeleteAsync(owner);
            return Ok(owner);
        }
    }
}