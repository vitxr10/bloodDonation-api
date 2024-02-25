using BloodDonation.Application.ViewModels;
using BloodDonation.Core.Entities;
using BloodDonation.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonation.Application.Queries.GetAllDonors
{
    public class GetAllDonorsQueryHandler : IRequestHandler<GetAllDonorsQuery, List<DonorViewModel>>
    {
        private readonly IDonorRepository _donorRepository;
        public GetAllDonorsQueryHandler(IDonorRepository donorRepository)
        {
            _donorRepository = donorRepository;
        }

        public async Task<List<DonorViewModel>> Handle(GetAllDonorsQuery request, CancellationToken cancellationToken)
        {
            var donors = await _donorRepository.GetAllAsync();

            var donorsViewModel = donors
                .Select(d => new DonorViewModel(d.Id, d.FullName, d.Weight, d.BloodType, d.RHFactor))
                .ToList();

            return donorsViewModel;
        }
    }
}
