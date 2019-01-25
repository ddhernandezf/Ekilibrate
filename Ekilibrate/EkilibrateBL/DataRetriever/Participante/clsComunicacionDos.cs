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
    public class clsComunicacionDos : Ekilibrate.Data.Access.Common.clsReadOnlyDataAccess<Ekilibrate.Model.Entity.Participante.clsComunicacionDosBase, Int32>
    {
        private ILifetimeScope _lifetimeScope;
        public clsComunicacionDos(ILifetimeScope lifetimeScope) : base(lifetimeScope) { _lifetimeScope = lifetimeScope; }

        public async Task<Ekilibrate.Model.Entity.Participante.clsComunicacionDosBase> GetComunicacionesDos(Ekilibrate.Model.Entity.Participante.clsComunicacionDosFiltro Filtro)
        {
            var p = new DynamicParameters();
            if (Filtro.ID_PARTICIPANTE > 0) p.Add("ID_PARTICIPANTE", Filtro.ID_PARTICIPANTE, System.Data.DbType.Int32);
            IEnumerable<Ekilibrate.Model.Entity.Participante.clsComunicacionDosBase> list = await Get(p, QComunicacionDos.List);

            if (list.Count() > 0)
            {
                Ekilibrate.Model.Entity.Participante.clsComunicacionDosBase obj = list.First<Ekilibrate.Model.Entity.Participante.clsComunicacionDosBase>();
                Ekilibrate.BL.DataRetriever.Participante.clsAsertivaDos objAsertivaDos = new clsAsertivaDos(_lifetimeScope);
                Ekilibrate.Model.Entity.Participante.clsAsertivaDosFiltro AsertivaDosFiltro = new Model.Entity.Participante.clsAsertivaDosFiltro
                {
                    ID_PARTICIPANTE = obj.ID_PARTICIPANTE,
                };
                obj.LISTA_PREGUNTA_DOS = await objAsertivaDos.GetAsertivasDos(AsertivaDosFiltro);

                return obj;
            }
            else
            return null ;
        }
    }
}
