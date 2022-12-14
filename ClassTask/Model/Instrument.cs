using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTask.Model
{
    public abstract class Instrument
    {

        public string Marka { get; set; } = null!;
        public string Model { get; set; } = null!;
        public double Fiyat { get; set; }
        public virtual string Sound()
        {
            return "Default ses ";
        }
    }
}
