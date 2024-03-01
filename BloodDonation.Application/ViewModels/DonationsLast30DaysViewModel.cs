using BloodDonation.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonation.Application.ViewModels
{
    public class DonationsLast30DaysViewModel
    {
        public DonationsLast30DaysViewModel(int donorId, string fullName, BloodTypeEnum bloodType, RHFactorEnum rHFactor, double amountInMl)
        {
            DonorId = donorId;
            FullName = fullName;
            BloodType = bloodType;
            RHFactor = rHFactor;
            AmountInMl = amountInMl;
        }

        public int DonorId { get; set; }
        public string FullName { get; set; }
        public BloodTypeEnum BloodType { get; set; }
        public RHFactorEnum RHFactor { get; set; }
        public double AmountInMl { get; set; }
    }
}
