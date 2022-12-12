using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6Task.Domain
{
    public class Supplier
    {
        public int SupplierId { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public List<SupplierProduct> SupplierProducts { get; set; } = null!;
    }
}
