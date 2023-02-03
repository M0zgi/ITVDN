using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;

namespace BLL.Services
{
	public class GoogleServices
	{
		/// <summary>
		/// Идентификатор клиента для вашего приложения. Вы можете найти это значение в API ConsoleCredentials page.
		/// </summary>
		private const string CLIENTID = "495449131913-1t6ir0s4c10nr8cssr25lut2e6snsuhl.apps.googleusercontent.com";
		private const string CLIENTSECRET = "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";

        public string CreateRedirectGoogle()
		{
			string url = "https://accounts.google.com/o/oauth2/v2/auth";
			Dictionary<string, string> query = new Dictionary<string, string>()
			{
				{ "client_id", CLIENTID },
				{ "redirect_uri", "https://localhost:32768/Google/GetGoogleCode" },
				{ "response_type", "code" },
				{ "scope", "email" },
				{ "access_type", "offline" },

			};

			return QueryHelpers.AddQueryString(url, query);
		}

        public async Task <GoogleToken> GetGoogleToken(string code)
        {
            string url = "https://oauth2.googleapis.com/token";

            Dictionary<string, string> query = new Dictionary<string, string>()
            {
                { "client_id", CLIENTID },
                { "client_secret", CLIENTSECRET },
                { "code", code },
                { "grant_type", "authorization_code" },
                { "redirect_uri", "https://localhost:32768/Google/GetGoogleCode" },
                { "access_type", "offline" },

            };

            HttpClient client = new HttpClient();
            var content = new FormUrlEncodedContent(query);
			var response = await client.PostAsync(url, content);
			var context = await response.Content.ReadAsStringAsync();
            var token = JsonConvert.DeserializeObject<GoogleToken>(context);
           
            return token;
        }

        public async Task<GooglePerson> GoogleGetPerson(GoogleToken token)
        {
            string url = "https://oauth2.googleapis.com/tokeninfo";

            Dictionary<string, string> query = new Dictionary<string, string>()
            {
                { "id_token", token.IdToken },

            };

            HttpClient client = new HttpClient();
            var content = new FormUrlEncodedContent(query);
            var response = await client.PostAsync(url, content);
            var context = await response.Content.ReadAsStringAsync();
            var person = JsonConvert.DeserializeObject<GooglePerson>(context);
            return person;
        }
    }
}
