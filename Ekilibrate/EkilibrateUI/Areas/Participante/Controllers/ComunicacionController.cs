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
    public class ComunicacionController : Controller
    {
        // GET: Participante/Comunicacion
        public async Task<ActionResult> Index()
        {
            using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                BarcoSoftUtilidades.Seguridad.Usuario user = this.HttpContext.GetActualUser();

                if (user == null)
                    return Redirect("~/SitioAdministrativo/Home/Login?ReturnUrl=%2fParticipante%2fComunicacion");

                Ekilibrate.Model.Entity.Participante.clsComunicacionFiltro objFiltro = new Ekilibrate.Model.Entity.Participante.clsComunicacionFiltro();
                Ekilibrate.Model.Entity.Participante.clsAsertivaFiltro objFiltro2 = new Ekilibrate.Model.Entity.Participante.clsAsertivaFiltro();
                objFiltro.ID_PARTICIPANTE = user.IdPersona;
                objFiltro2.ID_PARTICIPANTE = user.IdPersona;

                var middleTier = scope.Resolve<Ekilibrate.Model.Services.Participante.IDataRetriever>();
                var Result = await middleTier.GetComunicaciones(objFiltro);

                var middleTier2 = scope.Resolve<Ekilibrate.Model.Services.Participante.IDataRetriever>();
                ViewBag.Comunicacion = await middleTier2.GetAsertivas(objFiltro2);

                if (Result != null)
                    return View(Result);
                else
                    return View();
            }
        }
        
        [HttpPost]
        public async Task<ActionResult> Index(Ekilibrate.Model.Entity.Participante.clsComunicacionBase model)
        {
            try
            {
                using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                {
                    BarcoSoftUtilidades.Seguridad.Usuario user = this.HttpContext.GetActualUser();

                    if (user == null)
                        return Redirect("~/SitioAdministrativo/Home/Login?ReturnUrl=%2fParticipante%2fComunicacion");

                    Ekilibrate.Model.Entity.Participante.clsAsertivaFiltro objFiltro2 = new Ekilibrate.Model.Entity.Participante.clsAsertivaFiltro();
                    objFiltro2.ID_PARTICIPANTE = user.IdPersona;
                    var middleTier2 = scope.Resolve<Ekilibrate.Model.Services.Participante.IDataRetriever>();
                    ViewBag.Comunicacion = await middleTier2.GetAsertivas(objFiltro2);
                    
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
        public async Task<ActionResult> AddAsertiva(int pID_PREGUNTA, string pAsertiva)
        {
            try
            {
                var user = this.HttpContext.GetActualUser();
                var obj = new Ekilibrate.Model.Entity.Participante.clsAsertiva();
                switch (pAsertiva)
                { 
                    case "1":
                        obj = new Ekilibrate.Model.Entity.Participante.clsAsertiva()
                        {
                            ID_PREGUNTA = pID_PREGUNTA,
                            ID_PARTICIPANTE = user.IdPersona,
                            EN_ABSOLUTO = true,
                            UN_POCO = false,
                            BASTANTE = false,
                            MUCHO = false,
                            MUCHISIMO = false,
                        };
                        break;
                        case "2":
                        obj = new Ekilibrate.Model.Entity.Participante.clsAsertiva()
                        {
                            ID_PREGUNTA = pID_PREGUNTA,
                            ID_PARTICIPANTE = user.IdPersona,
                            EN_ABSOLUTO = false,
                            UN_POCO = true,
                            BASTANTE = false,
                            MUCHO = false,
                            MUCHISIMO = false,
                        };
                        break;
                        case "3":
                        obj = new Ekilibrate.Model.Entity.Participante.clsAsertiva()
                        {
                            ID_PREGUNTA = pID_PREGUNTA,
                            ID_PARTICIPANTE = user.IdPersona,
                            EN_ABSOLUTO = false,
                            UN_POCO = false,
                            BASTANTE = true,
                            MUCHO = false,
                            MUCHISIMO = false,
                        };
                        break;
                        case "4":
                        obj = new Ekilibrate.Model.Entity.Participante.clsAsertiva()
                        {
                            ID_PREGUNTA = pID_PREGUNTA,
                            ID_PARTICIPANTE = user.IdPersona,
                            EN_ABSOLUTO = false,
                            UN_POCO = false,
                            BASTANTE = false,
                            MUCHO = true,
                            MUCHISIMO = false,
                        };
                        break;
                        case "5":
                        obj = new Ekilibrate.Model.Entity.Participante.clsAsertiva()
                        {
                            ID_PREGUNTA = pID_PREGUNTA,
                            ID_PARTICIPANTE = user.IdPersona,
                            EN_ABSOLUTO = false,
                            UN_POCO = false,
                            BASTANTE = false,
                            MUCHO = false,
                            MUCHISIMO = true,
                        };
                        break;
                    default:
                        break;

                }
                using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                {
                    var middleTier = scope.Resolve<Ekilibrate.Model.Services.Participante.IDataInjector>();
                    await middleTier.CreateAsertiva(obj);
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