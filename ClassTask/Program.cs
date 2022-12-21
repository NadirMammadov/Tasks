using ClassTask.Model;
using System.Reflection;

public class Program
{
    public static void Main()
    {
        List<User> users = new List<User>();
        User user = new User("nadir@gmail.com", "SAAs123213213");
        user.Fullname = "Nadirmemm";
        User user1 = new User("nadirem@gmail.com", "Aas123213213");
        user1.Fullname = "MemmedovNadir";
        if (user.PasswordChecker(user.Password))
        {
            users.Add(user);
            
            user.ShowInfo();
        }
        else
        {
            Console.WriteLine("Password duzgun deyl");
        }
        if (user1.PasswordChecker(user1.Password))
        {
            users.Add(user);
            user1.ShowInfo();
        }
        else
        {
            Console.WriteLine("Password duzgun deyl");
        }
    }
}