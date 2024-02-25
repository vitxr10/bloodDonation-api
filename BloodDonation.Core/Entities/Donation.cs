using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonation.Core.Entities
{
    public class Donation
    {
        public Donation(int donorId, DateTime donationDate, double amountInML)
        {
            DonorId = donorId;
            DonationDate = donationDate;
            AmountInML = amountInML;
        }

        public int Id { get; set; }
        public int DonorId { get; set; }
        public DateTime DonationDate { get; set; }
        public double AmountInML { get; set; }
        public Donor Donor { get; set; }

    }
}
