using BloodDonation.Core.Entities;
using BloodDonation.Core.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonation.Application.Commands.UpdateDonor
{
    public class UpdateDonorCommand : IRequest
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public double Weight { get; set; }
        public Address Address { get; set; }
    }
}
