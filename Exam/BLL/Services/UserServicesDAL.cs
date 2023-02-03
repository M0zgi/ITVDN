using BLL.Entities;
using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DAL.Interfaces;

namespace BLL.Services
{
	public class UserServicesDal : IUserService
    {
        private IUserRepositoryDal _userRepository;
        private IMapper _mapper;

		public UserServicesDal(IMapper mapper, IUserRepositoryDal userRepository)
		{
			_userRepository = userRepository;
            _mapper = mapper;
		}
		public async Task<User> Authorize(string email, string password)
		{
			var users = await _userRepository.Select();
			var user = users.FirstOrDefault(person => person.Email == email);
			if(user == null)
				throw new Exception("User Not Found");
			if(user.Password != password)
				throw new Exception("Password is not valid");
           
            return _mapper.Map<User>(user);

			//return user;
		}

		public async Task<User> AuthorizeFromGoogle(string email)
		{
			var users = await _userRepository.Select();
			var user = users.FirstOrDefault(person => person.Email == email);
			if(user == null)
				throw new Exception("User Not Found");

			return _mapper.Map<User>(user);
		}

        public Task<bool> Create(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserByEmail(string email)
		{
			var users = await _userRepository.Select();
			var user = users.FirstOrDefault(person => person.Email == email);
			if(user == null)
				throw new Exception("User Not Found");

            return _mapper.Map<User>(user);
		}

		public async Task<User> Registration(string name, string email, string password)
		{
			//var users = await _userRepository.Select();

			//var user = users.FirstOrDefault(person => person.Email == email);
			//if(user != null)
			//	throw new Exception("User Exist");

			//User nUser = new User()
			//{
			//	Name = name,
			//	Email = email,
			//	Password = password
			//};

			//bool res = await _userRepository.Create(nUser);

			//if(res == false)
			//	throw new Exception("DataBase Error");
			
			//return nUser;

            throw new NotImplementedException();
		}

        public async Task<List<User>> Select()
        {
            var products = await _userRepository.Select();
            return _mapper.Map<List<User>>(products);
        }

        public Task<User> Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
