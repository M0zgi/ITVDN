using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;

namespace BLL.Interfaces
{
	public interface IUserService
	{
		Task<User> Authorize(string email, string password);
		Task<User> Registration(string name, string email, string password);
		Task<User> AuthorizeFromGoogle (string email);

		Task<User> GetUserByEmail(string email);
	}
}
