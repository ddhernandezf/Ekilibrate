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
    public class clsTallerProgramacion : IEntityPOCO<List<Int32>>
    {
        [DataMember]
        public int TallerId { get; set; }
        [DataMember]
        public int NoSesion { get; set; }
        [DataMember]
        public DateTime HoraInicio { get; set; }
        [DataMember]
        public DateTime HoraFin { get; set; }

        List<Int32> IEntityPOCO<List<Int32>>.Key
        {
            get
            {
                return new List<Int32>(new Int32[] { TallerId, NoSesion });
            }
            set
            {
                TallerId = value[0];
                NoSesion = value[1];
            }
        }
    }
}