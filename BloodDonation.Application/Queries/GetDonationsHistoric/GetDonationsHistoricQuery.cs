using BloodDonation.Application.ViewModels;
using BloodDonation.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonation.Application.Queries.GetDonationsHistoric
{
    public class GetDonationsHistoricQuery : IRequest<List<DonationsHistoricViewModel>>
    {
        public GetDonationsHistoricQuery(int donorId)
        {
            DonorId = donorId;
        }

        public int DonorId { get; set; }
    }
}
