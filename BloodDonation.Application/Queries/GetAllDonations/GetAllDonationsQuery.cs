using BloodDonation.Application.ViewModels;
using BloodDonation.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonation.Application.Queries.GetAllDonations
{
    public class GetAllDonationsQuery : IRequest<List<DonationViewModel>>
    {
        public int Id { get; set; }
        public int DonorId { get; set; }
        public double AmountInML { get; set; }
    }
}
