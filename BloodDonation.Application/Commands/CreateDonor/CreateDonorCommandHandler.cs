using BloodDonation.Core.Entities;
using BloodDonation.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonation.Application.Commands.CreateDonor
{
    public class CreateDonorCommandHandler : IRequestHandler<CreateDonorCommand, int>
    {
        private readonly IDonorRepository _donorRepository;
        public CreateDonorCommandHandler(IDonorRepository donorRepository)
        {
            _donorRepository = donorRepository;
        }

        public async Task<int> Handle(CreateDonorCommand request, CancellationToken cancellationToken)
        {
            var donor = new Donor
                (
                request.FullName,
                request.Email,
                request.BirthDate,
                request.Gender,
                request.Weight,
                request.BloodType,
                request.RHFactor
                );

            await _donorRepository.CreateAsync(donor);

            var requestAddress = request.Address;
            var address = new Address
                (
                requestAddress.Neighborhood,
                requestAddress.City,
                requestAddress.State,
                requestAddress.ZipCode,
                donor.Id
                );

            donor.Address = address;

            await _donorRepository.SaveAsync();


            return donor.Id;
        }
    }
}
