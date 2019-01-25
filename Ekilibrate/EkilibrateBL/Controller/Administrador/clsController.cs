using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Dapper;
using Autofac;
using Ekilibrate.BL.Queries;
using Ekilibrate.Model.Entity.Administrador;
using Ekilibrate.ad.Administrador;
using Ekilibrate.Model.Constantes.Administrador;

namespace Ekilibrate.BL.Controller
{
    public class clsController
    {
        ILifetimeScope _lifetimeScope; 
        private const string sk = "3kiP@rt";
        private const string tranuser = "paguilar";
        public clsController(ILifetimeScope lifetimeScope) { _lifetimeScope = lifetimeScope; }

        /// <summary>
        /// Este método cambia el estado del proyecto y notifica al cliente que puede cargar los participantes
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public async Task EnviarNotificacion(int ProyectoId)
        {
            Ekilibrate.BL.DataRetriever.clsProyecto drProyecto = new Ekilibrate.BL.DataRetriever.clsProyecto(_lifetimeScope);
            Ekilibrate.Model.Entity.Administrador.clsProyecto data = await  drProyecto.GetProyecto(ProyectoId);

            //if (data.CrearUsuarios)
            //{
            if (data.Correo != null && data.PasswordCorreo != null)
            {
                if ((data.Estado == Ekilibrate.Model.Constantes.Administrador.Proyecto.Estado.EnRegistro 
                    || data.Estado == Ekilibrate.Model.Constantes.Administrador.Proyecto.Estado.Preparacion 
                    || data.Estado == Ekilibrate.Model.Constantes.Administrador.Proyecto.Estado.CreacionParticipantes))
                {
                    //Notificar a los contactos del proyecto que carguen los participantes
                    Ekilibrate.BL.DataRetriever.Administrador.clsProyectoContacto objContacto = new Ekilibrate.BL.DataRetriever.Administrador.clsProyectoContacto(_lifetimeScope);
                    IEnumerable<Ekilibrate.Model.Entity.Administrador.clsContactoProyecto> dContacto = await objContacto.GetContacto(ProyectoId);

                    if (dContacto.Count() > 0)
                    {
                        foreach (var item in dContacto)
                        {
                            //Crear Usuarios
                            //Crear Participante
                            Ekilibrate.ad.Administracion.clsUsuario objUsuario = new Ekilibrate.ad.Administracion.clsUsuario(_lifetimeScope);
                            Ekilibrate.Model.Entity.Administracion.clsUsuarioBase dUsuario = await objUsuario.GetUsuarioByPersona(item.PersonaId);
                            string Mensaje = string.Empty;

                            //Insertar Usuario si no existe
                            if (dUsuario.IdPersona == 0)
                            {
                                string Usuario = await objUsuario.GetUserKey(item.Correo, data.EmpresaNombre, item.PrimerNombre, item.PrimerApellido);
                                dUsuario.IdPersona = item.PersonaId;
                                dUsuario.NombreUsuario = Usuario;
                                dUsuario.IdTipoUsuario = Ekilibrate.Model.Constantes.Administracion.TipoUsuario.Cliente;
                                
                                //Grabrar el usuario encriptado como contraseña de usuario
                                string nuevaContraseña = BarcoSoftUtilidades.Utilidades.Cryptography.Encrypt(DateTime.Now.Millisecond.ToString() + dUsuario.NombreUsuario);
                                dUsuario.Contraseña = BarcoSoftUtilidades.Utilidades.Cryptography.Encrypt(nuevaContraseña);
                                int IdUsuario = await objUsuario.Insert(dUsuario);

                                //Insertar UsuarioPorRol
                                Ekilibrate.ad.Administracion.clsUsuarioPorRol objUsuarioRol = new Ekilibrate.ad.Administracion.clsUsuarioPorRol(_lifetimeScope);
                                Ekilibrate.Model.Entity.Administracion.clsUsuarioPorRolBase dUsuarioRol = new Model.Entity.Administracion.clsUsuarioPorRolBase();
                                dUsuarioRol.IdUsuario = IdUsuario;
                                dUsuarioRol.IdRol = Ekilibrate.Model.Constantes.Administracion.Rol.Cliente;
                                dUsuarioRol.TransacDateTime = DateTime.Now;
                                dUsuarioRol.TransacUser = tranuser;
                                await objUsuarioRol.Insert(dUsuarioRol);

                                Mensaje = String.Format(Ekilibrate.Model.Constantes.Correo.HTMLCorreoRegistro, item.PrimerNombre, dUsuario.NombreUsuario, dUsuario.Contraseña, data.Nombre);
                            }
                            else
                            {
                                Mensaje = String.Format(Ekilibrate.Model.Constantes.Correo.HTMLCorreoRegistroSinContraseña, item.PrimerNombre, dUsuario.NombreUsuario, data.Nombre);
                            }

                            Ekilibrate.BL.Common.clsMail ctrlMail = new Ekilibrate.BL.Common.clsMail(_lifetimeScope);
                            Ekilibrate.Model.Entity.General.clsMensajeCorreo MailNotifica = new Model.Entity.General.clsMensajeCorreo();
                            MailNotifica.Para = item.Correo;
                            MailNotifica.Asunto = "Ekilibrate - Invitación modficar parámetros del proyecto";
                            MailNotifica.Mensaje = Mensaje;
                            MailNotifica.EsHTML = "SI";
                            MailNotifica.EsLista = "NO";

                            try
                            { 
                                await ctrlMail.DirectEmail(MailNotifica, data.Correo, data.PasswordCorreo, "Ekilibrate");
                            }
                            catch
                            {
                                throw new Exception("No se pudo enviar el correo a los contactos, verifique la información del correo destinatario y que la cuenta se encuentre activa");
                            }
                            //bool Enviado = this.DirectEmail(MailNotifica, dProyecto);
                            //if (Enviado)
                            //{
                            //    MailNotifica.EstadoEnvio = "ENVIADO";
                            //    MailNotifica.FechaEnvio = DateTime.Now;
                            //}
                        }

                        //Cambiar estado al proyecto
                        Ekilibrate.ad.Administrador.clsProyecto objProyecto = new Ekilibrate.ad.Administrador.clsProyecto(_lifetimeScope);
                        data.Estado = Ekilibrate.Model.Constantes.Administrador.Proyecto.Estado.CreacionParticipantes;
                        await objProyecto.Update(data);
                    }
                    else
                        throw new FaultException("El proyecto no cuenta con ningún contacto aún, no se puede cambiar el estado del proyecto.");
                }
                else
                    throw new FaultException("El estado actual del proyecto no permite la acción solicitada, revise la configuración y estado del proyecto.");
            }
            else
                throw new FaultException("La información del destinatario de correo es necesaria para el envío de notificaciones al cliente, favor registrar la información y vuelva a intentar la operación.");
            //}
            //else
            //{
            //    if ((data.Estado == Ekilibrate.Model.Constantes.Administrador.Proyecto.Estado.EnRegistro || data.Estado == Ekilibrate.Model.Constantes.Administrador.Proyecto.Estado.Preparacion))
            //    {
            //        //Cambiar estado al proyecto
            //        Ekilibrate.ad.Administrador.clsProyecto objProyecto = new Ekilibrate.ad.Administrador.clsProyecto(_lifetimeScope);
            //        data.Estado = Ekilibrate.Model.Constantes.Administrador.Proyecto.Estado.Preparacion;
            //        await objProyecto.Update(data);
            //    }
            //    else
            //        throw new FaultException("El estado actual del proyecto no permite la acción solicitada, revise la configuración y estado del proyecto.");
            //}
        }

        /// <summary>
        /// Este método cambia el estado del proyecto y notifica al cliente que puede cargar los participantes
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public async Task PruebaCorreoInvitacion1(int ProyectoId)
        {
            Ekilibrate.BL.DataRetriever.clsProyecto drProyecto = new Ekilibrate.BL.DataRetriever.clsProyecto(_lifetimeScope);
            Ekilibrate.Model.Entity.Administrador.clsProyecto data = await drProyecto.GetProyecto(ProyectoId);
                        
            if (data.Correo != null && data.PasswordCorreo != null)
            {
                //Notificar a los contactos del proyecto que carguen los participantes
                Ekilibrate.BL.DataRetriever.Administrador.clsProyectoContacto objContacto = new Ekilibrate.BL.DataRetriever.Administrador.clsProyectoContacto(_lifetimeScope);
                IEnumerable<Ekilibrate.Model.Entity.Administrador.clsContactoProyecto> dContacto = await objContacto.GetContacto(ProyectoId);

                if (dContacto.Count() > 0)
                {
                    foreach (var item in dContacto)
                    {
                        //Crear Usuarios
                        //Crear Participante
                        Ekilibrate.ad.Administracion.clsUsuario objUsuario = new Ekilibrate.ad.Administracion.clsUsuario(_lifetimeScope);
                        Ekilibrate.Model.Entity.Administracion.clsUsuarioBase dUsuario = await objUsuario.GetUsuarioByPersona(item.PersonaId);
                        string Mensaje = string.Empty;
                        
                        Ekilibrate.BL.Common.clsMail ctrlMail = new Ekilibrate.BL.Common.clsMail(_lifetimeScope);
                        Ekilibrate.Model.Entity.General.clsMensajeCorreo MailNotifica = new Model.Entity.General.clsMensajeCorreo();
                        MailNotifica.Para = item.Correo;
                        MailNotifica.Asunto = "Prueba de correo de invitación";
                        MailNotifica.Mensaje = String.Format(Ekilibrate.Model.Constantes.Correo.HTMLCorreoRegistroRayovac, item.PrimerNombre + " " + item.PrimerApellido, dUsuario.NombreUsuario, BarcoSoftUtilidades.Utilidades.Cryptography.Decrypt(dUsuario.Contraseña), data.Nombre);
                        MailNotifica.EsHTML = "SI";
                        MailNotifica.EsLista = "NO";

                        try
                        {
                            await ctrlMail.DirectEmail(MailNotifica, data.Correo, data.PasswordCorreo, "Ekilibrate");
                        }
                        catch
                        {
                            throw new Exception("No se pudo enviar el correo a los contactos, verifique la información del correo destinatario y que la cuenta se encuentre activa");
                        }
                    }
                }
                else
                    throw new FaultException("El proyecto no cuenta con ningún contacto aún, no se puede cambiar el estado del proyecto.");
                
            }
            else
                throw new FaultException("La información del destinatario de correo es necesaria para el envío de notificaciones al cliente, favor registrar la información y vuelva a intentar la operación.");
            //}
            //else
            //{
            //    if ((data.Estado == Ekilibrate.Model.Constantes.Administrador.Proyecto.Estado.EnRegistro || data.Estado == Ekilibrate.Model.Constantes.Administrador.Proyecto.Estado.Preparacion))
            //    {
            //        //Cambiar estado al proyecto
            //        Ekilibrate.ad.Administrador.clsProyecto objProyecto = new Ekilibrate.ad.Administrador.clsProyecto(_lifetimeScope);
            //        data.Estado = Ekilibrate.Model.Constantes.Administrador.Proyecto.Estado.Preparacion;
            //        await objProyecto.Update(data);
            //    }
            //    else
            //        throw new FaultException("El estado actual del proyecto no permite la acción solicitada, revise la configuración y estado del proyecto.");
            //}
        }

        /// <summary>
        /// Este método cambia el estado del proyecto y notifica al cliente que puede cargar los participantes
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public async Task CorreoNutricionistaCompa(int ProyectoId)
        //public async Task EnviarCorreoInformacion(int ProyectoId)
        {
            Ekilibrate.BL.DataRetriever.clsProyecto drProyecto = new Ekilibrate.BL.DataRetriever.clsProyecto(_lifetimeScope);
            Ekilibrate.Model.Entity.Administrador.clsProyecto data = await drProyecto.GetProyecto(ProyectoId);

            if (data.Correo != null && data.PasswordCorreo != null)
            {
                //2. Obtener Participantes
                Ekilibrate.BL.DataRetriever.Participante.clsParticipante drParticipante = new Ekilibrate.BL.DataRetriever.Participante.clsParticipante(_lifetimeScope);
                IEnumerable<Ekilibrate.Model.Entity.Participante.clsParticipante> dParticipantes = await drParticipante.GetParticipantes(data.Id);

                string Asunto = "NUTRITIONIST and COMPA";

                //Enviar correo directo
                Ekilibrate.BL.Common.clsMail ctrlMail = new Ekilibrate.BL.Common.clsMail(_lifetimeScope);
                
                //Enviar Correos de invitación
                foreach (var item in dParticipantes)
                {
                    //Ekilibrate.ad.Administracion.clsUsuario objUsuario = new Ekilibrate.ad.Administracion.clsUsuario(_lifetimeScope);
                    //Ekilibrate.Model.Entity.Administracion.clsUsuarioBase dUsuario = await objUsuario.GetUsuarioByPersona(item.Id);

                    string Mensaje = String.Format(Ekilibrate.Model.Constantes.Correo.HTMLCorreoNutricionistaCompa, item.PrimerNombre, item.NutricionistaNombre, item.CompaNombre);

                    //await ctrlMail.DirectEmail(new Model.Entity.General.clsMensajeCorreo(Asunto, Mensaje, "SI", "karinbarquero@ekilibrate.com"), data.Correo, data.PasswordCorreo, "Xoom Health & Wellness");
                    //await ctrlMail.DirectEmail(new Model.Entity.General.clsMensajeCorreo(Asunto, Mensaje, "SI", "jantbarco@gmail.com"), data.Correo, data.PasswordCorreo, "Xoom Health & Wellness");

                    //break;

                    //Enviar correo directo
                    Ekilibrate.Model.Entity.General.clsMensajeCorreo MailNotifica = new Model.Entity.General.clsMensajeCorreo(Asunto, Mensaje, "SI", item.Correo);
                    await ctrlMail.DirectEmail(MailNotifica, data.Correo, data.PasswordCorreo, "Xoom Health & Wellness");
                }
            }
            else
                throw new FaultException("La información del destinatario de correo es necesaria para el envío de notificaciones al cliente, favor registrar la información y vuelva a intentar la operación.");
        }

        /// <summary>
        /// Este método cambia el estado del proyecto y notifica al cliente que puede cargar los participantes
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public async Task CorreoDiagnosticoFinal(int ProyectoId)
        //public async Task EnviarCorreoInformacion(int ProyectoId)
        {
            Ekilibrate.BL.DataRetriever.clsProyecto drProyecto = new Ekilibrate.BL.DataRetriever.clsProyecto(_lifetimeScope);
            Ekilibrate.Model.Entity.Administrador.clsProyecto data = await drProyecto.GetProyecto(ProyectoId);

            if (data.Correo != null && data.PasswordCorreo != null)
            {
                //2. Obtener Participantes
                Ekilibrate.BL.DataRetriever.Participante.clsParticipante drParticipante = new Ekilibrate.BL.DataRetriever.Participante.clsParticipante(_lifetimeScope);
                IEnumerable<Ekilibrate.Model.Entity.Participante.clsParticipante> dParticipantes = await drParticipante.GetParticipantes(data.Id);

                string Asunto = "Congratulations you made it!";

                //Enviar correo directo
                Ekilibrate.BL.Common.clsMail ctrlMail = new Ekilibrate.BL.Common.clsMail(_lifetimeScope);

                //Enviar Correos de invitación
                foreach (var item in dParticipantes)
                {
                    //Ekilibrate.ad.Administracion.clsUsuario objUsuario = new Ekilibrate.ad.Administracion.clsUsuario(_lifetimeScope);
                    //Ekilibrate.Model.Entity.Administracion.clsUsuarioBase dUsuario = await objUsuario.GetUsuarioByPersona(item.Id);

                    string Mensaje = String.Format(Ekilibrate.Model.Constantes.Correo.HTMLCorreoDiagnosticoFinal, item.PrimerNombre, item.FechaBxFinal.ToString("dd-MMM hh:mm tt"), item.FechaDiagnosticoFinal.ToString("dd-MMM hh:mm tt"));

                    //await ctrlMail.DirectEmail(new Model.Entity.General.clsMensajeCorreo(Asunto, Mensaje, "SI", "karinbarquero@ekilibrate.com"), data.Correo, data.PasswordCorreo, "Xoom Health & Wellness");
                    //await ctrlMail.DirectEmail(new Model.Entity.General.clsMensajeCorreo(Asunto, Mensaje, "SI", "jantbarco@gmail.com"), data.Correo, data.PasswordCorreo, "Xoom Health & Wellness");

                    //break;

                    //Enviar correo directo
                    Ekilibrate.Model.Entity.General.clsMensajeCorreo MailNotifica = new Model.Entity.General.clsMensajeCorreo(Asunto, Mensaje, "SI", item.Correo);
                    await ctrlMail.DirectEmail(MailNotifica, data.Correo, data.PasswordCorreo, "Xoom Health & Wellness");

                    MailNotifica.Asunto = "BIO-MEDICAL EVALUATION";
                    await ctrlMail.SendAsAppointment(MailNotifica, data.Correo, data.PasswordCorreo, "Xoom Health & Wellness", "Cafeteria Xoom", item.FechaBxFinal, item.FechaBxFinal.AddMinutes(10));
                    MailNotifica.Asunto = "NUTRITIONAL EVALUATION";
                    await ctrlMail.SendAsAppointment(MailNotifica, data.Correo, data.PasswordCorreo, "Xoom Health & Wellness", "Cafeteria Xoom", item.FechaDiagnosticoFinal, item.FechaDiagnosticoFinal.AddMinutes(15));
                }
            }
            else
                throw new FaultException("La información del destinatario de correo es necesaria para el envío de notificaciones al cliente, favor registrar la información y vuelva a intentar la operación.");
        }

        /// <summary>
        /// Este método cambia el estado del proyecto y notifica al cliente que puede cargar los participantes
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public async Task PruebaCorreoInvitacion(int ProyectoId)
        //public async Task EnviarCorreoInformacion(int ProyectoId)
        {
            Ekilibrate.BL.DataRetriever.clsProyecto drProyecto = new Ekilibrate.BL.DataRetriever.clsProyecto(_lifetimeScope);
            Ekilibrate.Model.Entity.Administrador.clsProyecto data = await drProyecto.GetProyecto(ProyectoId);

            if (data.Correo != null && data.PasswordCorreo != null)
            {
                //2. Obtener Participantes
                Ekilibrate.BL.DataRetriever.Participante.clsParticipante drParticipante = new Ekilibrate.BL.DataRetriever.Participante.clsParticipante(_lifetimeScope);
                IEnumerable<Ekilibrate.Model.Entity.Participante.clsAvanceCuestionario> dParticipantes = await drParticipante.GetParticipantesRecordatorio(data.Id);

                string Asunto = "LAST CHANCE TO COMPLETE ONLINE LIFESTYLE EVALUATION";
                
                //Enviar correo directo
                Ekilibrate.BL.Common.clsMail ctrlMail = new Ekilibrate.BL.Common.clsMail(_lifetimeScope);
                
                //await ctrlMail.DirectEmail(new Model.Entity.General.clsMensajeCorreo(Asunto, HTMLCorreoRecordatorioRayovac, "SI", "karinbarquero@ekilibrate.com"), data.Correo, data.PasswordCorreo, "Xoom Health & Wellness");
                //await ctrlMail.DirectEmail(new Model.Entity.General.clsMensajeCorreo(Asunto, HTMLCorreoRecordatorioRayovac, "SI", "jantbarco@gmail.com"), data.Correo, data.PasswordCorreo, "Xoom Health & Wellness");

                //Enviar Correos de invitación
                foreach (var item in dParticipantes)
                {
                    //Ekilibrate.ad.Administracion.clsUsuario objUsuario = new Ekilibrate.ad.Administracion.clsUsuario(_lifetimeScope);
                    //Ekilibrate.Model.Entity.Administracion.clsUsuarioBase dUsuario = await objUsuario.GetUsuarioByPersona(item.Id);

                    string Mensaje = String.Format(Ekilibrate.Model.Constantes.Correo.HTMLCorreoRecordatorioRayovac, item.PrimerNombre, item.Porcentaje);

                    //await ctrlMail.DirectEmail(new Model.Entity.General.clsMensajeCorreo(Asunto, Mensaje, "SI", "karinbarquero@ekilibrate.com"), data.Correo, data.PasswordCorreo, "Xoom Health & Wellness");
                    //await ctrlMail.DirectEmail(new Model.Entity.General.clsMensajeCorreo(Asunto, Mensaje, "SI", "jantbarco@gmail.com"), data.Correo, data.PasswordCorreo, "Xoom Health & Wellness");

                    //break;
                    
                    //Enviar correo directo
                    Ekilibrate.Model.Entity.General.clsMensajeCorreo MailNotifica = new Model.Entity.General.clsMensajeCorreo(Asunto, Mensaje, "SI", item.Correo);
                    await ctrlMail.DirectEmail(MailNotifica, data.Correo, data.PasswordCorreo, "Xoom Health & Wellness");
                }
            }
            else
                throw new FaultException("La información del destinatario de correo es necesaria para el envío de notificaciones al cliente, favor registrar la información y vuelva a intentar la operación.");
        }

        /// <summary>
        /// Este método cambia el estado del proyecto y notifica al cliente que puede cargar los participantes
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public async Task SendNotifications()
        {
            try
            { 
                int Pasos = 0;
                int Citas = 0;
                DateTime HoraInicio = DateTime.Now;
                //1. Pasos
                if (DateTime.Now.DayOfWeek == DayOfWeek.Monday)
                    Pasos = await EnviarCorreoAutomatico(Ekilibrate.Model.Constantes.Correo.TipoMensaje.RecordatorioPasos);

                //2. Recordatorio de Citas
                if (DateTime.Now.DayOfWeek == DayOfWeek.Friday
                    || DateTime.Now.DayOfWeek == DayOfWeek.Monday
                    || DateTime.Now.DayOfWeek == DayOfWeek.Tuesday)
                    Citas = await EnviarCorreoAutomatico(Ekilibrate.Model.Constantes.Correo.TipoMensaje.RecordatorioCita);

                DateTime HoraFin = DateTime.Now;
                string Mensaje = @"<body><p>Ejecución finalizada sin errores.<p>" + 
                    "<br />(<b>" + Pasos + "</b>) recordatorios de pasos enviados." +
                    "<br />(<b>" + Citas + "</b>) recordatorios de citas enviados." +
                    "<br />Hora inicio: <b>" + HoraInicio + "</b>" +
                    "<br />Hora fin: <b>" + HoraFin + "</b></body>";

                Ekilibrate.BL.Common.clsMail ctrlMail = new Ekilibrate.BL.Common.clsMail(_lifetimeScope);
                await ctrlMail.DirectEmail(new Model.Entity.General.clsMensajeCorreo("Resumen de Ejecución Automática", Mensaje, "SI", "jantbarco@gmail.com"), "xoomwellness@ekilibrate.com", "Esdevisa", "xoomwellness");
            }
            catch(Exception e)
            {
                Ekilibrate.BL.Common.clsMail ctrlMail = new Ekilibrate.BL.Common.clsMail(_lifetimeScope);
                await ctrlMail.DirectEmail(new Model.Entity.General.clsMensajeCorreo("Ejecución Fallida", e.Message, "SI", "jantbarco@gmail.com"), "xoomwellness@ekilibrate.com", "Esdevisa", "xoomwellness");
            }
        }

        /// <summary>
        /// Este método cambia el estado del proyecto y notifica al cliente que puede cargar los participantes
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public async Task TestCorreoAutomatico()
        //public async Task EnviarCorreoInformacion(int ProyectoId)
        {
            Ekilibrate.BL.Common.clsMail ctrlMail = new Ekilibrate.BL.Common.clsMail(_lifetimeScope);
            await ctrlMail.DirectEmail(new Model.Entity.General.clsMensajeCorreo("Prueba", "Test", "SI", "jantbarco@gmail.com"), "xoomwellness@ekilibrate.com", "Esdevisa", "xoomwellness");
        }

        /// <summary>
        /// Este método cambia el estado del proyecto y notifica al cliente que puede cargar los participantes
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public async Task<int> EnviarCorreoAutomatico(Ekilibrate.Model.Constantes.Correo.TipoMensaje Tm)
        //public async Task EnviarCorreoInformacion(int ProyectoId)
        {
            string MensajeHtml = string.Empty;
            string Asunto = string.Empty;
            int Enviado = 0;

            try
            { 
                Ekilibrate.BL.DataRetriever.clsProyecto drProyecto = new Ekilibrate.BL.DataRetriever.clsProyecto(_lifetimeScope);
                IEnumerable<Ekilibrate.Model.Entity.Administrador.clsProyecto> ListadoProyecto = await drProyecto.GetProyectosxEstado(Ekilibrate.Model.Constantes.Administrador.Proyecto.Estado.EnEjecucion);

                if (ListadoProyecto != null && ListadoProyecto.Count() > 0)
                { 
                    foreach(var data in ListadoProyecto)
                    { 
                        if (data.Correo != null && data.PasswordCorreo != null)
                        {
                            //2. Obtener Participantes
                            Ekilibrate.BL.DataRetriever.Participante.clsParticipante drParticipante = new Ekilibrate.BL.DataRetriever.Participante.clsParticipante(_lifetimeScope);
                            IEnumerable<Ekilibrate.Model.Entity.Participante.clsParticipante> dParticipantes;

                            switch (Tm)
                            {
                                case Ekilibrate.Model.Constantes.Correo.TipoMensaje.RecordatorioPasos:
                                    dParticipantes = await drParticipante.GetParticipantes(data.Id);
                                    break;
                                case Ekilibrate.Model.Constantes.Correo.TipoMensaje.RecordatorioCita:
                                    dParticipantes = await drParticipante.GetParticipantesRecordatorioCita(data.Id);
                                    break;
                                default:
                                    dParticipantes = await drParticipante.GetParticipantes(data.Id);
                                    break;
                            }

                            //Enviar correo directo
                            Ekilibrate.BL.Common.clsMail ctrlMail = new Ekilibrate.BL.Common.clsMail(_lifetimeScope);

                            //Enviar Correos de invitación
                            foreach (var item in dParticipantes)
                            {
                                switch (Tm)
                                {
                                    case Ekilibrate.Model.Constantes.Correo.TipoMensaje.RecordatorioPasos:
                                        MensajeHtml = string.Format(Ekilibrate.Model.Constantes.Correo.HTMLCorreoRecordatorioPasos, item.PrimerNombre);
                                        Asunto = "Monday is MANPO KEI day!";
                                        break;
                                    case Ekilibrate.Model.Constantes.Correo.TipoMensaje.RecordatorioCita:
                                        TimeSpan Hora = (TimeSpan)item.CitaHora;
                                        MensajeHtml = string.Format(Ekilibrate.Model.Constantes.Correo.HTMLCorreoRecordatorioCita, item.PrimerNombre, item.PrimeraCita.DayOfWeek, Hora.ToString(@"hh\:mm"));
                                        Asunto = item.PrimeraCita.DayOfWeek + " -" + ToEnOrdinal(item.CitaNo) + " Appointment  for nutritional control-";
                                        break;
                                    default:
                                        dParticipantes = await drParticipante.GetParticipantes(data.Id);
                                        break;
                                }

                                await ctrlMail.DirectEmail(new Model.Entity.General.clsMensajeCorreo(Asunto, MensajeHtml, "SI", item.Correo), data.Correo, data.PasswordCorreo, data.Nombre);
                                Enviado++;
                            }
                        }
                    }
                }
                return Enviado;
            }
            catch (Exception e)
            {
                throw new Exception("Error al enviar pasos. " + System.Environment.NewLine + "Detalle: " + e.Message + System.Environment.NewLine + "Trace: " + e.StackTrace);
            }
        }

        public static string ToEnOrdinal(int num)
        {
            if (num <= 0) return num.ToString();

            switch (num % 100)
            {
                case 11:
                case 12:
                case 13:
                    return num + "th";
            }

            switch (num % 10)
            {
                case 1:
                    return num + "st";
                case 2:
                    return num + "nd";
                case 3:
                    return num + "rd";
                default:
                    return num + "th";
            }
        }


        /// <summary>
        /// Este método cambia el estado del proyecto y finaliza la carga los participantes
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public async Task FinalizarCargaParticipantes(int ProyectoId)
        {
            Ekilibrate.BL.DataRetriever.clsProyecto drProyecto = new Ekilibrate.BL.DataRetriever.clsProyecto(_lifetimeScope);
            Ekilibrate.Model.Entity.Administrador.clsProyecto data = await drProyecto.GetProyecto(ProyectoId);

            if (data.Estado == Ekilibrate.Model.Constantes.Administrador.Proyecto.Estado.CreacionParticipantes)
            {
                //Cambiar estado al proyecto
                Ekilibrate.ad.Administrador.clsProyecto objProyecto = new Ekilibrate.ad.Administrador.clsProyecto(_lifetimeScope);
                data.Estado = Ekilibrate.Model.Constantes.Administrador.Proyecto.Estado.Preparacion;
                await objProyecto.Update(data);
            }
            else
                throw new FaultException("El estado actual del proyecto no permite la acción solicitada.");
        }
                
        /// <summary>
        /// Este método cambia el estado del proyecto y configura el proyecto para su inicio
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public async Task IniciarProyecto(int ProyectoId)
        {
            //1. Revisar y cambiar estado
            Ekilibrate.BL.DataRetriever.clsProyecto drProyecto = new Ekilibrate.BL.DataRetriever.clsProyecto(_lifetimeScope);
            Ekilibrate.Model.Entity.Administrador.clsProyecto data = await drProyecto.GetProyecto(ProyectoId);

            if (data.Estado == Ekilibrate.Model.Constantes.Administrador.Proyecto.Estado.Preparacion)
            {
                //Cambiar estado al proyecto
                Ekilibrate.ad.Administrador.clsProyecto objProyecto = new Ekilibrate.ad.Administrador.clsProyecto(_lifetimeScope);
                data.Estado = Ekilibrate.Model.Constantes.Administrador.Proyecto.Estado.EnEjecucion;
                await objProyecto.Update(data);
            }
            else
                throw new FaultException("El estado actual del proyecto no permite la acción solicitada.");

            //2. Crear usuarios y diagnósticos
            Ekilibrate.BL.DataRetriever.Participante.clsParticipante drParticipante = new Ekilibrate.BL.DataRetriever.Participante.clsParticipante(_lifetimeScope);
            IEnumerable<Ekilibrate.Model.Entity.Participante.clsParticipante> dParticipantes = await drParticipante.GetParticipantes(data.Id);

            
            if (data.CrearUsuarios)                
                await CrearUsuarios(data, dParticipantes);
            
            //3. Cargar información de acuerdo a la configuración del proyecto
            Ekilibrate.BL.DataRetriever.Administrador.clsProyectoArea drAreas = new DataRetriever.Administrador.clsProyectoArea(_lifetimeScope);
            var Areas = await drAreas.GetProyectoArea(ProyectoId);
            bool ProgramaTalleres = false;
            bool TiemposCreados = false;

            foreach (var Area in Areas)
            {
                if (Area.Seleccionado)
                { 
                    switch (Area.AreaId)
                    {
                        case 1: //Evaluación del estilo de vida (cuestionarios)
                            break;
                        case 2: //Evaluación clínica (pruebas de laboratorio)

                            break;
                        case 3: //Evaluación nutricional (evaluación corta de la nutricionista)
                            break;
                        case 4: //Diagnóstico nutricional (evaluación larga de la nutricionista - consulta)
                            //await CrearCitasDiagnostico(data, dParticipantes);
                            //if (!TiemposCreados)
                            //{
                            //    await CrearTiempos(data);
                            //    TiemposCreados = true;
                            //}
                            break;
                        case 5: //Seguimiento nutricional                            
                            await CrearCitasSeguimiento(data, dParticipantes);
                            //if (!TiemposCreados)
                            //{
                            //    await CrearTiempos(data);
                            //    TiemposCreados = true;
                            //}
                            break;
                        case 6: //Programa Manpo Kei (10,000 Pasos)
                            break;
                        case 7: //Talleres Salud
                            ProgramaTalleres = true;
                            break;                      
                        case 8: //Talleres Emociones
                            ProgramaTalleres = true;
                            break;
                        case 9: //Talleres Relaciones Interpersonales
                            ProgramaTalleres = true;
                            break;
                        case 10: //Talleres Relaciones Interpersonales
                            ProgramaTalleres = true;
                            break;
                    }
                }
            }

            //4. Crear Programación de talleres
            if (ProgramaTalleres)
                await CrearProgramacionTaller(data);

            //5. Enviar Invitación
            //await EnviarInvitaciones(data, dParticipantes);
        }

        private async Task CrearDiagnostico(Ekilibrate.Model.Entity.Participante.clsParticipante item)
        {
            Ekilibrate.BL.ad.Participante.clsDiagnostico objDiagnostico = new Ekilibrate.BL.ad.Participante.clsDiagnostico(_lifetimeScope);
            Ekilibrate.Model.Entity.Participante.clsDiagnosticoBase dDiagnostico = await objDiagnostico.GetOne(item.Id);
            if (dDiagnostico == null)
            {
                dDiagnostico = new Model.Entity.Participante.clsDiagnosticoBase();
                dDiagnostico.ID_PARTICIPANTE = item.Id;
                dDiagnostico.PrimerNombre = item.PrimerNombre;
                dDiagnostico.SegundoNombre = item.SegundoNombre;
                dDiagnostico.PrimerApellido = item.PrimerApellido;
                dDiagnostico.SegundoApellido = item.SegundoApellido;
                dDiagnostico.Correo = item.Correo;
                await objDiagnostico.Insert(dDiagnostico);
            }
        }

        private async Task CrearUsuarios(Ekilibrate.Model.Entity.Administrador.clsProyecto dProyecto,
                                        IEnumerable<Ekilibrate.Model.Entity.Participante.clsParticipante> dParticipantes)
        {
            Ekilibrate.ad.Administracion.clsUsuario objUsuario = new Ekilibrate.ad.Administracion.clsUsuario(_lifetimeScope);
            Ekilibrate.ad.Administracion.clsUsuarioPorRol objUsuarioRol = new Ekilibrate.ad.Administracion.clsUsuarioPorRol(_lifetimeScope);

            foreach (var item in dParticipantes)
            {
                //Insertar Usuario
                Ekilibrate.Model.Entity.Administracion.clsUsuarioBase dUsuario = await objUsuario.GetUsuarioByPersona(item.Id);
                Ekilibrate.Model.Entity.Administracion.clsUsuarioPorRolBase dUsuarioRol = new Model.Entity.Administracion.clsUsuarioPorRolBase();
                int IdUsuario = 0;
                string nuevaContraseña = "(Enviada anteriormente)";
                if (dUsuario.IdUsuario == 0)
                {
                    dUsuario = new Model.Entity.Administracion.clsUsuarioBase();
                    string Usuario = await objUsuario.GetUserKey(item.Correo, dProyecto.EmpresaNombre, item.PrimerNombre, item.PrimerApellido);

                    dUsuario.IdPersona = item.Id;
                    dUsuario.NombreUsuario = Usuario;
                    dUsuario.IdTipoUsuario = Ekilibrate.Model.Constantes.Administracion.TipoUsuario.Participante;
                    //Grabrar el usuario encriptado como contraseña de usuario
                    nuevaContraseña = BarcoSoftUtilidades.Utilidades.Cryptography.Encrypt(DateTime.Now.Millisecond.ToString() + dUsuario.NombreUsuario);
                    dUsuario.Contraseña = BarcoSoftUtilidades.Utilidades.Cryptography.Encrypt(nuevaContraseña);
                    IdUsuario = await objUsuario.Insert(dUsuario);

                    //Insertar UsuarioPorRol
                    dUsuarioRol.IdUsuario = IdUsuario;
                    dUsuarioRol.IdRol = Ekilibrate.Model.Constantes.Administracion.Rol.Participante;
                    dUsuarioRol.TransacDateTime = DateTime.Now;
                    dUsuarioRol.TransacUser = tranuser;
                    await objUsuarioRol.Insert(dUsuarioRol);
                }
                else
                {
                    IdUsuario = dUsuario.IdUsuario;

                    if (dUsuario.IdTipoUsuario == Ekilibrate.Model.Constantes.Administracion.TipoUsuario.Cliente)
                    {
                        dUsuario.IdTipoUsuario = Ekilibrate.Model.Constantes.Administracion.TipoUsuario.ClienteParticipante;
                        await objUsuario.Update(dUsuario);

                        //Insertar UsuarioPorRol
                        dUsuarioRol.IdUsuario = IdUsuario;
                        dUsuarioRol.IdRol = Ekilibrate.Model.Constantes.Administracion.Rol.Participante;
                        dUsuarioRol.TransacDateTime = DateTime.Now;
                        dUsuarioRol.TransacUser = tranuser;
                        await objUsuarioRol.Insert(dUsuarioRol);
                    }
                }
            }
        }        

        private async Task EnviarInvitaciones(Ekilibrate.Model.Entity.Administrador.clsProyecto data, 
                                              IEnumerable<Ekilibrate.Model.Entity.Participante.clsParticipante> dParticipantes)
        {
            //Enviar Correos de invitación
            foreach (var item in dParticipantes)
            {
                Ekilibrate.ad.Administracion.clsUsuario objUsuario = new Ekilibrate.ad.Administracion.clsUsuario(_lifetimeScope);
                Ekilibrate.Model.Entity.Administracion.clsUsuarioBase dUsuario = await objUsuario.GetUsuarioByPersona(item.Id);
                            
                Ekilibrate.Model.Entity.General.clsMensajeCorreo MailNotifica = new Model.Entity.General.clsMensajeCorreo();
                MailNotifica.Para = item.Correo;
                MailNotifica.EsHTML = "SI";
                MailNotifica.EsLista = "NO";
                MailNotifica.Asunto = "Bienvenido a Ekilibrate";
                MailNotifica.Mensaje = String.Format(Ekilibrate.Model.Constantes.Correo.HTMLCorreoRegistroRayovac, item.PrimerNombre + " " + item.PrimerApellido, dUsuario.NombreUsuario, BarcoSoftUtilidades.Utilidades.Cryptography.Decrypt(dUsuario.Contraseña), data.Nombre);
                //await objCorreo.Insert(MailNotifica);

                DateTime fechaCorreo = data.FechaCorreoInvitacion.AddHours(data.HoraInicioConsultas.Value.Hours).AddMinutes(data.HoraInicioConsultas.Value.Minutes);
                if (fechaCorreo.DayOfWeek == DayOfWeek.Sunday)
                    fechaCorreo = fechaCorreo.AddDays(-2);

                if (fechaCorreo <= DateTime.Now)
                {
                    //Enviar correo directo
                    Ekilibrate.BL.Common.clsMail ctrlMail = new Ekilibrate.BL.Common.clsMail(_lifetimeScope);
                    await ctrlMail.DirectEmail(MailNotifica, data.Correo, data.PasswordCorreo, "Ekilibrate");
                }
                else
                {
                    //Programar envío del correo 24 hora antes del inicio de la jornada de citas
                    Ekilibrate.ad.General.clsMensajeCorreo objCorreo = new Ekilibrate.ad.General.clsMensajeCorreo(_lifetimeScope);
                    MailNotifica.FechaEnvio = fechaCorreo;
                    await objCorreo.Insert(MailNotifica);
                }
            }
        }

        private async Task CrearTiempos(Ekilibrate.Model.Entity.Administrador.clsProyecto data)
        {
            //-----Semanas
            Ekilibrate.ad.Administrador.clsSemana objSemana = new Ekilibrate.ad.Administrador.clsSemana(_lifetimeScope);

            int DeltaFrecuencia = 1;
            switch (data.FrecuenciaConsultasUnidad)
            { 
                case 1:
                    DeltaFrecuencia = data.FrecuenciaConsultas / 7;
                break;
                case 2:
                    DeltaFrecuencia = data.FrecuenciaConsultas * 1;
                    break;
                case 3:
                    DeltaFrecuencia = data.FrecuenciaConsultas * 4;
                break;
            }

            int semanas = (data.NoConsultasNutricionales) * DeltaFrecuencia;
            for (int i = 1; i <= semanas; i++)
            {
                int deltaMonday = Convert.ToInt32(DayOfWeek.Monday - data.FechaInicioConsultas.DayOfWeek);
                DateTime monday = data.FechaInicioConsultas.AddDays(deltaMonday);
                DateTime sunday = monday.AddDays(6);

                Ekilibrate.Model.Entity.Administrador.clsSemana dSemana = new Model.Entity.Administrador.clsSemana();
                dSemana.ProyectoId = data.Id;
                dSemana.Semana = i;
                dSemana.FechaInicio = monday;
                dSemana.FechaFin = sunday;
                dSemana.Nombre = "Semana " + i.ToString();

                await objSemana.Insert(dSemana);
            }
        }

        private async Task CrearCitasDiagnostico(Ekilibrate.Model.Entity.Administrador.clsProyecto data, 
                                                 IEnumerable<Ekilibrate.Model.Entity.Participante.clsParticipante> dParticipantes)
        {
            

            if (data.FechaPrimeraCitaDiagnostico == null)
                throw new FaultException("El parámetro de la fecha del primer diagnóstico no puede estar vacío, debes colocar una fecha para el inicio del diagnóstico");

            if (data.FechaPrimeraCitaDiagnostico < DateTime.Now)
                throw new FaultException("El parámetro de la fecha del primer diagnóstico ya pasó, debes colocar una fecha posterior al día de hoy.");

            //await ProgramarCiclo(data, dParticipantes, data.FechaPrimeraCitaDiagnostico.Value, data.FechaPrimeraCitaDiagnostico.Value.AddDays(6), 1, 1);
        }

        private async Task ProgramarCiclo(Ekilibrate.Model.Entity.Administrador.clsProyecto data,
                                          Ekilibrate.Model.Entity.Administrador.clsNutricionistaBase Nutri,
                                          IEnumerable<Ekilibrate.Model.Entity.Participante.clsParticipante> dParticipantes, 
                                          int Secuencia, int TipoCita,
                                          int CicloId, int NutricionistaId)
        {
            Ekilibrate.ad.Administrador.clsCita objCita = new Ekilibrate.ad.Administrador.clsCita(_lifetimeScope);
            Ekilibrate.ad.Administrador.clsCitaProgramacion objCitaProgramacion = new Ekilibrate.ad.Administrador.clsCitaProgramacion(_lifetimeScope);

            //La fecha del diagnóstica se encuentra en un parámetro del proyecto
            DateTime FechaCita = Nutri.MaxFecha;
            //Asigna la primera hora de citas, la hora de inicio de consultas parametrizada en el proyecto
            TimeSpan HoraCita = new TimeSpan(Nutri.MaxFecha.Hour, Nutri.MaxFecha.Minute, 0);
            HoraCita = HoraCita.Add(new TimeSpan(data.DuracionConsultas.Value.Hours, data.DuracionConsultas.Value.Minutes, 0));
            int CorPart = 0;

            foreach (var itemPart in dParticipantes)
            {
                //Si es hora de almuerzo sumarle una hora
                if (new TimeSpan(13, 0, 0) == HoraCita)
                    HoraCita = HoraCita.Add(new TimeSpan(1, 0, 0));
                    
                //Si la la hora de la cita supera el límite - 1 hora, se debe asignar para el día siguiente
                if (HoraCita >= data.HoraFinConsultas.Value.Add(new TimeSpan(-1, 0, 0))  )
                {
                    FechaCita = FechaCita.AddDays(1);
                    HoraCita = new TimeSpan(data.HoraInicioConsultas.Value.Hours, data.HoraInicioConsultas.Value.Minutes, 0);
                }

                //Insertar DiagnosticoBase
                //await CrearDiagnostico(itemPart);

                Ekilibrate.Model.Entity.Administrador.clsCita dCita = new Model.Entity.Administrador.clsCita();
                dCita.CicloId = CicloId;
                dCita.ParticipanteId = itemPart.Id;
                dCita.ProyectoId = data.Id;
                dCita.TipoCitaId = TipoCita;
                dCita.FechaProgramada = FechaCita.Add(HoraCita);
                int CitaId = await objCita.Insert(dCita);

                Ekilibrate.Model.Entity.Administrador.clsCitaProgramacion dCitaProgramacion = new Model.Entity.Administrador.clsCitaProgramacion();
                dCitaProgramacion.CitaId = CitaId;
                dCitaProgramacion.NutricionistaId = NutricionistaId;
                dCitaProgramacion.Fecha = FechaCita.Add(HoraCita);
                dCitaProgramacion.Cancelada = false;
                await objCitaProgramacion.Insert(dCitaProgramacion);

                DateTime fechaCorreo = FechaCita.AddDays(-1);

                if (fechaCorreo.DayOfWeek == DayOfWeek.Sunday)
                    fechaCorreo = data.FechaPrimeraCitaDiagnostico.Value.AddDays(-3);

                //if (fechaCorreo > DateTime.Now)
                //{
                //    if (fechaCorreo > DateTime.Now.AddDays(1))
                //    {
                //        //Programar envío del correo 24 hora antes del inicio de la jornada de citas
                //        Ekilibrate.ad.General.clsMensajeCorreo objCorreo = new Ekilibrate.ad.General.clsMensajeCorreo(_lifetimeScope);
                //        Ekilibrate.Model.Entity.General.clsMensajeCorreo MailNotifica = new Model.Entity.General.clsMensajeCorreo();
                //        MailNotifica.Para = itemPart.Correo;
                //        MailNotifica.Asunto = "Ekilibrate - Recordatorio de Cita de Diagnóstico";
                //        MailNotifica.Mensaje = "Tu cita está programada para el: " + data.FechaPrimeraCitaDiagnostico.Value.ToShortDateString() + " a las: " + data.FechaPrimeraCitaDiagnostico.Value.ToShortTimeString();
                //        MailNotifica.EsHTML = "NO";
                //        MailNotifica.EsLista = "NO";
                //        MailNotifica.FechaEnvio = fechaCorreo;
                //        await objCorreo.Insert(MailNotifica);
                //    }
                //    else
                //    {
                //Enviar correo directo
                if (Secuencia == 0)
                {
                    Ekilibrate.BL.Common.clsMail ctrlMail = new Ekilibrate.BL.Common.clsMail(_lifetimeScope);
                    Ekilibrate.Model.Entity.General.clsMensajeCorreo MailNotifica = new Model.Entity.General.clsMensajeCorreo();
                    MailNotifica.Para = itemPart.Correo;
                    MailNotifica.Asunto = "NUTRITIONIST and COMPA";
                    MailNotifica.Mensaje = String.Format(Ekilibrate.Model.Constantes.Correo.HTMLCorreoNutricionistaCompa, itemPart.PrimerNombre, itemPart.NutricionistaNombre, FechaCita.DayOfWeek.ToString(), HoraCita.ToString(), FechaCita.ToShortDateString(), itemPart.CompaNombre);
                    MailNotifica.EsHTML = "SI";
                    MailNotifica.EsLista = "NO";

                    await ctrlMail.DirectEmail(MailNotifica, data.Correo, data.PasswordCorreo, "Xoom Health & Wellness");
                }
            //}
            //}

                HoraCita = HoraCita.Add(new TimeSpan(data.DuracionConsultas.Value.Hours, data.DuracionConsultas.Value.Minutes, 0));
                CorPart++;
            }
        }

        private async Task CrearCitasSeguimiento(Ekilibrate.Model.Entity.Administrador.clsProyecto data, IEnumerable<Ekilibrate.Model.Entity.Participante.clsParticipante> dParticipantes)
        {
            //-------Ciclo de Cita de Diagnóstico
            Ekilibrate.ad.Administrador.clsCiclo objCiclo = new Ekilibrate.ad.Administrador.clsCiclo(_lifetimeScope);
            Ekilibrate.ad.Administrador.clsCita objCita = new Ekilibrate.ad.Administrador.clsCita(_lifetimeScope);
            Ekilibrate.ad.Administrador.clsCitaProgramacion objCitaProgramacion = new Ekilibrate.ad.Administrador.clsCitaProgramacion(_lifetimeScope);
            
            //Ciclos de Citas nutricionales
            int ciclos = (int)data.NoConsultasNutricionales + 1; //el número de las citas nutricionales más el diagnóstico final
            int DeltaFrecuencia = 7;
            int deltaMonday = Convert.ToInt32(DayOfWeek.Monday - data.FechaInicioConsultas.DayOfWeek);
            
            for (int i = 0; i < ciclos; i++)
            {
                DateTime InicioCiclo = data.FechaInicioConsultas.AddDays(deltaMonday);
                DateTime FinCiclo = InicioCiclo.AddDays(DeltaFrecuencia);

                switch (data.FrecuenciaConsultasUnidad)
                {
                    case 1:                        
                        InicioCiclo = InicioCiclo.AddDays(data.FrecuenciaConsultas * i);
                        FinCiclo = InicioCiclo.AddDays(data.FrecuenciaConsultas).AddDays(-1);
                        break;
                    case 2:
                        InicioCiclo = InicioCiclo.AddDays(data.FrecuenciaConsultas * 7 * i);
                        FinCiclo = InicioCiclo.AddDays(data.FrecuenciaConsultas * 7).AddDays(-1);
                        break;
                    case 3:
                        InicioCiclo = InicioCiclo.AddMonths(data.FrecuenciaConsultas * i);
                        FinCiclo = InicioCiclo.AddMonths(data.FrecuenciaConsultas).AddDays(-1);
                        break;
                    default:
                        throw new FaultException("Debe especificar la frecuencia de connsultas.");
                }

                //await ProgramarCiclo(data, dParticipantes, InicioCiclo, FinCiclo, i, 2);
            }
        }

        public async Task AsignarNutricionistas(int ProyectoId)
        {
            try
            { 
                //1. Revisar y cambiar estado
                Ekilibrate.BL.DataRetriever.clsProyecto drProyecto = new Ekilibrate.BL.DataRetriever.clsProyecto(_lifetimeScope);
                Ekilibrate.Model.Entity.Administrador.clsProyecto data = await drProyecto.GetProyecto(ProyectoId);

                //if (data.Estado == Ekilibrate.Model.Constantes.Administrador.Proyecto.Estado.Preparacion)
                //{
                //    //Cambiar estado al proyecto
                //    Ekilibrate.ad.Administrador.clsProyecto objProyecto = new Ekilibrate.ad.Administrador.clsProyecto(_lifetimeScope);
                //    data.Estado = Ekilibrate.Model.Constantes.Administrador.Proyecto.Estado.EnEjecucion;
                //    await objProyecto.Update(data);
                //}
                //else
                //    throw new FaultException("El estado actual del proyecto no permite la acción solicitada.");

                //2. Crear usuarios y diagnósticos
                Ekilibrate.BL.DataRetriever.Participante.clsParticipante drParticipante = new Ekilibrate.BL.DataRetriever.Participante.clsParticipante(_lifetimeScope);
                IEnumerable<Ekilibrate.Model.Entity.Participante.clsParticipante> dParticipantes = await drParticipante.GetParticipantes(data.Id);

                Ekilibrate.ad.Participante.clsParticipante adParticipante = new Ekilibrate.ad.Participante.clsParticipante(_lifetimeScope);
                Ekilibrate.BL.DataRetriever.Administrador.clsNutricionista drNutricionista = new Ekilibrate.BL.DataRetriever.Administrador.clsNutricionista(_lifetimeScope);
                IEnumerable<Ekilibrate.Model.Entity.Administrador.clsNutricionistaBase> dNutricionistas = await drNutricionista.GetNutricionista(data.Id);

                int Capacidad = dParticipantes.Count() / data.NoNutricionistas;
                int CorNut = 0;
            
                foreach (var itemNut in dNutricionistas)
                {
                    var ParticipantesXNutricionista = dParticipantes.Where(x => x.NutricionistaId == itemNut.ColaboradorId).ToList();
                    var ParticipantesSinNutricionista = dParticipantes.Where(x => x.NutricionistaId == 0).ToList();
                    var list = ParticipantesSinNutricionista.Take((Capacidad - ParticipantesXNutricionista.Count));

                    list.ToList().ForEach(async x =>
                        {
                            x.NutricionistaId = itemNut.ColaboradorId;
                            ParticipantesXNutricionista.Add(x);
                            await adParticipante.AsignarNutricionista(x);
                        }
                    );
                
                    CorNut++;
                }
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo asignar nutricionistas. Error:" + e.Message);
            }
        }

        public async Task ProgramarCitasNutricionales(int ProyectoId)
        {
            try
            {
                //1. Revisar y cambiar estado
                Ekilibrate.BL.DataRetriever.clsProyecto drProyecto = new Ekilibrate.BL.DataRetriever.clsProyecto(_lifetimeScope);
                Ekilibrate.Model.Entity.Administrador.clsProyecto data = await drProyecto.GetProyecto(ProyectoId);

                //if (data.Estado == Ekilibrate.Model.Constantes.Administrador.Proyecto.Estado.Preparacion)
                //{
                //    //Cambiar estado al proyecto
                //    Ekilibrate.ad.Administrador.clsProyecto objProyecto = new Ekilibrate.ad.Administrador.clsProyecto(_lifetimeScope);
                //    data.Estado = Ekilibrate.Model.Constantes.Administrador.Proyecto.Estado.EnEjecucion;
                //    await objProyecto.Update(data);
                //}
                //else
                //    throw new FaultException("El estado actual del proyecto no permite la acción solicitada.");

                //2. Cargando participantes
                Ekilibrate.BL.DataRetriever.Participante.clsParticipante drParticipante = new Ekilibrate.BL.DataRetriever.Participante.clsParticipante(_lifetimeScope);
                IEnumerable<Ekilibrate.Model.Entity.Participante.clsParticipante> dParticipantes = await drParticipante.GetParticipantesSinCitas(data.Id);

                //3 Ciclos
                Ekilibrate.ad.Administrador.clsCiclo objCiclo = new Ekilibrate.ad.Administrador.clsCiclo(_lifetimeScope);
                //List<Ekilibrate.Model.Entity.Administrador.clsCiclo> ListadoCiclos = new List<Ekilibrate.Model.Entity.Administrador.clsCiclo>();
                IEnumerable<Ekilibrate.Model.Entity.Administrador.clsCiclo> ListadoCiclos = await objCiclo.GetByProyecto(ProyectoId);
                int ciclos = (int)data.NoConsultasNutricionales + 1; //el número de las citas nutricionales más el diagnóstico final

                if (ListadoCiclos.Count() != ciclos)
                {  
                    int DeltaFrecuencia = 7;
                    int deltaMonday = Convert.ToInt32(DayOfWeek.Monday - data.FechaInicioConsultas.DayOfWeek);

                    for (int i = 0; i < ciclos; i++)
                    {
                        DateTime InicioCiclo = data.FechaInicioConsultas.AddDays(deltaMonday);
                        DateTime FinCiclo = InicioCiclo.AddDays(DeltaFrecuencia);

                        switch (data.FrecuenciaConsultasUnidad)
                        {
                            case 1:
                                InicioCiclo = InicioCiclo.AddDays(data.FrecuenciaConsultas * i);
                                FinCiclo = InicioCiclo.AddDays(data.FrecuenciaConsultas).AddDays(-1);
                                break;
                            case 2:
                                InicioCiclo = InicioCiclo.AddDays(data.FrecuenciaConsultas * 7 * i);
                                FinCiclo = InicioCiclo.AddDays(data.FrecuenciaConsultas * 7).AddDays(-1);
                                break;
                            case 3:
                                InicioCiclo = InicioCiclo.AddMonths(data.FrecuenciaConsultas * i);
                                FinCiclo = InicioCiclo.AddMonths(data.FrecuenciaConsultas).AddDays(-1);
                                break;
                            default:
                                throw new FaultException("Debe especificar la frecuencia de connsultas.");
                        }
                    
                        Ekilibrate.Model.Entity.Administrador.clsCiclo dCiclo = new Model.Entity.Administrador.clsCiclo();
                        dCiclo.ProyectoId = data.Id;
                        dCiclo.No = i + 1;
                        dCiclo.FechaInicio = InicioCiclo;
                        dCiclo.FechaFin = FinCiclo;
                        dCiclo.Finalizado = false;

                        int CicloId = await objCiclo.Insert(dCiclo);
                        dCiclo.Id = CicloId;
                        //ListadoCiclos.Add(dCiclo);
                    }
                }

                Ekilibrate.ad.Participante.clsParticipante adParticipante = new Ekilibrate.ad.Participante.clsParticipante(_lifetimeScope);
                Ekilibrate.BL.DataRetriever.Administrador.clsNutricionista drNutricionista = new Ekilibrate.BL.DataRetriever.Administrador.clsNutricionista(_lifetimeScope);
                IEnumerable<Ekilibrate.Model.Entity.Administrador.clsNutricionistaBase> dNutricionistas = await drNutricionista.GetNutricionista(data.Id);

                int Capacidad = dParticipantes.Count() / data.NoNutricionistas;
                int CorNut = 0;

                foreach (var itemNut in dNutricionistas)
                {
                    var ParticipantesXNutricionista = dParticipantes.Where(x => x.NutricionistaId == itemNut.ColaboradorId).ToList();

                    foreach (var itemCiclo in ListadoCiclos)
                    { 
                        await ProgramarCiclo(data, itemNut, ParticipantesXNutricionista, itemCiclo.No, 2, itemCiclo.Id, itemNut.ColaboradorId);
                    }
                    CorNut++;
                }
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo asignar nutricionistas. Error:" + e.Message);
            }
        }

        private async Task CrearProgramacionTaller(Ekilibrate.Model.Entity.Administrador.clsProyecto data)
        {
            Ekilibrate.BL.DataRetriever.Participante.clsParticipante drParticipante = new Ekilibrate.BL.DataRetriever.Participante.clsParticipante(_lifetimeScope);
            Ekilibrate.ad.Administrador.clsTallerProgramacion adTallerProgramacion = new Ekilibrate.ad.Administrador.clsTallerProgramacion(_lifetimeScope);
            Ekilibrate.ad.Administrador.clsTallerNota adTallerNota = new Ekilibrate.ad.Administrador.clsTallerNota(_lifetimeScope);
            Ekilibrate.BL.DataRetriever.Administrador.clsTallerProyecto drTaller = new Ekilibrate.BL.DataRetriever.Administrador.clsTallerProyecto(_lifetimeScope);
            IEnumerable<Ekilibrate.Model.Entity.Administrador.clsTallerBase> dTaller = await drTaller.GetList(data.Id);

            foreach (var itemTaller in dTaller)
            {
                DateTime FechaTaller = data.FechaInicioConsultas;
                int deltaMonday = Convert.ToInt32(DayOfWeek.Monday - data.FechaInicioConsultas.DayOfWeek);
                DateTime monday = data.FechaInicioConsultas.AddDays(deltaMonday);
                DateTime sunday = monday.AddDays(6);

                //Cargar a los participantes por taller
                IEnumerable<Ekilibrate.Model.Entity.Participante.clsParticipanteBase> dParticipantesGrupo = await drParticipante.GetParticipantesPorGrupo(itemTaller.GrupoId);

                //Crear programacion del taller según los días programados en la parametrización del taller
                int i = 1;
                while (i < itemTaller.NoSesiones)
                {


                    if (itemTaller.Lunes)
                    {
                        Ekilibrate.Model.Entity.Proyecto.clsTallerProgramacion dTallerProgramacion = ProgramarTaller(itemTaller, i, monday);
                        await adTallerProgramacion.Insert(dTallerProgramacion);

                        //Crear Notas por participante                            
                        foreach (var itemPart in dParticipantesGrupo)
                        {
                            Ekilibrate.Model.Entity.Proyecto.clsTallerNota dTallerNota = new Model.Entity.Proyecto.clsTallerNota();
                            dTallerNota.TallerId = itemTaller.Id;
                            dTallerNota.NoSesion = i;
                            dTallerNota.ParticipanteId = itemPart.Id;

                            await adTallerNota.Insert(dTallerNota);
                        }

                        i++;
                    }
                    if (itemTaller.Martes)
                    {
                        Ekilibrate.Model.Entity.Proyecto.clsTallerProgramacion dTallerProgramacion = ProgramarTaller(itemTaller, i, monday.AddDays(1));
                        await adTallerProgramacion.Insert(dTallerProgramacion);

                        //Crear Notas por participante                            
                        foreach (var itemPart in dParticipantesGrupo)
                        {
                            Ekilibrate.Model.Entity.Proyecto.clsTallerNota dTallerNota = new Model.Entity.Proyecto.clsTallerNota();
                            dTallerNota.TallerId = itemTaller.Id;
                            dTallerNota.NoSesion = i;
                            dTallerNota.ParticipanteId = itemPart.Id;

                            await adTallerNota.Insert(dTallerNota);
                        }

                        i++;
                    }
                    if (itemTaller.Miercoles)
                    {
                        Ekilibrate.Model.Entity.Proyecto.clsTallerProgramacion dTallerProgramacion = ProgramarTaller(itemTaller, i, monday.AddDays(2));
                        await adTallerProgramacion.Insert(dTallerProgramacion);

                        //Crear Notas por participante                            
                        foreach (var itemPart in dParticipantesGrupo)
                        {
                            Ekilibrate.Model.Entity.Proyecto.clsTallerNota dTallerNota = new Model.Entity.Proyecto.clsTallerNota();
                            dTallerNota.TallerId = itemTaller.Id;
                            dTallerNota.NoSesion = i;
                            dTallerNota.ParticipanteId = itemPart.Id;

                            await adTallerNota.Insert(dTallerNota);
                        }

                        i++;
                    }
                    if (itemTaller.Jueves)
                    {
                        Ekilibrate.Model.Entity.Proyecto.clsTallerProgramacion dTallerProgramacion = ProgramarTaller(itemTaller, i, monday.AddDays(3));
                        await adTallerProgramacion.Insert(dTallerProgramacion);

                        //Crear Notas por participante                            
                        foreach (var itemPart in dParticipantesGrupo)
                        {
                            Ekilibrate.Model.Entity.Proyecto.clsTallerNota dTallerNota = new Model.Entity.Proyecto.clsTallerNota();
                            dTallerNota.TallerId = itemTaller.Id;
                            dTallerNota.NoSesion = i;
                            dTallerNota.ParticipanteId = itemPart.Id;

                            await adTallerNota.Insert(dTallerNota);
                        }

                        i++;
                    }
                    if (itemTaller.Viernes)
                    {
                        Ekilibrate.Model.Entity.Proyecto.clsTallerProgramacion dTallerProgramacion = ProgramarTaller(itemTaller, i, monday.AddDays(4));
                        await adTallerProgramacion.Insert(dTallerProgramacion);

                        //Crear Notas por participante                            
                        foreach (var itemPart in dParticipantesGrupo)
                        {
                            Ekilibrate.Model.Entity.Proyecto.clsTallerNota dTallerNota = new Model.Entity.Proyecto.clsTallerNota();
                            dTallerNota.TallerId = itemTaller.Id;
                            dTallerNota.NoSesion = i;
                            dTallerNota.ParticipanteId = itemPart.Id;

                            await adTallerNota.Insert(dTallerNota);
                        }

                        i++;
                    }
                    if (itemTaller.Sabado)
                    {
                        Ekilibrate.Model.Entity.Proyecto.clsTallerProgramacion dTallerProgramacion = ProgramarTaller(itemTaller, i, monday.AddDays(5));
                        await adTallerProgramacion.Insert(dTallerProgramacion);

                        //Crear Notas por participante                            
                        foreach (var itemPart in dParticipantesGrupo)
                        {
                            Ekilibrate.Model.Entity.Proyecto.clsTallerNota dTallerNota = new Model.Entity.Proyecto.clsTallerNota();
                            dTallerNota.TallerId = itemTaller.Id;
                            dTallerNota.NoSesion = i;
                            dTallerNota.ParticipanteId = itemPart.Id;

                            await adTallerNota.Insert(dTallerNota);
                        }

                        i++;
                    }
                    if (itemTaller.Domingo)
                    {
                        Ekilibrate.Model.Entity.Proyecto.clsTallerProgramacion dTallerProgramacion = ProgramarTaller(itemTaller, i, monday.AddDays(6));
                        await adTallerProgramacion.Insert(dTallerProgramacion);

                        //Crear Notas por participante                            
                        foreach (var itemPart in dParticipantesGrupo)
                        {
                            Ekilibrate.Model.Entity.Proyecto.clsTallerNota dTallerNota = new Model.Entity.Proyecto.clsTallerNota();
                            dTallerNota.TallerId = itemTaller.Id;
                            dTallerNota.NoSesion = i;
                            dTallerNota.ParticipanteId = itemPart.Id;

                            await adTallerNota.Insert(dTallerNota);
                        }

                        i++;
                    }
                }
            }
        }

        private Ekilibrate.Model.Entity.Proyecto.clsTallerProgramacion ProgramarTaller(Ekilibrate.Model.Entity.Administrador.clsTallerBase itemTaller, int NoSesion, DateTime Fecha)
        {
            Ekilibrate.Model.Entity.Proyecto.clsTallerProgramacion dTallerProgramacion = new Model.Entity.Proyecto.clsTallerProgramacion();
            dTallerProgramacion.TallerId = itemTaller.Id;
            dTallerProgramacion.NoSesion = NoSesion;
            dTallerProgramacion.HoraInicio = Fecha.Add(itemTaller.HoraInicio);
            dTallerProgramacion.HoraFin = Fecha.Add(itemTaller.HoraFin);
            return dTallerProgramacion;
        }

        /// <summary>
        /// Este método cambia el estado del proyecto y Finaliza la carga de participantes
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public async Task FinalizarProyecto(int ProyectoId)
        {
            Ekilibrate.BL.DataRetriever.clsProyecto blProyecto = new Ekilibrate.BL.DataRetriever.clsProyecto(_lifetimeScope);
            Ekilibrate.Model.Entity.Administrador.clsProyecto Data = await blProyecto.GetProyecto(ProyectoId);

            if (Data.Estado == Ekilibrate.Model.Constantes.Administrador.Proyecto.Estado.EnEjecucion)
            {
                //Cambiar estado al proyecto
                Ekilibrate.ad.Administrador.clsProyecto objProyecto = new Ekilibrate.ad.Administrador.clsProyecto(_lifetimeScope);
                Data.Estado = Ekilibrate.Model.Constantes.Administrador.Proyecto.Estado.Finalizado;
                await objProyecto.Update(Data);
            }
            else
            {
                throw new Exception("No se puede cargar participantes en el estado actual del proyecto.");
            }
        }
    }
}

