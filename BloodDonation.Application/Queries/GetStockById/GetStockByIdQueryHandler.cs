using BloodDonation.Application.ViewModels;
using BloodDonation.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonation.Application.Queries.GetStockById
{
    public class GetStockByIdQueryHandler : IRequestHandler<GetStockByIdQuery, StockViewModel>
    {
        private readonly IStockRepository _stockRepository;
        public GetStockByIdQueryHandler(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public async Task<StockViewModel> Handle(GetStockByIdQuery request, CancellationToken cancellationToken)
        {
            var stock = await _stockRepository.GetByIdAsync(request.Id);

            if (stock == null)
                throw new Exception("Estoque não encontrado.");

            var stockViewModel = new StockViewModel(stock.Id, stock.BloodType, stock.RHFactor, stock.AmountInML);

            return stockViewModel;
        }
    }
}
