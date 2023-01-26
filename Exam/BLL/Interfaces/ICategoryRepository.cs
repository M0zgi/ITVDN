using BLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICategoryRepository
    {
        Task<bool> Create(Product entity);
        Task<Product> Update(Product entity);
        Task<bool> Delete(Product entity);
        Task<List<Product>> Select();
        Task<Product> GetById(Guid id);
        Task<Product> GetByName(string name);
    }
}
