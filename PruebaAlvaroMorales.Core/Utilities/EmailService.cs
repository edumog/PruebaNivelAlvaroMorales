using PruebaAlvaroMorales.Core.Entities;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace PruebaAlvaroMorales.Core.Utilities
{
    static class EmailService
    {
        private static string emailOrigin = "email-origin";
        private static string password = "password";
        public static async Task SendEmailBillStatusChangeNotification(Client client, string previousState, Bill bill)
        {
            string subject = "Cambio de estado de factura";
            string body = $"Notificación de cambio de estado de factura<h2>Buen día {client.Name}</h2><h3>Id Factura {bill.Id}</h3><p>La factura {bill.Id} por un valor de {bill.Total} cambio de {previousState} a {bill.State}.</p><br><footer>Gracias feliz día</footer>";
            MailMessage message = new MailMessage(emailOrigin, client.Email, subject, body);
            message.IsBodyHtml = true;
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Port = 587;
            smtpClient.Credentials = new NetworkCredential(emailOrigin, password);
            await smtpClient.SendMailAsync(message);
            smtpClient.Dispose();
        }
    }
}
