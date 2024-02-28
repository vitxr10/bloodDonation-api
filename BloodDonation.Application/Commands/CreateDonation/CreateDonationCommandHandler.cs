using BloodDonation.Core.Entities;
using BloodDonation.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonation.Application.Commands.CreateDonation
{
    public class CreateDonationCommandHandler : IRequestHandler<CreateDonationCommand, int>
    {
        private readonly IDonationRepository _donationRepository;
        private readonly IDonorRepository _donorRepository;
        private readonly IStockRepository _stockRepository;
        public CreateDonationCommandHandler(IDonationRepository donationRepository, IDonorRepository donorRepository, IStockRepository stockRepository)
        {
            _donationRepository = donationRepository;
            _donorRepository = donorRepository;
            _stockRepository = stockRepository;
        }

        public async Task<int> Handle(CreateDonationCommand request, CancellationToken cancellationToken)
        {
            var donation = new Donation(request.DonorId, DateTime.Now, request.AmountInML);

            await _donationRepository.CreateAsync(donation);

            var donor = await _donorRepository.GetByIdAsync(donation.DonorId);
            var stock = await _stockRepository.GetByBloodTypeAsync(donor.BloodType, donor.RHFactor);

            if (stock == null)
                throw new DirectoryNotFoundException("Não há estoque para esse tipo sanguíneo.");
           

            stock.UpdateBloodStock(donation.AmountInML);
            await _stockRepository.SaveAsync();

            return donation.Id;
        }
    }
}
