using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
namespace ClasssTaskAsync;
internal class Bacon { }
internal class Coffee { }
internal class Egg { }
internal class Juice { }
internal class Toast { }

class Program
{

   
    static async Task Main(string[] args)
    {
        List<string> urls = new List<string>();
        urls.Add("https://www.facebook.com/");
        urls.Add("https://www.linkedin.com/");
        urls.Add("https://www.instagram.com/");
        List<Task<string>> tasks = new List<Task<string>>();
        HttpClient http = new();
        Stopwatch stopwatch = new();
        stopwatch.Start();
        foreach (var url in urls)
        {
            tasks.Add(http.GetStringAsync(url));
        }
        await Task.WhenAll(tasks);
        stopwatch.Stop();
        foreach (var item in tasks)
        {
            Console.WriteLine($"{item.Result.Length} ");
        }

    }
   
}

