using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;

namespace BLL.Interfaces
{
    public interface IProductServices
    {
        Task<bool> CreateProduct(Product entity);
        Task<Product> UpdateProduct(Product entity);
        Task<bool> DeleteProduct(Product entity);
        Task<List<Product>> SelectProducts();
        Task<List<Product>> SelectProductsByCategory(string category);
        Task<List<Product>> SelectProductsByPrice(double price);
        Task<Product> GetProductById(Guid id);
        Task<Product> GetProductByName(string name);
    }
}
