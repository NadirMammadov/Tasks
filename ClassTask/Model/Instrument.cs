using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTask.Model
{
    public abstract class Instrument
    {
        public string ModelName { get; set; } = null!;
        public string Brand { get; set; } = null!;
        public double Price { get; set; }
        public string Color  { get; set; } = null!;
        public int Count { get; set; }
        public virtual string Sound()
        {
            return "Ela sesi var";
        }
    }
}
