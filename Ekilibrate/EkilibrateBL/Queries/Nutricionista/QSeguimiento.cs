using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.BL.Queries.Nutricionista
{
    public class QSeguimiento
    {
        public const string GetOne =
                        @"
SELECT *
  FROM [dbo].[NU.Seguimiento]
 WHERE CitaId = @CitaId
";
        public const string Get =
                        @"
SELECT b.[ParticipanteId], @CitaId CitaId, ISNULL(a.[NutricionistaId], sa.NutricionistaId) NutricionistaId, 
	   ISNULL(a.[ComentariosRelevantes], sa.[ComentariosRelevantes]) [ComentariosRelevantes], 
	   c.[No]
  FROM [dbo].[PR.Cita] b
  LEFT JOIN [dbo].[PR.Ciclo] c ON c.Id = b.CicloId
  LEFT JOIN [dbo].[NU.Seguimiento] a ON a.[CitaId] = @CitaId
  LEFT JOIN (SELECT * 
			    FROM [dbo].[NU.Seguimiento] x
			   WHERE x.[CitaId] = (SELECT MAX(CitaId) 
									 FROM [NU.Seguimiento] y
									WHERE y.[CitaId] < @CitaId
									  and y.ParticipanteId = x.ParticipanteId)) sa ON sa.ParticipanteId = b.ParticipanteId
 WHERE b.Id = @CitaId
";
        public const string GetActual =
                        @"
DECLARE @CitaId INT;
SELECT @CitaId = b.Id
  FROM [dbo].[PR.Cita] b
 INNER JOIN [PR.Ciclo] Ci 
    ON Ci.Id = b.CicloId  
 WHERE b.ParticipanteId = @ParticipanteId
   AND CAST(GETDATE() AS DATE) BETWEEN  CAST(Ci.FechaInicio AS DATE) AND CAST(Ci.FechaFin as DATE);
SELECT b.[ParticipanteId], @CitaId CitaId, ISNULL(a.[NutricionistaId], sa.NutricionistaId) NutricionistaId, 
	   ISNULL(a.[ComentariosRelevantes], sa.[ComentariosRelevantes]) [ComentariosRelevantes], 
	   --[ComentariosRelevantes],
	   c.[No]
  FROM [dbo].[PR.Cita] b
  LEFT JOIN [dbo].[PR.Ciclo] c ON c.Id = b.CicloId
  LEFT JOIN [dbo].[NU.Seguimiento] a ON a.[CitaId] = @CitaId
  LEFT JOIN (SELECT * 
			    FROM [dbo].[NU.Seguimiento] x
			   WHERE x.[CitaId] = (SELECT MAX(CitaId) 
									 FROM [NU.Seguimiento] y
									WHERE y.[CitaId] < @CitaId
									  and y.ParticipanteId = x.ParticipanteId)) sa ON sa.ParticipanteId = b.ParticipanteId
 WHERE b.Id = @CitaId
";


        public const string Insert =
            @"
INSERT INTO [dbo].[NU.Seguimiento]
           ([ParticipanteId]
           ,[CitaId]
           ,[NutricionistaId]
           ,[ComentariosRelevantes])
     VALUES
           (@ParticipanteId
           ,@CitaId
           ,@NutricionistaId
           ,@ComentariosRelevantes)
";

        public const string Update =
    @"
UPDATE [dbo].[NU.Seguimiento]
   SET 
      [NutricionistaId] =			@NutricionistaId
      ,[ComentariosRelevantes] =	@ComentariosRelevantes
 WHERE [ParticipanteId] =			@ParticipanteId AND
      [CitaId] =					@CitaId
";

    }
}
