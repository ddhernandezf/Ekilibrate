using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.BL.Queries.Participante
{
    class QTemaFinanzas
    {
        public const string Preguntas =
            @"
SELECT a.Id TemaId, a.Nombre, IIF(ISNULL(b.ParticipanteId,0)=0,0,1) Seleccionado FROM [dbo].[PAR.TemaFinanzas] a
 LEFT JOIN (SELECT * FROM [dbo].[PAR.TestTemaFinanzas] t where t.ParticipanteId = @ParticipanteId) b ON b.TemaId = a.Id";

        public const string GetOne =
            @"
SELECT * FROM [dbo].[PAR.TestTemaFinanzas]
 WHERE ParticipanteId = @ParticipanteId
   AND TemaId = @TemaId";

        public const string Insert =
            @"
INSERT INTO [dbo].[PAR.TestTemaFinanzas]
            ([ParticipanteId],
            [TemaId],
            [Interes])
VALUES
    (@ParticipanteId,
    @TemaId,
    1)";

        public const string Delete =
            @"
DELETE FROM [dbo].[PAR.TestTemaFinanzas]
 WHERE ParticipanteId = @ParticipanteId
   AND TemaId = @TemaId";
    }
}
