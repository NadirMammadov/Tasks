using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6Task.Domain
{
    public  class OrderItem
    {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; } = null!;
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!; 
    }
}
