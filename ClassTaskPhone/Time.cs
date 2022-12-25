using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTaskPhone
{
    public static class Time
    {
        public static async Task<string> StartTime()
        {
            while (true)
            {
                DateTime time = DateTime.Now;
                return time.ToLongTimeString();
                await Task.Delay(2000);
            }
                
           
        }
    }
}
