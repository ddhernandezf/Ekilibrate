using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.BL.Queries.Administrador
{
    public class QCiclo
    {
        public const string GetOne =
            @"
SELECT * 
  FROM [PR.Ciclo] 
 WHERE Id = @Id";

        public const string GetByProyecto =
            @"
SELECT * 
  FROM [PR.Ciclo] 
 WHERE ProyectoId = @ProyectoId";

        public const string List =
            "SELECT * FROM [PR.Ciclo] WHERE 1=1 ";

        public const string Insert =
            @"
INSERT INTO [dbo].[PR.Ciclo]
       ([Id],
        [ProyectoId], 
        [FechaInicio],
        [FechaFin],
        [Finalizado],
        [No])
 OUTPUT INSERTED.[Id]
 VALUES ((SELECT ISNULL(MAX(x.Id), 0) + 1 FROM [dbo].[PR.Ciclo] x),
         @ProyectoId,
         @FechaInicio,
         @FechaFin,
         @Finalizado,
         @No)";

        public const string Update =
            @"
UPDATE [dbo].[PR.Ciclo]
   SET [ProyectoId] = @ProyectoId, 
       [FechaInicio] = @FechaInicio,
       [FechaFin] = @FechaFin,
       [Finalizado] = @Finalizado,
       [No] = @No
WHERE [Id] = @Id";

        public const string Delete =
            @"
DELETE [dbo].[PR.Ciclo]
WHERE [Id] = @Id";
    }
}
