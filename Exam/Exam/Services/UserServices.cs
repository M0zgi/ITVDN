using System.Security.Claims;
using AutoMapper;
using Exam.Interfeces;
using Exam.Models;

namespace Exam.Services
{
    public class UserServices : IUserService
    {
        private BLL.Interfaces.IUserService _userService;
        private IMapper _mapper; 
        public UserServices(IMapper mapper, BLL.Interfaces.IUserService userService)
        {
            _userService = userService;
            _mapper = mapper;
        }
        public async Task<IBaseResponse<RegisterModel>> Authorize(UserModel entity)
        {
            BaseResponse<RegisterModel> result = new BaseResponse<RegisterModel>();

            try
            {
                var user = await _userService.Authorize(entity.Email, entity.Password);
                result.Data = _mapper.Map<RegisterModel>(user);
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.Status = ResultStatusCode.Error;
            }

            return result;

        }
        public async Task<IBaseResponse<RegisterModel>> AuthorizeFromGoogle(string email)
        {
            BaseResponse<RegisterModel> result = new BaseResponse<RegisterModel>();

            try
            {
                var user = await _userService.AuthorizeFromGoogle(email);
                result.Data = _mapper.Map<RegisterModel>(user);
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.Status = ResultStatusCode.Error;
            }

            return result;
        }

        public async Task<IBaseResponse<RegisterModel>> Registration(UserModel entity)
        {
            BaseResponse<RegisterModel> result = new BaseResponse<RegisterModel>();

            try
            {
                var user = await _userService.Authorize(entity.Email, entity.Password);
                result.Data = _mapper.Map<RegisterModel>(user);
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.Status = ResultStatusCode.Error;
            }

            return result;
        }
    }
}
