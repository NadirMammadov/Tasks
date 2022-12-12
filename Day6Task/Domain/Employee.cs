using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Day6Task.Domain
{
    public class Employee: User
    {
        public int EmployeeId { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public List<OrderItem> OrderItems { get; set; }
        public Employee()
        {
            OrderItems = new List<OrderItem>();
        }
    }
}
