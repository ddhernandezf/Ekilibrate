using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.BL.Queries.Nutricionista
{
    public class QSeguimientoAspectos
    {
        public const string GetOne =
            @"
SELECT *
  FROM [NU.SeguimientoAspectos]
 WHERE [CitaId] = @CitaId
   AND [AspectoId] = @AspectoId;
";

        public const string ListAspectos =
            @"
SELECT a.AspectoId, a.Aspecto, a.Area, a.ParticipanteId, @CitaId CitaId, a.Diagnostico, sa.Logro, 
       IIF(saaa.Logro IS NULL, a.Diagnostico, saaa.Logro) Base,
	   IIF(sa.Meta IS NULL, CASE WHEN a.AspectoId = 10 THEN ROUND(ISNULL(dbo.f_calcular_meta3(s.Id, @ParticipanteId), 0), 0)
								 WHEN a.AspectoId IN (13, 14) THEN 1
								 ELSE 0 
							END, sa.Meta) Meta,
       saa.CitaId CitaAnterior, 
	   IIF(saa.Logro IS NULL, CASE WHEN a.AspectoId = 10 THEN rp.Caminados
								 WHEN a.AspectoId IN (13, 14) THEN 1
								 ELSE 0 
							END, saa.Logro) LogroAnterior,
	   IIF(saa.Meta IS NULL, CASE WHEN a.AspectoId = 10 THEN rp.Meta
								 WHEN a.AspectoId IN (13, 14) THEN 1
								 ELSE 0 
							END, saa.Meta) MetaAnterior,
	   sa.Observaciones, saa.Observaciones ObservacionesAnterior, sea.Id, c.FechaProgramada,
       IIF(ISNULL(sa.AspectoId,0) = 0,1,0) Nuevo 
  FROM [dbo].[vw_DiagnosticoAspectos] a
  LEFT JOIN  (SELECT * 
			    FROM [NU.SeguimientoAspectos] x
			   WHERE x.[ParticipanteId] = @ParticipanteId
				 AND x.[CitaId] = @CitaId) AS  sa
	ON sa.AspectoId = a.AspectoId 
  LEFT JOIN  (SELECT * 
			    FROM [NU.SeguimientoAspectos] x
			   WHERE x.[CitaId] = (SELECT MAX(CitaId) 
									 FROM [NU.SeguimientoAspectos] y
									WHERE y.[ParticipanteId] = @ParticipanteId
									  AND y.[CitaId] < @CitaId)
			  ) AS  saa
    ON saa.AspectoId = a.AspectoId
  LEFT JOIN  (SELECT x.* 
			    FROM [NU.SeguimientoAspectos] x
			   INNER JOIN  (SELECT TOP 2 y.CitaId, Row_Number() OVER (ORDER BY y.CitaId DESC) AS rownum
							  FROM [NU.SeguimientoAspectos] y
							 WHERE y.[ParticipanteId] = @ParticipanteId
							   AND y.[CitaId] < @CitaId
							 GROUP BY y.CitaId) y ON y.CitaId = x.CitaId
			   WHERE y.rownum = 2
			  ) AS  saaa
    ON saaa.AspectoId = a.AspectoId
  LEFT JOIN [dbo].[PR.Cita] c ON c.Id = @CitaId
  LEFT JOIN [dbo].[PR.Semana] s ON c.FechaProgramada BETWEEN s.FechaInicio AND s.FechaFin
  LEFT JOIN [dbo].[PR.Semana] sea ON DATEADD(day, -7, c.FechaProgramada) BETWEEN sea.FechaInicio AND sea.FechaFin
  LEFT JOIN [dbo].[vw_PasosSemana] rp ON rp.Id = @ParticipanteId AND rp.SemanaId = sea.Id
 WHERE a.ParticipanteId = @ParticipanteId
 ORDER BY a.Area, a.AspectoId
            ";
        
        public const string Insert =
            @"
INSERT INTO [dbo].[NU.SeguimientoAspectos]
           ([ParticipanteId]
           ,[CitaId]
           ,[AspectoId]
           ,[Logro]
           ,[Meta]
           ,[Observaciones])
     VALUES
           (@ParticipanteId
           ,@CitaId
           ,@AspectoId
           ,@Logro
           ,@Meta
           ,@Observaciones) 
";

        public const string Update =
    @"
UPDATE [dbo].[NU.SeguimientoAspectos]
   SET 
       [Logro] =    @Logro
      ,[Meta] =     @Meta
      ,[Observaciones] = @Observaciones
 WHERE [ParticipanteId] = @ParticipanteId
      AND [CitaId] = @CitaId 
	  AND [AspectoId] = @AspectoId
";

    }
}
