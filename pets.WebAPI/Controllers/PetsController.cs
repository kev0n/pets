using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pets.Data.Interfaces;
using pets.Data.Models;

namespace pets.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetsController : ControllerBase
    {
        private IRepositoryWrapper _repositoryWrapper;
        public PetsController(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pet>>> GetAll()
        {
            return Ok(await _repositoryWrapper.Pet.GetAllPetsAsync());
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<User>> GetById(int id)
        {
            var pet = await _repositoryWrapper.Pet.GetByPetIdAsync(id);
            if (pet == null)
                return NotFound();
            return new ObjectResult(pet);
        }
        [HttpPost]
        public async Task<ActionResult<Pet>> Create(Pet pet)
        {
            if (pet == null) return BadRequest();
            var owner = await _repositoryWrapper.Owner.GetByIdAsync(pet.OwnerId);
            pet.Owner = owner;
            await _repositoryWrapper.Pet.CreateAsync(pet);
            await _repositoryWrapper.SaveAsync();
            return Ok(pet);
        }


        [HttpPut]
        public async Task<IActionResult> Update(Pet pet)
        {
            try
            {
                await _repositoryWrapper.Pet.UpdateAsync(pet);
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Owner>> Delete(int id)
        {
            Pet pet = await _repositoryWrapper.Pet.GetByIdAsync(id);
            if (pet == null)
            {
                return NotFound();
            }
            await _repositoryWrapper.Pet.DeleteAsync(pet);
            return Ok(pet);
        }
    }
}
