using ClassTask4.Models;
using Newtonsoft.Json;

public class Program
{
    public static  void Main()
    {
        List<Product> products = new List<Product>();
        products.Add(new Product()
        {
            Id = 1,
            Name = "Iphone 11",
            Description = "Iphone telefonu",
            Price = 2000
        });
        string json = JsonConvert.SerializeObject(products);

        //string folderPath = "C:\\Users\\nadir\\Source\\Repos\\Tasks\\ClassTask4\\AppData\\";
        //StreamWriter streamWriter = File.CreateText(folderPath + "dataa.json");
        //streamWriter.WriteLine(json);
        StreamReader streamReader = new StreamReader(json);
        var jsss = streamReader.ReadToEndAsync().Result;
        Product products1 = JsonConvert.DeserializeObject<Product>(jsss);
        var obj = JsonConvert.DeserializeObject<Product>(jsss);
        Console.WriteLine(obj);

    }
}