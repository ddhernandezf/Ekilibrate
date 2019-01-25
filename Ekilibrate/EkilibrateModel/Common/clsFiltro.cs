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
    public class clsPaging
    {
        [DataMember]
        public Int32 ItemsPerPage { get; set; }
        [DataMember]
        public String Page { get; set; }
    }
    
}
