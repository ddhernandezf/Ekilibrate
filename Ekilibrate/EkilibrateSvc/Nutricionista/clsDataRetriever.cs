using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Ekilibrate.Model.Entity.Proyecto;
using Ekilibrate.Model.Services.Nutricionista;
using Ekilibrate.Services.Abstract;
using System.Threading.Tasks;
using Dapper;

namespace Ekilibrate.Services.Nutricionista
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single,
                     ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class clsDataRetriever : clsServiceBase, IDataRetriever
    {
        async Task<IEnumerable<Model.Entity.Proyecto.clsCita>> IDataRetriever.GetCitas(clsCitaFiltro Filtro)
        {

            try
            {
                using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                {
                    var objDataRetriever = new Ekilibrate.BL.DataRetriever.Nutricionista.clsCita(scope);
                    return await objDataRetriever.GetCitas(Filtro);
                }
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        async Task<IEnumerable<Model.Entity.Proyecto.clsCita>> IDataRetriever.GetCitasDiagnostico(clsCitaFiltro Filtro)
        {

            try
            {
                using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                {
                    var objDataRetriever = new Ekilibrate.BL.DataRetriever.Nutricionista.clsCita(scope);
                    return await objDataRetriever.GetCitasDiagnostico(Filtro);
                }
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        async Task<IEnumerable<Model.Entity.Proyecto.clsCita>> IDataRetriever.GetCitasFin(clsCitaFiltro Filtro)
        {

            try
            {
                using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                {
                    var objDataRetriever = new Ekilibrate.BL.DataRetriever.Nutricionista.clsCita(scope);
                    return await objDataRetriever.GetCitasFin(Filtro);
                }
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public async Task<Model.Entity.Nutricionista.Diagnostico> GetDiagnostico(int ParticipanteId, int CitaId)
        {
            try
            {
                using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                {
                    var objDataRetriever = new Ekilibrate.BL.DataRetriever.Nutricionista.clsDiagnosticoAlimentos(scope);
                    return await objDataRetriever.GetDiagnostico(ParticipanteId, CitaId);
                }
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public async Task<IEnumerable<Model.Entity.Nutricionista.DiagnosticoAlimentos>> GetAlimentos(int ParticipanteId, int CitaId)
        {
            try
            {
                using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                {
                    var objDataRetriever = new Ekilibrate.BL.DataRetriever.Nutricionista.clsDiagnosticoAlimentos(scope);
                    return await objDataRetriever.GetAlimentos(ParticipanteId, CitaId);
                }
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        async Task<IEnumerable<Model.Entity.Nutricionista.clsMetaPasoBase>> IDataRetriever.GetMetaPasos(int ParticipanteId)
        {
            try
            {
                using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                {
                    var objDataRetriever = new Ekilibrate.BL.DataRetriever.Nutricionista.clsMetaPasos(scope);
                    return await objDataRetriever.Get(ParticipanteId);
                }
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }


        async Task<IEnumerable<Model.Entity.Nutricionista.clsCalificacionTaller>> IDataRetriever.GetCalificacionTaller(int ParticipanteId, int TallerId)
        {
            try
            {
                using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                {
                    var objDataRetriever = new Ekilibrate.BL.DataRetriever.Nutricionista.clsCalificacionTaller(scope);
                    return await objDataRetriever.Get(ParticipanteId, TallerId);
                }
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }
        async Task<Model.Entity.Nutricionista.clsSeguimiento> IDataRetriever.GetSeguimiento(int CitaId)
        {

            try
            {
                using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                {
                    var objDataRetriever = new Ekilibrate.BL.DataRetriever.Nutricionista.clsSeguimiento(scope);
                    var res = await objDataRetriever.GetSeguimiento(CitaId);
                    if (res == null)
                    {
                        var objCita = new Ekilibrate.BL.DataRetriever.Nutricionista.clsCita(scope);
                        var cita = await objCita.GetCita(CitaId);
                        return new Ekilibrate.Model.Entity.Nutricionista.clsSeguimiento { Nuevo = true, CitaId = CitaId, ParticipanteId = cita.ParticipanteId, NutricionistaId = cita.NutricionistaId, No = -1 };
                    }
                    else
                        return res;
                }
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        async Task<Model.Entity.Nutricionista.clsSeguimiento> IDataRetriever.GetSeguimientoActual(int ParticipanteId)
        {

            try
            {
                using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                {
                    var objDataRetriever = new Ekilibrate.BL.DataRetriever.Nutricionista.clsSeguimiento(scope);
                    var res = await objDataRetriever.GetSeguimientoActual(ParticipanteId);
                    if (res == null)
                    {
                        var objCita = new Ekilibrate.BL.DataRetriever.Nutricionista.clsCita(scope);
                        var cita = await objCita.GetCitaActual(ParticipanteId);
                        if (cita != null)
                            return new Ekilibrate.Model.Entity.Nutricionista.clsSeguimiento { Nuevo = true, CitaId = cita.Id, ParticipanteId = cita.ParticipanteId };
                        else
                            return new Ekilibrate.Model.Entity.Nutricionista.clsSeguimiento { Nuevo = true, CitaId = 0, ParticipanteId = ParticipanteId };
                    }
                    else
                        return res;
                }
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        async Task<IEnumerable<Model.Entity.Nutricionista.clsSeguimientoAspectos>> IDataRetriever.GetSeguimientoAspectos(int ParticipanteId, int CitaId)
        {

            try
            {
                using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                {
                    var objDataRetriever = new Ekilibrate.BL.DataRetriever.Nutricionista.clsSeguimientoAspectos(scope);
                    return await objDataRetriever.Get(ParticipanteId, CitaId);
                }
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }
        
        public async Task<IEnumerable<Model.Entity.Nutricionista.DiagnosticoAnamnesisTiempo>> GetAnamnesis(int NutricionistaId, int ParticipanteId, int CitaId)
        {
            try
            {
                using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                {
                    var objDataRetriever = new Ekilibrate.BL.DataRetriever.Nutricionista.clsAnamnesis(scope);
                    return await objDataRetriever.GetAnamnesis(NutricionistaId, ParticipanteId, CitaId);
                }
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public async Task<Model.Entity.Nutricionista.clsPlanAlimentacion> GetPlanAlimentacion(int CitaId, int ParticipanteId)
        {
            try
            {
                using (var scope = Ekilibrate.Data.Access.Common.ContainerConfig.ProxyContainer.BeginLifetimeScope())
                {
                    var objDataRetriever = new Ekilibrate.BL.DataRetriever.Nutricionista.claPlanAlimentacion(scope);
                    return await objDataRetriever.Get(CitaId, ParticipanteId);
                }
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }
    }
}
