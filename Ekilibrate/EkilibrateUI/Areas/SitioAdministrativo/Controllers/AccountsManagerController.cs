using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System.Data.Entity;
using System.Text;
using BarcoSoftUtilidades;
using EkilibrateUI.Areas.SitioAdministrativo.Models;
using EkilibrateUI.Areas.SitioAdministrativo.Models.Data;


namespace EkilibrateUI.Areas.SitioAdministrativo.Controllers
{

    [BarcoSoftUtilidades.Seguridad.BarcoSoftAuthorize]
    public class AccountsManagerController : Controller
    {
        // GET: AdministracionCuentas
        public ActionResult Index()
        {
            return View();
        }

        #region Usuarios
        [BarcoSoftUtilidades.Seguridad.BarcoSoftAuthorize(Objeto = (int)Accesos.Usuarios)]
        public ActionResult Users()
        {

            Models.Data.EkiibrateDBEntities db = new Models.Data.EkiibrateDBEntities(true);
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

            Models.Data.EkiibrateDBEntities db = new Models.Data.EkiibrateDBEntities(true);
            List<ViewModelUsuario> user = db.Usuario.Where(x => x.Activo == true).Select(x => new ViewModelUsuario
            {
                Activo = x.Activo,
                Contraseña = x.Contraseña,
                IdPersona = x.IdPersona,
                IdTipoUsuario = x.IdTipoUsuario,
                IdUsuario = x.IdUsuario,
                NombreUsuario = x.NombreUsuario,
                GE_Persona = new ViewModelPersona
                {
                    Apellido = x.GE_Persona.Apellido,
                    Correo = x.GE_Persona.Correo,
                    Direccion = x.GE_Persona.Direccion,
                    Extension = x.GE_Persona.Extension,
                    Id = x.GE_Persona.Id,
                    Nombre = x.GE_Persona.Nombre,
                    Puesto = x.GE_Persona.Puesto,
                    Telefono = x.GE_Persona.Telefono
                }

            }).ToList();

            return new JsonNetResult
            {
                Data = user
                    .ToDataSourceResult(request),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult User_Create([DataSourceRequest] DataSourceRequest request, ViewModelUsuario model)
        {

            try
            {
                if (model != null && ModelState.IsValid)
                {
                    Models.Data.EkiibrateDBEntities db = new Models.Data.EkiibrateDBEntities(true);
                    Usuario efModel = new Usuario 
                    {
                        GE_Persona = model.GE_Persona.CopyPropertiesTo(new GE_Persona()),
                        IdPersona =model.IdPersona,
                        IdTipoUsuario = model.IdTipoUsuario,
                        NombreUsuario = model.NombreUsuario,
                        
                    };
                    efModel.Contraseña = model.NombreUsuario.Encrypt();
                    efModel.Activo = true;
                    model.GE_Persona.Id = db.GE_Persona.Max(x => x.Id) + 1;
                    db.GE_Persona.Add(efModel.GE_Persona);
                    db.Usuario.Add(efModel);

                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult User_Update([DataSourceRequest] DataSourceRequest request, ViewModelUsuario model)
        {
            try
            {
                Models.Data.EkiibrateDBEntities db = new Models.Data.EkiibrateDBEntities(true);
                var original = db.Usuario.Find(model.IdUsuario);
                var originalPersona = db.GE_Persona.Find(model.IdPersona);
                if (ModelState.IsValid && original != null)
                {

                    db.Entry(original).CurrentValues.SetValues(model);
                    db.Entry(originalPersona).CurrentValues.SetValues(model.GE_Persona);
                    
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }


        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult User_Destroy([DataSourceRequest] DataSourceRequest request, ViewModelUsuario model)
        {
            try
            {
               

                    Models.Data.EkiibrateDBEntities db = new Models.Data.EkiibrateDBEntities(true);
                    var original = db.Usuario.Find(model.IdUsuario);
                    model.Activo = false;

                    if (ModelState.IsValid && original != null)
                    {
                        
                        db.Entry(original).CurrentValues.SetValues(model);
                        db.SaveChanges();
                    }
                
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }
        #endregion

        #region UserType
        [BarcoSoftUtilidades.Seguridad.BarcoSoftAuthorize(Objeto = (int)Accesos.Tipo_de_usuarios)]
        public ActionResult UserTypes()
        {
            return View();
        }

        public ActionResult UserType_Read([DataSourceRequest] DataSourceRequest request)
        {

            Models.Data.EkiibrateDBEntities db = new Models.Data.EkiibrateDBEntities(true);
            List<ViewModelTipoUsuario> userTypesList = db.TipoUsuario.Where(x => x.Activo == true).ToList().Select(x => x.CopyPropertiesTo(new ViewModelTipoUsuario())).ToList();

            return new JsonNetResult
            {
                Data = userTypesList
                    .ToDataSourceResult(request),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
           
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UserType_Create([DataSourceRequest] DataSourceRequest request, ViewModelTipoUsuario model)
        {

            try
            {
                TipoUsuario efModel =  model.CopyPropertiesTo(new TipoUsuario());
                if (model != null && ModelState.IsValid)
                {
                    Models.Data.EkiibrateDBEntities db = new Models.Data.EkiibrateDBEntities(true);
                    efModel.Activo = true;
                    efModel.IdTipoUsuario = db.TipoUsuario.Max(x => x.IdTipoUsuario) + 1;
                    db.TipoUsuario.Add(efModel);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
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
                    Models.Data.EkiibrateDBEntities db = new Models.Data.EkiibrateDBEntities(true);
                    db.TipoUsuario.Attach(model);
                    db.Entry(model).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
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
                    Models.Data.EkiibrateDBEntities db = new Models.Data.EkiibrateDBEntities(true);
                    model.Activo = false;
                    db.TipoUsuario.Attach(model);
                    db.Entry(model).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }
        #endregion
    }
}