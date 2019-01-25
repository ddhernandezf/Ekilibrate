using Ekilibrate.Data.EntityModel.Abstract;
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
    public class clsProyectoAreaBase : IEntityPOCO<Int32>
    {
        [DataMember]
        public int ProyectoId { get; set; }
        [DataMember]
        public int AreaId { get; set; }
      
        Int32 IEntityPOCO<Int32>.Key
        {
            get
            {
                return AreaId;
            }
            set
            {
                AreaId = value;
            }
        }
    }

    public sealed class clsProyectoArea : clsProyectoAreaBase
    {
        [DataMember]
        [Display(Name = "Área")]
        public string Nombre { get; set; }
        [DataMember]
        [Display(Name = "Elegir")]
        public bool Seleccionado { get; set; }
    }


    [DataContract(Namespace = "Ekilibrate.Model.Entity.Administrador")]
    public sealed class clsProyectoAreaFiltro
    {
        [DataMember]
        public Int32 IdProyecto { get; set; }

    }
}
