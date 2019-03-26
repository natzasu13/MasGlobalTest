using MasGlobalTest.UI.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace MasGlobalTest.UI.ApiControllers
{

    public class EnvioCorreosController : ApiController
    {
        private readonly EmailStructure _emailStructure;

        private EnvioCorreosController()
        {
            if (_emailStructure == null)
                _emailStructure = new EmailStructure();

        }

        //GET: api/EnvioCorreos/SendEmailNodo?subject=asuntoCorreoprueba2&body=este es el cuerpo del correo&emailTo=natzasu13@gmail.com&emailsCopy=nzartha@utp.edu.co&emailsCopy=natalia.zartha@gmail.com&emailsHidderCopy=natzasu13@gmail.com&emailsHidderCopy=natzasu13@hotmail.com
        [HttpGet]
        public async Task SendEmailNodo(string subject, string emailTo, string body, [FromUri] string[] emailsCopy, [FromUri] string[] emailsHidderCopy)
        {
            MailMessage mail = new MailMessage();
            SmtpClient smtpClient = new SmtpClient();

            var tuple = _emailStructure.ConfigEmailStructure(subject, emailTo, body, emailsCopy, emailsHidderCopy);
            smtpClient = tuple.Item2;
            mail = tuple.Item1;

            #region add sttachments
            //Add image
            string imagePath = AppDomain.CurrentDomain.BaseDirectory + "/Images/bullet.png";
            Attachment inlineLogo = new Attachment(imagePath);
            mail.Attachments.Add(inlineLogo);
            //if (!string.IsNullOrWhiteSpace(attachmentPath) && File.Exists(attachmentPath))
            //{
            //    Attachment attachment = new Attachment(attachmentPath);
            //    mailMsg.Attachments.Add(attachment);
            //}

            ////Add .doc

            #endregion


            //event handler for asynchronous call
            try
            {
                await smtpClient.SendMailAsync(mail);
            }
            catch (Exception ex)
            {
                /* exception handling code here */
            }

        }

        public class EmailApiModel
        {
            public string subject { get; set; }
            public string body { get; set; }
            public string emailTo { get; set; }
            public string emailFrom { get; set; }
            public string idNodo { get; set; }
            public string[] emailsCopy { get; set; }
            public string[] emailsHidderCopy { get; set; }
        }
    }
}
