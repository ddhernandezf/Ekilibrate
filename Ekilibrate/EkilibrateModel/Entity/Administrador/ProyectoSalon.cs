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
    public class clsProyectoSalonBase : IEntityPOCO<Int32>
    {
        [DataMember]
        public int ProyectoId { get; set; }
        [DataMember]
        public int SalonId { get; set; }
        Int32 IEntityPOCO<Int32>.Key
        {
            get
            {
                return SalonId;
            }
            set
            {
                SalonId = value;
            }
        }

    }

    public sealed class clsProyectoSalon : clsProyectoSalonBase
    {
        [DataMember]
        [Display(Name = "Salon")]
        public string Nombre { get; set; }
        [DataMember]
        [Display(Name = "Elegir")]
        public bool Seleccionado { get; set; }
    }



    [DataContract(Namespace = "Ekilibrate.Model.Entity.Administrador")]
    public sealed class clsProyectoSalonFiltro
    {
        [DataMember]
        public Int32 IdProyecto { get; set; }

        [DataMember]
        public Int32 IdEmpresa { get; set; }
    }
}
