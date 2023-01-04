using System;
using System.Collections.Generic;
using System.IO;

namespace SimpleApp.Models
{
    public class ProductReader
    {
        public readonly string path = "App_Data/data.txt";

        public List<Product> ReadFromFile()
        {
            string[] lines = File.ReadAllLines(path);

            List<Product> result = new List<Product>();
            foreach (string line in lines)
            {
                string[] items = line.Split(',');

                Product product = new Product();
                product.Id = Convert.ToInt32(items[0].Trim());
                product.Category = Convert.ToString(items[1].Trim());
                product.CategoryId = Convert.ToInt32(items[2].Trim());
                product.Name = items[3].Trim();
                product.Price = Convert.ToDouble(items[4].Trim());
                product.Description = Convert.ToString(items[5].Trim());
                product.Quantity = Convert.ToInt32(items[6].Trim());

                result.Add(product);
            }

            return result;
        }
    }
}
