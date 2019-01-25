using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcoSoftUtilidades.Seguridad
{
    public class Parametro
    {

        public enum Enumerable
        {
            PáginaAccesodenegadoString = 1,
        }

        /// <summary>
        /// Enumerable tipo de parametro.
        /// </summary>
        public enum TipoParametro
        {
            String = 1,
            Entero = 2,
            Decimal = 3,
            Booleano = 4,
            FechaHora = 5,
            Hora = 6,
            EncryptString = 7,
        }


        /// <summary>
        /// Valor 
        /// </summary>
        public string Valor { get; set; }

        /// <summary>
        /// Identificador del parametro general en la base de datos (corresponde a un enumerable dentro de esta misma clase).
        /// </summary>
        public int IdParametro { get; private set; }

        /// <summary>
        /// Propeitario del parametro.
        /// </summary>
        public int IdPropietario { get; set; }

        /// <summary>
        /// Establece el tipo de parametro que es(ver enumerable).
        /// </summary>
        public int IdParametroTipo { get; set; }

        /// <summary>
        /// Constructor con el parametro a buscar
        /// </summary>
        /// <param name="pIdParametro"></param>
        public Parametro(int pIdParametro)
        {
            IdParametro = pIdParametro;
            Valor = string.Empty;
            GetParameter();
        }

        /// <summary>
        /// Constructor con el parametro a buscar
        /// </summary>
        /// <param name="pIdParametro"></param>
        public Parametro(Enumerable pIdParametro)
        {
            IdParametro =  (int)pIdParametro;
            Valor = string.Empty;
            GetParameter();
        }

        /// <summary>
        /// Método interno para buscar el parametro 
        /// </summary>
        private void GetParameter()
        {
            try
            {
                Data.BarcoSoftUtilidadesDB db = new Data.BarcoSoftUtilidadesDB(true);
                Data.ParametroGeneral result = db.ParametroGeneral.Where(x => x.IdParametroGeneral == this.IdParametro).FirstOrDefault();
                if (result != null)
                {
                    this.Valor = result.Valor;
                    this.IdParametro = result.IdParametroGeneral;
                    this.IdParametroTipo = (int)result.IdParametroTipo;
                }
            }
            catch (Exception ex)
            {
                String className = "ParametroGeneral";
                String methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                throw new Exception(className + " " + methodName + ": " + ex.Message);
            }
        }
    }
}
