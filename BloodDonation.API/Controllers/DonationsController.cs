using BloodDonation.Application.Commands.CreateDonation;
using BloodDonation.Application.Queries.GetAllDonations;
using BloodDonation.Application.Queries.GetDonationById;
using BloodDonation.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonation.API.Controllers
{
    [Route("api/donations")]
    [ApiController]
    public class DonationsController : ControllerBase
    {
        private readonly IMediator _mediatR;
        public DonationsController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }

        /// <summary>
        /// Listar todas as doações
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllDonationsQuery();

            var donations = await _mediatR.Send(query);

            return Ok(donations);
        }

        /// <summary>
        /// Obter doação por id
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var query = new GetDonationByIdQuery(id);

                var donation = await _mediatR.Send(query);

                return Ok(donation);
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Cadastrar uma doação
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateDonationCommand command)
        {
            try
            {
                int id = await _mediatR.Send(command);

                return CreatedAtAction(nameof(GetById), new { id }, command);
            }
            catch (DirectoryNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
