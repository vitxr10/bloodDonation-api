using BloodDonation.Core.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonation.Application.Commands.CreateStock
{
    public class CreateStockCommand : IRequest<int>
    {
        public BloodTypeEnum BloodType { get; set; }
        public RHFactorEnum RHFactor { get; set; }
    }
}
