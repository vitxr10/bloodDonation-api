using BloodDonation.Application.Commands.CreateStock;
using BloodDonation.Application.Queries.GetAllStocks;
using BloodDonation.Application.Queries.GetStockById;
using BloodDonation.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonation.API.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IMediator _mediatR;
        public StockController(IMediator mediatR)
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
            var query = new GetStockByIdQuery(id);

            var stock = await _mediatR.Send(query);

            return Ok(stock);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateStockCommand command)
        {
            var id = await _mediatR.Send(command);

            return CreatedAtAction(nameof(GetById), new { id }, command);
        }

        //[HttpPut("{id}")]
        //public IActionResult Put(int id, [FromBody] Donor donor)
        //{
        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    return NoContent();
        //}
    }
}
