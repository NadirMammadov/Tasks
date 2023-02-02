

using RabbitMQ.Client;
using System.Text.Json;
using System.Text;
using RabbitMQ.Client.Events;
using System.Reflection.Metadata;
using RabbitMQProject.Models;
using RabbitMQDemo;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.AspNet.SignalR.Client;


public class Program
{
    public static async Task Main()
    {

        Microsoft.AspNetCore.SignalR.Client.HubConnection hubConnection = new HubConnectionBuilder().WithUrl("http://localhost:5185/chatHub").Build();
         hubConnection.StartAsync();
        ConnectionFactory factory = new ConnectionFactory();
        factory.Uri = new Uri("amqps://jklhyubi:M-TgUC9Yr9eLagaeGqCY5YXXquJxi_QK@jackal.rmq.cloudamqp.com/jklhyubi");
        using RabbitMQ.Client.IConnection connection = factory.CreateConnection();
        using IModel channel = connection.CreateModel();


        channel.QueueDeclare("messagequeue",false,false,true);

        EventingBasicConsumer consumer = new EventingBasicConsumer(channel);
        channel.BasicConsume("messagequeue", true, consumer);
        consumer.Received += async (sender, e) =>
        {

            User user = JsonSerializer.Deserialize<User>(Encoding.UTF8.GetString(e.Body.Span));
            EmailSender.SendEmail(user.Email, "Report", user.Message);
            Console.WriteLine("bura isledi");
            hubConnection.InvokeAsync("SendMessage", $"{user.Email} adresine mail gonderildi");
        };
        Console.Read();
    }
}