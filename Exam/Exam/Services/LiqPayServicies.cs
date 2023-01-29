using BLL.Entities;
using Exam.Interfeces;
using Exam.Models;

namespace Exam.Services
{
	public class LiqPayServicies
	{
		private BLL.Interfaces.IPaymaentServices _paymaent;
		public LiqPayServicies(BLL.Interfaces.IPaymaentServices paymaent)
		{
			_paymaent = paymaent;
		}
		public async Task<IBaseResponse<bool>> PaymentEmail(string email)
		{
			BaseResponse<bool> result = new BaseResponse<bool>();
			try
			{
				var response = await _paymaent.PaymentEmail(email);
				result.Data = response;
			}
			catch (Exception ex)
			{
				result.Message = ex.Message;
				result.Status = ResultStatusCode.Error;
			}

			return result;
		}
	}
}
