using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace BarcoSoftUtilidades.Seguridad
{

    public class Persona
    {
        public int IdPersona { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }

        public string Telefono { get; set; }
        public string Email { get; set; }
    }

    public class TipoUsuario
    {
        public int IdTipoUsuario { get; set; }

        public string Nombre { get; set; }
        public string RedirectUrlTipoUsuario { get; set; }
    }

    public class Empresa
    {
        public int IdEmpresa { get; set; }
        public string Nombre { get; set; }
    }

    public class Proyecto
    {
        public int IdProyecto { get; set; }
        public string Color { get; set; }
    }

    public class Nutricionista
    {
        public int idNutricionista { get; set; }
    }


    public class Usuario : Persona
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }

        public TipoUsuario Tipo { get; set; }
        public Empresa Empresa { get; set; }
        public Proyecto Proyecto { get; set; }

        public Nutricionista Nutricionista { get; set; }

        public static Usuario GetUserByName(string pUserName)
        {
            Usuario user = new Usuario();
            Data.BarcoSoftUtilidadesDB db = new Data.BarcoSoftUtilidadesDB(true);
            user = (from u in db.Usuario
                    join par in db.PAR_Participante on u.GE_Persona.Id equals par.Id into gj
                    from par in gj.DefaultIfEmpty()
                    join proy in db.PR_Proyecto on par.ProyectoId equals proy.Id into gj1
                    from proy in gj1.DefaultIfEmpty()
                    join emp in db.ADM_Empresa on proy.EmpresaId equals emp.Id into gj2
                    from emp in gj2.DefaultIfEmpty()
                    join nutri in db.PR_Nutricionista on u.IdPersona equals nutri.ColaboradorId into gj4
                    from nutri in gj4.DefaultIfEmpty()
                    where u.NombreUsuario == pUserName
                    select new Usuario
                    {
                        IdUsuario = u.IdUsuario,
                        Tipo = new TipoUsuario
                        {
                            IdTipoUsuario = u.TipoUsuario.IdTipoUsuario,
                            RedirectUrlTipoUsuario = u.TipoUsuario.UrlRedireccion,
                            Nombre = u.TipoUsuario.Nombre
                        },
                        NombreUsuario = u.NombreUsuario,
                        Apellidos = u.GE_Persona.PrimerApellido,
                        Email = u.GE_Persona.Correo,
                        Nombres = u.GE_Persona.PrimerNombre,
                        Telefono = u.GE_Persona.Telefono,
                        IdPersona = u.GE_Persona.Id,
                        Empresa = emp != null ? new Empresa
                        {
                            IdEmpresa = emp.Id,
                            Nombre = emp.Nombre
                        } : u.GE_Persona.ADM_Contacto.ADM_Empresa != null ? new Empresa
                        {
                            IdEmpresa = u.GE_Persona.ADM_Contacto.ADM_Empresa.Id,
                            Nombre = u.GE_Persona.ADM_Contacto.ADM_Empresa.Nombre
                        } : null,
                        Proyecto = proy != null ? new Proyecto
                        {
                            IdProyecto = proy.Id,
                            Color = proy.Color
                        } : null,
                        Nutricionista = nutri != null ? new Nutricionista
                        {
                            idNutricionista = nutri.ColaboradorId
                        } : null,

                    }
                    ).FirstOrDefault();
            //user = db.Usuario.Where(x => x.NombreUsuario == pUserName).ToList().Select(x => new Usuario
            //{
            //    IdUsuario = x.IdUsuario,
            //    Tipo = new TipoUsuario
            //    {
            //        IdTipoUsuario = x.TipoUsuario.IdTipoUsuario,
            //        RedirectUrlTipoUsuario = x.TipoUsuario.UrlRedireccion,
            //        Nombre = x.TipoUsuario.Nombre
            //    },
            //    NombreUsuario = pUserName,
            //    Apellidos = x.GE_Persona.Apellido,
            //    Email = x.GE_Persona.Correo,
            //    Nombres = x.GE_Persona.Nombre,
            //    Telefono = x.GE_Persona.Telefono,
            //    IdPersona = x.GE_Persona.Id,                

            //}).FirstOrDefault();

            return user;
        }

        public static Usuario GetUserById(int IdUser)
        {
            Usuario user = new Usuario();
            Data.BarcoSoftUtilidadesDB db = new Data.BarcoSoftUtilidadesDB(true);
            user = (from u in db.Usuario
                    join par in db.PAR_Participante on u.GE_Persona.Id equals par.Id into gj
                    from par in gj.DefaultIfEmpty()
                    join proy in db.PR_Proyecto on par.ProyectoId equals proy.Id into gj1
                    from proy in gj1.DefaultIfEmpty()
                    join emp in db.ADM_Empresa on proy.EmpresaId equals emp.Id into gj2
                    from emp in gj2.DefaultIfEmpty()
                    join nutri in db.PR_Nutricionista on u.IdPersona equals nutri.ColaboradorId into gj4
                    from nutri in gj4.DefaultIfEmpty()
                    where u.IdUsuario == IdUser
                    select new Usuario
                    {
                        IdUsuario = u.IdUsuario,
                        Tipo = new TipoUsuario
                        {
                            IdTipoUsuario = u.TipoUsuario.IdTipoUsuario,
                            RedirectUrlTipoUsuario = u.TipoUsuario.UrlRedireccion,
                            Nombre = u.TipoUsuario.Nombre
                        },
                        NombreUsuario = u.NombreUsuario,
                        Apellidos = u.GE_Persona.PrimerApellido,
                        Email = u.GE_Persona.Correo,
                        Nombres = u.GE_Persona.PrimerNombre,
                        Telefono = u.GE_Persona.Telefono,
                        IdPersona = u.GE_Persona.Id,
                        Empresa = emp != null ? new Empresa
                        {
                            IdEmpresa = emp.Id,
                            Nombre = emp.Nombre
                        } : u.GE_Persona.ADM_Contacto.ADM_Empresa != null ? new Empresa
                        {
                            IdEmpresa = u.GE_Persona.ADM_Contacto.ADM_Empresa.Id,
                            Nombre = u.GE_Persona.ADM_Contacto.ADM_Empresa.Nombre
                        } : null,
                        Proyecto = proy != null ? new Proyecto
                        {
                            IdProyecto = proy.Id,
                        } : null,
                        Nutricionista = nutri != null ? new Nutricionista
                        {
                            idNutricionista = nutri.ColaboradorId
                        } : null,

                    }
               ).FirstOrDefault();
            return user;
        }



        public static void ChangePassword(string NombreUsuario, string pNewEncriptedPassword)
        {
            Data.BarcoSoftUtilidadesDB db = new Data.BarcoSoftUtilidadesDB(true);
            db.Usuario.Where(x => x.NombreUsuario == NombreUsuario).ToList().ForEach(y =>
            {
                y.Contraseña = pNewEncriptedPassword;
            });
            db.SaveChanges();

        }

        public static void RecoverPassword(string nombreUsuario, string url)
        {
            Data.BarcoSoftUtilidadesDB db = new Data.BarcoSoftUtilidadesDB(true);

            // Generar nueva contraseña
            Data.Usuario user = db.Usuario.Where(x => x.GE_Persona.Correo.ToLower().Trim() == nombreUsuario.ToLower().Trim()).FirstOrDefault();
            if (user == null)
            {
                throw new Exception("Usuario ingresado no existe");
            }
            
            using (SmtpClient client = new SmtpClient())
            {
                client.EnableSsl = false;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("ekilibrateessential@ekilibrate.com", "Esvisa16");
                client.Host = "mail.server260.com";
                client.Port = 587;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.ServicePoint.MaxIdleTime = 1;
                client.Timeout = 10000;

                MailMessage msg = new MailMessage();

                msg.From = new MailAddress("ekilibrateessential@ekilibrate.com", "Ekilibrate");
                msg.To.Add(user.GE_Persona.Correo);
                msg.Subject = "Recuperación de Contraseña";
                msg.Body = String.Format(HTMLCorreoRegistro, user.GE_Persona.PrimerNombre, url + "?p85=" + user.NombreUsuario.Encrypt() + "&p67=" + DateTime.Now.Date.ToString().Encrypt());
                msg.IsBodyHtml = true;
                msg.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

                try
                {
                    client.Send(msg);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al enviar mensaje: " + ex.Message);
                    //throw new Exception("No se pudo enviar el mensaje de confirmación a tu correo, favor verifica que sea correcto");   
                }
            }
        }

        private const string HTMLCorreoRegistro = @"
<!DOCTYPE HTML PUBLIC ""-//W3C//DTD XHTML 1.0 Strict//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd"">
<html xmlns=""http://www.w3.org/1999/xhtml"">
<head>
    <!-- NAME: 1 COLUMN -->
    <meta http-equiv=""Content-Type"" content=""text/html; charset=UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>Bienvenido a Ekilibrate</title>

    <style type=""text/css"">
		body,#bodyTable,#bodyCell{{
			height:100% !important;
			margin:0;
			padding:0;
			width:100% !important;
		}}
		table{{
			border-collapse:collapse;
		}}
		img,a img{{
			border:0;
			outline:none;
			text-decoration:none;
		}}
		h1,h2,h3,h4,h5,h6{{
			margin:0;
			padding:0;
		}}
		p{{
			margin:1em 0;
			padding:0;
		}}
		a{{
			word-wrap:break-word;
		}}
		.ReadMsgBody{{
			width:100%;
		}}
		.ExternalClass{{
			width:100%;
		}}
		.ExternalClass,.ExternalClass p,.ExternalClass span,.ExternalClass font,.ExternalClass td,.ExternalClass div{{
			line-height:100%;
		}}
		table,td{{
			mso-table-lspace:0pt;
			mso-table-rspace:0pt;
		}}
		#outlook a{{
			padding:0;
		}}
		img{{
			-ms-interpolation-mode:bicubic;
		}}
		body,table,td,p,a,li,blockquote{{
			-ms-text-size-adjust:100%;
			-webkit-text-size-adjust:100%;
		}}
		#templatePreheader,#templateHeader,#templateBody,#templateFooter{{
			min-width:100%;
		}}
		#bodyCell{{
			padding:20px;
		}}
		.mcnImage{{
			vertical-align:bottom;
		}}
		.mcnTextContent img{{
			height:auto !important;
		}}
		body,#bodyTable{{
			background-color:#F2F2F2;
		}}
		#bodyCell{{
			border-top:0;
		}}
		#templateContainer{{
			border:0;
		}}
		h1{{
			color:#606060 !important;
			display:block;
			font-family:Helvetica;
			font-size:40px;
			font-style:normal;
			font-weight:bold;
			line-height:125%;
			letter-spacing:-1px;
			margin:0;
			text-align:left;
		}}
		h2{{
			color:#404040 !important;
			display:block;
			font-family:Helvetica;
			font-size:26px;
			font-style:normal;
			font-weight:bold;
			line-height:125%;
			letter-spacing:-.75px;
			margin:0;
			text-align:left;
		}}
		h3{{
			color:#606060 !important;
			display:block;
			font-family:Helvetica;
			font-size:18px;
			font-style:normal;
			font-weight:bold;
			line-height:125%;
			letter-spacing:-.5px;
			margin:0;
			text-align:left;
		}}
		h4{{
			color:#808080 !important;
			display:block;
			font-family:Helvetica;
			font-size:16px;
			font-style:normal;
			font-weight:bold;
			line-height:125%;
			letter-spacing:normal;
			margin:0;
			text-align:left;
		}}
		#templatePreheader{{
			background-color:#FFFFFF;
			border-top:0;
			border-bottom:0;
		}}
		.preheaderContainer .mcnTextContent,.preheaderContainer .mcnTextContent p{{
			color:#606060;
			font-family:Helvetica;
			font-size:11px;
			line-height:125%;
			text-align:left;
		}}
		.preheaderContainer .mcnTextContent a{{
			color:#606060;
			font-weight:normal;
			text-decoration:underline;
		}}
		#templateHeader{{
			background-color:#FFFFFF;
			border-top:0;
			border-bottom:0;
		}}
		.headerContainer .mcnTextContent,.headerContainer .mcnTextContent p{{
			color:#606060;
			font-family:Helvetica;
			font-size:15px;
			line-height:150%;
			text-align:left;
		}}
		.headerContainer .mcnTextContent a{{
			color:#6DC6DD;
			font-weight:normal;
			text-decoration:underline;
		}}
		#templateBody{{
			background-color:#ffffff;
			border-top:0;
			border-bottom:0;
		}}
		.bodyContainer .mcnTextContent,.bodyContainer .mcnTextContent p{{
			color:#606060;
			font-family:Helvetica;
			font-size:15px;
			line-height:150%;
			text-align:left;
		}}
		.bodyContainer .mcnTextContent a{{
			color:#6DC6DD;
			font-weight:normal;
			text-decoration:underline;
		}}
		#templateFooter{{
			background-color:#FFFFFF;
			border-top:0;
			border-bottom:0;
		}}
		.footerContainer .mcnTextContent,.footerContainer .mcnTextContent p{{
			color:#606060;
			font-family:Helvetica;
			font-size:11px;
			line-height:125%;
			text-align:left;
		}}
		.footerContainer .mcnTextContent a{{
			color:#606060;
			font-weight:normal;
			text-decoration:underline;
		}}
</style>
</head>
<body leftmargin=""0"" marginwidth=""0"" topmargin=""0"" marginheight=""0"" offset=""0"" style=""margin: 0;padding: 0;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;background-color: #F2F2F2;height: 100% !important;width: 100% !important;"">
    <center>
        <table align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" height=""100%"" width=""100%"" id=""bodyTable"" style=""border-collapse: collapse;mso-table-lspace: 0pt;mso-table-rspace: 0pt;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;margin: 0;padding: 0;background-color: #F2F2F2;height: 100% !important;width: 100% !important;"">
            <tr>
                <td align=""center"" valign=""top"" id=""bodyCell"" style=""mso-table-lspace: 0pt;mso-table-rspace: 0pt;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;margin: 0;padding: 20px;border-top: 0;height: 100% !important;width: 100% !important;"">
                    <!-- BEGIN TEMPLATE // -->
                    <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""600"" id=""templateContainer"" style=""border-collapse: collapse;mso-table-lspace: 0pt;mso-table-rspace: 0pt;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;border: 0;"">
                        <tr>
                            <td align=""center"" valign=""top"" style=""mso-table-lspace: 0pt;mso-table-rspace: 0pt;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;"">
                                <!-- BEGIN HEADER // -->
                                <img src=""https://software.ekilibrate.com/assets/img/encabezado_correo.jpg"" alt="""" width=""100%"" />
                                <!-- // END HEADER -->
                            </td>
                        </tr>
                        <tr>
                            <td align=""center"" valign=""top"" style=""background-color:#FFFFFF; mso-table-lspace: 0pt;mso-table-rspace: 0pt;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;"">
                                <!-- BEGIN BODY // -->
                                <h3 style=""text-align: left;font-family: Helvetica;font-size: 14px; font-weight:100"">
                                    Hola, <font color=""#08B2F0"" style=""font-weight:500;"">{0}</font>
                                    <br />
                                    <br />
                                    Hemos recibido una solicitud para recuperar tu contraseña, puedes proceder con la recuperación haciendo clic <a href=""{1}"">aquí</a>, si no deseas recuperarla puedes simplemente ignorar este correo.
                                    <br />
                                    <br />
                                    Si necesitas ayuda o crees que este correo fue enviado por error, siéntete en libertad de <a href=""mailto:ekilibrate@ekilibrate.com"">contactarnos</a>
                                    <br />
                                    <br />
                                    Gracias,
                                    <br />
                                    Ekilibrate
                                </h3>
                                <br />
                                <!-- // END BODY -->
                                <center>
                                    <table class=""mcnFollowStacked"" align=""left"" border=""0"" cellpadding=""0"" cellspacing=""0"" style=""border-collapse: collapse;mso-table-lspace: 0pt;mso-table-rspace: 0pt;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;"">
                                        <tbody>
                                            <tr>
                                                <td class=""mcnFollowIconContent"" style=""padding-right: 10px;padding-bottom: 5px;mso-table-lspace: 0pt;mso-table-rspace: 0pt;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;"" align=""center"" valign=""top"">
                                                    <a href=""http://www.facebook.com/ekilibratelife"" target=""_blank"" style=""word-wrap: break-word;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;""><img src=""http://cdn-images.mailchimp.com/icons/social-block/color-facebook-128.png"" alt=""Facebook"" class=""mcnFollowBlockIcon"" style=""width: 48px;max-width: 48px;display: block;border: 0;outline: none;text-decoration: none;-ms-interpolation-mode: bicubic;"" width=""48"" /></a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class=""mcnFollowTextContent"" style=""padding-right: 10px;padding-bottom: 9px;mso-table-lspace: 0pt;mso-table-rspace: 0pt;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;"" align=""center"" valign=""top"">
                                                    <a style=""color: #EB4102;font-family: Arial;font-size: 11px;font-weight: normal;line-height: 100%;text-align: center;text-decoration: none;word-wrap: break-word;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;"" href=""http://www.facebook.com/ekilibratelife"" target=""_blank"">Facebook</a>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>

                                    <table class=""mcnFollowStacked"" align=""left"" border=""0"" cellpadding=""0"" cellspacing=""0"" style=""border-collapse: collapse;mso-table-lspace: 0pt;mso-table-rspace: 0pt;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;"">

                                        <tbody>
                                            <tr>
                                                <td class=""mcnFollowIconContent"" style=""padding-right: 10px;padding-bottom: 5px;mso-table-lspace: 0pt;mso-table-rspace: 0pt;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;"" align=""center"" valign=""top"">
                                                    <a href=""http://www.ekilibrate.com"" target=""_blank"" style=""word-wrap: break-word;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;""><img src=""http://cdn-images.mailchimp.com/icons/social-block/color-link-128.png"" alt=""Website"" class=""mcnFollowBlockIcon"" style=""width: 48px;max-width: 48px;display: block;border: 0;outline: none;text-decoration: none;-ms-interpolation-mode: bicubic;"" width=""48"" /></a>
                                                </td>
                                            </tr>


                                            <tr>
                                                <td class=""mcnFollowTextContent"" style=""padding-right: 10px;padding-bottom: 9px;mso-table-lspace: 0pt;mso-table-rspace: 0pt;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;"" align=""center"" valign=""top"">
                                                    <a style=""color: #EB4102;font-family: Arial;font-size: 11px;font-weight: normal;line-height: 100%;text-align: center;text-decoration: none;word-wrap: break-word;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;"" href=""http://www.ekilibrate.com"" target=""_blank"">Website</a>
                                                </td>
                                            </tr>

                                        </tbody>
                                    </table>

                                    <table class=""mcnFollowStacked"" align=""left"" border=""0"" cellpadding=""0"" cellspacing=""0"" style=""border-collapse: collapse;mso-table-lspace: 0pt;mso-table-rspace: 0pt;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;"">

                                        <tbody>
                                            <tr>
                                                <td class=""mcnFollowIconContent"" style=""padding-right: 10px;padding-bottom: 5px;mso-table-lspace: 0pt;mso-table-rspace: 0pt;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;"" align=""center"" valign=""top"">
                                                    <a href=""mailto:ekilibrate@ekilibrate.com"" target=""_blank"" style=""word-wrap: break-word;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;""><img src=""http://cdn-images.mailchimp.com/icons/social-block/color-forwardtofriend-128.png"" alt=""Email"" class=""mcnFollowBlockIcon"" style=""width: 48px;max-width: 48px;display: block;border: 0;outline: none;text-decoration: none;-ms-interpolation-mode: bicubic;"" width=""48"" /></a>
                                                </td>
                                            </tr>


                                            <tr>
                                                <td class=""mcnFollowTextContent"" style=""padding-right: 10px;padding-bottom: 9px;mso-table-lspace: 0pt;mso-table-rspace: 0pt;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;"" align=""center"" valign=""top"">
                                                    <a style=""color: #EB4102;font-family: Arial;font-size: 11px;font-weight: normal;line-height: 100%;text-align: center;text-decoration: none;word-wrap: break-word;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;"" href=""mailto:ekilibrate@ekilibrate.com"" target=""_blank"">Email</a>
                                                </td>
                                            </tr>

                                        </tbody>
                                    </table>

                                    <table class=""mcnFollowStacked"" align=""left"" border=""0"" cellpadding=""0"" cellspacing=""0"" style=""border-collapse: collapse;mso-table-lspace: 0pt;mso-table-rspace: 0pt;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;"">
                                        <tbody>
                                            <tr>
                                                <td class=""mcnFollowIconContent"" style=""padding-right: 10px;padding-bottom: 5px;mso-table-lspace: 0pt;mso-table-rspace: 0pt;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;"" align=""center"" valign=""top"">
                                                    <a href=""http://www.linkedin.com/company/ekilibrate"" target=""_blank"" style=""word-wrap: break-word;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;""><img src=""http://cdn-images.mailchimp.com/icons/social-block/color-linkedin-128.png"" alt=""LinkedIn"" class=""mcnFollowBlockIcon"" style=""width: 48px;max-width: 48px;display: block;border: 0;outline: none;text-decoration: none;-ms-interpolation-mode: bicubic;"" width=""48"" /></a>
                                                </td>
                                            </tr>


                                            <tr>
                                                <td class=""mcnFollowTextContent"" style=""padding-right: 10px;padding-bottom: 9px;mso-table-lspace: 0pt;mso-table-rspace: 0pt;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;"" align=""center"" valign=""top"">
                                                    <a style=""color: #EB4102;font-family: Arial;font-size: 11px;font-weight: normal;line-height: 100%;text-align: center;text-decoration: none;word-wrap: break-word;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;"" href=""http://www.linkedin.com/company/ekilibrate"" target=""_blank"">LinkedIn</a>
                                                </td>
                                            </tr>
       

                                        </tbody>
                                    </table>


                                </center>
                                
                            </td>
                        </tr>
                    </table>
                    <!-- // END TEMPLATE -->
                </td>
            </tr>
        </table>
    </center>
</body>
</html>
";

        public static Usuario MobileLogin(string nombreUsuario, string contraseña)
        {
            Data.BarcoSoftUtilidadesDB db = new Data.BarcoSoftUtilidadesDB(true);
            Data.Usuario dbResult;
            string CriptPass = contraseña.Encrypt();
            dbResult = db.Usuario.Where(x => x.NombreUsuario.ToLower() == nombreUsuario.ToLower() && x.Contraseña == CriptPass).FirstOrDefault();
            if (dbResult == null)
            {
                return null;
            }
            else
            {
                return GetUserByName(nombreUsuario);
            }
        }
    }
}
