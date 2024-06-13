using FoodShareNet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShareNet.Application.Interfaces
{
    public interface IDonorService
    {
        Task<IList<Donor>> GetAllDonorsAsync();
        Task<Donor> GetDonorAsync(int id);
        Task<Donor> CreateDonorAsync(Donor donor);
        Task<bool> UpdateDonorAsync(int donorId);
        Task<bool> DeleteDonorAsync(int id);
    }
}
