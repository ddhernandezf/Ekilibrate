using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BarcoSoftUtilidades.Utilidades
{
    public class SendMail
    {
        /// <summary>
        /// Credenciales de env{io
        /// </summary>
        private SmtpClient smtpClient { get; set; }

        private string fromAdress { get; set; }

        public SendMail(SmtpClient pClienteSmtp, string pFromAdress)
        {
            smtpClient = pClienteSmtp;
            fromAdress = pFromAdress;
        }

        public SendMail(string pEmailDireccionProvider, string pPassword, string pHost, int pPort)
        {
            //var client = new SmtpClient("smtp.gmail.com", 587)
            var client = new SmtpClient(pHost, pPort)
            {
                Credentials = new NetworkCredential(pEmailDireccionProvider, pPassword),
                EnableSsl = true
            };
            fromAdress = pEmailDireccionProvider;
        }

        public void Send(MailMessage mail)
        {
            smtpClient.Send(mail);
        }

        public void Send(string fromName, string toAdress, string toName, string subject, string body, bool isBodyHtml)
        {
            var fromAddress = new MailAddress(fromAdress, fromName);
            var toAddress = new MailAddress(toAdress, toName);
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = isBodyHtml
            })
                smtpClient.Send(message);
        }




    }
}
