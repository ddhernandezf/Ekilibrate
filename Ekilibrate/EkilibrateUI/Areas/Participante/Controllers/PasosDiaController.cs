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
using BarcoSoftUtilidades.Seguridad;

namespace EkilibrateUI.Areas.Participante.Controllers
{
    [BarcoSoftAuthorize]
    public class PasosDiaController : Controller
    {
        // GET: Participante/PasosDia
        public async Task<ActionResult> Index(int? IdParticipante)
        {
            using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                List<String> TitleList = new List<String>();
                List<Int32> MetaList = new List<Int32>();
                List<Int32> PasosList = new List<Int32>();
                                
                Ekilibrate.Model.Entity.Participante.clsPasosDiaFiltro objFiltro = new Ekilibrate.Model.Entity.Participante.clsPasosDiaFiltro();
                BarcoSoftUtilidades.Seguridad.Usuario user = this.HttpContext.GetActualUser();
                objFiltro.ParticipanteId = user.IdPersona;

                if (IdParticipante == null)
                    IdParticipante = user.IdPersona;

                TempData["filtro"] = objFiltro;


                var middleTier = scope.Resolve<Ekilibrate.Model.Services.Participante.IDataRetriever>();
                var Result = await middleTier.GetPasosDia((int)IdParticipante);

                //List<Ekilibrate.Model.Entity.Participante.clsPasosDiaBase> lresult = (List<Ekilibrate.Model.Entity.Participante.clsPasosDiaBase>)Result;

                Result.OrderBy(y => y.Dia).ToList().ForEach(x =>
                {
                    TitleList.Add(x.NombreDia);
                    MetaList.Add(x.Meta);
                    PasosList.Add(x.Caminados);
                });

                ViewBag.TitleList = TitleList;
                ViewBag.MetaList = MetaList;
                ViewBag.PasosList = PasosList;

                if (MetaList.Count > 0)
                {
                    ViewBag.MaxMeta = MetaList.Max();
                    ViewBag.AvgMeta = MetaList.Average();
                }
                else
                {
                    ViewBag.MaxMeta = 0;
                    ViewBag.AvgMeta = 0;
                }

                if (PasosList.Count > 0)
                    ViewBag.AvgPasos = PasosList.Average();
                else
                    ViewBag.AvgPasos = 0;

                return View(Result);
            }
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
                    
                    var middleTier = scope.Resolve<Ekilibrate.Model.Services.Participante.IDataRetriever>();
                    var Result = await middleTier.GetPasosDia(user.IdPersona);
                    return Json(Result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return Json(new List<Ekilibrate.Model.Entity.Administrador.clsProyectoBase>().ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
            }
        }
                
        public async Task<ActionResult> Update([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<Ekilibrate.Model.Entity.Participante.clsRegistroPasos> model)
        {
            try
            {
                if (model != null && ModelState.IsValid)
                {
                    using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                    {
                        var middleTier = scope.Resolve<Ekilibrate.Model.Services.Participante.IDataInjector>();
                        await middleTier.SincronizarPasosDia(model);
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
        
        //Métodos para devolver al APP
        /// <summary>
        /// Retorna un JSON con los pasos del compa del partcipante
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous()]
        public async Task<JsonResult> GetPasos(int userId, string startDate, string endDate)
        {
            using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                BarcoSoftUtilidades.Seguridad.Usuario user = this.HttpContext.GetActualUser();

                var middleTier = scope.Resolve<Ekilibrate.Model.Services.Participante.IDataRetriever>();
                Ekilibrate.Model.Entity.Participante.clsPasosApp Result = await middleTier.GetPasosDiaApp(userId);
                return Json(Result);
            }
        }
    }
}