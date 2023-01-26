using BLL.Entities;
using Exam.Models;

namespace Exam.Interfeces
{
    public interface IProductServices
    {
        Task <IBaseResponse<bool>> CreateProduct(ProductModel entity);
        Task <IBaseResponse<Product>> UpdateProduct(ProductModel entity);
        Task <IBaseResponse<bool>> DeleteProduct(ProductModel entity);
        Task <IBaseResponse<List<ProductModel>>> SelectProducts();
        Task <IBaseResponse<List<ProductModel>>> SelectProductsByCategory(string category);
        Task <IBaseResponse<List<ProductModel>>> SelectProductsByPrice(double price);
        Task <IBaseResponse<ProductModel>> GetProductById(Guid id);
        Task <IBaseResponse<ProductModel>> GetProductByName(string name);
    }
}
