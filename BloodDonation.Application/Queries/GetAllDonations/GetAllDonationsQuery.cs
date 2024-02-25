using BloodDonation.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonation.Application.Queries.GetAllDonations
{
    public class GetAllDonationsQuery : IRequest<List<Donation>>
    {
        public int Id { get; set; }
        public int DonorId { get; set; }
        public double AmountInML { get; set; }
    }
}
