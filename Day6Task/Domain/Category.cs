using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6Task.Domain
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public List<ProductCategory> ProductCategories { get; set; } = null!;
    }
}
