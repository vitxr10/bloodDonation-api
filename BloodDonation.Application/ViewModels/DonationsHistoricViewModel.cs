using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonation.Application.ViewModels
{
    public class DonationsHistoricViewModel
    {
        public DonationsHistoricViewModel(int id, DateTime donationDate, double amountInML)
        {
            Id = id;
            DonationDate = donationDate;
            AmountInML = amountInML;
        }

        public int Id { get; set; }
        public DateTime DonationDate { get; set; }
        public double AmountInML { get; set; }
    }
}
