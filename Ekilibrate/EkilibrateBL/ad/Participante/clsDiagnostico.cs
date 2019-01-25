using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Autofac;
using Ekilibrate.BL.Queries.Participante;
using Ekilibrate.Model.Entity.Participante;

namespace Ekilibrate.BL.ad.Participante
{
    public class clsDiagnostico : Ekilibrate.Data.Access.Common.clsTransactionalDataAccess<clsDiagnosticoBase,Int32>
    {
        public clsDiagnostico(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task<clsDiagnosticoBase> GetOne(int ParticipanteId)
        {
            var p = new DynamicParameters();
            p.Add("ID_PARTICIPANTE", ParticipanteId, System.Data.DbType.Int32);
            var r = await Get(p, QDiagnostico.GetOne);
            return r.FirstOrDefault();
        }

        public async Task<Int32> Insert(clsDiagnosticoBase Data)
        {
            var p = GetParams(Data);            
            await Set(p, QDiagnostico.Insert);
            return Data.ID_PARTICIPANTE;
        }
        public async Task Update(clsDiagnosticoBase Data)
        {
            var p = GetParams(Data);            
            await SetWithResult<Int32>(p, QDiagnostico.Update);
        }

        public async Task Delete(int ID_PARTICIPANTE)
        {
            var p = new DynamicParameters();
            p.Add("ID_PARTICIPANTE", ID_PARTICIPANTE, System.Data.DbType.Int32);
            await Set(p, QDiagnostico.Delete);
        }

        public DynamicParameters GetParams(clsDiagnosticoBase Data)
        {
            var p = new DynamicParameters();

            p.Add("ID_PARTICIPANTE", Data.ID_PARTICIPANTE, System.Data.DbType.Int32);
            p.Add("FACEBOOK", Data.FACEBOOK, System.Data.DbType.String);
            p.Add("ID_MEDIO_COMUNICACION", Data.ID_MEDIO_COMUNICACION, System.Data.DbType.Int32);
            if (Data.ID_MEDIO_COMUNICACION == 0)
                p.Add("ID_MEDIO_COMUNICACION", DBNull.Value, System.Data.DbType.Int32);
            else
                p.Add("ID_MEDIO_COMUNICACION", Data.ID_MEDIO_COMUNICACION, System.Data.DbType.Int32);
            p.Add("SEXO", Data.SEXO, System.Data.DbType.String);
            if (Data.FECHA_NACIMIENTO == DateTime.MinValue)
                p.Add("FECHA_NACIMIENTO", DBNull.Value, System.Data.DbType.Date);
            else
                p.Add("FECHA_NACIMIENTO", Data.FECHA_NACIMIENTO, System.Data.DbType.Date);
            p.Add("MUJER_EMBARAZADA", Data.MUJER_EMBARAZADA, System.Data.DbType.Boolean);
            if (Data.FEC_ULT_MENSTRUACION == DateTime.MinValue)
                p.Add("FEC_ULT_MENSTRUACION", DBNull.Value, System.Data.DbType.Date);
            else
                p.Add("FEC_ULT_MENSTRUACION", Data.FEC_ULT_MENSTRUACION, System.Data.DbType.Date);
            p.Add("EDAD_GESTACIONAL", Data.EDAD_GESTACIONAL, System.Data.DbType.Int32);
            p.Add("PESO_ANTERIOR", Data.PESO_ANTERIOR, System.Data.DbType.Int32);
            p.Add("MUJER_LACTANCIA", Data.MUJER_LACTANCIA, System.Data.DbType.String);
            if (Data.FEC_NAC_BEBE == DateTime.MinValue)
                p.Add("FEC_NAC_BEBE", DBNull.Value, System.Data.DbType.Date);
            else
                p.Add("FEC_NAC_BEBE", Data.FEC_NAC_BEBE, System.Data.DbType.Date);
            p.Add("EDAD", Data.EDAD, System.Data.DbType.Int32);
            p.Add("MENOPAUSIA", Data.MENOPAUSIA, System.Data.DbType.Boolean);

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
