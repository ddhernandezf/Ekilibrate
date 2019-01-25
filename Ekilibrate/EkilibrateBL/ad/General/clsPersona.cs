using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Autofac;
using Ekilibrate.BL.Queries.General;
using Ekilibrate.Model.Entity.General;

namespace Ekilibrate.ad.General
{
    public class clsPersona : Ekilibrate.Data.Access.Common.clsTransactionalDataAccess<clsPersonaBase, Int32>
    {
        public clsPersona(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task<clsPersonaBase> GetOne(int Id)
        {
            var p = new DynamicParameters();
            p.Add("Id", Id, System.Data.DbType.Int32);
            var r = await Get(p, QPersona.GetByCorreo);
            return r.FirstOrDefault();
        }

        public async Task<clsPersonaBase> GetByCorreo(string Correo)
        {
            var p = new DynamicParameters();
            p.Add("Correo", Correo, System.Data.DbType.String);
            var r = await Get(p, QPersona.GetByCorreo);
            return r.FirstOrDefault();
        }

        public async Task<Int32> Insert(clsPersonaBase Data)
        {
            var p = GetParams(Data);
            return await SetWithResult<Int32>(p, QPersona.Insert); 
        }

        public async Task<Int32> FotoPerfil(int Id, byte[] Foto)
        {
            var p = new DynamicParameters();
            p.Add("Id", Id, System.Data.DbType.Int32);
            p.Add("FotoPerfil", Foto, System.Data.DbType.Binary);
            return await SetWithResult<Int32>(p, QPersona.FotoPerfil);
        }

        public async Task Update(clsPersonaBase Data)
        {
            var p = GetParams(Data);
            await SetWithResult<Int32>(p, QPersona.Update);
        }

        public async Task Delete(int Id)
        {
            var p = new DynamicParameters();
            p.Add("Id", Id, System.Data.DbType.Int32);
            await Set(p, QPersona.Delete);
        }

        public DynamicParameters GetParams(clsPersonaBase Data)
        {
            var p = new DynamicParameters();
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
            return p;
        }
    }
}
