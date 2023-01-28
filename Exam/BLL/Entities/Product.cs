using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
    public class Product
    {
        private ProductCategory category;

        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double Oldprice { get; set; }
        public string? Description { get; set; }
        public bool Isnew { get; set; }
        public bool Issale { get; set; }
        public string? Urlimage { get; set; }
        public ProductCategory Category { get => category; set => category = value; }

    }
}