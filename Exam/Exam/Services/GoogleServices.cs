using BLL.Entities;
using Exam.Interfeces;
using Exam.Models;
using Newtonsoft.Json.Linq;

namespace Exam.Services
{
    public class GoogleServices
    {
        private BLL.Services.GoogleServices _googleServices;
        public GoogleServices(BLL.Services.GoogleServices googleServices)
        {
            _googleServices = googleServices;
        }
    }
}
