using SitioAdministrativoUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BarcoSoftUtilidades;
using SitioAdministrativoUI.Models.Data;
using System.Net.Mail;
using System.Net;
using System.Web.Security;
using BarcoSoftUtilidades.Seguridad;
using System.Xml.Linq;

namespace SitioAdministrativoUI.Controllers
{
    public class HomeController : Controller
    {

        [HttpPost]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("LogIn", "Home");
        }



        [BarcoSoftAuthorize]
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
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    BarcoSoftAuthorize.LogIn(this.HttpContext, model.Password.Encrypt(), model.Email);
                    FormsAuthentication.RedirectFromLoginPage(model.Email, false);
                    return Redirect(returnUrl);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View();
        }


        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    BarcoSoftDBEntities db = new BarcoSoftDBEntities(true);

                }
            }
            catch (Exception ex)
            {
                ViewBag.boolResultado = false;
                ViewBag.mensajerError = ex.Message;
            }
            return View();
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
                    BarcoSoftDBEntities db = new BarcoSoftDBEntities(true);
                    // model.u
                }
            }
            catch (Exception ex)
            {
                ViewBag.boolResultado = false;
                ViewBag.mensajerError = ex.Message;
            }
            return View();
        }
    }
}
