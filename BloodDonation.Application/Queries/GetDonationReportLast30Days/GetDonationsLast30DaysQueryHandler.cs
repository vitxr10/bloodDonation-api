using BloodDonation.Application.ViewModels;
using BloodDonation.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonation.Application.Queries.GetDonationReportLast30Days
{
    public class GetDonationsLast30DaysQueryHandler : IRequestHandler<GetDonationsLast30DaysQuery, List<DonationsLast30DaysViewModel>>
    {
        private readonly IDonationRepository _donationRepository;
        private readonly IDonorRepository _donorRepository;
        public GetDonationsLast30DaysQueryHandler(IDonationRepository donationRepository, IDonorRepository donorRepository)
        {
            _donationRepository = donationRepository;
            _donorRepository = donorRepository;
        }
        public async Task<List<DonationsLast30DaysViewModel>> Handle(GetDonationsLast30DaysQuery request, CancellationToken cancellationToken)
        {
            var donations = await _donationRepository.GetDonationsLast30Days();



            //var donationsLast30DaysViewModel = donations
            //    .Select(dn => new DonationsLast30DaysViewModel(dn.DonorId, dn.f))
        }
    }
}
