using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BLL.Entities;
using BLL.Interfaces;

namespace BLL.Services
{
    public class ProductServices : IProductServices
    {
        private IProductRepository _repository;
        public ProductServices(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> CreateProduct(Product entity)
        {
            return await _repository.Create(entity);
        }

        public async Task<bool> DeleteProduct(Product entity)
        {
            return await _repository.Delete(entity);
        }

        public async Task<Product> GetProductById(Guid id)
        {
            return await _repository.GetById(id);
        }

        public async Task<Product> GetProductByName(string name)
        {
            return await _repository.GetByName(name);
        }

        public async Task<List<Product>> SelectProducts()
        {
            return await _repository.Select();
        }

        public async Task<List<Product>> SelectProductsByCategory(string category)
        {
            var products = await _repository.Select();

            return products.Where(product => product.Category.Name == category).ToList();
        }

        public async Task<List<Product>> SelectProductsByPrice(double price)
        {
            var products = await _repository.Select();

            return products.Where(product => product.Price <= price).ToList();
        }

        public async Task<Product> UpdateProduct(Product entity)
        {
            return await _repository.Update(entity);
        }
    }
}
