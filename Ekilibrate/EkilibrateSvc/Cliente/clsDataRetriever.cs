using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Ekilibrate.Model.Services.Cliente;
using Ekilibrate.Model.Entity.Proyecto;
using Ekilibrate.Services.Abstract;
using System.Threading.Tasks;
using Dapper;

namespace Ekilibrate.Services.Cliente
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single,
                     ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class clsDataRetriever : clsServiceBase, IDataRetriever
    {
        async Task<IEnumerable<Model.Entity.Proyecto.clsProyectoBase>> IDataRetriever.GetProyectos(clsProyectoFiltro Filtro)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                var objDataRetriever = new Ekilibrate.BL.DataRetriever.Cliente.clsProyecto(scope);
                return await objDataRetriever.GetProyecto(Filtro);
            }
        }

        async Task<IEnumerable<Model.Entity.Proyecto.clsProyectoBase>> IDataRetriever.GetParticipantes(clsProyectoFiltro Filtro)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope())
            {
                var objDataRetriever = new Ekilibrate.BL.DataRetriever.Cliente.clsProyecto(scope);
                return await objDataRetriever.GetProyecto(Filtro);
            }
        }
    }
}
