using BloodDonation.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonation.Application.Queries.GetDonor
{
    public class GetDonorByIdQuery : IRequest<DonorDetailsViewModel>
    {
        public GetDonorByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
