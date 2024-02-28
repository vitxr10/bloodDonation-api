using BloodDonation.Core.Entities;
using BloodDonation.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonation.Application.Commands.CreateStock
{
    public class CreateStockCommandHandler : IRequestHandler<CreateStockCommand, int>
    {
        private readonly IStockRepository _stockRepository;
        public CreateStockCommandHandler(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public async Task<int> Handle(CreateStockCommand request, CancellationToken cancellationToken)
        {
            var stock = new Stock(request.BloodType, request.RHFactor);

            await _stockRepository.CreateAsync(stock);

            return stock.Id;
        }
    }
}
