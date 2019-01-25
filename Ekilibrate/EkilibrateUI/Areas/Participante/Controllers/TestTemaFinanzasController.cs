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
    public class TestTemaFinanzasController : Controller
    {
        // GET: Participante/TestTemaFinanzas
        [Authorize]
        public async Task<ActionResult> Index()
        {
            using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                BarcoSoftUtilidades.Seguridad.Usuario user = this.HttpContext.GetActualUser();

                if (user == null)
                    return Redirect("~/SitioAdministrativo/Home/Login?ReturnUrl=%2fParticipante%2fTestTemaFinanzas");

                var middleTier2 = scope.Resolve<Ekilibrate.Model.Services.Participante.IDataRetriever>();
                var Result = await middleTier2.GetTestTemasFinanzas(user.IdPersona);

                ViewBag.Preguntas = Result;

                if (Result != null)
                    return View(Result);
                else
                    return View();
            }
        }

        [HttpPost]
        public async Task<ActionResult> Select(int TemaId, bool Interes)
        {
            try
            {
                using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                {
                    var user = this.HttpContext.GetActualUser();
                    var Data = new Ekilibrate.Model.Entity.Participante.clsTestTemaFinanzas()
                            {
                                ParticipanteId = user.IdPersona,
                                TemaId = TemaId
                            };

                    var middleTier = scope.Resolve<Ekilibrate.Model.Services.Participante.IDataInjector>();
                    if (Interes)
                        await middleTier.SelectTemaFinanzas(Data);
                    else
                        await middleTier.UnSelectTemaFinanzas(Data);
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