using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodShareNet.Domain.Entities;
using System.Diagnostics.Metrics;

namespace FoodShareNet.Repository.Data
{
    public class FoodShareNetDbContext : DbContext //FoodShareNetDbContext class is inheriting from DbContext
    {
        public FoodShareNetDbContext(DbContextOptions<FoodShareNetDbContext> options) 
            :base(options) { }

        //We have to add DbSet properties for each of the domain entities
        public DbSet<Courier> Couriers { get; set; }
        public DbSet<Beneficiary> Beneficiaries { get; set; }
        public DbSet<Donor> Donors { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<DonationStatus> DonationStatuses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Product> Products { get; set; }

        //We are going override the OnModelCreating method to add data (seed) for some of the tables that need to be prepopulated
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasData(
                new City { Id = 1, Name = "Bucuresti" }, //This data is going to be inserted into database as we defined it here
                new City { Id = 2, Name = "Cluj-Napoca" },
                new City { Id = 3, Name = "Timisoara" },
                new City { Id = 4, Name = "Iasi" },
                new City { Id = 5, Name = "Constanta" }
            );

            modelBuilder.Entity<Courier>().HasData(
                new Courier { Id = 1, Name = "DPD", Price = 20 },
                new Courier { Id = 2, Name = "DHL", Price = 15 },
                new Courier { Id = 3, Name = "GLS", Price = 17.5M }
            );

            modelBuilder.Entity<DonationStatus>().HasData(
                new DonationStatus { Id = 1, Name = "Pending" },
                new DonationStatus { Id = 2, Name = "Approved" },
                new DonationStatus { Id = 3, Name = "Rejected" }
            );

            modelBuilder.Entity<OrderStatus>().HasData(
                new OrderStatus { Id = 1, Name = "Unconfirmed" },
                new OrderStatus { Id = 2, Name = "Confirmed" },
                new OrderStatus { Id = 3, Name = "InDelivery" },
                new OrderStatus { Id = 4, Name = "Delivered" }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Tomatoes", Image = "Tomatoes" },
                new Product { Id = 2, Name = "Potatoes", Image = "Potatoes" },
                new Product { Id = 3, Name = "Meat", Image = "Meat" }
            );

            modelBuilder.Entity<Courier>()
                .Property(c => c.Price)
                .HasColumnType("decimal(18, 2)"); //we also need to specify columnType for Courier.Price column 
            
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Donation)
                .WithMany()
                .HasForeignKey(o => o.DonationId)
                .OnDelete(DeleteBehavior.Restrict); //and to add Restrict behavior in case of Order deletion
                                                    //This is because we have 2 delete paths when a City is deleted as:
                                                    //city->beneficiary->order
                                                    //city->donor->donation->order

            base.OnModelCreating(modelBuilder);
        }
    }
}
