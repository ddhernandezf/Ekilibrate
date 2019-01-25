using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Autofac;
using System.Threading.Tasks;

namespace EkilibrateUI.Areas.Api.Controllers
{
    public class StepsController : ApiController
    {
        [AllowAnonymous]
        [HttpGet]
        [Route("GetPasos/{userId:int}")]
        public async Task<Ekilibrate.Model.Entity.Participante.clsPasosApp> GetPasos(int userId)
        {
            using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                var middleTier = scope.Resolve<Ekilibrate.Model.Services.Participante.IDataRetriever>();
                Ekilibrate.Model.Entity.Participante.clsPasosApp Result = await middleTier.GetPasosDiaApp(userId);
                //return Json(Result, JsonRequestBehavior.AllowGet);
                return Result;
                //return "OK";
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("SetPasos")]
        public async Task<IHttpActionResult> SetPasos()
        {
            using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                var middleTier = scope.Resolve<Ekilibrate.Model.Services.Participante.IDataRetriever>();
                //Ekilibrate.Model.Entity.Participante.clsPasosApp Result = await middleTier.GetPasosDiaApp(null);
                //return  Json(Result, JsonRequestBehavior.AllowGet);
                return Ok(true);
            }
        }
    }
}
