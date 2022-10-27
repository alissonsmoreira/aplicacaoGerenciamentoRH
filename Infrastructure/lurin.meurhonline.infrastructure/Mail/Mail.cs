using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Net.Configuration;
using System.IO;
using System.Reflection;
using lurin.meurhonline.domain.model;

namespace lurin.meurhonline.infrastructure.mail
{
    public class Mail
    {
        private static readonly string fromEmailAdress = ConfigurationManager.AppSettings["MailSendAddress"];
        private static readonly string mailSmtpClient = ConfigurationManager.AppSettings["MailSmtpClient"];
        private static readonly string mailSendPAssword = ConfigurationManager.AppSettings["MailSendPAssword"];
        private static readonly string mailUrl = ConfigurationManager.AppSettings["MailUrl"];
        public static void SendEmail(string toEmailAddress, string emailSubject, string emailMessage, bool htmlMessage)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(fromEmailAdress);
            mail.To.Add(toEmailAddress);
            mail.Subject = emailSubject;
            mail.Body = emailMessage;
            if (htmlMessage)
                mail.IsBodyHtml = true;

            using (var smtp = new SmtpClient(mailSmtpClient))
            {
                smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(fromEmailAdress, mailSendPAssword);
                smtp.Send(mail);
            }

            Task.Delay(500);
        }

        public static bool MailValide(string mail)
        {
            Regex regex = new Regex(@"\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}");
            if (regex.IsMatch(mail))
                return true;
            else
                return false;
        }

        public static string GetTemplateHtml(MailType emailType)
        {
            StreamReader arquivo = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream(emailType.Value));
            return arquivo.ReadToEnd();
        }

        public static string GetMailUrl()
        {
            return mailUrl;
        }

    }
}
