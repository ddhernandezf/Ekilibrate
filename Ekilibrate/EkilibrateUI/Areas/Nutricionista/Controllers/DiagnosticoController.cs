using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ekilibrate.Model.Entity.Nutricionista;
using Autofac;
using System.Threading.Tasks;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using Ekilibrate.Model.Common;
using BarcoSoftUtilidades.Utilidades;
using BarcoSoftUtilidades;
using System.Web.Script.Serialization;
using BarcoSoftUtilidades.Seguridad;

namespace EkilibrateUI.Areas.Nutricionista.Controllers
{
    [BarcoSoftAuthorize]
    public class DiagnosticoController : Controller
    {
        // GET: Nutricionista/Diagnostico
        [BarcoSoftUtilidades.Seguridad.BarcoSoftAuthorize]
        public async Task<ActionResult> Index()
        {
            using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                var middleTier = scope.Resolve<Ekilibrate.Model.Services.Nutricionista.IDataRetriever>();
                int Participante = Convert.ToInt32(Request.QueryString["P"].ToString());
                int Cita = Convert.ToInt32(Request.QueryString["C"].ToString());
                var Result = await middleTier.GetDiagnostico(Participante, Cita);
                if (Result == null)
                    Result = new Ekilibrate.Model.Entity.Nutricionista.Diagnostico();

                return View(Result);
            }
        }



        public async Task<ActionResult> Read([DataSourceRequest] DataSourceRequest req, string Par, string Ci)
        {
            using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                var middleTier = scope.Resolve<Ekilibrate.Model.Services.Nutricionista.IDataRetriever>();
                int Participante = Convert.ToInt32(Par);
                int Cita = Convert.ToInt32(Ci);
                var Result = await middleTier.GetAlimentos(Participante, Cita);
                ViewBag.Alimentos = Result;
                return Json(Result.ToDataSourceResult(req), JsonRequestBehavior.AllowGet);                
            }
        }

        public async Task<ActionResult> Read_Anam([DataSourceRequest] DataSourceRequest request, string Par, string Ci)
        {

            using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                var middleTier = scope.Resolve<Ekilibrate.Model.Services.Nutricionista.IDataRetriever>();

                BarcoSoftUtilidades.Seguridad.Usuario user = this.HttpContext.GetActualUser();

                int Participante = Convert.ToInt32(Par);
                int Cita = Convert.ToInt32(Ci);
                int Nutricionista = user.Nutricionista.idNutricionista;
                
                var Result = await middleTier.GetAnamnesis(Nutricionista, Participante, Cita);
                ViewBag.Anamnesia = Result;
                return Json(Result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
                //return View("Formulario");
            }

        }

        private bool IsNumber(string Number)
        {
            for (int i = 0; i < Number.Length; i++)
            {
                if (!char.IsNumber(Number[i]))
                {
                    return false;
                }
            }

            return true;
        }


        [AcceptVerbs(HttpVerbs.Post)]
        public async Task<ActionResult> Update_Anamnesis([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<DiagnosticoAnamnesisTiempo> Anamnesis, string Par, string Ci)
        {
            if (Anamnesis != null && ModelState.IsValid)
            {
                BarcoSoftUtilidades.Seguridad.Usuario user = this.HttpContext.GetActualUser();

                foreach (var Anam in Anamnesis)
                {
                    Anam.GrupoAlimentoId = Anam.GrupoAlimentoId;
                    Anam.NutricionistaId = user.Nutricionista.idNutricionista;
                    Anam.ParticipanteId = Convert.ToInt16(Par);
                    Anam.Porciones = Anam.Porciones;
                    Anam.CitaId = Convert.ToInt16(Ci);
                    //Anam.NombreColumna = Anam.
                }

                using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                {
                    var middleTier = scope.Resolve<Ekilibrate.Model.Services.Nutricionista.IDataInjector>();
                    await middleTier.CreateDiagnosticoAnamnesis(Anamnesis);
                }

            }

            return Json(Anamnesis.ToDataSourceResult(request, ModelState));

            //return Json(Alimentos.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public async Task<ActionResult> Update_Alimentos([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<DiagnosticoAlimentos> Alimentos, string Par, string Ci)
        {
            if (Alimentos != null && ModelState.IsValid)
            {
                BarcoSoftUtilidades.Seguridad.Usuario user = this.HttpContext.GetActualUser();
                foreach (var Anam in Alimentos)
                {
                    Anam.ParticipanteId = Convert.ToInt16(Par);
                    Anam.CitaId = Convert.ToInt16(Ci);
                    Anam.NutricionistaId = user.Nutricionista.idNutricionista;
                }
            }

            using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                var middleTier = scope.Resolve<Ekilibrate.Model.Services.Nutricionista.IDataInjector>();
                await middleTier.CreateDiagnosticoAlimentos(Alimentos);
            }

            return Json(Alimentos.ToDataSourceResult(request, ModelState));

        }

        [HttpPost]
        public async Task<ActionResult> AgregaFormulario(Diagnostico model, string P, string C)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Index", model);
                }

                BarcoSoftUtilidades.Seguridad.Usuario user = this.HttpContext.GetActualUser();

                string Participante = string.Empty;
                int Nutricionista = 0;
                int Cita = 0;

                Participante = Request.QueryString["P"].ToString();
                Nutricionista = user.IdPersona;
                Cita = Convert.ToInt32(C);

                if (IsNumber(Participante))
                {
                    Diagnostico diagnostico = new Diagnostico();
                    model.NutricionistaId = Nutricionista;
                    model.CitaId = Cita;
                    model.ParticipanteId = Convert.ToInt16(Participante);                    

                    using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                    {
                        var middleTier = scope.Resolve<Ekilibrate.Model.Services.Nutricionista.IDataInjector>();
                        await middleTier.CreateDiagnostico(model);
                    }
                }

                return Redirect("../Diagnostico/FinCitas");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View("Index", model);
            }
        }

        // GET: Nutricionista/Home
        public ActionResult Citas()
        {
            return View();
        }

        public ActionResult AnalisisCitas()
        {
            return View();
        }

        public ActionResult FinCitas()
        {
            return View();
        }

        public ActionResult Analisis(int? IdParticipante)
        {

            return View(IdParticipante);
        }

        public ActionResult MetaPasos(int? IdParticipante)
        {
            return PartialView(IdParticipante);
        }

        public async Task<ActionResult> Read_MetasPasos([DataSourceRequest] DataSourceRequest request, int? IdParticipante)
        {
            Ekilibrate.Model.Entity.Nutricionista.clsMetaPasosFiltro Filtro = new clsMetaPasosFiltro();
            var user = this.HttpContext.GetActualUser();
            Filtro.ParticipanteId = IdParticipante == null ? user.IdPersona : (int)IdParticipante;
            using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                var middleTier = scope.Resolve<Ekilibrate.Model.Services.Nutricionista.IDataRetriever>();
                var Result = await middleTier.GetMetaPasos(Filtro.ParticipanteId);

                return Json(Result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
                //return View("Formulario");
            }

        }
    }
}
