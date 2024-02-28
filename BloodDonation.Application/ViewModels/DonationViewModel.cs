using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonation.Application.ViewModels
{
    public class DonationViewModel
    {
        public DonationViewModel(int id, int donorId, double amountInML)
        {
            Id = id;
            DonorId = donorId;
            AmountInML = amountInML;
        }

        public int Id { get; set; }
        public int DonorId { get; set; }
        public double AmountInML { get; set; }
    }
}
