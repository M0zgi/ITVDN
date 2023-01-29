using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;

namespace BLL.Interfaces
{
    public interface IProductServices : IProductRepository
    {
	    Task<IEnumerable<Product>> SelectProductsByCategory(string category);

        Task<IEnumerable<Product>> SelectProductsByPrice(double price);
    }
}
