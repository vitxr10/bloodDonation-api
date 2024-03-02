using BloodDonation.Application.ViewModels;
using BloodDonation.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonation.Application.Queries.GetBloodTypeReport
{
    public class GetBloodTypeReportQueryHandler : IRequestHandler<GetBloodTypeReportQuery, List<BloodTypeReportViewModel>>
    {
        private readonly IStockRepository _stockRepository;
        public GetBloodTypeReportQueryHandler(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }
        public async Task<List<BloodTypeReportViewModel>> Handle(GetBloodTypeReportQuery request, CancellationToken cancellationToken)
        {
            var stocks = await _stockRepository.GetAllAsync();

            var bloodTypeReportViewModel = stocks
                .Select(r => new BloodTypeReportViewModel(r.BloodType, r.RHFactor, r.AmountInML))
                .ToList();

            return bloodTypeReportViewModel;
        }
    }
}
