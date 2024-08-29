using MascotasBack.Entities;
using MascotasBack.Interfaces;
using MascotasBack.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MascotasBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly IPetService _petService;

        public PetsController(IPetService petService)
        {
            _petService = petService;
        }

        [HttpGet("getPets")]
        public async Task<List<Pets>> GetPets()
        { 
            var pets = await _petService.GetPets();
            return pets;
        }

        [HttpPost("createPet")]
        public async Task<IActionResult> CreatePet([FromBody] PetCreationDto request)
        {
            try
            {
                await _petService.CreatePet(request);
                return Ok(new { message = "Pet created successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Failed to create pet: " + ex.Message });
            }
        }

        [HttpPut("updatePet/{id}")]
        public async Task<IActionResult> UpdatePet(int id, [FromBody] PetCreationDto request)
        {
            try
            {
                await _petService.UpdatePet(id, request);
                return Ok(new { message = "Pet update successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Failed to update pet: " + ex.Message });
            }
            
        }

        [HttpDelete("deletePet/{id}")]
        public async Task<IActionResult> DeletePet(int id)
        {
            try
            {
                await _petService.DeletePet(id);
                return Ok(new { message = "Pet deleted successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Failed to delete pet: " + ex.Message });
            }
        }

    }
}
