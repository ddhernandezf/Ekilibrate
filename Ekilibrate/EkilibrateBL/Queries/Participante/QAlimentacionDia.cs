using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.BL.Queries.Participante
{
    public class QAlimentacionDia
    {
        public const string List =
            @"
SELECT ISNULL(ad.Id, ROW_NUMBER() OVER(ORDER BY d.Id, ga.Id ASC)) AS Id, s.Id SemanaId, d.Id [Dia], @ParticipanteId ParticipanteId, ga.ID AS GrupoAlimentoId, ga.Nombre AS NombreAlimento,
	   ad.Comido, 
       CASE WHEN ga.Id = 1 THEN ISNULL(p.Lacteos, 0)
			WHEN ga.Id = 2 THEN ISNULL(p.Cereales, 0)
			WHEN ga.Id = 3 THEN ISNULL(p.Vegetales, 0)
			WHEN ga.Id = 4 THEN ISNULL(p.Frutas, 0)
			WHEN ga.Id = 5 THEN ISNULL(p.Carnes, 0)
			WHEN ga.Id = 6 THEN ISNULL(p.Grasas, 0)
			WHEN ga.Id = 7 THEN ISNULL(p.Azucares, 0)
			ELSE 0
	   END Meta, 
       d.[Nombre] NombreDia, DATEADD(day,d.Id - 1, s.FechaInicio) As Fecha,
	   IIF(ISNULL(ad.Id, 0) = 0, 1, 0) AS Nuevo, d.SortableName
  FROM [dbo].[GE.Dia] d  
 INNER JOIN [GE.Semana] s ON DATEADD(HOUR, -6 - 24, GETDATE()) BETWEEN s.FechaInicio and DATEADD (DAY, 1, s.FechaFin) 
 INNER JOIN [CA.GrupoAlimento] ga on 1 = 1
  LEFT JOIN (SELECT a.Id, a.SemanaId, a.Dia [DiaId], a.Meta, a.Comido, a.GrupoAlimentoId
			   FROM [PR.AlimentacionDia] a
              WHERE a.ParticipanteId = @ParticipanteId) ad ON ISNULL(ad.DiaId, d.Id) = d.Id AND ad.SemanaId = s.Id AND ad.GrupoAlimentoId = ga.Id
  LEFT JOIN [dbo].[NU.PlanAlimentacion] p ON p.ParticipanteId = @ParticipanteId AND p.CitaId = (SELECT MAX(x.CitaId) FROM [dbo].[NU.PlanAlimentacion] x WHERE x.ParticipanteId = @ParticipanteId)
 WHERE ga.Id < 8
 ORDER BY d.Id, ga.Id
";

        public const string AlimentacionSemanaApp =
            @"
SELECT s.Semana AS Week,
	   a.Meta GoalCalories, 
	   AVG(x.CaloriasDia) AS ConsumedCalories
  FROM [PR.Alimentacion] a 
 INNER JOIN (SELECT	ad.ParticipanteId, ad.SemanaId, ad.Dia, SUM(ad.Comido * ga.Calorias) CaloriasDia
			   FROM [PR.AlimentacionDia] ad 			  
			  INNER JOIN [CA.GrupoAlimento] ga on ga.Id = ad.GrupoAlimentoId
			 GROUP BY ad.ParticipanteId, ad.SemanaId, ad.Dia) x 
	ON x.SemanaId = a.SemanaId AND	x.ParticipanteId = a.ParticipanteId
 INNER JOIN [PR.Semana] s on s.Id = a.SemanaId
 WHERE GETDATE() BETWEEN s.FechaInicio AND DATEADD (day, 1, s.FechaFin) 
   AND a.ParticipanteId = @ParticipanteId
 GROUP BY s.Semana, a.Meta";

        public const string AlimentacionDiaApp =
            @"
select ad.Dia DayRef, 
		case ad.Dia			
			when 1 then 'Lunes'
			when 2 then 'Martes'
			when 3 then 'Miercoles'
			when 4 then 'Jueves'
			when 5 then 'Viernes'
			when 6 then 'Sabado'
			when 7 then 'Domingo'
		end DayName, 
		DATEADD(DAY,ad.Dia - 1, s.FechaInicio) As Date,
		ad.GrupoAlimentoId Category, 
		ga.Nombre CategoryName,
		ad.Meta GoalPortions, 
		ad.Comido ConsumedPortions,		
		ad.Comido * ga.Calorias AS ConsumedCalories
  from	[PR.AlimentacionDia] ad 
  inner join [PR.Semana] s on s.Id = ad.SemanaId
  inner join [CA.GrupoAlimento] ga on ga.Id = ad.GrupoAlimentoId
 where	getdate() between s.FechaInicio and DATEADD (day, 1, s.FechaFin) 
   and	ad.ParticipanteId = @ParticipanteId";


        public const string Insert =
            @"insert into [PR.AlimentacionDia] (Id,ParticipanteId,GrupoAlimentoId,SemanaId,Dia,Meta,Comido)
values ((SELECT ISNULL(MAX(x.Id), 0) + 1 FROM [dbo].[PR.AlimentacionDia] x),
@ParticipanteId,
@GrupoAlimentoId,
@SemanaId,
@Dia,
@Meta,
@Comido)";

        public const string Update =
            @"update	[PR.AlimentacionDia]
   set	Comido = @Comido
 where Id = @Id";

        public const string Delete =
            @"delete from [PR.AlimentacionDia] where Id = @Id";
    }
}
