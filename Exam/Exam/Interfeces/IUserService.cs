using Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Interfeces
{
	public interface IUserService
	{
		Task<IBaseResponse<RegisterModel>> Authorize(UserModel entity);
		Task<IBaseResponse<RegisterModel>> Registration(UserModel entity);
		Task<IBaseResponse<RegisterModel>> AuthorizeFromGoogle (string email);
	}
}
