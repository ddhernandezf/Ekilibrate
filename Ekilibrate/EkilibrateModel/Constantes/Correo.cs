using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.Model.Constantes
{
    public static class Correo
    {
        public enum TipoMensaje
        {
            Bienvenida = 1,
            Invitacion = 2,
            RecordatorioCuestionarios = 3,
            NotificaCitaNutriCompa = 4,
            RecordatorioCita = 5,
            RecordatorioPasos = 6
        }

        public const string HTMLCorreoRegistro = @"
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
			background-color:#FFFFFF;
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
<body leftmargin=""0"" marginwidth=""0"" topmargin=""0"" marginheight=""0"" offset=""0"" style=""margin: 0;padding: 0;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;background-color: #FFFFFF;height: 100% !important;width: 100% !important;"">
    <center>
        <table align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" height=""100%"" width=""100%"" id=""bodyTable"" style=""border-collapse: collapse;mso-table-lspace: 0pt;mso-table-rspace: 0pt;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;margin: 0;padding: 0;background-color: #FFFFFF;height: 100% !important;width: 100% !important;"">
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
                                    <font color=""#08B2F0"" style=""font-weight:500;"">{0}</font>
                                    <br />
                                    Tienes una invitación a configurar los parámetros de nuestro proyecto
                                    <br />
                                    <font color=""#94C06B"" style=""font-weight:600;"">{3}</font>
                                    <br />
                                    <br />
                                    Haz clic <a href=""https://software.ekilibrate.com/SitioAdministrativo/Home/Login?ReturnUrl=%2fParticipante%2fDiagnostico"">aquí</a> o ingresa
                                    <br />
                                    www.ekilibrate.com/software 
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

        public const string HTMLCorreoRegistroSinContraseña = @"
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
			background-color:#FFFFFF;
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
<body leftmargin=""0"" marginwidth=""0"" topmargin=""0"" marginheight=""0"" offset=""0"" style=""margin: 0;padding: 0;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;background-color: #FFFFFF;height: 100% !important;width: 100% !important;"">
    <center>
        <table align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" height=""100%"" width=""100%"" id=""bodyTable"" style=""border-collapse: collapse;mso-table-lspace: 0pt;mso-table-rspace: 0pt;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;margin: 0;padding: 0;background-color: #FFFFFF;height: 100% !important;width: 100% !important;"">
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
                                    <font color=""#08B2F0"" style=""font-weight:500;"">{0}</font>
                                    <br />
                                    Tienes una invitación a configurar los parámetros de nuestro proyecto
                                    <br />
                                    <font color=""#94C06B"" style=""font-weight:600;"">{2}</font>
                                    <br />
                                    <br />
                                    Haz clic <a href=""https://software.ekilibrate.com/SitioAdministrativo/Home/Login?ReturnUrl=%2fParticipante%2fDiagnostico"">aquí</a> o ingresa
                                    <br />
                                    www.ekilibrate.com/software 
                                    <br />
                                    en tu navegador.
                                    <br />
                                    
                                    Tus datos de registro son
                                    <br />
                                    Usuario: <font color=""#08B2F0"" style=""font-weight:500;"">{1}</font>
                                    <br />
                                    Password: (Enviado anteriormente)</font>
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

        public const string HTMLCorreoRegistroRayovac = @"
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
			background-color:#FFFFFF;
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
<body leftmargin=""0"" marginwidth=""0"" topmargin=""0"" marginheight=""0"" offset=""0"" style=""margin: 0;padding: 0;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;background-color: #FFFFFF;height: 100% !important;width: 100% !important;"">
    <center>
        <table align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" height=""100%"" width=""100%"" id=""bodyTable"" style=""border-collapse: collapse;mso-table-lspace: 0pt;mso-table-rspace: 0pt;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;margin: 0;padding: 0;background-color: #FFFFFF;height: 100% !important;width: 100% !important;"">
            <tr>
                <td align=""center"" valign=""top"" id=""bodyCell"" style=""mso-table-lspace: 0pt;mso-table-rspace: 0pt;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;margin: 0;padding: 20px;border-top: 0;height: 100% !important;width: 100% !important;"">
                    <!-- BEGIN TEMPLATE // -->
                    <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""600"" id=""templateContainer"" style=""border-collapse: collapse;mso-table-lspace: 0pt;mso-table-rspace: 0pt;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;border: 0;"">
                        <tr>
                            <td align=""center"" valign=""top"" style=""mso-table-lspace: 0pt;mso-table-rspace: 0pt;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;"">
                                <!-- BEGIN HEADER // -->
                                <img src=""https://software.ekilibrate.com/assets/img/encabezado_rayobac.jpg"" alt="""" width=""100%"" />
                                <!-- // END HEADER -->
                            </td>
                        </tr>
                        <tr>
                            <td align=""center"" valign=""top"" style=""background-color:#FFFFFF; mso-table-lspace: 0pt;mso-table-rspace: 0pt;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;"">
                                <!-- BEGIN BODY // -->
                                <h3 style=""text-align: center;font-family: Helvetica;font-size: 24px; font-weight:100"">
                                    Bienvenido, <font color=""#08B2F0"" style=""font-weight:500;"">{0}</font>
                                    <br />
                                    <font color=""#DC143C"" style=""font-weight:500;"">Nos disculpamos por el error cometido, estas son las instrucciones correctas para tu registro</font>
                                    <br />
                                    Para acceder a tu
                                    <br />
                                    <font color=""#94C06B"" style=""font-weight:600;"">Diagnóstico de Estilo de Vida</font>
                                    <br />
                                    <br />
                                    Haz clic <a href=""https://software.ekilibrate.com/SitioAdministrativo/Home/Login?ReturnUrl=%2fParticipante%2fDiagnostico"">aquí</a> o ingresa
                                    <br />
                                    www.ekilibrate.com/software 
                                    <br />
                                    en tu navegador.
                                    <br />
                                    ***Tienes 8 días para completar tu cuestionario.  Tu usuario estará habilitado del 7 al 14 de febrero***
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

        public const string HTMLCorreoRecordatorioRayovac = @"
<!DOCTYPE HTML PUBLIC ""-//W3C//DTD XHTML 1.0 Strict//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd"">
<html xmlns=""http://www.w3.org/1999/xhtml"">
<head>
    <!-- NAME: 1 COLUMN -->
    <meta http-equiv=""Content-Type"" content=""text/html; charset=UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>Friendly Reminder</title>

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
			background-color:#FFFFFF;
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
<body leftmargin=""0"" marginwidth=""0"" topmargin=""0"" marginheight=""0"" offset=""0"" style=""margin: 0;padding: 0;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;background-color: #FFFFFF;height: 100% !important;width: 100% !important;"">
    <center>
        <table align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" height=""100%"" width=""100%"" id=""bodyTable"" style=""border-collapse: collapse;mso-table-lspace: 0pt;mso-table-rspace: 0pt;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;margin: 0;padding: 0;background-color: #FFFFFF;height: 100% !important;width: 100% !important;"">
            <tr>
                <td align=""center"" valign=""top"" id=""bodyCell"" style=""mso-table-lspace: 0pt;mso-table-rspace: 0pt;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;margin: 0;padding: 20px;border-top: 0;height: 100% !important;width: 100% !important;"">
                    <!-- BEGIN TEMPLATE // -->
                    <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""600"" id=""templateContainer"" style=""border-collapse: collapse;mso-table-lspace: 0pt;mso-table-rspace: 0pt;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;border: 0;"">
                        <tr>
                            <td align=""center"" valign=""top"" style=""mso-table-lspace: 0pt;mso-table-rspace: 0pt;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;"">
                                <!-- BEGIN HEADER // -->                                
                                <!-- // END HEADER -->
                            </td>
                        </tr>
                        <tr>
                            <td align=""center"" valign=""top"" style="" mso-table-lspace: 0pt;mso-table-rspace: 0pt;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;"">
                                <!-- BEGIN BODY // -->
                                <h3 style=""text-align: left;font-family: Helvetica;font-size: 20px; font-weight:100"">
                                    Dear {0}
                                    <br />
                                    <br />
                                    You are running behind to get a complete Lifestyle Diagnosis.  
                                    <br />
                                    <br />
                                    Your online questionnaires are still at a {1}%.  
                                    <br />
                                    <br />
                                    In order to be able to give you a complete report on we need to have as much information as possible. 
                                    <br />
                                    <br />
                                    Please take some time to complete them. It only takes 20 minutes.  
                                    <br />
                                    <br />
                                    Your  user will be enabled for 24 hours more.  
                                    <br />
                                    <br />
                                    Don’t miss this chance!                                     
                                    <br />
                                    <br />
                                    Xoom Health & Wellness Team
                                    <br />
                                    <br />
                                </h3>
                                <br />
                                <!-- // END BODY -->
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

        public const string HTMLCorreoNutricionistaCompa = @"
<!DOCTYPE HTML PUBLIC ""-//W3C//DTD XHTML 1.0 Strict//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd"">
<html xmlns=""http://www.w3.org/1999/xhtml"">
<head>
    <!-- NAME: 1 COLUMN -->
    <meta http-equiv=""Content-Type"" content=""text/html; charset=UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>Friendly Reminder</title>

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
			background-color:#FFFFFF;
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
<body leftmargin=""0"" marginwidth=""0"" topmargin=""0"" marginheight=""0"" offset=""0"" style=""margin: 0;padding: 0;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;background-color: #FFFFFF;height: 100% !important;width: 100% !important;"">
    <center>
        <table align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" height=""100%"" width=""100%"" id=""bodyTable"" style=""border-collapse: collapse;mso-table-lspace: 0pt;mso-table-rspace: 0pt;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;margin: 0;padding: 0;background-color: #FFFFFF;height: 100% !important;width: 100% !important;"">
            <tr>
                <td align=""center"" valign=""top"" id=""bodyCell"" style=""mso-table-lspace: 0pt;mso-table-rspace: 0pt;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;margin: 0;padding: 20px;border-top: 0;height: 100% !important;width: 100% !important;"">
                    <!-- BEGIN TEMPLATE // -->
                    <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""600"" id=""templateContainer"" style=""border-collapse: collapse;mso-table-lspace: 0pt;mso-table-rspace: 0pt;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;border: 0;"">
                        <tr>
                            <td align=""center"" valign=""top"" style=""mso-table-lspace: 0pt;mso-table-rspace: 0pt;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;"">
                                <!-- BEGIN HEADER // -->                                
                                <!-- // END HEADER -->
                            </td>
                        </tr>
                        <tr>
                            <td align=""center"" valign=""top"" style="" mso-table-lspace: 0pt;mso-table-rspace: 0pt;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;"">
                                <!-- BEGIN BODY // -->
                                <h3 style=""text-align: left;font-family: Helvetica;font-size: 20px; font-weight:100"">
                                    Dear <div style=""color:#DC143C; font-weight: bold;display:inline;"">{0}</div>
                                    <br />
                                    <br />
                                    Welcome to Health & Wellness Challenge!
                                    <br />
                                    During the next 16 weeks we will be working on improving our lifestyle, especially in the Health Area.
                                    <br />
                                    <br />
                                    The program has two parts that will be carried away simultaneously:
                                    <br />
                                    <br />
                                    <b><u>Part I: Nutritional monitoring (6 follow-up appointments + 1 final diagnosis)</u></b>
                                    <br />
                                    The nutritionist who will be in charge of your follow up is: 
                                    <div style=""color:#DC143C; font-weight: bold;display:inline;"">{1}</div>
                                    <br />
                                    And your appointments will take place every other week on: <div style=""color:#DC143C; font-weight: bold;display:inline;"">{2}</div> at <div style=""color:#DC143C; font-weight: bold;display:inline;"">{3}</div> starting on <div style=""color:#DC143C; font-weight: bold;display:inline;"">{4}</div>
                                    <br />
                                    <br />
                                    <b><u>Part I: Nutritional monitoring (6 follow-up appointments + 1 final diagnosis)</u></b>
                                    <br />
                                    This program will help us improve our physical activity. The goal is to get to walk 10,000 steps daily. This may seem hard but its not, especially if you are not alone.
                                    <br />
                                    We have assigned you a ""COMPA"" (compañero de pasos) to encourage each other to keep going week after week.
                                    <br />
                                    Your COMPA  is:  
                                    <div style=""color:#DC143C; font-weight: bold;display:inline;"">{5}</div>
                                    begin your challenge!
                                    <br />
                                    <br />
                                    Good luck on your Journey to a healthy LifeStyle,
                                    <br />
                                    <br />
                                    Xoom Health & Wellness Team
                                </h3>
                                <br />
                                <!-- // END BODY -->
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

        public const string HTMLCorreoDiagnosticoFinal = @"
<!DOCTYPE HTML PUBLIC ""-//W3C//DTD XHTML 1.0 Strict//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd"">
<html xmlns=""http://www.w3.org/1999/xhtml"">
<head>
    <!-- NAME: 1 COLUMN -->
    <meta http-equiv=""Content-Type"" content=""text/html; charset=UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>Friendly Reminder</title>

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
			background-color:#FFFFFF;
		}}
		#bodyCell{{
			border-top:0;
		}}
		#templateContainer{{
			border:0;
		}}
		h1{{
			color:#000000 !important;
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
<body leftmargin=""0"" marginwidth=""0"" topmargin=""0"" marginheight=""0"" offset=""0"" style=""margin: 0;padding: 0;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;background-color: #FFFFFF;height: 100% !important;width: 100% !important;"">
    <center>
        <table align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" height=""100%"" width=""100%"" id=""bodyTable"" style=""border-collapse: collapse;mso-table-lspace: 0pt;mso-table-rspace: 0pt;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;margin: 0;padding: 0;background-color: #FFFFFF;height: 100% !important;width: 100% !important;"">
            <tr>
                <td align=""center"" valign=""top"" id=""bodyCell"" style=""mso-table-lspace: 0pt;mso-table-rspace: 0pt;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;margin: 0;padding: 20px;border-top: 0;height: 100% !important;width: 100% !important;"">
                    <!-- BEGIN TEMPLATE // -->
                    <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""600"" id=""templateContainer"" style=""border-collapse: collapse;mso-table-lspace: 0pt;mso-table-rspace: 0pt;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;border: 0;"">
                        <tr>
                            <td align=""center"" valign=""top"" style=""mso-table-lspace: 0pt;mso-table-rspace: 0pt;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;"">
                                <!-- BEGIN HEADER // -->                                
                                <!-- // END HEADER -->
                            </td>
                        </tr>
                        <tr>
                            <td align=""center"" valign=""top"" style="" mso-table-lspace: 0pt;mso-table-rspace: 0pt;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;"">
                                <!-- BEGIN BODY // -->
                                <h3 style=""text-align: left;font-family: Helvetica;font-size: 20px; font-weight:100"">
                                    Dear <div style=""color:#DC143C; font-weight: bold;display:inline-block;"">{0}</div>
                                    <br />
                                    <br />
                                    <div style=""color:#00008B;display:inline-block;"">Our apologies to you. The information you received yesterday is not accurate. The date of your BIOMEDICAL EVALUATION was wrong. Please check the correct date and time in the information below</div>
                                    <br />
                                    <br />
                                    <div style=""color:#00008B;display:inline-block;"">We will be sending you this invitation in an appointment format as well, so it can be added it to your calendar automatically.</div>
                                    <br />
                                    <br />
                                    <div style=""color:#00008B;display:inline-block;"">Thank you and sorry for the inconvenience.</div>
                                    <br />
                                    <br />
                                    Congratulations on your perseverance!
                                    <br />
                                    <br />
                                    You have reached the final stage of the journey towards a healthy lifestyle.
                                    <br />
                                    All that is missing is the final step of evaluating the complete achievement through a final diagnosis..
                                    <br />
                                    <br />
                                    <b>THIS THE STEPS TO FOLLOW:</b>
                                    <br />
                                    <br />
                                    <b><u>STEP 1 – BIO-MEDICAL EVALUATION (<div style=""color:#00008B; font-weight: bold;display:inline-block;"">{1}</div>)</u></b>
                                    <br />
                                    We will be taking your blood pressure as well as blood samples in order to test cholesterol, triglycerides and glucose levels. You must come with a 12 hours fast. Last meal should not be taken after 8 pm the previous day. Prefer a light meal and avoid alcoholic drinks.
                                    <br />
                                    <br />
                                    <b><u>STEP 2 – NUTRITIONAL EVALUATION (<div style=""color:#00008B; font-weight: bold;display:inline-block;"">{2}</div>)</u></b>
                                    <br />
                                    <b>The day after</b> your Bio-Medical evaluation you will have a nutritional assessment where we will find  out what was your total performance in the program.
                                    <br />
                                    Drink plenty of water the day before so fat percentage can be well measured. We will be asking you to take your shoes and socks off.
                                    <br />
                                    <br />
                                    Please respect the days and hours of your evaluation. This time there will be no appointment reschedule.   If you have trouble with the schedule, tell us in advance by replying this e-mail. 
                                    <br />
                                    <br />
                                    See you soon!
                                    <br />
                                    <br />                                    
                                </h3>
                                <br />
                                <!-- // END BODY -->
                            </td>
                        </tr>
                        <tr>
                            <td align=""left"">
                                <img src=""https://software.ekilibrate.com/assets/img/xoom_footer.jpg"" alt="""" />
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

        public const string HTMLCorreoRecordatorioPasos = @"
<!DOCTYPE HTML PUBLIC ""-//W3C//DTD XHTML 1.0 Strict//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd"">
<html xmlns=""http://www.w3.org/1999/xhtml"">
<head>
    <!-- NAME: 1 COLUMN -->
    <meta http-equiv=""Content-Type"" content=""text/html; charset=UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>Friendly Reminder</title>

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
			background-color:#FFFFFF;
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
<body leftmargin=""0"" marginwidth=""0"" topmargin=""0"" marginheight=""0"" offset=""0"" style=""margin: 0;padding: 0;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;background-color: #FFFFFF;height: 100% !important;width: 100% !important;"">
    <center>
        <table align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" height=""100%"" width=""100%"" id=""bodyTable"" style=""border-collapse: collapse;mso-table-lspace: 0pt;mso-table-rspace: 0pt;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;margin: 0;padding: 0;background-color: #FFFFFF;height: 100% !important;width: 100% !important;"">
            <tr>
                <td align=""center"" valign=""top"" id=""bodyCell"" style=""mso-table-lspace: 0pt;mso-table-rspace: 0pt;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;margin: 0;padding: 20px;border-top: 0;height: 100% !important;width: 100% !important;"">
                    <!-- BEGIN TEMPLATE // -->
                    <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""600"" id=""templateContainer"" style=""border-collapse: collapse;mso-table-lspace: 0pt;mso-table-rspace: 0pt;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;border: 0;"">
                        <tr>
                            <td align=""center"" valign=""top"" style=""mso-table-lspace: 0pt;mso-table-rspace: 0pt;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;"">
                                <!-- BEGIN HEADER // -->                                
                                <!-- // END HEADER -->
                            </td>
                        </tr>
                        <tr>
                            <td align=""center"" valign=""top"" style="" mso-table-lspace: 0pt;mso-table-rspace: 0pt;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;"">
                                <!-- BEGIN BODY // -->
                                <h3 style=""text-align: left;font-family: Helvetica;font-size: 20px; font-weight:100"">
                                    Dear <div style=""color:#DC143C; font-weight: bold;display:inline;"">{0}</div>
                                    <br />
                                    <br />
                                    Do not forget to report your MANPO KEI steps today! Monday is the last day you can enter steps from last week.  
                                    <br />
                                    <br />
                                    So do it before midnight and do not lose the count!
                                    <br />
                                    <br />
                                    PS. If you are having problems with the operation of your smart bracelet, please bring it to your nutritionist. For purposes of warranty claim we need it in its original box. Thank you.
                                </h3>
                                <br />
                                <!-- // END BODY -->
                            </td>
                        </tr>
                        <tr>
                            <td align=""left"">
                                <img src=""https://software.ekilibrate.com/assets/img/xoom_footer.jpg"" alt="""" />
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

        public const string HTMLCorreoRecordatorioCita = @"
<!DOCTYPE HTML PUBLIC ""-//W3C//DTD XHTML 1.0 Strict//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd"">
<html xmlns=""http://www.w3.org/1999/xhtml"">
<head>
    <!-- NAME: 1 COLUMN -->
    <meta http-equiv=""Content-Type"" content=""text/html; charset=UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>Friendly Reminder</title>

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
			background-color:#FFFFFF;
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
<body leftmargin=""0"" marginwidth=""0"" topmargin=""0"" marginheight=""0"" offset=""0"" style=""margin: 0;padding: 0;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;background-color: #FFFFFF;height: 100% !important;width: 100% !important;"">
    <center>
        <table align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" height=""100%"" width=""100%"" id=""bodyTable"" style=""border-collapse: collapse;mso-table-lspace: 0pt;mso-table-rspace: 0pt;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;margin: 0;padding: 0;background-color: #FFFFFF;height: 100% !important;width: 100% !important;"">
            <tr>
                <td align=""center"" valign=""top"" id=""bodyCell"" style=""mso-table-lspace: 0pt;mso-table-rspace: 0pt;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;margin: 0;padding: 20px;border-top: 0;height: 100% !important;width: 100% !important;"">
                    <!-- BEGIN TEMPLATE // -->
                    <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""600"" id=""templateContainer"" style=""border-collapse: collapse;mso-table-lspace: 0pt;mso-table-rspace: 0pt;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;border: 0;"">
                        <tr>
                            <td align=""center"" valign=""top"" style=""mso-table-lspace: 0pt;mso-table-rspace: 0pt;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;"">
                                <!-- BEGIN HEADER // -->                                
                                <!-- // END HEADER -->
                            </td>
                        </tr>
                        <tr>
                            <td align=""center"" valign=""top"" style="" mso-table-lspace: 0pt;mso-table-rspace: 0pt;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;"">
                                <!-- BEGIN BODY // -->
                                <h3 style=""text-align: left;font-family: Helvetica;font-size: 20px; font-weight:100"">
                                    Hello <div style=""color:#DC143C; font-weight: bold;display:inline;"">{0}</div>
                                    <br />
                                    <br />
                                    Do not forget your appointment this week on <div style=""color:#DC143C; font-weight: bold;display:inline;"">{1}</div> at <div style=""color:#DC143C; font-weight: bold;display:inline;"">{2}</div> We'll be waiting for you at Atitlán conference room.
                                    <br />
                                    <br />
                                    Please if you have  any problem with your schedule let us know prior to the date and time of the appointment.
                                    <br />
                                    <br />
                                    See you,
                                    <br />
                                    <br />
                                </h3>
                                <br />
                                <!-- // END BODY -->
                            </td>
                        </tr>
                        <tr>
                            <td align=""left"">
                                <img src=""https://software.ekilibrate.com/assets/img/xoom_footer.jpg"" alt="""" />
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
