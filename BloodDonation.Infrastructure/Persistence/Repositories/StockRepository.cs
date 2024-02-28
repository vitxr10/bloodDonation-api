using BloodDonation.Core.Entities;
using BloodDonation.Core.Enums;
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
    public class StockRepository : IStockRepository
    {
        private readonly BloodDonationDbContext _dbContext;
        public StockRepository(BloodDonationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateAsync(Stock stock)
        {
            await _dbContext.Stocks.AddAsync(stock);
            await _dbContext.SaveChangesAsync();

            return stock.Id;
        }

        public async Task<List<Stock>> GetAllAsync()
        {
            return await _dbContext.Stocks.ToListAsync();
        }

        public async Task<Stock> GetByBloodTypeAsync(BloodTypeEnum bloodType, RHFactorEnum rhFactor)
        {
            var stock = await _dbContext.Stocks.SingleOrDefaultAsync(s => s.BloodType == bloodType && s.RHFactor == rhFactor);

            return stock;
        }

        public async Task<Stock> GetByIdAsync(int id)
        {
            var stock = await _dbContext.Stocks.SingleOrDefaultAsync(s => s.Id == id);

            return stock;
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
