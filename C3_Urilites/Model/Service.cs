using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace C3_Urilites.Model
{
    internal class Service
    {
        public static void SendMail(string sender, string recipient, string password)
        {
            MailAddress from = new MailAddress(sender);
            MailAddress to = new MailAddress(recipient);
            MailMessage mailMessage = new MailMessage(from, to);
            mailMessage.Subject = "Тест письма";
            mailMessage.Body = "<h2>Письмо-тест. Smtp-клиент/<h2>";
            mailMessage.IsBodyHtml =true;
            SmtpClient smtpClient = new SmtpClient("smtp.mail.ru", 25);
            smtpClient.Credentials = new NetworkCredential(sender, password);
            smtpClient.EnableSsl = true;
            try
            {
                smtpClient.Send(mailMessage);
                Log("Send");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Письмо не отправлено " + ex.Message);
            }
        }

        public static void Log(string message)
        {
            string messageSender = $"{DateTime.Now.ToLongTimeString()}: {message}";
            System.Diagnostics.Debug.WriteLine(messageSender);
            System.IO.File.AppendAllText("log.txt", messageSender);
        }
        public static List<String> GetListTo()
        {
            return new List<string>() { "Adres1@mail.ru", "Adres2@mail.ru" };
        }
    }
}
