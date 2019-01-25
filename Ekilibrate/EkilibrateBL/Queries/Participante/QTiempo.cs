using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.BL.Queries.Participante
{
    public class QTiempo
    {
        public const string List =
            "SELECT * FROM [PAR.TIEMPO] WHERE [ID_PARTICIPANTE]=@ID_PARTICIPANTE";

        public const string Insert =
            @"
INSERT INTO [dbo].[PAR.TIEMPO]
            ([ID_PARTICIPANTE],
            [ID_PREGUNTA],
            [SIEMPRE],
            [FRECUENTE],
            [CASI_NUNCA],
            [NUNCA])
OUTPUT INSERTED.[ID_PARTICIPANTE]
VALUES
    ((SELECT ISNULL(MAX(X.ID_PARTICIPANTE),0)+1 FROM [dbo].[PAR.TIEMPO] X),
    @ID_PREGUNTA,
@SIEMPRE,
@CASI_NUNCA,
@NUNCA)";

        public const string Update =
            @"UPDATE [dbo].[PAR.TIEMPO]
SET [ID_PREGUNTA]=@ID_PREGUNTA,
            [SIEMPRE]=@SIEMPRE,
            [FRECUENTE]=@FRECUENTE,
            [CASI_NUNCA]=@CASI_NUNCA,
            [NUNCA]=@NUNCA
WHERE [ID_PARTICIPANTE]=@ID_PARTICIPANTE";

        public const string Delete =
            @"DELETE [dbo].[PAR.TIEMPO]
WHERE [ID_PARTICIPANTE]=@ID_PARTICIPANTE";


    }
}
