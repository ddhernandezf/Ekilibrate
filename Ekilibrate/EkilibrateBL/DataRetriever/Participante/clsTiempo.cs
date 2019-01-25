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
    public class clsTiempo : Ekilibrate.Data.Access.Common.clsReadOnlyDataAccess<Ekilibrate.Model.Entity.Participante.clsTiempoBase, Int32>
    {
        private ILifetimeScope _lifetimeScope;
        public clsTiempo(ILifetimeScope lifetimeScope) : base(lifetimeScope) { _lifetimeScope = lifetimeScope; }


        public async Task<Ekilibrate.Model.Entity.Participante.clsTiempoBase> GetTiempos(Ekilibrate.Model.Entity.Participante.clsTiempoFiltro Filtro)
        {
            var p = new DynamicParameters();
            if (Filtro.ID_PARTICIPANTE > 0) p.Add("ID_PARTICIPANTE", Filtro.ID_PARTICIPANTE, System.Data.DbType.Int32);
            IEnumerable<Ekilibrate.Model.Entity.Participante.clsTiempoBase> list = await Get(p, QTiempo.List);

            if (list.Count() > 0)
            {
                Ekilibrate.Model.Entity.Participante.clsTiempoBase obj = list.First<Ekilibrate.Model.Entity.Participante.clsTiempoBase>();
                Ekilibrate.BL.DataRetriever.Participante.clsFrecuencia objFrecuencia = new clsFrecuencia(_lifetimeScope);
                Ekilibrate.Model.Entity.Participante.clsFrecuenciaFiltro frecuenciaFiltro = new Model.Entity.Participante.clsFrecuenciaFiltro
                {
                    ID_PARTICIPANTE = obj.ID_PARTICIPANTE,
                };
                obj.LISTA_PREGUNTA = await objFrecuencia.GetFrecuencias(frecuenciaFiltro);

                return obj;
            }
            else
                return null;
        }
    }
}
