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
    public class CuidadoController : Controller
    {
        // GET: Participante/Cuidado
        public  async Task<ActionResult> Index()
        {
            try
            {
                using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                {
                    BarcoSoftUtilidades.Seguridad.Usuario user = this.HttpContext.GetActualUser();

                    if (user == null)
                        return Redirect("~/SitioAdministrativo/Home/Login?ReturnUrl=%2fParticipante%2fCuidado");

                    var middleTier = scope.Resolve<Ekilibrate.Model.Services.Participante.IDataRetriever>();
                    var Result = await middleTier.GetCuidados(user.IdPersona);

                    if (Result == null)
                    {
                        Result = new Ekilibrate.Model.Entity.Participante.clsCuidado();
                        Result.ActividadFisica = new Ekilibrate.Model.Entity.Participante.clsActividadFisica();
                        Result.Padecimiento = new Ekilibrate.Model.Entity.Participante.clsPadecimiento();
                    }

                    ViewBag.TipoEjercicio = await middleTier.GetTipoEjercicio();


                    return View(Result);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        [HttpPost]
        public async Task<ActionResult> Index(Ekilibrate.Model.Entity.Participante.clsCuidado model, string accion)
        {            
            using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                if (model != null && ModelState.IsValid)
                {
                    var middleTierDr = scope.Resolve<Ekilibrate.Model.Services.Participante.IDataRetriever>();
                    try
                    {                    
                        BarcoSoftUtilidades.Seguridad.Usuario user = this.HttpContext.GetActualUser();
                        var middleTier = scope.Resolve<Ekilibrate.Model.Services.Participante.IDataInjector>();
                        
                        int participante = model.ActividadFisica.ID_PARTICIPANTE;
                        if (participante == 0)
                        {
                            model.ActividadFisica.ID_PARTICIPANTE = user.IdPersona;
                            model.Padecimiento.ID_PARTICIPANTE = user.IdPersona;
                            await middleTier.CreateCuidado(model);
                        }
                        else
                            await middleTier.UpdateCuidado(model);

                        if (accion == "Siguiente")
                            return Redirect("../Participante/Emocion");

                        model = await middleTierDr.GetCuidados(user.IdPersona);
                                                
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);
                    }
                    
                    ViewBag.TipoEjercicio = await middleTierDr.GetTipoEjercicio();
                }   
            }
            
            return View(model);
            
        }
                      
        [HttpPost]
        public async Task<ActionResult> AddCondicionPreExistente(int pID_CONDICION, string pCondicion_Respuesta)
        {
            try
            {
                using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                {
                    var user = this.HttpContext.GetActualUser();

                    var middleTier = scope.Resolve<Ekilibrate.Model.Services.Participante.IDataInjector>();
                    await middleTier.CreateCondicionPreExistente(new Ekilibrate.Model.Entity.Participante.clsCondicionPreExistenteBase()
                    {
                        ID_CONDICION = pID_CONDICION,
                        ID_PARTICIPANTE = user.IdPersona,
                        RESPUESTA = pCondicion_Respuesta

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
        public async Task<ActionResult> DeleteCondicionPreExistente(int pID_CONDICION)
        {
            try
            {
                using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                {
                    var user = this.HttpContext.GetActualUser();

                    var middleTier = scope.Resolve<Ekilibrate.Model.Services.Participante.IDataInjector>();
                    await middleTier.DeleteCondicionPreExistente(new Ekilibrate.Model.Entity.Participante.clsCondicionPreExistenteBase()
                    {
                        ID_CONDICION = pID_CONDICION,
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