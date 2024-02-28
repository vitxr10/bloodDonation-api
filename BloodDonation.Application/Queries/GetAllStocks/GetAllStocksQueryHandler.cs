using BloodDonation.Application.ViewModels;
using BloodDonation.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonation.Application.Queries.GetAllStocks
{
    public class GetAllStocksQueryHandler : IRequestHandler<GetAllStocksQuery, List<StockViewModel>>
    {
        private readonly IStockRepository _stockRepository;
        public GetAllStocksQueryHandler(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public async Task<List<StockViewModel>> Handle(GetAllStocksQuery request, CancellationToken cancellationToken)
        {
            var stocks = await _stockRepository.GetAllAsync();

            var stocksViewModel = stocks
                .Select(s => new StockViewModel(s.Id, s.BloodType, s.RHFactor, s.AmountInML))
                .ToList();

            return stocksViewModel;
        }
    }
}

