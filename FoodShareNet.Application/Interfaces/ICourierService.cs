using FoodShareNet.Domain.Entities;

namespace FoodShareNet.Application.Interfaces
{
    public interface ICourierService
    {
        Task<IList<Courier>> GetAllCouriersAsync();
        Task<Courier> GetCourierAsync(int id);
        Task<Courier> CreateCourierAsync(Courier courier);
        Task<bool> UpdateCourierAsync(int courierId);
        Task<bool> DeleteCourierAsync(int id);
    }
}
