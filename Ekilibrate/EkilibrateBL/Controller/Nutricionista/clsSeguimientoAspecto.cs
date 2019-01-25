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

namespace Ekilibrate.BL.Controller.Nutricionista
{
    public class clsSeguimientoAspecto : Ekilibrate.BL.ad.Nutricionista.clsSeguimientoAspectos
    {
        public clsSeguimientoAspecto(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task Create(IEnumerable<Model.Entity.Nutricionista.clsSeguimientoAspectos> Data)
        {
            foreach (var item in Data)
            {       
                //Sincrnoniza aspecto en semana actual
                if (item.Nuevo)
                    await base.Insert(item);
                else
                    await base.Update(item);
                
                //Actualiza Logro de semana anterior
                if (item.CitaAnterior > 0)
                {
                    var CitaAnterior = await GetOne(item.CitaAnterior, item.AspectoId);
                    if (CitaAnterior != null)
                    {
                        CitaAnterior.Logro = item.LogroAnterior;
                        await base.Update(CitaAnterior);
                    }
                    else
                        await CreateAnterior(item);                    
                }
                else
                    await CreateAnterior(item);                
            }
        }

        public async Task CreateAnterior(Model.Entity.Nutricionista.clsSeguimientoAspectos item)
        {
            var objCita = new Ekilibrate.BL.DataRetriever.Nutricionista.clsCita(base._lifetimescope);
            var r = await objCita.GetAnterior(item.CitaId);

            var CitaAnterior = new clsSeguimientoAspectosBase();
            CitaAnterior.ParticipanteId = item.ParticipanteId;
            CitaAnterior.CitaId = r.Id;
            CitaAnterior.AspectoId = item.AspectoId;
            CitaAnterior.Logro = item.LogroAnterior;
            CitaAnterior.Meta = item.MetaAnterior;
            await base.Insert(CitaAnterior);
        }
    }
}
