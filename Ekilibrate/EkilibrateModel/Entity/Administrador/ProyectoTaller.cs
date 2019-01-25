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
    public class clsTallerBase : IEntityPOCO<Int32>
    {
        [DataMember]
        [UIHint("ReadOnly")]
        [Display(Name = "Código")]
        public int Id { get; set; }
        [DataMember]
        public int ProyectoId { get; set; }
       
        [DataMember]
        [UIHint("GridForeignKey")]

        [Required(ErrorMessage = "El taller es un campo requerido.")]
        [Display(Name = "Taller")]
        public int TallerId { get; set; }
        [DataMember]
        [UIHint("GridForeignKey")]
        [Display(Name = "Grupo")]
        [Required(ErrorMessage = "El grupo es un campo requerido.")]
        public int GrupoId { get; set; }

        [DataMember]
        [UIHint("GridForeignKey")]
        [Display(Name = "Salon")]
        [Required(ErrorMessage = "El salon es un campo requerido.")]
        public int SalonId { get; set; }


        [DataMember]
        [UIHint("GridForeignKey")]
        [Display(Name = "Facilitador")]
        [Required(ErrorMessage = "El facilitador es un campo requerido.")]
        public int FacilitadorId { get; set; }

        [Display(Name = "Número módulos")]
        [Required(ErrorMessage = "El número de sesiones es un campo requerido.")]
        [DataMember]
        public int NoSesiones { get; set; }

        [DataMember]
        [Display(Name = "Frecuencia")]
        [Required(ErrorMessage = "La frecuencia es un campo requerido.")]
        public int FrecuenciaSesiones { get; set; }

        [DataMember]
        [Required(ErrorMessage = "La unidad es un campo requerido.")]
        public int FrecuenciaSesionesUnidad { get; set; }

        [Display(Name = "Duración sesiones")]
        [DataMember]
        public TimeSpan DuracionSesiones { get; set; }

        [DataMember]
        [Display(Name = "Hora Inicio")]
        public TimeSpan HoraInicio { get; set; }


        [Display(Name = "Hora Fin")]
        [DataMember]
        public TimeSpan HoraFin { get; set; }

        [DataMember]
        public bool Lunes { get; set; }

        [DataMember]
        public bool Martes { get; set; }
        [DataMember]
        public bool Miercoles { get; set; }
        [DataMember]
        public bool Jueves { get; set; }
        [DataMember]
        public bool Viernes { get; set; }
        [DataMember]
        public bool Sabado { get; set; }
        [DataMember]
        public bool Domingo { get; set; }


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
    public  class clsTallerVista : clsTallerBase
    {
        [DataMember]
        [Display(Name = "Hora Inicio")]
        [Required(ErrorMessage = "La hora es un campo requerido.")]
        public DateTime DHoraInicio { get; set; }

        [DataMember]
        [Display(Name = "Hora Fin")]
        [Required(ErrorMessage = "La hora es un campo requerido.")]
        public DateTime DHoraFin { get; set; }

        [Display(Name = "Duración sesiones")]
        [Required(ErrorMessage = "La duración es un campo requerido.")]
        [DataMember]
        public DateTime DDuracionSesiones { get; set; }

        [DataMember]
        [Display(Name = "Grupo")]
        public string NombreGrupo { get; set; }
        [DataMember]
        [Display(Name = "Área")]
        public string NombreArea { get; set; }
        [DataMember]
        [Display(Name = "Taller")]
        public string NombreTaller { get; set; }


       

    }

    [DataContract(Namespace = "Ekilibrate.Model.Entity.Administrador")]
    public sealed class clsTallerFiltro
    {
        [DataMember]
        public Int32 IdProyecto { get; set; }
    }
}