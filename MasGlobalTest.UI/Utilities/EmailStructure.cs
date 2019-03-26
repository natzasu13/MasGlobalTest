using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Http;

namespace MasGlobalTest.UI.Utilities
{
    public class EmailStructure
    {
        private string passwordFrom = "****";
        private string emailFrom = "natzasu13@hotmail.com";
        private int port = 587; //465; //587;
        private string smtp = "smtp.live.com";

        public EmailStructure()
        {


        }

        public Tuple<MailMessage, SmtpClient> ConfigEmailStructure(string subject, string emailTo, string body, string[] emailsCopy = null, string[] emailsHidderCopy = null)
        {
            MailMessage mail = new MailMessage(emailFrom, emailTo);

            #region Email body
            mail.IsBodyHtml = true;
            mail.Subject = subject;
            mail.SubjectEncoding = Encoding.UTF8;
            mail.Body = body;
            mail.BodyEncoding = Encoding.UTF8;
            mail.Priority = MailPriority.Normal;

            #endregion

            #region Add email whit copy and hidder copy
            if (emailsCopy != null)
            {
                foreach (var item in emailsCopy)
                {
                    MailAddress copy = new MailAddress(item);
                    mail.CC.Add(copy);
                }
            }

            if (emailsHidderCopy != null)
            {
                foreach (var item in emailsHidderCopy)
                {
                    MailAddress Bcopy = new MailAddress(item);
                    mail.Bcc.Add(Bcopy);
                }
            }
            #endregion

            #region Smtp cliente congiguration


            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Port = port;
            smtpClient.Host = smtp;
            smtpClient.Timeout = 1000000;
            smtpClient.UseDefaultCredentials = false; // Important: This line of code must be executed before setting the NetworkCredentials object, otherwise the setting will be reset (a bug in .NET)
            smtpClient.Credentials = new System.Net.NetworkCredential(emailFrom, passwordFrom);
            //detect SSL/TLS automatically
            smtpClient.EnableSsl = true; //Esto es para que vaya a través de SSL que es obligatorio con GMail

            #endregion

            return Tuple.Create(mail, smtpClient);
        }
    }
}