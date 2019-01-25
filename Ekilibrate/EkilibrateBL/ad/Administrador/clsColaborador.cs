using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Autofac;
using Ekilibrate.BL.Queries.Administrador;
using Ekilibrate.Model.Entity.Administrador;

namespace Ekilibrate.ad.Administrador
{
    public class clsColaborador : Ekilibrate.Data.Access.Common.clsTransactionalDataAccess<clsColaboradorBase, Int32>
    {
        public clsColaborador(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task<Int32> Insert(clsColaboradorBase Data)
        {
            var p = GetParams(Data);
            return await SetWithResult<Int32>(p, QColaboradores.Insert);
        }

        public async Task Update(clsColaboradorBase Data)
        {
            var p = GetParams(Data);
            await Set(p, QColaboradores.Update);
        }

        public async Task Delete(int Id)
        {
            var p = new DynamicParameters();
            p.Add("Id", Id, System.Data.DbType.Int32);
            await Set(p, QColaboradores.Delete);
        }

        public DynamicParameters GetParams(clsColaboradorBase Data)
        {
            var p = new DynamicParameters();
            p.Add("Id", Data.Id, System.Data.DbType.Int32);
            p.Add("PrimerNombre", Data.PrimerNombre, System.Data.DbType.String);
            p.Add("SegundoNombre", Data.SegundoNombre, System.Data.DbType.String);
            p.Add("PrimerApellido", Data.PrimerApellido, System.Data.DbType.String);
            p.Add("SegundoApellido", Data.SegundoApellido, System.Data.DbType.String);
            p.Add("Puesto", Data.Puesto, System.Data.DbType.String);
            p.Add("Correo", Data.Correo, System.Data.DbType.String);
            p.Add("Telefono", Data.Telefono, System.Data.DbType.String);
            p.Add("Extension", Data.Extension, System.Data.DbType.String);
            p.Add("Celular", Data.Celular, System.Data.DbType.String);
            p.Add("ApellidoCasada", Data.ApellidoCasada, System.Data.DbType.String);
            p.Add("Departamento", Data.Departamento, System.Data.DbType.String);
            p.Add("Nutricionista", Convert.ToInt32(Data.Nutricionista), System.Data.DbType.Int32);
            p.Add("Facilitador", Convert.ToInt32(Data.Facilitador), System.Data.DbType.Int32);
            p.Add("Asistente", Convert.ToInt32(Data.Asistente), System.Data.DbType.Int32);
            p.Add("Enfermero", Convert.ToInt32(Data.Enfermero), System.Data.DbType.Int32);
            p.Add("Estado", Data.Estado, System.Data.DbType.String);
            return p;
        }
    }
}
