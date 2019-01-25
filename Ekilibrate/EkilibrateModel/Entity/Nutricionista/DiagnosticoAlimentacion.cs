using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Ekilibrate.Data.EntityModel.Abstract;
using Ekilibrate.Model.Common;
using System.ComponentModel.DataAnnotations;
namespace Ekilibrate.Model.Entity.Nutricionista
{
    [DataContract(Namespace = "Ekilibrate.Model.Entity.Nutricionista")]
    public class DiagnosticoAlimentacion : IEntityPOCO<Int32>
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int ParticipanteId { get; set; }
        [DataMember]
        public int CitaId { get; set; }
        [DataMember]
        public int ProyectoId { get; set; }
        [DataMember]
        public int NutricionistaId { get; set; }
        [DataMember]
        public int AlimentoId { get; set; }
        [DataMember]
        public int Porciones { get; set; }
        [DataMember]
        public int Dias { get; set; }

        Int32 IEntityPOCO<Int32>.Key
        {
            get
            {
                return ParticipanteId;
            }
            set
            {
                ParticipanteId = value;
            }
        }
    }

    [DataContract(Namespace = "Ekilibrate.Model.Entity.Nutricionista")]
    public class DiagnosticoAlimentos : DiagnosticoAlimentacion
    {
        [DataMember]
        
        public string NombreAlimento { get; set; }
        [DataMember]
        public int Porcion0 { get; set; }
        [DataMember]
        public int Porcion1 { get; set; }
        [DataMember]
        public int Porcion2 { get; set; }
        [DataMember]
        public int Porcion3 { get; set; }
        [DataMember]
        public int Porcion4 { get; set; }
        [DataMember]
        public int Porcion5 { get; set; }
        [DataMember]
        public int Porcion6 { get; set; }
        [DataMember]
        public int Porcion7 { get; set; }
    }
}