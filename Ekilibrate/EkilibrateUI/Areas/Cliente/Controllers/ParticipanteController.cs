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
using Ekilibrate.Model.Services.Participante;
using Ekilibrate.Model.Entity.Participante;

namespace EkilibrateUI.Areas.Cliente.Controllers
{
    [BarcoSoftAuthorize]
    public class ParticipanteController : Controller
    {
        // GET: Cliente/Participante
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Read([DataSourceRequest] DataSourceRequest request, int pProyectoId)
        {
            try
            { 
                using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                {
                    clsParticipanteFiltro objFiltro = new clsParticipanteFiltro();
                    objFiltro.ProyectoId = pProyectoId;
                    var middleTier = scope.Resolve<IDataRetriever>();
                    var Result = await middleTier.GetParticipantes(objFiltro);
                    return Json(Result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View();
            }
        }
    }
}