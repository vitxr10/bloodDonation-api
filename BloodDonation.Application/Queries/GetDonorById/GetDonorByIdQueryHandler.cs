using BloodDonation.Application.Queries.GetDonor;
using BloodDonation.Application.ViewModels;
using BloodDonation.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonation.Application.Queries.GetDonorById
{
    public class GetDonorByIdQueryHandler : IRequestHandler<GetDonorByIdQuery, DonorDetailsViewModel>
    {
        private readonly IDonorRepository _donorRepository;
        public GetDonorByIdQueryHandler(IDonorRepository donorRepository)
        {
            _donorRepository = donorRepository;
        }

        public async Task<DonorDetailsViewModel> Handle(GetDonorByIdQuery request, CancellationToken cancellationToken)
        {
            var donor = await _donorRepository.GetByIdAsync(request.Id);

            var donorDetailsViewModel = new DonorDetailsViewModel
                (
                    donor.Id,
                    donor.FullName,
                    donor.Email,
                    donor.BirthDate,
                    donor.Gender,
                    donor.Weight,
                    donor.BloodType,
                    donor.RHFactor,
                    donor.LastDonation,
                    donor.Active
                );

            return donorDetailsViewModel;
        }
    }
}
