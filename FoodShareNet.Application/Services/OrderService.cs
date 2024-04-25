﻿using FoodShareNet.Application.Exceptions;
using FoodShareNet.Application.Interfaces;
using FoodShareNet.Domain.Entities;
using FoodShareNet.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShareNet.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IFoodShareDbContext _context;

        public OrderService(IFoodShareDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<Order> CreateOrderAsync(Order order)
        {
            var donation = await _context.Donations
                .FirstOrDefaultAsync(d => d.Id == order.DonationId);

            if (donation == null)
            {
                throw new NotFoundException($"Donation with Id {order.DonationId} not found.");
            }

            if (donation.Quantity < order.Quantity)
            {
                throw new OrderException($"Requested quantity exceeds available quantity for Donation with Id {order.DonationId}.");
            }

            donation.Quantity -= order.Quantity;

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return order;
        }

        public async Task<Order> GetOrderAsync(int id)
        {
            var order = await _context.Orders
               .Include(o => o.Beneficiary)
               .Include(o => o.Donation)
               .Include(o => o.OrderStatus)
               .Include(o => o.Courier)
               .Include(o => o.Donation.Product)
               .Where(o => o.Id == id)
              .FirstOrDefaultAsync(m => m.Id == id);

            if (order == null)
            {
                throw new NotFoundException($"Order not found.");
            }

            return order;
        }

        public async Task<bool> UpdateOrderStatusAsync(int orderId, OrderStatusEnum orderStatus)
        {
            var order = await _context.Orders
                .FirstOrDefaultAsync(b => b.Id == orderId);

            if (order == null)
            {
                throw new NotFoundException($"Order with ID {orderId} not found.");
            }

            order.OrderStatusId = (int)orderStatus;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
