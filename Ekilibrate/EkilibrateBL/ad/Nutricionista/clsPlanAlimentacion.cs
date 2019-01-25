using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Autofac;
using Ekilibrate.BL.Queries.Nutricionista;
using Ekilibrate.Model.Entity.Nutricionista;


namespace Ekilibrate.BL.ad.Nutricionista
{
    public class clsPlanAlimentacion : Ekilibrate.Data.Access.Common.clsTransactionalDataAccess<Model.Entity.Nutricionista.clsPlanAlimentacion, Int32>
    {

        public clsPlanAlimentacion(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task<Int32> Insert(Model.Entity.Nutricionista.clsPlanAlimentacion Data)
        {
            try
            {
                var p = GetParams(Data);
                return await SetWithResult<Int32>(p, QPlanAlimentacion.Insert);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Int32> Update(Model.Entity.Nutricionista.clsPlanAlimentacion Data)
        {
            try
            {
                var p = GetParams(Data);
                return await SetWithResult<Int32>(p, QPlanAlimentacion.Update);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Model.Entity.Nutricionista.clsPlanAlimentacion> GetOne(int CitaId)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("CitaId", CitaId, System.Data.DbType.Int16);                
                var r = await Get(p, QPlanAlimentacion.GetOne);
                return r.FirstOrDefault();                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        private DynamicParameters GetParams(Model.Entity.Nutricionista.clsPlanAlimentacion Data)
        {
            var p = new DynamicParameters();
            p.Add("CitaId", Data.CitaId, System.Data.DbType.Int16);
            p.Add("ParticipanteId", Data.ParticipanteId, System.Data.DbType.Int16);
            p.Add("Desayuno", Data.Desayuno, System.Data.DbType.String);
            p.Add("RefaccionAm", Data.RefaccionAm, System.Data.DbType.String);
            p.Add("Almuerzo", Data.Almuerzo, System.Data.DbType.String);
            p.Add("RefaccionPm", Data.RefaccionPm, System.Data.DbType.String);
            p.Add("Cena", Data.Cena, System.Data.DbType.String);
            p.Add("Cereales", Data.Cereales, System.Data.DbType.Int16);
            p.Add("Lacteos", Data.Lacteos, System.Data.DbType.Int16);
            //p.Add("LacteosDescremados", Data.LacteosDescremados, System.Data.DbType.Int16);
            //p.Add("LacteosSemi", Data.LacteosSemi, System.Data.DbType.Int16);
            p.Add("Frutas", Data.Frutas, System.Data.DbType.Int16);
            p.Add("Vegetales", Data.Vegetales, System.Data.DbType.Int16);
            p.Add("Azucares", Data.Azucares, System.Data.DbType.Int16);
            p.Add("Carnes", Data.Carnes, System.Data.DbType.Int16);
            p.Add("Grasas", Data.Grasas, System.Data.DbType.Int16);            
            return p;
        }
    }
}
