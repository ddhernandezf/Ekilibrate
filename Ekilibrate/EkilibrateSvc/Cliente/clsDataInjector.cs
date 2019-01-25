using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Ekilibrate.Model.Common;
using Ekilibrate.Data.Access.Common;
using Ekilibrate.Model.Services.Cliente;
using Ekilibrate.Services.Abstract;
using System.Threading.Tasks;
using Dapper;
using Autofac;

namespace Ekilibrate.Services.Cliente
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall,
                     ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class clsDataInjector : clsServiceBase, IDataInjector
    {
        async Task IDataInjector.CargarParticipantes(int ProyectoId, IEnumerable<Ekilibrate.Model.Entity.Participante.clsParticipante> Data)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.Cliente.clsController(scope);
                    await objController.CargarParticipantes(ProyectoId, Data);
                    var DBContext = scope.Resolve<DBTrnContext>();
                    DBContext.CommitTransaction();                    
                }
                catch (FaultException ex)
                {
                    throw ex;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
