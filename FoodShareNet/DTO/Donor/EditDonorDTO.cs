﻿using FoodShareNet.Domain.Entities;

namespace FoodShareNetAPI.DTO.Donor
{
    public class EditDonorDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }
        public string Address { get; set; }

        //public List<Donation> Donations { get; set; } = new List<Donation>();
        //public List<int> DonationsId { get; set; } = new List<int>();
    }
}
