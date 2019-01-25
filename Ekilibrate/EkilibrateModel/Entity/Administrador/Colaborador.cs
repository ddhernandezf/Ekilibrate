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
    public class clsColaboradorBase : Ekilibrate.Model.Entity.General.clsPersonaBase
    {        
        [DataMember]
        [Display(Name = "Estado")]
        [MaxLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public String Estado { get; set; }

        [DataMember]
        [Display(Name = "Nutricionista")]
        public Boolean Nutricionista { get; set; }

        [DataMember]
        [Display(Name = "Facilitador")]
        public Boolean Facilitador { get; set; }

        [DataMember]
        [Display(Name = "Asistente")]
        public Boolean Asistente { get; set; }

        [DataMember]
        [Display(Name = "Enfermero (a)")]
        public Boolean Enfermero { get; set; }
    }

    [DataContract(Namespace = "Ekilibrate.Model.Entity.Administrador")]
    public sealed class clsColaborador : clsColaboradorBase
    {
    }

    [DataContract(Namespace = "Ekilibrate.Model.Entity.Administrador")]
    public sealed class clsColaboradorFiltro : clsPaging
    {
        [DataMember]
        public Int32 Id { get; set; }

        [DataMember]
        public String Nombre { get; set; }

        [DataMember]
        public String Apellido { get; set; }
    }
}
