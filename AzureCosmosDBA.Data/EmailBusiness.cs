using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Configuration;

namespace AzureCosmosDBA.Data
{
    public class EmailBusiness
    {
        public void Email(string To, string Subject, string Message)
        {

            var SenderEmail = new MailAddress(ConfigurationManager.AppSettings["EmailAddress"], "Azure Email");
            var recieverEmail = new MailAddress(To, "Reciever");

            var Password = ConfigurationManager.AppSettings["EmailPassword"];
            var sub = Subject;
            var body = Message;

            var smtp = new SmtpClient
            {
                Host = $"smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(SenderEmail.Address, Password)

            };


            using (var mess = new MailMessage(SenderEmail, recieverEmail)
            {
                Subject = Subject,
                Body = body
            }
                )
            {
                smtp.Send(mess);
            }


        }
    }
}
