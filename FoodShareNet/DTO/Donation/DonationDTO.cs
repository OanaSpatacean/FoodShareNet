namespace FoodShareNetAPI.DTO.Donation
{
    public class DonationDTO
    {
        public int Id { get; set; }
        public string DonorName { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string StatusName { get; set; }
    }
}
