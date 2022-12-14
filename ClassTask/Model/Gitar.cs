using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTask.Model
{
    public class Gitar:Instrument
    {
        public string Tur { get; set; } = null!;
        public string Klavye { get; set; } = null!;
        public override string Sound()
        {
            return "Gitar sesi ";    
        }

    }
}
