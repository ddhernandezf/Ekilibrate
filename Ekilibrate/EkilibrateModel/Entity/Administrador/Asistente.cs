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
    public class clsAsistenteBase : IEntityPOCO<Int32>
    {
        [DataMember]
        public int ProyectoId { get; set; }
        [DataMember]
        [UIHint("GridForeignKey")]
        [Required(ErrorMessage = "El colaborador es un campo requerido.")]
        [Display(Name = "Colaborador")]
        public int ColaboradorId { get; set; }
        Int32 IEntityPOCO<Int32>.Key
        {
            get
            {
                return ColaboradorId;
            }
            set
            {
                ColaboradorId = value;
            }
        }
    }

    [DataContract(Namespace = "Ekilibrate.Model.Entity.Administrador")]
    public sealed class clsAsistenteFiltro
    {
        [DataMember]
        public Int32 ProyectoId { get; set; }
    }
}