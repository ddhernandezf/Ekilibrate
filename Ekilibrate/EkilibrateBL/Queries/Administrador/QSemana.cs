using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.BL.Queries.Administrador
{
    public class QSemana
    {
        public const string List =
            "SELECT * FROM [PR.Semana] WHERE 1=1 ";

        public const string Insert =
            @"
INSERT INTO [dbo].[PR.Semana]
           ([Id],
            [ProyectoId], 
            [Semana],
            [Nombre],
            [FechaInicio],
            [FechaFin])
     VALUES
           ((SELECT ISNULL(MAX(x.Id), 0) + 1 FROM [dbo].[CA.Semana] x),
            @ProyectoId,
            @Semana,
            @Nombre,
            @FechaInicio,
            @FechaFin)";

        public const string Update =
            @"
UPDATE [dbo].[PR.Semana]
SET [ProyectoId] = @ProyectoId, 
    [Semana] = @Semana,
    [Nombre] = @Nombre,
    [FechaInicio] = @FechaInicio,
    [FechaFin] = @FechaFin
WHERE [Id] = @Id";

        public const string Delete =
            @"
DELETE [dbo].[PR.Semana]
WHERE [Id] = @Id";
    }
}
