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
    public class AlimentacionDiaController : Controller
    {
        public async Task<ActionResult> Index()
        {
            using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                List<String> TitleList = new List<String>();
                List<Int32> MetaList = new List<Int32>();
                List<Int32> ComidoList = new List<Int32>();

                Ekilibrate.Model.Entity.Participante.clsAlimentacionDiaFiltro objFiltro = new Ekilibrate.Model.Entity.Participante.clsAlimentacionDiaFiltro();
                BarcoSoftUtilidades.Seguridad.Usuario user = this.HttpContext.GetActualUser();
                objFiltro.ParticipanteId = user.IdPersona;

                TempData["filtro"] = objFiltro;


                var middleTier = scope.Resolve<Ekilibrate.Model.Services.Participante.IDataRetriever>();
                var Result = await middleTier.GetAlimentacionDia(objFiltro);

                //Estos datos quedan quemados de acuerdo a lo que platicamos que estos calculo los haria un servicio que programarias.
                TitleList.Add("Lunes"); TitleList.Add("Martes"); TitleList.Add("Miercoles"); TitleList.Add("Jueves"); TitleList.Add("Viernes");
                MetaList.Add(100); MetaList.Add(50); MetaList.Add(90); MetaList.Add(100); MetaList.Add(55);
                ComidoList.Add(25); ComidoList.Add(25); ComidoList.Add(25); ComidoList.Add(25); ComidoList.Add(25);

                ViewBag.MetaList = MetaList;
                ViewBag.ComidoList = ComidoList;
                ViewBag.MaxMeta = MetaList.Max();
                ViewBag.AvgMeta = MetaList.Average();
                ViewBag.AvgComidos = ComidoList.Average();

                return View(Result);
            }
        }

        public async Task<ActionResult> Read([DataSourceRequest] DataSourceRequest request)
        {
            using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                Ekilibrate.Model.Entity.Participante.clsAlimentacionDiaFiltro objFiltro = new Ekilibrate.Model.Entity.Participante.clsAlimentacionDiaFiltro();
                BarcoSoftUtilidades.Seguridad.Usuario user = this.HttpContext.GetActualUser();
                objFiltro.ParticipanteId = user.IdPersona;
                TempData["filtro"] = objFiltro;

                var middleTier = scope.Resolve<Ekilibrate.Model.Services.Participante.IDataRetriever>();
                var Result = await middleTier.GetAlimentacionDia(objFiltro);
                return Json(Result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public async Task<ActionResult> Update([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<Ekilibrate.Model.Entity.Participante.clsAlimentacionDiaBase> model)
        {
            try
            {
                if (model != null && ModelState.IsValid)
                {
                    using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                    {
                        var middleTier = scope.Resolve<Ekilibrate.Model.Services.Participante.IDataInjector>();
                        await middleTier.SincronizarAlimentacionDia(model);
                        return Json(model.ToDataSourceResult(request, ModelState));
                    }

                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return Json(model.ToDataSourceResult(request, ModelState));
        }
    }
}