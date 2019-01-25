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
    public class clsParticipanteBase : Ekilibrate.Model.Entity.General.clsPersonaBase
    {
        //[DataMember]
        //public int Id { get; set; }
        [DataMember]
        public int? PaisId { get; set; }
        [DataMember]
        public int? GrupoId { get; set; }
        [DataMember]
        public int? Compa { get; set; }
        [DataMember]
        public int ProyectoId { get; set; }
        [DataMember]
        public bool Baja { get; set; }
        [DataMember]
        public int NutricionistaId { get; set; }
        [DataMember]
        public int CitaDia { get; set; }
        [DataMember]
        public TimeSpan? CitaHora { get; set; }
        [DataMember]
        public DateTime PrimeraCita { get; set; }
    }

    [DataContract(Namespace = "Ekilibrate.Model.Entity.Participante")]
    public class clsParticipante : clsParticipanteBase
    {
        [DataMember]
        public int No { get; set; }
        [DataMember]
        public int CitaNo { get; set; }
        [DataMember]
        public string Pais { get; set; }
        [DataMember]
        public string Grupo { get; set; }
        [DataMember]
        public string Sexo { get; set; }
        [DataMember]
        public DateTime FechaNacimiento { get; set; }
        [DataMember]
        public string CompaNombre { get; set; }
        [DataMember]
        public string NutricionistaNombre { get; set; }
        [DataMember]
        public DateTime FechaDiagnosticoFinal { get; set; }
        [DataMember]
        public DateTime FechaBxFinal { get; set; }
    }

    [DataContract(Namespace = "Ekilibrate.Model.Entity.Participante")]
    public class clsParticipanteProgramacion : clsParticipante
    {
        [DataMember]
        public DateTime FechaCita { get; set; }        
    }

    [DataContract(Namespace = "Ekilibrate.Model.Entity.Participante")]
    public class clsRegistroParticipante : clsParticipante
    {
        [DataMember]
        [Display(Name = "Código de Registro")]
        [Required(ErrorMessage = "Campo requerido.")]
        public string CodigoRegistro { get; set; }

        [DataMember]
        [Display(Name = "Usuario")]
        public string Usuario { get; set; }

        [DataMember]
        [Required(ErrorMessage = "Debe ingresar su contraseña")]
        [StringLength(100, ErrorMessage = "La contraseña debe tener al menos {2} caracteres de longitud.", MinimumLength = 4)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [DataMember]
        [Display(Name = "Confirma contraseña")]
        [Required(ErrorMessage = "Debe confirmar su contraseña.")]
        [StringLength(100, ErrorMessage = "La contraseña debe tener al menos {2} caracteres de longitud.", MinimumLength = 4)]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }

    [DataContract(Namespace = "Ekilibrate.Model.Entity.Participante")]
    public class clsParticipanteFiltro
    {
        [DataMember]
        public int ProyectoId { get; set; }
        [DataMember]
        public int GrupoId { get; set; }
    }

    [DataContract(Namespace = "Ekilibrate.Model.Entity.Participante")]
    public class clsAvanceCuestionario : clsParticipanteBase
    {
        [DataMember]
        public int No { get; set; }

        [DataMember]
        public bool InformacionGeneral { get; set; }

        [DataMember]
        public bool Alimentacion { get; set; }

        [DataMember]
        public bool Riesgo { get; set; }

        [DataMember]
        public bool ActividadFisica { get; set; }

        [DataMember]
        public bool Emociones { get; set; }

        [DataMember]
        public int EmocionesNota { get; set; }

        [DataMember]
        public bool ManejoTiempo { get; set; }

        [DataMember]
        public int ManejoTiempoNota { get; set; }

        [DataMember]
        public bool ComunicacionAsertiva1 { get; set; }

        [DataMember]
        public bool ComunicacionAsertiva2 { get; set; }

        [DataMember]
        public int ComunicacionAsertivaNota { get; set; }

        [DataMember]
        public bool Finanzas { get; set; }

        [DataMember]
        public string FinanzasFactor { get; set; }

        [DataMember]
        public bool Liderazgo { get; set; }

        [DataMember]
        public int LiderazgoNota { get; set; }

        [DataMember]
        public int Porcentaje { get; set; }

        [DataMember]
        public bool DiagnosticoNutricional { get; set; }
    }
}