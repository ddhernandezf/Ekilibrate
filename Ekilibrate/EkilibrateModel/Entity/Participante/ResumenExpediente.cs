using Ekilibrate.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.Model.Entity.Participante
{
    [DataContract(Namespace = "Ekilibrate.Model.Entity.Participante")]
    public class ResumenExpediente
    {
        [DataMember]
        public Int32 Id { get; set; }
        [DataMember]
        public String Nombre { get; set; }
        [DataMember]
        public String Puesto { get; set; }
        [DataMember]
        public String Correo { get; set; }
        [DataMember]
        public String Telefono { get; set; }
        [DataMember]
        public String MedioComunicacion { get; set; }
        


        [DataMember]
        public String Sexo { get; set; }
        [DataMember]
        public Int32 EsEmbarazada { get; set; }
        [DataMember]
        public Int32 Edad { get; set; }
        [DataMember]
        public String FechaUltimaMenstruacion { get; set; }
        [DataMember]
        public String EdadGestacional { get; set; }
        [DataMember]
        public String FechaNacimientoBebe { get; set; }
        [DataMember]
        public Boolean Menopausia { get; set; }



        [DataMember]
        public Decimal Estatura { get; set; }
        [DataMember]
        public Decimal PesoReal { get; set; }
        [DataMember]
        public Decimal PesoActual { get; set; }
        [DataMember]
        public Decimal PesoDeseable { get; set; }
        [DataMember]
        public Int32 PorcPT { get; set; }
        [DataMember]
        public Decimal Abdomen { get; set; }



        [DataMember]
        public Int32 CHOL { get; set; }
        [DataMember]
        public Int32 TGL { get; set; }
        [DataMember]
        public Int32 GLI { get; set; }



        [DataMember]
        public Int32 Fuma { get; set; }
        [DataMember]
        public Int32 CantidadFuma { get; set; }
        [DataMember]
        public Int32 FrecuenciaFuma { get; set; }
        [DataMember]
        public String FrecuenciaFumaTexto { get; set; }
        [DataMember]
        public Int32 Bebe { get; set; }
        [DataMember]
        public Int32 CantidadBebe { get; set; }
        [DataMember]
        public Int32 FrecuenciaBebe { get; set; }
        [DataMember]
        public String FrecuenciaBebeTexto { get; set; }
        [DataMember]
        public Int32 Diabetes { get; set; }



        [DataMember]
        public Int32 VET { get; set; }
        [DataMember]
        public Int32 RED { get; set; }



        [DataMember]
        public String ComidasFavoritas { get; set; }
        [DataMember]
        public String ComidasNoGustan { get; set; }
        [DataMember]
        public String ComidasDaninas { get; set; }



        [DataMember]
        public Int32 REDgeneral { get; set; }



        [DataMember]
        public Int32 Proteinas { get; set; }
        [DataMember]
        public Int32 Carbohidratos { get; set; }
        [DataMember]
        public Int32 Grasas { get; set; }



        [DataMember]
        public Int32 Agua { get; set; }
        [DataMember]
        public Int32 Sal { get; set; }
        [DataMember]
        public Int32 Azucar { get; set; }



        [DataMember]
        public Int32 Desayuno { get; set; }
        [DataMember]
        public Int32 RefaAM { get; set; }
        [DataMember]
        public Int32 Almuerzo { get; set; }
        [DataMember]
        public Int32 RefaPM { get; set; }
        [DataMember]
        public Int32 Cena { get; set; }



        [DataMember]
        public Int32 Enfermo { get; set; }
        [DataMember]
        public Decimal PorcentajeGrasa { get; set; }



        [DataMember]
        public String FrecuenciaGrasa { get; set; }
        [DataMember]
        public String FrecuenciaAzucar { get; set; }
        [DataMember]
        public String FrecuenciaSal { get; set; }
        [DataMember]
        public String FrecuenciaFibra { get; set; }
    }
    public sealed class ResumenExpedienteFiltro : clsPaging
    {
        [DataMember]
        public Int32 ID_PARTICIPANTE { get; set; }
    }
}
