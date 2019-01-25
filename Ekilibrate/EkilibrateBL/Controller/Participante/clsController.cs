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

namespace Ekilibrate.BL.Controller.Participante
{
    public class clsController
    {
        private ILifetimeScope _lifetimeScope;
        private const Int32 TipoUsuarioParticipante = 3;
        private const Int32 RolParticipante = 5;
        private const string sk = "3kiP@rt";
        private const string tranuser = "paguilar";
        private const string EstadoProyectoEnRegistro = "EN REGISTRO";
        private const string EstadoProyectoCreacionParticipantes = "CREACIÓN DE PARTICIPANTES";
        private const string EstadoProyectoPreparacion = "PREPARACIÓN";
        private const string EstadoProyectoEnEjecucion = "EN EJECUCIÓN";
        private const string EstadoProyectoFinalizado = "FINALIZADO";
        
        public clsController(ILifetimeScope lifetimeScope) { _lifetimeScope = lifetimeScope; }

        public async Task<string> CrearParticipante(Ekilibrate.Model.Entity.Participante.clsRegistroParticipante Data)
        {
            try
            {
                //Obtener información del proyecto
                Ekilibrate.BL.DataRetriever.clsProyecto objProyecto = new Ekilibrate.BL.DataRetriever.clsProyecto(_lifetimeScope);
                Ekilibrate.Model.Entity.Administrador.clsProyecto dProyecto = await objProyecto.GetProyecto(Data.CodigoRegistro);

                if (dProyecto != null)
                {
                    //Crear Participante                
                    //Crear Persona
                    Ekilibrate.ad.General.clsPersona objPersona = new Ekilibrate.ad.General.clsPersona(_lifetimeScope);
                    Data.Id = await objPersona.Insert(Data);

                    //Insertar Participante
                    Ekilibrate.ad.Participante.clsParticipante objParticipante = new Ekilibrate.ad.Participante.clsParticipante(_lifetimeScope);
                    Ekilibrate.Model.Entity.Participante.clsParticipanteBase dParticipante = new Model.Entity.Participante.clsParticipanteBase();
                    dParticipante.Id = Data.Id;
                    dParticipante.ProyectoId = dProyecto.Id;
                    //dParticipante.GrupoId = ListaGrupos.Where(x => x.Nombre == item.Grupo).First().Id;
                    await objParticipante.Insert(dParticipante);

                    //if (dProyecto.Estado == EstadoProyectoEnEjecucion)
                    //{ 
                        //Insertar DiagnosticoBase
                        Ekilibrate.BL.ad.Participante.clsDiagnostico objDiagnostico = new Ekilibrate.BL.ad.Participante.clsDiagnostico(_lifetimeScope);
                        Ekilibrate.Model.Entity.Participante.clsDiagnosticoBase dDiagnostico = new Model.Entity.Participante.clsDiagnosticoBase();
                        dDiagnostico.ID_PARTICIPANTE = Data.Id;
                        dDiagnostico.PrimerNombre = Data.PrimerNombre;
                        dDiagnostico.PrimerApellido = Data.PrimerApellido;
                        dDiagnostico.Correo = Data.Correo;
                        await objDiagnostico.Insert(dDiagnostico);
                    //}

                    //Insertar Usuario
                    Ekilibrate.ad.Administracion.clsUsuario objUsuario = new Ekilibrate.ad.Administracion.clsUsuario(_lifetimeScope);
                    Ekilibrate.Model.Entity.Administracion.clsUsuarioBase dUsuario = new Model.Entity.Administracion.clsUsuarioBase();

                    string Usuario = await objUsuario.GetUserKey(Data.Correo, dProyecto.EmpresaNombre, Data.PrimerNombre, Data.PrimerApellido);
                    dUsuario.IdPersona = Data.Id;
                    dUsuario.NombreUsuario = Usuario;
                    dUsuario.IdTipoUsuario = TipoUsuarioParticipante;
                    dUsuario.Activo = true;
                    //Grabrar el usuario encriptado como contraseña de usuario
                    //dUsuario.Contraseña = BarcoSoftUtilidades.Utilidades.Cryptography.Encrypt(BarcoSoftUtilidades.Utilidades.Cryptography.Encrypt(item.Id.ToString(), sk));
                    
                    dUsuario.Contraseña = BarcoSoftUtilidades.Utilidades.Cryptography.Encrypt(Data.Password);
                    int IdUsuario = await objUsuario.Insert(dUsuario);

                    //Insertar UsuarioPorRol
                    Ekilibrate.ad.Administracion.clsUsuarioPorRol objUsuarioRol = new Ekilibrate.ad.Administracion.clsUsuarioPorRol(_lifetimeScope);
                    Ekilibrate.Model.Entity.Administracion.clsUsuarioPorRolBase dUsuarioRol = new Model.Entity.Administracion.clsUsuarioPorRolBase();
                    dUsuarioRol.IdUsuario = IdUsuario;
                    dUsuarioRol.IdRol = RolParticipante;
                    dUsuarioRol.TransacDateTime = DateTime.Now;
                    dUsuarioRol.TransacUser = tranuser;
                    await objUsuarioRol.Insert(dUsuarioRol);

                    //Enviar Correo
                    Ekilibrate.BL.Common.clsMail ctrlMail = new Ekilibrate.BL.Common.clsMail(_lifetimeScope);
                    Ekilibrate.Model.Entity.General.clsMensajeCorreo MailNotifica = new Model.Entity.General.clsMensajeCorreo();
                    MailNotifica.Para = Data.Correo;
                    MailNotifica.EsHTML = "SI";
                    MailNotifica.EsLista = "NO";
                    MailNotifica.Asunto = "Bienvenido a Ekilibrate";
                    MailNotifica.Mensaje = String.Format(HTMLCorreoRegistro, Data.PrimerNombre, Usuario, Data.Password);

                    await ctrlMail.DirectEmail(MailNotifica, dProyecto.Correo, dProyecto.PasswordCorreo, "Ekilibrate");
                    return Usuario;
                }
                else
                    throw new Exception("El Código ingresado no es válido favor verifique.");
            }
            catch (Exception e)
            {
                throw new Exception("Error al registrar el participante", e);
            }
            
        }

        public async Task FotoPerfil(int Id, byte[] Foto)
        {
            try
            {                
                Ekilibrate.ad.General.clsPersona objPersona = new Ekilibrate.ad.General.clsPersona(_lifetimeScope);
                await objPersona.FotoPerfil(Id, Foto);                
            }
            catch (Exception e)
            {
                throw new Exception("Error al registrar el participante", e);
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
                                <h3 style=""text-align: center;font-family: Helvetica;font-size: 24px; font-weight:100"">
                                    Gracias, <font color=""#08B2F0"" style=""font-weight:500;"">{0}</font>
                                    <br />
                                    Para acceder a tu
                                    <br />
                                    <font color=""#94C06B"" style=""font-weight:600;"">Diagnóstico de Estilo de Vida</font>
                                    <br />
                                    <br />
                                    Haz clic <a href=""https://software.ekilibrate.com/SitioAdministrativo/Home/Login?ReturnUrl=%2fParticipante%2fDiagnostico"">aquí</a> o ingresa
                                    <br />
                                    https://software.ekilibrate.com 
                                    <br />
                                    en tu navegador.
                                    <br />
                                    
                                    Tus datos de registro son
                                    <br />
                                    Usuario: <font color=""#08B2F0"" style=""font-weight:500;"">{1}</font>
                                    <br />
                                    Password: <font color=""#08B2F0"" style=""font-weight:500;"">{2}</font>
                                    <br />
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
    }
}
