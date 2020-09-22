using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Product
    {
        public int ID { get; set; }
        public int Category_ID { get; set; }
        public int Brand_ID { get; set; }
        public string SKU { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double SalePrice { get; set; }
        public string LinkID { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
