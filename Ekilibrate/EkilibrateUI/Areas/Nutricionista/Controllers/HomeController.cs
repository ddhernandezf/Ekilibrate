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
using Ekilibrate.Model.Services;
using Ekilibrate.Model.Entity.Proyecto;
using Ekilibrate.Model.Entity.Nutricionista;
using BarcoSoftUtilidades;
using BarcoSoftUtilidades.Seguridad;

namespace EkilibrateUI.Areas.Nutricionista.Controllers
{
    [BarcoSoftAuthorize]
    public class HomeController : Controller
    {
        // GET: Nutricionista/Home
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Read([DataSourceRequest] DataSourceRequest request)
        {
            BarcoSoftUtilidades.Seguridad.Usuario user = this.HttpContext.GetActualUser();
            using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                clsCitaFiltro objFiltro = new clsCitaFiltro();
                objFiltro.NutricionistaId = user.Nutricionista.idNutricionista;
                objFiltro.Fecha = DateTime.Now;

                var middleTier = scope.Resolve<Ekilibrate.Model.Services.Nutricionista.IDataRetriever>();
                IEnumerable<clsCita> Result = await middleTier.GetCitas(objFiltro);

                var resultFilter = Result.Where(x => x.Cancelada.Equals(false)).ToList();

                return Json(resultFilter.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
            }
        }

        public async Task<ActionResult> ReadD([DataSourceRequest] DataSourceRequest request)
        {
            BarcoSoftUtilidades.Seguridad.Usuario user = this.HttpContext.GetActualUser();
            using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                clsCitaFiltro objFiltro = new clsCitaFiltro();
                objFiltro.NutricionistaId = user.Nutricionista.idNutricionista;
                objFiltro.Fecha = DateTime.Now;

                var middleTier = scope.Resolve<Ekilibrate.Model.Services.Nutricionista.IDataRetriever>();
                IEnumerable<clsCita> Result = await middleTier.GetCitasDiagnostico(objFiltro);

                var resultFilter = Result.Where(x => x.Cancelada.Equals(false)).ToList();

                return Json(resultFilter.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
            }
        }

        public async Task<ActionResult> ReadF([DataSourceRequest] DataSourceRequest request)
        {
            BarcoSoftUtilidades.Seguridad.Usuario user = this.HttpContext.GetActualUser();
            using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                clsCitaFiltro objFiltro = new clsCitaFiltro();
                objFiltro.NutricionistaId = user.Nutricionista.idNutricionista;
                objFiltro.Fecha = DateTime.Now;

                var middleTier = scope.Resolve<Ekilibrate.Model.Services.Nutricionista.IDataRetriever>();
                IEnumerable<clsCita> Result = await middleTier.GetCitasFin(objFiltro);

                var resultFilter = Result.Where(x => x.Cancelada.Equals(false)).ToList();

                return Json(resultFilter.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Redirect(clsCita Cita)
        {
            return View("Formulario", Cita);
        }
    }
}