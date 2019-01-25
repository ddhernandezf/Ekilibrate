using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using SitioAdministrativoUI.Models.Data;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using BarcoSoftUtilidades;
using System.Data.Entity;
using System.Text;


namespace SitioAdministrativoUI.Controllers
{
    
    public class AccountsManagerController : Controller
    {
        // GET: AdministracionCuentas
        public ActionResult Index()
        {
            return View();
        }

        #region Usuarios
        [BarcoSoftUtilidades.Seguridad.BarcoSoftAuthorize(Objeto= (int)Accesos.Usuarios)]
        public ActionResult Users()
        {

            BarcoSoftDBEntities db = new BarcoSoftDBEntities(true);
            ViewBag.UserTypes = db.TipoUsuario.Where(x => x.Activo == true)
                     .Select(x => new DropDownListItem
                     {
                         Text = x.Nombre,
                         Value = x.IdTipoUsuario.ToString()
                     }).OrderBy(e => e.Text).ToList();

            return View();
        }


        public ActionResult User_Read([DataSourceRequest] DataSourceRequest request)
        {

            BarcoSoftDBEntities db = new BarcoSoftDBEntities(true);
            List<Usuario> user = db.Usuario.Where(x => x.Activo == true).ToList();

            return new JsonNetResult
            {
                Data = user
                    .ToDataSourceResult(request),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult User_Create([DataSourceRequest] DataSourceRequest request, Usuario model)
        {

            try
            {
                if (model != null && ModelState.IsValid)
                {
                    BarcoSoftDBEntities db = new BarcoSoftDBEntities(true);
                    model.Persona.NombreCompleto = model.Persona.Nombres + " " + model.Persona.Apellidos;
                    model.Contraseña = model.NombreUsuario.Encrypt();
                    model.Persona.Activo = true;
                    model.Activo = true;
                    db.Persona.Add(model.Persona);
                    db.Usuario.Add(model);

                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Model", ex.Message);
            }
            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult User_Update([DataSourceRequest] DataSourceRequest request, Usuario model)
        {
            try
            {
                if (model != null && ModelState.IsValid)
                {
                    BarcoSoftDBEntities db = new BarcoSoftDBEntities(true);
                    model.Persona.NombreCompleto = model.Persona.Nombres + " " + model.Persona.Apellidos;
                    db.Persona.Attach(model.Persona);
                    db.Entry(model.Persona).State = EntityState.Modified;
                    db.Usuario.Attach(model);
                    db.Entry(model).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ViewBag.isError = "Error";
                ViewBag.Error = ex.Message;
            }
            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }


        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult User_Destroy([DataSourceRequest] DataSourceRequest request, Usuario model)
        {
            try
            {
                if (model != null && ModelState.IsValid)
                {

                    BarcoSoftDBEntities db = new BarcoSoftDBEntities(true);
                    model.Persona.Activo = false;
                    model.Activo = false;
                    db.Persona.Attach(model.Persona);
                    db.Entry(model.Persona).State = EntityState.Modified;
                    db.Usuario.Attach(model);
                    db.Entry(model).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Model", ex.Message);
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }
        #endregion

        #region UserType
        [BarcoSoftUtilidades.Seguridad.BarcoSoftAuthorize(Objeto = (int)Accesos.Tipos_de_usuario)]
        public ActionResult UserTypes()
        {
            return View();
        }

        public ActionResult UserType_Read([DataSourceRequest] DataSourceRequest request)
        {

            BarcoSoftDBEntities db = new BarcoSoftDBEntities(true);
            List<TipoUsuario> userTypesList = db.TipoUsuario.Where(x => x.Activo == true).ToList();
            return Json(userTypesList
                     .ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UserType_Create([DataSourceRequest] DataSourceRequest request, TipoUsuario model)
        {

            try
            {
                if (model != null && ModelState.IsValid)
                {
                    BarcoSoftDBEntities db = new BarcoSoftDBEntities(true);
                    model.Activo = true;
                    db.TipoUsuario.Add(model);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Model", ex.Message);
            }
            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UserType_Update([DataSourceRequest] DataSourceRequest request, TipoUsuario model)
        {
            try
            {
                if (model != null && ModelState.IsValid)
                {
                    BarcoSoftDBEntities db = new BarcoSoftDBEntities(true);
                    db.TipoUsuario.Attach(model);
                    db.Entry(model).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Model", ex.Message);
            }
            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }


        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UserType_Destroy([DataSourceRequest] DataSourceRequest request, TipoUsuario model)
        {
            try
            {
                if (model != null && ModelState.IsValid)
                {
                    BarcoSoftDBEntities db = new BarcoSoftDBEntities(true);
                    model.Activo = false;
                    db.TipoUsuario.Attach(model);
                    db.Entry(model).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Model", ex.Message);
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }
        #endregion
    }
}