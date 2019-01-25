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
using System.IO;
using BarcoSoftUtilidades.Seguridad;

namespace EkilibrateUI.Areas.Administrador.Controllers
{
    [BarcoSoftAuthorize]
    public class EmpresaController : Controller
    {
        // GET: Empresa
        [BarcoSoftUtilidades.Seguridad.BarcoSoftAuthorize(Objeto = (int)Accesos.Empresas)]
        public async Task<ActionResult> Index()
        {
            using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                Ekilibrate.Model.Entity.Administrador.clsEmpresaFiltro objFiltro = new Ekilibrate.Model.Entity.Administrador.clsEmpresaFiltro();
                Ekilibrate.Model.Catalogos.clsTipoUsoSalonFiltro objFiltro2 = new Ekilibrate.Model.Catalogos.clsTipoUsoSalonFiltro();
                Ekilibrate.Model.Entity.Administrador.clsEmpresaFiltro objFiltro3 = new Ekilibrate.Model.Entity.Administrador.clsEmpresaFiltro();

                var middleTier = scope.Resolve<Ekilibrate.Model.Services.Administrador.IDataRetriever>();
                var Result = await middleTier.GetEmpresas(objFiltro);



                var middleTier3 = scope.Resolve<Ekilibrate.Model.Services.Administrador.IDataRetriever>();
                ViewBag.Empresa = await middleTier3.GetEmpresas(objFiltro3);

                var middleTier4 = scope.Resolve<Ekilibrate.Model.Services.Administrador.IDataRetriever>();
                ViewBag.GiroEmpresa = await middleTier4.GetGiroEmpresa();

                return View(Result);
            }
        }

        [BarcoSoftUtilidades.Seguridad.BarcoSoftAuthorize(Objeto = (int)Accesos.Empresas)]
        public async Task<ActionResult> EditSalones()
        {
            using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                Ekilibrate.Model.Catalogos.clsTipoUsoSalonFiltro objFiltro2 = new Ekilibrate.Model.Catalogos.clsTipoUsoSalonFiltro();
                var middleTier2 = scope.Resolve<Ekilibrate.Model.Services.Administrador.IDataRetriever>();
                ViewBag.TipoUsoSalon = await middleTier2.GetTipoUsoSalon(objFiltro2);
            }
            return PartialView();
        }


        [BarcoSoftUtilidades.Seguridad.BarcoSoftAuthorize(Objeto = (int)Accesos.Empresas)]
        public async Task<ActionResult> EditContactos()
        {

            return PartialView();
        }

        /// <summary>
        /// Request de la información de propietarios.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ActionResult> Read([DataSourceRequest] DataSourceRequest request)
        {
            using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                Ekilibrate.Model.Entity.Administrador.clsEmpresaFiltro objFiltro = new Ekilibrate.Model.Entity.Administrador.clsEmpresaFiltro();
                var middleTier = scope.Resolve<Ekilibrate.Model.Services.Administrador.IDataRetriever>();
                var Result = await middleTier.GetEmpresas(objFiltro);
                return Json(Result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public async Task<ActionResult> Create([DataSourceRequest] DataSourceRequest request, Ekilibrate.Model.Entity.Administrador.clsEmpresaBase model)
        {
            try
            {
                if (model != null && ModelState.IsValid)
                {
                    using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                    {
                        var middleTier = scope.Resolve<Ekilibrate.Model.Services.Administrador.IDataInjector>();
                        var Result = await middleTier.CreateEmpresa(model);

                        model.Id = Result;
                        if (System.IO.File.Exists(Path.Combine(Server.MapPath("~/Uploads/Empresas/TempEmpresa.png"))))
                        {
                            System.IO.File.Move(Path.Combine(Server.MapPath("~/Uploads/Empresas/TempEmpresa.png")),
                                        Path.Combine(Server.MapPath("~/Uploads/Empresas"), model.Id.ToString() + ".png"));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, ex);
            }
            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public async Task<ActionResult> Update([DataSourceRequest] DataSourceRequest request, Ekilibrate.Model.Entity.Administrador.clsEmpresaBase model)
        {
            try
            {
                if (model != null && ModelState.IsValid)
                {
                    using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                    {
                        var middleTier = scope.Resolve<Ekilibrate.Model.Services.Administrador.IDataInjector>();
                        await middleTier.UpdateEmpresa(model);
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
        public async Task<ActionResult> Delete([DataSourceRequest] DataSourceRequest request, Ekilibrate.Model.Entity.Administrador.clsEmpresaBase model)
        {
            try
            {
                if (model != null && ModelState.IsValid)
                {
                    using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                    {
                        var middleTier = scope.Resolve<Ekilibrate.Model.Services.Administrador.IDataInjector>();
                        await middleTier.DeleteEmpresa(model.Id);
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, ex);
            }
            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        public async Task<JsonResult> GetGiro()
        {
            using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                Ekilibrate.Model.Entity.Administrador.clsEmpresaFiltro objFiltro = new Ekilibrate.Model.Entity.Administrador.clsEmpresaFiltro();
                var middleTier = scope.Resolve<Ekilibrate.Model.Services.Administrador.IDataRetriever>();
                var result3 = await middleTier.GetGiroEmpresa();
                return Json(result3
               .Select(x => new DropDownListItem
               {
                   Text = x.Nombre,
                   Value = x.Id.ToString()
               }).OrderBy(e => e.Text).ToList(), JsonRequestBehavior.AllowGet);
            }
        }
    }
}