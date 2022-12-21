

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
        var users = httpClient.GetStreamAsync("https://randomuser.me/api?results=10").Result;
        StreamReader streamReader = new StreamReader(users);
        var json = streamReader.ReadToEndAsync().Result;
        var obj = JsonConvert.DeserializeObject<Root>(json);
        var result = obj.results.ToList();
        foreach (var item in result)
        {
            VCard vCard = new VCard();
            vCard.Id = item.id.value;
            vCard.FirstName = item.name.first;
            vCard.LastName = item.name.last;
            vCard.Email = item.email;
            vCard.Phone = item.phone;
            vCard.Country = item.location.country;
            vCard.City = item.location.city;

            string vcardcontent = FileHelp.CreateVCard(vCard);
            string SavePath = System.IO.Path.Combine(AppContext.BaseDirectory, $"output_{item.id.value}.vcf");
            System.IO.File.WriteAllText(SavePath, vcardcontent);
            Console.WriteLine("File saved at " + SavePath.Trim());
        }
        
         
        
    }
}
