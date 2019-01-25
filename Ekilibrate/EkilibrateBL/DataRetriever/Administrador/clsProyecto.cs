using Autofac;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.BL.DataRetriever
{
    public class clsProyecto : Ekilibrate.Data.Access.Common.clsReadOnlyDataAccess<Ekilibrate.Model.Entity.Administrador.clsProyecto, Int32>
    {
        public clsProyecto(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task<IEnumerable<Ekilibrate.Model.Entity.Administrador.clsProyecto>> GetProyectos()
        {
            var p = new DynamicParameters();
            var result = await Get(p, Queries.Administrador.QProyecto.List);
            result.ToList().ForEach(x =>
            {
                StartDates(ref x);
            });

            return  result;
        }

        public async Task<IEnumerable<Ekilibrate.Model.Entity.Administrador.clsProyecto>> GetProyectos(int EmpresaId)
        {
            var p = new DynamicParameters();
            p.Add("EmpresaId", EmpresaId, System.Data.DbType.Int32);

            var result = await Get(p, Queries.Administrador.QProyecto.ListByEmpresa);
            result.ToList().ForEach(x =>
            {
                StartDates(ref x);
            });

            return result;
        }

        public async Task<IEnumerable<Ekilibrate.Model.Entity.Administrador.clsProyecto>> GetProyectosxEstado(string Estado)
        {
            var p = new DynamicParameters();
            p.Add("Estado", Estado, System.Data.DbType.String);

            var result = await Get(p, Queries.Administrador.QProyecto.ListByEstado);
            result.ToList().ForEach(x =>
            {
                StartDates(ref x);
            });

            return result;
        }

        public async Task<Ekilibrate.Model.Entity.Administrador.clsProyecto> GetProyecto(int ProyectoId)
        {
            var p = new DynamicParameters();

            p.Add("Id", ProyectoId, System.Data.DbType.Int32);
            IEnumerable<Ekilibrate.Model.Entity.Administrador.clsProyecto> res = await Get<Ekilibrate.Model.Entity.Administrador.clsProyecto>(p, Queries.Administrador.QProyecto.ProyectoDetailed);
            if (res.Count() > 0)
            {
                var x = res.First();
                StartDates(ref x);
                return x;
            }
            else
                throw new Exception("No se encontró información del proyecto");
        }

        public async Task<Ekilibrate.Model.Entity.Administrador.clsProyecto> GetProyecto(string CodigoRegistro)
        {
            var p = new DynamicParameters();

            p.Add("CodigoRegistro", CodigoRegistro, System.Data.DbType.String);
            IEnumerable<Ekilibrate.Model.Entity.Administrador.clsProyecto> res = await Get<Ekilibrate.Model.Entity.Administrador.clsProyecto>(p, Queries.Administrador.QProyecto.ProyectoByCodigo);
            if (res.Count() > 0)
            {
                var x = res.First();
                StartDates(ref x);
                return x;
            }
            else
                return null;
        }

        public void StartDates(ref Ekilibrate.Model.Entity.Administrador.clsProyecto x)
        {
            x.DHoraInicioConsultas = x.HoraInicioConsultas != null ? new DateTime().Add((TimeSpan)x.HoraInicioConsultas) : new DateTime();
            x.DHoraFinConsultas = x.HoraFinConsultas != null ? new DateTime().Add((TimeSpan)x.HoraFinConsultas) : new DateTime();
            x.DDuracionConsultas = x.DuracionConsultas != null ? new DateTime().Add((TimeSpan)x.DuracionConsultas) : new DateTime();
            x.DHoraInicioBx = x.HoraInicioBx != null ? new DateTime().Add((TimeSpan)x.HoraInicioBx) : new DateTime();
            x.DHoraFinBx = x.HoraFinBx != null ? new DateTime().Add((TimeSpan)x.HoraFinBx) : new DateTime();
            x.DHoraInicioDN = x.HoraInicioDN != null ? new DateTime().Add((TimeSpan)x.HoraInicioDN) : new DateTime();
            x.DHoraFinDN = x.HoraFinDN != null ? new DateTime().Add((TimeSpan)x.HoraFinDN) : new DateTime();
            x.DDuracionDN = x.DuracionDN != null ? new DateTime().Add((TimeSpan)x.DuracionDN) : new DateTime();
        }
    }
}
