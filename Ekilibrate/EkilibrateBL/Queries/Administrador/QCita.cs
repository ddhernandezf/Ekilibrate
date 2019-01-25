using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.BL.Queries.Administrador
{
    public class QCita
    {
        public const string List =
            "SELECT * FROM [PR.Cita] WHERE 1=1 ";

        public const string GetOne =
            @"
SELECT * FROM [PR.Cita]
WHERE Id = @CitaId";

        public const string Insert =
            @"
INSERT INTO [dbo].[PR.Cita]
       ([Id],
        [CicloId], 
        [ParticipanteId],
        [ProyectoId],
        [FechaProgramada],
        [NotaGlobal],
        [Ranking])
 OUTPUT INSERTED.[Id]
 VALUES ((SELECT ISNULL(MAX(x.Id), 0) + 1 FROM [dbo].[PR.Cita] x),
        @CicloId, 
        @ParticipanteId,
        @ProyectoId,
        @FechaProgramada,
        @NotaGlobal,
        @Ranking)";

        public const string Update =
            @"
UPDATE [dbo].[PR.Cita]
   SET [CicloId] = @CicloId, 
       [ParticipanteId] = @ParticipanteId,
       [FechaProgramada] = @FechaProgramada,
       [NotaGlobal] = @NotaGlobal,
       [Ranking] = @Ranking
WHERE [Id] = @Id";

        public const string Delete =
            @"
DELETE [dbo].[PR.Cita]
WHERE [Id] = @Id";
    }
}
