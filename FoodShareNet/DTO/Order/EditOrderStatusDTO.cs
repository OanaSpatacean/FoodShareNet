namespace FoodShareNetAPI.DTO.Order
{
    public class EditOrderStatusDTO
    {
        public int Id { get; set; }
        public DateTime? DeliveryDate { get; set; } // Nullable in case the delivery date is not yet set
        public int OrderStatusId { get; set; }
    }
}
