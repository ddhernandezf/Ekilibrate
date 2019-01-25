using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac;
using System.Threading.Tasks;

namespace EkilibrateUI.Areas.Api.Controllers
{
    public class AlimentosController : Controller
    {
        // GET: Api/Alimentos
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("GetPasos/{userId:int}")]
        public async Task<JsonResult> GetAlimentacion(int userId)
        {
            using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                Ekilibrate.Model.Entity.Participante.clsAlimentacionDiaFiltro objFiltro = new Ekilibrate.Model.Entity.Participante.clsAlimentacionDiaFiltro();
                objFiltro.ParticipanteId = userId;

                var middleTier = scope.Resolve<Ekilibrate.Model.Services.Participante.IDataRetriever>();
                Ekilibrate.Model.Entity.Participante.clsAlimentacionApp Result = await middleTier.GetAlimentacionDiaApp(objFiltro);
                return Json(Result, JsonRequestBehavior.AllowGet);
                //return "OK";
            }
        }
    }
}