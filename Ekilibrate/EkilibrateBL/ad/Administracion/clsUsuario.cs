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
    public class clsUsuario : Ekilibrate.Data.Access.Common.clsTransactionalDataAccess<clsUsuarioBase, Int32>
    {
        public clsUsuario(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task<Int32> Insert(clsUsuarioBase Data)
        {
            var p = new DynamicParameters();
            p.Add("NombreUsuario", Data.NombreUsuario, System.Data.DbType.String);
            p.Add("Contraseña", Data.Contraseña, System.Data.DbType.String);
            p.Add("IdPersona", Data.IdPersona, System.Data.DbType.String);
            p.Add("IdTipoUsuario", Data.IdTipoUsuario, System.Data.DbType.String);
            p.Add("Activo", Data.Activo, System.Data.DbType.String);
            return await SetWithResult<Int32>(p, QUsuario.Insert);
        }

        public async Task Update(clsUsuarioBase Data)
        {
            var p = new DynamicParameters();
            p.Add("IdUsuario", Data.NombreUsuario, System.Data.DbType.Int32);
            p.Add("IdTipoUsuario", Data.IdTipoUsuario, System.Data.DbType.Int32);
            p.Add("Activo", Data.Activo, System.Data.DbType.String);
            await Set(p, QUsuario.Update);
        }

        public async Task<clsUsuarioBase> GetUsuarioByPersona(int IdPersona)
        {
            var p = new DynamicParameters();
            p.Add("IdPersona", IdPersona, System.Data.DbType.String);
            
            var Result = await Get(p, QUsuario.GetByPersona);
            if (Result.Count() > 0)
                return Result.First();
            else
                return new clsUsuarioBase();
        }

        public async Task<string> GetUserKey(string Correo, string Empresa, string Nombre, string Apellido)
        {
            string Usuario = String.Empty;
            if (Correo.Length > 0)
                Usuario = Correo.Substring(0, Correo.IndexOf("@") + 1);
            else
                Usuario = Nombre.ToLower().Trim().Replace(" ", "") + "." + Apellido.ToLower().Trim().Replace(" ", "") + "@" + Empresa.ToLower().Replace(" ", "");
                        
            var p = new DynamicParameters();
            p.Add("NombreUsuario", Usuario, System.Data.DbType.String);
            
            var Result = await Get(p, QUsuario.GetNick);
            if (Result.Count() > 0)
            {
                return Usuario + "_" + Result.Count() + Empresa.ToLower().Trim();
            }
            else
                return Usuario + Empresa.ToLower().Trim();
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
