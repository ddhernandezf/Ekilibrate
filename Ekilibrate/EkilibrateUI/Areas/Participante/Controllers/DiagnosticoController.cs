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
    public class DiagnosticoController : Controller
    {
        // GET: Participante/Diagnostico
        public async Task<ActionResult> Index()
        {
            using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                Ekilibrate.Model.Entity.Participante.clsDiagnosticoFiltro objFiltro = new Ekilibrate.Model.Entity.Participante.clsDiagnosticoFiltro();
                BarcoSoftUtilidades.Seguridad.Usuario user = this.HttpContext.GetActualUser();
                
                if (user == null)
                    return Redirect("~/SitioAdministrativo/Home/Login?ReturnUrl=%2fParticipante%2fDiagnostico");

                objFiltro.ID_PARTICIPANTE = user.IdPersona;

                var middleTier = scope.Resolve<Ekilibrate.Model.Services.Participante.IDataRetriever>();
                var Result = await middleTier.GetDiagnosticos(objFiltro);

                if (Result != null)
                {
                    return View(Result);
                }
                else
                {
                    return View(new Ekilibrate.Model.Entity.Participante.clsDiagnosticoBase());
                }
            }
        }

        [HttpPost]
        public async Task<ActionResult> Index(Ekilibrate.Model.Entity.Participante.clsDiagnosticoBase model, string accion)
        {            
            return await GrabarInformacionGeneral(model, accion);
        }

        //[HttpPost]
        //[MultipleButton(Name = "action", Argument = "Guardar")]
        //public async Task<ActionResult> Guardar(Ekilibrate.Model.Entity.Participante.clsDiagnosticoBase model) 
        //{
        //    return await GrabarInformacionGeneral(model, false);
        //}

        //[HttpPost]
        //[MultipleButton(Name = "action", Argument = "Siguiente")]
        //public async Task<ActionResult> Siguiente(Ekilibrate.Model.Entity.Participante.clsDiagnosticoBase model) 
        //{
        //    return await GrabarInformacionGeneral(model, true);
        //}
        
        private async Task<ActionResult> GrabarInformacionGeneral(Ekilibrate.Model.Entity.Participante.clsDiagnosticoBase model, string accion)
        {
            try
            {
                BarcoSoftUtilidades.Seguridad.Usuario user = this.HttpContext.GetActualUser();
                int? participante = model.ID_PARTICIPANTE;

                if (model.SEXO == "MASCULINO")
                {
                    model.FEC_NAC_BEBE = null;
                    model.FEC_ULT_MENSTRUACION = null;
                    model.MUJER_EMBARAZADA = false;
                }
                else
                {
                    if (model.FEC_ULT_MENSTRUACION != null)
                    {
                        model.MUJER_EMBARAZADA = true;
                    }
                    else
                    {
                        model.MUJER_EMBARAZADA = false;
                    }

                    if (model.FEC_NAC_BEBE != null)
                    {
                        model.MUJER_LACTANCIA = true;
                    }
                    else
                    {
                        model.MUJER_LACTANCIA = false;
                    }
                }

                if (model != null && ModelState.IsValid)
                {
                    using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                    {
                        var middleTier = scope.Resolve<Ekilibrate.Model.Services.Participante.IDataInjector>();
                        if (participante == null)
                            await middleTier.CreateDiagnostico(model);
                        else
                            await middleTier.UpdateDiagnostico(model);

                        if (accion == "Siguiente")
                            return Redirect("../Participante/Alimentacion");
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(model);
        }

        


    }
}