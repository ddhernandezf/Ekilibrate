using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BarcoSoftUtilidades.Seguridad;

namespace EkilibrateUI.Areas.Participante.Controllers
{
    [BarcoSoftAuthorize]
    public class SaludController : Controller
    {
        // GET: Participante/Salud
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult ActividadFisica()
        {
            return PartialView("ActividadFisica");
        }

        public PartialViewResult Condiciones()
        {
            return PartialView("Condiciones");
        }
    }
}