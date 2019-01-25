using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.BL.Queries.Nutricionista
{
    public class QCita
    {
        public const string GetOne = @"
SELECT * 
  FROM [PR.Cita]
 WHERE Id = @Id
";

        public const string GetBefore = @"
SELECT b.* 
  FROM [PR.Cita] a
 INNER JOIN [PR.Cita] b ON b.ParticipanteId = a.ParticipanteId
 WHERE a.Id = @Id
   AND b.Id = (SELECT MAX(Id) 
			   FROM [PR.Cita] y
			  WHERE y.[ParticipanteId] = a.ParticipanteId
				AND y.[Id] < @Id)
";

        public const string GetPresent =
            @"
SELECT C.*
  FROM [PR.Cita] C
 INNER JOIN [PR.Ciclo] Ci 
    ON Ci.Id = C.CicloId 
 WHERE CAST(GETDATE() AS DATE) BETWEEN  CAST(Ci.FechaInicio AS DATE) AND CAST(Ci.FechaFin as DATE) 
   AND ParticipanteId = @ParticipanteId  
";

        public const string List =
            @"
SELECT C.Id, P.Id 'ProgramacionId' ,PA.Id 'ParticipanteId', 
	   LTRIM(RTRIM(PE.PrimerNombre)) + ISNULL(' ' + LTRIM(RTRIM(PE.SegundoNombre)), '')  + ' ' + LTRIM(RTRIM(PE.PrimerApellido)) + ISNULL(' ' + LTRIM(RTRIM(PE.SegundoApellido)) + ISNULL(' de ' + LTRIM(RTRIM(PE.ApellidoCasada)), ''), '') Nombre, 
	   cast(cast(DATEADD(day, + 1, P.Fecha) as date) as varchar)Fecha, C.TipoCitaId, P.NutricionistaId,
	   cast(datepart(HH,P.Fecha) as varchar) +':' + CASE datepart(mi,P.Fecha) when 0 then cast(datepart(mi,P.Fecha) as varchar)+ '0' else cast(datepart(mi,P.Fecha) as varchar) end 'Hora', 
       PA.ProyectoId, P.Cancelada, Ci.No, IIF(p.FechaFin IS NULL, 0, 1) Finalizada
  FROM [PR.CitaProgramacion] P 
 INNER JOIN [PR.Cita] C
	ON P.CitaId = C.Id
 INNER JOIN [PR.Ciclo] Ci
    ON Ci.Id = C.CicloId
 INNER JOIN [PAR.Participante] PA
	ON C.ParticipanteId = PA.Id
 INNER JOIN [GE.Persona] PE 
    ON PA.Id = PE.Id
 WHERE P.NutricionistaId = @NutricionistaId
   --AND CAST(GETDATE() AS DATE) BETWEEN  CAST(DATEADD(day, - 2, Ci.FechaInicio) AS DATE) AND CAST(Ci.FechaFin as DATE)
   AND Ci.No IN (1, 2, 3, 4, 5, 6)
   --AND P.FechaFin IS NULL
 ORDER BY Ci.No DESC, P.Fecha 
/*UNION ALL
SELECT 0 Cancelada, 0 Id, 0 'ProgramacionId', PA.Id 'ParticipanteId', LTRIM(RTRIM(PE.PrimerNombre)) + ISNULL(' ' + LTRIM(RTRIM(PE.SegundoNombre)), '')  + ' ' + LTRIM(RTRIM(PE.PrimerApellido)) + ISNULL(' ' + LTRIM(RTRIM(PE.SegundoApellido)) + ISNULL(' de ' + LTRIM(RTRIM(PE.ApellidoCasada)), ''), '') Nombre, GETDATE() Fecha, 1 TipoCitaId, 7 NutricionistaId, '' 'Hora', PA.ProyectoId
  FROM [PAR.Participante] PA
 INNER JOIN [GE.Persona] PE
    ON PA.Id = PE.Id
 INNER join [PR.Proyecto] PR 
    ON PR.Id = PA.ProyectoId
 INNER join [PR.Nutricionista] NU
    ON NU.ProyectoId = PA.ProyectoId
 WHERE PR.TipoProyectoId IN (1, 3, 4)
   AND PR.Estado IN ('PREPARACIÓN', 'EN EJECUCIÓN')
   AND (NU.ColaboradorId = 1)
   AND EXISTS (SELECT 1 FROM [PR.CitaProgramacion] P 
					INNER JOIN [PR.Cita] C ON P.CitaId = C.Id
                    WHERE C.ParticipanteId = PA.Id
					  AND CAST(@Fecha AS DATE) BETWEEN  CAST(DATEADD(day, - 3, P.fecha) AS DATE) AND CAST(P.fecha as DATE))*/
";
        public const string ListSinCita =
            @"
SELECT 0 Cancelada, 0 Id, 0 'ProgramacionId', PA.Id 'ParticipanteId', LTRIM(RTRIM(PE.PrimerNombre)) + ISNULL(' ' + LTRIM(RTRIM(PE.SegundoNombre)), '')  + ' ' + LTRIM(RTRIM(PE.PrimerApellido)) + ISNULL(' ' + LTRIM(RTRIM(PE.SegundoApellido)) + ISNULL(' de ' + LTRIM(RTRIM(PE.ApellidoCasada)), ''), '') Nombre, GETDATE() Fecha, 
	   1 TipoCitaId, NU.ColaboradorId NutricionistaId, '' 'Hora', PA.ProyectoId
  FROM [PAR.Participante] PA
 INNER JOIN [GE.Persona] PE
    ON PA.Id = PE.Id
 INNER join [PR.Proyecto] PR 
    ON PR.Id = PA.ProyectoId
 INNER join [PR.Nutricionista] NU
    ON NU.ProyectoId = PA.ProyectoId
 WHERE PR.TipoProyectoId IN (1, 3, 4)
   AND PR.Estado IN ('PREPARACIÓN', 'EN EJECUCIÓN')
   AND PA.Baja = 0
   --AND PA.Id IN (53, 80, 570)
   AND (NU.ColaboradorId = @NutricionistaId)
   /*AND EXISTS (SELECT 1 FROM [PR.CitaProgramacion] P 
					INNER JOIN [PR.Cita] C ON P.CitaId = C.Id
                    WHERE C.ParticipanteId = PA.Id
					  AND CAST(GETDATE() AS DATE) BETWEEN  CAST(DATEADD(day, - 3, P.fecha) AS DATE) AND CAST(P.fecha as DATE))*/
";
        public const string ListFin =
            @"
SELECT C.Id, P.Id 'ProgramacionId' ,PA.Id 'ParticipanteId', 
	   LTRIM(RTRIM(PE.PrimerNombre)) + ISNULL(' ' + LTRIM(RTRIM(PE.SegundoNombre)), '')  + ' ' + LTRIM(RTRIM(PE.PrimerApellido)) + ISNULL(' ' + LTRIM(RTRIM(PE.SegundoApellido)) + ISNULL(' de ' + LTRIM(RTRIM(PE.ApellidoCasada)), ''), '') Nombre, 
	   cast(cast(DATEADD(day, + 1, P.Fecha) as date) as varchar)Fecha, C.TipoCitaId, P.NutricionistaId,
	   cast(datepart(HH,P.Fecha) as varchar) +':' + CASE datepart(mi,P.Fecha) when 0 then cast(datepart(mi,P.Fecha) as varchar)+ '0' else cast(datepart(mi,P.Fecha) as varchar) end 'Hora', 
       PA.ProyectoId, P.Cancelada, Ci.No, IIF(p.FechaFin IS NULL, 0, 1) Finalizada
  FROM [PR.CitaProgramacion] P 
 INNER JOIN [PR.Cita] C
	ON P.CitaId = C.Id
 INNER JOIN [PR.Ciclo] Ci
    ON Ci.Id = C.CicloId
 INNER JOIN [PAR.Participante] PA
	ON C.ParticipanteId = PA.Id
 INNER JOIN [GE.Persona] PE 
    ON PA.Id = PE.Id
 WHERE P.NutricionistaId = @NutricionistaId
   AND C.TipoCitaId = 3
   AND PA.Baja = 0
 ORDER BY Ci.No DESC, P.Fecha
";

    }
}
