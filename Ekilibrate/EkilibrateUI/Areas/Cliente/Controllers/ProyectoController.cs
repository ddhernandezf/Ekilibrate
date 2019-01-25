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
using BarcoSoftUtilidades;
using Ekilibrate.Model.Services;
using Ekilibrate.Model.Entity.Proyecto;
using Ekilibrate.Model.Entity.Participante;
using System.IO;
using System.Data;
using System.Data.OleDb;
using BarcoSoftUtilidades.Seguridad;
using Excel;

namespace EkilibrateUI.Areas.Cliente.Controllers
{
    [BarcoSoftAuthorize]
    public class ProyectoController : Controller
    {
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

                    Ekilibrate.Model.Entity.Administrador.clsEmpresaFiltro objFiltro = new Ekilibrate.Model.Entity.Administrador.clsEmpresaFiltro();
                    middleTier = scope.Resolve<Ekilibrate.Model.Services.Administrador.IDataRetriever>();
                    var Result = await middleTier.GetEmpresas(objFiltro);
                    ViewBag.Empresas = Result
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
            }

            return View();
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
                    BarcoSoftUtilidades.Seguridad.Usuario user = this.HttpContext.GetActualUser();
                    var middleTier = scope.Resolve<Ekilibrate.Model.Services.Administrador.IDataRetriever>();
                    var Result = await middleTier.GetProyectosEmpresa(user.Empresa.IdEmpresa);
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

        #region ProyectoSalon
        public async Task<ActionResult> ProyectoSalon_Read([DataSourceRequest] DataSourceRequest request, int pIdProyecto, int pIdEmpresa)
        {
            try
            {
                IEnumerable<Ekilibrate.Model.Entity.Administrador.clsProyectoSalon> Result = new List<Ekilibrate.Model.Entity.Administrador.clsProyectoSalon>();
                if (pIdProyecto > 0)
                {
                    using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                    {
                        Ekilibrate.Model.Entity.Administrador.clsProyectoSalonFiltro objFiltro = new Ekilibrate.Model.Entity.Administrador.clsProyectoSalonFiltro();
                        objFiltro.IdEmpresa = pIdEmpresa;
                        objFiltro.IdProyecto = pIdProyecto;
                        var middleTier = scope.Resolve<Ekilibrate.Model.Services.Administrador.IDataRetriever>();
                        Result = await middleTier.GetSalonesProyecto(objFiltro);
                    }
                }

                return Json(Result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
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

        public async Task<ActionResult> ProyectoContacto_Read([DataSourceRequest] DataSourceRequest request, int pIdProyecto, int pIdEmpresa)
        {
            try
            {
                using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                {
                    Ekilibrate.Model.Entity.Administrador.clsProyectoContactoFiltro objFiltro = new Ekilibrate.Model.Entity.Administrador.clsProyectoContactoFiltro();
                    objFiltro.IdEmpresa = pIdEmpresa;
                    objFiltro.IdProyecto = pIdProyecto;
                    var middleTier = scope.Resolve<Ekilibrate.Model.Services.Administrador.IDataRetriever>();
                    var Result = await middleTier.GetContactosProyecto(objFiltro);
                    return Json(Result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
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

        public async Task<ActionResult> ProyectoArea_Read([DataSourceRequest] DataSourceRequest request, int pIdProyecto)
        {
            try
            {
                using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                {
                    var middleTier = scope.Resolve<Ekilibrate.Model.Services.Administrador.IDataRetriever>();
                    var Result = await middleTier.GetAreasProyecto(pIdProyecto);
                    return Json(Result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
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
        public async Task<ActionResult> ProyectoTaller_Read([DataSourceRequest] DataSourceRequest request, int pIdProyecto)
        {
            try
            {
                using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                {
                    Ekilibrate.Model.Entity.Administrador.clsTallerFiltro objFiltro = new Ekilibrate.Model.Entity.Administrador.clsTallerFiltro();
                    objFiltro.IdProyecto = pIdProyecto;
                    var middleTier = scope.Resolve<Ekilibrate.Model.Services.Administrador.IDataRetriever>();
                    var Result = await middleTier.GetTaller(objFiltro);
                    return Json(Result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return Json(new List<Ekilibrate.Model.Entity.Administrador.clsProyectoArea>().ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public async Task<ActionResult> CreateTaller([DataSourceRequest] DataSourceRequest request, Ekilibrate.Model.Entity.Administrador.clsTallerVista model, int pIdProyecto, FormCollection frm)
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
                   Value = x.Id.ToString()
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

        public async Task<JsonResult> GetCATaller()
        {
            using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                Ekilibrate.Model.Entity.Catalogos.clsTallerFiltro filtro = new Ekilibrate.Model.Entity.Catalogos.clsTallerFiltro { ProyectoId = null };
                var middleTier = scope.Resolve<Ekilibrate.Model.Services.Administrador.IDataRetriever>();
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
        #endregion

        /// <summary>
        /// Upload selected Excel files.
        /// </summary>
        [AcceptVerbs(HttpVerbs.Post)]
        public async Task<ActionResult> Submit(IEnumerable<HttpPostedFileBase> files1, int pProyectoId)
        {
            try
            {
                if (files1 != null)
                {
                    string fileName;
                    string filepath;
                    string fileExtension;

                    foreach (var f in files1)
                    {
                        //Set file details.
                        SetFileDetails(f, out fileName, out filepath, out fileExtension);

                        IExcelDataReader excelReader;

                        if (fileExtension.EndsWith("xls"))
                        {
                            excelReader = ExcelReaderFactory.CreateBinaryReader(f.InputStream);
                        }
                        else
                        {
                            if (fileExtension.EndsWith("xlsx"))
                            {
                                excelReader = ExcelReaderFactory.CreateOpenXmlReader(f.InputStream);
                            }
                            else throw new Exception("");
                        }

                        excelReader.IsFirstRowAsColumnNames = true;
                        DataSet DSExcel = excelReader.AsDataSet();

                        List<Ekilibrate.Model.Entity.Participante.clsParticipante> Participantes = GetSetUploadExcelData(DSExcel);

                        using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                        {
                            var middleTier = scope.Resolve<Ekilibrate.Model.Services.Cliente.IDataInjector>();
                            await middleTier.CargarParticipantes(pProyectoId, Participantes);
                        }
                    }
                }
                return Content(string.Empty);
            }
            catch (Exception e)
            {
                return Content(e.Message);
            }

        }

        /// <summary>
        /// This method is used to get the file details and set.
        /// </summary>
        private static void SetFileDetails(HttpPostedFileBase f, out string fileName, out string filepath, out string fileExtension)
        {
            fileName = Path.GetFileName(f.FileName);
            fileExtension = Path.GetExtension(f.FileName);
            filepath = Path.GetFullPath(f.FileName);
        }

        private List<Ekilibrate.Model.Entity.Participante.clsParticipante> GetSetUploadExcelData(DataSet data)
        {
            List<Ekilibrate.Model.Entity.Participante.clsParticipante> uploadExl = new List<Ekilibrate.Model.Entity.Participante.clsParticipante>();
            if (data.Tables.Count > 0)
            {
                for (int t = 0; t < data.Tables.Count; t++)
                {
                    for (int i = 0; i < data.Tables[t].Rows.Count; i++)
                    {
                        if (data.Tables[t].Rows[i]["Primer Nombre"].ToString().Length > 0)
                        {
                            Ekilibrate.Model.Entity.Participante.clsParticipante Persona = new Ekilibrate.Model.Entity.Participante.clsParticipante();
                            if (data.Tables[t].Columns.Contains("Correlativo")) Persona.No = Convert.ToInt32(data.Tables[t].Rows[i]["Correlativo"]);
                            if (data.Tables[t].Columns.Contains("Primer Nombre")) Persona.PrimerNombre = Convert.ToString(data.Tables[t].Rows[i]["Primer Nombre"]);
                            if (data.Tables[t].Columns.Contains("Segundo Nombre")) Persona.SegundoNombre = Convert.ToString(data.Tables[t].Rows[i]["Segundo Nombre"]);
                            if (data.Tables[t].Columns.Contains("Primer Apellido")) Persona.PrimerApellido = Convert.ToString(data.Tables[t].Rows[i]["Primer Apellido"]);
                            if (data.Tables[t].Columns.Contains("Segundo Apellido")) Persona.SegundoApellido = Convert.ToString(data.Tables[t].Rows[i]["Segundo Apellido"]);
                            if (data.Tables[t].Columns.Contains("Apellido de Casada")) Persona.ApellidoCasada = Convert.ToString(data.Tables[t].Rows[i]["Apellido de Casada"]);
                            if (data.Tables[t].Columns.Contains("Correo")) Persona.Correo = Convert.ToString(data.Tables[t].Rows[i]["Correo"]);
                            if (data.Tables[t].Columns.Contains("Código País Móvil")) Persona.Telefono = Convert.ToString(data.Tables[t].Rows[i]["Código País Móvil"]);
                            if (data.Tables[t].Columns.Contains("Teléfono Móvil")) Persona.Telefono = Convert.ToString(data.Tables[t].Rows[i]["Teléfono Móvil"]);
                            if (data.Tables[t].Columns.Contains("Código País Teléfono")) Persona.Telefono = Convert.ToString(data.Tables[t].Rows[i]["Código País Teléfono"]);
                            if (data.Tables[t].Columns.Contains("Teléfono Of.")) Persona.Telefono = Convert.ToString(data.Tables[t].Rows[i]["Teléfono Of."]);
                            if (data.Tables[t].Columns.Contains("Extensión")) Persona.Extension = Convert.ToString(data.Tables[t].Rows[i]["Extensión"]);
                            if (data.Tables[t].Columns.Contains("Departamento")) Persona.Departamento = Convert.ToString(data.Tables[t].Rows[i]["Departamento"]);
                            if (data.Tables[t].Columns.Contains("Puesto")) Persona.Puesto = Convert.ToString(data.Tables[t].Rows[i]["Puesto"]);
                            if (data.Tables[t].Columns.Contains("Sexo")) Persona.Sexo = Convert.ToString(data.Tables[t].Rows[i]["Sexo"]);
                            if (data.Tables[t].Columns.Contains("Fecha de Nacimiento") && data.Tables[t].Rows[i]["Fecha de Nacimiento"].ToString().Length > 0) Persona.FechaNacimiento = Convert.ToDateTime(data.Tables[t].Rows[i]["Fecha de Nacimiento"]);
                            if (data.Tables[t].Columns.Contains("Grupo")) Persona.Grupo = Convert.ToString(data.Tables[t].Rows[i]["Grupo"]);
                            if (data.Tables[t].Columns.Contains("Compa") && data.Tables[t].Rows[i]["Compa"].ToString().Length > 0) Persona.Compa = Convert.ToInt32(data.Tables[t].Rows[i]["Compa"]);
                            uploadExl.Add(Persona);
                        }
                    }
                }
            }
            return uploadExl;
        }

        [HttpPost]
        public async Task<ActionResult> FinalizarCarga(int pProyectoId)
        {
            try
            {
                using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                {
                    var middleTier = scope.Resolve<Ekilibrate.Model.Services.Administrador.IDataInjector>();
                    await middleTier.FinalizarCarga(pProyectoId);
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