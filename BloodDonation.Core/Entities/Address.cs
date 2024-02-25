using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonation.Core.Entities
{
    public class Address
    {
        public Address(string neighborhood, string city, string state, string zipCode, int donorId)
        {
            Neighborhood = neighborhood;
            City = city;
            State = state;
            ZipCode = zipCode;
            DonorId = donorId;
        }

        public int Id { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public int DonorId { get; set; }
        public Donor Donor { get; set; }
    }
}
