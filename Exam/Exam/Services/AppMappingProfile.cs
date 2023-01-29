using AutoMapper;
using Exam.Models;

namespace Exam.Services
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<BLL.Entities.Product, ProductModel>().ReverseMap();
            CreateMap<BLL.Entities.ProductCategory, CategoryModel>().ReverseMap();
            CreateMap<BLL.Entities.User, RegisterModel>().ReverseMap();
        }
    }
}
