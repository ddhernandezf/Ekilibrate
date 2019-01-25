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
    public class clsRiesgo : Ekilibrate.Data.Access.Common.clsReadOnlyDataAccess<Ekilibrate.Model.Entity.Participante.clsRiesgoBase,Int32> 
    {
        private ILifetimeScope _lifetimeScope;

        public clsRiesgo(ILifetimeScope lifetimeScope) : base(lifetimeScope) { _lifetimeScope = lifetimeScope; }
                
        public async Task<Ekilibrate.Model.Entity.Participante.clsRiesgoBase> GetRiesgos(int Participante)
        {
            Ekilibrate.Model.Entity.Participante.clsRiesgoBase obj;
            Ekilibrate.BL.DataRetriever.Participante.clsBebidasFrecuentes objBebida = new clsBebidasFrecuentes(_lifetimeScope);
            Ekilibrate.BL.DataRetriever.Participante.clsMedidaBebida objMedida = new clsMedidaBebida(_lifetimeScope);
            Ekilibrate.BL.DataRetriever.Participante.clsEnfermedad objEnfermedad = new clsEnfermedad(_lifetimeScope);

            var p = new DynamicParameters();
            p.Add("ID_PARTICIPANTE", Participante, System.Data.DbType.Int32);

            IEnumerable<Ekilibrate.Model.Entity.Participante.clsRiesgoBase> list = await Get(p, QRiesgo.List);

            if (list.Count() > 0)
                obj = list.First<Ekilibrate.Model.Entity.Participante.clsRiesgoBase>();
            else
                obj = new Ekilibrate.Model.Entity.Participante.clsRiesgoBase();

            obj.LISTA_BEBIDA = await objBebida.GetBebidas(obj.ID_PARTICIPANTE);
            obj.LISTA_MEDIDA = await objMedida.GetMedidas(obj.ID_PARTICIPANTE);
            obj.LISTA_ENFERMEDAD = await objEnfermedad.GetEnfermedad(obj.ID_PARTICIPANTE);
            
            return obj;
        }

    }
}
