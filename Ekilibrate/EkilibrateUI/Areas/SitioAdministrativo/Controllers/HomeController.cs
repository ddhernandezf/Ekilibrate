using EkilibrateUI.Areas.SitioAdministrativo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BarcoSoftUtilidades;
using EkilibrateUI.Areas.SitioAdministrativo.Models.Data;
using System.Net.Mail;
using System.Net;
using System.Web.Security;
using BarcoSoftUtilidades.Seguridad;
using System.Xml.Linq;
using System.IO;
using System.Threading.Tasks;
using Autofac;
using System.Web.UI;

namespace EkilibrateUI.Areas.SitioAdministrativo.Controllers
{
    public class HomeController : Controller
    {

        [HttpPost]
        [AllowAnonymous]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("LogIn", "Home");
        }

        public ActionResult Error404()
        {
            return View();
        }
        public ActionResult Error500()
        {
            return View();
        }

        public ActionResult AccessDenied()
        {
            return View();
        }

        public ActionResult FinalizacionSession()
        {
            return View();
        }

        [BarcoSoftAuthorize]
        [HttpPost]
        public ActionResult Submit(IEnumerable<HttpPostedFileBase> files)
        {
            if (files != null && files.Count() > 0)
            {
                var file = files.FirstOrDefault();
                int id = this.HttpContext.GetActualUser().IdPersona;
                string ext = System.IO.Path.GetExtension(file.FileName);
                var destinationPath = Path.Combine(
                    Server.MapPath("~/Uploads/Participantes"), id.ToString() + ext);
                System.IO.File.Delete(Path.Combine(
                    Server.MapPath("~/Uploads/Participantes"), id.ToString() + ".jpg"));
                System.IO.File.Delete(Path.Combine(
                    Server.MapPath("~/Uploads/Participantes"), id.ToString() + ".png"));
                file.SaveAs(destinationPath);

                MemoryStream target = new MemoryStream();
                file.InputStream.CopyTo(target);
                byte[] data = target.ToArray();


            }

            // Return an empty string to signify success
            return Content("");
        }

        [BarcoSoftAuthorize]
        [HttpPost]
        public ActionResult SubmitE(IEnumerable<HttpPostedFileBase> EmpresaImg, int? pIdEmpresa)
        {
            if (EmpresaImg != null && EmpresaImg.Count() > 0)
            {
                var file = EmpresaImg.FirstOrDefault();
                string id = pIdEmpresa == null ? "TempEmpresa" : ((int)pIdEmpresa).ToString();
                string ext = System.IO.Path.GetExtension(file.FileName);
                var destinationPath = Path.Combine(
                    Server.MapPath("~/Uploads/Empresas"), id + ext);
                System.IO.File.Delete(Path.Combine(
                    Server.MapPath("~/Uploads/Empresas"), id + ".png"));
                file.SaveAs(destinationPath);
            }

            // Return an empty string to signify success
            return Content("");
        }

        [BarcoSoftAuthorize]
        [HttpPost]
        public ActionResult SubmitP(IEnumerable<HttpPostedFileBase> ProyectoImg, int? pIdProyecto)
        {
            if (ProyectoImg != null && ProyectoImg.Count() > 0)
            {
                var file = ProyectoImg.FirstOrDefault();
                string id = pIdProyecto == null ? "TempProyecto" : ((int)pIdProyecto).ToString();
                string ext = System.IO.Path.GetExtension(file.FileName);
                var destinationPath = Path.Combine(
                    Server.MapPath("~/Uploads/Proyectos"), id.ToString() + ext);
                System.IO.File.Delete(Path.Combine(
                    Server.MapPath("~/Uploads/Proyectos"), id.ToString() + ".jpg"));
                System.IO.File.Delete(Path.Combine(
                    Server.MapPath("~/Uploads/Proyectos"), id.ToString() + ".png"));
                file.SaveAs(destinationPath);
            }

            // Return an empty string to signify success
            return Content("");
        }


        [BarcoSoftUtilidades.Seguridad.BarcoSoftAuthorize(Objeto = (int)Accesos.Generales)]
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            LoginViewModel model = new LoginViewModel { returnUrl = returnUrl };
            return View(model);
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    BarcoSoftAuthorize.LogIn(this.HttpContext, model.Password.Encrypt(), model.Email.Trim());
                    FormsAuthentication.SetAuthCookie(model.Email, false);

                    if (model.returnUrl != null && model.returnUrl.Length > 0 && !model.returnUrl.EndsWith("/") && !model.returnUrl.EndsWith("EkilibrateUI") )
                    {
                        if (Request.Url.Host == "localhost" && !model.returnUrl.Contains("EkilibrateUI"))
                        {
                            return Redirect("/EkilibrateUI" + model.returnUrl);
                        }
                        else
                        {
                            return Redirect(model.returnUrl);
                        }
                    }
                    else
                    {
                        BarcoSoftUtilidades.Seguridad.Usuario user = this.HttpContext.GetActualUser();
                        if (user.Tipo.IdTipoUsuario == 6)
                            return Redirect(user.Tipo.RedirectUrlTipoUsuario);
                            //return Redirect("~/SitioAdministrativo/Home/Lock");
                        else
                            return Redirect(user.Tipo.RedirectUrlTipoUsuario);
                    }

                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View();
        }

        //
        // GET: /Account/Lock
        [AllowAnonymous]
        public ActionResult Lock(string returnUrl)
        {
            LoginViewModel model = new LoginViewModel { returnUrl = returnUrl };
            return View(model);
        }

        //
        // GET: /Account/Lock
        public ActionResult Cliente()
        {
            return Redirect("~/Cliente/Home");
        }

        //
        // GET: /Account/Lock
        public ActionResult Participante()
        {
            return Redirect("~/Participante/Home");
        }

        

       [BarcoSoftAuthorize]
        public ActionResult ChangePassword()
        {
            RecoverPasswordViewModel model = new RecoverPasswordViewModel
            {
                NombreUsuario = HttpContext.GetActualUser().NombreUsuario,
            };
            return View("RecoverPassword", model);
        }


        

        public ActionResult RecoverPassword(string p85, string p67)
        {
            RecoverPasswordViewModel model = new RecoverPasswordViewModel();
            try
            {
                if (Convert.ToDateTime(p67.Decrypt()).Date <= DateTime.Now.AddDays(1).Date)
                {
                    model = new RecoverPasswordViewModel
                    {
                        NombreUsuario = p85.Decrypt(),
                    }; 
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult RecoverPassword(RecoverPasswordViewModel model)
        {
            try
            {
                if (model.NewPassword!=model.ConfirmNewPassword)
                {
                    ModelState.AddModelError("ConfirmNewPassword", "Las contraseñas no coinciden.");
                    return View(model);
                }
                BarcoSoftUtilidades.Seguridad.Usuario.ChangePassword(model.NombreUsuario, model.NewPassword.Encrypt());
                return Redirect("~/SitioAdministrativo/Home/login");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ocurrió un error inesperado: " + ex.Message);
            }
            return View(model);
        }


        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult ForgotPassword(ForgotMyPasswordViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    BarcoSoftUtilidades.Seguridad.Usuario.RecoverPassword(model.Email, Url.Action("RecoverPassword", null, null, Request.Url.Scheme));  
                    ViewBag.Exito = "Te hemos enviado un correo con las instrucciones para recuperar tu contraseña, favor verifica.";
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View();
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View(new Ekilibrate.Model.Entity.Participante.clsRegistroParticipante());
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Register(Ekilibrate.Model.Entity.Participante.clsRegistroParticipante model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.Password == model.ConfirmPassword)
                    {
                        using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                        {
                            var middleTier = scope.Resolve<Ekilibrate.Model.Services.Participante.IDataInjector>();
                            var usr = await middleTier.CrearParticipante(model);

                            BarcoSoftAuthorize.LogIn(this.HttpContext, model.Password.Encrypt(), usr);
                            FormsAuthentication.SetAuthCookie(usr, false);

                            BarcoSoftUtilidades.Seguridad.Usuario user = this.HttpContext.GetActualUser();
                            if (user.Tipo.IdTipoUsuario == 6)
                                return Redirect(user.Tipo.RedirectUrlTipoUsuario); 
                                //return Redirect("~/SitioAdministrativo/Home/Lock");
                            else
                                return Redirect(user.Tipo.RedirectUrlTipoUsuario);
                        }
                    }
                    else
                        ModelState.AddModelError(string.Empty, "Las contraseñas ingresadas no coinciden");
                }
                else
                    ModelState.AddModelError(string.Empty, "Verifica tu datos.");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(model);
        }
    }
}
