using BloodDonation.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonation.Application.ViewModels
{
    public class StockViewModel
    {
        public StockViewModel(int id, BloodTypeEnum bloodType, RHFactorEnum rHFactor, double amountInML)
        {
            Id = id;
            BloodType = bloodType;
            RHFactor = rHFactor;
            AmountInML = amountInML;
        }

        public int Id { get; set; }
        public BloodTypeEnum BloodType { get; set; }
        public RHFactorEnum RHFactor { get; set; }
        public double AmountInML { get; set; }
    }
}
