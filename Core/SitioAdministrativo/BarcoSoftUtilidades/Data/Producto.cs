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
    
    public partial class Producto
    {
        public Producto()
        {
            this.Objeto = new HashSet<Objeto>();
        }
    
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int IdPropietario { get; set; }
        public bool Activo { get; set; }
    
        public virtual ICollection<Objeto> Objeto { get; set; }
        public virtual Propietario Propietario { get; set; }
    }
}
