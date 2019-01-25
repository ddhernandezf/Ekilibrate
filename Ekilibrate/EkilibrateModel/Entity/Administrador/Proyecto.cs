using Ekilibrate.Data.EntityModel.Abstract;
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
    public class clsProyectoBase : IEntityPOCO<Int32>
    {

        [DataMember]
        [UIHint("ReadOnly")]
        [Display(Name = "Id")]
        public Int32 Id { get; set; }

        [DataMember]
        [UIHint("GridForeignKey")]
        [Required(ErrorMessage = "El número de empresa es un campo requerido.")]
        [Display(Name = "Empresa")]
        public Int32 EmpresaId { get; set; }


        [DataMember]
        [Required(ErrorMessage = "El estado es un campo requerido.")]
        [Display(Name = "Estado")]
        [MaxLength(50, ErrorMessage = "El campo no puede superar los 50 caracteres.")]
        public string Estado { get; set; }


        [DataMember]
        [Required(ErrorMessage = "El nombre es un campo requerido.")]
        [Display(Name = "Nombre")]
        [MaxLength(25, ErrorMessage = "El campo no puede superar los 25 caracteres.")]
        public string Nombre { get; set; }

        [DataMember]
        [DataType(DataType.Date)]
        //[Required(ErrorMessage = "La fecha de inicio es un campo requerido.")]
        [Display(Name = "Fecha de Inicio", ShortName = "Fecha Inicio")]

        public DateTime? FechaInicio { get; set; }

        [DataMember]
        //[Required(ErrorMessage = "La fecha de finalización es un campo requerido.")]
        [Display(Name = "Fecha de finalización", ShortName = "Fecha fin")]

        public DateTime FechaFin { get; set; }

        [DataMember]
        //[Required(ErrorMessage = "El número de semanas es un campo requerido.")]
        [Display(Name = "Semanas")]
        [Range(0, int.MaxValue, ErrorMessage = "Número invalido")]
        public Int32 NoSemanas { get; set; }


        [DataMember]
        [Required(ErrorMessage = "El número de participantes es un campo requerido.")]
        [Display(Name = "Participantes")]
        [Range(0, int.MaxValue, ErrorMessage = "Número invalido")]
        public Int32 NoParticipantes { get; set; }

        [DataMember]
        [Required(ErrorMessage = "El número de nutricionistas es un campo requerido.")]
        [Display(Name = "Nutricionistas")]
        [Range(0, int.MaxValue, ErrorMessage = "Número invalido")]
        public Int32 NoNutricionistas { get; set; }


        [DataMember]
        [Required(ErrorMessage = "El número de enfermeras es un campo requerido.")]
        [Display(Name = "Enfermeras")]
        [Range(0, int.MaxValue, ErrorMessage = "Número invalido")]
        public Int32 NoEnfermeras { get; set; }

        [DataMember]
        //[Required(ErrorMessage = "El número de facilitadores es un campo requerido.")]
        [Display(Name = "Facilitadores")]
        [Range(0, int.MaxValue, ErrorMessage = "Número invalido")]
        public Int32 NoFacilitadores { get; set; }



        [DataMember]
        [Required(ErrorMessage = "El número de Asistentes es un campo requerido.")]
        [Display(Name = "Asistentes de Proyecto")]
        [Range(0, int.MaxValue, ErrorMessage = "Número invalido")]
        public int NoAsistentes { get; set; }

        [DataMember]
       // [Required(ErrorMessage = "El número de consultas es un campo requerido.")]
        [Display(Name = "Consultas nutricionales")]
        [Range(0, int.MaxValue, ErrorMessage = "Número invalido")]

        public int NoConsultasNutricionales { get; set; }
        [DataMember]
      //  [Required(ErrorMessage = "El número de frecuencias es un campo requerido.")]
        [Display(Name = "Frecuencia Consultas")]
        public int FrecuenciaConsultas { get; set; }

        [DataMember]
        //[Required(ErrorMessage = "El número de frecuencia de alertas es un campo requerido.")]
        [Display(Name = "Frecuencia de Alertas")]
        public int FrecuenciaAlertas { get; set; }

        [DataMember]
        [UIHint("GridForeignKey")]
        //[Required(ErrorMessage = "la unidad de frecuencia de alertas es un campo requerido.")]
        [Display(Name = "Unidad frecuencia de alertas")]
        public int? FrecuenciaAlertasUnidad { get; set; }


        [DataMember]
        [UIHint("GridForeignKey")]
        //[Required(ErrorMessage = "La unidad de frecuencia de alertas es un campo requerido.")]
        [Display(Name = "Unidad frecuencia de alertas")]
        public int? FrecuenciaConsultasUnidad { get; set; }


        [DataMember]
        [Display(Name = "Color")]
        public string Color { get; set; }

        [DataMember]
        [Display(Name = "¿Crear usuarios mediante?")]
        public bool CrearUsuarios { get; set; }


        [DataMember]
        [Display(Name = "Url logo")]
        public string LogoURL { get; set; }


        [DataMember]
        [Display(Name = "Aseguradora")]

        public int? AseguradoraId { get; set; }

        [DataMember]
        [Display(Name = "Indice de reclamos")]
        public decimal? IndiceReclamos { get; set; }


        [DataMember]
        [Display(Name = "Participantes por grupo")]
        //[Required(ErrorMessage = "El número de participantes por grupo es un campo requerido.")]
        public int? NoParticipantesPorGrupo { get; set; }

        [DataMember]
        [Display(Name = "Fecha invitación por correo")]
        //[Required(ErrorMessage = "La fecha de correo es un campo requerido.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaCorreoInvitacion { get; set; }

        [DataMember]
        [Display(Name = "Fecha inicio")]
        //[ProyectoDateNullableValidation(ErrorMessage = "La fecha de primera cita de diagnóstico no es válida")]
        public DateTime? FechaPrimeraCitaDiagnostico { get; set; }

        [DataMember]
        [Display(Name = "¿Citas programadas?")]
        public bool? CitasProgramadas { get; set; }
        [DataMember]
        [Display(Name = "¿Metas calculadas?")]
        public bool? MetasCalculadas { get; set; }

        [DataMember]
        [Display(Name = "Fecha inicio")]
       // [Required(ErrorMessage = "La fecha de inicio de consultas es un campo requerido.")]
        public DateTime FechaInicioConsultas { get; set; }

        [DataMember]
        [Display(Name = "Hora de inicio de Jornada laboral")]
        public TimeSpan? HoraInicioConsultas { get; set; }

        [DataMember]
        [Display(Name = "Hora finaliza jornada")]
        public TimeSpan? HoraFinConsultas { get; set; }


        [DataMember]
        [Display(Name = "Duración consulta")]
        public TimeSpan? DuracionConsultas { get; set; }

        [DataMember]
        [Display(Name = "Tipo de Proyecto")]
        [Required (ErrorMessage="El tipo de proyecto es un campo requerido.")]
        public int TipoProyectoId { get; set; }

        [DataMember]
        [Display(Name = "Código para registro de usuarios")]
        public string CodigoRegistro { get; set; }

        [DataMember]
        [Display(Name = "Correo remitente de notificaciones")]
        public string Correo { get; set; }

        [DataMember]
        [Display(Name = "Password de ingreso al correo")]
        public string PasswordCorreo { get; set; }
        
        [DataMember]
        public int UsuarioCreador { get; set; }

        [DataMember]
        [Display(Name = "Fecha Pruebas Bx")]
        public DateTime? FechaInicioBx { get; set; }

        [DataMember]
        [Display(Name = "Hora Inicio")]
        public TimeSpan? HoraInicioBx { get; set; }

        [DataMember]
        [Display(Name = "Hora Finaliza")]
        public TimeSpan? HoraFinBx { get; set; }

        [DataMember]
        [Display(Name = "Hora Inicio")]
        public TimeSpan? HoraInicioDN { get; set; }

        [DataMember]
        [Display(Name = "Hora Finaliza")]
        public TimeSpan? HoraFinDN { get; set; }

        [DataMember]
        [Display(Name = "Duración")]
        public TimeSpan? DuracionDN { get; set; }

        [DataMember]
        public string HtmlDiagnostico { get; set; }

        [DataMember]
        public string HtmlLanzamiento { get; set; }

        [DataMember]
        public string HtmlConsultas { get; set; }


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
    public class clsProyecto : clsProyectoBase
    {
        [DataMember]
        public string EmpresaNombre { get; set; }

        [DataMember]
        public string TipoProyecto { get; set; }

        [DataMember]
        [Display(Name = "Hora inicio")]
        [Required(ErrorMessage = "La hora de inicio es un campo requerido.")]
        public DateTime DHoraInicioConsultas { get; set; }

        [DataMember]
        [Display(Name = "Hora finaliza")]
        [Required(ErrorMessage = "La hora de fin es un campo requerido.")]
        public DateTime DHoraFinConsultas { get; set; }
        
        [DataMember]
        [Display(Name = "Duración consulta")]
        [Required(ErrorMessage = "La duración es un campo requerido.")]
        public DateTime DDuracionConsultas { get; set; }

        [DataMember]
        [Display(Name = "Hora inicio")]
        public DateTime DHoraInicioBx { get; set; }

        [DataMember]
        [Display(Name = "Hora finaliza")]
        public DateTime DHoraFinBx { get; set; }

        [DataMember]
        [Display(Name = "Hora inicio")]
        public DateTime DHoraInicioDN { get; set; }

        [DataMember]
        [Display(Name = "Hora finaliza")]
        public DateTime DHoraFinDN { get; set; }

        [DataMember]
        [Display(Name = "Duración consulta")]
        [Required(ErrorMessage = "La duración es un campo requerido.")]
        public DateTime DDuracionDN { get; set; }
    }

    public class ProyectoDateNullableValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dt;
            if (value == null)
                return true;

            bool parsed = DateTime.TryParse((string)value, out dt);
            if (!parsed)
                return false;

            return true;
        }
    }

}

	