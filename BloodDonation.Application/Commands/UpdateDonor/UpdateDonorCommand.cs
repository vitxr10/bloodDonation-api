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
        public UpdateDonorCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
        public double Weight { get; set; }
    }
}
