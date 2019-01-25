using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Autofac;
using Ekilibrate.BL.Queries.Administracion;
using Ekilibrate.Model.Entity.Administracion;

namespace Ekilibrate.ad.Administracion
{
    public class clsUsuarioPorRol : Ekilibrate.Data.Access.Common.clsTransactionalDataAccess<clsUsuarioPorRolBase, List<Int32>>
    {
        public clsUsuarioPorRol(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task Insert(clsUsuarioPorRolBase Data)
        {
            var p = new DynamicParameters();
            p.Add("IdUsuario", Data.IdUsuario, System.Data.DbType.Int32);
            p.Add("IdRol", Data.IdRol, System.Data.DbType.Int32);
            p.Add("TransacDateTime", Data.TransacDateTime, System.Data.DbType.DateTime);
            p.Add("TransacUser", Data.TransacUser, System.Data.DbType.String);
            await Set(p, QUsuarioPorRol.Insert);
        }

        //public async Task Update(clsUsuarioBase Data)
        //{
        //    var p = new DynamicParameters();
        //    p.Add("Id", Data.Id, System.Data.DbType.Int32);
        //    p.Add("Nombre", Data.Nombre, System.Data.DbType.String);
        //    p.Add("Apellido", Data.Apellido, System.Data.DbType.String);
        //    p.Add("Telefono", Data.Telefono, System.Data.DbType.String);
        //    p.Add("Direccion", Data.Direccion, System.Data.DbType.String);
        //    p.Add("Correo", Data.Correo, System.Data.DbType.String);
        //    p.Add("Extension", Data.Extension, System.Data.DbType.String);
        //    p.Add("Puesto", Data.Puesto, System.Data.DbType.String);
        //    await SetWithResult<Int32>(p, QPersona.Update);
        //}

        //public async Task Delete(int Id)
        //{
        //    var p = new DynamicParameters();
        //    p.Add("Id", Id, System.Data.DbType.Int32);
        //    await Set(p, QPersona.Delete);
        //}
    }
}
