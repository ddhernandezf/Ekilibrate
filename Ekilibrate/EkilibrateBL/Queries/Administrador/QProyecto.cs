using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.BL.Queries.Administrador
{
    public class QProyecto
    {
        public const string List =
        @"
SELECT a.*, b.Nombre AS EmpresaNombre, c.Nombre AS TipoProyecto
  FROM [PR.Proyecto] a 
 INNER JOIN [ADM.Empresa] b ON b.Id = a.EmpresaId
 INNER JOIN [CA.TipoProyecto] c ON c.Id = a.TipoProyectoId
 WHERE 1=1 ";

        public const string ListByEmpresa =
        "SELECT * FROM [PR.Proyecto] WHERE EmpresaId=@EmpresaId and estado = 'CREACIÓN DE PARTICIPANTES'";

        public const string ListByEstado =
        @"
SELECT * 
  FROM [PR.Proyecto] 
 WHERE Estado = @Estado
";

        public const string ProyectoDetailed =
        @"
SELECT a.*, b.Nombre AS EmpresaNombre, c.Nombre AS TipoProyecto
  FROM [PR.Proyecto] a 
 INNER JOIN [ADM.Empresa] b ON b.Id = a.EmpresaId
 INNER JOIN [CA.TipoProyecto] c ON c.Id = a.TipoProyectoId
 WHERE a.Id = @Id ";

        public const string ProyectoByCodigo =
        @"
SELECT a.*, b.Nombre AS EmpresaNombre 
  FROM [PR.Proyecto] a 
 INNER JOIN [ADM.Empresa] b ON b.Id = a.EmpresaId
 WHERE a.CodigoRegistro = @CodigoRegistro ";

        public const string Insert =
        @" INSERT INTO [dbo].[PR.Proyecto]
           ([Id]
           ,[EmpresaId]
           ,[Estado]
           ,[FechaInicio]
           ,[FechaFin]
           ,[NoSemanas]
           ,[NoParticipantes]
           ,[NoEnfermeras]
           ,[NoFacilitadores]
           ,[NoAsistentes]
           ,[NoConsultasNutricionales]
           ,[FrecuenciaConsultas]
           ,[FrecuenciaAlertas]
           ,[FrecuenciaAlertasUnidad]
           ,[FrecuenciaConsultasUnidad]
           ,[Color]
           ,[CrearUsuarios]
           ,[LogoURL]
           ,[AseguradoraId]
           ,[IndiceReclamos]
           ,[NoParticipantesPorGrupo]
           ,[FechaCorreoInvitacion]
           ,[FechaPrimeraCitaDiagnostico]
           ,[CitasProgramadas]
           ,[MetasCalculadas]
           ,[FechaInicioConsultas]
           ,[HoraInicioConsultas]
           ,[HoraFinConsultas]
           ,[DuracionConsultas]
           ,[NoNutricionistas]
           ,[TipoProyectoId]
           ,[Nombre]
           ,[CodigoRegistro]
           ,[Correo]
           ,[PasswordCorreo]
           ,[UsuarioCreador]
           ,[FechaInicioBx]
           ,[HoraInicioBx]
           ,[HoraFinBx]
           ,[HoraInicioDN]
           ,[HoraFinDN]
           ,[DuracionDN]
           ,[HtmlDiagnostico]
           ,[HtmlLanzamiento]
           ,[HtmlConsultas]
)
OUTPUT INSERTED.[Id]
     VALUES
           ((SELECT ISNULL(MAX(x.Id), 0) + 1 FROM [dbo].[PR.Proyecto] x)
           ,@EmpresaId
           ,@Estado
           ,@FechaInicio
           ,@FechaFin
           ,@NoSemanas
           ,@NoParticipantes
           ,@NoEnfermeras
           ,@NoFacilitadores
           ,@NoAsistentes
           ,@NoConsultasNutricionales
           ,@FrecuenciaConsultas
           ,@FrecuenciaAlertas
           ,@FrecuenciaAlertasUnidad
           ,@FrecuenciaConsultasUnidad
           ,@Color
           ,@CrearUsuarios
           ,@LogoURL
           ,@AseguradoraId
           ,@IndiceReclamos
           ,@NoParticipantesPorGrupo
           ,@FechaCorreoInvitacion
           ,@FechaPrimeraCitaDiagnostico
           ,@CitasProgramadas
           ,@MetasCalculadas
           ,@FechaInicioConsultas
           ,@HoraInicioConsultas
           ,@HoraFinConsultas
           ,@DuracionConsultas
           ,@NoNutricionistas
           ,@TipoProyectoId
           ,@Nombre
           ,@CodigoRegistro
           ,@Correo
           ,@PasswordCorreo
           ,@UsuarioCreador
           ,@FechaInicioBx
           ,@HoraInicioBx
           ,@HoraFinBx
           ,@HoraInicioDN
           ,@HoraFinDN
           ,@DuracionDN
           ,@HtmlDiagnostico
           ,@HtmlLanzamiento
           ,@HtmlConsultas)
";

        public const string Update = @"
UPDATE [dbo].[PR.Proyecto]
   SET [EmpresaId] = @EmpresaId
        ,[Estado] = @Estado
        ,[FechaInicio] = @FechaInicio
        ,[FechaFin] = @FechaFin
        ,[NoSemanas] = @NoSemanas
        ,[NoParticipantes] = @NoParticipantes
        ,[NoEnfermeras] = @NoEnfermeras
        ,[NoFacilitadores] = @NoFacilitadores
        ,[NoAsistentes] = @NoAsistentes
        ,[NoConsultasNutricionales] = @NoConsultasNutricionales
        ,[FrecuenciaConsultas] = @FrecuenciaConsultas
        ,[FrecuenciaAlertas] = @FrecuenciaAlertas
        ,[FrecuenciaAlertasUnidad] = @FrecuenciaAlertasUnidad
        ,[FrecuenciaConsultasUnidad] = @FrecuenciaConsultasUnidad
        ,[Color] = @Color
        ,[CrearUsuarios] = @CrearUsuarios
        ,[LogoURL] = @LogoURL
        ,[AseguradoraId] = @AseguradoraId
        ,[IndiceReclamos] = @IndiceReclamos
        ,[NoParticipantesPorGrupo] = @NoParticipantesPorGrupo
        ,[FechaCorreoInvitacion] = @FechaCorreoInvitacion
        ,[FechaPrimeraCitaDiagnostico] = @FechaPrimeraCitaDiagnostico
        ,[CitasProgramadas] = @CitasProgramadas
        ,[MetasCalculadas] = @MetasCalculadas
        ,[FechaInicioConsultas] = @FechaInicioConsultas
        ,[HoraInicioConsultas] = @HoraInicioConsultas
        ,[HoraFinConsultas] = @HoraFinConsultas
        ,[DuracionConsultas] = @DuracionConsultas
        ,[NoNutricionistas] = @NoNutricionistas
        ,[TipoProyectoId] = @TipoProyectoId
        ,[Nombre] = @Nombre
        ,[CodigoRegistro] = @CodigoRegistro
        ,[Correo] = @Correo
        ,[PasswordCorreo] = @PasswordCorreo
        ,[UsuarioCreador] = @UsuarioCreador
        ,[FechaInicioBx] = @FechaInicioBx
        ,[HoraInicioBx] = @HoraInicioBx
        ,[HoraFinBx] = @HoraFinBx
        ,[HoraInicioDN] = @HoraInicioDN
        ,[HoraFinDN] = @HoraFinDN
        ,[DuracionDN] = @DuracionDN
        ,[HtmlDiagnostico] = @HtmlDiagnostico
        ,[HtmlLanzamiento] = @HtmlLanzamiento
        ,[HtmlConsultas] = @HtmlConsultas
 WHERE Id = @Id;";

        public const string Delete = @"

        DELETE FROM [dbo].[PR.Proyecto]
                WHERE Id = @Id;
";
    }
}
