using BloodDonation.Core.Entities;
using BloodDonation.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonation.Application.ViewModels
{
    public class DonorViewModel
    {
        public DonorViewModel(int id, string fullName, double weight, BloodTypeEnum bloodType, RHFactorEnum rHFactor)
        {
            Id = id;
            FullName = fullName;
            Weight = weight;
            BloodType = bloodType;
            RHFactor = rHFactor;
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public double Weight { get; set; }
        public BloodTypeEnum BloodType { get; set; }
        public RHFactorEnum RHFactor { get; set; }
    }
}
