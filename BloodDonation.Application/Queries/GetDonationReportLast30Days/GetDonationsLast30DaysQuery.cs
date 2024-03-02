using BloodDonation.Application.ViewModels;
using BloodDonation.Core.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonation.Application.Queries.GetDonationReportLast30Days
{
    public class GetDonationsLast30DaysQuery : IRequest<List<DonationsLast30DaysDTO>>
    {
    }
}
