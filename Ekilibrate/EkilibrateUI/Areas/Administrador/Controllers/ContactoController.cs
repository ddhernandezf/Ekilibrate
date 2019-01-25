using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac;
using System.Threading.Tasks;
using BarcoSoftUtilidades.Seguridad;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using Ekilibrate.Model.Common;

namespace EkilibrateUI.Areas.Administrador.Controllers
{
    [BarcoSoftAuthorize]
    public class ContactoController : Controller
    {
        [AcceptVerbs(HttpVerbs.Post)]
        public async Task<ActionResult> Read([DataSourceRequest] DataSourceRequest request, int pIdEmpresa)
        {
            using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                Ekilibrate.Model.Entity.Administrador.clsContactoFiltro objFiltro = new Ekilibrate.Model.Entity.Administrador.clsContactoFiltro();
                objFiltro.EmpresaId = pIdEmpresa;

                var middleTier = scope.Resolve<Ekilibrate.Model.Services.Administrador.IDataRetriever>();
                var Result = await middleTier.GetContacto(objFiltro);
                return Json(Result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public async Task<ActionResult> Create([DataSourceRequest] DataSourceRequest request, Ekilibrate.Model.Entity.Administrador.clsContactoBase model, int pIdEmpresa)
        {
            try
            {
                model.EmpresaId = pIdEmpresa;
                if (model != null && ModelState.IsValid)
                {
                    using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                    {
                        var middleTier = scope.Resolve<Ekilibrate.Model.Services.Administrador.IDataInjector>();
                        var Result = await middleTier.CreateContacto(model);

                        model.IdPersona = Result;
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
        public async Task<ActionResult> Update([DataSourceRequest] DataSourceRequest request, Ekilibrate.Model.Entity.Administrador.clsContactoBase model, int pIdEmpresa)
        {
            try
            {
                model.EmpresaId = pIdEmpresa;
                if (model != null && ModelState.IsValid)
                {
                    using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                    {
                        var middleTier = scope.Resolve<Ekilibrate.Model.Services.Administrador.IDataInjector>();
                        await middleTier.UpdateContacto(model);
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
        public async Task<ActionResult> Delete([DataSourceRequest] DataSourceRequest request, Ekilibrate.Model.Entity.Administrador.clsContactoBase model)
        {
            try
            {
                if (model != null && ModelState.IsValid)
                {
                    using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                    {
                        var middleTier = scope.Resolve<Ekilibrate.Model.Services.Administrador.IDataInjector>();
                        await middleTier.DeleteContacto(model.IdPersona);
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, ex);
            }
            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        public async Task<JsonResult> GetClienteRol()
        {
            using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                Ekilibrate.Model.Administrador.clsClienteRolFiltro objFiltro = new Ekilibrate.Model.Administrador.clsClienteRolFiltro();
                
                var middleTier = scope.Resolve<Ekilibrate.Model.Services.Administrador.IDataRetriever>();
                var Result = await middleTier.GetClienteRol(objFiltro);

                return Json(Result.ToList(), JsonRequestBehavior.AllowGet);
            }
            
        }
    }
}