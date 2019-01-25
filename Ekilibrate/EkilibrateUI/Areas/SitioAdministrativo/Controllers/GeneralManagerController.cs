using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using EkilibrateUI.Areas.SitioAdministrativo.Models.Data;
using BarcoSoftUtilidades.Utilidades;
using BarcoSoftUtilidades;
using EkilibrateUI.Areas.SitioAdministrativo.Models;


namespace EkilibrateUI.Areas.SitioAdministrativo.Controllers
{

    [BarcoSoftUtilidades.Seguridad.BarcoSoftAuthorize]
    public class GeneralManagerController : Controller
    {
        // GET: GeneralManager
        public ActionResult Index()
        {
            return View();
        }

        #region Owner

        public JsonResult GetOwners()
        {
            Models.Data.EkiibrateDBEntities db = new Models.Data.EkiibrateDBEntities(true);

            return Json(db.Propietario.Where(x => x.Activo).ToList()
                        .Select(x => new DropDownListItem
                        {
                            Text = x.Nombre,
                            Value = x.IdPropietario.ToString()
                        }).OrderBy(e => e.Text).ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetProducts(int? IdOwner)
        {
            Models.Data.EkiibrateDBEntities db = new Models.Data.EkiibrateDBEntities(true);
            return Json(db.Producto.Where(y => ((y.IdPropietario == IdOwner && IdOwner != null) || IdOwner == null) && y.Activo).ToList()
                            .Select(x => new DropDownListItem
                            {
                                Text = x.Nombre,
                                Value = x.IdProducto.ToString()
                            }).OrderBy(e => e.Text).ToList(), JsonRequestBehavior.AllowGet);

        }



        /// <summary>
        /// Listar Propietarios
        /// </summary>
        /// <returns></returns>
        [BarcoSoftUtilidades.Seguridad.BarcoSoftAuthorize(Objeto = (int)Accesos.Propietarios)]
        public ActionResult Owners()
        {
            return View();
        }


        /// <summary>
        /// Request de la información de propietarios.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ActionResult Owner_Read([DataSourceRequest] DataSourceRequest request)
        {

            Models.Data.EkiibrateDBEntities db = new Models.Data.EkiibrateDBEntities(true);
            return new JsonNetResult
            {
                Data = db.Propietario.Where(x => x.Activo == true).ToList().Select(x => x.CopyPropertiesTo(new ViewModelPropietario())).ToList()
                    .ToDataSourceResult(request),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        /// <summary>
        /// Agregar nuevo registro
        /// </summary>
        /// <param name="request"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Owner_Create([DataSourceRequest] DataSourceRequest request, Propietario model)
        {

            try
            {
                if (model != null && ModelState.IsValid)
                {
                    Models.Data.EkiibrateDBEntities db = new Models.Data.EkiibrateDBEntities(true);
                    model.Activo = true;
                    db.Propietario.Add(model);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        /// <summary>
        /// Editar registro
        /// </summary>
        /// <param name="request"></param>
        /// <param name="model">Objeto con toda la información modificada.</param>
        /// <returns></returns>
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Owner_Update([DataSourceRequest] DataSourceRequest request, Propietario model)
        {
            try
            {
                if (model != null && ModelState.IsValid)
                {
                    Models.Data.EkiibrateDBEntities db = new Models.Data.EkiibrateDBEntities(true);
                    db.Propietario.Attach(model);
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


        /// <summary>
        /// Eliminar el registro.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Owner_Destroy([DataSourceRequest] DataSourceRequest request, Propietario model)
        {
            try
            {
                if (model != null && ModelState.IsValid)
                {
                    Models.Data.EkiibrateDBEntities db = new Models.Data.EkiibrateDBEntities(true);
                    model.Activo = false;
                    db.Propietario.Attach(model);
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

        #region Product
        [BarcoSoftUtilidades.Seguridad.BarcoSoftAuthorize(Objeto = (int)Accesos.Productos)]
        public ActionResult Products()
        {
            try
            {
                Models.Data.EkiibrateDBEntities db = new Models.Data.EkiibrateDBEntities(true);
                ViewBag.Owner = db.Propietario.Where(x => x.Activo == true).ToList()
                  .Select(x => new DropDownListItem
                  {
                      Text = x.Nombre,
                      Value = x.IdPropietario.ToString()
                  }).OrderBy(e => e.Text).ToList();
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View();
        }


        public ActionResult Product_Read([DataSourceRequest] DataSourceRequest request)
        {
            Models.Data.EkiibrateDBEntities db = new Models.Data.EkiibrateDBEntities(true);
            return new JsonNetResult
            {
                Data = db.Producto.Where(x => x.Activo == true).ToList().Select(x => x.CopyPropertiesTo(new ViewModelProducto()))
                    .ToDataSourceResult(request),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Product_Create([DataSourceRequest] DataSourceRequest request, Producto model)
        {

            if (model != null && ModelState.IsValid)
            {
                Models.Data.EkiibrateDBEntities db = new Models.Data.EkiibrateDBEntities(true);
                model.Activo = true;
                db.Producto.Add(model);
                db.SaveChanges();
            }
            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Product_Update([DataSourceRequest] DataSourceRequest request, Producto model)
        {
            try
            {
                if (model != null && ModelState.IsValid)
                {
                    Models.Data.EkiibrateDBEntities db = new Models.Data.EkiibrateDBEntities(true);
                    db.Producto.Attach(model);
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
        public ActionResult Product_Destroy([DataSourceRequest] DataSourceRequest request, Producto model)
        {
            try
            {
                if (model != null && ModelState.IsValid)
                {
                    Models.Data.EkiibrateDBEntities db = new Models.Data.EkiibrateDBEntities(true);
                    model.Activo = false;
                    db.Producto.Attach(model);
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

        #region ParametroGeneral

        [HttpPost]
        public ActionResult ParametersByProductEnumerable(int pIdOwner)
        {
            try
            {
                return Json(new { success = true, result = GetGlobalParametersEnum(pIdOwner) });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, result = ex.Message });
            }

        }

        private string GetGlobalParametersEnum(int pIdOwner)
        {
            Models.Data.EkiibrateDBEntities db = new Models.Data.EkiibrateDBEntities(true);
            string result = "public enum Parameters  <br>     { <br>";

            db.ParametroGeneral.Where(y => y.Activo && y.IdPropietario == pIdOwner).ToList().ForEach(x =>
            {
                result += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + x.Nombre.Replace(" ", "") + "" + x.ParametroTipo.Nombre + " = " + x.IdPropietario + ",  <br>";
            });
            result += " } ";
            return result;
        }


        [BarcoSoftUtilidades.Seguridad.BarcoSoftAuthorize(Objeto = (int)Accesos.Parametros)]
        public ActionResult GlobalParameters()
        {
            Models.Data.EkiibrateDBEntities db = new Models.Data.EkiibrateDBEntities(true);
            ViewBag.Owner = db.Propietario.Where(x => x.Activo == true).ToList()
              .Select(x => new DropDownListItem
              {
                  Text = x.Nombre,
                  Value = x.IdPropietario.ToString()
              }).OrderBy(e => e.Text).ToList();

            ViewBag.ParameterType = db.ParametroTipo
            .Select(x => new DropDownListItem
            {
                Text = x.Nombre,
                Value = x.IdParametroTipo.ToString()
            }).OrderBy(e => e.Value).ToList();
            return View();
        }


        public ActionResult GlobalParameter_Read([DataSourceRequest] DataSourceRequest request, int? pIdOwner)
        {
            Models.Data.EkiibrateDBEntities db = new Models.Data.EkiibrateDBEntities(true);
            return new JsonNetResult
            {
                Data = db.ParametroGeneral.Where(x => x.Activo && (pIdOwner == null || x.IdPropietario == pIdOwner)).ToList()
                .Select(x => x.CopyPropertiesTo(new ViewModelParametroGeneral()))
                    .ToDataSourceResult(request),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };


        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult GlobalParameter_Create([DataSourceRequest] DataSourceRequest request, ViewModelParametroGeneral model)
        {

            try
            {
                ParametroGeneral efModel = model.CopyPropertiesTo(new ParametroGeneral());
                Models.Data.EkiibrateDBEntities db = new Models.Data.EkiibrateDBEntities(true);
                efModel.Activo = true;
                efModel.TransacUser = this.HttpContext.GetActualUser().NombreUsuario;
                efModel.TransacDateTime = DateTime.Now;
                if (ModelState.IsValid)
                {
                    try
                    {
                        switch (efModel.IdParametroTipo)
                        {
                            case (int)EParametroTipo.String:
                                Convert.ToString(model.Valor);
                                break;
                            case (int)EParametroTipo.Entero:
                                Convert.ToInt32(model.Valor);
                                break;
                            case (int)EParametroTipo.Decimal:
                                Convert.ToDecimal(model.Valor);
                                break;
                            case (int)EParametroTipo.Booleano:
                                Convert.ToBoolean(model.Valor);
                                break;
                            case (int)EParametroTipo.FechaHora:
                                Convert.ToDateTime(model.Valor);
                                break;
                            case (int)EParametroTipo.Hora:
                                Convert.ToDateTime(model.Valor);
                                break;
                            case (int)EParametroTipo.EncryptString:
                                BarcoSoftUtilidades.Utilidades.Cryptography.Decrypt(model.Valor);
                                break;
                        }
                        db.ParametroGeneral.Add(efModel);
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("Valor", ex.Message);
                    }

                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult GlobalParameter_Update([DataSourceRequest] DataSourceRequest request, ViewModelParametroGeneral model)
        {
            try
            {
                Models.Data.EkiibrateDBEntities db = new Models.Data.EkiibrateDBEntities(true);

                var original = db.ParametroGeneral.Find(model.IdParametroGeneral);
                model.TransacUser = this.HttpContext.GetActualUser().NombreUsuario;
                model.TransacDateTime = DateTime.Now;
                if (ModelState.IsValid && original != null)
                {
                    switch (model.IdParametroTipo)
                    {
                        case (int)EParametroTipo.Entero:
                            Convert.ToInt32(model.Valor);
                            break;
                        case (int)EParametroTipo.Decimal:
                            Convert.ToDecimal(model.Valor);
                            break;
                        case (int)EParametroTipo.Booleano:
                            Convert.ToBoolean(model.Valor);
                            break;
                        case (int)EParametroTipo.FechaHora:
                            Convert.ToDateTime(model.Valor);
                            break;
                        case (int)EParametroTipo.Hora:
                            Convert.ToDateTime(model.Valor);
                            break;
                        case (int)EParametroTipo.EncryptString:
                            BarcoSoftUtilidades.Utilidades.Cryptography.Decrypt(model.Valor);
                            break;
                    }

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


        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult GlobalParameter_Destroy([DataSourceRequest] DataSourceRequest request, ViewModelParametroGeneral model)
        {
            try
            {
                Models.Data.EkiibrateDBEntities db = new Models.Data.EkiibrateDBEntities(true);
                var original = db.ParametroGeneral.Find(model.IdParametroGeneral);
                model.TransacUser = this.HttpContext.GetActualUser().NombreUsuario;
                model.TransacDateTime = DateTime.Now;
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
    }
}