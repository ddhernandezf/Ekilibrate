using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EkilibrateUI.Areas.Api.Controllers
{
    public class PasosController : Controller
    {
        // GET: Api/Pasos
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("GetPasos/{userId:int}")]
        public async Task<JsonResult> GetPasos(int userId)
        {
            using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                var middleTier = scope.Resolve<Ekilibrate.Model.Services.Participante.IDataRetriever>();
                Ekilibrate.Model.Entity.Participante.clsPasosApp Result = await middleTier.GetPasosDiaCompaApp(userId);
                return Json(Result, JsonRequestBehavior.AllowGet);

                //var middleTier = scope.Resolve<Ekilibrate.Model.Services.ParticipanUJ te.IDataRetriever>();
                //Ekilibrate.Model.Entity.Participante.clsPasosApp Result = await middleTier.GetPasosDiaApp(userId);
                //return Json(Result, JsonRequestBehavior.AllowGet);
                //return "OK";
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("GetPasosCompa/{userId:int}")]
        public async Task<JsonResult> GetPasosCompa(int userId)
        {
            using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                var middleTier = scope.Resolve<Ekilibrate.Model.Services.Participante.IDataRetriever>();
                Ekilibrate.Model.Entity.Participante.clsPasosApp Result = await middleTier.GetPasosDiaCompaApp(userId);
                return Json(Result, JsonRequestBehavior.AllowGet);
                //return "OK";
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("SetPasos")]
        public async Task<ActionResult> SetPasos()
        {
            using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                Stream req = Request.InputStream;
                req.Seek(0, System.IO.SeekOrigin.Begin);
                string json = new StreamReader(req).ReadToEnd();

                Ekilibrate.Model.Entity.Participante.clsPasosDiaApp input = null;
                try
                {
                    var format = "yyyy/MM/dd"; // your datetime format
                    var dateTimeConverter = new IsoDateTimeConverter { DateTimeFormat = format };

                    // assuming JSON.net/Newtonsoft library from http://json.codeplex.com/
                    input = JsonConvert.DeserializeObject<Ekilibrate.Model.Entity.Participante.clsPasosDiaApp>(json, dateTimeConverter);
                    if (input == null)
                        throw new Exception();
                }
                catch (Exception ex)
                {
                    // Try and handle malformed POST body
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                Ekilibrate.Model.Entity.Participante.clsPasosDiaFiltro objFiltro = new Ekilibrate.Model.Entity.Participante.clsPasosDiaFiltro();
                
                var middleTier = scope.Resolve<Ekilibrate.Model.Services.Participante.IDataInjector>();
                await middleTier.SetPasosDia(input);
                return new HttpStatusCodeResult(HttpStatusCode.OK);
                //return "OK";
            }
        }
    }
}