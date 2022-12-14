using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTask.Model
{
    public class Keman : Instrument
    {
        public string Arse { get; set; } = null!;
        public override string Sound()
        {
            return "Keman sesi";    
        }
    }
}
