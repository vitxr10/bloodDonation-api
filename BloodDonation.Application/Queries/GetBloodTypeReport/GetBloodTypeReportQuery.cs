using BloodDonation.Application.ViewModels;
using BloodDonation.Core.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonation.Application.Queries.GetBloodTypeReport
{
    public class GetBloodTypeReportQuery : IRequest<List<BloodTypeReportViewModel>>
    {
    }
}
