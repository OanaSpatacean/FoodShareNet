using FoodShareNet.Domain.Entities;

namespace FoodShareNet.Application.Interfaces
{
    public interface IBeneficiaryService
    {
        Task<IList<Beneficiary>> GetAllBeneficiariesAsync();
        Task<Beneficiary> GetBeneficiaryAsync(int id);
        Task<Beneficiary> CreateBeneficiaryAsync(Beneficiary beneficiary);
        Task<bool> UpdateBeneficiaryAsync(int beneficiaryId);
        Task<bool> DeleteBeneficiaryAsync(int id);
    }
}
