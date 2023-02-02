using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BLL.Entities
{
	public class GooglePerson
	{
		[JsonProperty("email")]
		public string Email { get; set; }

        [JsonProperty("email_verified")]
		public bool EmailVerified { get; set; }
	}
}
