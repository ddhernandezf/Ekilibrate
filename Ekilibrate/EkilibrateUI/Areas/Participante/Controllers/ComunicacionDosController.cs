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
    public class ComunicacionDosController : Controller
    {
        // GET: Participante/ComunicacionDos
        public async Task<ActionResult> Index()
        {
            using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                BarcoSoftUtilidades.Seguridad.Usuario user = this.HttpContext.GetActualUser();

                if (user == null)
                    return Redirect("~/SitioAdministrativo/Home/Login?ReturnUrl=%2fParticipante%2fComunicacionDos");

                Ekilibrate.Model.Entity.Participante.clsComunicacionDosFiltro objFiltro = new Ekilibrate.Model.Entity.Participante.clsComunicacionDosFiltro();
                Ekilibrate.Model.Entity.Participante.clsAsertivaDosFiltro objFiltro2 = new Ekilibrate.Model.Entity.Participante.clsAsertivaDosFiltro();
                objFiltro.ID_PARTICIPANTE = user.IdPersona;
                objFiltro2.ID_PARTICIPANTE = user.IdPersona;

                var middleTier = scope.Resolve<Ekilibrate.Model.Services.Participante.IDataRetriever>();
                var Result = await middleTier.GetComunicacionesDos(objFiltro);

                var middleTier2 = scope.Resolve<Ekilibrate.Model.Services.Participante.IDataRetriever>();
                ViewBag.ComunicacionDos= await middleTier2.GetAsertivasDos(objFiltro2);

                if (Result != null)
                    return View(Result);
                else
                    return View();
            }
        }
        
        [HttpPost]
        public async Task<ActionResult> Index(Ekilibrate.Model.Entity.Participante.clsComunicacionDosBase model)
        {
            try
            {
                using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                {
                    BarcoSoftUtilidades.Seguridad.Usuario user = this.HttpContext.GetActualUser();

                    if (user == null)
                        return Redirect("~/SitioAdministrativo/Home/Login?ReturnUrl=%2fParticipante%2fComunicacionDos");

                    Ekilibrate.Model.Entity.Participante.clsAsertivaDosFiltro objFiltro2 = new Ekilibrate.Model.Entity.Participante.clsAsertivaDosFiltro();
                    objFiltro2.ID_PARTICIPANTE = user.IdPersona;

                    var middleTier2 = scope.Resolve<Ekilibrate.Model.Services.Participante.IDataRetriever>();
                    ViewBag.ComunicacionDos = await middleTier2.GetAsertivasDos(objFiltro2);

                    return View(model);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(model);
        }
        
        [HttpPost]
        public async Task<ActionResult> AddAsertivaDos(int pID_PREGUNTA, string pAsertivaDos)
        {
            try
            {
                var user = this.HttpContext.GetActualUser();
                var obj = new Ekilibrate.Model.Entity.Participante.clsAsertivaDos();
                switch (pAsertivaDos)
                {
                    case "1":
                        obj = new Ekilibrate.Model.Entity.Participante.clsAsertivaDos()
                        {
                            ID_PREGUNTA = pID_PREGUNTA,
                            ID_PARTICIPANTE = user.IdPersona,
                            SIEMPRE_LO_HAGO = true,
                            HABITUALMENTEBIT = false,
                            MITAD_VECES = false,
                            RARAMENTE = false,
                            NUNCA = false,
                        };
                        break;
                    case "2":
                        obj = new Ekilibrate.Model.Entity.Participante.clsAsertivaDos()
                        {
                            ID_PREGUNTA = pID_PREGUNTA,
                            ID_PARTICIPANTE = user.IdPersona,
                            SIEMPRE_LO_HAGO = false,
                            HABITUALMENTEBIT = true,
                            MITAD_VECES = false,
                            RARAMENTE = false,
                            NUNCA = false,
                        };
                        break;
                    case "3":
                        obj = new Ekilibrate.Model.Entity.Participante.clsAsertivaDos()
                        {
                            ID_PREGUNTA = pID_PREGUNTA,
                            ID_PARTICIPANTE = user.IdPersona,
                            SIEMPRE_LO_HAGO = false,
                            HABITUALMENTEBIT = false,
                            MITAD_VECES = true,
                            RARAMENTE = false,
                            NUNCA = false,
                        };
                        break;
                    case "4":
                        obj = new Ekilibrate.Model.Entity.Participante.clsAsertivaDos()
                        {
                            ID_PREGUNTA = pID_PREGUNTA,
                            ID_PARTICIPANTE = user.IdPersona,
                            SIEMPRE_LO_HAGO = false,
                            HABITUALMENTEBIT = false,
                            MITAD_VECES = false,
                            RARAMENTE = true,
                            NUNCA = false,
                        };
                        break;
                    case "5":
                        obj = new Ekilibrate.Model.Entity.Participante.clsAsertivaDos()
                        {
                            ID_PREGUNTA = pID_PREGUNTA,
                            ID_PARTICIPANTE = user.IdPersona,
                            SIEMPRE_LO_HAGO = false,
                            HABITUALMENTEBIT = false,
                            MITAD_VECES = false,
                            RARAMENTE = false,
                            NUNCA = true,
                        };
                        break;
                    default:
                        break;

                }
                using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                {
                    var middleTier = scope.Resolve<Ekilibrate.Model.Services.Participante.IDataInjector>();
                    await middleTier.CreateAsertivaDos(obj);
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