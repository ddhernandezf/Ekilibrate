using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.Model.Services.Participante
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IDataRetriever
    {
        //HOME
        [OperationContract]
        Task<Ekilibrate.Model.Entity.Participante.clsAvanceCuestionario> GetDashboard(int ParticipanteId);

        //DIAGNOSTICO
        [OperationContract]
        Task<Ekilibrate.Model.Entity.Participante.clsDiagnosticoBase> GetDiagnosticos(Ekilibrate.Model.Entity.Participante.clsDiagnosticoFiltro Filtro);
        //ALIMENTACION
        [OperationContract]
        Task<Ekilibrate.Model.Entity.Participante.clsAlimentacionBase> GetAlimentaciones(Ekilibrate.Model.Entity.Participante.clsAlimentacionFiltro Filtro);
        //RIESGO
        [OperationContract]
        Task<Ekilibrate.Model.Entity.Participante.clsRiesgoBase> GetRiesgos(int Participante);
        //BEBIDAS
        [OperationContract]
        Task<IEnumerable<Ekilibrate.Model.Entity.Participante.clsBebidaBase>> GetBebidas(Ekilibrate.Model.Entity.Participante.clsBebidasFrecuentesFiltro Filtro);
        //CONDICION
        [OperationContract]
        Task<IEnumerable<Ekilibrate.Model.Entity.Participante.clsCondicionPreExistente>> GetPreExistentes(Ekilibrate.Model.Entity.Participante.clsCondicionPreExistenteFiltro Filtro);
        //ENFERMEDAD
        [OperationContract]
        Task<IEnumerable<Ekilibrate.Model.Entity.Participante.clsEnfermedad>> GetEnfermedad(int Participante);
        //MEDIDA
        [OperationContract]
        Task<IEnumerable<Ekilibrate.Model.Entity.Participante.clsMedidaBebida>> GetMedidas(Ekilibrate.Model.Entity.Participante.clsMedidaBebidaFiltro Filtro);
        //CUIDADO
        [OperationContract]
        Task<Ekilibrate.Model.Entity.Participante.clsCuidado> GetCuidados(int Participante);

        [OperationContract]
        Task<IEnumerable<Ekilibrate.Model.Entity.Participante.clsTipoEjercicio>> GetTipoEjercicio();
        //EMOCION
        [OperationContract]
        Task<IEnumerable<Ekilibrate.Model.Entity.Participante.clsEmocion>> GetEmociones(int Participante);
        //RESP_ANSIEDAD
        [OperationContract]
        Task<IEnumerable<Ekilibrate.Model.Entity.Participante.clsAnsiedad>> GetAnsiedades(int Partcipante);
        //TIEMPO
        [OperationContract]
        Task<Ekilibrate.Model.Entity.Participante.clsTiempoBase> GetTiempos(Ekilibrate.Model.Entity.Participante.clsTiempoFiltro Filtro);
        //FRECUENCIA
        [OperationContract]
        Task<IEnumerable<Ekilibrate.Model.Entity.Participante.clsFrecuencia>> GetFrecuencias(Ekilibrate.Model.Entity.Participante.clsFrecuenciaFiltro Filtro);
        //COMUNICACION
        [OperationContract]
        Task<Ekilibrate.Model.Entity.Participante.clsComunicacionBase> GetComunicaciones(Ekilibrate.Model.Entity.Participante.clsComunicacionFiltro Filtro);
        //ASERTIVA
        [OperationContract]
        Task<IEnumerable<Ekilibrate.Model.Entity.Participante.clsAsertiva>> GetAsertivas(Ekilibrate.Model.Entity.Participante.clsAsertivaFiltro Filtro);
        //COMUNICACIONDOS
        [OperationContract]
        Task<Ekilibrate.Model.Entity.Participante.clsComunicacionDosBase> GetComunicacionesDos(Ekilibrate.Model.Entity.Participante.clsComunicacionDosFiltro Filtro);
        //ASERTIVADOS
        [OperationContract]
        Task<IEnumerable<Ekilibrate.Model.Entity.Participante.clsAsertivaDos>> GetAsertivasDos(Ekilibrate.Model.Entity.Participante.clsAsertivaDosFiltro Filtro);
        //LIDERAZGO
        [OperationContract]
        Task<Ekilibrate.Model.Entity.Participante.clsTestLiderazgoBase> GetLiderazgos(Ekilibrate.Model.Entity.Participante.clsLiderazgoFiltro Filtro);
        //PREGUNTALIDERAZGO
        [OperationContract]
        Task<IEnumerable<Ekilibrate.Model.Entity.Participante.clsPreguntaLiderazgo>> GetPreguntasLiderazgo(int Participante);
        //Get Participantes
        [OperationContract]
        Task<IEnumerable<Model.Entity.Participante.clsParticipante>> GetParticipantes(Model.Entity.Participante.clsParticipanteFiltro Filtro);

        //PASOSDIA
        [OperationContract]
        Task<IEnumerable<Model.Entity.Participante.clsRegistroPasos>> GetPasosDia(int Participante);
        [OperationContract]
        Task<Ekilibrate.Model.Entity.Participante.clsPasosApp> GetPasosDiaApp(int ParticipanteId);
        [OperationContract]
        Task<Ekilibrate.Model.Entity.Participante.clsPasosApp> GetPasosDiaCompaApp(int ParticipanteId);

        //ALIMENTACIONDIA
        [OperationContract]
        Task<IEnumerable<Model.Entity.Participante.clsAlimentacionDiaBase>> GetAlimentacionDia(Model.Entity.Participante.clsAlimentacionDiaFiltro Filtro);

        [OperationContract]
        Task<Model.Entity.Participante.clsAlimentacionApp> GetAlimentacionDiaApp(Model.Entity.Participante.clsAlimentacionDiaFiltro Filtro);

        //Test de Finanzas
        [OperationContract]
        Task<IEnumerable<Model.Entity.Participante.clsPreguntaFinanzas>> GetTestFinanzas(int Participante);

        //Test de Temas de interés de Finanzas
        [OperationContract]
        Task<IEnumerable<Model.Entity.Participante.clsTestTemaFinanzas>> GetTestTemasFinanzas(int Participante);


        [OperationContract]
        Task<Model.Entity.Participante.clsExpedienteCrecimientoPersonal> GetExpedienteCrecimientoPersonal(int Participante);


        [OperationContract]
        Task<Model.Entity.Participante.clsExpedienteEstadoSalud> GetExpedienteEstadoSalud(Ekilibrate.Model.Entity.Participante.clsExpedienteFiltro Filtro);

        [OperationContract]
        Task<Model.Entity.Participante.clsExpedienteManejoEmociones> GetExpedienteManejoEmociones(Ekilibrate.Model.Entity.Participante.clsExpedienteFiltro Filtro);


        [OperationContract]
        Task<Model.Entity.Participante.clsExpedienteRelacionesInterpersonales> GetExpedienteRelacionesInterpersonales(Ekilibrate.Model.Entity.Participante.clsExpedienteFiltro Filtro);

        [OperationContract]
        Task<Model.Entity.Participante.ResumenExpediente> GetResumenExpediente(int ParticipanteId);


        
    }
}
