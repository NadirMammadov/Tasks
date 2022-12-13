using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTask.Model
{
    public class Gitar:Instrument
    {
        public string Type { get; set; } = null!;
        public string Material { get; set; } = null!;
        public override string Sound()
        {
            return "Gitaranin sesi ";
        }

    }
}
