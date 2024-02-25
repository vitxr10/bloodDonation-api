using BloodDonation.Core.Entities;
using BloodDonation.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonation.Application.ViewModels
{
    public class DonorDetailsViewModel
    {
        public DonorDetailsViewModel(int id, string fullName, string email, DateTime birthDate, GenderEnum gender, double weight, BloodTypeEnum bloodType, RHFactorEnum rHFactor, bool active)
        {
            Id = id;
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            Gender = gender;
            Weight = weight;
            BloodType = bloodType;
            RHFactor = rHFactor;
            Active = active;
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public GenderEnum Gender { get; set; }
        public double Weight { get; set; }
        public BloodTypeEnum BloodType { get; set; }
        public RHFactorEnum RHFactor { get; set; }
        public bool Active { get; set; }
    }
}
