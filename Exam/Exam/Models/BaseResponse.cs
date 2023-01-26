using Exam.Interfeces;

namespace Exam.Models
{
    public class BaseResponse<T> : IBaseResponse<T>
    {
        public T Data { get; set; }

        public ResultStatusCode Status { get; set; }

        public string Message { get; set; }
    }
}
