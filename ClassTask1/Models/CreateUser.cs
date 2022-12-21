using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTask1.Models
{
    public class CreateUser
    {
        public User Create(User user)
        {
            User user1 = new();
            user1.FirstName = user.FirstName;
            user1.LastName = user.LastName;
            user1.UserName = (user.FirstName + user.LastName).ToLower();
            user1.Email = (user.FirstName+ user.LastName + "@gmail.com").ToLower();
            user1.Password = user.Password;
            return user1;
        }
    }
}
