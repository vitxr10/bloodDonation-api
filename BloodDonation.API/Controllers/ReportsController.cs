using BloodDonation.Application.Queries.GetAllStocks;
using BloodDonation.Application.Queries.GetBloodTypeReport;
using BloodDonation.Application.Queries.GetDonationReportLast30Days;
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

        /// <summary>
        /// Obter histórico de doações de um doador
        /// </summary>
        [HttpGet("donors/{id}/donations")]
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

        /// <summary>
        /// Obter relatório de estoque por tipo sanguíneo 
        /// </summary>
        [HttpGet("stocks")]
        public async Task<IActionResult> GetBloodTypeReport()
        {
            var query = new GetBloodTypeReportQuery();

            var stocks = await _mediatR.Send(query);

            return Ok(stocks);
        }

        /// <summary>
        /// Obter relatório de doações dos últimos 30 dias
        /// </summary>
        [HttpGet("donations")]
        public async Task<IActionResult> GetDonationReportLast30Days()
        {
            var query = new GetDonationsLast30DaysQuery();

            var donationsLast30Days = await _mediatR.Send(query);

            return Ok(donationsLast30Days);
        }
    }
}
