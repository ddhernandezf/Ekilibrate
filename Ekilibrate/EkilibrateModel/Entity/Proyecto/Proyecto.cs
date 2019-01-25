using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Ekilibrate.Data.EntityModel.Abstract;
using Ekilibrate.Model.Common;
using System.ComponentModel.DataAnnotations;

namespace Ekilibrate.Model.Entity.Proyecto
{
    [DataContract(Namespace = "Ekilibrate.Model.Entity.Proyecto")]
    public class clsProyectoBase : IEntityPOCO<Int32>
	{
        [DataMember]
        public int Id {get;set;}
        [DataMember]
        public int EmpresaId {get;set;}
        [DataMember]
        public string Estado {get;set;}
        [DataMember]
        public DateTime FechaInicio {get;set;}
        [DataMember]
        public DateTime FechaFin {get;set;}
        [DataMember]
        public int NoSemanas {get;set;}
        [DataMember]
        public int NoParticipantes {get;set;}
        [DataMember]
        public int NoEnfermeras {get;set;}
        [DataMember]
        public int NoFacilitadores {get;set;}
        [DataMember]
        public int NoAsistentes {get;set;}
        [DataMember]
        public int NoConsultasNutricionales {get;set;}
        [DataMember]
        public int FrecuenciaConsultas {get;set;}
        [DataMember]
        public int FrecuenciaAlertas {get;set;}
        [DataMember]
        public int FrecuenciaAlertasUnidad {get;set;}
        [DataMember]
        public int FrecuenciaConsultasUnidad {get;set;}
        [DataMember]
        public string Color {get;set;}
        [DataMember]
        public bool CrearUsuarios {get;set;}
        [DataMember]
        public int TipoProyectoId { get; set; }

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

    [DataContract(Namespace = "Ekilibrate.Model.Entity.Proyecto")]
    public class clsProyecto : clsProyectoBase
    {
        [DataMember]
        public string Empresa { get; set; }
        public string Aseguradora { get; set; }
    }

    [DataContract(Namespace = "Ekilibrate.Model.Entity.Proyecto")]
    public class clsProyectoFiltro
	{
        [DataMember]
        public int Id {get;set;}
        [DataMember]
        public int EmpresaId {get;set;}
        [DataMember]
        public string Estado {get;set;}
        [DataMember]
        public DateTime FechaInicio {get;set;}
        [DataMember]
        public DateTime FechaFin {get;set;}
    }

    [DataContract(Namespace = "Ekilibrate.Model.Entity.Proyecto")]
    public class clsProyectoCliente : IEntityPOCO<Int32>
    {
        [DataMember]
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [DataMember]
        [ScaffoldColumn(false)]
        public int EmpresaId { get; set; }
        [DataMember]
        //[ScaffoldColumn(false)]
        public string Empresa { get; set; }
        [DataMember]
        //[ScaffoldColumn(false)]
        public string Estado { get; set; }
        [DataMember]
        //[ScaffoldColumn(false)]
        public DateTime FechaInicio { get; set; }
        [DataMember]
        //[ScaffoldColumn(false)]
        public DateTime FechaFin { get; set; }
        public string Color { get; set; }
        [DataMember]
        public bool CrearUsuarios { get; set; }
        [DataMember]
        public string LogoURL { get; set; }
        [DataMember]
        public int? AseguradoraId { get; set; }
        [DataMember]
        [ScaffoldColumn(false)]
        public string Aseguradora { get; set; }
        [DataMember]
        public decimal? IndiceReclamos { get; set; }
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
}