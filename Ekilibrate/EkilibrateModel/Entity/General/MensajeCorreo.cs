using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Ekilibrate.Data.EntityModel.Abstract;
using Ekilibrate.Model.Common;
using System.ComponentModel.DataAnnotations;
namespace Ekilibrate.Model.Entity.General
{
    [DataContract(Namespace = "Ekilibrate.Model.Entity.General")]
    public class clsMensajeCorreo : IEntityPOCO<Int32>
    {
        public clsMensajeCorreo()
        {

        }

        public clsMensajeCorreo (string _Asunto, string _Mensaje, string _EsHTML, string _Para)
        {
            Asunto = _Asunto;
            Mensaje = _Mensaje;
            EsHTML = _EsHTML;
            Para = _Para;
            EsLista = "NO";
        }

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Asunto { get; set; }
        [DataMember]
        public string Mensaje { get; set; }
        [DataMember]
        public string EsHTML { get; set; }
        [DataMember]
        public string Para { get; set; }
        [DataMember]
        public string EsLista { get; set; }
        [DataMember]
        public DateTime? FechaEnvio { get; set; }
        [DataMember]
        public string EstadoEnvio { get; set; }
        Int32 IEntityPOCO<Int32>.Key { get { return Id; } set { Id = value; } }
    }
}