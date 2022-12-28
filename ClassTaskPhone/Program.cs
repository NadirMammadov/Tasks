using ClassTaskPhone;
using ClassTaskPhone.Models;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;

public class Program
{
    public  static async Task Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Phone myPhone = new Phone();
        myPhone.Number = Console.ReadLine();
        myPhone.Balance = double.Parse(Console.ReadLine());
        myPhone.Provider = ProviderName(myPhone.Number);



        List<Task> tasks = new List<Task>();
        tasks.Add(Time.StartTime());
        tasks.Add(CallNumber());
        await Task.WhenAll(tasks);


        async Task CallNumber()
        {
            List<int> numbers = new();
            while (true)
            {
                
                var dt = Console.ReadKey();
                numbers.Add(dt.KeyChar);
            }
        }
    }


    public static string ProviderName(string number)
    {
        if (number.IndexOf("+99470", 0, 6)==0 || number.IndexOf("070", 0, 3) == 0 || number.IndexOf("+99477", 0, 6) == 0 || number.IndexOf("077", 0, 3) == 0)
        {
            return "Nar";
        }
        else if(number.IndexOf("+99455", 0, 6) == 0 || number.IndexOf("055", 0, 3) == 0 || number.IndexOf("+99499", 0, 6) == 0 || number.IndexOf("099", 0, 3) == 0)
        {
            return "Bakcell";
        }
        else if (number.IndexOf("+99450", 0, 6) == 0 || number.IndexOf("050", 0, 3) == 0 || number.IndexOf("+99451", 0, 6) == 0 || number.IndexOf("051", 0, 3) == 0)
        {
            return "Azercell";
        }
        return "Provider tapilmadi";
    }
}