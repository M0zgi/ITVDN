using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;
using BLL.Interfaces;
using LiqPay.SDK;
using LiqPay.SDK.Dto;
using LiqPay.SDK.Dto.Enums;

namespace BLL.Services
{
	internal class LiqPayServicies : IPaymaentServices
	{
		private const string PRIMARY = "sandbox_i31909983879";
		private const string FOREIGN = "sandbox_MrnuffMYlzLoykmd6vuYoQjsiI509r7XlhStPLJf";
		private const string RETURN = "https://localhost:32792/";

		readonly LiqPayClient _client;
		private IUserService _userService;
		public LiqPayServicies(IUserService userService)
		{
			_client = new LiqPayClient(PRIMARY, FOREIGN);
			_client.IsCnbSandbox = true;
			_userService = userService;
		}

		public async Task<LiqPayRequest> PayCart(string email)
		{
			var user = await _userService.GetUserByEmail(email);

			var price = user.Cart.Sum(x => x.Price);

			var query = from items in user.Cart
						group items by items.Name;

			var goods = new List<LiqPayRequestGoods>();

			foreach (var product in query)
			{
				goods.Add(new LiqPayRequestGoods()
				{
					Name = product.Key,
					Amount = product.First().Price,
					Count = product.Count(),
					Unit = "шт"
				});
			}

			LiqPayRequest request = new LiqPayRequest()
			{
				Email = email,
				ResultUrl = RETURN,
				ServerUrl = RETURN,
				Amount = price,
				Currency = "UAH",
				OrderId = Guid.NewGuid().ToString(),
				ActionPayment = LiqPayRequestActionPayment.Pay,
				Action = LiqPayRequestAction.InvoiceSend,
				Goods = goods
			};

			return request;
		}

		public async Task<bool> PaymentEmail(string email)
		{
			var cart = await PayCart(email);

			var response = await _client.RequestAsync("request", cart);

			if (response.ErrorCode != null)
				throw new Exception(response.ErrorCode);

			return true;
		}
	}
}
