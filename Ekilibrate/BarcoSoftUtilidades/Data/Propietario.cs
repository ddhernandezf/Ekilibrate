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
    
    public partial class Propietario
    {
        public Propietario()
        {
            this.Producto = new HashSet<Producto>();
            this.Rol = new HashSet<Rol>();
            this.ParametroGeneral = new HashSet<ParametroGeneral>();
        }
    
        public int IdPropietario { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
    
        public virtual ICollection<Producto> Producto { get; set; }
        public virtual ICollection<Rol> Rol { get; set; }
        public virtual ICollection<ParametroGeneral> ParametroGeneral { get; set; }
    }
}
