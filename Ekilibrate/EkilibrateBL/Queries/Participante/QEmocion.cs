using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.BL.Queries.Participante
{
    public class QEmocion
    {
        public const string List =
            "SELECT * FROM [PAR.ANSIEDAD] WHERE [ID_PARTICIPANTE] = @ID_PARTICIPANTE ";

        public const string Insert =
            @"
INSERT INTO [dbo].[PAR.ANSIEDAD]
            ([ID_PARTICIPANTE],
            [ID_ANSIEDAD],
            [RESPUESTA])
OUTPUT INSERTED.[ID_PARTICIPANTE]
    VALUES          
        ((SELECT ISNULL(MAX(x.ID_PARTICIPANTE),0) + 1 FROM [dbo].[PAR.ANSIEDAD] X),
        @ID_ANSIEDAD,
        @RESPUESTA)";

        public const string Update =
            @"UPDATE [dbo].[PAR.ANSIEDAD]
SET [ID_ANSIEDAD]=@ID_ANSIEDAD,
            [RESPUESTA]=@RESPUESTA
WHERE [ID_PARTICIPANTE]=@ID_PARTICIPANTE";

        public const string Delete =
            @"DELETE [dbo].[PAR.ANSIEDAD]
WHERE [ID_PARTICIPANTE] =@ID_PARTICIPANTE";

    }
}
