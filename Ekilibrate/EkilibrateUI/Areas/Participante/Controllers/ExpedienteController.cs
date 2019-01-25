using Ekilibrate.Model.Entity.Nutricionista;
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
using BarcoSoftUtilidades;
using BarcoSoftUtilidades.Seguridad;

namespace EkilibrateUI.Areas.Participante.Controllers
{
    [BarcoSoftAuthorize]
    public class ExpedienteController : Controller
    {
        //GET: Participante/Expediente
        [BarcoSoftUtilidades.Seguridad.BarcoSoftAuthorize]
        public async Task<ActionResult> Index()
        {
            //return View();
            Ekilibrate.Model.Entity.Participante.ResumenExpediente model = new Ekilibrate.Model.Entity.Participante.ResumenExpediente();
            Ekilibrate.Model.Entity.Participante.clsExpedienteFiltro Filtro = new Ekilibrate.Model.Entity.Participante.clsExpedienteFiltro();

            BarcoSoftUtilidades.Seguridad.Usuario user = this.HttpContext.GetActualUser();

            if (user == null)
                return Redirect("~/SitioAdministrativo/Home/Login?ReturnUrl=%2fParticipante%2fExpediente");
            
            using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                //1. Resumen
                var middleTier = scope.Resolve<Ekilibrate.Model.Services.Participante.IDataRetriever>();
                model = await middleTier.GetResumenExpediente(user.IdPersona);
                model.REDgeneral = model.VET - model.RED;

                //2. Pasos
                List<String> TitleList = new List<String>();
                List<Int32> MetaList = new List<Int32>();
                List<Int32> PasosList = new List<Int32>();
                List<Int32> MetaCompaList = new List<Int32>();
                List<Int32> PasosCompaList = new List<Int32>();

                var Pasos = await middleTier.GetPasosDia(user.IdPersona);
                
                if (Pasos.Count() > 0)
                {
                    var compa = Pasos.FirstOrDefault();
                    ViewBag.NombreCompa = compa.NombreCompa;
                    ViewBag.IdCompa = compa.IdCompa;

                    ViewBag.FechaInicio = compa.FechaInicio;
                    ViewBag.FechaFin = compa.FechaFin;
                }
                else
                {
                    ViewBag.NombreCompa = string.Empty;
                    ViewBag.IdCompa = 0;
                }

                //List<Ekilibrate.Model.Entity.Participante.clsPasosDiaBase> lresult = (List<Ekilibrate.Model.Entity.Participante.clsPasosDiaBase>)Result;

                Pasos.OrderBy(y => y.Dia).ToList().ForEach(x =>
                {
                    TitleList.Add(x.NombreDia);
                    MetaList.Add(x.Meta);
                    PasosList.Add(x.Caminados);
                    MetaCompaList.Add(x.MetaCompa);
                    PasosCompaList.Add(x.CaminadosCompa);
                });

                ViewBag.TitleList = TitleList;
                ViewBag.MetaList = MetaList;
                ViewBag.PasosList = PasosList;
                ViewBag.MetaCompaList = MetaCompaList;
                ViewBag.PasosCompaList = PasosCompaList;

                if (MetaList.Count > 0)
                {
                    ViewBag.MaxMeta = MetaList.Max();
                    ViewBag.AvgMeta = MetaList.Average();
                    ViewBag.MaxMetaCompa = MetaCompaList.Max();
                    ViewBag.AvgMetaCompa = MetaCompaList.Average();
                }
                else
                {
                    ViewBag.MaxMeta = 0;
                    ViewBag.AvgMeta = 0;
                    ViewBag.MaxMetaCompa = 0;
                    ViewBag.AvgMetaCompa = 0;
                }

                if (PasosList.Count > 0)
                { 
                    ViewBag.AvgPasos = PasosList.Average();
                    ViewBag.CountPasos = PasosList.Sum();
                    ViewBag.AvgPasosCompa = PasosCompaList.Average();
                    ViewBag.CountPasosCompa = PasosCompaList.Sum();
                }
                else
                { 
                    ViewBag.AvgPasos = 0;
                    ViewBag.CountPasos = 0;
                    ViewBag.AvgCompaPasos = 0;
                    ViewBag.CountCompaPasos = 0;
                }

                ViewBag.Pasos = Pasos;

                //3. Alimentacion
                List<String> ATitleList = new List<String>();
                List<Decimal> AMetaList = new List<Decimal>();
                List<Decimal> ComidoList = new List<Decimal>();

                Ekilibrate.Model.Entity.Participante.clsAlimentacionDiaFiltro objFiltro = new Ekilibrate.Model.Entity.Participante.clsAlimentacionDiaFiltro();
                objFiltro.ParticipanteId = user.IdPersona;                
                var Alimentacion = await middleTier.GetAlimentacionDia(objFiltro);

                //Estos datos quedan quemados de acuerdo a lo que platicamos que estos calculo los haria un servicio que programarias.
                Alimentacion.OrderBy(y => y.Dia).ToList().ForEach(x =>
                {
                    ATitleList.Add(x.NombreDia);
                    AMetaList.Add(x.Meta);
                    ComidoList.Add(x.Comido);                    
                });

                ViewBag.AMetaList = AMetaList;
                ViewBag.ComidoList = ComidoList;
                ViewBag.MaxAMeta = AMetaList.Max();
                ViewBag.AvgAMeta = AMetaList.Average();
                ViewBag.AvgComidos = ComidoList.Average();                

                //6. Crecimiento Personal
                ViewBag.ModelCP = await middleTier.GetExpedienteCrecimientoPersonal(user.IdPersona);

                //7. Cuadro de metas
                var middleTierNut = scope.Resolve<Ekilibrate.Model.Services.Nutricionista.IDataRetriever>();
                var resultSeg = await middleTierNut.GetSeguimientoActual(user.IdPersona);
                resultSeg.ReadOnly = true;
                ViewBag.ModelSeg = resultSeg;

                //8. Plan de Alimentacion
                var Plan = await middleTierNut.GetPlanAlimentacion(resultSeg.CitaId, resultSeg.ParticipanteId);
                Plan.ReadOnly = true;
                ViewBag.ModelPlan = Plan;
            }

            return PartialView(model);
        }

        //[BarcoSoftUtilidades.Seguridad.BarcoSoftAuthorize]
        //public ActionResult Index()
        //{
        //    return View();
        //}


        #region Estado Salud

        [BarcoSoftUtilidades.Seguridad.BarcoSoftAuthorize]
        public async Task<ActionResult> EstadoSaludExpediente(int? IdParticipante)
        {
            Ekilibrate.Model.Entity.Participante.clsExpedienteEstadoSalud model = new Ekilibrate.Model.Entity.Participante.clsExpedienteEstadoSalud();
            Ekilibrate.Model.Entity.Participante.clsExpedienteFiltro Filtro = new Ekilibrate.Model.Entity.Participante.clsExpedienteFiltro();
            BarcoSoftUtilidades.Seguridad.Usuario user = this.HttpContext.GetActualUser();

            if (IdParticipante == null)
                IdParticipante = user.IdPersona;

            Filtro.ID_PARTICIPANTE = (int)IdParticipante;
            using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
               var middleTier = scope.Resolve<Ekilibrate.Model.Services.Participante.IDataRetriever>();
                model = await middleTier.GetExpedienteEstadoSalud(Filtro);
            }

            return  PartialView(model);
        }

        public async Task<ActionResult> Read_Aspectos([DataSourceRequest] DataSourceRequest request)
        {
            using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                Ekilibrate.Model.Entity.Nutricionista.clsSeguimientoAspectosFiltro objFiltro = null;
                BarcoSoftUtilidades.Seguridad.Usuario user = this.HttpContext.GetActualUser();
                if (user != null)
                {
                    objFiltro =
                   new clsSeguimientoAspectosFiltro
                   {
                       CitaId = 1,
                       ParticipanteId = user.IdPersona
                   };
                }
                else
                {
                    objFiltro =
                  new clsSeguimientoAspectosFiltro
                  {
                      CitaId = 1,
                      ParticipanteId = 1
                  };
                }

                var middleTier = scope.Resolve<Ekilibrate.Model.Services.Nutricionista.IDataRetriever>();
                var Result = await middleTier.GetSeguimientoAspectos(objFiltro.ParticipanteId, objFiltro.CitaId);
                return Json(Result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
            }
        }
        #endregion



        [BarcoSoftUtilidades.Seguridad.BarcoSoftAuthorize]
        public async Task<ActionResult> ManejoEmociones(int? IdParticipante)
        {
            Ekilibrate.Model.Entity.Participante.clsExpedienteManejoEmociones model = new Ekilibrate.Model.Entity.Participante.clsExpedienteManejoEmociones();
            Ekilibrate.Model.Entity.Participante.clsExpedienteFiltro Filtro = new Ekilibrate.Model.Entity.Participante.clsExpedienteFiltro();
            BarcoSoftUtilidades.Seguridad.Usuario user = this.HttpContext.GetActualUser();
            Filtro.ID_PARTICIPANTE = user.IdPersona;
            using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                var middleTier = scope.Resolve<Ekilibrate.Model.Services.Participante.IDataRetriever>();
                model = await middleTier.GetExpedienteManejoEmociones(Filtro);
            }

            return PartialView(model);
        }


        [BarcoSoftUtilidades.Seguridad.BarcoSoftAuthorize]
        public async Task<ActionResult> RelacionesInterpersonales(int? IdParticipante)
        {
            Ekilibrate.Model.Entity.Participante.clsExpedienteRelacionesInterpersonales model = new Ekilibrate.Model.Entity.Participante.clsExpedienteRelacionesInterpersonales();
            Ekilibrate.Model.Entity.Participante.clsExpedienteFiltro Filtro = new Ekilibrate.Model.Entity.Participante.clsExpedienteFiltro();
            BarcoSoftUtilidades.Seguridad.Usuario user = this.HttpContext.GetActualUser();
            Filtro.ID_PARTICIPANTE = user.IdPersona;
            using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                var middleTier = scope.Resolve<Ekilibrate.Model.Services.Participante.IDataRetriever>();
                model = await middleTier.GetExpedienteRelacionesInterpersonales(Filtro);
            }

            return PartialView(model);
        }
    }
}