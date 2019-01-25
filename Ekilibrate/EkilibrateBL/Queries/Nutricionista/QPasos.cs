using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.BL.Queries.Nutricionista
{
    public class QPasos
    {
        public const string List =
            @"
SELECT a.CitaId, d.Nombre, d.Apellido, a.Fecha
  FROM [dbo].[PR.CitaProgramacion] a
  INNER JOIN [dbo].[PR.Cita] b ON b.Id = a.CitaDiaId
  LEFT JOIN [dbo].[GE.Persona] d ON d.Id = b.ParticipanteId
 WHERE a.NutricionistaId = @NutricionistaId
   AND a.Fecha = @Fecha";
    }
}
