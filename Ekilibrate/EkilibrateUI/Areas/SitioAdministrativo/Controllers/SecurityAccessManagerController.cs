using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Text.RegularExpressions;
using EkilibrateUI.Areas.SitioAdministrativo.Models.Data;
using EkilibrateUI.Areas.SitioAdministrativo.Models;
using BarcoSoftUtilidades;
using BarcoSoftUtilidades.Utilidades;
using BarcoSoftUtilidades.Seguridad;

namespace EkilibrateUI.Areas.SitioAdministrativo.Controllers
{
    [BarcoSoftAuthorize]
    public class SecurityAccessManagerController : Controller
    {

        // GET: SecurityAccessManager
        public ActionResult Index()
        {
            return View();
        }

        #region Roles
         [BarcoSoftUtilidades.Seguridad.BarcoSoftAuthorize(Objeto = (int)Accesos.Roles)]
        public ActionResult Roles()
        {
            Models.Data.EkiibrateDBEntities db = new Models.Data.EkiibrateDBEntities(true);
            ViewBag.Owner = db.Propietario.Where(x => x.Activo == true).ToList()
              .Select(x => new DropDownListItem
              {
                  Text = x.Nombre,
                  Value = x.IdPropietario.ToString()
              }).OrderBy(e => e.Text).ToList();

            ViewBag.UserTypes = db.TipoUsuario.Where(x => x.Activo == true)
                     .Select(x => new DropDownListItem
                     {
                         Text = x.Nombre,
                         Value = x.IdTipoUsuario.ToString()
                     }).OrderBy(e => e.Text).ToList();

            return View();
        }

        public ActionResult Role_Read([DataSourceRequest] DataSourceRequest request)
        {
            Models.Data.EkiibrateDBEntities db = new Models.Data.EkiibrateDBEntities(true);
            return new JsonNetResult
            {
                Data = db.Rol.Where(x => x.Activo == true)
                .Select(y => new ViewModelRole
                {
                    Activo = y.Activo,
                    Descripcion = y.Descripcion,
                    IdPropietario = y.IdPropietario,
                    IdRol = y.IdRol,
                    Nombre = y.Nombre
                })
                .ToList()
                    .ToDataSourceResult(request),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Role_Create([DataSourceRequest] DataSourceRequest request, Rol model)
        {

            try
            {
                if (model != null && ModelState.IsValid)
                {
                    Models.Data.EkiibrateDBEntities db = new Models.Data.EkiibrateDBEntities(true);
                    model.Activo = true;
                    db.Rol.Add(model);
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
        public ActionResult Role_Update([DataSourceRequest] DataSourceRequest request, Rol model)
        {
            try
            {
                Models.Data.EkiibrateDBEntities db = new Models.Data.EkiibrateDBEntities(true);
                var original = db.Rol.Find(model.IdRol);

                if (model != null && ModelState.IsValid && original != null)
                {
                    db.Entry(original).CurrentValues.SetValues(model);
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
        public ActionResult Role_Destroy([DataSourceRequest] DataSourceRequest request, Rol model)
        {
            try
            {

                Models.Data.EkiibrateDBEntities db = new Models.Data.EkiibrateDBEntities(true);
                var original = db.Rol.Find(model.IdRol);
                model.Activo = false;
                if (model != null && ModelState.IsValid && original != null)
                {
                    db.Entry(original).CurrentValues.SetValues(model);
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

        #region Objeto

        [HttpPost]
        public ActionResult ProductObjectEnumerable(int pIdProduct)
        {
            try
            {

                string resultEnum = @"  public enum Accesos <br>
        {<br>";
                Models.Data.EkiibrateDBEntities db = new Models.Data.EkiibrateDBEntities(true);
                db.Objeto.Where(x => x.Activo && x.IdProducto == pIdProduct).ToList().ForEach(y =>
                {
                    resultEnum += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + y.Nombre.Replace(" ", "_") + " = " + y.IdObjeto + ",   //" + y.Descripcion + " <br>";
                });
                resultEnum += "}";

                return Json(new { success = true, result = resultEnum });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, result = ex.Message });
            }

        }

        public JsonResult GetPermission(int IdProduct, int? IdPermission)
        {

            Models.Data.EkiibrateDBEntities db = new Models.Data.EkiibrateDBEntities(true);
            var hijos = new List<Objeto>();
            if (IdPermission != null)
            {
                hijos = GetAllChilds((int)IdPermission);
            }
            return Json(db.Objeto.Where(y => y.Activo && y.IdProducto == IdProduct && (IdPermission == null || (y.IdObjeto != IdPermission && hijos.Where(z => z.IdObjeto == y.IdObjeto).Count() == 0)))
                            .Select(x => new DropDownListItem
                            {
                                Text = x.Nombre,
                                Value = x.IdObjeto.ToString()
                            }).OrderBy(e => e.Text).ToList(), JsonRequestBehavior.AllowGet);

        }

        private List<Objeto> GetAllChilds(int idObjeto)
        {
            List<Objeto> result = new List<Objeto>();
            Models.Data.EkiibrateDBEntities db = new Models.Data.EkiibrateDBEntities(true);
            db.Objeto.Where(x => x.Activo && x.IdObjetoPadre == idObjeto).ToList().ForEach(x =>
            {
                result.Add(x);
                result.AddRange(GetAllChilds(x.IdObjeto));
            });


            return result;
        }

        [BarcoSoftUtilidades.Seguridad.BarcoSoftAuthorize(Objeto = (int)Accesos.Objetos)]
        public ActionResult ObjectManager()
        {
            Models.Data.EkiibrateDBEntities db = new Models.Data.EkiibrateDBEntities(true);
            ViewBag.Products = db.Producto.Where(x => x.Activo == true).ToList()
              .Select(x => new DropDownListItem
              {
                  Text = x.Nombre,
                  Value = x.IdProducto.ToString()
              }).OrderBy(e => e.Text).ToList();

            ViewBag.PermissionsParent = db.Objeto.Where(x => x.Activo == true)
                     .Select(x => new DropDownListItem
                     {
                         Text = x.IdObjeto + " | " + x.Nombre,
                         Value = x.IdObjeto.ToString()
                     }).OrderBy(e => e.Text).ToList();
            return View();
        }

        public ActionResult Object_Read([DataSourceRequest] DataSourceRequest request, int pIdProduct)
        {
            Models.Data.EkiibrateDBEntities db = new Models.Data.EkiibrateDBEntities(true);
            return Json(db.Objeto.Where(x => x.Activo && pIdProduct == x.IdProducto).Select(y => new Models.ViewModelObjeto
            {
                IdPermission = y.IdObjeto,
                IdNewPermissionParent = y.IdObjetoPadre,
                IdProduct = y.IdProducto,
                IdPermissionParent = y.IdObjetoPadre,
                Name = y.Nombre,
                ProductName = y.Producto.Nombre,
                Description = y.Descripcion,
                IdOwner = y.Producto.IdPropietario
            }).ToList().
              ToTreeDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Object_Create([DataSourceRequest] DataSourceRequest request, ViewModelObjeto model)
        {

            try
            {
                if (model != null && ModelState.IsValid)
                {
                    Models.Data.EkiibrateDBEntities db = new Models.Data.EkiibrateDBEntities(true);
                    Objeto obj = new Objeto
                    {
                        Activo = true,
                        Descripcion = model.Description,
                        IdObjetoPadre = model.IdNewPermissionParent,
                        IdProducto = model.IdProduct,
                        Nombre = model.Name
                    };
                    db.Objeto.Add(obj);
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
        public ActionResult Object_Update([DataSourceRequest] DataSourceRequest request, ViewModelObjeto model)
        {
            try
            {
                if (model != null && ModelState.IsValid)
                {
                    Models.Data.EkiibrateDBEntities db = new Models.Data.EkiibrateDBEntities(true);
                    Objeto obj = db.Objeto.Where(x => x.IdObjeto == model.IdPermission).FirstOrDefault();
                    obj.Activo = true;
                    obj.Nombre = model.Name;
                    obj.Descripcion = model.Description;
                    obj.IdObjetoPadre = model.IdNewPermissionParent;
                    db.Objeto.Attach(obj);
                    db.Entry(obj).State = EntityState.Modified;
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
        public ActionResult Object_Destroy([DataSourceRequest] DataSourceRequest request, ViewModelObjeto model, bool pOperar)
        {
            try
            {
                if (pOperar && model != null && ModelState.IsValid)
                {
                    Models.Data.EkiibrateDBEntities db = new Models.Data.EkiibrateDBEntities(true);
                    Objeto obj = db.Objeto.Where(x => x.IdObjeto == model.IdPermission).FirstOrDefault();
                    obj.Activo = false;
                    db.Objeto.Attach(obj);
                    db.Entry(obj).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Model", ex.Message);
                //throw new Exception(ex.Message);
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        #endregion

        #region PermisoObjeto
        public ActionResult RoleToPermission(int pIdRole)
        {
            Models.Data.EkiibrateDBEntities db = new Models.Data.EkiibrateDBEntities(true);
            Rol rol = db.Rol.Where(x => x.IdRol == pIdRole).FirstOrDefault();
            return View(rol);
        }

        public JsonResult Read_RoleToPermission([DataSourceRequest] DataSourceRequest request, int? pIdProduct, int? pIdRole)
        {
            if (pIdProduct != null && pIdRole != null)
            {
                List<PermisoObjeto> result = new PermisoObjeto().Get((int)pIdRole, (int)pIdProduct);

                return new JsonNetResult
                {
                    Data = result
                        .ToTreeDataSourceResult(request),
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            else
            {
                List<PermisoObjeto> result = new List<PermisoObjeto>();
                return new JsonNetResult
                {
                    Data = result
                        .ToTreeDataSourceResult(request),
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }

        }


        public JsonResult Update([DataSourceRequest] DataSourceRequest request, EkilibrateUI.Areas.SitioAdministrativo.Models.PermisoObjeto model)
        {
            if (ModelState.IsValid)
            {
                //KatharsisUser userInfo = (KatharsisUser)Session["nombre_usuario"];
                if ((bool)model.TieneAcceso)
                {
                    new PermisoObjeto().Add(model.IdObjeto, model.IdRol, "paguilar");
                }
                else
                {
                    new PermisoObjeto().Delete(model.IdObjeto, model.IdRol, "paguilar");
                }
            }

            return Json(new[] { model }.ToTreeDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public ActionResult OnChangePermission(int pIdRole, int pIdObjeto, bool pTieneAcceso)
        {
            try
            {

                if ((bool)pTieneAcceso)
                {
                    new PermisoObjeto().Add(pIdObjeto, pIdRole, "paguilar");
                }
                else
                {
                    new PermisoObjeto().Delete(pIdObjeto, pIdRole, "paguilar");
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
            return Json(new { success = true, error = "" });

        }

        #endregion

        #region RoleToUsers
        public JsonResult UsersToAsign_Read([DataSourceRequest] DataSourceRequest request, int pIdRole)
        {
            Models.Data.EkiibrateDBEntities db = new Models.Data.EkiibrateDBEntities(true);
            List<ViewModelUsuario> result = db.Usuario.Where(x => db.UsuarioPorRol.Where(y => y.IdUsuario == x.IdUsuario && y.IdRol == pIdRole).Count() == 0)
                //.Select(x => x.CopyPropertiesTo(new ViewModelUsuario())).ToList();
                .Select(x => new ViewModelUsuario
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
                Data = result
                    .ToTreeDataSourceResult(request),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };


        }



        public JsonResult AssignedUsers_Read([DataSourceRequest] DataSourceRequest request, int pIdRole)
        {
            Models.Data.EkiibrateDBEntities db = new Models.Data.EkiibrateDBEntities(true);
            List<ViewModelUsuario> result = db.UsuarioPorRol.Where(x => x.IdRol == pIdRole).Select(x => new ViewModelUsuario
            {
                Activo = x.Usuario.Activo,
                Contraseña = x.Usuario.Contraseña,
                IdPersona = x.Usuario.IdPersona,
                IdTipoUsuario = x.Usuario.IdTipoUsuario,
                IdUsuario = x.Usuario.IdUsuario,
                NombreUsuario = x.Usuario.NombreUsuario,
                GE_Persona = new ViewModelPersona
                {
                    Apellido = x.Usuario.GE_Persona.Apellido,
                    Correo = x.Usuario.GE_Persona.Correo,
                    Direccion = x.Usuario.GE_Persona.Direccion,
                    Extension = x.Usuario.GE_Persona.Extension,
                    Id = x.Usuario.GE_Persona.Id,
                    Nombre = x.Usuario.GE_Persona.Nombre,
                    Puesto = x.Usuario.GE_Persona.Puesto,
                    Telefono = x.Usuario.GE_Persona.Telefono
                }

            }).ToList();
            return new JsonNetResult
            {
                Data = result
                    .ToTreeDataSourceResult(request),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };

        }

        [HttpPost]
        public ActionResult AddUserToRole(int pIdRole, int pIdUser)
        {
            try
            {

                Models.Data.EkiibrateDBEntities db = new Models.Data.EkiibrateDBEntities(true);
                UsuarioPorRol model = new UsuarioPorRol();
                model.IdRol = pIdRole;
                model.IdUsuario = pIdUser;
                model.TransacUser = "paguilar";
                model.TransacDateTime = DateTime.Now;
                db.UsuarioPorRol.Add(model);
                db.SaveChanges();
                return Json(new { success = true, error = "" });
            }
            catch (Exception ex)
            {

                return Json(new { success = false, error = ex.Message });
            }

        }

        [HttpPost]
        public ActionResult DeleteUserToRole(int pIdRole, int pIdUser)
        {
            try
            {

                Models.Data.EkiibrateDBEntities db = new Models.Data.EkiibrateDBEntities(true);
                UsuarioPorRol model = db.UsuarioPorRol.Where(x => x.IdRol == pIdRole && x.IdUsuario == pIdUser).FirstOrDefault();
                db.UsuarioPorRol.Attach(model);
                db.Entry(model).State = EntityState.Deleted;

                HistoricoUsuarioPorRol model2 = new HistoricoUsuarioPorRol();
                model2.IdRol = model.IdRol;
                model2.IdUsuario = model.IdUsuario;
                model2.TransacUser = model.TransacUser;
                model2.TransacDateTime = model.TransacDateTime;
                model2.HistoricTransacUser = "paguilar";
                model2.HistoricTransacDateTime = DateTime.Now;

                db.HistoricoUsuarioPorRol.Add(model2);

                db.SaveChanges();

                return Json(new { success = true, error = "" });
            }
            catch (Exception ex)
            {

                return Json(new { success = false, error = ex.Message });
            }
        }

        #endregion

        #region Encript
        [BarcoSoftUtilidades.Seguridad.BarcoSoftAuthorize(Objeto = (int)Accesos.Encripción)]
        public ActionResult EncryptUtility()
        {
            return View();
        }


        [HttpPost]
        public ActionResult EncryptUtility(EncryptUtility model)
        {

            try
            {
                if (!string.IsNullOrEmpty(model.EncryptString))
                {
                    model.ValueDecript = model.EncryptString.Trim().Decrypt();
                }
                else
                {
                    model.ValueDecript = string.Empty;
                }

                if (!string.IsNullOrEmpty(model.DecryptString))
                {
                    model.ValueEncript = model.DecryptString.Trim().Encrypt();
                }
                else
                {
                    model.ValueEncript = string.Empty;
                }

            }
            catch (Exception ex)
            {
                ViewBag.isError = "Error";
                ViewBag.Error = ex.Message;
            }
            return View(model);
        }
        #endregion

        #region Menu
        public ActionResult Menu(int pIdObject, string pObject)
        {
            Models.Data.EkiibrateDBEntities db = new Models.Data.EkiibrateDBEntities(true);
            var menu = db.Menu.Where(x => x.IdObjeto == pIdObject);//new SecurityBL.General.Menu().GetActive().Where(x => x.IdPermission == pIdPermission);
            if (menu.Count() == 0)
            {
                Models.Data.Menu newMenu = new Models.Data.Menu();
                newMenu.IdObjeto = pIdObject;
                newMenu.Nombre = pObject;
                return PartialView("Menu", newMenu);
            }
            else
            {
                return PartialView("Menu", menu.FirstOrDefault());
            }

        }


        public ActionResult OperarMenu(Models.Data.Menu model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Models.Data.EkiibrateDBEntities db = new Models.Data.EkiibrateDBEntities(true);
                    if (model.IdMenu <= 0)
                    {

                        db.Menu.Add(model);
                        db.SaveChanges();
                        //model.Add();
                    }
                    else
                    {
                        var original = db.Menu.Find(model.IdMenu);

                        if (original != null)
                        {
                            db.Entry(original).CurrentValues.SetValues(model);
                            db.SaveChanges();
                        }
                        //    model.Update();
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("s", ex);

            }
            return PartialView("Menu", model);
        }



        public ActionResult MenuImages([DataSourceRequest] DataSourceRequest request)
        {
            List<Models.Data.Menu> lstImages = new List<Models.Data.Menu>();
            //string[] files = Directory.GetFiles(Server.MapPath("~/assets/img/icons/"), "*.png").Select(path => Path.GetFileName(path))
            //    .ToArray();

            //foreach (string s in files)
            //{
            //    lstImages.Add(new Models.Data.Menu() { ImageUrl = s });
            //}

            CssParser css = new CssParser();
            css.AddStyleSheet(Server.MapPath("~/assets/css/ekilibrate-icons.css"));
            foreach (KeyValuePair<string, CssParser.StyleClass> s in css.Styles)
            {
                lstImages.Add(new Models.Data.Menu() { ImageUrl = s.Key });
            }

            css.AddStyleSheet(Server.MapPath("~/assets/css/font-awesome.min.css"));
            foreach (KeyValuePair<string, CssParser.StyleClass> s in css.Styles)
            {
                lstImages.Add(new Models.Data.Menu() { ImageUrl = s.Key.Split('-')[0].Replace(".", "") + " " + s.Key.Replace(".", "").Replace(":before", "") });
            }
            return Json(lstImages.ToDataSourceResult(request));
        }

        #endregion

    }
    public class CssParser
    {
        private List<string> _styleSheets;
        private SortedList<string, StyleClass> _scc;
        public SortedList<string, StyleClass> Styles
        {
            get { return this._scc; }
            set { this._scc = value; }
        }

        public CssParser()
        {
            this._styleSheets = new List<string>();
            this._scc = new SortedList<string, StyleClass>();
        }

        public void AddStyleSheet(string path)
        {
            this._styleSheets.Add(path);
            ProcessStyleSheet(path);
        }

        public string GetStyleSheet(int index)
        {
            return this._styleSheets[index];
        }

        private void ProcessStyleSheet(string path)
        {
            string content = CleanUp(File.ReadAllText(path));
            string[] parts = content.Split('}');
            foreach (string s in parts)
            {
                if (CleanUp(s).IndexOf('{') > -1)
                {
                    FillStyleClass(s);
                }
            }
        }

        private void FillStyleClass(string s)
        {
            StyleClass sc = null;
            string[] parts = s.Split('{');
            string styleName = CleanUp(parts[0]).Trim().ToLower();

            if (this._scc.ContainsKey(styleName))
            {
                sc = this._scc[styleName];
                this._scc.Remove(styleName);
            }
            else
            {
                sc = new StyleClass();
            }

            sc.Name = styleName;

            string[] atrs = CleanUp(parts[1]).Replace("}", "").Split(';');
            foreach (string a in atrs)
            {
                if (a.Contains(":"))
                {
                    string _key = a.Split(':')[0].Trim().ToLower();
                    if (sc.Attributes.ContainsKey(_key))
                    {
                        sc.Attributes.Remove(_key);
                    }
                    sc.Attributes.Add(_key, a.Split(':')[1].Trim().ToLower());
                }
            }
            this._scc.Add(sc.Name, sc);
        }

        private string CleanUp(string s)
        {
            string temp = s;
            string reg = "(/\\*(.|[\r\n])*?\\*/)|(//.*)";
            Regex r = new Regex(reg);
            temp = r.Replace(temp, "");
            temp = temp.Replace("\r", "").Replace("\n", "");
            return temp;
        }

        public class StyleClass
        {
            private string _name = string.Empty;
            public string Name
            {
                get { return _name; }
                set { _name = value; }
            }

            private SortedList<string, string> _attributes = new SortedList<string, string>();
            public SortedList<string, string> Attributes
            {
                get { return _attributes; }
                set { _attributes = value; }
            }
        }
    }
}