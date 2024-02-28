using BloodDonation.Application.Commands.CreateDonation;
using BloodDonation.Application.Queries.GetAllDonations;
using BloodDonation.Application.Queries.GetDonationById;
using BloodDonation.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonation.API.Controllers
{
    [Route("api/donation")]
    [ApiController]
    public class DonationController : ControllerBase
    {
        private readonly IMediator _mediatR;
        public DonationController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllDonationsQuery();

            var donations = await _mediatR.Send(query);

            return Ok(donations);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetDonationByIdQuery(id);

            var donation = await _mediatR.Send(query);

            return Ok(donation);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateDonationCommand command)
        {
            try
            {
                int id = await _mediatR.Send(command);

                return CreatedAtAction(nameof(GetById), new { id = id }, command);
            }
            catch(DirectoryNotFoundException ex)
            {
                return NotFound(ex.Message);
            }

        }

    }
}
