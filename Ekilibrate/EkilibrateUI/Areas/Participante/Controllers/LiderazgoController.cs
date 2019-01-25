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
    public class LiderazgoController : Controller
    {
        public async Task<ActionResult> Index()
        {
            // GET: Participante/Liderazgo
            using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                BarcoSoftUtilidades.Seguridad.Usuario user = this.HttpContext.GetActualUser();

                if (user == null)
                    return Redirect("~/SitioAdministrativo/Home/Login?ReturnUrl=%2fParticipante%2fLiderazgo");

                var middleTier = scope.Resolve<Ekilibrate.Model.Services.Participante.IDataRetriever>();
                ViewBag.Liderazgo = await middleTier.GetPreguntasLiderazgo(user.IdPersona);

                return View();
            }
        }

        [HttpPost]
        public async Task<ActionResult> Select(int PreguntaId, bool Siempre, bool Frecuentemente, bool CasiNunca, bool Nunca)
        {
            try
            {
                using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                {
                    var user = this.HttpContext.GetActualUser();

                    if (user == null)
                        return Redirect("~/SitioAdministrativo/Home/Login?ReturnUrl=%2fParticipante%2fLiderazgo");

                    var middleTier = scope.Resolve<Ekilibrate.Model.Services.Participante.IDataInjector>();
                    await middleTier.SelectLiderazgo(new Ekilibrate.Model.Entity.Participante.clsTestLiderazgoBase()
                    {
                        ParticipanteId = user.IdPersona,
                        PreguntaId = PreguntaId,
                        Siempre = Siempre,
                        Frecuentemente = Frecuentemente,
                        CasiNunca = CasiNunca,
                        Nunca = Nunca
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