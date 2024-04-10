namespace FoodShareNetAPI.DTO.Order
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public string BeneficiaryName { get; set; }
        public string DonationName { get; set; }
        public string CourierName { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? DeliveryDate { get; set; } // Nullable in case the delivery date is not yet set
        public string OrderStatusName { get; set; }
    }
}
