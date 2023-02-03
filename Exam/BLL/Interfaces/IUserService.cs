using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;

namespace BLL.Interfaces
{
	public interface IUserService : IEntityRepository<User>
	{
        public Task<User> Authorize(string email, string password);
        public Task<User> Registration(string name, string email, string password);
        public Task<User> AuthorizeFromGoogle (string email);

        public Task<User> GetUserByEmail(string email);
	}
}
