using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;
using BLL.Interfaces;

namespace BLL.Repository
{
	public class UserRepositoryMoq : IUserRepository
	{
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

		public async Task<List<User>> Select()
		{
			return DataBaseMoq.Users;
		}

		public Task<User> Update(User entity)
		{
			throw new NotImplementedException();
		}
	}
}
