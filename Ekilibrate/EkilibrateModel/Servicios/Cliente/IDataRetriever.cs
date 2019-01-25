using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using Ekilibrate.Model.Entity.Proyecto;

namespace Ekilibrate.Model.Services.Cliente
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IDataRetriever
    {
        [OperationContract]
        Task<IEnumerable<Model.Entity.Proyecto.clsProyectoBase>> GetProyectos(clsProyectoFiltro Filtro);

        [OperationContract]
        Task<IEnumerable<Model.Entity.Proyecto.clsProyectoBase>> GetParticipantes(clsProyectoFiltro Filtro);
    }
}
