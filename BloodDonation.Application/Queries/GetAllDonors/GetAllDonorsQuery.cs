using BloodDonation.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonation.Application.Queries.GetAllDonors
{
    public class GetAllDonorsQuery : IRequest<List<DonorViewModel>>
    {
    }
}
