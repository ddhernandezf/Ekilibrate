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
    public class EmocionController : Controller{
   
        // GET: Participante/Emocion
        public async Task<ActionResult> Index()
        {
            using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                BarcoSoftUtilidades.Seguridad.Usuario user = this.HttpContext.GetActualUser();

                if (user == null)
                    return Redirect("~/SitioAdministrativo/Home/Login?ReturnUrl=%2fParticipante%2fEmocion");
                
                var middleTier = scope.Resolve<Ekilibrate.Model.Services.Participante.IDataRetriever>();
                ViewBag.Emocion = await middleTier.GetAnsiedades(user.IdPersona);

                return View();
            }

        }
               
        [HttpPost]
        public async Task<ActionResult> Index(Ekilibrate.Model.Entity.Participante.clsEmocionBase model)
        {
            try
            {
                using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                {
                    BarcoSoftUtilidades.Seguridad.Usuario user = this.HttpContext.GetActualUser();

                    if (user == null)
                        return Redirect("~/SitioAdministrativo/Home/Login?ReturnUrl=%2fParticipante%2fEmocion");

                    var middleTier = scope.Resolve<Ekilibrate.Model.Services.Participante.IDataRetriever>();
                    ViewBag.Emocion = await middleTier.GetAnsiedades(user.IdPersona);

                    return View();
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(model);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [HttpPost]
        public async Task<ActionResult> AddAnsiedad(int pID_ANSIEDAD)
        {
            try
            {
                using(var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                {
                    var user = this.HttpContext.GetActualUser();
                    if (user == null)
                        return Redirect("~/SitioAdministrativo/Home/Login?ReturnUrl=%2fParticipante%2fEmocion");

                    var middleTier = scope.Resolve<Ekilibrate.Model.Services.Participante.IDataInjector>();
                    await middleTier.CreateAnsiedad(new Ekilibrate.Model.Entity.Participante.clsAnsiedadBase() { ID_ANSIEDAD = pID_ANSIEDAD, ID_PARTICIPANTE = user.IdPersona });
                }
                return Json(new { success = true, error = "" });
            }
            catch (Exception ex)
            {

                return Json(new { success = false, error = ex.Message });
            }

        }


        [HttpPost]
        public async Task<ActionResult> DeleteAnsiedad(int pID_ANSIEDAD)
        {
            try
            {
                using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                {
                    var user = this.HttpContext.GetActualUser();
                    if (user == null)
                        return Redirect("~/SitioAdministrativo/Home/Login?ReturnUrl=%2fParticipante%2fEmocion");

                    var middleTier = scope.Resolve<Ekilibrate.Model.Services.Participante.IDataInjector>();
                    await middleTier.DeleteAnsiedad(new Ekilibrate.Model.Entity.Participante.clsAnsiedadBase()
                    {
                        ID_ANSIEDAD = pID_ANSIEDAD,
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