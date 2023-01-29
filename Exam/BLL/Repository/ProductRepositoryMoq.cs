using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;
using BLL.Interfaces;

namespace BLL.Repository
{
    /// <summary>
    /// Для имитации объектов или для создания так называемых фейковых объектов.
    /// В данном случае имитируется функциональность репозитория
    /// </summary>
    public class ProductRepositoryMoq : IProductRepository
    {

	    public async Task<bool> Create(Product entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> GetByName(string name)
        {
#pragma warning disable CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
            return DataBaseMoq.Products.FirstOrDefault(product =>
            {
                if (product is null)
                {
                    throw new ArgumentNullException(nameof(product));
                }

                return product.Name == name;
            });
#pragma warning restore CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
        }

        public async Task<List<Product>> Select()
        {
            return DataBaseMoq.Products;
        }

        public async Task<Product> Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
