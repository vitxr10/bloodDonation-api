using BloodDonation.Core.Entities;
using BloodDonation.Core.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonation.API.Controllers
{
    [Route("api/donor")]
    [ApiController]
    public class DonorController : ControllerBase
    {
        private readonly IDonorRepository _donorRepository;
        public DonorController(IDonorRepository donorRepository)
        {
            _donorRepository = donorRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var donors = await _donorRepository.GetAllAsync();
            return Ok(donors);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Donor donor) 
        {
            await _donorRepository.CreateAsync(donor);

            return CreatedAtAction(nameof(GetById), new { id = donor.Id }, donor);
        }
            
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Donor donor)
        {
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return NoContent();
        }
    }
}
