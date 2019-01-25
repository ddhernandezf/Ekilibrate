using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using Ekilibrate.Model.Common;

namespace Ekilibrate.Model.Services.Participante
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IDataInjector
    {
        //DIAGNOSTICO
        [OperationContract]
        Task<Int32> CreateDiagnostico(Ekilibrate.Model.Entity.Participante.clsDiagnosticoBase Data);

        [OperationContract]
        Task UpdateDiagnostico(Ekilibrate.Model.Entity.Participante.clsDiagnosticoBase Data);

        [OperationContract]
        Task DeleteDiagnostico(int ID_PARTICIPANTE);

        //ALIMENTACION
        [OperationContract]
        Task<Int32> CreateAlimentacion(Ekilibrate.Model.Entity.Participante.clsAlimentacionBase Data);

        [OperationContract]
        Task UpdateAlimentacion(Ekilibrate.Model.Entity.Participante.clsAlimentacionBase Data);

        [OperationContract]
        Task DeleteAlimentacion(int ID_PARTICIPANTE);

        //RIESGO
        [OperationContract]
        Task<Int32> CreateRiesgo(Ekilibrate.Model.Entity.Participante.clsRiesgoBase Data);

        [OperationContract]
        Task UpdateRiesgo(Ekilibrate.Model.Entity.Participante.clsRiesgoBase Data);

        [OperationContract]
        Task DeleteRiesgo(int ID_PARTICIPANTE);

        //CUIDADO
        [OperationContract]
        Task CreateCuidado(Ekilibrate.Model.Entity.Participante.clsCuidado Data);

        [OperationContract]
        Task UpdateCuidado(Ekilibrate.Model.Entity.Participante.clsCuidado Data);

        [OperationContract]
        Task DeleteCuidado(int ID_PARTICIPANTE);

        //EMOCION
        [OperationContract]
        Task<Int32> CreateEmocion(Ekilibrate.Model.Entity.Participante.clsEmocionBase Data);

        [OperationContract]
        Task UpdateEmocion(Ekilibrate.Model.Entity.Participante.clsEmocionBase Data);

        [OperationContract]
        Task DeleteEmocion(int ID_PARTICIPANTE);

        //TIEMPO
        [OperationContract]
        Task<Int32> CreateTiempo(Ekilibrate.Model.Entity.Participante.clsTiempoBase Data);

        [OperationContract]
        Task UpdateTiempo(Ekilibrate.Model.Entity.Participante.clsTiempoBase Data);

        [OperationContract]
        Task DeleteTiempo(int ID_PARTICIPANTE);

        //COMUNICACION
        [OperationContract]
        Task<Int32> CreateComunicacion(Ekilibrate.Model.Entity.Participante.clsComunicacionBase Data);

        [OperationContract]
        Task UpdateComunicacion(Ekilibrate.Model.Entity.Participante.clsComunicacionBase Data);

        [OperationContract]
        Task DeleteComunicacion(int ID_PARTICIPANTE);

        //COMUNICACIONDOS
        [OperationContract]
        Task<Int32> CreateComunicacionDos(Ekilibrate.Model.Entity.Participante.clsComunicacionDosBase Data);

        [OperationContract]
        Task UpdateComunicacionDos(Ekilibrate.Model.Entity.Participante.clsComunicacionDosBase Data);

        [OperationContract]
        Task DeleteComunicacionDos(int ID_PARTICIPANTE);

        //LIDERAZGO
        [OperationContract]
        Task SelectLiderazgo(Ekilibrate.Model.Entity.Participante.clsTestLiderazgoBase Data);

        //BEBIDAS FRECUENTES
        [OperationContract]
        Task CreateBebidasFrecuentes(Ekilibrate.Model.Entity.Participante.clsBebidasFrecuentesBase Data);

        [OperationContract]
        Task DeleteBebidasFrecuentes(Ekilibrate.Model.Entity.Participante.clsBebidasFrecuentesBase Data);

        //CONDICION PREEXISTENTE
        [OperationContract]
        Task CreateCondicionPreExistente(Ekilibrate.Model.Entity.Participante.clsCondicionPreExistenteBase Data);

        [OperationContract]
        Task DeleteCondicionPreExistente(Ekilibrate.Model.Entity.Participante.clsCondicionPreExistenteBase Data);
        //MEDIDA BEBIDA
        [OperationContract]
        Task CreateMedidaBebida(Ekilibrate.Model.Entity.Participante.clsMedidaBebidaBase Data);

        [OperationContract]
        Task DeleteMedidaBebida(Ekilibrate.Model.Entity.Participante.clsMedidaBebidaBase Data);

        //ENFERMEDAD
        [OperationContract]
        Task CreateEnfermedad(Ekilibrate.Model.Entity.Participante.clsEnfermedadBase Data);

        [OperationContract]
        Task DeleteEnfermedad(Ekilibrate.Model.Entity.Participante.clsEnfermedadBase Data);

        //FRECUENCIA
        [OperationContract]
        Task CreateFrecuencia(Ekilibrate.Model.Entity.Participante.clsFrecuencia Data);

        //ASERTIVA
        [OperationContract]
        Task CreateAsertiva(Ekilibrate.Model.Entity.Participante.clsAsertiva Data);

        //ASERTIVADOS
        [OperationContract]
        Task CreateAsertivaDos(Ekilibrate.Model.Entity.Participante.clsAsertivaDos Data);

        //ANSIEDAD
        [OperationContract]
        Task CreateAnsiedad(Ekilibrate.Model.Entity.Participante.clsAnsiedadBase Data);

        [OperationContract]
        Task DeleteAnsiedad(Ekilibrate.Model.Entity.Participante.clsAnsiedadBase Data);

        #region PasosDia
        [OperationContract]
        Task SincronizarPasosDia(IEnumerable<Ekilibrate.Model.Entity.Participante.clsRegistroPasos> Data);
        
        [OperationContract]
        Task SetPasosDia(Ekilibrate.Model.Entity.Participante.clsPasosDiaApp Data);
        #endregion

        #region AlimentacionDia        
        [OperationContract]
        Task SincronizarAlimentacionDia(IEnumerable<Ekilibrate.Model.Entity.Participante.clsAlimentacionDiaBase> Data);

        #endregion

        #region TestFinanzas

        [OperationContract]
        Task SelectFinanzas(Ekilibrate.Model.Entity.Participante.clsTestFinanzas Data);

        #endregion

        #region TestTemaFinanzas
        [OperationContract]
        Task SelectTemaFinanzas(Ekilibrate.Model.Entity.Participante.clsTestTemaFinanzas Data);

        [OperationContract]
        Task UnSelectTemaFinanzas(Ekilibrate.Model.Entity.Participante.clsTestTemaFinanzas Data);
        #endregion

        [OperationContract]
        Task<string> CrearParticipante(Ekilibrate.Model.Entity.Participante.clsRegistroParticipante Data);

        [OperationContract]
        Task FotoPerfil(int Participante, byte[] file);

    }
}
