using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTask.Model
{
    public class Piano :Instrument
    {
        public int PedalCount { get; set; }
        public override string Sound()
        {
            return "Pianonun sesi";
        }
    }
}
