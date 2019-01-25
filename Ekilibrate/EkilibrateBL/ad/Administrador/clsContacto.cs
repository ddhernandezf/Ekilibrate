using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Autofac;
using Ekilibrate.BL.Queries.Administrador;
using Ekilibrate.Model.Entity.Administrador;
using Ekilibrate.Model.Administrador;

namespace Ekilibrate.ad.Administrador
{
    public class clsContacto : Ekilibrate.Data.Access.Common.clsTransactionalDataAccess<clsColaboradorBase, Int32>
    {
        public clsContacto(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task<Int32> Insert(clsContactoBase Data)
        {
            var p = GetParams(Data);
            if (Data.EsPrincipal)
                return await SetWithResult<Int32>(p, QContaco.InsertPrincipal);
            else
                return await SetWithResult<Int32>(p, QContaco.Insert);
        }

        public async Task Update(clsContactoBase Data)
        {
            var p = GetParams(Data);
            if (Data.EsPrincipal)
                await Set(p, QContaco.UpdatePrincipal);
            else
                await Set(p, QContaco.Update);
        }

        public async Task Delete(int Id)
        {
            var p = new DynamicParameters();
            p.Add("Id", Id, System.Data.DbType.Int32);
            await Set(p, QContaco.Delete);
        }

        private DynamicParameters GetParams(clsContactoBase Data)
        {
            var p = new DynamicParameters();
            p.Add("Id", Data.Id, System.Data.DbType.Int32);
            p.Add("PrimerNombre", Data.PrimerNombre, System.Data.DbType.String);
            p.Add("SegundoNombre", Data.SegundoNombre, System.Data.DbType.String);
            p.Add("PrimerApellido", Data.PrimerApellido, System.Data.DbType.String);
            p.Add("SegundoApellido", Data.SegundoApellido, System.Data.DbType.String);
            p.Add("ApellidoCasada", Data.SegundoApellido, System.Data.DbType.String);
            p.Add("Telefono", Data.Telefono, System.Data.DbType.String);
            p.Add("Direccion", Data.Direccion, System.Data.DbType.String);
            p.Add("Correo", Data.Correo, System.Data.DbType.String);
            p.Add("Extension", Data.Extension, System.Data.DbType.String);
            p.Add("Puesto", Data.Puesto, System.Data.DbType.String);
            p.Add("EmpresaId", Data.EmpresaId, System.Data.DbType.Int32);
            p.Add("Celular", Data.Celular, System.Data.DbType.String);
            p.Add("EsPrincipal", Data.EsPrincipal, System.Data.DbType.Boolean);
            return p;
        }
    }
}
