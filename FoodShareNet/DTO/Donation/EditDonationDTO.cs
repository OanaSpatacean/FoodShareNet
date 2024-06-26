﻿namespace FoodShareNetAPI.DTO.Donation
{
    public class EditDonationDTO
    {
        public int Id { get; set; }
        public int DonorId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int StatusId { get; set; }
    }
}
