using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTask1.Models
{
    public class Rectangular :Figure
    {
        public Rectangular(double width , double length)
        {
            Width = width;
            Length = length;
        }
        private double _width;
        private double _length;
        public double Width {
            get
            {
                return _width;
            }
            set
            {
                if (value <0)
                    throw new Exception("Width menfi ola bilmez");
                else
                    _width = value;
            }

        }
        public double Length {
            get
            {
                return _length;
            }
            set
            {
                if (value < 0)
                    throw new Exception("Length menfi ola bilmez");
                else
                    _length = value;
            }
        }
        public override double CalcArea()
        {
            return Width * Length;
        }
    }
}
