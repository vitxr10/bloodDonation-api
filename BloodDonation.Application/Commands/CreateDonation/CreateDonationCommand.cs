using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonation.Application.Commands.CreateDonation
{
    public class CreateDonationCommand : IRequest<int>
    {
        public int DonorId { get; set; }
        public double AmountInML { get; set; }
    }
}
