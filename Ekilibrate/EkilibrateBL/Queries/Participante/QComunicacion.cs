using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.BL.Queries.Participante
{
    public class QComunicacion
    {
        public const string List =
            "SELECT * FROM [PAR.COMUNICACION_ASERTIVA_UNO] WHERE 1 = 1";

        public const string Insert =
            @"
INSERT INTO [dbo].[PAR.COMUNICACION_ASERTIVA_UNO]
            ([ID_PARTICIPANTE],
            [ID_PREGUNTA],
            [EN_ABSOLUTO],
            [UN_POCO],
            [BASTANTE],
            [MUCHO],
            [MUCHISIMO])
OUTPUT INSERTED.[ID_PARTICIPANTE]
VALUES
    ((SELECT ISNULL(MAX(X.ID_PARTICIPANTE),0)+1 FROM [dbo].[PAR.COMUNICACION_ASERTIVA_UNO] X),
    @ID_PREGUNTA,
@EN_ABSOLUTO,
@UN_POCO,
@BASTANTE,
@MUCHO,
@MUCHISIMO)";

        public const string Update =
            @"UPDATE [dbo].[PAR.COMUNICACION_ASERTIVA_UNO]
SET [ID_PREGUNTA]=@ID_PREGUNTA,
            [EN_ABSOLUTO]=@EN_ABSOLUTO,
            [UN_POCO]=@UN_POCO,
            [BASTANTE]=@BASTANTE,
            [MUCHO]=@MUCHO,
            [MUCHISIMO]=@MUCHISIMO
WHERE [ID_PARTICIPANTE]=@ID_PARTICIPANTE";

        public const string Delete =
            @"DELETE [dbo].[PAR.COMUNICACION_ASERTIVA_UNO]
WHERE [ID_PARTICIPANTE]=@ID_PARTICIPANTE";


    }
}
