using Microsoft.AspNetCore.Mvc;
using SimpleApp.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace SimpleApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _appEnvironment;

        public HomeController(IWebHostEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetFile()
        {
            ProductReader productReader = new ProductReader();
            // Путь к файлу
            string file_path = Path.Combine(_appEnvironment.ContentRootPath, productReader.path);
            // Тип файла - content-type
            string file_type = "application/txt";
            // Имя файла - необязательно
            string file_name = "data.txt";
            return PhysicalFile(file_path, file_type, file_name);
        }
    }
}
