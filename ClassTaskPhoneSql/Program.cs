using ClassTaskPhoneSql.Models;
using Dapper;
using System.Data.SqlClient;
using System.Diagnostics;

public class Program
{
    public static void Main()
    {
        // User user = GetUserNumber();
        //List<Task> tasks = new List<Task>();

        //tasks.Add(StartTime());
        //tasks.Add(GetMenu());
        //tasks.Add(GetCommand());

        //await Task.WhenAll(tasks);
        User user = new User()
        {
            Provider = "Nar"
        };

        List<string> enterNum = new();
        string message=null;
        string callTime = null;
        Task.Run(async () =>
        {
           
                while (true)
                {
                    string logo = @$" ---------------------
|                     |
|    {StartTime()}      |
|  {user.Provider}                |
|  {message}                   | 
|                    |
|   {GetDisplay()}                  |
|                     |
                ";

                    Console.WriteLine(logo);
                    Console.WriteLine(GetMenu());
                      
                    await Task.Delay(1000);
                    Console.Clear();
                   
            }
                       
            
            
            
        });

        Task.Run(() =>
        {
            while (true)
            {
                string num = Console.ReadKey().KeyChar.ToString();
                
                if(num == "Y" || num == "y")
                {
                    var number = GetDisplay();

                    if (ProviderName(number) == "Error" || number.Length > 13 || number.Length < 10)
                    {
                        message = "Nomre duzgun daxil edilmeyib";
                        enterNum = new();
                    }
                    else
                    {
                        message = "Zeng edilir...";
                    }
                }
                else
                {
                    enterNum.Add(num);
                }
               
            }
        });
        while (true)
        {

        }
        string GetDisplay()
        {
            string displayText=null;
            foreach (var item in enterNum)
            {
                displayText += item;
            }
            return displayText;
        }
    }
    public static void Call(string number)
    {

    }
    public static string StartTime()
    {
        DateTime time = DateTime.Now;
        return time.ToLongTimeString();
    }
    public static string GetMenu()
    {
        return "Zeng etmek ucun daxil edib Y basin \nNomre elave etmek ucun H \nNomreni yenilemek ucun J  \nContacti gostermek ucun F\nCixisi ucun X ";
    }
    public static void GetCommand()
    {
        int num = int.Parse(Console.ReadLine());
        switch (num)
        {
            case 1:
                AddContact();
                break;
            case 2:
                UpdateContact();
                break;
            case 3:
                GetAllContact();
                break;
            default:
                break;
        }

    }
    public static void GetAllContact()
    {
        var connection = GetConnection();
        var data = connection.ExecuteReader("select Name,Number FROM Contact;");
        Console.WriteLine("------------------------------------------------");
        while (data.Read())
        {
            Console.WriteLine($"Contact Name : {data[0]}\n--Number:{data[1]}");
        }
        Console.WriteLine("------------------------------------------------");
    }

    public static void UpdateContact()
    {
        Console.WriteLine("Yenilecek contactin adini girin");
        string? updateName = Console.ReadLine();
        Console.WriteLine("Yeni nomreni daxil edin");
        string? newNumber = Console.ReadLine();
        var connection = GetConnection();
        connection.Execute("Update Contact set Number = @newNumber WHERE NAME =@updateName;  ", new { newNumber, updateName });
        Console.Clear();
    }

    public static void AddContact()
    {
        Contact contact = new();
        Console.WriteLine("Adi daxil edin: ");

        contact.Name = Console.ReadLine();
        Console.WriteLine("Nomreni daxil edin: ");

        contact.Number = Console.ReadLine();
        var connection = GetConnection();
        connection.Execute("insert into Contact(Name , Number) Values(@name,@number);", new { contact.Name, contact.Number });
        Console.Clear();
    }
    public static SqlConnection GetConnection()
    {
        string connectionString = "Server=Machine; Database=PhoneDb; Trusted_Connection=True;";
        SqlConnection connection = new SqlConnection(connectionString);
        return connection;
    }
    public static User GetUserNumber()
    {
        bool validate = true;
        User user = new();
        Console.WriteLine("Telefonu baslatmaq ucun nomrenizi daxil edin: ");
        user.Number = Console.ReadLine();

        while (validate)
        {
            if (ProviderName(user.Number) == "Error" || user.Number.Length > 13 || user.Number.Length < 10)
            {
                Console.WriteLine("Nomreni duzgun daxil edin");
                user.Number = Console.ReadLine();
            }
            else validate = false;
        }
        user.Provider = ProviderName(user.Number);
        Console.WriteLine("Balansi daxil edin: ");
        user.Balance = Convert.ToDouble(Console.ReadLine());
        return user;
    }
    public static string ProviderName(string number)
    {
        if (number.IndexOf("+99470", 0, 6) == 0 || number.IndexOf("070", 0, 3) == 0 || number.IndexOf("+99477", 0, 6) == 0 || number.IndexOf("077", 0, 3) == 0)
        {
            return "Nar";
        }
        else if (number.IndexOf("+99455", 0, 6) == 0 || number.IndexOf("055", 0, 3) == 0 || number.IndexOf("+99499", 0, 6) == 0 || number.IndexOf("099", 0, 3) == 0)
        {
            return "Bakcell";
        }
        else if (number.IndexOf("+99450", 0, 6) == 0 || number.IndexOf("050", 0, 3) == 0 || number.IndexOf("+99451", 0, 6) == 0 || number.IndexOf("051", 0, 3) == 0)
        {
            return "Azercell";
        }
        return "Error";
    }
}