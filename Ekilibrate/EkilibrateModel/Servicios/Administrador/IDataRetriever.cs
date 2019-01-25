using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.Model.Services.Administrador
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IDataRetriever
    {
        [OperationContract]
        Task<IEnumerable<Ekilibrate.Model.Entity.Administrador.clsEmpresaContacto>> GetEmpresas(Ekilibrate.Model.Entity.Administrador.clsEmpresaFiltro Filtro);

        [OperationContract]
        Task<IEnumerable<Ekilibrate.Model.Entity.Catalogos.clsTipoProyecto>> GetTipoProyecto();

        [OperationContract]
        Task<IEnumerable<Ekilibrate.Model.Entity.Administrador.clsProyecto>> GetProyectos();

        [OperationContract]
        Task<Ekilibrate.Model.Entity.Administrador.clsProyecto> GetProyecto(int ProyectoId);

        [OperationContract]
        Task<IEnumerable<Ekilibrate.Model.Entity.Administrador.clsProyecto>> GetProyectosEmpresa(int EmpresaId);

        [OperationContract]
        Task<IEnumerable<Ekilibrate.Model.Entity.Administrador.clsSalonBase>> GetSalones(Ekilibrate.Model.Entity.Administrador.clsSalonFiltro Filtro);

        [OperationContract]
        Task<IEnumerable<Ekilibrate.Model.Entity.Administrador.clsProyectoSalon>> GetSalonesProyecto(Ekilibrate.Model.Entity.Administrador.clsProyectoSalonFiltro Filtro);

        [OperationContract]
        Task<IEnumerable<Ekilibrate.Model.Entity.Administrador.clsProyectoContacto>> GetContactosProyecto(Ekilibrate.Model.Entity.Administrador.clsProyectoContactoFiltro Filtro);

        [OperationContract]
        Task<IEnumerable<Ekilibrate.Model.Catalogos.clsTipoUsoSalonBase>> GetTipoUsoSalon(Ekilibrate.Model.Catalogos.clsTipoUsoSalonFiltro Filtro);


        [OperationContract]
        Task<IEnumerable<Ekilibrate.Model.Entity.Administrador.clsProyectoArea>> GetAreasProyecto(int ProyectoId);

        [OperationContract]
        Task<IEnumerable<Ekilibrate.Model.Entity.Administrador.clsTallerVista>> GetTaller(Ekilibrate.Model.Entity.Administrador.clsTallerFiltro Filtro);


        [OperationContract]
        Task<IEnumerable<Ekilibrate.Model.Entity.Catalogos.clsAreaBase>> GetArea(Ekilibrate.Model.Entity.Catalogos.clsAreaFiltro Filtro);

        [OperationContract]
        Task<IEnumerable<Ekilibrate.Model.Entity.Catalogos.clsTallerBase>> GetCatalogoTaller(Ekilibrate.Model.Entity.Catalogos.clsTallerFiltro Filtro);

        [OperationContract]
        Task<IEnumerable<Ekilibrate.Model.Entity.Catalogos.clsAseguradoraBase>> GetCatalogoAseguradora();


        [OperationContract]
        Task<IEnumerable<Ekilibrate.Model.Entity.Administrador.clsGrupoBase>> GetGrupo(Ekilibrate.Model.Entity.Administrador.clsGrupoFiltro Filtro);

        [OperationContract]
        Task<IEnumerable<Ekilibrate.Model.Entity.Administrador.clsColaboradorBase>> GetColaborador(Ekilibrate.Model.Entity.Administrador.clsColaboradorFiltro Filtro);

        [OperationContract]
        Task<IEnumerable<Ekilibrate.Model.Entity.Administrador.clsContactoBase>> GetContacto(Ekilibrate.Model.Entity.Administrador.clsContactoFiltro Filtro);

        [OperationContract]
        Task<IEnumerable<Ekilibrate.Model.Administrador.clsClienteRolBase>> GetClienteRol(Ekilibrate.Model.Administrador.clsClienteRolFiltro Filtro);

        [OperationContract]
        Task<IEnumerable<Ekilibrate.Model.Entity.Catalogos.clsGiroEmpresaBase>> GetGiroEmpresa();

        [OperationContract]
        Task<IEnumerable<Ekilibrate.Model.Entity.Catalogos.clsRolNutricionista>> GetRolNutricionista();

        [OperationContract]
        Task<IEnumerable<Ekilibrate.Model.Entity.Administrador.clsNutricionistaBase>> GetNutricionista(Ekilibrate.Model.Entity.Administrador.clsNutricionistaFiltro Filtro);

        [OperationContract]
        Task<IEnumerable<Ekilibrate.Model.Entity.Administrador.clsFacilitador>> GetFacilitador(Ekilibrate.Model.Entity.Administrador.clsFacilitadorFiltro Filtro);

        [OperationContract]
        Task<IEnumerable<Ekilibrate.Model.Entity.Administrador.clsAsistenteBase>> GetAsistente(Ekilibrate.Model.Entity.Administrador.clsAsistenteFiltro Filtro);

        [OperationContract]
        Task<IEnumerable<Ekilibrate.Model.Entity.Administrador.clsEnfermeraBase>> GetEnfermera(Ekilibrate.Model.Entity.Administrador.clsEnfermeraFiltro Filtro);

        [OperationContract]
        Task<IEnumerable<Ekilibrate.Model.Entity.General.clsMensajeCorreo>> GetCorreos();

        [OperationContract]
        Task<IEnumerable<Ekilibrate.Model.Entity.General.CorreoElectronico>> GetInfoCorreo();

    }
}
