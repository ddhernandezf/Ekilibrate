using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using BarcoSoftUtilidades;

namespace EkilibrateUI.Areas.SitioAdministrativo.Models.Data
{
    public partial class EkiibrateDBEntities
    {
        /// <summary>
        /// Constructor para utilizar cadena de conexión encryptada.
        /// </summary>
        /// <param name="stupidParameter">Parametro estupido para utilizar cadena de conexión encriptada.</param>
        public EkiibrateDBEntities(bool stupidParameter = true)
            : base(DecryptConnectionString())
        {

        }

        /// <summary>
        /// retornar cadena de conexión ya desencriptada.
        /// </summary>
        /// <returns></returns>
        private static string DecryptConnectionString()
        {
            string className = "Areas.SitioAdministrativo.Models.Data.SitioAdministrativoUI";
            return String.Format(ConfigurationManager.ConnectionStrings["EkilibrateEF"].ConnectionString, String.Format("res://*/{0}.csdl|res://*/{0}.ssdl|res://*/{0}.msl", className));
        }
    }
}