using FoodShareNet.Domain.Entities;
using FoodShareNet.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShareNet.Application.Interfaces
{
    public interface IOrderService
    {
        Task<Order> CreateOrderAsync(Order order);
        Task<Order> GetOrderAsync(int id);
        Task<bool> UpdateOrderStatusAsync(int orderId, OrderStatusEnum orderStatus);
    }
}
