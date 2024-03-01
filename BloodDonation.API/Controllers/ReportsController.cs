using BloodDonation.Application.Queries.GetAllStocks;
using BloodDonation.Application.Queries.GetBloodTypeReport;
using BloodDonation.Application.Queries.GetDonationsHistoric;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonation.API.Controllers
{
    [Route("api/reports")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IMediator _mediatR;
        public ReportsController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }

        [HttpGet("/donors/{id}/donations")]
        public async Task<IActionResult> GetDonationsHistoric(int id)
        {
            try
            {
                var query = new GetDonationsHistoricQuery(id);

                var donor = await _mediatR.Send(query);

                return Ok(donor);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("/stocks")]
        public async Task<IActionResult> GetBloodTypeReport()
        {
            var query = new GetBloodTypeReportQuery();

            var stocks = await _mediatR.Send(query);

            return Ok(stocks);
        }

        [HttpGet("/donations")]
        public async Task<IActionResult> GetDonationReportLast30Days()
        {

        }




    }
}
