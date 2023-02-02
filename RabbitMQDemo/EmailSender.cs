using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;


namespace RabbitMQDemo
{
    public class EmailSender
    {
        public static void SendEmail(string to, string subject, string body)
        {
            Console.WriteLine("Email sending...");
            MimeMessage email = new MimeMessage();
            email.Sender = MailboxAddress.Parse("nadirem@code.edu.az");
            email.To.Add(MailboxAddress.Parse(to));
            email.Subject = subject;
            var builder = new BodyBuilder();
            builder.HtmlBody = $@"<h1 style='text-align:center;'>{subject}</h1></br>
<p style='text-align:center;color:blue;'>{body}</p>";
            email.Body = builder.ToMessageBody();
            using (MailKit.Net.Smtp.SmtpClient smtp = new())
            {
                smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                smtp.Authenticate("nadirem@code.edu.az", "$Codenadir$$");
                smtp.Send(email);
                smtp.Disconnect(true);
            }

            Console.WriteLine("Email sent");
        }
       
    }
    
}
