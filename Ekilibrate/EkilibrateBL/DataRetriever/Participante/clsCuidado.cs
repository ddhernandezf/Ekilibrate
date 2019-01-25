using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Autofac;
using Ekilibrate.BL.Queries.Participante;

namespace Ekilibrate.BL.DataRetriever.Participante
{
    public class clsCuidado : Ekilibrate.Data.Access.Common.clsReadOnlyDataAccess<Ekilibrate.Model.Entity.Participante.clsActividadFisica, Int32>
    {        
        public clsCuidado(ILifetimeScope lifetimeScope) : base(lifetimeScope) { _lifetimescope = lifetimeScope; }

        public async Task<Ekilibrate.Model.Entity.Participante.clsCuidado> GetCuidados(int Participante)
        {
            Ekilibrate.ad.Participante.clsActividadFisica objActividad = new Ekilibrate.ad.Participante.clsActividadFisica(_lifetimescope);
            Ekilibrate.BL.ad.Participante.clsPadecimiento objPadecimiento = new Ekilibrate.BL.ad.Participante.clsPadecimiento(_lifetimescope);
            Ekilibrate.BL.DataRetriever.Participante.clsCondicionPreExistente objCondicionPre = new clsCondicionPreExistente(_lifetimescope);
                        
            Ekilibrate.Model.Entity.Participante.clsCuidado objCuidado = new Model.Entity.Participante.clsCuidado();
            objCuidado.ActividadFisica = await objActividad.GetByParticipante(Participante);
            objCuidado.Padecimiento = await objPadecimiento.GetByParticipante(Participante);
            objCuidado.ListadoCondiciones = await objCondicionPre.GetPreExistentes(Participante);

            return objCuidado;
        }

        public async Task<IEnumerable<Ekilibrate.Model.Entity.Participante.clsTipoEjercicio>> GetTipoEjercicio()
        {
            Ekilibrate.BL.DataRetriever.Participante.clsTipoEjercicio objTipoEjercicio = new Ekilibrate.BL.DataRetriever.Participante.clsTipoEjercicio(_lifetimescope);
            return await objTipoEjercicio.GetTipoEjercicio();
        }
    }
}
