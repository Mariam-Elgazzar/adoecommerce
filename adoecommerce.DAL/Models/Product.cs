using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adoecommerce.BL.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int categoryId { get; set; }
        public Category Category { get; set; }
        public Product()
        {
            Category = new Category();
        }
    }
}
