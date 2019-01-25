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
    public class RiesgoController : Controller
    {
        // GET: Participante/Riesgo
        public async Task<ActionResult> Index()
        {
            using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                BarcoSoftUtilidades.Seguridad.Usuario user = this.HttpContext.GetActualUser();

                if (user == null)
                    return Redirect("~/SitioAdministrativo/Home/Login?ReturnUrl=%2fParticipante%2fRiesgo");

                try
                {
                    var middleTier = scope.Resolve<Ekilibrate.Model.Services.Participante.IDataRetriever>();
                    var Result = await middleTier.GetRiesgos(user.IdPersona);
                    if (Result != null)
                    {
                        return View(Result);
                    }
                    else
                        return View(new Ekilibrate.Model.Entity.Participante.clsRiesgoBase());
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }


        [HttpPost]
        public async Task<ActionResult> Index(Ekilibrate.Model.Entity.Participante.clsRiesgoBase model, string accion)
        {
            try
            {   
                if (model != null && ModelState.IsValid)
                {
                    using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                    {
                        BarcoSoftUtilidades.Seguridad.Usuario user = this.HttpContext.GetActualUser();

                        if (user == null)
                            return Redirect("~/SitioAdministrativo/Home/Login?ReturnUrl=%2fParticipante%2fRiesgo");

                        var middleTierRet = scope.Resolve<Ekilibrate.Model.Services.Participante.IDataRetriever>();
                        var middleTier = scope.Resolve<Ekilibrate.Model.Services.Participante.IDataInjector>();
                        int? participante = model.ID_PARTICIPANTE;

                        if (participante == 0)
                        {
                            model.ID_PARTICIPANTE = user.IdPersona;
                            await middleTier.CreateRiesgo(model);
                        }
                        else
                            await middleTier.UpdateRiesgo(model);

                        if (accion == "Siguiente")
                            return Redirect("../Participante/Cuidado");

                        var Result = await middleTierRet.GetRiesgos(user.IdPersona);
                        return View(Result);
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);                
            }
            return View(model);
            
        }
        
        [HttpPost]
        public async Task<ActionResult> AddBebidasFrecuentes(int pID_BEBIDA, string pBebida_Respuesta)
        {
            try
            {
                using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                {
                    BarcoSoftUtilidades.Seguridad.Usuario user = this.HttpContext.GetActualUser();

                    if (user == null)
                        return Redirect("~/SitioAdministrativo/Home/Login?ReturnUrl=%2fParticipante%2fRiesgo");

                    var middleTier = scope.Resolve<Ekilibrate.Model.Services.Participante.IDataInjector>();
                    await middleTier.CreateBebidasFrecuentes(new Ekilibrate.Model.Entity.Participante.clsBebidasFrecuentesBase() {ID_BEBIDA = pID_BEBIDA, ID_PARTICIPANTE= user.IdPersona , RESPUESTA=pBebida_Respuesta
                    
                    });
                }

                return Json(new { success = true, error = "" });
            }
            catch (Exception ex)
            {

                return Json(new { success = false, error = ex.Message });
            }

        }


        [HttpPost]
        public async Task<ActionResult> DeleteBebidasFrecuentes(int pID_BEBIDA)
        {
            try
            {
                using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                {
                    BarcoSoftUtilidades.Seguridad.Usuario user = this.HttpContext.GetActualUser();

                    if (user == null)
                        return Redirect("~/SitioAdministrativo/Home/Login?ReturnUrl=%2fParticipante%2fRiesgo");

                    var middleTier = scope.Resolve<Ekilibrate.Model.Services.Participante.IDataInjector>();
                    await middleTier.DeleteBebidasFrecuentes(new Ekilibrate.Model.Entity.Participante.clsBebidasFrecuentesBase()
                    {
                        ID_BEBIDA = pID_BEBIDA,
                        ID_PARTICIPANTE = user.IdPersona,

                    });
                }

                return Json(new { success = true, error = "" });
            }
            catch (Exception ex)
            {

                return Json(new { success = false, error = ex.Message });
            }

        }


        [HttpPost]
        public async Task<ActionResult> AddMedidaBebida(int pID_MEDIDA)
        {
            try
            {
                using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                {
                    BarcoSoftUtilidades.Seguridad.Usuario user = this.HttpContext.GetActualUser();

                    if (user == null)
                        return Redirect("~/SitioAdministrativo/Home/Login?ReturnUrl=%2fParticipante%2fRiesgo");

                    var middleTier = scope.Resolve<Ekilibrate.Model.Services.Participante.IDataInjector>();
                    await middleTier.CreateMedidaBebida(new Ekilibrate.Model.Entity.Participante.clsMedidaBebidaBase()
                    {
                        ID_MEDIDA = pID_MEDIDA,
                        ID_PARTICIPANTE = user.IdPersona,
                        RESPUESTA = "1"
                    });
                }

                return Json(new { success = true, error = "" });
            }
            catch (Exception ex)
            {

                return Json(new { success = false, error = ex.Message });
            }

        }


        [HttpPost]
        public async Task<ActionResult> DeleteMedidaBebida(int pID_MEDIDA)
        {
            try
            {
                using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                {
                    BarcoSoftUtilidades.Seguridad.Usuario user = this.HttpContext.GetActualUser();

                    if (user == null)
                        return Redirect("~/SitioAdministrativo/Home/Login?ReturnUrl=%2fParticipante%2fRiesgo");

                    var middleTier = scope.Resolve<Ekilibrate.Model.Services.Participante.IDataInjector>();
                    await middleTier.DeleteMedidaBebida(new Ekilibrate.Model.Entity.Participante.clsMedidaBebidaBase()
                    {
                        ID_MEDIDA = pID_MEDIDA,
                        ID_PARTICIPANTE = user.IdPersona,

                    });
                }

                return Json(new { success = true, error = "" });
            }
            catch (Exception ex)
            {

                return Json(new { success = false, error = ex.Message });
            }

        }

        [HttpPost]
        public async Task<ActionResult> AddEnfermedad(int IdEnfermedad)
        {
            try
            {
                using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                {
                    BarcoSoftUtilidades.Seguridad.Usuario user = this.HttpContext.GetActualUser();

                    if (user == null)
                        return Redirect("~/SitioAdministrativo/Home/Login?ReturnUrl=%2fParticipante%2fRiesgo");

                    var middleTier = scope.Resolve<Ekilibrate.Model.Services.Participante.IDataInjector>();
                    await middleTier.CreateEnfermedad(new Ekilibrate.Model.Entity.Participante.clsEnfermedadBase()
                    {
                        ID_ENFERMEDAD = IdEnfermedad,
                        ID_PARTICIPANTE = user.IdPersona,
                        RESPUESTA = "1"
                    });
                }

                return Json(new { success = true, error = "" });
            }
            catch (Exception ex)
            {

                return Json(new { success = false, error = ex.Message });
            }

        }


        [HttpPost]
        public async Task<ActionResult> DeleteEnfermedad(int IdEnfermedad)
        {
            try
            {
                using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                {
                    BarcoSoftUtilidades.Seguridad.Usuario user = this.HttpContext.GetActualUser();

                    if (user == null)
                        return Redirect("~/SitioAdministrativo/Home/Login?ReturnUrl=%2fParticipante%2fRiesgo");

                    var middleTier = scope.Resolve<Ekilibrate.Model.Services.Participante.IDataInjector>();
                    await middleTier.DeleteEnfermedad(new Ekilibrate.Model.Entity.Participante.clsEnfermedadBase()
                    {
                        ID_ENFERMEDAD = IdEnfermedad,
                        ID_PARTICIPANTE = user.IdPersona,

                    });
                }

                return Json(new { success = true, error = "" });
            }
            catch (Exception ex)
            {

                return Json(new { success = false, error = ex.Message });
            }

        }

    }
}