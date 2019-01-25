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
    public class clsLiderazgo : Ekilibrate.Data.Access.Common.clsReadOnlyDataAccess<Ekilibrate.Model.Entity.Participante.clsTestLiderazgoBase, List<Int32>>
    {
        private ILifetimeScope _lifetimeScope;
        public clsLiderazgo(ILifetimeScope lifetimeScope) : base(lifetimeScope) { _lifetimeScope = lifetimeScope; }

        public async Task<Ekilibrate.Model.Entity.Participante.clsTestLiderazgoBase> GetLiderazgos(Ekilibrate.Model.Entity.Participante.clsLiderazgoFiltro Filtro)
        {
            var p = new DynamicParameters();
            if (Filtro.ID_PARTICIPANTE > 0) p.Add("ID_PARTICIPANTE", Filtro.ID_PARTICIPANTE, System.Data.DbType.Int32);
            IEnumerable<Ekilibrate.Model.Entity.Participante.clsTestLiderazgoBase> list = await Get(p, QTestLiderazgo.List);

            if (list.Count() > 0)
            {
                Ekilibrate.Model.Entity.Participante.clsTestLiderazgoBase obj = list.First<Ekilibrate.Model.Entity.Participante.clsTestLiderazgoBase>();
                Ekilibrate.BL.DataRetriever.Participante.clsPreguntaLiderazgo objPreguntaLiderazgo = new clsPreguntaLiderazgo(_lifetimeScope);
                Ekilibrate.Model.Entity.Participante.clsPreguntaLiderazgoFiltro PreguntaLiderazgoFiltro = new Model.Entity.Participante.clsPreguntaLiderazgoFiltro
                {
                    ID_PARTICIPANTE = obj.ParticipanteId,
                };
                //obj.LISTA_PREGUNTA_DOS = await objPreguntaLiderazgo.GetPreguntasLiderazgo(obj.ParticipanteId);
                    
                return obj;
            }
            else
            return null ;
        }
    }
}
