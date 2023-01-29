using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Exam.Models
{
	public class UserModel
	{
		public Guid Id { get; set; }

		[Display(Name = "Email", Prompt = "Your Email")]
		[Required]
		[EmailAddress]
		public string Email { get; set; }

		[Display(Name = "Password", Prompt = "Your Password")]
		[Required]
		[DataType(DataType.Password)]
		[StringLength(16, MinimumLength = 3)]
		public string Password { get; set; }
	}

    public class RegisterModel : UserModel
    {
		public string Role { get; set; }
    }
}
