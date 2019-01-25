using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using BarcoSoftUtilidades;

namespace SitioAdministrativoUI.Models.Data
{
    public partial class BarcoSoftDBEntities
    {
        /// <summary>
        /// Constructor para utilizar cadena de conexión encryptada.
        /// </summary>
        /// <param name="stupidParameter">Parametro estupido para utilizar cadena de conexión encriptada.</param>
        public BarcoSoftDBEntities(bool stupidParameter = true)
            : base(DecryptConnectionString())
        {

        }

        /// <summary>
        /// retornar cadena de conexión ya desencriptada.
        /// </summary>
        /// <returns></returns>
        private static string DecryptConnectionString()
        {
            string className = "SitioAdministrativoUI";
            return String.Format(ConfigurationManager.ConnectionStrings["BarcoSoftDBPrincipal"].ConnectionString.Decrypt(), String.Format("res://*/Models.Data.{0}.csdl|res://*/Models.Data.{0}.ssdl|res://*/Models.Data.{0}.msl", className));
        }
    }
}