using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.BL.Queries.Participante
{
    class QPreguntaLiderazgo
    {
        public const string List =
                 @"
SELECT s.Id PreguntaId, s.Nombre, ISNULL(pa.Siempre, 0) Siempre, ISNULL(pa.Frecuentemente, 0) Frecuentemente, ISNULL(pa.CasiNunca, 0) CasiNunca, ISNULL(pa.Nunca, 0) Nunca 
  FROM [PAR.PreguntaLiderazgo] s
  LEFT JOIN (SELECT * FROM [PAR.TestLiderazgo] p WHERE p.ParticipanteId = @ParticipanteId) as pa 
	ON s.Id = pa.PreguntaId
";
    }
}