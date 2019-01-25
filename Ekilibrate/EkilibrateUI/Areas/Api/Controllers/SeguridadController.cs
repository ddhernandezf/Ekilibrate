
using System.Collections.Generic;
using System.Web.Mvc;

namespace EkilibrateUI.Areas.Api.Controllers
{
    public class SeguridadController : Controller
    {
        
        [AllowAnonymous]
        [Route("MobileLogin/{UserName}/{Password}")]
        public JsonResult MobileLogin(string UserName, string Password)
        {
            var ValidateResult = new List<object>();
            
            BarcoSoftUtilidades.Seguridad.Usuario u = BarcoSoftUtilidades.Seguridad.Usuario.MobileLogin(UserName, Password);
            ValidateResult.Add(u);
            return Json(ValidateResult, JsonRequestBehavior.AllowGet);
        }
    }
}