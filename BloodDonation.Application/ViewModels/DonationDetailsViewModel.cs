using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonation.Application.ViewModels
{
    public class DonationDetailsViewModel
    {
        public DonationDetailsViewModel(int id, int donorId, DateTime donationDate, double amountInML)
        {
            Id = id;
            DonorId = donorId;
            DonationDate = donationDate;
            AmountInML = amountInML;
        }

        public int Id { get; set; }
        public int DonorId { get; set; }
        public DateTime DonationDate { get; set; }
        public double AmountInML { get; set; }
    }
}
