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
    
    public partial class Persona
    {
        public Persona()
        {
            this.Usuario = new HashSet<Usuario>();
        }
    
        public int IdPersona { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string NombreCompleto { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public bool Activo { get; set; }
    
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
