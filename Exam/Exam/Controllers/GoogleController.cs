using System.Security.Claims;

using BLL.Services;
using Exam.Interfeces;
using Exam.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace Exam.Controllers
{
	public class GoogleController : Controller
	{
        readonly GoogleServices _googleServices;
        //private IUserService _userService;
        //private UserServices _userServices;
        private IUserService _userService;
		public GoogleController(GoogleServices googleServices, IUserService userService)
		{
			_googleServices = googleServices;
            _userService = userService;
		}
		
		public IActionResult RedirectToGoogle()
		{
			string url = _googleServices.CreateRedirectGoogle();
			return Redirect(url);
		}

		public async Task<IActionResult> GetGoogleCode(string code)
        {
            var result = await _googleServices.GetGoogleToken(code);

            var person = await _googleServices.GoogleGetPerson(result);

			var response = await _userService.AuthorizeFromGoogle(person.Email);

            if (response.Status == ResultStatusCode.Ok)

            {
                await AddSession(response.Data);
                return RedirectToAction("Index", "Home");
            }

			return Json("Not Acces");
		}

        private async Task AddSession(RegisterModel user)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };

            ClaimsIdentity person = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Email, ClaimTypes.Role);

            ClaimsPrincipal principal = new ClaimsPrincipal(person);
            await HttpContext.SignInAsync(principal);
        }
	}
}
