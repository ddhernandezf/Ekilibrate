using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Ekilibrate.Data.EntityModel.Abstract;
using Ekilibrate.Model.Common;
using System.ComponentModel.DataAnnotations;

namespace Ekilibrate.Model.Entity.Administrador
{
    [DataContract(Namespace = "Ekilibrate.Model.Entity.Administrador")]
    public class clsSalonBase : IEntityPOCO<Int32>
    {
        [DataMember]
        [ScaffoldColumn(false)]
        public Int32 Id { get; set; }
        [DataMember]
        [Required(ErrorMessage = "Debe ingresa el nombre del salón")]
        [Display(Name = "Nombre del salón")]
        [MaxLength(100, ErrorMessage = "Máximo 100 caracteres")]
        public String Nombre { get; set; }
        [DataMember]
        [Required(ErrorMessage = "Debe ingresa la capacidad de personas")]
        public Int32 Capacidad { get; set; }
        [DataMember]
        [UIHint("GridForeignKey")]
        [Required(ErrorMessage = "Debe seleccionar el tipo de uso")]
        [Display(Name = "Tipo de Uso")]
        public Int32 TipoUsoId { get; set; }
        [DataMember]
        [ScaffoldColumn(false)]
        public Int32 EmpresaId { get; set; }

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

    [DataContract(Namespace = "Ekilibrate.Model.Entity.Administrador")]
    public sealed class clsSalon : clsSalonBase
    {
        public String TipoUsoSalon { get; set; }
        public String Empresa { get; set; }
    }

    [DataContract(Namespace = "Ekilibrate.Model.Entity.Administrador")]
    public sealed class clsSalonFiltro : clsPaging
    {
        [DataMember]
        public Int32 Id { get; set; }
        [DataMember]
        public String Nombre { get; set; }
        [DataMember]
        public Int32 Capacidad { get; set; }
        [DataMember]
        public Int32 TipoUsoId { get; set; }
        [DataMember]
        public Int32 EmpresaId { get; set; }

        [DataMember]
        public Int32 ProyectoId { get; set; }
    }
}
