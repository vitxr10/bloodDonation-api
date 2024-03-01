using BloodDonation.Application.ViewModels;
using BloodDonation.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonation.Application.Queries.GetDonationById
{
    public class GetDonationByIdQueryHandler : IRequestHandler<GetDonationByIdQuery, DonationDetailsViewModel>
    {
        private readonly IDonationRepository _donationRepository;
        public GetDonationByIdQueryHandler(IDonationRepository donationRepository)
        {
            _donationRepository = donationRepository;
        }

        public async Task<DonationDetailsViewModel> Handle(GetDonationByIdQuery request, CancellationToken cancellationToken)
        {
            var donation = await _donationRepository.GetByIdAsync(request.Id);

            if (donation == null)
                throw new Exception("Doação não foi encontrada");

            var donationDetailsViewModel = new DonationDetailsViewModel
                (
                    donation.Id,
                    donation.DonorId,
                    donation.DonationDate,
                    donation.AmountInML
                );

            return donationDetailsViewModel;
        }
    }
}
