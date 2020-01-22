using SendGrid;
using SendGrid.Helpers.Mail;
using SendGrid.SmtpApi;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace NotificationService
{
    public static class SendNotification
    {
        public static void SendNotificationToUser()
        {
            // Command-line argument must be the SMTP host.
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("worldofangerpixel@gmail.com", "Hordarula1");

            var message = new MailMessage();

            message.To.Add("mirko.srsens@gmail.com");
            message.From = new MailAddress("worldofangerpixel@gmail.com");
            message.Subject = "It works !";
            message.Body = "This is actualy working";

            client.Send(message);
        }
    }
}
