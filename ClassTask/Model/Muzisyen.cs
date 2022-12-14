using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTask.Model
{
    public class Muzisyen
    {
        public Muzisyen()
        {
            this.Instrument = new HashSet<Instrument>();
        }
        public string Adi { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int Yasi { get; set; }
        public ICollection<Instrument>?  Instrument { get; set; }
    }
}
