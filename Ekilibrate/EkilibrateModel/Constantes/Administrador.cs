using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.Model.Constantes
{
    namespace Administrador
    {
        namespace Proyecto
        {
            public static class TipoProyecto
            {
                public const int Essential = 1;
                public const int Progress = 2;
                public const int Transform = 3;
            }

            public static class Estado
            {
                public const string EnRegistro = "EN REGISTRO";
                public const string CreacionParticipantes = "CREACIÓN DE PARTICIPANTES";
                public const string Preparacion = "PREPARACIÓN";
                public const string EnEjecucion = "EN EJECUCIÓN";
                public const string Finalizado = "FINALIZADO";
            }
        }
    }
}
