using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Autofac;
using Ekilibrate.BL.Queries;
using Ekilibrate.Model.Entity.Participante;
using Ekilibrate.BL.ad.Participante;

namespace Ekilibrate.BL.Controller.Participante
{
    public class clsPasosDia : Ekilibrate.BL.ad.Participante.clsPasosDia
    {
        ILifetimeScope _lifetimeScope;
        public clsPasosDia(ILifetimeScope lifetimeScope) : base(lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
        }

        public async Task<Int32> Create(clsPasosDiaBase Data)
        {
            return await base.Insert(Data);
        }

        public async Task Sincronizar(clsRegistroPasos item)
        {            
            if (item.IdCompa > 0)
            {
                item.Id = item.IdPasosCompa;
                item.ParticipanteId = item.IdCompa;
                item.Caminados = item.CaminadosCompa;
            }

            var d = await GetOne(item.SemanaId, item.ParticipanteId, item.Dia);

            if (d == null)
                await base.Insert(item);
            else
            {
                item.Id = d.Id;
                await base.Update(item);
            }
        }

        public async Task Sincronizar(IEnumerable<clsRegistroPasos> Data)
        {
            var objPasos = new Ekilibrate.BL.ad.Participante.clsPasos(_lifetimeScope);
            
            foreach (clsRegistroPasos item in Data)
            {
                await Sincronizar(item);
            }

            //Actualizar los pasos de la semana
            var Listado = Data.GroupBy(x => new { x.ParticipanteId, x.SemanaId  })
                              .Select(grp => grp.First())
                              .ToList();

            foreach (var x in Listado)
            {
                if (x.IdCompa > 0)
                    x.ParticipanteId = x.IdCompa;

                var d = await objPasos.GetOne(x.SemanaId, x.ParticipanteId);

                if (d != null)
                    await objPasos.Update(x.SemanaId, x.ParticipanteId);
                else
                    await objPasos.Insert(x.SemanaId, x.ParticipanteId);
            }
        }
    }
}
