namespace Exam.Models
{
    public class ProductModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double Oldprice { get; set; }
        public string? Description { get; set; }
        public bool Isnew { get; set; }
        public bool Issale { get; set; }
        public string? Urlimage { get; set; }
        public CategoryModel Category { get; set; }
    }
}
