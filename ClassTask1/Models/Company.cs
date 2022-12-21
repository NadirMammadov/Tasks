using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ClassTask1.Models
{
    public class Company
    {
        public string Name { get; set; }
        public string Register(string firstName,string lastName, string password)
        {
            var validate = RegisterValidation(firstName, lastName, password);
            return validate;
        }
        public string RegisterValidation(string firstName, string lastName, string password)
        {
            if (firstName == null)
                return "Name bos ola bilmez";
            else if (lastName == null)
                return "LastName bos ola bilmez";
            else if (password == null)
                return "Password bos ola bilmez";
            else if (password.Length < 8)
                return "Password en azi 8 simvol olmalidir";
    
            return "Success";
        }
        public string UserLoginValidate(User datauser, User loginuser)
        {
            if (datauser.Password != loginuser.Password)
            {
                return "Login Success";
            }
            else
                return "Password dogru deyil";
        }
    }
}
