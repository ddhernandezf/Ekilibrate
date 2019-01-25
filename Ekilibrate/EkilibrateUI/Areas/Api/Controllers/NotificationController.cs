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
    public class NotificationController : Controller
    {
        // GET: Api/Notification
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Send")]
        public async Task<ActionResult> Send()
        {
            using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                var middleTier = scope.Resolve<Ekilibrate.Model.Services.Administrador.IDataInjector>();
                await middleTier.SendNotifications();
                return new HttpStatusCodeResult(HttpStatusCode.OK);
                //return "OK";
            }
        }
    }
}