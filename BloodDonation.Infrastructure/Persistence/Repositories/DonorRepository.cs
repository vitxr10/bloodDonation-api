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
    public class DonorRepository : IDonorRepository
    {
        private readonly BloodDonationDbContext _dbContext;
        public DonorRepository(BloodDonationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateAsync(Donor donor)
        {
            await _dbContext.Donors.AddAsync(donor);
            await _dbContext.SaveChangesAsync();

            return donor.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var donor = await _dbContext.Donors.SingleOrDefaultAsync(d => d.Id == id);

            _dbContext.Donors.Remove(donor);
            await _dbContext.SaveChangesAsync();
        }

        public Task<List<Donor>> GetAllAsync()
        {
            return _dbContext.Donors.ToListAsync();
        }

        public async Task<Donor> GetByIdAsync(int id)
        {
            return await _dbContext.Donors.SingleOrDefaultAsync(d => d.Id == id);
        }

        public async Task UpdateAsync(int id, Donor donor)
        {
            var donorDb = await _dbContext.Donors.SingleOrDefaultAsync(d => d.Id == id);

            _dbContext.Donors.Update(donorDb);
            await _dbContext.SaveChangesAsync();
        }
    }
}
