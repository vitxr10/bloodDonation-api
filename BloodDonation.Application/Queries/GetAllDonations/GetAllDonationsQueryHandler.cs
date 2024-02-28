using BloodDonation.Application.ViewModels;
using BloodDonation.Core.Entities;
using BloodDonation.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonation.Application.Queries.GetAllDonations
{
    public class GetAllDonationsQueryHandler : IRequestHandler<GetAllDonationsQuery, List<DonationViewModel>>
    {
        private readonly IDonationRepository _donationRepository;
        public GetAllDonationsQueryHandler(IDonationRepository donationRepository)
        {
            _donationRepository = donationRepository;
        }

        public async Task<List<DonationViewModel>> Handle(GetAllDonationsQuery request, CancellationToken cancellationToken)
        {
            var donations = await _donationRepository.GetAllAsync();

            var donationsViewModel = donations
                .Select(dn => new DonationViewModel(dn.Id, dn.DonorId, dn.AmountInML))
                .ToList();

            return donationsViewModel;
        }
    }
}
