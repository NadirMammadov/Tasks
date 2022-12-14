using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTask1.Models
{
    public class Square: Figure
    {
        public Square(double side)
        {
            Side = side;
        }
        private double _side;
        public double Side {
            get
            {
                return _side;
            } set
            {
                if (value <= 0)
                   throw new Exception("menfi deyer ala bilmez");
                else
                    _side = value;
            }
        }
        public override double CalcArea()
        {
            return Side*Side;
                
        }

    }
}
