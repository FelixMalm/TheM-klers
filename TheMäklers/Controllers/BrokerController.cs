using Microsoft.AspNetCore.Mvc;
using TheMäklersAPI.Data.Interfaces;
using TheMäklersAPI.Data.Models;
using TheMäklersAPI.Data.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
// Linus Anderstedt
namespace TheMäklersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrokerController : ControllerBase
    {
        private readonly IBroker brokerRepo;

        public BrokerController(IBroker brokerRepository)
        {
            brokerRepo = brokerRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Broker>>> GetBroker()
        {
            var brokers = await brokerRepo.GetBrokersAsync();
            return Ok(brokers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Broker>> GetBroker(int id)
        {
            var broker = await brokerRepo.GetBrokerByIdAsync(id);
            if (broker == null)
            {
                return NotFound();
            }
            return Ok(broker);
        }

        [HttpPost]
        public async Task<ActionResult<Broker>> PostBroker(Broker broker)
        {
            await brokerRepo.AddBrokerAsync(broker);
            return CreatedAtAction(nameof(GetBroker), new { id = broker.Id }, broker);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBroker(int id, Broker broker)
        {
            if (id != broker.Id)
            {
                return BadRequest();
            }

            await brokerRepo.UpdateBrokerAsync(broker);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBroker(int id)
        {
            var existingBroker = await brokerRepo.GetBrokerByIdAsync(id);
            if (existingBroker == null)
            {
                return NotFound();
            }

            await brokerRepo.DeleteBrokerAsync(existingBroker);
            return NoContent();
        }
    }
}
