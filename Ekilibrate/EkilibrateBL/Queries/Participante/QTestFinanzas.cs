using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.BL.Queries.Participante
{
    class QTestFinanzas
    {
        public const string Preguntas =
            @"
SELECT * FROM [dbo].[PAR.PreguntaFinanzas]";

        public const string Respuestas =
            @"
SELECT a.*, IIF(ISNULL(b.ParticipanteId,0)=0,0,1) Seleccionado FROM [dbo].[PAR.RespuestaFinanzas] a
 LEFT JOIN (SELECT * FROM [dbo].[PAR.TestFinanzas] t where t.ParticipanteId = @ParticipanteId) b ON b.PreguntaId = a.PreguntaId AND b.RespuestaId = a.Id  
WHERE a.PreguntaId = @PreguntaId";

        public const string GetOne =
            @"
SELECT * FROM [dbo].[PAR.TestFinanzas]
 WHERE ParticipanteId = @ParticipanteId
   AND PreguntaId = @PreguntaId";

        public const string Insert =
            @"
INSERT INTO [dbo].[PAR.TestFinanzas]
            ([ParticipanteId],
            [PreguntaId],
            [RespuestaId])
VALUES
    (@ParticipanteId,
    @PreguntaId,
    @RespuestaId)";

        public const string Update =
            @"
UPDATE [dbo].[PAR.TestFinanzas]
   SET [ParticipanteId]=@ParticipanteId,
       [PreguntaId]=@PreguntaId,
       [RespuestaId]=@RespuestaId
WHERE ParticipanteId = @ParticipanteId
  AND PreguntaId = @PreguntaId";
    }
}
