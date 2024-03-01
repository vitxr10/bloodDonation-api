using BloodDonation.Application.Commands.CreateDonor;
using BloodDonation.Application.Commands.DeleteDonor;
using BloodDonation.Application.Commands.UpdateDonor;
using BloodDonation.Application.Queries.GetAllDonors;
using BloodDonation.Application.Queries.GetDonationsHistoric;
using BloodDonation.Application.Queries.GetDonor;
using BloodDonation.Core.Entities;
using BloodDonation.Core.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonation.API.Controllers
{
    [Route("api/donors")]
    [ApiController]
    public class DonorsController : ControllerBase
    {
        private readonly IMediator _mediatR;
        public DonorsController(IMediator mediatR)
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
            try
            {
                var query = new GetDonorByIdQuery(id);

                var donor = await _mediatR.Send(query);

                return Ok(donor);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        //[HttpGet("{id}/donations")]
        //public async Task<IActionResult> GetDonationsHistoric(int id)
        //{
        //    try
        //    {
        //        var query = new GetDonationsHistoricQuery(id);

        //        var donor = await _mediatR.Send(query);

        //        return Ok(donor);
        //    }
        //    catch (Exception ex)
        //    {
        //        return NotFound(ex.Message);
        //    }
        //}

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateDonorCommand command)
        {
            try
            {
                int id = await _mediatR.Send(command);

                return CreatedAtAction(nameof(GetById), new { id }, command);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateDonorCommand command)
        {
            try
            {
                command.Id = id;

                await _mediatR.Send(command);

                return NoContent();
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var command = new DeleteDonorCommand(id);

                await _mediatR.Send(command);

                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
