using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;
using BLL.Interfaces;

namespace BLL.Services
{
    /// <summary>
    /// Для имитации объектов или для создания так называемых фейковых объектов.
    /// В данном случае имитируется функциональность репозитория
    /// </summary>
    public class ProductRepositoryMoq : IProductRepository
    {
        private List<Product> _database;
        public ProductRepositoryMoq()
        {
            ProductCategory category = new ProductCategory()
            {
                CategoryName = "Женские юбки"
            };

            ProductCategory category2 = new ProductCategory()
            {
                CategoryName = "Мужские футболки"
            };

            _database = new List<Product>()
            {
                new Product()
                {
                    Name = "Юбка Bershka 6466/469/615 L Красная (SZ06466469615041)",
                    Price = 459,
                    Category = category

                },

                new Product()
                {
                    Name = "Юбка Escada 38 Черно-белая 5033547",
                    Price = 17892,
                    Category = category

                },

                new Product()
                {
                    Name = "Поло Puma Ess Pique Polo 58667401 M Black (4063697400696)",
                    Price = 1490,
                    Category = category2

                },

                new Product()
                {
                    Name = "Спортивная футболка Adidas Fast Tee Gfx HA6524 XL Blurus/Print (4065423552914)",
                    Price = 2220,
                    Category = category2

                },

                new Product()
                {
                    Name = "Футболка Nike M Nk Df Rise 365 Ss CZ9184-100 L (194955895078)",
                    Price = 2480,
                    Category = category2

                },



            };
        }
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
            return _database.FirstOrDefault(product =>
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
            return _database;
        }

        public async Task<Product> Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
