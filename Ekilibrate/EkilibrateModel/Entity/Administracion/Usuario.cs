using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Ekilibrate.Data.EntityModel.Abstract;
using Ekilibrate.Model.Common;
using System.ComponentModel.DataAnnotations;

namespace Ekilibrate.Model.Entity.Administracion
{
    [DataContract(Namespace = "Ekilibrate.Model.Entity.Administracion")]
    public class clsUsuarioBase : IEntityPOCO<Int32>
    {
        [DataMember]
        public int IdUsuario { get; set; }
        [DataMember]
        public string NombreUsuario { get; set; }
        [DataMember]
        public string Contraseña { get; set; }
        [DataMember]
        public int IdPersona { get; set; }
        [DataMember]
        public int IdTipoUsuario { get; set; }
        [DataMember]
        public bool Activo { get; set; }

        Int32 IEntityPOCO<Int32>.Key
        {
            get
            {
                return IdUsuario;
            }
            set
            {
                IdUsuario = value;
            }
        }
    }
}