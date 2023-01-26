using Exam.Interfeces;
using Exam.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Exam.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productService"></param>
        /// <returns></returns>
        public async Task<IActionResult> Privacy([FromServices] IProductServices productService)
        {
            var result = await productService.SelectProducts();
            //var result = await productService.SelectProductsByCategory("Мужские футболки");

            return View();
        }

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

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}