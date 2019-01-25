using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac;
using System.Threading.Tasks;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using Ekilibrate.Model.Common;
using BarcoSoftUtilidades.Seguridad;
using System.IO;

namespace EkilibrateUI.Areas.Administrador.Controllers
{

    [BarcoSoftAuthorize]
    public class ProyectoController : Controller
    {
        // GET: Administrador/Proyecto

        [BarcoSoftUtilidades.Seguridad.BarcoSoftAuthorize(Objeto = (int)Accesos.Proyectos)]
        public async Task<ActionResult> ColaboradoresPartial()
        {
            return PartialView();
        }

        [BarcoSoftUtilidades.Seguridad.BarcoSoftAuthorize(Objeto = (int)Accesos.Proyectos)]
        public async Task<ActionResult> AreasPartial()
        {
            return PartialView();
        }

        [BarcoSoftUtilidades.Seguridad.BarcoSoftAuthorize(Objeto = (int)Accesos.Proyectos)]
        public async Task<ActionResult> TalleresPartial()
        {
            return PartialView();
        }

        [BarcoSoftUtilidades.Seguridad.BarcoSoftAuthorize(Objeto = (int)Accesos.Proyectos)]
        public async Task<ActionResult> SalonesPartial()
        {
            return PartialView();
        }

        [BarcoSoftUtilidades.Seguridad.BarcoSoftAuthorize(Objeto = (int)Accesos.Proyectos)]
        public async Task<ActionResult> ContactoPartial()
        {
            return PartialView();
        }
        [BarcoSoftUtilidades.Seguridad.BarcoSoftAuthorize(Objeto = (int)Accesos.Proyectos)]
        public async Task<ActionResult> Index()
        {
            try
            {
                using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                {

                    Ekilibrate.Model.Entity.Administrador.clsColaboradorFiltro objFiltroColaborador = new Ekilibrate.Model.Entity.Administrador.clsColaboradorFiltro();
                    var middleTier = scope.Resolve<Ekilibrate.Model.Services.Administrador.IDataRetriever>();
                    var Result1 = await middleTier.GetColaborador(objFiltroColaborador);
                    ViewBag.ColaboradorFacilitador = Result1.Where(x => x.Facilitador)
                   .Select(x => new DropDownListItem
                   {
                       Text = x.PrimerNombre + " " + x.PrimerApellido,
                       Value = x.Id.ToString()
                   }).OrderBy(e => e.Text).ToList();

                    Ekilibrate.Model.Entity.Catalogos.clsAreaFiltro areaFiltro = new Ekilibrate.Model.Entity.Catalogos.clsAreaFiltro();
                    middleTier = scope.Resolve<Ekilibrate.Model.Services.Administrador.IDataRetriever>();
                    var result6 = await middleTier.GetArea(areaFiltro);
                    ViewBag.Areas = result6
                   .Select(x => new DropDownListItem
                   {
                       Text = x.Nombre,
                       Value = x.Id.ToString()
                   }).OrderBy(e => e.Text).ToList();

                    Ekilibrate.Model.Entity.Administrador.clsEmpresaFiltro objFiltro = new Ekilibrate.Model.Entity.Administrador.clsEmpresaFiltro();
                    middleTier = scope.Resolve<Ekilibrate.Model.Services.Administrador.IDataRetriever>();
                    var Result = await middleTier.GetEmpresas(objFiltro);
                    ViewBag.Empresas = Result
                   .Select(x => new DropDownListItem
                   {
                       Text = x.Nombre,
                       Value = x.Id.ToString()
                   }).OrderBy(e => e.Text).ToList();

                    middleTier = scope.Resolve<Ekilibrate.Model.Services.Administrador.IDataRetriever>();
                    var result3 = await middleTier.GetTipoProyecto();
                    ViewBag.TipoProyecto = result3
                       .Select(x => new DropDownListItem
                       {
                           Text = x.Nombre,
                           Value = x.Id.ToString()
                       }).OrderBy(e => e.Text).ToList();




                    Ekilibrate.Model.Administrador.clsClienteRolFiltro filtroRol = new Ekilibrate.Model.Administrador.clsClienteRolFiltro();
                    var middleTier2 = scope.Resolve<Ekilibrate.Model.Services.Administrador.IDataRetriever>();
                    ViewBag.ClienteRol = await middleTier2.GetClienteRol(filtroRol);
                }
            }
            catch (Exception ex)
            {
                ViewBag.ClienteRol = new List<Ekilibrate.Model.Administrador.clsClienteRolBase>();
                ViewBag.ColaboradorFacilitador = new List<DropDownListItem>();
                ViewBag.Areas = new List<DropDownListItem>();
                ViewBag.Empresas = new List<DropDownListItem>();
                ViewBag.TipoProyecto = new List<DropDownListItem>();

            }

            return View();
        }

        [BarcoSoftAuthorize]
        [HttpPost]
        public ActionResult SubmitProjectImage(IEnumerable<HttpPostedFileBase> files, int? IdProyecto)
        {
            if (files != null && files.Count() > 0)
            {
                var file = files.FirstOrDefault();
                string ext = System.IO.Path.GetExtension(file.FileName);
                var destinationPath = Path.Combine(Server.MapPath("~/Uploads/Proyectos"), IdProyecto.ToString() + ext);
                file.SaveAs(destinationPath);
            }
            // Return an empty string to signify success
            return Content("");
        }



        /// <summary>
        /// Request de la información de los proyectos.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ActionResult> Read([DataSourceRequest] DataSourceRequest request)
        {
            try
            {
                using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                {

                    var middleTier = scope.Resolve<Ekilibrate.Model.Services.Administrador.IDataRetriever>();
                    var Result = await middleTier.GetProyectos();
                    return Json(Result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return Json(new List<Ekilibrate.Model.Entity.Administrador.clsProyectoBase>().ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public async Task<ActionResult> Create([DataSourceRequest] DataSourceRequest request, Ekilibrate.Model.Entity.Administrador.clsProyecto model)
        {
            try
            {
                model.HoraFinConsultas = model.DHoraFinConsultas.TimeOfDay;
                model.HoraInicioConsultas = model.DHoraInicioConsultas.TimeOfDay;
                model.DuracionConsultas = model.DDuracionConsultas.TimeOfDay;
                
                
                if (model != null && ModelState.IsValid)
                {
                    using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                    {
                        var middleTier = scope.Resolve<Ekilibrate.Model.Services.Administrador.IDataInjector>();
                        var Result = await middleTier.CreateProyecto(model);
                        model.Id = Result;
                        if (System.IO.File.Exists(Path.Combine(Server.MapPath("~/Uploads/Proyectos/TempProyecto.png"))))
                        {
                            System.IO.File.Move(Path.Combine(Server.MapPath("~/Uploads/Proyectos/TempProyecto.png")),
                                        Path.Combine(Server.MapPath("~/Uploads/Proyectos"), model.Id.ToString() + ".png")); 
                        }
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
        public async Task<ActionResult> Update([DataSourceRequest] DataSourceRequest request, Ekilibrate.Model.Entity.Administrador.clsProyecto model)
        {
            try
            {
                model.HoraFinConsultas = model.DHoraFinConsultas.TimeOfDay;
                model.HoraInicioConsultas = model.DHoraInicioConsultas.TimeOfDay;
                model.DuracionConsultas = model.DDuracionConsultas.TimeOfDay;

                if (model != null && ModelState.IsValid)
                {
                    using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                    {
                        var middleTier = scope.Resolve<Ekilibrate.Model.Services.Administrador.IDataInjector>();
                        await middleTier.UpdateProyecto(model);
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
        public async Task<ActionResult> Delete([DataSourceRequest] DataSourceRequest request, Ekilibrate.Model.Entity.Administrador.clsProyecto model)
        {
            try
            {


                if (model != null && model.Id > 0)
                {
                    using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                    {
                        var middleTier = scope.Resolve<Ekilibrate.Model.Services.Administrador.IDataInjector>();
                        await middleTier.DeleteProyecto(model.Id);
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        #region ProyectoSalon
        public async Task<ActionResult> ProyectoSalon_Read([DataSourceRequest] DataSourceRequest request, int? pIdProyecto, int? pIdEmpresa)
        {
            try
            {
                if (pIdProyecto != null && pIdEmpresa != null)
                {
                    using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                    {
                        Ekilibrate.Model.Entity.Administrador.clsProyectoSalonFiltro objFiltro = new Ekilibrate.Model.Entity.Administrador.clsProyectoSalonFiltro();
                        objFiltro.IdEmpresa = (int)pIdEmpresa;
                        objFiltro.IdProyecto = (int)pIdProyecto;
                        var middleTier = scope.Resolve<Ekilibrate.Model.Services.Administrador.IDataRetriever>();
                        var Result = await middleTier.GetSalonesProyecto(objFiltro);
                        return Json(Result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new List<Ekilibrate.Model.Entity.Administrador.clsProyectoSalon>().ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return Json(new List<Ekilibrate.Model.Entity.Administrador.clsProyectoSalonBase>().ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult AddProyectoSalon(int pIdProyecto, int pIdSalon)
        {
            try
            {
                Ekilibrate.Model.Entity.Administrador.clsProyectoSalon model = new Ekilibrate.Model.Entity.Administrador.clsProyectoSalon();
                model.ProyectoId = pIdProyecto;
                model.SalonId = pIdSalon;
                if (model != null && ModelState.IsValid)
                {
                    using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                    {
                        var middleTier = scope.Resolve<Ekilibrate.Model.Services.Administrador.IDataInjector>();
                        middleTier.AddSalonProyecto(model);
                    }
                }
                return Json(new { success = true, error = "" });
            }
            catch (Exception ex)
            {

                return Json(new { success = false, error = ex.Message });
            }
        }


        [HttpPost]
        public ActionResult DeleteProyectoSalon(int pIdProyecto, int pIdSalon)
        {
            try
            {
                Ekilibrate.Model.Entity.Administrador.clsProyectoSalon model = new Ekilibrate.Model.Entity.Administrador.clsProyectoSalon();
                model.ProyectoId = pIdProyecto;
                model.SalonId = pIdSalon;
                if (model != null && ModelState.IsValid)
                {
                    using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                    {
                        var middleTier = scope.Resolve<Ekilibrate.Model.Services.Administrador.IDataInjector>();
                        middleTier.DeleteSalonProyecto(model);
                    }
                }
                return Json(new { success = true, error = "" });
            }
            catch (Exception ex)
            {

                return Json(new { success = false, error = ex.Message });
            }
        }
        #endregion

        #region ProyectoContacto

        public async Task<ActionResult> ProyectoContacto_Read([DataSourceRequest] DataSourceRequest request, int? pIdProyecto, int? pIdEmpresa)
        {
            try
            {
                if (pIdEmpresa != null && pIdProyecto != null)
                {
                    using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                    {
                        Ekilibrate.Model.Entity.Administrador.clsProyectoContactoFiltro objFiltro = new Ekilibrate.Model.Entity.Administrador.clsProyectoContactoFiltro();
                        objFiltro.IdEmpresa = (int)pIdEmpresa;
                        objFiltro.IdProyecto = (int)pIdProyecto;
                        var middleTier = scope.Resolve<Ekilibrate.Model.Services.Administrador.IDataRetriever>();
                        var Result = await middleTier.GetContactosProyecto(objFiltro);
                        return Json(Result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new List<Ekilibrate.Model.Entity.Administrador.clsProyectoContacto>().ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return Json(new List<Ekilibrate.Model.Entity.Administrador.clsProyectoSalonBase>().ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult AddProyectoContacto(int pIdProyecto, int pIdContacto)
        {
            try
            {
                Ekilibrate.Model.Entity.Administrador.clsProyectoContacto model = new Ekilibrate.Model.Entity.Administrador.clsProyectoContacto();
                model.ProyectoId = pIdProyecto;
                model.ContactoId = pIdContacto;
                if (model != null && ModelState.IsValid)
                {
                    using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                    {
                        var middleTier = scope.Resolve<Ekilibrate.Model.Services.Administrador.IDataInjector>();
                        middleTier.AddContactoProyecto(model);
                    }
                }
                return Json(new { success = true, error = "" });
            }
            catch (Exception ex)
            {

                return Json(new { success = false, error = ex.Message });
            }
        }


        [HttpPost]
        public ActionResult DeleteProyectoContacto(int pIdProyecto, int pIdContacto)
        {
            try
            {
                Ekilibrate.Model.Entity.Administrador.clsProyectoContacto model = new Ekilibrate.Model.Entity.Administrador.clsProyectoContacto();
                model.ProyectoId = pIdProyecto;
                model.ContactoId = pIdContacto;
                if (model != null && ModelState.IsValid)
                {
                    using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                    {
                        var middleTier = scope.Resolve<Ekilibrate.Model.Services.Administrador.IDataInjector>();
                        middleTier.DeleteContactoProyecto(model);
                    }
                }
                return Json(new { success = true, error = "" });
            }
            catch (Exception ex)
            {

                return Json(new { success = false, error = ex.Message });
            }
        }
        #endregion

        #region Areas
        [HttpPost]
        public ActionResult AddProyectoArea(int pIdProyecto, int pIdArea)
        {
            try
            {
                Ekilibrate.Model.Entity.Administrador.clsProyectoArea model = new Ekilibrate.Model.Entity.Administrador.clsProyectoArea();
                model.ProyectoId = pIdProyecto;
                model.AreaId = pIdArea;
                if (model != null && ModelState.IsValid)
                {
                    using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                    {
                        var middleTier = scope.Resolve<Ekilibrate.Model.Services.Administrador.IDataInjector>();
                        middleTier.AddAreaProyecto(model);
                    }
                }
                return Json(new { success = true, error = "" });
            }
            catch (Exception ex)
            {

                return Json(new { success = false, error = ex.Message });
            }

        }

        [HttpPost]
        public ActionResult DeleteProyectoArea(int pIdProyecto, int pIdArea)
        {
            try
            {
                Ekilibrate.Model.Entity.Administrador.clsProyectoArea model = new Ekilibrate.Model.Entity.Administrador.clsProyectoArea();
                model.ProyectoId = pIdProyecto;
                model.AreaId = pIdArea;
                if (model != null && ModelState.IsValid)
                {
                    using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                    {
                        var middleTier = scope.Resolve<Ekilibrate.Model.Services.Administrador.IDataInjector>();
                        middleTier.DeleteAreaProyecto(model);
                    }
                }
                return Json(new { success = true, error = "" });
            }
            catch (Exception ex)
            {

                return Json(new { success = false, error = ex.Message });
            }

        }

        public async Task<ActionResult> ProyectoArea_Read([DataSourceRequest] DataSourceRequest request, int? pIdProyecto)
        {
            try
            {
                if (pIdProyecto != null)
                {
                    using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                    {
                        var middleTier = scope.Resolve<Ekilibrate.Model.Services.Administrador.IDataRetriever>();
                        var Result = await middleTier.GetAreasProyecto((int)pIdProyecto);
                        return Json(Result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new List<Ekilibrate.Model.Entity.Administrador.clsProyectoArea>().ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return Json(new List<Ekilibrate.Model.Entity.Administrador.clsProyectoArea>().ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Taller
        public async Task<ActionResult> ProyectoTaller_Read([DataSourceRequest] DataSourceRequest request, int? pIdProyecto)
        {
            try
            {
                if (pIdProyecto != null)
                {
                    using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                    {
                        Ekilibrate.Model.Entity.Administrador.clsTallerFiltro objFiltro = new Ekilibrate.Model.Entity.Administrador.clsTallerFiltro();
                        objFiltro.IdProyecto = (int)pIdProyecto;
                        var middleTier = scope.Resolve<Ekilibrate.Model.Services.Administrador.IDataRetriever>();
                        var Result = await middleTier.GetTaller(objFiltro);
                        return Json(Result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
                    }

                }
                else
                {
                    return Json(new List<Ekilibrate.Model.Entity.Administrador.clsTallerVista>().ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return Json(new List<Ekilibrate.Model.Entity.Administrador.clsProyectoArea>().ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public async Task<ActionResult> CreateTaller([DataSourceRequest] DataSourceRequest request, Ekilibrate.Model.Entity.Administrador.clsTallerVista model, int pIdProyecto)
        {
            try
            {
                model.ProyectoId = pIdProyecto;
                model.HoraInicio = model.DHoraInicio.TimeOfDay;
                model.HoraFin = model.DHoraFin.TimeOfDay;
                model.DuracionSesiones = model.DDuracionSesiones.TimeOfDay;
                if (model != null && ModelState.IsValid)
                {
                    using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                    {
                        var middleTier = scope.Resolve<Ekilibrate.Model.Services.Administrador.IDataInjector>();
                        int id = await middleTier.CreateTaller(model);
                        model.Id = id;
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
        public async Task<ActionResult> UpdateTaller([DataSourceRequest] DataSourceRequest request, Ekilibrate.Model.Entity.Administrador.clsTallerVista model, int pIdProyecto)
        {
            try
            {
                model.ProyectoId = pIdProyecto;
                model.HoraInicio = model.DHoraInicio.TimeOfDay;
                model.HoraFin = model.DHoraFin.TimeOfDay;
                model.DuracionSesiones = model.DDuracionSesiones.TimeOfDay;
                if (model != null && ModelState.IsValid)
                {
                    using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                    {
                        var middleTier = scope.Resolve<Ekilibrate.Model.Services.Administrador.IDataInjector>();
                        await middleTier.UpdateTaller(model);

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
        public async Task<ActionResult> DeleteTaller([DataSourceRequest] DataSourceRequest request, Ekilibrate.Model.Entity.Administrador.clsTallerVista model, int pIdProyecto)
        {
            try
            {
                model.ProyectoId = pIdProyecto;
                model.HoraInicio = model.DHoraInicio.TimeOfDay;
                model.HoraFin = model.DHoraFin.TimeOfDay;
                model.DuracionSesiones = model.DDuracionSesiones.TimeOfDay;
                if (model != null && ModelState.IsValid)
                {
                    using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                    {
                        var middleTier = scope.Resolve<Ekilibrate.Model.Services.Administrador.IDataInjector>();
                        await middleTier.DeleteTaller(model);
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }
        #endregion

        public async Task<JsonResult> GetGrupo(int? pIdProyecto)
        {
            using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                Ekilibrate.Model.Entity.Administrador.clsGrupoFiltro grupoFiltro = new Ekilibrate.Model.Entity.Administrador.clsGrupoFiltro();
                grupoFiltro.ProyectoId = (int)pIdProyecto;
                var middleTier = scope.Resolve<Ekilibrate.Model.Services.Administrador.IDataRetriever>();
                var result1 = await middleTier.GetGrupo(grupoFiltro);
                return Json(result1
               .Select(x => new DropDownListItem
               {
                   Text = x.Nombre,
                   Value = x.ToString()
               }).OrderBy(e => e.Text).ToList(), JsonRequestBehavior.AllowGet);
            }
        }

        public async Task<JsonResult> GetSalon(int? pIdProyecto)
        {
            using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                Ekilibrate.Model.Entity.Administrador.clsSalonFiltro grupoFiltro = new Ekilibrate.Model.Entity.Administrador.clsSalonFiltro();

                grupoFiltro.ProyectoId = (int)pIdProyecto;
                var middleTier = scope.Resolve<Ekilibrate.Model.Services.Administrador.IDataRetriever>();
                var result1 = await middleTier.GetSalones(grupoFiltro);
                return Json(result1
               .Select(x => new DropDownListItem
               {
                   Text = x.Nombre,
                   Value = x.Id.ToString()
               }).OrderBy(e => e.Text).ToList(), JsonRequestBehavior.AllowGet);
            }
        }

        public async Task<JsonResult> GetFacilitador(int? pIdProyecto)
        {
            using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                Ekilibrate.Model.Entity.Administrador.clsFacilitadorFiltro objFiltro = new Ekilibrate.Model.Entity.Administrador.clsFacilitadorFiltro();
                objFiltro.ProyectoId = (int)pIdProyecto;
                var middleTier = scope.Resolve<Ekilibrate.Model.Services.Administrador.IDataRetriever>();
                var Result = await middleTier.GetFacilitador(objFiltro);
                return Json(Result
               .Select(x => new DropDownListItem
               {
                   Text = x.NombreColaborador.ToString(),
                   Value = x.ColaboradorId.ToString()
               }).OrderBy(e => e.Text).ToList(), JsonRequestBehavior.AllowGet);
            }
        }

        public async Task<JsonResult> GetArea(int? pIdProyecto)
        {
            using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                Ekilibrate.Model.Entity.Catalogos.clsAreaFiltro areaFiltro = new Ekilibrate.Model.Entity.Catalogos.clsAreaFiltro();
                areaFiltro.ProyectoId = (int)pIdProyecto;
                var middleTier = scope.Resolve<Ekilibrate.Model.Services.Administrador.IDataRetriever>();
                var result2 = await middleTier.GetArea(areaFiltro);
                return Json(result2
               .Select(x => new DropDownListItem
               {
                   Text = x.Nombre,
                   Value = x.Id.ToString()
               }).OrderBy(e => e.Text).ToList(), JsonRequestBehavior.AllowGet);
            }
        }

        public async Task<JsonResult> GetCATaller(int? pIdProyecto)
        {
            using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {

                var middleTier = scope.Resolve<Ekilibrate.Model.Services.Administrador.IDataRetriever>();
                Ekilibrate.Model.Entity.Catalogos.clsTallerFiltro filtro = new Ekilibrate.Model.Entity.Catalogos.clsTallerFiltro { ProyectoId = pIdProyecto };
                var result3 = await middleTier.GetCatalogoTaller(filtro);
                return Json(result3
               .Select(x => new DropDownListItem
               {
                   Text = x.Nombre,
                   Value = x.Id.ToString()
               }).OrderBy(e => e.Text).ToList(), JsonRequestBehavior.AllowGet);
            }
        }

        public async Task<JsonResult> GetEmpresa()
        {
            using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                Ekilibrate.Model.Entity.Administrador.clsEmpresaFiltro objFiltro = new Ekilibrate.Model.Entity.Administrador.clsEmpresaFiltro();
                var middleTier = scope.Resolve<Ekilibrate.Model.Services.Administrador.IDataRetriever>();
                var result3 = await middleTier.GetEmpresas(objFiltro);
                return Json(result3
               .Select(x => new DropDownListItem
               {
                   Text = x.Nombre,
                   Value = x.Id.ToString()
               }).OrderBy(e => e.Text).ToList(), JsonRequestBehavior.AllowGet);
            }
        }

        public async Task<JsonResult> GetTipoProyecto()
        {
            using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                var middleTier = scope.Resolve<Ekilibrate.Model.Services.Administrador.IDataRetriever>();
                var result3 = await middleTier.GetTipoProyecto();
                return Json(result3
               .Select(x => new DropDownListItem
               {
                   Text = x.Nombre,
                   Value = x.Id.ToString()
               }).OrderBy(e => e.Text).ToList(), JsonRequestBehavior.AllowGet);
            }
        }

        public async Task<JsonResult> GetAseguradora()
        {
            using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {

                var middleTier = scope.Resolve<Ekilibrate.Model.Services.Administrador.IDataRetriever>();
                var result3 = await middleTier.GetCatalogoAseguradora();
                return Json(result3
               .Select(x => new DropDownListItem
               {
                   Text = x.Nombre,
                   Value = x.Id.ToString()
               }).OrderBy(e => e.Text).ToList(), JsonRequestBehavior.AllowGet);
            }
        }


        #region Colaboradores
        [BarcoSoftUtilidades.Seguridad.BarcoSoftAuthorize(Objeto = (int)Accesos.Proyectos)]
        public async Task<ActionResult> AsistentePartial()
        {
            using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                Ekilibrate.Model.Entity.Administrador.clsColaboradorFiltro objFiltroColaborador = new Ekilibrate.Model.Entity.Administrador.clsColaboradorFiltro();
                var middleTier = scope.Resolve<Ekilibrate.Model.Services.Administrador.IDataRetriever>();
                var Result1 = await middleTier.GetColaborador(objFiltroColaborador);
                ViewBag.ColaboradorAsistente = Result1.Where(x => x.Asistente)
                 .Select(x => new DropDownListItem
                 {
                     Text = x.Nombre + " " + x.Apellido,
                     Value = x.Id.ToString()
                 }).OrderBy(e => e.Text).ToList();
            }
            return PartialView();
        }
        [BarcoSoftUtilidades.Seguridad.BarcoSoftAuthorize(Objeto = (int)Accesos.Proyectos)]
        public async Task<ActionResult> EnfermeraPartial()
        {
            using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                Ekilibrate.Model.Entity.Administrador.clsColaboradorFiltro objFiltroColaborador = new Ekilibrate.Model.Entity.Administrador.clsColaboradorFiltro();
                var middleTier = scope.Resolve<Ekilibrate.Model.Services.Administrador.IDataRetriever>();
                var Result1 = await middleTier.GetColaborador(objFiltroColaborador);
                ViewBag.ColaboradorEnfermera = Result1.Where(x => x.Enfermero)
                .Select(x => new DropDownListItem
                {
                    Text = x.Nombre + " " + x.Apellido,
                    Value = x.Id.ToString()
                }).OrderBy(e => e.Text).ToList();
            }
            return PartialView();
        }

        [BarcoSoftUtilidades.Seguridad.BarcoSoftAuthorize(Objeto = (int)Accesos.Proyectos)]
        public async Task<ActionResult> NutricionistaPartial()
        {
            using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                Ekilibrate.Model.Entity.Administrador.clsColaboradorFiltro objFiltroColaborador = new Ekilibrate.Model.Entity.Administrador.clsColaboradorFiltro();
                var middleTier = scope.Resolve<Ekilibrate.Model.Services.Administrador.IDataRetriever>();
                var Result1 = await middleTier.GetColaborador(objFiltroColaborador);


                middleTier = scope.Resolve<Ekilibrate.Model.Services.Administrador.IDataRetriever>();
                var Result10 = await middleTier.GetRolNutricionista();
                ViewBag.RolNutricionista = Result10
               .Select(x => new DropDownListItem
               {
                   Text = x.Nombre,
                   Value = x.Id.ToString()
               }).OrderBy(e => e.Text).ToList();

                ViewBag.ColaboradorNutricionista = Result1.Where(x => x.Nutricionista)
               .Select(x => new DropDownListItem
               {
                   Text = x.Nombre + " " + x.Apellido,
                   Value = x.Id.ToString()
               }).OrderBy(e => e.Text).ToList();
            }
            return PartialView();
        }
        [BarcoSoftUtilidades.Seguridad.BarcoSoftAuthorize(Objeto = (int)Accesos.Proyectos)]
        public async Task<ActionResult> FacilitadorPartial()
        {
            using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                Ekilibrate.Model.Entity.Administrador.clsColaboradorFiltro objFiltroColaborador = new Ekilibrate.Model.Entity.Administrador.clsColaboradorFiltro();
                var middleTier = scope.Resolve<Ekilibrate.Model.Services.Administrador.IDataRetriever>();
                var Result1 = await middleTier.GetColaborador(objFiltroColaborador);
                ViewBag.ColaboradorFacilitador = Result1.Where(x => x.Facilitador)
               .Select(x => new DropDownListItem
               {
                   Text = x.Nombre + " " + x.Apellido,
                   Value = x.Id.ToString()
               }).OrderBy(e => e.Text).ToList();


                Ekilibrate.Model.Entity.Catalogos.clsAreaFiltro areaFiltro = new Ekilibrate.Model.Entity.Catalogos.clsAreaFiltro();
                middleTier = scope.Resolve<Ekilibrate.Model.Services.Administrador.IDataRetriever>();
                var result6 = await middleTier.GetArea(areaFiltro);
                ViewBag.Areas = result6
               .Select(x => new DropDownListItem
               {
                   Text = x.Nombre,
                   Value = x.Id.ToString()
               }).OrderBy(e => e.Text).ToList();
            }
            return PartialView();
        }

        public async Task<ActionResult> Asistente_Read([DataSourceRequest] DataSourceRequest request, int pIdProyecto)
        {
            try
            {
                using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                {
                    Ekilibrate.Model.Entity.Administrador.clsColaboradorFiltro objFiltroColaborador = new Ekilibrate.Model.Entity.Administrador.clsColaboradorFiltro();
                    var middleTier = scope.Resolve<Ekilibrate.Model.Services.Administrador.IDataRetriever>();
                    var Result1 = await middleTier.GetColaborador(objFiltroColaborador);
                    ViewBag.Colaborador = Result1.Where(x => x.Asistente)
                   .Select(x => new DropDownListItem
                   {
                       Text = x.Nombre,
                       Value = x.Id.ToString()
                   }).OrderBy(e => e.Text).ToList();


                    Ekilibrate.Model.Entity.Administrador.clsAsistenteFiltro objFiltro = new Ekilibrate.Model.Entity.Administrador.clsAsistenteFiltro();
                    objFiltro.ProyectoId = pIdProyecto;
                    middleTier = scope.Resolve<Ekilibrate.Model.Services.Administrador.IDataRetriever>();
                    var Result = await middleTier.GetAsistente(objFiltro);
                    return Json(Result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return Json(new List<Ekilibrate.Model.Entity.Administrador.clsAsistenteBase>().ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public async Task<ActionResult> Asistente_Create([DataSourceRequest] DataSourceRequest request, Ekilibrate.Model.Entity.Administrador.clsAsistenteBase model, int pIdProyecto)
        {
            try
            {
                model.ProyectoId = pIdProyecto;
                if (model != null && ModelState.IsValid)
                {
                    using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                    {
                        var middleTier = scope.Resolve<Ekilibrate.Model.Services.Administrador.IDataInjector>();
                        await middleTier.CreateAsistente(model);
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
        public async Task<ActionResult> Asistente_Destroy([DataSourceRequest] DataSourceRequest request, Ekilibrate.Model.Entity.Administrador.clsAsistenteBase model, int pIdProyecto)
        {
            try
            {
                model.ProyectoId = pIdProyecto;
                if (model != null && ModelState.IsValid)
                {
                    using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                    {
                        var middleTier = scope.Resolve<Ekilibrate.Model.Services.Administrador.IDataInjector>();
                        await middleTier.DeleteAsistente(model);
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }





        public async Task<ActionResult> Nutricionista_Read([DataSourceRequest] DataSourceRequest request, int pIdProyecto)
        {
            try
            {
                using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                {

                    Ekilibrate.Model.Entity.Administrador.clsNutricionistaFiltro objFiltro = new Ekilibrate.Model.Entity.Administrador.clsNutricionistaFiltro();
                    objFiltro.ProyectoId = pIdProyecto;
                    var middleTier = scope.Resolve<Ekilibrate.Model.Services.Administrador.IDataRetriever>();
                    var Result = await middleTier.GetNutricionista(objFiltro);
                    return Json(Result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return Json(new List<Ekilibrate.Model.Entity.Administrador.clsNutricionistaBase>().ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public async Task<ActionResult> Nutricionista_Create([DataSourceRequest] DataSourceRequest request, Ekilibrate.Model.Entity.Administrador.clsNutricionistaBase model, int pIdProyecto)
        {
            try
            {
                model.ProyectoId = pIdProyecto;
                if (model != null && ModelState.IsValid)
                {
                    using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                    {
                        var middleTier = scope.Resolve<Ekilibrate.Model.Services.Administrador.IDataInjector>();
                        await middleTier.CreateNutricionista(model);

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
        public async Task<ActionResult> Nutricionista_Destroy([DataSourceRequest] DataSourceRequest request, Ekilibrate.Model.Entity.Administrador.clsNutricionistaBase model, int pIdProyecto)
        {
            try
            {
                model.ProyectoId = pIdProyecto;
                if (model != null && ModelState.IsValid)
                {
                    using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                    {
                        var middleTier = scope.Resolve<Ekilibrate.Model.Services.Administrador.IDataInjector>();
                        await middleTier.DeleteNutricionista(model);

                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        public async Task<ActionResult> Enfermera_Read([DataSourceRequest] DataSourceRequest request, int pIdProyecto)
        {
            try
            {
                using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                {


                    Ekilibrate.Model.Entity.Administrador.clsEnfermeraFiltro objFiltro = new Ekilibrate.Model.Entity.Administrador.clsEnfermeraFiltro();
                    objFiltro.ProyectoId = pIdProyecto;
                    var middleTier = scope.Resolve<Ekilibrate.Model.Services.Administrador.IDataRetriever>();
                    var Result = await middleTier.GetEnfermera(objFiltro);
                    return Json(Result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return Json(new List<Ekilibrate.Model.Entity.Administrador.clsEnfermeraBase>().ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public async Task<ActionResult> Enfermera_Create([DataSourceRequest] DataSourceRequest request, Ekilibrate.Model.Entity.Administrador.clsEnfermeraBase model, int pIdProyecto)
        {
            try
            {
                model.ProyectoId = pIdProyecto;
                if (model != null && ModelState.IsValid)
                {
                    using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                    {
                        var middleTier = scope.Resolve<Ekilibrate.Model.Services.Administrador.IDataInjector>();
                        await middleTier.CreateEnfermera(model);
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
        public async Task<ActionResult> Enfermera_Destroy([DataSourceRequest] DataSourceRequest request, Ekilibrate.Model.Entity.Administrador.clsEnfermeraBase model, int pIdProyecto)
        {
            try
            {
                model.ProyectoId = pIdProyecto;
                if (model != null && ModelState.IsValid)
                {
                    using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                    {
                        var middleTier = scope.Resolve<Ekilibrate.Model.Services.Administrador.IDataInjector>();
                        await middleTier.DeleteEnfermera(model);
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        public async Task<ActionResult> Facilitador_Read([DataSourceRequest] DataSourceRequest request, int pIdProyecto)
        {
            try
            {
                using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                {

                    Ekilibrate.Model.Entity.Administrador.clsFacilitadorFiltro objFiltro = new Ekilibrate.Model.Entity.Administrador.clsFacilitadorFiltro();
                    objFiltro.ProyectoId = pIdProyecto;
                    var middleTier = scope.Resolve<Ekilibrate.Model.Services.Administrador.IDataRetriever>();
                    var Result = await middleTier.GetFacilitador(objFiltro);
                    return Json(Result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return Json(new List<Ekilibrate.Model.Entity.Administrador.clsFacilitadorBase>().ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public async Task<ActionResult> Facilitador_Create([DataSourceRequest] DataSourceRequest request, Ekilibrate.Model.Entity.Administrador.clsFacilitadorBase model, int pIdProyecto)
        {
            try
            {
                model.ProyectoId = pIdProyecto;
                if (model != null && ModelState.IsValid)
                {
                    using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                    {
                        var middleTier = scope.Resolve<Ekilibrate.Model.Services.Administrador.IDataInjector>();
                        await middleTier.CreateFacilitador(model);
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
        public async Task<ActionResult> Facilitador_Destroy([DataSourceRequest] DataSourceRequest request, Ekilibrate.Model.Entity.Administrador.clsFacilitadorBase model, int pIdProyecto)
        {
            try
            {
                model.ProyectoId = pIdProyecto;
                if (model != null && ModelState.IsValid)
                {
                    using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                    {
                        var middleTier = scope.Resolve<Ekilibrate.Model.Services.Administrador.IDataInjector>();
                        await middleTier.DeleteFacilitador(model);

                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        #endregion

        

        [HttpPost]
        public async Task<ActionResult> Enviar(int pIdProyecto)
        {
            try
            {
                using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                {
                    var middleTier = scope.Resolve<Ekilibrate.Model.Services.Administrador.IDataInjector>();
                    await middleTier.EnviarNotificacion(pIdProyecto);
                    return Json(new { success = true, error = "" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult> Arrancar(int pIdProyecto)
        {
            try
            {
                using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                {
                    var middleTier = scope.Resolve<Ekilibrate.Model.Services.Administrador.IDataInjector>();
                    await middleTier.IniciarProyecto(pIdProyecto);
                    return Json(new { success = true, error = "" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult> PruebaCorreo(int pIdProyecto)
        {
            try
            {
                using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                {
                    var middleTier = scope.Resolve<Ekilibrate.Model.Services.Administrador.IDataInjector>();
                    await middleTier.PruebaCorreo(pIdProyecto);
                    return Json(new { success = true, error = "" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult> AsignarNutricionistas(int pIdProyecto)
        {
            try
            {
                using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                {
                    var middleTier = scope.Resolve<Ekilibrate.Model.Services.Administrador.IDataInjector>();
                    await middleTier.AsignarNutricionistas(pIdProyecto);
                    return Json(new { success = true, error = "" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult> ProgramarCitas(int pIdProyecto)
        {
            try
            {
                using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                {
                    var middleTier = scope.Resolve<Ekilibrate.Model.Services.Administrador.IDataInjector>();
                    await middleTier.ProgramarCitas(pIdProyecto);
                    return Json(new { success = true, error = "" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }

    }
}