using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.BL.Queries.Participante
{
    public class QComunicacionDos
    {
        public const string List =
            "SELECT * FROM [PAR.COMUNICACION_ASERVITA_DOS] WHERE 1 = 1";

        public const string Insert =
            @"
INSERT INTO [dbo].[PAR.COMUNICACION_ASERVITA_DOS]
            ([ID_PARTICIPANTE],
            [ID_PREGUNTA],
            [SIEMPRE_LO_HAGO],
            [HABITUALMENTEBIT],
            [MITAD_VECES],
            [RARAMENTE],
            [NUNCA])
OUTPUT INSERTED.[ID_PARTICIPANTE]
VALUES
    ((SELECT ISNULL(MAX(X.ID_PARTICIPANTE),0)+1 FROM [dbo].[PAR.COMUNICACION_ASERVITA_DOS] X),
    @ID_PREGUNTA,
@SIEMPRE_LO_HAGO,
@HABITUALMENTEBIT,
@MITAD_VECES,
@RARAMENTE,
@NUNCA)";

        public const string Update =
            @"UPDATE [dbo].[PAR.COMUNICACION_ASERVITA_DOS]
SET [ID_PREGUNTA]=@ID_PREGUNTA,
            [SIEMPRE_LO_HAGO]=@SIEMPRE_LO_HAGO,
            [HABITUALMENTEBIT]=@HABITUALMENTEBIT,
            [MITAD_VECES]=@MITAD_VECES,
            [RARAMENTE]=@RARAMENTE,
            [NUNCA]=@NUNCA
WHERE [ID_PARTICIPANTE]=@ID_PARTICIPANTE";

        public const string Delete =
            @"DELETE [dbo].[PAR.COMUNICACION_ASERVITA_DOS]
WHERE [ID_PARTICIPANTE]=@ID_PARTICIPANTE";


    }
}
