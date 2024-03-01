using BloodDonation.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonation.Core.Entities
{
    public class Donor
    {
        public Donor(string fullName, string email, DateTime birthDate, GenderEnum gender, double weight, BloodTypeEnum bloodType, RHFactorEnum rHFactor)
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            Gender = gender;
            Weight = weight;
            BloodType = bloodType;
            RHFactor = rHFactor;
            Active = true;
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public GenderEnum Gender { get; set; }
        public double Weight { get; set; }
        public BloodTypeEnum BloodType { get; set; }
        public RHFactorEnum RHFactor { get; set; }
        public DateTime LastDonation { get; set; }
        public bool Active { get; set; }
        public List<Donation>? Donations { get; private set; }
        public Address? Address { get; set; }

        public bool IsValid()
        {
            if (Gender == GenderEnum.Female && LastDonation.AddDays(90) > DateTime.Now)
                return false;

            if (Gender == GenderEnum.Male && LastDonation.AddDays(60) > DateTime.Now)
                return false;

            if (Weight < 50)
                return false;

            if (BirthDate.AddYears(18) > DateTime.Now)
                return false;

            if (Active == false)
                return false;

            return true;
        }

        public void Update (double weight)
        {
            Weight = weight;
        }

        public void UpdateLastDonation()
        {
            LastDonation = DateTime.Now;
        }

        public void Delete()
        {
            Active = false;
        }


    }
}
