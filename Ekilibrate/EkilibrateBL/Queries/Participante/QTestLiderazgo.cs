using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.BL.Queries.Participante
{
    public class QTestLiderazgo
    {
        public const string List =
            "SELECT * FROM [PAR.TestLiderazgo] WHERE 1 = 1";

        public const string GetOne =
            @"
SELECT * FROM [PAR.TestLiderazgo] 
WHERE [ParticipanteId]=@ParticipanteId
   AND [PreguntaId]=@PreguntaId";

        public const string Insert =
            @"
INSERT INTO [dbo].[PAR.TestLiderazgo]
            ([ParticipanteId],
             [PreguntaId],
             [Siempre],
             [Frecuentemente],
             [CasiNunca],
             [Nunca])
 VALUES (@ParticipanteId,
         @PreguntaId,
         @Siempre,
         @Frecuentemente,
         @CasiNunca,
         @Nunca)";

        public const string Update =
            @"
UPDATE [dbo].[PAR.TestLiderazgo]
   SET [Siempre]=@Siempre,
       [Frecuentemente]=@Frecuentemente,
       [CasiNunca]=@CasiNunca,
       [Nunca]=@Nunca
 WHERE [ParticipanteId]=@ParticipanteId
   AND [PreguntaId]=@PreguntaId";

        public const string SetSiempre =
            @"
UPDATE [dbo].[PAR.TestLiderazgo]
   SET [Siempre]=1,
       [Frecuentemente]=0,
       [CasiNunca]=0,
       [Nunca]=0
 WHERE [ParticipanteId]=@ParticipanteId
   AND [PreguntaId]=@PreguntaId";

        public const string SetFrecuentemente =
            @"
UPDATE [dbo].[PAR.TestLiderazgo]
   SET [Siempre]=0,
       [Frecuentemente]=1,
       [CasiNunca]=0,
       [Nunca]=0
 WHERE [ParticipanteId]=@ParticipanteId
   AND [PreguntaId]=@PreguntaId";

        public const string SetCasiNunca =
                        @"
UPDATE [dbo].[PAR.TestLiderazgo]
   SET [Siempre]=0,
       [Frecuentemente]=0,
       [CasiNunca]=1,
       [Nunca]=0
 WHERE [ParticipanteId]=@ParticipanteId
   AND [PreguntaId]=@PreguntaId";

        public const string SetNunca =
            @"
UPDATE [dbo].[PAR.TestLiderazgo]
   SET [Siempre]=0,
       [Frecuentemente]=0,
       [CasiNunca]=0,
       [Nunca]=1
 WHERE [ParticipanteId]=@ParticipanteId
   AND [PreguntaId]=@PreguntaId";

        public const string Delete =
            @"DELETE [dbo].[PAR.TestLiderazgo]
WHERE [ParticipanteId]=@ParticipanteId";
    }
}
