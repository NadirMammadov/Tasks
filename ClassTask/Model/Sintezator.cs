using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTask.Model
{
    public class Sintezator : Instrument
    {
        public string Type { get; set; } = null!;
        public int ButtonCount { get; set; }
        public double Kq { get; set; }
        public override string Sound()
        {
            return "Sintezator sesi ";    
        }
    }
}
