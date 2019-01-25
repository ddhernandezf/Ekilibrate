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
    public class clsGrupoBase : IEntityPOCO<Int32>
    {
        [DataMember]
        public Int32 Id { get; set; }

        [DataMember]
        [Required(ErrorMessage = "Debe ingresa el nombre del grupo")]
        [Display(Name = "Nombre")]
        [MaxLength(100, ErrorMessage = "Máximo 100 caracteres")]
        public String Nombre { get; set; }

        [DataMember]
        public Int32 ProyectoId { get; set; }

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
    public sealed class clsGrupoFiltro : clsPaging
    {
        [DataMember]
        public Int32 Id { get; set; }

        [DataMember]
        public String Nombre { get; set; }

        [DataMember]
        public Int32 ProyectoId { get; set; }
    }



}
