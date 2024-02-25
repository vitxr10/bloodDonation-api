using BloodDonation.Application.Commands.CreateDonor;
using BloodDonation.Application.Commands.DeleteDonor;
using BloodDonation.Application.Commands.UpdateDonor;
using BloodDonation.Application.Queries.GetAllDonors;
using BloodDonation.Application.Queries.GetDonor;
using BloodDonation.Core.Entities;
using BloodDonation.Core.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonation.API.Controllers
{
    [Route("api/donor")]
    [ApiController]
    public class DonorController : ControllerBase
    {
        private readonly IMediator _mediatR;
        public DonorController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllDonorsQuery();

            var donors = await _mediatR.Send(query);

            return Ok(donors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetDonorByIdQuery(id);

            var donor = await _mediatR.Send(query);

            return Ok(donor);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateDonorCommand command)
        {
            int id = await _mediatR.Send(command);

            return CreatedAtAction(nameof(GetById), new { id }, command);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateDonorCommand command)
        {
            command.Id = id;

            await _mediatR.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteDonorCommand(id);

            await _mediatR.Send(command);

            return NoContent();
        }
    }
}
