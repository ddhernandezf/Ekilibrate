using Autofac;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ekilibrate.BL.Queries.Administrador;
using Ekilibrate.Model.Administrador;

namespace Ekilibrate.ad.Administrador
{
    public class clsProyecto : Ekilibrate.Data.Access.Common.clsTransactionalDataAccess<Ekilibrate.Model.Entity.Administrador.clsProyecto, Int32>
    {
        public clsProyecto(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task<Int32> Insert(Ekilibrate.Model.Entity.Administrador.clsProyecto Data)
        {
            var p = GetParams(Data);
            return await SetWithResult<Int32>(p, QProyecto.Insert);
        }

        public async Task Update(Ekilibrate.Model.Entity.Administrador.clsProyecto Data)
        {
            var p = GetParams(Data);
            await Set(p, QProyecto.Update);
        }

        public async Task Delete(int Id)
        {
            var p = new DynamicParameters();
            p.Add("Id", Id, System.Data.DbType.Int32);
            await Set(p, QProyecto.Delete);
        }

        private DynamicParameters GetParams(Ekilibrate.Model.Entity.Administrador.clsProyecto Data)
        {
            var p = new DynamicParameters();
            p.Add("Id", Data.Id, System.Data.DbType.Int32);
            p.Add("EmpresaId", Data.EmpresaId, System.Data.DbType.Int32);
            p.Add("Estado", Data.Estado, System.Data.DbType.String);
            p.Add("FechaInicio", Data.FechaInicio, System.Data.DbType.DateTime);
            p.Add("FechaFin", Data.FechaFin, System.Data.DbType.DateTime);
            p.Add("NoSemanas", Data.NoSemanas, System.Data.DbType.Int32);
            p.Add("NoParticipantes", Data.NoParticipantes, System.Data.DbType.Int32);
            p.Add("NoEnfermeras", Data.NoEnfermeras, System.Data.DbType.Int32);
            p.Add("NoFacilitadores", Data.NoFacilitadores, System.Data.DbType.Int32);
            p.Add("NoAsistentes", Data.NoAsistentes, System.Data.DbType.Int32);
            p.Add("NoConsultasNutricionales", Data.NoConsultasNutricionales, System.Data.DbType.Int32);
            p.Add("FrecuenciaConsultas", Data.FrecuenciaConsultas, System.Data.DbType.Int32);
            p.Add("FrecuenciaAlertas", Data.FrecuenciaAlertas, System.Data.DbType.Int32);
            p.Add("FrecuenciaAlertasUnidad", Data.FrecuenciaAlertasUnidad, System.Data.DbType.Int32);
            p.Add("FrecuenciaConsultasUnidad", Data.FrecuenciaConsultasUnidad, System.Data.DbType.Int32);
            p.Add("Color", Data.Color, System.Data.DbType.String);
            p.Add("CrearUsuarios", Data.CrearUsuarios, System.Data.DbType.Boolean);
            p.Add("LogoURL", Data.LogoURL, System.Data.DbType.String);
            p.Add("AseguradoraId", Data.AseguradoraId, System.Data.DbType.Int32);
            p.Add("IndiceReclamos", Data.IndiceReclamos, System.Data.DbType.Decimal);
            p.Add("NoParticipantesPorGrupo", Data.NoParticipantesPorGrupo, System.Data.DbType.Int32);
            p.Add("FechaCorreoInvitacion", Data.FechaCorreoInvitacion, System.Data.DbType.DateTime);
            p.Add("FechaPrimeraCitaDiagnostico", Data.FechaPrimeraCitaDiagnostico, System.Data.DbType.DateTime);
            p.Add("CitasProgramadas", Data.CitasProgramadas, System.Data.DbType.Boolean);
            p.Add("MetasCalculadas", Data.MetasCalculadas, System.Data.DbType.Boolean);
            p.Add("FechaInicioConsultas", Data.FechaInicioConsultas, System.Data.DbType.DateTime);
            p.Add("HoraInicioConsultas", Data.HoraInicioConsultas, System.Data.DbType.Time);
            p.Add("HoraFinConsultas", Data.HoraFinConsultas, System.Data.DbType.Time);
            p.Add("DuracionConsultas", Data.DuracionConsultas, System.Data.DbType.Time);
            p.Add("NoNutricionistas", Data.NoNutricionistas, System.Data.DbType.Int32);
            p.Add("TipoProyectoId", Data.TipoProyectoId, System.Data.DbType.Int32);
            p.Add("Nombre", Data.Nombre, System.Data.DbType.String);
            p.Add("CodigoRegistro", Data.CodigoRegistro, System.Data.DbType.String);
            p.Add("Correo", Data.Correo, System.Data.DbType.String);
            p.Add("PasswordCorreo", Data.PasswordCorreo, System.Data.DbType.String);
            p.Add("UsuarioCreador", Data.UsuarioCreador, System.Data.DbType.Int32);
            p.Add("FechaInicioBx", Data.FechaInicioBx, System.Data.DbType.DateTime);
            p.Add("HoraInicioBx", Data.HoraInicioBx, System.Data.DbType.Time);
            p.Add("HoraFinBx", Data.HoraFinBx, System.Data.DbType.Time);
            p.Add("HoraInicioDN", Data.HoraInicioDN, System.Data.DbType.Time);
            p.Add("HoraFinDN", Data.HoraFinDN, System.Data.DbType.Time);
            p.Add("DuracionDN", Data.DuracionDN, System.Data.DbType.Time);
            p.Add("HtmlDiagnostico", Data.HtmlDiagnostico, System.Data.DbType.String);
            p.Add("HtmlLanzamiento", Data.HtmlLanzamiento, System.Data.DbType.String);
            p.Add("HtmlConsultas", Data.HtmlConsultas, System.Data.DbType.String);
            return p;
        }
    }
}
