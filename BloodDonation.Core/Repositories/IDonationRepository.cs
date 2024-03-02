using BloodDonation.Core.DTOs;
using BloodDonation.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonation.Core.Repositories
{
    public interface IDonationRepository
    {
        Task<List<Donation>> GetAllAsync();
        Task<Donation> GetByIdAsync(int id);
        Task<List<Donation>> GetDonationsHistoric(int id);
        Task<List<DonationsLast30DaysDTO>> GetDonationsLast30Days();
        Task<int> CreateAsync(Donation donation);
        Task SaveAsync();
    }
}
