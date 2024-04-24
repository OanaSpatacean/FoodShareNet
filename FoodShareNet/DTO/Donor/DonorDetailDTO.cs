using FoodShareNet.Domain.Entities;
using FoodShareNetAPI.DTO.Donation;

namespace FoodShareNetAPI.DTO.Donor
{
    public class DonorDetailDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }
        public string Address { get; set; }
        //public List<DonationDTO> Donations { get; set; } = new List<DonationDTO>();
        public List<int> DonationsId { get; set; } = new List<int>();
    }
}
