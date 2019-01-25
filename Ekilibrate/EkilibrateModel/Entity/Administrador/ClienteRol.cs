using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Ekilibrate.Data.EntityModel.Abstract;
using Ekilibrate.Model.Common;
using System.ComponentModel.DataAnnotations;

namespace Ekilibrate.Model.Administrador
{
    [DataContract(Namespace = "Ekilibrate.Model.Administrador")]
    public class clsClienteRolBase : IEntityPOCO<Int32>
    {
        [DataMember]
        [ScaffoldColumn(false)]
        public Int32 Id { get; set; }

        [DataMember]
        [Required(ErrorMessage = "Debe ingresa el nombre del rol")]
        [Display(Name = "Rol")]
        [MaxLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public String Nombre { get; set; }

        Int32 IEntityPOCO<Int32>.Key
        {
            get
            {
                return Id;
            }
            set
            {
                Id = value;
            }
        }
    }

    [DataContract(Namespace = "Ekilibrate.Model.Administrador")]
    public sealed class clsClienteRol : clsClienteRolBase
    {
    }

    [DataContract(Namespace = "Ekilibrate.Model.Administrador")]
    public sealed class clsClienteRolFiltro : clsPaging
    {
        [DataMember]
        public Int32 Id { get; set; }

        [DataMember]
        public String Nombre { get; set; }

    }
}
