using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.Model.Services.Nutricionista
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IDataInjector
    {
        [OperationContract]
        Task CreateDiagnostico(Ekilibrate.Model.Entity.Nutricionista.Diagnostico Data);

        [OperationContract]
        Task CreateSeguimiento(Ekilibrate.Model.Entity.Nutricionista.clsSeguimiento Data);

        [OperationContract]
        Task SincronizarCuadroMetas(IEnumerable<Ekilibrate.Model.Entity.Nutricionista.clsSeguimientoAspectos> Data);

        [OperationContract]
        Task<Int32> CreateDiagnosticoAnamnesis(IEnumerable<Ekilibrate.Model.Entity.Nutricionista.DiagnosticoAnamnesisTiempo> Data);

        [OperationContract]
        Task<Int32> CreateDiagnosticoAlimentos(IEnumerable<Ekilibrate.Model.Entity.Nutricionista.DiagnosticoAlimentos> Data);

        [OperationContract]
        Task UpdateCitaProgramacion(Ekilibrate.Model.Entity.Administrador.clsCitaProgramacion Data);

        [OperationContract]
        Task SincronizarPlan(Ekilibrate.Model.Entity.Nutricionista.clsPlanAlimentacion Data);
    }
}
