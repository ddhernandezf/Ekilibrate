using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Ekilibrate.Data.EntityModel.Abstract;
using Ekilibrate.Model.Common;
using System.ComponentModel.DataAnnotations;

namespace Ekilibrate.Model.Entity.Catalogos
{
    [DataContract(Namespace = "Ekilibrate.Model.Entity.Catalogos")]
    public class clsAreaBase : IEntityPOCO<Int32>
    {
        [DataMember]
        public Int32 Id { get; set; }

        [DataMember]
        [Required(ErrorMessage = "Debe ingresa el nombre del área")]
        [Display(Name = "Nombre")]
        [MaxLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public String Nombre { get; set; }


        [Display(Name = "Restrictiva")]
        public Boolean Restrictiva { get; set; }

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


    [DataContract(Namespace = "Ekilibrate.Model.Entity.Catalogos")]
    public sealed class clsAreaFiltro : clsPaging
    {
        [DataMember]
        public Int32 ProyectoId { get; set; }
    }
}
