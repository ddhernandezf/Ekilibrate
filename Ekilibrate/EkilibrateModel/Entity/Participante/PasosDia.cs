using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Ekilibrate.Data.EntityModel.Abstract;
using Ekilibrate.Model.Common;
using System.ComponentModel.DataAnnotations;

namespace Ekilibrate.Model.Entity.Participante
{
    [DataContract(Namespace = "Ekilibrate.Model.Entity.Participante")]
    public class clsPasosDiaBase : IEntityPOCO<Int32>
    {
        [DataMember]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [DataMember]
        [Required(ErrorMessage = "Se requiere la semana")]
        public int SemanaId { get; set; }

        [DataMember]
        public int Dia { get; set; }

        [DataMember]
        [Required(ErrorMessage = "Se requiere el participante")]
        public int ParticipanteId { get; set; }

        [DataMember]
        [Required(ErrorMessage = "Se requiere el proyecto")]
        public int ProyectoId { get; set; }
        
        [DataMember]
        public int Meta { get; set; }

        [DataMember]
        public int Caminados { get; set; }

        [DataMember]
        public String NombreDia { get; set; }

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

    [DataContract(Namespace = "Ekilibrate.Model.Entity.Participante")]
    public sealed class clsRegistroPasos: clsPasosDiaBase
    {
        [DataMember]
        public int IdPasosCompa { get; set; }

        [DataMember]
        public int IdCompa { get; set; }

        [DataMember]
        public int MetaCompa { get; set; }

        [DataMember]
        public int CaminadosCompa { get; set; }

        [DataMember]
        public string NombreCompa { get; set; }

        [DataMember]
        public string FechaInicio { get; set; }

        [DataMember]
        public string FechaFin { get; set; }
    }

    [DataContract(Namespace = "Ekilibrate.Model.Entity.Participante")]
    public sealed class clsPasosApp
    {
        [DataMember]
        public decimal Goal { get; set; }

        [DataMember]
        public decimal Average { get; set; }

        [DataMember]
        public String CompaId { get; set; }

        [DataMember]
        public String Compa{ get; set; }

        [DataMember]
        public int Week { get; set; }

        [DataMember]
        public IEnumerable<clsPasosDiaApp> data { get; set; }
    }

    [DataContract(Namespace = "Ekilibrate.Model.Entity.Participante")]
    public sealed class clsPasosDiaApp
    {
        [DataMember]
        public int UserId { get; set; }

        [DataMember]
        public int DayRef { get; set; }

        [DataMember]
        public string DayName { get; set; }

        [DataMember]
        public DateTime Date { get; set; }
        
        [DataMember]
        public int Steps { get; set; }

        [DataMember]
        public int Goal { get; set; }

        [DataMember]
        public int PercentAchieve { get; set; }
        //{
        //    get
        //    {
        //        return Goal / Steps;
        //    }
        //    set
        //    {

        //    }
        //}
    }

    [DataContract(Namespace = "Ekilibrate.Model.Entity.Participante")]
    public sealed class clsPasosDiaFiltro : clsPaging
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int SemanaId { get; set; }
        
        [DataMember]
        public int ProyectoId { get; set; }
        
        [DataMember]
        public int ParticipanteId { get; set; }

        [DataMember]
        public DateTime Fecha { get; set; }
    }
}
