using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTaskPhone
{
    public static class Time
    {
        public static async Task StartTime()
        {
            while (true)
            {
                DateTime time = DateTime.Now;
                
                Console.WriteLine(time.ToLongTimeString());
                await Task.Delay(1000);
                Console.Clear();
            }
                
           
        }
    }
}


