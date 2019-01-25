using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using Ekilibrate.Model.Administrador;
using Autofac;
using System.ServiceModel;
using Autofac.Integration.Wcf;


namespace EkilibrateSendMail
{


    public class Mail
    {
        public Mail()
        {

        }

        public async Task<List<Ekilibrate.Model.Entity.General.clsMensajeCorreo>> ReadMail()
        {            
            using (var scope = EkilibrateSendMail.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                
                Ekilibrate.Model.Entity.Administrador.clsEmpresaFiltro objFiltro = new Ekilibrate.Model.Entity.Administrador.clsEmpresaFiltro();
                var middleTier = scope.Resolve<Ekilibrate.Model.Services.Administrador.IDataRetriever>();
                var ColaMensajes = await middleTier.GetCorreos();

                var MensajesIndividuales = ColaMensajes.Where(c => c.EsLista == "NO").ToList();

                return MensajesIndividuales;
            }
        }

        public async Task<Ekilibrate.Model.Entity.General.CorreoElectronico> ReadSMTPConfig()
        {
            using (var scope = EkilibrateSendMail.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                Ekilibrate.Model.Entity.Administrador.clsEmpresaFiltro objFiltro = new Ekilibrate.Model.Entity.Administrador.clsEmpresaFiltro();
                var middleTier = scope.Resolve<Ekilibrate.Model.Services.Administrador.IDataRetriever>();
                var CorreoElectronico = await middleTier.GetInfoCorreo();

                return CorreoElectronico.FirstOrDefault();
            }
        }

        public async Task<Int32> UpdateMail(IEnumerable<Ekilibrate.Model.Entity.General.clsMensajeCorreo> correos)
        {
            using (var scope = EkilibrateSendMail.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                var middleTier = scope.Resolve<Ekilibrate.Model.Services.Administrador.IDataInjector>();
                return await middleTier.UpdateCorreo(correos);
                
            }
        }

        public async Task CreateMailDB(Ekilibrate.Model.Entity.General.clsMensajeCorreo correo)
        {
            using (var scope = EkilibrateSendMail.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                var middleTier = scope.Resolve<Ekilibrate.Model.Services.Administrador.IDataInjector>();
                await middleTier.CrearCorreo(correo);
            }
        }

        public async Task<ExcecutionResult> MandaEmail()
        {

            try
            {
                ExcecutionResult Result = new ExcecutionResult();
                Autofac.ContainerConfig.Start();

                var ColaMensajes = await ReadMail();

                var Correo = await ReadSMTPConfig();

                using (SmtpClient client = new SmtpClient())
                {
                    client.EnableSsl = false;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(Correo.Usuario, Correo.Password);
                    client.Host = Correo.Host;
                    client.Port = (int)Correo.Puerto;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.ServicePoint.MaxIdleTime = 1;
                    client.Timeout = 10000;

                    foreach (var destino in ColaMensajes)
                    {
                        MailMessage msg = new MailMessage();

                        msg.From = new MailAddress(Correo.Correo.ToString());
                        msg.To.Add(destino.Para.ToString());
                        msg.Subject = destino.Asunto;
                        msg.Body = destino.Mensaje;
                        msg.IsBodyHtml = destino.EsHTML.Equals("SI");
                        msg.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                        
                        try
                        {
                            client.Send(msg);
                            destino.EstadoEnvio = "ENVIADO";
                            destino.FechaEnvio = DateTime.Now;
                            Result.CorreosEnviados++;
                        }
                        catch (Exception ex)
                        {
                            destino.EstadoEnvio = "ERROR";
                            //destino.FechaEnvio = DateTime.Now;

                            Result.CorreosNoEnviados++;
                            Result.Referencia += "-> [" + ex.Message + "<" + ex.InnerException + ">" + "]";
                        }
                    }

                    var update = UpdateMail(ColaMensajes);
                }

                return Result;
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error fatal: " + ex.Message +" / "+ ex.InnerException.Message);
                throw;
            }
        }
        
        public async Task DirectEmail(Ekilibrate.Model.Entity.General.clsMensajeCorreo mensaje,
                                string MailAccount,
                                string MailPassword)
        {
            try
            {                
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

                    msg.From = new MailAddress(MailAccount, "Ekilibrate");
                    msg.To.Add(mensaje.Para.ToString());
                    msg.Subject = mensaje.Asunto;
                    msg.Body = mensaje.Mensaje;
                    msg.IsBodyHtml = mensaje.EsHTML.Equals("SI");
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

                    await CreateMailDB(mensaje);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al enviar correo: " + ex.Message + " / " + ex.InnerException.Message);
                throw;
            }
        }

        public async Task<ExcecutionResult> SendEmail()
        {

            try
            {
                ExcecutionResult Result = new ExcecutionResult();
                Autofac.ContainerConfig.Start();

                var ColaMensajes = await ReadMail();

                var Correo = await ReadSMTPConfig();

                using (SmtpClient client = new SmtpClient())
                {
                    client.EnableSsl = false;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(Correo.Usuario, Correo.Password);
                    client.Host = Correo.Host;
                    client.Port = (int)Correo.Puerto;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.ServicePoint.MaxIdleTime = 1;
                    client.Timeout = 10000;

                    foreach (var destino in ColaMensajes)
                    {
                        MailMessage msg = new MailMessage();

                        msg.From = new MailAddress(Correo.Correo.ToString());
                        msg.To.Add(destino.Para.ToString());
                        msg.Subject = destino.Asunto;
                        msg.Body = destino.Mensaje;
                        msg.IsBodyHtml = destino.EsHTML.Equals("SI");
                        msg.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

                        try
                        {
                            client.Send(msg);
                            destino.EstadoEnvio = "ENVIADO";
                            destino.FechaEnvio = DateTime.Now;
                            Result.CorreosEnviados++;
                        }
                        catch (Exception ex)
                        {
                            destino.EstadoEnvio = "ERROR";
                            //destino.FechaEnvio = DateTime.Now;

                            Result.CorreosNoEnviados++;
                            Result.Referencia += "-> [" + ex.Message + "<" + ex.InnerException + ">" + "]";
                        }
                    }

                    var update = UpdateMail(ColaMensajes);
                }

                return Result;
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error fatal: " + ex.Message + " / " + ex.InnerException.Message);
                throw;
            }
        }
    }
}
