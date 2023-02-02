using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using RabbitMQProject.Models;
using System.Diagnostics;
using System.Text;
using System.Text.Json;

namespace RabbitMQProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Chat()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Chat(User user)
        {
            ConnectionFactory factory = new ConnectionFactory();
            factory.Uri = new Uri("amqps://jklhyubi:M-TgUC9Yr9eLagaeGqCY5YXXquJxi_QK@jackal.rmq.cloudamqp.com/jklhyubi");
             using IConnection connection = factory.CreateConnection();
            using IModel channel = connection.CreateModel();
            string serilaze = JsonSerializer.Serialize(user);
            byte[] byteData = Encoding.UTF8.GetBytes(serilaze);

            channel.QueueDeclare("messagequeue", false, false, true);
            channel.BasicPublish("", routingKey: "messagequeue", body: byteData);


            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}