//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BarcoSoftUtilidades.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class PR_Nutricionista
    {
        public int ProyectoId { get; set; }
        public int ColaboradorId { get; set; }
        public int RolId { get; set; }
        public int Capacidad { get; set; }
    
        public virtual ADM_Colaborador ADM_Colaborador { get; set; }
        public virtual PR_Proyecto PR_Proyecto { get; set; }
    }
}
