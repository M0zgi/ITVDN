using Exam.Interfeces;
using Exam.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace Exam.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IUserService _userService;
        public HomeController(IUserService userService, ILogger<HomeController> logger)
        {
            _logger = logger;
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> Products([FromServices] IProductServices productService)
        {
            var result = await productService.SelectProducts();
            //var result = await productService.SelectProductsByCategory("Мужские футболки");

            if (result.Status == ResultStatusCode.Ok)
            {
                return Json(result.Data);
            }

            return StatusCode((int)result.Status);
        }


        ///// <summary>
        ///// Тестирование маппинга
        ///// </summary>
        ///// <param name="productService"></param>
        ///// <returns></returns>
        //public async Task<IActionResult> Privacy([FromServices] IProductServices productService)
        //{
        //    var result = await productService.SelectProducts();
        //    //var result = await productService.SelectProductsByCategory("Мужские футболки");

        //    return View();
        //}

        ////Для тестирования ProductRepositoryMoq
        //public async Task<IActionResult> Privacy([FromServices] BLL.Interfaces.IProductServices productService)
        //{
        //    //var result = await productService.SelectProducts();
        //    var result = await productService.SelectProductsByCategory("Мужские футболки");

        //    return View();
        //}
        //public IActionResult Privacy()
        //{
        //    return View();
        //}


        ///// <summary>
        ///// Проверка, на эту страницу попадают только авторизированные
        ///// </summary>
        ///// <returns></returns>
        //[Authorize(Roles = "User")]
        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        public IActionResult Authorization()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            var res = User;
            return View();
        }

        public IActionResult Order()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> SignIn(UserModel model)
        {
            var response = await _userService.Authorize(model);
            if (ModelState.IsValid)
            {
                await AddSession(response.Data);
                return RedirectToAction("Privacy");
            }

            return View("Authorization");
        }

        public async Task<IActionResult> SignOut()
        {
	        await HttpContext.SignOutAsync();

	        return RedirectToAction("Index");
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