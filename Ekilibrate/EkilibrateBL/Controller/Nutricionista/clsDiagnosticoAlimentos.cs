using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Autofac;
using Ekilibrate.BL.Queries.Nutricionista;
using Ekilibrate.Model.Entity.Nutricionista;
using Ekilibrate.BL.ad.Nutricionista;
using Ekilibrate.Model.Entity.Catalogos;

namespace Ekilibrate.BL.Controller.Nutricionista
{
    public class clsDiagnosticoAlimentos: Ekilibrate.BL.ad.Nutricionista.clsDiagnosticoAlimentos
    {
        public clsDiagnosticoAlimentos(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task<Int32> Create(IEnumerable<DiagnosticoAlimentos> Data)
        {
            int Result = 0;

            foreach (DiagnosticoAlimentos item in Data)
            {
                var r = await base.GetOne(item.ParticipanteId, item.CitaId, item.AlimentoId);
                if (r == null)
                    await base.Insert(item);
                else
                    await base.Update(item);
                //Result = await base.InsertAlimentacion(item);            
            }
            return Result;
        }

    }
}
