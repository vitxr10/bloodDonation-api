using BloodDonation.Application.ViewModels;
using BloodDonation.Core.DTOs;
using BloodDonation.Core.Entities;
using BloodDonation.Core.Repositories;
using BloodDonation.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonation.Infrastructure.Persistence.Repositories
{
    public class DonationRepository : IDonationRepository
    {
        private readonly BloodDonationDbContext _dbContext;
        public DonationRepository(BloodDonationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateAsync(Donation donation)
        {
            await _dbContext.Donations.AddAsync(donation);
            await _dbContext.SaveChangesAsync();

            return donation.Id;
        }

        public async Task<List<Donation>> GetAllAsync()
        {
            return await _dbContext.Donations.ToListAsync();
        }

        public async Task<Donation> GetByIdAsync(int id)
        {
            return await _dbContext.Donations.SingleOrDefaultAsync(d => d.Id == id);
        }

        public async Task<List<Donation>> GetDonationsHistoric(int id)
        {
            var donations = await _dbContext.Donations.Where(dn => dn.DonorId == id).ToListAsync();

            return donations;
        }

        public async Task<List<DonationsLast30DaysDTO>> GetDonationsLast30Days()
        {
            var donations = await _dbContext.Donations
                .Where(dn => dn.DonationDate.Date >= DateTime.Now.Date.AddDays(-30))
                .Join(_dbContext.Donors,
                            donation => donation.DonorId,
                            donor => donor.Id,
                (donation, donor) => new DonationsLast30DaysDTO
                (
                    donation.DonorId,
                    donor.FullName,
                    donor.BloodType,
                    donor.RHFactor,
                    donation.AmountInML
                ))
                .ToListAsync();

            return donations;
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
