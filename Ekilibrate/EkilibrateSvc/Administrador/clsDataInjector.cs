using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Ekilibrate.Model.Services.Administrador;
using Ekilibrate.Model.Common;
using Ekilibrate.Services.Abstract;
using Ekilibrate.Data.Access.Common;
using System.Threading.Tasks;
using Dapper;
using Autofac;

namespace Ekilibrate.Services.Administrador
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall,
                     ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class clsDataInjector : clsServiceBase, IDataInjector
    {
        #region Empresa
        async Task<Int32> IDataInjector.CreateEmpresa(Ekilibrate.Model.Entity.Administrador.clsEmpresaBase Data)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.Administrador.clsEmpresa(scope);
                    var result = await objController.Create(Data);
                    var DBContext = scope.Resolve<DBTrnContext>();
                    DBContext.CommitTransaction();
                    return result;
                }
                catch (FaultException ex)
                {
                    throw ex;
                }
                catch (Exception ex)
                {
                    var objController = new Ekilibrate.BL.Common.clsLog(scope);
                    objController.GuardarLog(ex);
                    throw new FaultException("Error al registrar los datos de la empresa.");
                }
            }
        }

        async Task IDataInjector.UpdateEmpresa(Ekilibrate.Model.Entity.Administrador.clsEmpresaBase Data)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.Administrador.clsEmpresa(scope);
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
                    throw new FaultException("Error al actualizar datos de la empresa.");
                }
            }
        }

        async Task IDataInjector.DeleteEmpresa(int Id)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.Administrador.clsEmpresa(scope);
                    await objController.Delete(Id);
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
                    throw new FaultException("Error al eliminar la empresa.");
                }
            }
        }

        #endregion

        #region Salones
        async Task<Int32> IDataInjector.CreateSalon(Ekilibrate.Model.Entity.Administrador.clsSalonBase Data)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.clsSalon(scope);
                    var result = await objController.Create(Data);
                    var DBContext = scope.Resolve<DBTrnContext>();
                    DBContext.CommitTransaction();
                    return result;
                }
                catch (FaultException ex)
                {
                    throw ex;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        async Task IDataInjector.UpdateSalon(Ekilibrate.Model.Entity.Administrador.clsSalonBase Data)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.clsSalon(scope);
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
                    throw new FaultException("Error al actualizar datos de la empresa.");
                }
            }
        }

        async Task IDataInjector.DeleteSalon(int Id)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.clsSalon(scope);
                    await objController.Delete(Id);
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
                    throw new FaultException("Error al eliminar la empresa.");
                }
            }
        }
        #endregion

        #region Proyecto
        async Task<Int32> IDataInjector.CreateProyecto(Ekilibrate.Model.Entity.Administrador.clsProyecto Data)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.clsProyecto(scope);
                    var result = await objController.Create(Data);
                    var DBContext = scope.Resolve<DBTrnContext>();
                    DBContext.CommitTransaction();
                    return result;
                }
                catch (FaultException ex)
                {
                    throw ex;
                }
                catch (Exception ex)
                {
                    var objController = new Ekilibrate.BL.Common.clsLog(scope);
                    objController.GuardarLog(ex);
                    throw new FaultException("Error al registrar los datos del proyecto.");
                }
            }
        }


        async Task IDataInjector.UpdateProyecto(Ekilibrate.Model.Entity.Administrador.clsProyecto Data)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.clsProyecto(scope);
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
                    throw new FaultException("Error al actualizar los datos del proyecto.");
                }
            }
        }

        async Task IDataInjector.DeleteProyecto(int Id)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.clsProyecto(scope);
                    await objController.Delete(Id);
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
                    throw new FaultException("Error al eliminar los datos del proyecto.");
                }
            }
        }



        async Task IDataInjector.EnviarNotificacion(int ProyectoId)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.clsController(scope);
                    await objController.EnviarNotificacion(ProyectoId);
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
                    throw ex;
                }
            }
        }

        async Task IDataInjector.FinalizarCarga(int ProyectoId)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.clsController(scope);
                    await objController.FinalizarCargaParticipantes(ProyectoId);
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
                    throw new FaultException("Error al registrar los datos del proyecto.");
                }
            }
        }

        async Task IDataInjector.IniciarProyecto(int ProyectoId)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.clsController(scope);
                    await objController.IniciarProyecto(ProyectoId);
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
                    throw new FaultException("Error al registrar los datos del proyecto.");
                }
            }
        }

        async Task IDataInjector.AsignarNutricionistas(int ProyectoId)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.clsController(scope);
                    await objController.AsignarNutricionistas(ProyectoId);
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
                    throw new FaultException("Error al registrar los datos del proyecto.");
                }
            }
        }

        async Task IDataInjector.ProgramarCitas(int ProyectoId)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.clsController(scope);
                    await objController.ProgramarCitasNutricionales(ProyectoId);
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
                    throw new FaultException("Error al registrar los datos del proyecto.");
                }
            }
        }

        async Task IDataInjector.PruebaCorreo(int ProyectoId)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.clsController(scope);
                    await objController.CorreoDiagnosticoFinal(ProyectoId);
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
                    throw new FaultException("Error al enviar correo de prueba a los contactos");
                }
            }
        }

        async Task IDataInjector.SendNotifications()
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.clsController(scope);
                    await objController.SendNotifications();
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
                    throw new FaultException("Error al enviar correo de prueba a los contactos");
                }
            }
        }
        #endregion

        #region ProyectoSalon
        async Task IDataInjector.AddSalonProyecto(Ekilibrate.Model.Entity.Administrador.clsProyectoSalon Data)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.Administrador.clsProyectoSalon(scope);
                    await objController.Add(Data);
                    var DBContext = scope.Resolve<DBTrnContext>();
                    DBContext.CommitTransaction();
                }
                catch (FaultException ex)
                {
                    throw ex;
                }
                catch (Exception)
                {
                    throw new FaultException("Error al agregar el salon al proyecto.");
                }
            }
        }

        async Task IDataInjector.DeleteSalonProyecto(Ekilibrate.Model.Entity.Administrador.clsProyectoSalon Data)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.Administrador.clsProyectoSalon(scope);
                    await objController.Delete(Data);
                    var DBContext = scope.Resolve<DBTrnContext>();
                    DBContext.CommitTransaction();
                }
                catch (FaultException ex)
                {
                    throw ex;
                }
                catch (Exception)
                {
                    throw new FaultException("Error al quitar el salon al proyecto.");
                }
            }
        }
        #endregion

        #region ProyectoContacto
        async Task IDataInjector.AddContactoProyecto(Ekilibrate.Model.Entity.Administrador.clsProyectoContacto Data)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.Administrador.clsProyectoContacto(scope);
                    await objController.Add(Data);
                    var DBContext = scope.Resolve<DBTrnContext>();
                    DBContext.CommitTransaction();
                }
                catch (FaultException ex)
                {
                    throw ex;
                }
                catch (Exception)
                {
                    throw new FaultException("Error al agregar el salon al proyecto.");
                }
            }
        }

        async Task IDataInjector.DeleteContactoProyecto(Ekilibrate.Model.Entity.Administrador.clsProyectoContacto Data)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.Administrador.clsProyectoContacto(scope);
                    await objController.Delete(Data);
                    var DBContext = scope.Resolve<DBTrnContext>();
                    DBContext.CommitTransaction();
                }
                catch (FaultException ex)
                {
                    throw ex;
                }
                catch (Exception)
                {
                    throw new FaultException("Error al quitar el salon al proyecto.");
                }
            }
        }
        #endregion

        #region ProyectoSArea
        async Task IDataInjector.AddAreaProyecto(Ekilibrate.Model.Entity.Administrador.clsProyectoArea Data)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.Administrador.clsProyectoArea(scope);
                    await objController.Add(Data);
                    var DBContext = scope.Resolve<DBTrnContext>();
                    DBContext.CommitTransaction();
                }
                catch (FaultException ex)
                {
                    throw ex;
                }
                catch (Exception)
                {
                    throw new FaultException("Error al agregar el área al proyecto.");
                }
            }
        }

        async Task IDataInjector.DeleteAreaProyecto(Ekilibrate.Model.Entity.Administrador.clsProyectoArea Data)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.Administrador.clsProyectoArea(scope);
                    await objController.Delete(Data);
                    var DBContext = scope.Resolve<DBTrnContext>();
                    DBContext.CommitTransaction();
                }
                catch (FaultException ex)
                {
                    throw ex;
                }
                catch (Exception)
                {
                    throw new FaultException("Error al quitar el salon al proyecto.");
                }
            }
        }
        #endregion

        #region TipoUsoSalon
        async Task<Int32> IDataInjector.CreateTipoUsoSalon(Ekilibrate.Model.Catalogos.clsTipoUsoSalonBase Data)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.clsTipoUsoSalon(scope);
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
                    throw new FaultException("Error al registrar los datos del tipo de uso.");
                }
            }
        }

        async Task IDataInjector.UpdateTipoUsoSalon(Ekilibrate.Model.Catalogos.clsTipoUsoSalonBase Data)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.clsTipoUsoSalon(scope);
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
                    throw new FaultException("Error al actualizar datos de tipo de uso.");
                }
            }
        }

        async Task IDataInjector.DeleteTipoUsoSalon(int Id)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.clsTipoUsoSalon(scope);
                    await objController.Delete(Id);
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
                    throw new FaultException("Error al eliminar el tipo de uso.");
                }
            }
        }
        #endregion

        #region Colaborador
        async Task<Int32> IDataInjector.CreateColaborador(Ekilibrate.Model.Entity.Administrador.clsColaboradorBase Data)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.Administrador.clsColaborador(scope);
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
                    throw new FaultException("Error al registrar los datos del colaborador.");
                }
            }
        }

        async Task IDataInjector.UpdateColaborador(Ekilibrate.Model.Entity.Administrador.clsColaboradorBase Data)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.Administrador.clsColaborador(scope);
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
                    throw new FaultException("Error al actualizar datos de colaborador.");
                }
            }
        }

        async Task IDataInjector.DeleteColaborador(int Id)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.Administrador.clsColaborador(scope);
                    await objController.Delete(Id);
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
                    throw new FaultException("Error al eliminar la empresa.");
                }
            }
        }

        #endregion

        #region Contacto
        async Task<Int32> IDataInjector.CreateContacto(Ekilibrate.Model.Entity.Administrador.clsContactoBase Data)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.Administrador.clsContacto(scope);
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
                    throw new FaultException("Error al registrar los datos del colaborador.");
                }
            }
        }

        async Task IDataInjector.UpdateContacto(Ekilibrate.Model.Entity.Administrador.clsContactoBase Data)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.Administrador.clsContacto(scope);
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
                    throw new FaultException("Error al actualizar datos de colaborador.");
                }
            }
        }

        async Task IDataInjector.DeleteContacto(int Id)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.Administrador.clsContacto(scope);
                    await objController.Delete(Id);
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
                    throw new FaultException("Error al eliminar la empresa.");
                }
            }
        }

        #endregion

        #region ClienteRol
        async Task<Int32> IDataInjector.CreateClienteRol(Ekilibrate.Model.Administrador.clsClienteRolBase Data)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.Administrador.clsClienteRol(scope);
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
                    throw new FaultException("Error al registrar los datos del rol.");
                }
            }
        }

        async Task IDataInjector.UpdateClienteRol(Ekilibrate.Model.Administrador.clsClienteRolBase Data)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.Administrador.clsClienteRol(scope);
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
                    throw new FaultException("Error al actualizar datos del rol.");
                }
            }
        }

        async Task IDataInjector.DeleteClienteRol(int Id)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.Administrador.clsClienteRol(scope);
                    await objController.Delete(Id);
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
                    throw new FaultException("Error al eliminar la empresa.");
                }
            }
        }

        #endregion

        #region Taller
        async Task<Int32> IDataInjector.CreateTaller(Ekilibrate.Model.Entity.Administrador.clsTallerVista Data)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.clsTaller(scope);
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
                    throw new FaultException("Error al registrar los datos del taller.");
                }
            }
        }

        async Task IDataInjector.UpdateTaller(Ekilibrate.Model.Entity.Administrador.clsTallerVista Data)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.clsTaller(scope);
                    await objController.Update(Data);
                    var DBContext = scope.Resolve<DBTrnContext>();
                    DBContext.CommitTransaction();
                }
                catch (FaultException ex)
                {
                    throw ex;
                }
                catch (Exception)
                {
                    throw new FaultException("Error al modificar los datos del taller.");
                }
            }
        }


        async Task IDataInjector.DeleteTaller(Ekilibrate.Model.Entity.Administrador.clsTallerVista Data)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.clsTaller(scope);
                    await objController.Delete(Data);
                    var DBContext = scope.Resolve<DBTrnContext>();
                    DBContext.CommitTransaction();
                }
                catch (FaultException ex)
                {
                    throw ex;
                }
                catch (Exception)
                {
                    throw new FaultException("Error al eliminar los datos del taller.");
                }
            }
        }
        #endregion

        #region ColaboradorProyecto
        async Task IDataInjector.CreateAsistente(Ekilibrate.Model.Entity.Administrador.clsAsistenteBase Data)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.clsAsistente(scope);
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
                    throw new FaultException("Error al registrar los datos de asistente.");
                }
            }
        }


        async Task IDataInjector.CreateNutricionista(Ekilibrate.Model.Entity.Administrador.clsNutricionistaBase Data)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.clsNutricionista(scope);
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
                    throw new FaultException("Error al registrar los datos de nutricionista.");
                }
            }
        }


        async Task IDataInjector.CreateFacilitador(Ekilibrate.Model.Entity.Administrador.clsFacilitadorBase Data)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.clsFacilitador(scope);
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
                    throw new FaultException("Error al registrar los datos del facilitador.");
                }
            }
        }


        async Task IDataInjector.CreateEnfermera(Ekilibrate.Model.Entity.Administrador.clsEnfermeraBase Data)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.clsEnfermera(scope);
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
                    throw new FaultException("Error al registrar los datos del enfermero.");
                }
            }
        }


        async Task IDataInjector.DeleteAsistente(Ekilibrate.Model.Entity.Administrador.clsAsistenteBase Data)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.clsAsistente(scope);
                    await objController.Delete(Data);
                    var DBContext = scope.Resolve<DBTrnContext>();
                    DBContext.CommitTransaction();
                }
                catch (FaultException ex)
                {
                    throw ex;
                }
                catch (Exception)
                {
                    throw new FaultException("Error al registrar los datos de asistente.");
                }
            }
        }


        async Task IDataInjector.DeleteNutricionista(Ekilibrate.Model.Entity.Administrador.clsNutricionistaBase Data)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.clsNutricionista(scope);
                    await objController.Delete(Data);
                    var DBContext = scope.Resolve<DBTrnContext>();
                    DBContext.CommitTransaction();

                }
                catch (FaultException ex)
                {
                    throw ex;
                }
                catch (Exception)
                {
                    throw new FaultException("Error al registrar los datos de nutricionista.");
                }
            }
        }


        async Task IDataInjector.DeleteFacilitador(Ekilibrate.Model.Entity.Administrador.clsFacilitadorBase Data)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.clsFacilitador(scope);
                    await objController.Delete(Data);
                    var DBContext = scope.Resolve<DBTrnContext>();
                    DBContext.CommitTransaction();
                }
                catch (FaultException ex)
                {
                    throw ex;
                }
                catch (Exception)
                {
                    throw new FaultException("Error al registrar los datos del facilitador.");
                }
            }
        }


        async Task IDataInjector.DeleteEnfermera(Ekilibrate.Model.Entity.Administrador.clsEnfermeraBase Data)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.clsEnfermera(scope);
                    await objController.Delete(Data);
                    var DBContext = scope.Resolve<DBTrnContext>();
                    DBContext.CommitTransaction();
                }
                catch (FaultException ex)
                {
                    throw ex;
                }
                catch (Exception)
                {
                    throw new FaultException("Error al registrar los datos del enfermero.");
                }
            }
        }
        #endregion

        #region CorreoElectronico

        async Task<Int32> IDataInjector.UpdateCorreo(IEnumerable<Ekilibrate.Model.Entity.General.clsMensajeCorreo> Data)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.General.clsMensajeCorreo(scope);
                    var result = await objController.Update(Data);
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
                    throw new FaultException("Error al registrar los datos de asistente.");
                }
            }
        }

        async Task IDataInjector.CrearCorreo(Ekilibrate.Model.Entity.General.clsMensajeCorreo Data)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                try
                {
                    var objController = new Ekilibrate.BL.Controller.General.clsMensajeCorreo(scope);
                    var result = await objController.Insert(Data);
                    var DBContext = scope.Resolve<DBTrnContext>();
                    DBContext.CommitTransaction();                    
                }
                catch (FaultException ex)
                {
                    throw ex;
                }
                catch (Exception)
                {
                    throw new FaultException("Error al registrar los datos de asistente.");
                }
            }
        }

        #endregion
    }
}
