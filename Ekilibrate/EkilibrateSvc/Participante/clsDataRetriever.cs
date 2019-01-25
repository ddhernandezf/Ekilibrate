using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Ekilibrate.Model.Services.Participante;
using Ekilibrate.Model.Entity.Participante;
using Ekilibrate.Services.Abstract;
using System.Threading.Tasks;
using Dapper;
using System.Collections;

namespace Ekilibrate.Services.Participante
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single,
                     ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class clsDataRetriever : clsServiceBase, IDataRetriever
    {
        //HOME
        async Task<Ekilibrate.Model.Entity.Participante.clsAvanceCuestionario> IDataRetriever.GetDashboard(int ParticipanteId)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                var objDataRetriever = new Ekilibrate.BL.DataRetriever.Participante.clsParticipante(scope);
                return await objDataRetriever.GetParticipanteAvance(ParticipanteId);
            }
        }

        //DIAGNOSTICO
        async Task<Ekilibrate.Model.Entity.Participante.clsDiagnosticoBase> IDataRetriever.GetDiagnosticos(Ekilibrate.Model.Entity.Participante.clsDiagnosticoFiltro Filtro)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                var objDataRetriever = new Ekilibrate.BL.DataRetriever.Participante.clsDiagnostico(scope);
                return await objDataRetriever.GetDiagnosticos(Filtro);
            }
        }
        //ALIMENTACION
        async Task<Ekilibrate.Model.Entity.Participante.clsAlimentacionBase> IDataRetriever.GetAlimentaciones(Ekilibrate.Model.Entity.Participante.clsAlimentacionFiltro Filtro)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                var objDataRetriever = new Ekilibrate.BL.DataRetriever.Participante.clsAlimentacion(scope);
                return await objDataRetriever.GetAlimentaciones(Filtro);
            }
        }
        //RIESGO
        async Task<Ekilibrate.Model.Entity.Participante.clsRiesgoBase> IDataRetriever.GetRiesgos(int Participante)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                var objDataRetriever = new Ekilibrate.BL.DataRetriever.Participante.clsRiesgo(scope);
                return await objDataRetriever.GetRiesgos(Participante);
            }
        }
        //BEBIDAS FRECUENTES
        async Task<IEnumerable<Ekilibrate.Model.Entity.Participante.clsBebidaBase>> IDataRetriever.GetBebidas(Ekilibrate.Model.Entity.Participante.clsBebidasFrecuentesFiltro Filtro)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                var objDataRetriever = new Ekilibrate.BL.DataRetriever.Participante.clsBebidasFrecuentes(scope);
                return await objDataRetriever.GetBebidas(Filtro);
            }
        }

        //CONDICION PRE_EXISTENTE
        async Task<IEnumerable<Ekilibrate.Model.Entity.Participante.clsCondicionPreExistente>> IDataRetriever.GetPreExistentes(Ekilibrate.Model.Entity.Participante.clsCondicionPreExistenteFiltro Filtro)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                var objDataRetriever = new Ekilibrate.BL.DataRetriever.Participante.clsCondicionPreExistente(scope);
                return await objDataRetriever.GetPreExistentes(Filtro);
            }
        }
        //ENFERMEDAD
        async Task<IEnumerable<Ekilibrate.Model.Entity.Participante.clsEnfermedad>> IDataRetriever.GetEnfermedad(int Participante)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                var objDataRetriever = new Ekilibrate.BL.DataRetriever.Participante.clsEnfermedad(scope);
                return await objDataRetriever.GetEnfermedad(Participante);
            }
        }
        //MEDIDA BEBIDA
        async Task<IEnumerable<Ekilibrate.Model.Entity.Participante.clsMedidaBebida>> IDataRetriever.GetMedidas(Ekilibrate.Model.Entity.Participante.clsMedidaBebidaFiltro Filtro)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                var objDataRetriever = new Ekilibrate.BL.DataRetriever.Participante.clsMedidaBebida(scope);
                return await objDataRetriever.GetMedidas(Filtro);
            }
        }
        //PARTICIPANTE
        async Task<IEnumerable<Model.Entity.Participante.clsParticipante>> IDataRetriever.GetParticipantes(clsParticipanteFiltro Filtro)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                var objDataRetriever = new Ekilibrate.BL.DataRetriever.Participante.clsParticipante(scope);
                return await objDataRetriever.GetParticipantes(Filtro);
            }
        }
        //CUIDADO
        async Task<Ekilibrate.Model.Entity.Participante.clsCuidado> IDataRetriever.GetCuidados(int Participante)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                var objDataRetriever = new Ekilibrate.BL.DataRetriever.Participante.clsCuidado(scope);
                return await objDataRetriever.GetCuidados(Participante);
            }
        }

        async Task<IEnumerable<Ekilibrate.Model.Entity.Participante.clsTipoEjercicio>> IDataRetriever.GetTipoEjercicio()
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                var objDataRetriever = new Ekilibrate.BL.DataRetriever.Participante.clsTipoEjercicio(scope);
                return await objDataRetriever.GetTipoEjercicio();
            }
        }
        //EMOCION
        async Task<IEnumerable<Ekilibrate.Model.Entity.Participante.clsEmocion>> IDataRetriever.GetEmociones(int Participante)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                var objDataRetriever = new Ekilibrate.BL.DataRetriever.Participante.clsEmocion(scope);
                return await objDataRetriever.GetEmociones(Participante);
            }
        }
        //ANSIEDAD
        async Task<IEnumerable<Ekilibrate.Model.Entity.Participante.clsAnsiedad>> IDataRetriever.GetAnsiedades(int Participante)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                var objDataRetriever = new Ekilibrate.BL.DataRetriever.Participante.clsAnsiedad(scope);
                return await objDataRetriever.GetAnsiedades(Participante);
            }
        }
 
        //TIEMPO
        async Task<Ekilibrate.Model.Entity.Participante.clsTiempoBase> IDataRetriever.GetTiempos(Ekilibrate.Model.Entity.Participante.clsTiempoFiltro Filtro)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                var objDataRetriever = new Ekilibrate.BL.DataRetriever.Participante.clsTiempo(scope);
                return await objDataRetriever.GetTiempos(Filtro);
            }
        }
        //FRECUENCIA
        async Task<IEnumerable<Ekilibrate.Model.Entity.Participante.clsFrecuencia>> IDataRetriever.GetFrecuencias(Ekilibrate.Model.Entity.Participante.clsFrecuenciaFiltro Filtro)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                var objDataRetriever = new Ekilibrate.BL.DataRetriever.Participante.clsFrecuencia(scope);
                return await objDataRetriever.GetFrecuencias(Filtro);
            }
        }
        //COMUNICACION
        async Task<Ekilibrate.Model.Entity.Participante.clsComunicacionBase> IDataRetriever.GetComunicaciones(Ekilibrate.Model.Entity.Participante.clsComunicacionFiltro Filtro)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                var objDataRetriever = new Ekilibrate.BL.DataRetriever.Participante.clsComunicacion(scope);
                return await objDataRetriever.GetComunicaciones(Filtro);
            }
        }
        //ASERTIVA
        async Task<IEnumerable<Ekilibrate.Model.Entity.Participante.clsAsertiva>> IDataRetriever.GetAsertivas(Ekilibrate.Model.Entity.Participante.clsAsertivaFiltro Filtro)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                var objDataRetriever = new Ekilibrate.BL.DataRetriever.Participante.clsAsertiva(scope);
                return await objDataRetriever.GetAsertivas(Filtro);
            }
        }

        //COMUNICACIONDOS
        async Task<Ekilibrate.Model.Entity.Participante.clsComunicacionDosBase> IDataRetriever.GetComunicacionesDos(Ekilibrate.Model.Entity.Participante.clsComunicacionDosFiltro Filtro)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                var objDataRetriever = new Ekilibrate.BL.DataRetriever.Participante.clsComunicacionDos(scope);
                return await objDataRetriever.GetComunicacionesDos(Filtro);
            }
        }
        //ASERTIVADOS
        async Task<IEnumerable<Ekilibrate.Model.Entity.Participante.clsAsertivaDos>> IDataRetriever.GetAsertivasDos(Ekilibrate.Model.Entity.Participante.clsAsertivaDosFiltro Filtro)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                var objDataRetriever = new Ekilibrate.BL.DataRetriever.Participante.clsAsertivaDos(scope);
                return await objDataRetriever.GetAsertivasDos(Filtro);
            }
        }

        //LIDERAZGO
        async Task<Ekilibrate.Model.Entity.Participante.clsTestLiderazgoBase> IDataRetriever.GetLiderazgos(Ekilibrate.Model.Entity.Participante.clsLiderazgoFiltro Filtro)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                var objDataRetriever = new Ekilibrate.BL.DataRetriever.Participante.clsLiderazgo(scope);
                return await objDataRetriever.GetLiderazgos(Filtro);
            }
        }
        //PREGUNTALIDERAZGO
        async Task<IEnumerable<Ekilibrate.Model.Entity.Participante.clsPreguntaLiderazgo>> IDataRetriever.GetPreguntasLiderazgo(int Participante)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                var objDataRetriever = new Ekilibrate.BL.DataRetriever.Participante.clsPreguntaLiderazgo(scope);
                return await objDataRetriever.GetPreguntasLiderazgo(Participante);
            }
        }

        //PASOSDIA
        async Task<IEnumerable<Ekilibrate.Model.Entity.Participante.clsRegistroPasos>> IDataRetriever.GetPasosDia(int Participante)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                var objDataRetriever = new Ekilibrate.BL.DataRetriever.Participante.clsPasosDia(scope);
                return await objDataRetriever.GetPasosDia(Participante);
            }
        }

        /// <summary>
        /// Devuelve el Objeto que se enviará como un response a una solicitud de una App para consultar los pasos del compa del participante
        /// </summary>
        /// <param name="Filtro"></param>
        /// <returns></returns>
        async Task<Ekilibrate.Model.Entity.Participante.clsPasosApp> IDataRetriever.GetPasosDiaApp(int ParticipanteId)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                var objDataRetriever = new Ekilibrate.BL.DataRetriever.Participante.clsPasosDia(scope);
                return await objDataRetriever.GetPasosDiaApp(ParticipanteId);
            }
        }

        /// <summary>
        /// Devuelve el Objeto que se enviará como un response a una solicitud de una App para consultar los pasos del compa del participante
        /// </summary>
        /// <param name="Filtro"></param>
        /// <returns></returns>
        async Task<Ekilibrate.Model.Entity.Participante.clsPasosApp> IDataRetriever.GetPasosDiaCompaApp(int ParticipanteId)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                var objCompa = new Ekilibrate.BL.DataRetriever.Participante.clsParticipante(scope);
                Model.Entity.Participante.clsParticipante Compa = await objCompa.GetCompa(ParticipanteId);
                
                var objDataRetriever = new Ekilibrate.BL.DataRetriever.Participante.clsPasosDia(scope);
                return await objDataRetriever.GetPasosDiaApp(Compa.Id);
            }
        }

        //ALIMENTACIONDIA
        async Task<IEnumerable<Ekilibrate.Model.Entity.Participante.clsAlimentacionDiaBase>> IDataRetriever.GetAlimentacionDia(Ekilibrate.Model.Entity.Participante.clsAlimentacionDiaFiltro Filtro)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                var objDataRetriever = new Ekilibrate.BL.DataRetriever.Participante.clsAlimentacionDia(scope);
                return await objDataRetriever.GetAlimentacionDia(Filtro);
            }
        }

        async Task<Ekilibrate.Model.Entity.Participante.clsAlimentacionApp> IDataRetriever.GetAlimentacionDiaApp(Ekilibrate.Model.Entity.Participante.clsAlimentacionDiaFiltro Filtro)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                var objDataRetriever = new Ekilibrate.BL.DataRetriever.Participante.clsAlimentacionDia(scope);
                return await objDataRetriever.GetAlimentacionDiaApp(Filtro);
            }
        }

        //Test de Finanzas
        async Task<IEnumerable<Ekilibrate.Model.Entity.Participante.clsPreguntaFinanzas>> IDataRetriever.GetTestFinanzas(int Participante)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                var objDataRetriever = new Ekilibrate.BL.DataRetriever.Participante.clsTestFinanzas(scope);
                return await objDataRetriever.GetPreguntas(Participante);
            }
        }

        //Test de Temas de interés de Finanzas
        async Task<IEnumerable<Ekilibrate.Model.Entity.Participante.clsTestTemaFinanzas>> IDataRetriever.GetTestTemasFinanzas(int Participante)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                var objDataRetriever = new Ekilibrate.BL.DataRetriever.Participante.clsTestTemaFinanzas(scope);
                return await objDataRetriever.GetPreguntas(Participante);
            }
        }

        async Task<Ekilibrate.Model.Entity.Participante.clsExpedienteCrecimientoPersonal> IDataRetriever.GetExpedienteCrecimientoPersonal(int Participante)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                var objDataRetriever = new Ekilibrate.BL.DataRetriever.Participante.clsExpediente(scope);
                return await objDataRetriever.GetCrecimientoPersonal(Participante);
            }
        }

        async Task<Ekilibrate.Model.Entity.Participante.clsExpedienteEstadoSalud> IDataRetriever.GetExpedienteEstadoSalud(Ekilibrate.Model.Entity.Participante.clsExpedienteFiltro Filtro)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                var objDataRetriever = new Ekilibrate.BL.DataRetriever.Participante.clsExpediente(scope);
                return await objDataRetriever.GetEstadoSalud(Filtro);
            }
        }

        async Task<Ekilibrate.Model.Entity.Participante.clsExpedienteManejoEmociones> IDataRetriever.GetExpedienteManejoEmociones(clsExpedienteFiltro Filtro)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                var objDataRetriever = new Ekilibrate.BL.DataRetriever.Participante.clsExpediente(scope);
                return await objDataRetriever.GetManejoEmociones(Filtro);
            }
        }

        async Task<Ekilibrate.Model.Entity.Participante.clsExpedienteRelacionesInterpersonales> IDataRetriever.GetExpedienteRelacionesInterpersonales(Ekilibrate.Model.Entity.Participante.clsExpedienteFiltro Filtro)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                var objDataRetriever = new Ekilibrate.BL.DataRetriever.Participante.clsExpediente(scope);
                return await objDataRetriever.GetRelacionesInterpersonales(Filtro);
            }
        }

        async Task<Ekilibrate.Model.Entity.Participante.ResumenExpediente> IDataRetriever.GetResumenExpediente(int ParticipanteId)
        {
            using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope("a"))
            {
                var objDataRetriever = new Ekilibrate.BL.DataRetriever.Participante.clsExpediente(scope);
                return await objDataRetriever.GetResumenExpediente(ParticipanteId);
            }
        }
    }
}
