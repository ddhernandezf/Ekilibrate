using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EkilibrateUI.Areas.Administrador.Controllers
{
    public class HomeController : Controller
    {
        // GET: Administrador/Home
        [BarcoSoftUtilidades.Seguridad.BarcoSoftAuthorize(Objeto = (int)Accesos.Empresas)]
        public ActionResult Index()
        {
            return View();
        }
    }
}