using FoodShareNet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShareNet.Application.Interfaces
{
    public interface IDonationService
    {
        Task<IList<Donation>> GetAllDonationsAsync();
        Task<Donation> GetDonationAsync(int id);
        Task<Donation> CreateDonationAsync(Donation donation);
        Task<bool> UpdateDonationAsync(int donationId);
        Task<bool> DeleteDonationAsync(int id);
    }
}
