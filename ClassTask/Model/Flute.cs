using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTask.Model
{
    public class Flute : Instrument
    {
        public string Type { get; set; } = null!;
        public override string Sound()
        {
            return "Fluet Sound";
        }
    }
}
