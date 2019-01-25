using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.BL.Queries.Administrador
{
    public class QCitaProgramacion
    {
        public const string List =
            "SELECT * FROM [PR.Cita] WHERE 1=1 ";

        public const string GetOne =
            @"
SELECT * 
  FROM [PR.Cita] 
 WHERE CitaId = @CitaId
";

        public const string Insert =
            @"
INSERT INTO [dbo].[PR.CitaProgramacion]
           ([Id],
            [CitaId], 
            [NutricionistaId],
            [Fecha],
            [Cancelada],
            [FechaInicio],
            [FechaFin])
 VALUES ((SELECT ISNULL(MAX(x.Id), 0) + 1 FROM [dbo].[PR.CitaProgramacion] x),
         @CitaId, 
         @NutricionistaId,
         @Fecha,
         @Cancelada,
         @FechaInicio,
         @FechaFin)";

        public const string Update =
            @"
UPDATE [dbo].[PR.Cita]
   SET [CicloId] = @CicloId, 
       [ParticipanteId] = @ParticipanteId,
       [FechaProgramada] = @FechaProgramada,
       [NotaGlobal] = @NotaGlobal,
       [Ranking] = @Ranking
WHERE [Id] = @Id";

        public const string IniciarCita =
            @"
UPDATE [dbo].[PR.CitaProgramacion]
   SET [FechaInicio] = GETDATE()
 WHERE [CitaId] = @CitaId
   AND [Cancelada] = 0";

        public const string FinalizarCita =
            @"
UPDATE [dbo].[PR.CitaProgramacion]
   SET [FechaFin] = GETDATE()
 WHERE [CitaId] = @CitaId
   AND [Cancelada] = 0";

        public const string UpdateCancelado =
            @"
UPDATE [dbo].[PR.CitaProgramacion]
   SET [Cancelada] = @Cancelada
WHERE [Id] = @Id
   AND [NutricionistaId] = @NutricionistaId
   AND [CitaId] = @CitaId
";

        public const string InsertCancelado =
            @"
INSERT INTO [dbo].[PR.CitaProgramacion]
           ([Id],
            [CitaId], 
            [NutricionistaId],
            [Fecha],
            [Cancelada],
            [FechaInicio],
            [FechaFin])
     SELECT 
        ISNULL(MAX(x.Id), 0) + 1 Id,
            @CitaId, 
            @NutricionistaId,
            @Fecha,
            @Cancelada,
            @FechaInicio,
            @FechaFin
    FROM [PR.CitaProgramacion] x
        ";

        public const string Delete =
            @"
DELETE [dbo].[PR.Cita]
WHERE [Id] = @Id";
    }
}
