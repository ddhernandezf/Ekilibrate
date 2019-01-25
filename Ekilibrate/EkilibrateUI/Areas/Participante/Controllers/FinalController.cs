using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BarcoSoftUtilidades.Seguridad;

namespace EkilibrateUI.Areas.Participante.Controllers
{
    [BarcoSoftAuthorize]
    public class FinalController : Controller
    {
        // GET: Participante/Final
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}