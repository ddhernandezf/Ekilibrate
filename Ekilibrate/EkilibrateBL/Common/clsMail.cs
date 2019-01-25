using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Dapper;
using Autofac;
using Ekilibrate.BL.Queries.General;
using Ekilibrate.Model.Entity.General;
using System.Net.Mail;
using System.Net;

namespace Ekilibrate.BL.Common
{
    public class clsMail
    {
        private ILifetimeScope _lifetimeScope;
        public clsMail(ILifetimeScope lifetimeScope) { _lifetimeScope = lifetimeScope; }

        public async Task DirectEmail(Ekilibrate.Model.Entity.General.clsMensajeCorreo mensaje,
                                string MailAccount,
                                string MailPassword, 
                                string Remitente)
        {
            try
            {
                Ekilibrate.ad.General.clsMensajeCorreo objCorreo = new Ekilibrate.ad.General.clsMensajeCorreo(_lifetimeScope);
                Ekilibrate.Model.Common.ExecutionResult Result = new Ekilibrate.Model.Common.ExecutionResult();
                bool enviado = false;

                using (SmtpClient client = new SmtpClient())
                {
                    client.EnableSsl = false;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(MailAccount, MailPassword);
                    client.Host = "mail.server260.com";
                    client.Port = 587;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.ServicePoint.MaxIdleTime = 1;
                    client.Timeout = 10000;

                    MailMessage msg = new MailMessage();

                    msg.From = new MailAddress(MailAccount, Remitente);
                    msg.To.Add(mensaje.Para.ToString());
                    msg.Subject = mensaje.Asunto;
                    msg.Body = mensaje.Mensaje;
                    msg.IsBodyHtml = mensaje.EsHTML.Equals("SI");
                    msg.Bcc.Add(MailAccount);
                    msg.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

                    try
                    {
                        client.Send(msg);
                        enviado = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al enviar mensaje: " + ex.Message);
                        //throw new Exception("No se pudo enviar el mensaje de confirmación a tu correo, favor verifica que sea correcto");   
                    }

                    if (enviado)
                    {
                        mensaje.EstadoEnvio = "ENVIADO";
                        mensaje.FechaEnvio = DateTime.Now;
                    }

                    await objCorreo.Insert(mensaje);                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al enviar correo: " + ex.Message + " / " + ex.InnerException.Message);
                throw;
            }
        }

        public async Task SendAsAppointment(Ekilibrate.Model.Entity.General.clsMensajeCorreo mensaje,
                                          string MailAccount,
                                          string MailPassword,
                                          string Remitente,
                                          string Location,
                                          DateTime StarDate,
                                          DateTime EndDate
                                          )
        {
            try
            {
                Ekilibrate.ad.General.clsMensajeCorreo objCorreo = new Ekilibrate.ad.General.clsMensajeCorreo(_lifetimeScope);
                Ekilibrate.Model.Common.ExecutionResult Result = new Ekilibrate.Model.Common.ExecutionResult();
                bool enviado = false;

                // Now Contruct the ICS file using string builder
                StringBuilder str = new StringBuilder();
                str.AppendLine("BEGIN:VCALENDAR");
                str.AppendLine("PRODID:-//Schedule a Meeting");
                str.AppendLine("VERSION:2.0");
                str.AppendLine("METHOD:REQUEST");
                str.AppendLine("BEGIN:VEVENT");
                str.AppendLine(string.Format("DTSTART;TZID=America/Guatemala:{0:yyyyMMddTHHmmssZ}", StarDate));
                //str.AppendLine(string.Format("DTSTAMP:{0:yyyyMMddTHHmmssZ}", StarDate));
                str.AppendLine(string.Format("DTEND;TZID=America/Guatemala:{0:yyyyMMddTHHmmssZ}", EndDate));
                str.AppendLine("LOCATION: " + Location);
                str.AppendLine(string.Format("UID:{0}", Guid.NewGuid()));
                //str.AppendLine(string.Format("DESCRIPTION;ENCODING=ESCAPED-CHAR:{0}", mensaje.Mensaje));
                //str.AppendLine(string.Format("X-ALT-DESC;FMTTYPE=text/html:{0}", mensaje.Mensaje));
                str.AppendLine(string.Format("SUMMARY:{0}", mensaje.Asunto));
                str.AppendLine(string.Format("ORGANIZER:MAILTO:{0}", MailAccount));

                str.AppendLine(string.Format("ATTENDEE;CN=\"{0}\";RSVP=TRUE:mailto:{1}", Remitente, mensaje.Para));

                str.AppendLine("BEGIN:VALARM");
                str.AppendLine("TRIGGER:-PT15M");
                str.AppendLine("ACTION:DISPLAY");
                str.AppendLine("DESCRIPTION:Reminder");
                str.AppendLine("END:VALARM");
                str.AppendLine("END:VEVENT");
                str.AppendLine("END:VCALENDAR");

                //Now sending a mail with attachment ICS file.                     
                System.Net.Mail.SmtpClient smtpclient = new System.Net.Mail.SmtpClient();
                smtpclient.Host = "localhost"; //-------this has to given the Mailserver IP

                smtpclient.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;

                System.Net.Mime.ContentType contype = new System.Net.Mime.ContentType("text/calendar");
                contype.Parameters.Add("method", "REQUEST");
                contype.Parameters.Add("name", "Meeting.ics");
                AlternateView avCal = AlternateView.CreateAlternateViewFromString(str.ToString(), contype);                

                using (SmtpClient client = new SmtpClient())
                {
                    client.EnableSsl = false;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(MailAccount, MailPassword);
                    client.Host = "mail.server260.com";
                    client.Port = 587;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.ServicePoint.MaxIdleTime = 1;
                    client.Timeout = 10000;

                    MailMessage msg = new MailMessage();

                    msg.From = new MailAddress(MailAccount, Remitente);
                    msg.To.Add(mensaje.Para.ToString());
                    msg.Subject = mensaje.Asunto;
                    //msg.Body = mensaje.Mensaje;
                    msg.IsBodyHtml = mensaje.EsHTML.Equals("SI");
                    msg.Bcc.Add(MailAccount);
                    msg.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                    msg.AlternateViews.Add(avCal);                    

                    try
                    {
                        client.Send(msg);
                        enviado = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al enviar mensaje: " + ex.Message);
                        //throw new Exception("No se pudo enviar el mensaje de confirmación a tu correo, favor verifica que sea correcto");   
                    }

                    if (enviado)
                    {
                        mensaje.EstadoEnvio = "ENVIADO";
                        mensaje.FechaEnvio = DateTime.Now;
                    }

                    await objCorreo.Insert(mensaje);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al enviar correo: " + ex.Message + " / " + ex.InnerException.Message);
                throw;
            }
        }
    }
}
