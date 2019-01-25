using Ekilibrate.Data.EntityModel.Abstract;
using Ekilibrate.Model.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.Model.Entity.Administrador
{

    [DataContract(Namespace = "Ekilibrate.Model.Entity.Administrador")]
    public class clsProyectoContactoBase : IEntityPOCO<Int32>
    {
        [DataMember]
        public int ProyectoId { get; set; }
        [DataMember]
        public int ContactoId { get; set; }
        Int32 IEntityPOCO<Int32>.Key
        {
            get
            {
                return ContactoId;
            }
            set
            {
                ContactoId = value;
            }
        }

    }

    public sealed class clsProyectoContacto : clsProyectoContactoBase
    {
        [DataMember]
        [Display(Name = "Contacto")]
        public string Nombre { get; set; }
        [DataMember]
        [Display(Name = "Elegir")]
        public bool Seleccionado { get; set; }
    }

    public sealed class clsContactoProyecto : clsProyectoContactoBase
    {
        [DataMember]
        public int PersonaId { get; set; }
        [DataMember]
        public string PrimerNombre { get; set; }
        [DataMember]
        public string PrimerApellido { get; set; }
        [DataMember]
        public string Correo { get; set; }
    }

    [DataContract(Namespace = "Ekilibrate.Model.Entity.Administrador")]
    public sealed class clsProyectoContactoFiltro
    {
        [DataMember]
        public Int32 IdProyecto { get; set; }

        [DataMember]
        public Int32 IdEmpresa { get; set; }
    }
}
