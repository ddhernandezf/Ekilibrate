using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Autofac;
using Ekilibrate.BL.Queries.Nutricionista;
using Ekilibrate.Model.Entity.Proyecto;

namespace Ekilibrate.BL.DataRetriever.Nutricionista
{
    public class clsCita: Ekilibrate.Data.Access.Common.clsReadOnlyDataAccess<Model.Entity.Proyecto.clsCita, Int32>
    {
        public clsCita(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task<IEnumerable<Model.Entity.Proyecto.clsCita>> GetCitas(clsCitaFiltro Filtro)
        {
            var p = new DynamicParameters();


            p.Add("NutricionistaId", Filtro.NutricionistaId, System.Data.DbType.Int32);
            p.Add("Fecha", Filtro.Fecha, System.Data.DbType.DateTime);

            return await Get(p, QCita.List);
        }

        public async Task<IEnumerable<Model.Entity.Proyecto.clsCita>> GetCitasDiagnostico(clsCitaFiltro Filtro)
        {
            var p = new DynamicParameters();


            p.Add("NutricionistaId", Filtro.NutricionistaId, System.Data.DbType.Int32);
            p.Add("Fecha", Filtro.Fecha, System.Data.DbType.DateTime);

            return await Get(p, QCita.ListSinCita);
        }

        public async Task<IEnumerable<Model.Entity.Proyecto.clsCita>> GetCitasFin(clsCitaFiltro Filtro)
        {
            var p = new DynamicParameters();

            p.Add("NutricionistaId", Filtro.NutricionistaId, System.Data.DbType.Int32);
            p.Add("Fecha", Filtro.Fecha, System.Data.DbType.DateTime);

            return await Get(p, QCita.ListFin);
        }       

        public async Task<Model.Entity.Proyecto.clsCita> GetCita(int Id)
        {
            var p = new DynamicParameters();
            p.Add("Id", Id, System.Data.DbType.Int32);

            var res = await Get(p, QCita.GetOne);
            return res.FirstOrDefault();
        }

        public async Task<Model.Entity.Proyecto.clsCitaBase> GetCitaActual(int ParticipanteId)
        {
            var p = new DynamicParameters();
            p.Add("ParticipanteId", ParticipanteId, System.Data.DbType.Int32);

            var res = await Get<Model.Entity.Proyecto.clsCitaBase>(p, QCita.GetPresent);
            return res.FirstOrDefault();
        }

        public async Task<Model.Entity.Proyecto.clsCita> GetAnterior(int Id)
        {
            var p = new DynamicParameters();
            p.Add("Id", Id, System.Data.DbType.Int32);

            var res = await Get(p, QCita.GetBefore);
            return res.FirstOrDefault();
        }
    }
}
