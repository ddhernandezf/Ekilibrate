using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Ekilibrate.Model.Services.Participante;
using Ekilibrate.Model.Common;
using Ekilibrate.Services.Abstract;
using Ekilibrate.Data.Access.Common;
using System.Threading.Tasks;
using Dapper;
using Autofac;

namespace Ekilibrate.Services.Participante
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall,
                     ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class clsDataInjector : clsServiceBase, IDataInjector
    {
        //DIAGNOSTICO
        async Task<Int32> IDataInjector.CreateDiagnostico(Ekilibrate.Model.Entity.Participante.clsDiagnosticoBase Data)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.Participante.clsDiagnostico(scope);
                    var result = await objController.Create(Data);
                    var DBContext = scope.Resolve<DBTrnContext>();
                    DBContext.CommitTransaction();
                    return result;
                }
                catch (FaultException ex)
                {
                    throw ex;
                }
                catch (Exception)
                {
                    throw new FaultException("Error al registrar los datos del diagnostico.");
                }
            }
        }
        async Task IDataInjector.UpdateDiagnostico(Ekilibrate.Model.Entity.Participante.clsDiagnosticoBase Data)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.Participante.clsDiagnostico(scope);
                    
                    await objController.Update(Data);
                    var DBContext = scope.Resolve<DBTrnContext>();
                    DBContext.CommitTransaction();
                }
                catch (FaultException ex)
                {
                    throw ex;
                }
                catch (Exception ex)
                {
                    var objController = new Ekilibrate.BL.Common.clsLog(scope);
                    objController.GuardarLog(ex);
                    throw new FaultException("Error al actualizar datos del diagnóstico.");
                }
            }
        }

        async Task IDataInjector.DeleteDiagnostico(int ID_PARTICIPANTE)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.Participante.clsDiagnostico(scope);
                    await objController.Delete(ID_PARTICIPANTE);
                    var DBContext = scope.Resolve<DBTrnContext>();
                    DBContext.CommitTransaction();
                }
                catch (FaultException ex)
                {
                    throw ex;
                }
                catch (Exception ex)
                {
                    var objController = new Ekilibrate.BL.Common.clsLog(scope);
                    objController.GuardarLog(ex);
                    throw new FaultException("Error al eliminar el diagnostico.");
                }
            }
        }

        //ALIMENTACION
        async Task<Int32> IDataInjector.CreateAlimentacion(Ekilibrate.Model.Entity.Participante.clsAlimentacionBase Data)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.Participante.clsAlimentacion(scope);
                    var result = await objController.Create(Data);
                    var DBContext = scope.Resolve<DBTrnContext>();
                    DBContext.CommitTransaction();
                    return result;
                }
                catch (FaultException ex)
                {
                    throw ex;
                }
                catch (Exception)
                {
                    throw new FaultException("Error al registrar los datos de alimentacion.");
                }
            }
        }
        async Task IDataInjector.UpdateAlimentacion(Ekilibrate.Model.Entity.Participante.clsAlimentacionBase Data)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.Participante.clsAlimentacion(scope);
                    await objController.Update(Data);
                    var DBContext = scope.Resolve<DBTrnContext>();
                    DBContext.CommitTransaction();
                }
                catch (FaultException ex)
                {
                    throw ex;
                }
                catch (Exception ex)
                {
                    var objController = new Ekilibrate.BL.Common.clsLog(scope);
                    objController.GuardarLog(ex);
                    throw new FaultException("Error al actualizar datos de la alimentacion.");
                }
            }
        }

        async Task IDataInjector.DeleteAlimentacion(int ID_PARTICIPANTE)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.Participante.clsAlimentacion(scope);
                    await objController.Delete(ID_PARTICIPANTE);
                    var DBContext = scope.Resolve<DBTrnContext>();
                    DBContext.CommitTransaction();
                }
                catch (FaultException ex)
                {
                    throw ex;
                }
                catch (Exception ex)
                {
                    var objController = new Ekilibrate.BL.Common.clsLog(scope);
                    objController.GuardarLog(ex);
                    throw new FaultException("Error al eliminar datos de alimentacion.");
                }
            }
        }
        //RIESGO
        async Task<Int32> IDataInjector.CreateRiesgo(Ekilibrate.Model.Entity.Participante.clsRiesgoBase Data)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.Participante.clsRiesgo(scope);
                    var result = await objController.Create(Data);
                    var DBContext = scope.Resolve<DBTrnContext>();
                    DBContext.CommitTransaction();
                    return result;
                }
                catch (FaultException ex)
                {
                    throw ex;
                }
                catch (Exception)
                {
                    throw new FaultException("Error al registrar los datos de riesgo.");
                }
            }
        }
        async Task IDataInjector.UpdateRiesgo(Ekilibrate.Model.Entity.Participante.clsRiesgoBase Data)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.Participante.clsRiesgo(scope);
                    await objController.Update(Data);
                    var DBContext = scope.Resolve<DBTrnContext>();
                    DBContext.CommitTransaction();
                }
                catch (FaultException ex)
                {
                    throw ex;
                }
                catch (Exception ex)
                {
                    var objController = new Ekilibrate.BL.Common.clsLog(scope);
                    objController.GuardarLog(ex);
                    throw new FaultException("Error al actualizar datos de riesgo.");
                }
            }
        }

        async Task IDataInjector.DeleteRiesgo(int ID_PARTICIPANTE)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.Participante.clsRiesgo(scope);
                    await objController.Delete(ID_PARTICIPANTE);
                    var DBContext = scope.Resolve<DBTrnContext>();
                    DBContext.CommitTransaction();
                }
                catch (FaultException ex)
                {
                    throw ex;
                }
                catch (Exception ex)
                {
                    var objController = new Ekilibrate.BL.Common.clsLog(scope);
                    objController.GuardarLog(ex);
                    throw new FaultException("Error al eliminar datos de riesgo.");
                }
            }
        }

        //CUIDADO
        async Task IDataInjector.CreateCuidado(Ekilibrate.Model.Entity.Participante.clsCuidado Data)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.Participante.clsCuidado(scope);
                    await objController.Create(Data);
                    var DBContext = scope.Resolve<DBTrnContext>();
                    DBContext.CommitTransaction();
                }
                catch (FaultException ex)
                {
                    throw ex;
                }
                catch (Exception)
                {
                    throw new FaultException("Error al registrar los datos de cuidado.");
                }
            }
        }
        async Task IDataInjector.UpdateCuidado(Ekilibrate.Model.Entity.Participante.clsCuidado Data)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.Participante.clsCuidado(scope);
                    await objController.Update(Data);
                    var DBContext = scope.Resolve<DBTrnContext>();
                    DBContext.CommitTransaction();
                }
                catch (FaultException ex)
                {
                    throw ex;
                }
                catch (Exception ex)
                {
                    var objController = new Ekilibrate.BL.Common.clsLog(scope);
                    objController.GuardarLog(ex);
                    throw new FaultException("Error al actualizar datos de cuidado.");
                }
            }
        }

        async Task IDataInjector.DeleteCuidado(int ID_PARTICIPANTE)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.Participante.clsCuidado(scope);
                    await objController.Delete(ID_PARTICIPANTE);
                    var DBContext = scope.Resolve<DBTrnContext>();
                    DBContext.CommitTransaction();
                }
                catch (FaultException ex)
                {
                    throw ex;
                }
                catch (Exception ex)
                {
                    var objController = new Ekilibrate.BL.Common.clsLog(scope);
                    objController.GuardarLog(ex);
                    throw new FaultException("Error al eliminar datos de cuidado.");
                }
            }
        }
        //EMOCION
        async Task<Int32> IDataInjector.CreateEmocion(Ekilibrate.Model.Entity.Participante.clsEmocionBase Data)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.Participante.clsEmocion(scope);
                    var result = await objController.Create(Data);
                    var DBContext = scope.Resolve<DBTrnContext>();
                    DBContext.CommitTransaction();
                    return result;
                }
                catch (FaultException ex)
                {
                    throw ex;
                }
                catch (Exception)
                {
                    throw new FaultException("Error al registrar los datos de area de emocion.");
                }
            }
        }
        async Task IDataInjector.UpdateEmocion(Ekilibrate.Model.Entity.Participante.clsEmocionBase Data)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.Participante.clsEmocion(scope);
                    await objController.Update(Data);
                    var DBContext = scope.Resolve<DBTrnContext>();
                    DBContext.CommitTransaction();
                }
                catch (FaultException ex)
                {
                    throw ex;
                }
                catch (Exception ex)
                {
                    var objController = new Ekilibrate.BL.Common.clsLog(scope);
                    objController.GuardarLog(ex);
                    throw new FaultException("Error al actualizar datos del area de emoción.");
                }
            }
        }

        async Task IDataInjector.DeleteEmocion(int ID_PARTICIPANTE)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.Participante.clsEmocion(scope);
                    await objController.Delete(ID_PARTICIPANTE);
                    var DBContext = scope.Resolve<DBTrnContext>();
                    DBContext.CommitTransaction();
                }
                catch (FaultException ex)
                {
                    throw ex;
                }
                catch (Exception ex)
                {
                    var objController = new Ekilibrate.BL.Common.clsLog(scope);
                    objController.GuardarLog(ex);
                    throw new FaultException("Error al eliminar datos del area de Emocion.");
                }
            }
        }

        //TIEMPO
        async Task<Int32> IDataInjector.CreateTiempo(Ekilibrate.Model.Entity.Participante.clsTiempoBase Data)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.Participante.clsTiempo(scope);
                    var result = await objController.Create(Data);
                    var DBContext = scope.Resolve<DBTrnContext>();
                    DBContext.CommitTransaction();
                    return result;
                }
                catch (FaultException ex)
                {
                    throw ex;
                }
                catch (Exception)
                {
                    throw new FaultException("Error al registrar los datos de tiempo.");
                }
            }
        }
        async Task IDataInjector.UpdateTiempo(Ekilibrate.Model.Entity.Participante.clsTiempoBase Data)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.Participante.clsTiempo(scope);
                    await objController.Update(Data);
                    var DBContext = scope.Resolve<DBTrnContext>();
                    DBContext.CommitTransaction();
                }
                catch (FaultException ex)
                {
                    throw ex;
                }
                catch (Exception ex)
                {
                    var objController = new Ekilibrate.BL.Common.clsLog(scope);
                    objController.GuardarLog(ex);
                    throw new FaultException("Error al actualizar datos de tiempo.");
                }
            }
        }

        async Task IDataInjector.DeleteTiempo(int ID_PARTICIPANTE)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.Participante.clsTiempo(scope);
                    await objController.Delete(ID_PARTICIPANTE);
                    var DBContext = scope.Resolve<DBTrnContext>();
                    DBContext.CommitTransaction();
                }
                catch (FaultException ex)
                {
                    throw ex;
                }
                catch (Exception ex)
                {
                    var objController = new Ekilibrate.BL.Common.clsLog(scope);
                    objController.GuardarLog(ex);
                    throw new FaultException("Error al eliminar datos de Tiempo.");
                }
            }
        }
        //COMUNICACION
        async Task<Int32> IDataInjector.CreateComunicacion(Ekilibrate.Model.Entity.Participante.clsComunicacionBase Data)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.Participante.clsComunicacion(scope);
                    var result = await objController.Create(Data);
                    var DBContext = scope.Resolve<DBTrnContext>();
                    DBContext.CommitTransaction();
                    return result;
                }
                catch (FaultException ex)
                {
                    throw ex;
                }
                catch (Exception)
                {
                    throw new FaultException("Error al registrar los datos de la comunicacion.");
                }
            }
        }
        async Task IDataInjector.UpdateComunicacion(Ekilibrate.Model.Entity.Participante.clsComunicacionBase Data)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.Participante.clsComunicacion(scope);

                    await objController.Update(Data);
                    var DBContext = scope.Resolve<DBTrnContext>();
                    DBContext.CommitTransaction();
                }
                catch (FaultException ex)
                {
                    throw ex;
                }
                catch (Exception ex)
                {
                    var objController = new Ekilibrate.BL.Common.clsLog(scope);
                    objController.GuardarLog(ex);
                    throw new FaultException("Error al actualizar datos de la comunicacion.");
                }
            }
        }
        async Task IDataInjector.DeleteComunicacion(int ID_PARTICIPANTE)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.Participante.clsComunicacion(scope);
                    await objController.Delete(ID_PARTICIPANTE);
                    var DBContext = scope.Resolve<DBTrnContext>();
                    DBContext.CommitTransaction();
                }
                catch (FaultException ex)
                {
                    throw ex;
                }
                catch (Exception ex)
                {
                    var objController = new Ekilibrate.BL.Common.clsLog(scope);
                    objController.GuardarLog(ex);
                    throw new FaultException("Error al eliminar la comunicacion.");
                }
            }
        }
        //COMUNICACIONDOS
        async Task<Int32> IDataInjector.CreateComunicacionDos(Ekilibrate.Model.Entity.Participante.clsComunicacionDosBase Data)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.Participante.clsComunicacionDos(scope);
                    var result = await objController.Create(Data);
                    var DBContext = scope.Resolve<DBTrnContext>();
                    DBContext.CommitTransaction();
                    return result;
                }
                catch (FaultException ex)
                {
                    throw ex;
                }
                catch (Exception)
                {
                    throw new FaultException("Error al registrar los datos de la comunicacion.");
                }
            }
        }
        async Task IDataInjector.UpdateComunicacionDos(Ekilibrate.Model.Entity.Participante.clsComunicacionDosBase Data)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.Participante.clsComunicacionDos(scope);

                    await objController.Update(Data);
                    var DBContext = scope.Resolve<DBTrnContext>();
                    DBContext.CommitTransaction();
                }
                catch (FaultException ex)
                {
                    throw ex;
                }
                catch (Exception ex)
                {
                    var objController = new Ekilibrate.BL.Common.clsLog(scope);
                    objController.GuardarLog(ex);
                    throw new FaultException("Error al actualizar datos de la comunicacion.");
                }
            }
        }
        async Task IDataInjector.DeleteComunicacionDos(int ID_PARTICIPANTE)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.Participante.clsComunicacionDos(scope);
                    await objController.Delete(ID_PARTICIPANTE);
                    var DBContext = scope.Resolve<DBTrnContext>();
                    DBContext.CommitTransaction();
                }
                catch (FaultException ex)
                {
                    throw ex;
                }
                catch (Exception ex)
                {
                    var objController = new Ekilibrate.BL.Common.clsLog(scope);
                    objController.GuardarLog(ex);
                    throw new FaultException("Error al eliminar la comunicacion.");
                }
            }
        }
        //LIDERAZGO
        async Task IDataInjector.SelectLiderazgo(Ekilibrate.Model.Entity.Participante.clsTestLiderazgoBase Data)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.Participante.clsTestLiderazgo(scope);
                    await objController.Select(Data);
                    var DBContext = scope.Resolve<DBTrnContext>();
                    DBContext.CommitTransaction();
                }
                catch (FaultException ex)
                {
                    throw ex;
                }
                catch (Exception)
                {
                    throw new FaultException("Error al registrar los datos de liderazgo.");
                }
            }
        }
        
        //PASOSDIA        
        async Task IDataInjector.SincronizarPasosDia(IEnumerable<Ekilibrate.Model.Entity.Participante.clsRegistroPasos> Data)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.Participante.clsPasosDia(scope);

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
                    //if (ex.Message != "La secuencia no contiene elementos")
                    //{
                        var objController = new Ekilibrate.BL.Common.clsLog(scope);
                        objController.GuardarLog(ex);
                        throw new FaultException("Error al actualizar datos de los pasos por dia.");
                    //}
                }
            }
        }
        
        async Task IDataInjector.SetPasosDia(Ekilibrate.Model.Entity.Participante.clsPasosDiaApp Data)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.Participante.clsPasosDia(scope);
                    var objRetriever = new Ekilibrate.BL.DataRetriever.Participante.clsPasosDia(scope);
                    Ekilibrate.Model.Entity.Participante.clsPasosDiaBase DataPasos = await objRetriever.GetPasosDia(Data.UserId, Data.Date);

                    if (DataPasos.ParticipanteId == 0)
                    {
                        DataPasos = new Ekilibrate.Model.Entity.Participante.clsPasosDiaBase();
                        await objController.Create(DataPasos);
                    }
                    else
                    {
                        DataPasos.Caminados = Data.Steps;
                        await objController.Update(DataPasos);
                    }
                    
                    var DBContext = scope.Resolve<DBTrnContext>();
                    DBContext.CommitTransaction();                    
                }
                catch (FaultException ex)
                {
                    throw ex;
                }
                catch (Exception)
                {
                    throw new FaultException("Error al registrar los datos de pasos por dia.");
                }
            }
        }
                
        async Task IDataInjector.SincronizarAlimentacionDia(IEnumerable<Ekilibrate.Model.Entity.Participante.clsAlimentacionDiaBase> Data)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.Participante.clsAlimentacionDia(scope);

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
                    var objController = new Ekilibrate.BL.Common.clsLog(scope);
                    objController.GuardarLog(ex);
                    throw new FaultException("Error al actualizar datos de los pasos por dia.");
                }
            }
        }
        
        //BEBIDAS FRECUENTES
        async Task IDataInjector.CreateBebidasFrecuentes(Ekilibrate.Model.Entity.Participante.clsBebidasFrecuentesBase Data)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.Participante.clsBebidasFrecuentes(scope);
                    await objController.Create(Data);
                    var DBContext = scope.Resolve<DBTrnContext>();
                    DBContext.CommitTransaction();;
                }
                catch (FaultException ex)
                {
                    throw ex;
                }
                catch (Exception)
                {
                    throw new FaultException("Error al registrar los datos de bebidas frecuentes.");
                }
            }
        }

        async Task IDataInjector.DeleteBebidasFrecuentes(Ekilibrate.Model.Entity.Participante.clsBebidasFrecuentesBase Data)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.Participante.clsBebidasFrecuentes(scope);
                    await objController.Delete(Data);
                    var DBContext = scope.Resolve<DBTrnContext>();
                    DBContext.CommitTransaction();
                }
                catch (FaultException ex)
                {
                    throw ex;
                }
                catch (Exception ex)
                {
                    var objController = new Ekilibrate.BL.Common.clsLog(scope);
                    objController.GuardarLog(ex);
                    throw new FaultException("Error al eliminar datos de bebidas frecuentes.");
                }
            }
        }

        //CONDICION PRE_EXISTENTE
        async Task IDataInjector.CreateCondicionPreExistente(Ekilibrate.Model.Entity.Participante.clsCondicionPreExistenteBase Data)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.Participante.clsCondicionPreExistente(scope);
                    await objController.Create(Data);
                    var DBContext = scope.Resolve<DBTrnContext>();
                    DBContext.CommitTransaction(); ;
                }
                catch (FaultException ex)
                {
                    throw ex;
                }
                catch (Exception)
                {
                    throw new FaultException("Error al registrar los datos de condiciones PreExistentes.");
                }
            }
        }

        async Task IDataInjector.DeleteCondicionPreExistente(Ekilibrate.Model.Entity.Participante.clsCondicionPreExistenteBase Data)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.Participante.clsCondicionPreExistente(scope);
                    await objController.Delete(Data);
                    var DBContext = scope.Resolve<DBTrnContext>();
                    DBContext.CommitTransaction();
                }
                catch (FaultException ex)
                {
                    throw ex;
                }
                catch (Exception ex)
                {
                    var objController = new Ekilibrate.BL.Common.clsLog(scope);
                    objController.GuardarLog(ex);
                    throw new FaultException("Error al eliminar datos de condicion PreExistente.");
                }
            }
        }


        //MEDIDA BEBIDA
        async Task IDataInjector.CreateMedidaBebida(Ekilibrate.Model.Entity.Participante.clsMedidaBebidaBase Data)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.Participante.clsMedidaBebida(scope);
                    await objController.Create(Data);
                    var DBContext = scope.Resolve<DBTrnContext>();
                    DBContext.CommitTransaction(); ;
                }
                catch (FaultException ex)
                {
                    throw ex;
                }
                catch (Exception)
                {
                    throw new FaultException("Error al registrar los datos de Medidas de las bebidas.");
                }
            }
        }

        async Task IDataInjector.DeleteMedidaBebida(Ekilibrate.Model.Entity.Participante.clsMedidaBebidaBase Data)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.Participante.clsMedidaBebida(scope);
                    await objController.Delete(Data);
                    var DBContext = scope.Resolve<DBTrnContext>();
                    DBContext.CommitTransaction();
                }
                catch (FaultException ex)
                {
                    throw ex;
                }
                catch (Exception ex)
                {
                    var objController = new Ekilibrate.BL.Common.clsLog(scope);
                    objController.GuardarLog(ex);
                    throw new FaultException("Error al eliminar datos de Medidas de Bebidas.");
                }
            }
        }

        //ENFERMEDAD
        async Task IDataInjector.CreateEnfermedad(Ekilibrate.Model.Entity.Participante.clsEnfermedadBase Data)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.Participante.clsEnfermedad(scope);
                    await objController.Create(Data);
                    var DBContext = scope.Resolve<DBTrnContext>();
                    DBContext.CommitTransaction(); ;
                }
                catch (FaultException ex)
                {
                    throw ex;
                }
                catch (Exception)
                {
                    throw new FaultException("Error al registrar los datos de Enfermedad.");
                }
            }
        }

        async Task IDataInjector.DeleteEnfermedad(Ekilibrate.Model.Entity.Participante.clsEnfermedadBase Data)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.Participante.clsEnfermedad(scope);
                    await objController.Delete(Data);
                    var DBContext = scope.Resolve<DBTrnContext>();
                    DBContext.CommitTransaction();
                }
                catch (FaultException ex)
                {
                    throw ex;
                }
                catch (Exception ex)
                {
                    var objController = new Ekilibrate.BL.Common.clsLog(scope);
                    objController.GuardarLog(ex);
                    throw new FaultException("Error al eliminar datos de Enfermedad.");
                }
            }
        }

        //FRECUENCIA
        async Task IDataInjector.CreateFrecuencia(Ekilibrate.Model.Entity.Participante.clsFrecuencia Data)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.Participante.clsFrecuencia(scope);
                    await objController.Create(Data);
                    var DBContext = scope.Resolve<DBTrnContext>();
                    DBContext.CommitTransaction();
                    
                }
                catch (FaultException ex)
                {
                    throw ex;
                }
                catch (Exception)
                {
                    throw new FaultException("Error al registrar los datos de la frecuencia.");
                }
            }
        }
        //ASERTIVA
        async Task IDataInjector.CreateAsertiva(Ekilibrate.Model.Entity.Participante.clsAsertiva Data)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.Participante.clsAsertiva(scope);
                    await objController.Create(Data);
                    var DBContext = scope.Resolve<DBTrnContext>();
                    DBContext.CommitTransaction();

                }
                catch (FaultException ex)
                {
                    throw ex;
                }
                catch (Exception)
                {
                    throw new FaultException("Error al registrar los datos de la asertiva.");
                }
            }
        }
        //ASERTIVADOS
        async Task IDataInjector.CreateAsertivaDos(Ekilibrate.Model.Entity.Participante.clsAsertivaDos Data)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.Participante.clsAsertivaDos(scope);
                    await objController.Create(Data);
                    var DBContext = scope.Resolve<DBTrnContext>();
                    DBContext.CommitTransaction();

                }
                catch (FaultException ex)
                {
                    throw ex;
                }
                catch (Exception)
                {
                    throw new FaultException("Error al registrar los datos de la asertiva dos.");
                }
            }
        }

        //ANSIEDAD
        async Task IDataInjector.CreateAnsiedad(Ekilibrate.Model.Entity.Participante.clsAnsiedadBase Data)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.Participante.clsAnsiedad(scope);
                    await objController.Create(Data);
                    var DBContext = scope.Resolve<DBTrnContext>();
                    DBContext.CommitTransaction(); ;
                }
                catch (FaultException ex)
                {
                    throw ex;
                }
                catch (Exception)
                {
                    throw new FaultException("Error al registrar los datos de ansiedad.");
                }
            }
        }

        async Task IDataInjector.DeleteAnsiedad(Ekilibrate.Model.Entity.Participante.clsAnsiedadBase Data)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.Participante.clsAnsiedad(scope);
                    await objController.Delete(Data);
                    var DBContext = scope.Resolve<DBTrnContext>();
                    DBContext.CommitTransaction();
                }
                catch (FaultException ex)
                {
                    throw ex;
                }
                catch (Exception ex)
                {
                    var objController = new Ekilibrate.BL.Common.clsLog(scope);
                    objController.GuardarLog(ex);
                    throw new FaultException("Error al eliminar datos de ansiedad.");
                }
            }
        }

        //TEST FINANZAS
        async Task IDataInjector.SelectFinanzas(Ekilibrate.Model.Entity.Participante.clsTestFinanzas Data)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.Participante.clsTestFinanzas(scope);
                    await objController.Select(Data);
                    var DBContext = scope.Resolve<DBTrnContext>();
                    DBContext.CommitTransaction(); ;
                }
                catch (FaultException ex)
                {
                    throw ex;
                }
                catch (Exception)
                {
                    throw new FaultException("Error al registrar los datos de ansiedad.");
                }
            }
        }

        //TEST TEMA FINANZAS
        async Task IDataInjector.SelectTemaFinanzas(Ekilibrate.Model.Entity.Participante.clsTestTemaFinanzas Data)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.Participante.clsTestTemaFinanzas(scope);
                    await objController.Select(Data);
                    var DBContext = scope.Resolve<DBTrnContext>();
                    DBContext.CommitTransaction(); ;
                }
                catch (FaultException ex)
                {
                    throw ex;
                }
                catch (Exception)
                {
                    throw new FaultException("Error al registrar datos en el test de finanzas.");
                }
            }
        }

        async Task IDataInjector.UnSelectTemaFinanzas(Ekilibrate.Model.Entity.Participante.clsTestTemaFinanzas Data)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.Participante.clsTestTemaFinanzas(scope);
                    await objController.UnSelect(Data);
                    var DBContext = scope.Resolve<DBTrnContext>();
                    DBContext.CommitTransaction(); ;
                }
                catch (FaultException ex)
                {
                    throw ex;
                }
                catch (Exception)
                {
                    throw new FaultException("Error al registrar datos en el test de finanzas.");
                }
            }
        }

        async Task<string> IDataInjector.CrearParticipante(Ekilibrate.Model.Entity.Participante.clsRegistroParticipante Data)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.Participante.clsController(scope);
                    var result = await objController.CrearParticipante(Data);
                    var DBContext = scope.Resolve<DBTrnContext>();
                    DBContext.CommitTransaction();
                    return result;
                }
                catch (FaultException ex)
                {
                    throw ex;
                }
                catch (Exception)
                {
                    throw new FaultException("Error al registrar los datos del usuario. Favor comunícate con tu administrador o contacto principal o escríbenos a info@ekilibrate.com");
                }
            }
        }

        async Task IDataInjector.FotoPerfil(int Participante, byte[] file)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.Participante.clsController(scope);
                    await objController.FotoPerfil(Participante, file);
                    var DBContext = scope.Resolve<DBTrnContext>();
                    DBContext.CommitTransaction();                    
                }
                catch (FaultException ex)
                {
                    throw ex;
                }
                catch (Exception)
                {
                    throw new FaultException("Error al registrar los datos del usuario. Favor comunícate con tu administrador o contacto principal o escríbenos a info@ekilibrate.com");
                }
            }
        }
    }
}
