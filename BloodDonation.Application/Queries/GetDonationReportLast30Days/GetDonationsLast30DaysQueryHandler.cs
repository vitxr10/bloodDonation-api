using BloodDonation.Application.ViewModels;
using BloodDonation.Core.DTOs;
using BloodDonation.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonation.Application.Queries.GetDonationReportLast30Days
{
    public class GetDonationsLast30DaysQueryHandler : IRequestHandler<GetDonationsLast30DaysQuery, List<DonationsLast30DaysDTO>>
    {
        private readonly IDonationRepository _donationRepository;
        private readonly IDonorRepository _donorRepository;
        public GetDonationsLast30DaysQueryHandler(IDonationRepository donationRepository, IDonorRepository donorRepository)
        {
            _donationRepository = donationRepository;
            _donorRepository = donorRepository;
        }
        public async Task<List<DonationsLast30DaysDTO>> Handle(GetDonationsLast30DaysQuery request, CancellationToken cancellationToken)
        {
            var donationsLast30Days = await _donationRepository.GetDonationsLast30Days();

            return donationsLast30Days;
        }
    }
}
