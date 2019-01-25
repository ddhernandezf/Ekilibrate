using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Ekilibrate.Model.Services.Nutricionista;
using Ekilibrate.Model.Common;
using Ekilibrate.Services.Abstract;
using Ekilibrate.Data.Access.Common;
using System.Threading.Tasks;
using Dapper;
using Autofac;

namespace Ekilibrate.Services.Nutricionista
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall,
                     ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class clsDataInjector : clsServiceBase, IDataInjector
    {

        #region Diagnostico

        async Task IDataInjector.CreateDiagnostico(Ekilibrate.Model.Entity.Nutricionista.Diagnostico Data)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.Nutricionista.clsDiagnostico(scope);
                    await objController.Create(Data);
                    var DBContext = scope.Resolve<DBTrnContext>();
                    DBContext.CommitTransaction();                    
                }
                catch (FaultException ex)
                {
                    throw ex;
                }
                catch (Exception e)
                {
                    throw new FaultException("Error al registrar los datos del diagnostico. Mensaje: "+e.Message);
                }
            }
        }

        async Task<Int32> IDataInjector.CreateDiagnosticoAnamnesis(IEnumerable<Ekilibrate.Model.Entity.Nutricionista.DiagnosticoAnamnesisTiempo> Data)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.Nutricionista.clsDiagnosticoAnamnesis(scope);
                    var result = await objController.Create(Data);
                    var DBContext = scope.Resolve<DBTrnContext>();
                    DBContext.CommitTransaction();
                    return result;
                }
                catch (FaultException ex)
                {
                    throw ex;
                }
                catch (Exception e)
                {
                    throw new FaultException("Error al registrar los datos del diagnostico. Mensaje: " + e.Message);
                }
            }
        }

        async Task<Int32> IDataInjector.CreateDiagnosticoAlimentos(IEnumerable<Ekilibrate.Model.Entity.Nutricionista.DiagnosticoAlimentos> Data)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.Nutricionista.clsDiagnosticoAlimentos(scope);
                    var result = await objController.Create(Data);
                    var DBContext = scope.Resolve<DBTrnContext>();
                    DBContext.CommitTransaction();
                    return result;
                }
                catch (FaultException ex)
                {
                    throw ex;
                }
                catch (Exception e)
                {
                    throw new FaultException("Error al registrar los datos del diagnostico. Mensaje: " + e.Message);
                }
            }
        }

        #endregion


        async Task IDataInjector.CreateSeguimiento(Ekilibrate.Model.Entity.Nutricionista.clsSeguimiento Data)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.Nutricionista.clsController(scope);
                    await objController.FinalizarCita(Data);
                    
                    var DBContext = scope.Resolve<DBTrnContext>();
                    DBContext.CommitTransaction();
                }
                catch (FaultException ex)
                {
                    throw ex;
                }
                catch (Exception ex)
                {
                    //var objController = new Ekilibrate.BL.Common.clsLog(scope);
                    //objController.GuardarLog(ex);
                    throw new FaultException("Error al registrar los datos del seguimiento.");
                }
            }
        }


        async Task IDataInjector.SincronizarCuadroMetas(IEnumerable<Ekilibrate.Model.Entity.Nutricionista.clsSeguimientoAspectos> Data)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.Nutricionista.clsController(scope);
                    await objController.SincronizarCuadroMetas(Data);
                    var DBContext = scope.Resolve<DBTrnContext>();
                    DBContext.CommitTransaction();
                }
                catch (FaultException ex)
                {
                    throw ex;
                }
                catch (Exception ex)
                {
                    //var objController = new Ekilibrate.BL.Common.clsLog(scope);
                    //objController.GuardarLog(ex);
                    throw new FaultException("Error al registrar los datos del seguimiento.");
                }
            }
        }

        async Task IDataInjector.SincronizarPlan(Ekilibrate.Model.Entity.Nutricionista.clsPlanAlimentacion Data)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.Nutricionista.clsPlanAlimentacion(scope);
                    await objController.Sincronizar(Data);
                    var DBContext = scope.Resolve<DBTrnContext>();
                    DBContext.CommitTransaction();
                }
                catch (FaultException ex)
                {
                    throw ex;
                }
                catch (Exception ex)
                {
                    //var objController = new Ekilibrate.BL.Common.clsLog(scope);
                    //objController.GuardarLog(ex);
                    throw new FaultException("Error al registrar los datos del plan de alimentacion.");
                }
            }
        }

        #region Reprogramacion

        async Task IDataInjector.UpdateCitaProgramacion(Ekilibrate.Model.Entity.Administrador.clsCitaProgramacion Data)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.Administrador.clsCitaProgramacion(scope);
                    await objController.Reprograma_update(Data);
                    var DBContext = scope.Resolve<DBTrnContext>();
                    DBContext.CommitTransaction();

                    objController = new Ekilibrate.BL.Controller.Administrador.clsCitaProgramacion(scope);
                    await objController.Reprograma_Insert(Data);
                    DBContext = scope.Resolve<DBTrnContext>();
                    DBContext.CommitTransaction();


                }
                catch (FaultException ex)
                {
                    throw ex;
                }
                catch (Exception ex)
                {
                    //var objController = new Ekilibrate.BL.Common.clsLog(scope);
                    //objController.GuardarLog(ex);
                    throw new FaultException("Error al registrar los datos del seguimiento.");
                }
            }
        }

        #endregion

    }
}
