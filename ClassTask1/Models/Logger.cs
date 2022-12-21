using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTask1.Models
{
    public class Logger
    {
        public void LogToRegister(string message) {
            Console.WriteLine($"Register Log mesaji: {message}"); 
        } 
        public void LogToUserLogin(string message) {
            Console.WriteLine($"Login Log mesaji: {message}");
        }
    }
}
