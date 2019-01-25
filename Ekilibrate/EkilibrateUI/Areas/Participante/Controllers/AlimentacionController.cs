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
    public class AlimentacionController : Controller
    {
        // GET: Participante/Alimentacion
        public async Task<ActionResult> Index()
        {
            using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                BarcoSoftUtilidades.Seguridad.Usuario user = this.HttpContext.GetActualUser();

                if (user == null)
                    return Redirect("~/SitioAdministrativo/Home/Login?ReturnUrl=%2fParticipante%2fAlimentacion");

                Ekilibrate.Model.Entity.Participante.clsAlimentacionFiltro objFiltro = new Ekilibrate.Model.Entity.Participante.clsAlimentacionFiltro();
                objFiltro.ID_PARTICIPANTE = user.IdPersona;
                
                var middleTier = scope.Resolve<Ekilibrate.Model.Services.Participante.IDataRetriever>();
                var Result = await middleTier.GetAlimentaciones(objFiltro);
                if (Result != null)
                    return View(Result);
                else
                    return View(new Ekilibrate.Model.Entity.Participante.clsAlimentacionBase());
            }
        }
        
        [HttpPost]
        public async Task<ActionResult> Index(Ekilibrate.Model.Entity.Participante.clsAlimentacionBase model, string accion)
        {
            try
            {
                int? participante = null;
                participante = model.ID_PARTICIPANTE;

                if (model != null && ModelState.IsValid)
                {
                    using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                    {
                        var middleTier = scope.Resolve<Ekilibrate.Model.Services.Participante.IDataInjector>();

                        if (participante == 0)
                        {
                            BarcoSoftUtilidades.Seguridad.Usuario user = this.HttpContext.GetActualUser();
                            model.ID_PARTICIPANTE = user.IdPersona;
                            await middleTier.CreateAlimentacion(model);
                        }
                        else
                            await middleTier.UpdateAlimentacion(model);

                        if (accion == "Siguiente")
                            return Redirect("../Participante/Riesgo");
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(model);
        }        
    }
}