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
    public class clsComunicacion : Ekilibrate.Data.Access.Common.clsReadOnlyDataAccess<Ekilibrate.Model.Entity.Participante.clsComunicacionBase, Int32>
    {
        private ILifetimeScope _lifetimeScope;
        public clsComunicacion(ILifetimeScope lifetimeScope) : base(lifetimeScope) { _lifetimeScope = lifetimeScope; }

        public async Task<Ekilibrate.Model.Entity.Participante.clsComunicacionBase> GetComunicaciones(Ekilibrate.Model.Entity.Participante.clsComunicacionFiltro Filtro)
        {
            var p = new DynamicParameters();
            if (Filtro.ID_PARTICIPANTE > 0) p.Add("ID_PARTICIPANTE", Filtro.ID_PARTICIPANTE, System.Data.DbType.Int32);
            IEnumerable<Ekilibrate.Model.Entity.Participante.clsComunicacionBase> list = await Get(p, QComunicacion.List);

            if (list.Count() > 0)
            {
                Ekilibrate.Model.Entity.Participante.clsComunicacionBase obj = list.First<Ekilibrate.Model.Entity.Participante.clsComunicacionBase>();
                Ekilibrate.BL.DataRetriever.Participante.clsAsertiva objAsertiva = new clsAsertiva(_lifetimeScope);
                Ekilibrate.Model.Entity.Participante.clsAsertivaFiltro AsertivaFiltro = new Model.Entity.Participante.clsAsertivaFiltro
                {
                    ID_PARTICIPANTE = obj.ID_PARTICIPANTE,
                };
                obj.LISTA_PREGUNTA_UNO = await objAsertiva.GetAsertivas(AsertivaFiltro);

                return obj;
            }
            else
            return null ;
        }
    }
}
