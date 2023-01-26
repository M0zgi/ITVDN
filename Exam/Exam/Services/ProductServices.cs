using AutoMapper;
using BLL.Entities;
using Exam.Interfeces;
using Exam.Models;
using System.Collections.Generic;

namespace Exam.Services
{
    public class ProductServices : IProductServices
    {
        private BLL.Interfaces.IProductServices _productServices;
        private IMapper _mapper;
        public ProductServices(IMapper mapper, BLL.Interfaces.IProductServices productServices)
        {
            _productServices = productServices;
            _mapper = mapper;
        }
        public Task<IBaseResponse<bool>> CreateProduct(ProductModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<IBaseResponse<bool>> DeleteProduct(ProductModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<IBaseResponse<ProductModel>> GetProductById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IBaseResponse<ProductModel>> GetProductByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<IBaseResponse<List<ProductModel>>> SelectProducts()
        {
            BaseResponse<List<ProductModel>> response = new BaseResponse<List<ProductModel>>();

            try
            {
                var result = await _productServices.SelectProducts();

                

                //будет ошибка ProductModel не удается неявно преобразовать в Product
                //response.Data = result;


                response.Data = _mapper.Map<List<ProductModel>>(result);

                response.Status = ResultStatusCode.Ok;
            }
            catch (Exception ex)
            {
                response.Status = ResultStatusCode.Error;
            }

            return response;
        }

        public Task<IBaseResponse<List<ProductModel>>> SelectProductsByCategory(string category)
        {
            throw new NotImplementedException();
        }

        public Task<IBaseResponse<List<ProductModel>>> SelectProductsByPrice(double price)
        {
            throw new NotImplementedException();
        }

        public Task<IBaseResponse<Product>> UpdateProduct(ProductModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
