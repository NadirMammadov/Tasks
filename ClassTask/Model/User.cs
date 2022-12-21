

namespace ClassTask.Model
{
    public class User: IAccount
    {
        public User(string email, string password)
        {
            Email = email; Password = password; 
        }
        private static int _id =1;
        public int Id { get => _id++; }
        public string Fullname { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;

        public bool PasswordChecker(string password)
        {
            
            var passwordresult = System.Text.RegularExpressions.Regex.IsMatch(password, @"^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])");
            if (password.Length >= 8 && passwordresult)
            {
                return true;
            }
            return false;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"UserId:{Id} \n Fullname:{Fullname} \n Email:{Email}");
        }
    }
}
