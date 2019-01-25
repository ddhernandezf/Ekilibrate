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
using Ekilibrate.Model.Services;
using Ekilibrate.Model.Entity.Proyecto;
using Ekilibrate.Model.Entity.Participante;
using System.IO;
using System.Data;
using System.Data.OleDb;
using BarcoSoftUtilidades.Seguridad;

namespace EkilibrateUI.Areas.Cliente.Controllers
{
    [BarcoSoftAuthorize]
    public class HomeController : Controller
    {
        // GET: Cliente/Home
        public async Task<ActionResult> Index()
        {
            try
            {
                using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                {
                    BarcoSoftUtilidades.Seguridad.Usuario user = this.HttpContext.GetActualUser();
                    var middleTier = scope.Resolve<Ekilibrate.Model.Services.Administrador.IDataRetriever>();
                    ViewBag.Proyecto = await middleTier.GetProyectosEmpresa(user.Empresa.IdEmpresa);                    
                }
            }
            catch (Exception ex)
            {                
            }
            return View();
        }

        // GET: Cliente/Participante
        public ActionResult Participante(int ProyectoId)
        {

            return View();
        }

        // GET: Cliente/Participante
        public async Task<ActionResult> Proyecto(int ProyectoId)
        {

            try
            {
                using (var scope = EkilibrateUI.Autofac.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                {
                    var middleTier = scope.Resolve<Ekilibrate.Model.Services.Administrador.IDataRetriever>();
                    var result = await middleTier.GetProyecto(ProyectoId);
                    return View(result);
                }
            }
            catch (Exception ex)
            {
            }
            return View();
        }

        // GET: Cliente/Dummy
        public ActionResult Dummy()
        {
            return View();
        }
    }
}