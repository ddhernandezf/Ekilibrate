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
    public class clsContactoBase : Ekilibrate.Model.Entity.General.clsPersonaBase
    {
        [DataMember]
        [ScaffoldColumn(false)]
        public Int32 IdPersona { get; set; }
        
        [DataMember]
        [ScaffoldColumn(false)]
        public Int32 EmpresaId { get; set; }

        [DataMember]
        public bool EsPrincipal { get; set; }
        
    }

    [DataContract(Namespace = "Ekilibrate.Model.Entity.Administrador")]
    public sealed class clsContacto : clsContactoBase
    {
        public String Proyecto { get; set; }
        public String Rol { get; set; }
    }

    [DataContract(Namespace = "Ekilibrate.Model.Entity.Administrador")]
    public sealed class clsContactoFiltro : clsPaging
    {
        [DataMember]
        public Int32 EmpresaId { get; set; }
    }
}
