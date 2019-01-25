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
    public class TestFinanzasController : Controller
    {
        // GET: Participante/TestFinanzas
        [Authorize]
        public async Task<ActionResult> Index()
        {
            using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                BarcoSoftUtilidades.Seguridad.Usuario user = this.HttpContext.GetActualUser();

                if (user == null)
                    return Redirect("~/SitioAdministrativo/Home/Login?ReturnUrl=%2fParticipante%2fTestFinanzas");

                var middleTier2 = scope.Resolve<Ekilibrate.Model.Services.Participante.IDataRetriever>();
                var Result = await middleTier2.GetTestFinanzas(user.IdPersona);
                
                ViewBag.Preguntas = Result;

                if (Result != null)
                    return View(Result);
                else
                    return View();
            }
        }


        [HttpPost]
        public async Task<ActionResult> Select(int PreguntaId, int RespuestaId)
        {
            try
            {
                using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                {
                    var user = this.HttpContext.GetActualUser();

                    var middleTier = scope.Resolve<Ekilibrate.Model.Services.Participante.IDataInjector>();
                    await middleTier.SelectFinanzas(new Ekilibrate.Model.Entity.Participante.clsTestFinanzas()
                    {
                        ParticipanteId = user.IdPersona,
                        PreguntaId = PreguntaId,
                        RespuestaId = RespuestaId
                    });
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