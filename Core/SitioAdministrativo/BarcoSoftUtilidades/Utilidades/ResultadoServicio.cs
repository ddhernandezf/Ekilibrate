using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcoSoftUtilidades.Utilidades
{
    [Serializable]
    public class ResultadoServicio
    {
        public string MensajeError { get; private set; }

        public bool OperacionExitosa { get; private set; }

        public void RegistrarError(string pMensajeError)
        {
            this.OperacionExitosa = false;
            this.MensajeError = pMensajeError;
        }

        public void RegistrarExito()
        {
            this.OperacionExitosa = true;
        }

        public ResultadoServicio()
        {
            this.MensajeError = string.Empty;
            this.OperacionExitosa = true;
        }
    }
}
