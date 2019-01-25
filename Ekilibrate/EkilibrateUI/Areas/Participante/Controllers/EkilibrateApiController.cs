using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Autofac;
using System.Threading.Tasks;
using System.Web.Mvc;
using BarcoSoftUtilidades.Seguridad;

namespace EkilibrateUI.Areas.Participante.Controllers
{
    [BarcoSoftAuthorize]
    public class EkilibrateApiController : ApiController
    {
        //Métodos para devolver al APP
        /// <summary>
        /// Retorna un JSON con los pasos del compa del partcipante
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>        
        public async Task<string> GetPasos(int userId, string startDate, string endDate)
        {
            using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {                
                var middleTier = scope.Resolve<Ekilibrate.Model.Services.Participante.IDataRetriever>();
                Ekilibrate.Model.Entity.Participante.clsPasosApp Result = await middleTier.GetPasosDiaApp(userId);
                //return Json(Result.ToDataSourceResult(request, ModelState));
                return "OK";
            }
        }
    }
}
