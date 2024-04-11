using Microsoft.AspNetCore.Mvc;
using TheMäklersAPI.Data.Interfaces;
using TheMäklersAPI.Data.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TheMäklersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgencyController : ControllerBase
    {
        private readonly IAgency AgencyRepo;
        public AgencyController(IAgency AgencyRepository)
        {
            AgencyRepo = AgencyRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Agency>>> Get()
        {
            var agencies = await AgencyRepo.GetAgencyAsync();
            return Ok(agencies);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Agency>> Get(int id)
        {
            var agency = await AgencyRepo.GetAgencyByIdAsync(id);
            if (agency == null)
            {
                return NotFound();
            }
            return Ok(agency);
        }

        [HttpPost]
        public async Task<ActionResult<Agency>> Post([FromBody] Agency agency)
        {
            if (agency == null)
            {
                return BadRequest();
            }

            await AgencyRepo.AddAgencyAsync(agency);
            return CreatedAtAction(nameof(Get), new { id = agency.Id }, agency);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Agency agency)
        {
            if (id != agency.Id)
            {
                return BadRequest();
            }

            try
            {
                await AgencyRepo.UpdateAgencyAsync(id);
            }
            catch (Exception)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingAgency = await AgencyRepo.GetAgencyByIdAsync(id);
            if (existingAgency == null)
            {
                return NotFound();
            }

            await AgencyRepo.DeleteAgencyAsync(id);
            return NoContent();
        }
    }
}
