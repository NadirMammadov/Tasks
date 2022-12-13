using Day7Task.Model;

public class Program
{
    public static void Main()
    {
        User user = new User
        {
            FirstName = "Nadir",
            LastName = "Memmedov"
        };
        user.GetType().GetProperties().ToList().ForEach(p=>
        {
            if(p.Name!="Email")
            {
                Console.WriteLine($"{p.Name}: {p.GetValue(user)}");
            }
        }
           
        );
        user.GetType().GetMethods().ToList().ForEach(op =>
        {
            if(op.Name == "WriteEmail")
            {
                Console.Write("Email: ");
                Console.WriteLine(op.Invoke(user, new object[] { user.FirstName, user.LastName }));
            }
        });
    }
}