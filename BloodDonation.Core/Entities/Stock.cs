﻿using BloodDonation.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonation.Core.Entities
{
    public class Stock
    {
        public Stock(BloodTypeEnum bloodType, RHFactorEnum rHFactor)
        {
            BloodType = bloodType;
            RHFactor = rHFactor;
            AmountInML = 0;
        }

        public int Id { get; set; }
        public BloodTypeEnum BloodType { get; set; }
        public RHFactorEnum RHFactor { get; set; }
        public double AmountInML { get; set; }

        public void UpdateBloodStock(double amount)
        {
            AmountInML += amount;
        }
    }
}
