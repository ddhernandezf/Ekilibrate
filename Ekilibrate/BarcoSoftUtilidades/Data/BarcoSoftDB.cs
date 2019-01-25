using System;
using System.Configuration;
using System.Linq;

namespace BarcoSoftUtilidades.Data
{
    public partial class BarcoSoftUtilidadesDB
    {
        /// <summary>
        /// Constructor para utilizar cadena de conexión encryptada.
        /// </summary>
        /// <param name="stupidParameter">Parametro estupido para utilizar cadena de conexión encriptada.</param>
        public BarcoSoftUtilidadesDB(bool stupidParameter = true)
            : base(DecryptConnectionString())
        {

        }

        /// <summary>
        /// retornar cadena de conexión ya desencriptada.
        /// </summary>
        /// <returns></returns>
        private static string DecryptConnectionString()
        {
            string className = "BarcoSoftUtilidadesDB";
            return String.Format(ConfigurationManager.ConnectionStrings["EkilibrateEF"].ConnectionString, String.Format("res://*/Data.{0}.csdl|res://*/Data.{0}.ssdl|res://*/Data.{0}.msl", className));
        }
    }
}
