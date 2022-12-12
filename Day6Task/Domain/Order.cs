using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Day6Task.Domain
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;
        public string OrderNumber { get; set; } = null!;
        public DateTime OrderDate { get; set; }
        public List<OrderItem> OrderItems { get; set; } = null!;
       
        public EnumOrderState OrderState { get; set; }
        public EnumPaymentType PaymentType { get; set; }
    }

    public enum EnumOrderState
    {
        waiting = 0,
        paid = 1,
        incargo = 2,
        failed =3 ,
        completed = 4,
    }
    public enum EnumPaymentType
    {
        CreditCard = 0,
        Cash = 1
    }
}
