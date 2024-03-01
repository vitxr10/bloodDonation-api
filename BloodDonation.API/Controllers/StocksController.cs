using BloodDonation.Application.Commands.CreateStock;
using BloodDonation.Application.Queries.GetAllStocks;
using BloodDonation.Application.Queries.GetStockById;
using BloodDonation.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonation.API.Controllers
{
    [Route("api/stocks")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        private readonly IMediator _mediatR;
        public StocksController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllStocksQuery();

            var stocks = await _mediatR.Send(query);

            return Ok(stocks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var query = new GetStockByIdQuery(id);

                var stock = await _mediatR.Send(query);

                return Ok(stock);
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateStockCommand command)
        {
            try
            {
                var id = await _mediatR.Send(command);

                return CreatedAtAction(nameof(GetById), new { id }, command);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
