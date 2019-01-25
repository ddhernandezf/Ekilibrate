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
    public class ReprogramacionController : Controller
    {
        // GET: Nutricionista/Reprogramacion
        public ActionResult Index(string Par, string Ci, string Nu, string Fe)
        {
            @ViewBag.Fecha = Fe;
            return View();
        }

        public async Task<ActionResult> Read([DataSourceRequest] DataSourceRequest request, string fecha)
        {
            BarcoSoftUtilidades.Seguridad.Usuario user = this.HttpContext.GetActualUser();
            using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                clsCitaFiltro objFiltro = new clsCitaFiltro();
                objFiltro.NutricionistaId = user.Nutricionista.idNutricionista;

                string[] fechas = null;

                if (fecha != "")
                {
                    fechas = fecha.Split('-');
                    objFiltro.Fecha = new DateTime(Convert.ToInt16(fechas[2]),Convert.ToInt16(fechas[1]), Convert.ToInt16(fechas[0]) );
                }
                else
                {
                    objFiltro.Fecha = DateTime.Now;
                }

                var middleTier = scope.Resolve<Ekilibrate.Model.Services.Nutricionista.IDataRetriever>();
                var Result = await middleTier.GetCitas(objFiltro);
                return Json(Result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
            }
        }

        public async Task<ActionResult> Reprograma(string Fe, string Par, string Nu, string Ci, string Pr, string Ho, string Mi, string Ho2, string Mi2)
        {
            try
            {
                if (Fe != null)
                {
                    Ekilibrate.Model.Entity.Administrador.clsCitaProgramacion reprogramacion = new Ekilibrate.Model.Entity.Administrador.clsCitaProgramacion();
                    using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                    {
                        string[] Fechasplit = Fe.Split('-');

                        DateTime fechaProgramada = new DateTime(Convert.ToInt16(Fechasplit[2]), Convert.ToInt16(Fechasplit[1]), Convert.ToInt16(Fechasplit[0]));
                        reprogramacion.Id = Convert.ToInt32(Pr);
                        reprogramacion.CitaId = Convert.ToInt32(Ci);
                        reprogramacion.Cancelada = true;
                        reprogramacion.NutricionistaId = Convert.ToInt32(Nu);
                        reprogramacion.Fecha = fechaProgramada;
                        reprogramacion.FechaInicio = new DateTime(Convert.ToInt16(Fechasplit[2]), Convert.ToInt16(Fechasplit[1]), Convert.ToInt16(Fechasplit[0]), Convert.ToInt16(Ho), Convert.ToInt16(Mi), 0);
                        reprogramacion.FechaFin = new DateTime(Convert.ToInt16(Fechasplit[2]), Convert.ToInt16(Fechasplit[1]), Convert.ToInt16(Fechasplit[0]), Convert.ToInt16(Ho2), Convert.ToInt16(Mi2), 0);

                        if (reprogramacion.FechaInicio < reprogramacion.FechaFin)
                        {
                            var middleTier = scope.Resolve<Ekilibrate.Model.Services.Nutricionista.IDataInjector>();
                            await middleTier.UpdateCitaProgramacion(reprogramacion);
                        }
                        else
                        {
                            //error en horario
                        }
                    }
                }
                else
                {
                    //No puede reprogramar cita el mismo día
                }
                return View("Index");
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}