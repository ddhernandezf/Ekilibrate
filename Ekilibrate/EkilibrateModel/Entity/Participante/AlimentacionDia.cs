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
    public class clsAlimentacionDiaBase : IEntityPOCO<Int32>
    {
        [DataMember]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [DataMember]
        [Required(ErrorMessage = "Se requiere el participante")]
        public int ParticipanteId { get; set; }

        [DataMember]
        [Required(ErrorMessage = "Se requiere el grupo alimenticio")]
        public int GrupoAlimentoId { get; set; }

        [DataMember]
        [Required(ErrorMessage = "Se requiere la semana")]
        public int SemanaId { get; set; }

        [DataMember]
        public int Dia { get; set; }


        [DataMember]
        [Required(ErrorMessage = "Se requiere el proyecto")]
        public int ProyectoId { get; set; }

        [DataMember]
        public Decimal Meta { get; set; }

        [DataMember]
        public Decimal Comido { get; set; }

        [DataMember]
        public String NombreDia { get; set; }

        [DataMember]
        public String NombreAlimento { get; set; }

        [DataMember]
        public bool Nuevo { get; set; }

        //[DataMember]
        //public string SortableName { get; set; }
        
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
    public sealed class clsAlimentacionDia : clsAlimentacionDiaBase
    {

    }
    [DataContract(Namespace = "Ekilibrate.Model.Entity.Participante")]
    public sealed class clsAlimentacionDiaFiltro : clsPaging
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
        public int GrupoAlimenticioId { get; set; }
    }

    [DataContract(Namespace = "Ekilibrate.Model.Entity.Participante")]
    public sealed class clsAlimentacionApp
    {
        [DataMember]
        public decimal GoalCalories { get; set; }

        [DataMember]
        public decimal AverageCalories { get; set; }
                
        [DataMember]
        public int Week { get; set; }

        [DataMember]
        public IEnumerable<clsAlimentacionDiaApp> data { get; set; }
    }

    [DataContract(Namespace = "Ekilibrate.Model.Entity.Participante")]
    public sealed class clsAlimentacionDiaApp
    {
        [DataMember]
        public int DayRef { get; set; }

        [DataMember]
        public string DayName { get; set; }

        [DataMember]
        public DateTime Date { get; set; }
        
        [DataMember]
        public int Category { get; set; }

        [DataMember]
        public string CategoryName { get; set; }

        [DataMember]
        public int GoalPortions { get; set; }

        [DataMember]
        public int ConsumedPortions { get; set; }

        [DataMember]
        public int ConsumedCalories { get; set; }
    }

}
