using Ekilibrate.Data.EntityModel.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.Model.Entity.Catalogos
{
    [DataContract(Namespace = "Ekilibrate.Model.Catalogos")]
    public class clsTallerBase : IEntityPOCO<Int32>
    {
        [DataMember]
        public Int32 Id { get; set; }

        [DataMember]
        [Required(ErrorMessage = "Debe ingresa el nombre del taller")]
        [Display(Name = "Nombre")]
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

    [DataContract(Namespace = "Ekilibrate.Model.Catalogos")]
    public sealed class clsTallerFiltro
    {
        [DataMember]
        public int? ProyectoId { get; set; }
    }
}
