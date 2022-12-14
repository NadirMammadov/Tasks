using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8Taskk.Enum
{
    public enum ColorEnum
    {
        [Display(Name = "Kirmizi renk")]
        Red,
        [Display(Name = "Siyah renk")]
        Black,
        [Display(Name = "Mavi renk")]
        Blue,
        [Display(Name = "Yesil renk")]
        Green

    }
}
