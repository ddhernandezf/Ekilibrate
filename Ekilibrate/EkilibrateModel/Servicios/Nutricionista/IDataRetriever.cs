using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using Ekilibrate.Model.Entity.Proyecto;
using Ekilibrate.Model.Services.Nutricionista;

namespace Ekilibrate.Model.Services.Nutricionista
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IDataRetriever
    {
        [OperationContract]
        Task<IEnumerable<Model.Entity.Proyecto.clsCita>> GetCitas(Model.Entity.Proyecto.clsCitaFiltro Filtro);

        [OperationContract]
        Task<IEnumerable<Model.Entity.Proyecto.clsCita>> GetCitasDiagnostico(Model.Entity.Proyecto.clsCitaFiltro Filtro);

        [OperationContract]
        Task<IEnumerable<Model.Entity.Proyecto.clsCita>> GetCitasFin(Model.Entity.Proyecto.clsCitaFiltro Filtro);

        [OperationContract]
        Task<Model.Entity.Nutricionista.Diagnostico> GetDiagnostico(int ParticipanteId, int CitaId);

        [OperationContract]
        Task<IEnumerable<Model.Entity.Nutricionista.DiagnosticoAlimentos>> GetAlimentos(int ParticipanteId, int CitaId);

        [OperationContract]
        Task<Model.Entity.Nutricionista.clsSeguimiento> GetSeguimiento(int CitaId);

        [OperationContract]
        Task<Model.Entity.Nutricionista.clsSeguimiento> GetSeguimientoActual(int ParticipanteId);

        [OperationContract]
        Task<IEnumerable<Model.Entity.Nutricionista.clsMetaPasoBase>> GetMetaPasos(int ParticipanteId);

        [OperationContract]
        Task<IEnumerable<Model.Entity.Nutricionista.clsCalificacionTaller>> GetCalificacionTaller(int ParticipanteId, int TallerId);

        [OperationContract]
        Task<IEnumerable<Model.Entity.Nutricionista.clsSeguimientoAspectos>> GetSeguimientoAspectos(int ParticipanteId, int CitaId);

        [OperationContract]
        Task<IEnumerable<Model.Entity.Nutricionista.DiagnosticoAnamnesisTiempo>> GetAnamnesis(int NutricionistaId, int ParticipanteId, int CitaId);

        [OperationContract]
        Task<Model.Entity.Nutricionista.clsPlanAlimentacion> GetPlanAlimentacion(int CitaId, int ParticipanteId);
    }
}
