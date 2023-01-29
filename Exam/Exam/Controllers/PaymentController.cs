using Exam.Models;
using Exam.Services;
using Microsoft.AspNetCore.Mvc;

namespace Exam.Controllers
{
	public class PaymentController : Controller
	{
		private LiqPayServicies _payService;

		public PaymentController(LiqPayServicies payService)
		{
			_payService = payService;
		}

		public async Task<IActionResult> Pay()
		{
			List<ProductModel> products = new List<ProductModel>();
			await _payService.PaymentEmail(User.Identity.Name);
			return Json("chek email");
		}
	}
}
