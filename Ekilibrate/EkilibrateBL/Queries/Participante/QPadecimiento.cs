using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.BL.Queries.Participante
{
    public class QPadecimiento
    {
        public const string List =
             "SELECT * FROM [PAR.CONDICION_TRATAMIENTO] WHERE [ID_PARTICIPANTE] = @ID_PARTICIPANTE";

        public const string Insert =
            @"
INSERT INTO [dbo].[PAR.CONDICION_TRATAMIENTO]
            ([ID_PARTICIPANTE],
            [PADECIMIENTO_PRINCIPAL],
            [PADECIMIENTO_SECUNDARIO],
            [MEDICAMENTO_PRINCIPAL],
            [MEDICAMENTO_SECUNDARIO])
VALUES
    (@ID_PARTICIPANTE,
    @PADECIMIENTO_PRINCIPAL,
    @PADECIMIENTO_SECUNDARIO,
    @MEDICAMENTO_PRINCIPAL,
    @MEDICAMENTO_SECUNDARIO)";

        public const string Update =
            @"
UPDATE [dbo].[PAR.CONDICION_TRATAMIENTO]
SET [PADECIMIENTO_PRINCIPAL]=@PADECIMIENTO_PRINCIPAL,
            [PADECIMIENTO_SECUNDARIO]=@PADECIMIENTO_SECUNDARIO,
            [MEDICAMENTO_PRINCIPAL]=@MEDICAMENTO_PRINCIPAL,
            [MEDICAMENTO_SECUNDARIO]=@MEDICAMENTO_SECUNDARIO
WHERE [ID_PARTICIPANTE]=@ID_PARTICIPANTE";

        public const string Delete =
            @"DELETE [dbo].[PAR.MEDICAMENTO_SECUNDARIO]
WHERE [ID_PARTICIPANTE]=@ID_PARTICIPANTE";


    }
}
