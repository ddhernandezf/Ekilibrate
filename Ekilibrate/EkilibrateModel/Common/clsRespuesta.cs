using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Ekilibrate.Data.EntityModel.Abstract;

namespace Ekilibrate.Model.Common
{
    [DataContract(Namespace = "Ekilibrate.Model.Common")]
   public class clsRespuesta
    {
        [DataMember]
        public bool Error { get; set; }
        [DataMember]
        public String Mensaje { get; set; }
        public String Excepcion { get; set; }
    }

    [DataContract(Namespace = "Ekilibrate.Model.Common")]
    public class clsORespuesta : clsRespuesta
    {
        [DataMember]
        public object Resultado { get; set; }
    }

    [DataContract(Namespace = "Ekilibrate.Model.Common")]
    public class clsIntRespuesta : clsRespuesta
    {
        [DataMember]
        public Int32 Resultado { get; set; }
    }

    [DataContract(Namespace = "Ekilibrate.Model.Common")]
    public class clsStrRespuesta : clsRespuesta
    {
        [DataMember]
        public String Resultado { get; set; }
    }

    [DataContract(Namespace = "Ekilibrate.Model.Common")]
    public class clsBoolRespuesta : clsRespuesta
    {
        [DataMember]
        public Boolean Resultado { get; set; }
    }
}
