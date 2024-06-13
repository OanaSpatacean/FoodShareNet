using FoodShareNet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShareNet.Application.Interfaces
{
    public interface IProductService
    {
        Task<IList<Product>> GetAllProductsAsync();
        Task<Product> GetProductAsync(int id);
        Task<Product> CreateProductAsync(Product product);
        Task<bool> UpdateProductAsync(int productId);
        Task<bool> DeleteProductAsync(int id);
    }
}
