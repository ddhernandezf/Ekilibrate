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
    public class TiempoController : Controller
    {
        // GET: Participante/Tiempo
        public async Task<ActionResult> Index()
        {
            using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                BarcoSoftUtilidades.Seguridad.Usuario user = this.HttpContext.GetActualUser();

                if (user == null)
                    return Redirect("~/SitioAdministrativo/Home/Login?ReturnUrl=%2fParticipante%2fTiempo");

                Ekilibrate.Model.Entity.Participante.clsTiempoFiltro objFiltro = new Ekilibrate.Model.Entity.Participante.clsTiempoFiltro();
                Ekilibrate.Model.Entity.Participante.clsFrecuenciaFiltro objFiltro2 = new Ekilibrate.Model.Entity.Participante.clsFrecuenciaFiltro();
                objFiltro.ID_PARTICIPANTE = user.IdPersona;
                objFiltro2.ID_PARTICIPANTE = user.IdPersona;

                var middleTier = scope.Resolve<Ekilibrate.Model.Services.Participante.IDataRetriever>();
                var Result = await middleTier.GetTiempos(objFiltro);

                var middleTier2 = scope.Resolve<Ekilibrate.Model.Services.Participante.IDataRetriever>();
                ViewBag.Tiempo = await middleTier2.GetFrecuencias(objFiltro2);

                if (Result != null)
                    return View(Result);
                else
                    return View();
            }
        }
        
        [HttpPost]
        public async Task<ActionResult> Index(Ekilibrate.Model.Entity.Participante.clsTiempoBase model)
        {
            using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                BarcoSoftUtilidades.Seguridad.Usuario user = this.HttpContext.GetActualUser();

                if (user == null)
                    return Redirect("~/SitioAdministrativo/Home/Login?ReturnUrl=%2fParticipante%2fTiempo");

                Ekilibrate.Model.Entity.Participante.clsTiempoFiltro objFiltro = new Ekilibrate.Model.Entity.Participante.clsTiempoFiltro();
                Ekilibrate.Model.Entity.Participante.clsFrecuenciaFiltro objFiltro2 = new Ekilibrate.Model.Entity.Participante.clsFrecuenciaFiltro();
                objFiltro.ID_PARTICIPANTE = user.IdPersona;
                objFiltro2.ID_PARTICIPANTE = user.IdPersona;

                var middleTier = scope.Resolve<Ekilibrate.Model.Services.Participante.IDataRetriever>();
                var Result = await middleTier.GetTiempos(objFiltro);

                var middleTier2 = scope.Resolve<Ekilibrate.Model.Services.Participante.IDataRetriever>();
                ViewBag.Tiempo = await middleTier2.GetFrecuencias(objFiltro2);

                if (Result != null)
                    return View(Result);
                else
                    return View();
            }
        }
        
        [HttpPost]
        public async Task<ActionResult> AddFrecuencia(int pID_PREGUNTA, string pFrecuencia)
        {
            try
            {
                var user = this.HttpContext.GetActualUser();
                var obj = new Ekilibrate.Model.Entity.Participante.clsFrecuencia();
                switch (pFrecuencia)
                {
                    case "S":
                        obj = new Ekilibrate.Model.Entity.Participante.clsFrecuencia()
                        {
                            ID_PREGUNTA = pID_PREGUNTA,
                            ID_PARTICIPANTE = user.IdPersona,
                            SIEMPRE = true,
                            FRECUENTE = false,
                            CASI_NUNCA = false,
                            NUNCA = false,
                        };
                        break;
                    case "F":
                        obj = new Ekilibrate.Model.Entity.Participante.clsFrecuencia()
                        {
                            ID_PREGUNTA = pID_PREGUNTA,
                            ID_PARTICIPANTE = user.IdPersona,
                            SIEMPRE = false,
                            FRECUENTE = true,
                            CASI_NUNCA = false,
                            NUNCA = false,
                        };
                        break;

                    case "C":
                         obj = new Ekilibrate.Model.Entity.Participante.clsFrecuencia()
                        {
                            ID_PREGUNTA = pID_PREGUNTA,
                            ID_PARTICIPANTE = user.IdPersona,
                            SIEMPRE = false,
                            FRECUENTE = false,
                            CASI_NUNCA = true,
                            NUNCA = false,
                        };
                        break;

                    case "N":
                         obj = new Ekilibrate.Model.Entity.Participante.clsFrecuencia()
                        {
                            ID_PREGUNTA = pID_PREGUNTA,
                            ID_PARTICIPANTE = user.IdPersona,
                            SIEMPRE = false,
                            FRECUENTE = false,
                            CASI_NUNCA = false,
                            NUNCA = true,
                        };
                        break;
                    default:
                        break;
                }
                using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                {
                    var middleTier = scope.Resolve<Ekilibrate.Model.Services.Participante.IDataInjector>();
                    await middleTier.CreateFrecuencia(obj);
                }

                return Json(new { success = true, error = "" });
            }
            catch (Exception ex)
            {

                return Json(new { success = false, error = ex.Message });
            }

        }


       

    }
}