using BloodDonation.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonation.Core.Repositories
{
    public interface IDonorRepository
    {
        Task<List<Donor>> GetAllAsync();
        Task<Donor> GetByIdAsync(int id);
        Task<bool> GetByEmailAsync(string email);
        Task<int> CreateAsync(Donor donor);
        Task SaveAsync();



    }
}
