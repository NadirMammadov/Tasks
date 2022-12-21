

using Day10Task.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.Json.Serialization;

public class Program
{
    public  async static Task Main()
    {
      await  GetUsers();
    }
    public static async Task GetUsers()
    {
        HttpClient httpClient = new();
        var users = await httpClient.GetStringAsync("https://randomuser.me/api?results=50");
       
        dynamic obj =  JsonConvert.DeserializeObject(users);
        
        Console.WriteLine(obj);  
        
    }
}
