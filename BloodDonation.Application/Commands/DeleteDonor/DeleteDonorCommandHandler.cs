using BloodDonation.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonation.Application.Commands.DeleteDonor
{
    public class DeleteDonorCommandHandler : IRequestHandler<DeleteDonorCommand>
    {
        private readonly IDonorRepository _donorRepository;
        public DeleteDonorCommandHandler(IDonorRepository donorRepository)
        {
            _donorRepository = donorRepository;
        }

        public async Task Handle(DeleteDonorCommand request, CancellationToken cancellationToken)
        {
            var donor = await _donorRepository.GetByIdAsync(request.Id);

            if (donor == null)
                throw new Exception("Doador não encontrado.");

            donor.Delete();

            await _donorRepository.SaveAsync();
        }
    }
}
