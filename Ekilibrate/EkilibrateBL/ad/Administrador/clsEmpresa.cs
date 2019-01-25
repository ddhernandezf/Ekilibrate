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
    public class clsEmpresa : Ekilibrate.Data.Access.Common.clsTransactionalDataAccess<clsEmpresaBase, Int32>
    {
        public clsEmpresa(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task<Int32> Insert(clsEmpresaBase Data)
        {
            var p = new DynamicParameters();
            p.Add("Nombre", Data.Nombre, System.Data.DbType.String);
            p.Add("PBX", Data.PBX, System.Data.DbType.String);
            p.Add("Direccion", Data.Direccion, System.Data.DbType.String);
            p.Add("GiroId", Data.GiroId, System.Data.DbType.Int32);
            p.Add("CantidadAdministrativo", Data.CantidadAdministrativo, System.Data.DbType.Int32);
            p.Add("CantidadDistribucion", Data.CantidadDistribucion, System.Data.DbType.Int32);
            p.Add("CantidadOtros", Data.CantidadOtros, System.Data.DbType.Int32);
            p.Add("CantidadProduccion", Data.CantidadProduccion, System.Data.DbType.Int32);
            p.Add("CantidadTotalEmpleados", Data.CantidadTotalEmpleados, System.Data.DbType.Int32);
            p.Add("CantidadVentas", Data.CantidadVentas, System.Data.DbType.Int32);
            p.Add("OtrosDescripcion", (Data.OtrosDescripcion == null) ? "" : Data.OtrosDescripcion, System.Data.DbType.String);

            return await SetWithResult<Int32>(p, QEmpresa.Insert);
        }

        public async Task Update(clsEmpresaBase Data)
        {
            var p = new DynamicParameters();
            p.Add("Id",  Data.Id, System.Data.DbType.Int32);
            p.Add("Nombre", Data.Nombre, System.Data.DbType.String);
            p.Add("PBX", Data.PBX, System.Data.DbType.String);
            p.Add("Direccion", Data.Direccion, System.Data.DbType.String);
            p.Add("GiroId", Data.GiroId, System.Data.DbType.Int32);
            p.Add("CantidadAdministrativo", Data.CantidadAdministrativo, System.Data.DbType.Int32);
            p.Add("CantidadDistribucion", Data.CantidadDistribucion, System.Data.DbType.Int32);
            p.Add("CantidadOtros", Data.CantidadOtros, System.Data.DbType.Int32);
            p.Add("CantidadProduccion", Data.CantidadProduccion, System.Data.DbType.Int32);
            p.Add("CantidadTotalEmpleados", Data.CantidadTotalEmpleados, System.Data.DbType.Int32);
            p.Add("CantidadVentas", Data.CantidadVentas, System.Data.DbType.Int32);
            p.Add("OtrosDescripcion", (Data.OtrosDescripcion == null) ? "" : Data.OtrosDescripcion, System.Data.DbType.String);
            await Set(p, QEmpresa.Update);
        }

        public async Task Delete(int Id)
        {
            var p = new DynamicParameters();
            p.Add("Id", Id, System.Data.DbType.Int32);
            await Set(p, QEmpresa.Delete);
        }
    }
}
