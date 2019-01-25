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
    public class clsEmpresaBase : IEntityPOCO<Int32>
    {
        [DataMember]
        [ScaffoldColumn(false)]
        public Int32 Id { get; set; }
        [DataMember]
        [Required(ErrorMessage = "Debe ingresa el nombre de la empresa")]
        [Display(Name = "Nombre de la Empresa")]
        public String Nombre { get; set; }
        [DataMember]
        public String PBX { get; set; }
        [DataMember]
        public String Direccion { get; set; }
        [DataMember]
        [UIHint("GridForeignKey")]
        [Display(Name = "Giro de la Empresa")]
        public Int32 GiroId { get; set; }


        [DataMember]
        [Display(Name="No. Total de empleados")]
        [Range(0, int.MaxValue)]
        public int CantidadTotalEmpleados { get; set; }
        [DataMember]
        [Range(0, int.MaxValue)]
        [Display(Name = "No. administrativos")]
        public int CantidadAdministrativo { get; set; }
        [DataMember]

        [Display(Name = "No. en distribución")]
        [Range(0, int.MaxValue)]
        public int CantidadDistribucion { get; set; }
        [DataMember]
        [Display(Name = "No. en ventas")]
        [Range(0, int.MaxValue)]
        public int CantidadVentas { get; set; }
        [DataMember]
        [Range(0, int.MaxValue)]
        [Display(Name = "No. en producción")]
        public int CantidadProduccion { get; set; }
        [DataMember]
        [Display(Name = "No. otros")]
        public int CantidadOtros { get; set; }

        [DataMember]
        [Display(Name = "Descripción otros")]
        public string OtrosDescripcion { get; set; }

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
    public sealed class clsEmpresa : clsEmpresaBase
    {
        public String Giro { get; set; }
    }

    [DataContract(Namespace = "Ekilibrate.Model.Entity.Administrador")]
    public sealed class clsEmpresaContacto : clsEmpresaBase
    {
        [DataMember]
        public int PersonaId { get; set; }

        [DataMember]
        public String ContactoNombre { get; set; }

        [DataMember]
        public String ContactoTelefono { get; set; }

        [DataMember]
        public String ContactoExtension { get; set; }

        [DataMember]
        public String ContactoCelular { get; set; }

        [DataMember]
        public String ContactoCorreo { get; set; }
    }

    [DataContract(Namespace = "Ekilibrate.Model.Entity.Administrador")]
    public sealed class clsEmpresaFiltro : clsPaging
    {
        [DataMember]
        public Int32 Id { get; set; }
        [DataMember]
        public String Nombre { get; set; }
        [DataMember]
        public Int32 GiroId { get; set; }
    }
}
