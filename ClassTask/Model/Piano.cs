using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTask.Model
{
    public class Piano :Instrument
    {
        public string Klavye { get; set; } = null!;
        public string? Fonksiyonlar { get; set; }
        public bool KulaklikGirisi { get; set; }

        public override string Sound()
        {
            return "Piano sesi";    
        }
    }
}
