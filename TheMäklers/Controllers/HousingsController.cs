using Microsoft.AspNetCore.Mvc;
using TheMäklersAPI.Data.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TheMäklersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HousingsController : ControllerBase
    {
        private readonly IHousingRepository _housingRepository;

        public HousingsController(IHousingRepository housingRepository)
        {
            _housingRepository = housingRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Housing>>> GetHousings()
        {
            var housings = await _housingRepository.GetHousingsAsync();
            return Ok(housings);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Housing>> GetHousing(int id)
        {
            var housing = await _housingRepository.GetHousingByIdAsync(id);
            if (housing == null)
            {
                return NotFound();
            }
            return Ok(housing);
        }

        [HttpPost]
        public async Task<ActionResult<Housing>> PostHousing(Housing housing)
        {
            await _housingRepository.AddHousingAsync(housing);
            return CreatedAtAction(nameof(GetHousing), new { id = housing.Id }, housing);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutHousing(int id, Housing housing)
        {
            if (id != housing.Id)
            {
                return BadRequest();
            }

            await _housingRepository.UpdateHousingAsync(housing);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHousing(int id)
        {
            var existingHousing = await _housingRepository.GetHousingByIdAsync(id);
            if (existingHousing == null)
            {
                return NotFound();
            }

            await _housingRepository.DeleteHousingAsync(existingHousing);
            return NoContent();
        }
    }
}
