using Microsoft.AspNetCore.Mvc;
using TheMäklersAPI.Data.Interfaces;
using TheMäklersAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TheMäklersAPI.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgencyController : ControllerBase //Author Felix
    {
        private readonly IAgency AgencyRepo;
        private readonly IBroker BrokerRepo;

        public AgencyController(IAgency AgencyRepository, IBroker BrokerRepository) 
        {
            AgencyRepo = AgencyRepository;
            BrokerRepo = BrokerRepository; 
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Agency>>> Get()
        {
            var agency = await AgencyRepo.GetAgencyAsync();
            return Ok(agency);
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

        [HttpPost] //Author Felix
        public async Task<ActionResult<Agency>> Post([FromBody] AgencyDto agencyDto) 
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var agency = new Agency
                {
                    Name = agencyDto.Name,
                    Presentation = agencyDto.Presentation,
                    LogoUrl = agencyDto.LogoUrl
                };

                if (agencyDto.BrokerId.HasValue)
                {
                    var broker = await BrokerRepo.GetBrokerByIdAsync(agencyDto.BrokerId.Value);
                    if (broker == null)
                    {
                        return BadRequest("Invalid broker Id");
                    }
                    broker.Agency = agency;
                }

                await AgencyRepo.AddAgencyAsync(agency);
                return CreatedAtAction(nameof(Get), new { id = agency.Id }, agency);
            }
            catch (Exception ex)
            {
                // Log the exception
                // Handle the exception appropriately (e.g., return a 500 Internal Server Error response)
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")] //Author Felix
        public async Task<IActionResult> Put(int id, [FromBody] AgencyDto agencyDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var agency = await AgencyRepo.GetAgencyByIdAsync(id);
                if (agency == null)
                {
                    return NotFound($"Agency with Id {id} not found");
                }

                agency.Name = agencyDto.Name;
                agency.Presentation = agencyDto.Presentation;
                agency.LogoUrl = agencyDto.LogoUrl;

                if (agencyDto.BrokerId.HasValue)
                {
                    var broker = await BrokerRepo.GetBrokerByIdAsync(agencyDto.BrokerId.Value);
                    if (broker == null)
                    {
                        return BadRequest("Invalid broker Id");
                    }
                    broker.Agency = agency;
                }
                //else
                //{
                //    agency.Brokers = null; // Remove association if BrokerId is not provided
                //}

                await AgencyRepo.UpdateAgencyAsync(agency);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
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

    public class AgencyDto //Author Felix
    {
        [Required]
        public string Name { get; set; }
        public string Presentation { get; set; }
        public string LogoUrl { get; set; }
        public int? BrokerId { get; set; } 
    }
}
