using Microsoft.AspNetCore.Mvc;
using TheMäklersAPI.Data.Models;
using TheMäklersAPI.Data.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TheMäklersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HousingsController : Controller //Author Kim
    {
        private readonly IHousing housingRepo;

        public HousingsController(IHousing housingRepository)
        {
            housingRepo = housingRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Housing>>> GetHousings()
        {
            var housings = await housingRepo.GetHousingsAsync();
            return Ok(housings);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Housing>> GetHousing(int id)
        {
            var housing = await housingRepo.GetHousingByIdAsync(id);
            if (housing == null)
            {
                return NotFound();
            }
            return Ok(housing);
        }

        [HttpPost]
        public async Task<ActionResult<Housing>> PostHousing(Housing housing)
        {
            await housingRepo.AddHousingAsync(housing);
            return CreatedAtAction(nameof(GetHousing), new { id = housing.Id }, housing);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutHousing(int id, Housing housing)
        {
            if (id != housing.Id)
            {
                return BadRequest();
            }

            await housingRepo.UpdateHousingAsync(housing);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHousing(int id)
        {
            var existingHousing = await housingRepo.GetHousingByIdAsync(id);
            if (existingHousing == null)
            {
                return NotFound();
            }

            await housingRepo.DeleteHousingAsync(existingHousing);
            return NoContent();
        }
    }
}
