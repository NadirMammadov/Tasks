
using ClassTask1.Models;
using static ClassTask1.Program;

namespace ClassTask1;

public class Program
{
    public delegate void UserDelegate(string message);

    public static void Main()
    {
        
        //Loger Instance
        Logger logger = new();
        //Company Instance
        Company company = new();
        //CreateUser Instance
        CreateUser createUser = new();
        //User List
        List<User> users = new();


        #region User
        User user = new User();
        user.FirstName = "Nadir";
        user.Password = "nadirpassword";
        user.LastName = "Memmedov";
        #endregion


        // Register Delegate Instanse
        UserDelegate registerdel = new UserDelegate(logger.LogToRegister);
        // Register Check 
        var registerResult =  company.Register(user.FirstName, user.LastName,user.Password);
        if (registerResult=="Success")
        {
            var resultuser = createUser.Create(user);
            users.Add(resultuser);
        }
        registerdel.Invoke(registerResult);



        void Login(User loginuser)
        {
            UserDelegate userDelegate = new UserDelegate(logger.LogToUserLogin);

            var datauser  = users.FirstOrDefault(x => x.UserName == user.UserName);
            if (datauser == null)
            {
                userDelegate.Invoke("User tapilmadi");
            }
            var validateuser = company.UserLoginValidate(datauser, loginuser);
            userDelegate.Invoke(validateuser);
        }
        

    }
}