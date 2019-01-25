using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.BL.Queries.Participante
{
    public class QPasosDia
    {
        public const string List =
            @"
SELECT p.Id, s.Id SemanaId, d.Id [Dia], @ParticipanteId ParticipanteId, ISNULL(p.Meta, ISNULL([dbo].[f_calcular_meta3] (s.Id, cpa.Id), 0)) Meta, ISNULL(p.Caminados, 0) Caminados, p.FechaRegistro,
	   d.[Nombre] NombreDia, DATEADD(day,d.Id - 1, s.FechaInicio) As Fecha, c.Id IdPasosCompa, cpa.Id As IdCompa, 
	   ISNULL(c.Meta, ISNULL([dbo].[f_calcular_meta3] (s.Id, cpa.Id), 0)) MetaCompa, ISNULL(c.Caminados, 0) CaminadosCompa, cp.PrimerNombre AS NombreCompa,
       convert(nvarchar(MAX), s.FechaInicio, 103) FechaInicio, convert(nvarchar(MAX), s.FechaFin, 103) FechaFin
  FROM [dbo].[GE.Dia] d  
 INNER JOIN [GE.Semana] s ON DATEADD(HOUR, -6 - 24, GETDATE()) BETWEEN s.FechaInicio and DATEADD (DAY, 1, s.FechaFin) 
  LEFT JOIN (SELECT p.Id, p.SemanaId, p.Dia [DiaId], p.Meta,p.Caminados, p.FechaRegistro
			   FROM [PR.PasosDia] p
              WHERE p.ParticipanteId = @ParticipanteId) p ON ISNULL(p.DiaId, d.Id) = d.Id AND p.SemanaId = s.Id
  LEFT JOIN [PAR.Participante] cpa ON cpa.Compa = @ParticipanteId
  LEFT JOIN [GE.Persona] cp ON cp.Id = cpa.Id 
  LEFT JOIN (SELECT p.Id, p.SemanaId, p.Dia [DiaId], p.Meta,p.Caminados, p.FechaRegistro, p.ParticipanteId
			   FROM [PR.PasosDia] p) c ON ISNULL(c.DiaId, d.Id) = d.Id AND c.SemanaId = s.Id AND c.ParticipanteId = cpa.Id
";

        public const string PasosSemanaApp =
            @"
SELECT p.Id, p.SemanaId Week, compa.Id AS CompaId, s.ProyectoId, p.Meta Goal, AVG(pd.Caminados) Average,
       LTRIM(RTRIM(compan.PrimerNombre)) + ISNULL(' ' + LTRIM(RTRIM(compan.SegundoNombre)), '')  + ' ' + LTRIM(RTRIM(compan.PrimerApellido)) + ISNULL(' ' + LTRIM(RTRIM(compan.SegundoApellido)) + ISNULL(' de ' + LTRIM(RTRIM(compan.ApellidoCasada)), ''), '') AS Compa
  FROM [PR.PasosDia] pd
 INNER JOIN [PR.Pasos] p ON p.ParticipanteId = pd.ParticipanteId AND p.SemanaId = pd.SemanaId
 INNER JOIN [PR.Semana] s ON s.Id = pd.SemanaId
 INNER JOIN [PAR.Participante] compa ON compa.Id = pd.ParticipanteId
 INNER JOIN [PAR.Participante] pa ON pa.Id = compa.Id
 INNER JOIN [GE.Persona] compan ON compan.Id = compa.Id
 INNER JOIN [GE.Persona] pn ON pn.Id = pa.Id
 WHERE GETDATE() BETWEEN s.FechaInicio AND DATEADD (day, 1, s.FechaFin) 
   AND pa.Id = @ParticipanteId
 GROUP BY p.Id, p.SemanaId, compa.Id, s.ProyectoId, p.Meta, compan.PrimerNombre, compan.SegundoNombre, compan.PrimerApellido, compan.SegundoApellido, compan.ApellidoCasada";

        public const string PasosDiaApp =
            @"
select p.Dia DayRef, p.Caminados Steps, pa.Meta / 7 AS Goal, 
        IIF(p.Caminados = 0, 0, ROUND((pa.Meta / 7) / p.Caminados, 0)) AS PercentAchieve,
        DATEADD(day,p.Dia - 1, s.FechaInicio) As Date,
		case p.Dia			
			when 1 then 'Lunes'
			when 2 then 'Martes'
			when 3 then 'Miercoles'
			when 4 then 'Jueves'
			when 5 then 'Viernes'
			when 6 then 'Sabado'
            when 7 then 'Domingo'
		end DayName
  from [PR.Semana] s 
 inner join [PR.PasosDia] p on p.SemanaId = s.Id
 inner join [PR.Pasos] pa on pa.SemanaId = s.Id and pa.ParticipanteId = p.ParticipanteId
 where getdate() between s.FechaInicio and DATEADD (day, 1, s.FechaFin)  
   and p.ParticipanteId = @ParticipanteId";

        public const string GetOne =
            @"
SELECT *
  FROM [PR.PasosDia]
 WHERE SemanaId = @SemanaId
   AND ParticipanteId = @ParticipanteId
   AND Dia = @Dia";

        public const string PasosDia =
            @"
select p.*
  from [PR.Semana] s inner join [PR.PasosDia] p on p.SemanaId = s.Id
 where @Fecha = DATEADD(day,p.Dia - 1, s.FechaInicio)
   and p.ParticipanteId = @ParticipanteId";

        public const string Insert =
            @"
INSERT INTO [PR.PasosDia]
VALUES ((SELECT ISNULL(MAX(Id), 0) + 1 FROM [PR.PasosDia]),
        @SemanaId,
        @ParticipanteId,
        @Dia,
        @Meta,
        @Caminados,
        DATEADD(HOUR, -6, GETDATE()))";

        public const string Update =
            @"update	[PR.PasosDia]
   set	Caminados = @Caminados
 where	Id = @Id";

        public const string Delete =
            @"delete from [PR.PasosDia] where Id = @Id";
    }
}
