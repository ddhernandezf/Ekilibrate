using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using Ekilibrate.Model.Common;

namespace Ekilibrate.Model.Services.Administrador
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IDataInjector
    {
        #region Empresa
        [OperationContract]
        Task<Int32> CreateEmpresa(Ekilibrate.Model.Entity.Administrador.clsEmpresaBase Data);

        [OperationContract]
        Task UpdateEmpresa(Ekilibrate.Model.Entity.Administrador.clsEmpresaBase Data);

        [OperationContract]
        Task DeleteEmpresa(int Id);
        #endregion

        #region Salon
        [OperationContract]
        Task<Int32> CreateSalon(Ekilibrate.Model.Entity.Administrador.clsSalonBase Data);

        [OperationContract]
        Task UpdateSalon(Ekilibrate.Model.Entity.Administrador.clsSalonBase Data);

        [OperationContract]
        Task DeleteSalon(int Id);
        #endregion

        #region Proyecto
        [OperationContract]
        Task<Int32> CreateProyecto(Ekilibrate.Model.Entity.Administrador.clsProyecto Data);

        [OperationContract]
        Task UpdateProyecto(Ekilibrate.Model.Entity.Administrador.clsProyecto Data);


        [OperationContract]
        Task DeleteProyecto(int Id);

        [OperationContract]
        Task EnviarNotificacion(int ProyectoId);

        [OperationContract]
        Task FinalizarCarga(int ProyectoId);

        [OperationContract]
        Task IniciarProyecto(int ProyectoId);

        [OperationContract]
        Task PruebaCorreo(int ProyectoId);

        [OperationContract]
        Task AsignarNutricionistas(int ProyectoId);

        [OperationContract]
        Task ProgramarCitas(int ProyectoId);

        [OperationContract]
        Task SendNotifications();

        #endregion

        #region Taller
        [OperationContract]
        Task<Int32> CreateTaller(Ekilibrate.Model.Entity.Administrador.clsTallerVista Data);

        [OperationContract]
        Task UpdateTaller(Ekilibrate.Model.Entity.Administrador.clsTallerVista Data);

        [OperationContract]
        Task DeleteTaller(Ekilibrate.Model.Entity.Administrador.clsTallerVista Data);
        #endregion

        #region TipoUsoSalon
        [OperationContract]
        Task<Int32> CreateTipoUsoSalon(Ekilibrate.Model.Catalogos.clsTipoUsoSalonBase Data);

        [OperationContract]
        Task UpdateTipoUsoSalon(Ekilibrate.Model.Catalogos.clsTipoUsoSalonBase Data);

        [OperationContract]
        Task DeleteTipoUsoSalon(int Id);

        #endregion

        #region ProyectoSalon
        [OperationContract]
        Task AddSalonProyecto(Ekilibrate.Model.Entity.Administrador.clsProyectoSalon Data);


        [OperationContract]
        Task DeleteSalonProyecto(Ekilibrate.Model.Entity.Administrador.clsProyectoSalon Data);
        #endregion

        #region ProyectoContacto
        [OperationContract]
        Task AddContactoProyecto(Ekilibrate.Model.Entity.Administrador.clsProyectoContacto Data);


        [OperationContract]
        Task DeleteContactoProyecto(Ekilibrate.Model.Entity.Administrador.clsProyectoContacto Data);
        #endregion

        #region ProyectoArea
        [OperationContract]
        Task AddAreaProyecto(Ekilibrate.Model.Entity.Administrador.clsProyectoArea Data);


        [OperationContract]
        Task DeleteAreaProyecto(Ekilibrate.Model.Entity.Administrador.clsProyectoArea Data);
        #endregion

        #region Colaborador
        [OperationContract]
        Task<Int32> CreateColaborador(Ekilibrate.Model.Entity.Administrador.clsColaboradorBase Data);

        [OperationContract]
        Task UpdateColaborador(Ekilibrate.Model.Entity.Administrador.clsColaboradorBase Data);

        [OperationContract]
        Task DeleteColaborador(int Id);
        #endregion

        #region Contacto
        [OperationContract]
        Task<Int32> CreateContacto(Ekilibrate.Model.Entity.Administrador.clsContactoBase Data);

        [OperationContract]
        Task UpdateContacto(Ekilibrate.Model.Entity.Administrador.clsContactoBase Data);

        [OperationContract]
        Task DeleteContacto(int Id);
        #endregion

        #region ClienteRol
        [OperationContract]
        Task<Int32> CreateClienteRol(Ekilibrate.Model.Administrador.clsClienteRolBase Data);

        [OperationContract]
        Task UpdateClienteRol(Ekilibrate.Model.Administrador.clsClienteRolBase Data);

        [OperationContract]
        Task DeleteClienteRol(int Id);
        #endregion

        #region ColaboradorProyecto
        [OperationContract]
        Task CreateNutricionista(Ekilibrate.Model.Entity.Administrador.clsNutricionistaBase Data);

        [OperationContract]
        Task CreateFacilitador(Ekilibrate.Model.Entity.Administrador.clsFacilitadorBase Data);

        [OperationContract]
        Task CreateAsistente(Ekilibrate.Model.Entity.Administrador.clsAsistenteBase Data);


        [OperationContract]
        Task CreateEnfermera(Ekilibrate.Model.Entity.Administrador.clsEnfermeraBase Data);


        [OperationContract]
        Task DeleteNutricionista(Ekilibrate.Model.Entity.Administrador.clsNutricionistaBase Data);

        [OperationContract]
        Task DeleteFacilitador(Ekilibrate.Model.Entity.Administrador.clsFacilitadorBase Data);

        [OperationContract]
        Task DeleteAsistente(Ekilibrate.Model.Entity.Administrador.clsAsistenteBase Data);


        [OperationContract]
        Task DeleteEnfermera(Ekilibrate.Model.Entity.Administrador.clsEnfermeraBase Data);
        #endregion

        #region CorreoElectronico

        [OperationContract]
        Task<Int32> UpdateCorreo(IEnumerable<Ekilibrate.Model.Entity.General.clsMensajeCorreo> Data);

        [OperationContract]
        Task CrearCorreo(Ekilibrate.Model.Entity.General.clsMensajeCorreo Data);

        #endregion

    }
}
