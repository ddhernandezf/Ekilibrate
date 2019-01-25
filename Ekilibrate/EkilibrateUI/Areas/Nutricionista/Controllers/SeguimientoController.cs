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
using Ekilibrate.Model.Services;
using Ekilibrate.Model.Entity.Proyecto;
using Ekilibrate.Model.Entity.Nutricionista;
using BarcoSoftUtilidades;
using BarcoSoftUtilidades.Seguridad;

namespace EkilibrateUI.Areas.Nutricionista.Controllers
{
    [BarcoSoftAuthorize]
    public class SeguimientoController : Controller
    {
        // GET: Nutricionista/Seguimiento
        [BarcoSoftUtilidades.Seguridad.BarcoSoftAuthorize]
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Read([DataSourceRequest] DataSourceRequest request)
        {
            using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                BarcoSoftUtilidades.Seguridad.Usuario user = this.HttpContext.GetActualUser();
                clsCitaFiltro objFiltro = new clsCitaFiltro();
                objFiltro.NutricionistaId = user.Nutricionista.idNutricionista;
                objFiltro.Fecha = DateTime.Now;
                var middleTier = scope.Resolve<Ekilibrate.Model.Services.Nutricionista.IDataRetriever>();
                var Result = await middleTier.GetCitas(objFiltro);
                Result.ToList().ForEach(x =>
                {
                    if (x.Id <= 0)
                    {
                        x.Id = 1;
                    }
                });
                return Json(Result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
            }
        }

        [BarcoSoftUtilidades.Seguridad.BarcoSoftAuthorize]
        public async Task<ActionResult> Seguimiento(int cita)
        {
            Ekilibrate.Model.Entity.Participante.ResumenExpediente Resumen = new Ekilibrate.Model.Entity.Participante.ResumenExpediente();
            BarcoSoftUtilidades.Seguridad.Usuario user = this.HttpContext.GetActualUser();

            if (user == null)
                return Redirect("~/SitioAdministrativo/Home/Login?ReturnUrl=%2fNutricionista%2fSeguimiento%2fSeguimiento?cita=" + cita);

            //1.0 Cita
            var model = new clsCita()
            {
                Id = cita
            };

            using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                //2. Seguimiento
                var middleTier = scope.Resolve<Ekilibrate.Model.Services.Nutricionista.IDataRetriever>();
                var resultSeg = await middleTier.GetSeguimiento(cita);
                if (resultSeg != null)
                    resultSeg.NutricionistaId = user.Nutricionista.idNutricionista;
                resultSeg.ReadOnly = false;
                ViewBag.ModelSeg = resultSeg;

                //3. Resumen
                var middleTierPar = scope.Resolve<Ekilibrate.Model.Services.Participante.IDataRetriever>();
                Resumen = await middleTierPar.GetResumenExpediente(resultSeg.ParticipanteId);
                Resumen.REDgeneral = Resumen.VET - Resumen.RED;
                ViewBag.ModelResumen = Resumen;
                
                //4. Plan de Alimentacion
                var Plan = await middleTier.GetPlanAlimentacion(cita, resultSeg.ParticipanteId);
                Plan.ReadOnly = false;
                ViewBag.ModelPlan = Plan;
            }
            
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> CuadroMetas(clsSeguimiento model)
        {
            if (ModelState.IsValid)
            {
                using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                {
                    var middleTier = scope.Resolve<Ekilibrate.Model.Services.Nutricionista.IDataInjector>();
                    await middleTier.CreateSeguimiento(model);
                }
            }
            return RedirectToAction("Index");            
        }

        [HttpPost]
        public async Task<ActionResult> Plan(Ekilibrate.Model.Entity.Nutricionista.clsPlanAlimentacion model)
        {
            if (ModelState.IsValid)
            {
                using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                {
                    var middleTier = scope.Resolve<Ekilibrate.Model.Services.Nutricionista.IDataInjector>();
                    await middleTier.SincronizarPlan(model);
                }
            }
            return Json(model, JsonRequestBehavior.DenyGet);
            //return View(model);
        }

        [HttpPost]
        public ActionResult Test(Ekilibrate.Model.Entity.Nutricionista.clsTest model)
        {
            if (ModelState.IsValid)
            {
                using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                {
                    var middleTier = scope.Resolve<Ekilibrate.Model.Services.Nutricionista.IDataInjector>();                    
                }
            }
            return Json(model, JsonRequestBehavior.DenyGet);
            //return View(model);
        }

        public async Task<ActionResult> Read_Aspectos([DataSourceRequest] DataSourceRequest request, int pCita, int pParticipante)
        {
            try
            {
                using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                {
                    Ekilibrate.Model.Entity.Nutricionista.clsSeguimientoAspectosFiltro objFiltro =
                        new clsSeguimientoAspectosFiltro
                        {
                            CitaId = pCita,
                            ParticipanteId = pParticipante
                        };

                    var middleTier = scope.Resolve<Ekilibrate.Model.Services.Nutricionista.IDataRetriever>();
                    var Result = await middleTier.GetSeguimientoAspectos(objFiltro.ParticipanteId, objFiltro.CitaId);
                    return Json(Result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                throw new HttpException(ex.Message);
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public async Task<ActionResult> Update_Aspectos([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<Ekilibrate.Model.Entity.Nutricionista.clsSeguimientoAspectos> model)
        {
            try
            {
                if (model != null && ModelState.IsValid)
                {
                    using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                    {
                        var middleTier = scope.Resolve<Ekilibrate.Model.Services.Nutricionista.IDataInjector>();
                        await middleTier.SincronizarCuadroMetas(model);
                        return Json(model.ToDataSourceResult(request, ModelState));
                    }

                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return Json(model.ToDataSourceResult(request, ModelState));
        }

        [BarcoSoftUtilidades.Seguridad.BarcoSoftAuthorize]
        public async Task<ActionResult> TallerAreaSalud(int? par)
        {
            return PartialView(par);
        }

        public async Task<ActionResult> Read_TalleresCalificacion([DataSourceRequest] DataSourceRequest request, int pParticipante, int pTallerId )
        {
            try
            {
                using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                {
                    Ekilibrate.Model.Entity.Nutricionista.clsCalificacionTallerFiltro objFiltro =
                        new clsCalificacionTallerFiltro
                        {
                           TallerId = pTallerId,
                            ParticipanteId = pParticipante
                        };

                    var middleTier = scope.Resolve<Ekilibrate.Model.Services.Nutricionista.IDataRetriever>();
                    var Result = await middleTier.GetCalificacionTaller(pParticipante, pTallerId);
                    return Json(Result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                throw new HttpException(ex.Message);
            }
        }
        [BarcoSoftUtilidades.Seguridad.BarcoSoftAuthorize]
        public async Task<ActionResult> TallerManejoEmociones(int? par)
        {
            return PartialView(par);
        }

        [BarcoSoftUtilidades.Seguridad.BarcoSoftAuthorize]
        public async Task<ActionResult> TallerCrecimientoPersonal(int? par)
        {
            return PartialView(par);
        }

        [BarcoSoftUtilidades.Seguridad.BarcoSoftAuthorize]
        public async Task<ActionResult> TallerRelacionesInterpersonales(int? par)
        {
            return PartialView(par);
        }
        
    }
}