using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6Task.Domain
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public double Price { get; set; }
        public string Image  { get; set; } = null!;
        public DateTime DateAdded { get; set; }
        public List<ProductCategory> ProductCategories { get; set; } = null!;
        public List<SupplierProduct> SupplierProducts { get; set; } = null!;

    }
}
