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

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
