using BloodDonation.Application.ViewModels;
using BloodDonation.Core.Entities;
using BloodDonation.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonation.Application.Queries.GetDonationsHistoric
{
    public class GetDonationsHistoricQueryHandler : IRequestHandler<GetDonationsHistoricQuery, List<DonationsHistoricViewModel>>
    {
        private readonly IDonationRepository _donationRepository;
        public GetDonationsHistoricQueryHandler(IDonationRepository donationRepository)
        {
            _donationRepository = donationRepository;
        }

        public async Task<List<DonationsHistoricViewModel>> Handle(GetDonationsHistoricQuery request, CancellationToken cancellationToken)
        {
            var donations = await _donationRepository.GetDonationsHistoric(request.DonorId);

            if (donations.Count == 0)
                throw new Exception("O doador não foi encontrado");

            var donationsHistoricViewModel = donations
                .Select(dn => new DonationsHistoricViewModel(dn.Id, dn.DonationDate, dn.AmountInML))
                .ToList();

            return donationsHistoricViewModel;
        }
    }
}
