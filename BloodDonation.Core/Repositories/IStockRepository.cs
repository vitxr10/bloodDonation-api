using BloodDonation.Core.Entities;
using BloodDonation.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonation.Core.Repositories
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllAsync();
        Task<Stock> GetByIdAsync(int id);
        Task<Stock> GetByBloodTypeAsync(BloodTypeEnum bloodType, RHFactorEnum rhFactor);
        Task<int> CreateAsync(Stock stock);
        Task SaveAsync();
    }
}
