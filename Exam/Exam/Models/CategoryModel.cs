using BLL.Entities;

namespace Exam.Models
{
    public class CategoryModel
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; }
        public List<ProductModel>? Products { get; set; }
    }
}
