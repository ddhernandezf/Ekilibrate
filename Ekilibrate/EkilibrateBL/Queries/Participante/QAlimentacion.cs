using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.BL.Queries.Participante
{
    public class QAlimentacion
    {
        public const string List =
            "SELECT * FROM [PAR.ALIMENTACION] WHERE [ID_PARTICIPANTE]=@ID_PARTICIPANTE";

        public const string Insert =
            @"
INSERT INTO [dbo].[PAR.ALIMENTACION]
            ([ID_PARTICIPANTE],
            [DESAYUNO],
            [REFACCION_AM],
            [ALMUERZO],
            [REFACCION_TARDE],
            [CENA],
            [REFACCION_NOCHE],
            [ID_VASOS],
            [CUCHARADAS_DIARIAS],
            [SAL],
            [COMIDA_FAVORITA],
            [COMIDA_NO_FAVORITA],
            [COMIDA_DANINA])
VALUES
    (@ID_PARTICIPANTE,
    @DESAYUNO,
@REFACCION_AM,
@ALMUERZO,
@REFACCION_TARDE,
@CENA,
@REFACCION_NOCHE,
@ID_VASOS,
@CUCHARADAS_DIARIAS,
@SAL,
@COMIDA_FAVORITA,
@COMIDA_NO_FAVORITA,
@COMIDA_DANINA)";

        public const string Update =
            @"UPDATE [dbo].[PAR.ALIMENTACION]
SET [DESAYUNO]=@DESAYUNO,
            [REFACCION_AM]=@REFACCION_AM,
            [ALMUERZO]=@ALMUERZO,
            [REFACCION_TARDE]=@REFACCION_TARDE,
            [CENA]=@CENA,
            [REFACCION_NOCHE]=@REFACCION_NOCHE,
            [ID_VASOS]=@ID_VASOS,
            [CUCHARADAS_DIARIAS]=@CUCHARADAS_DIARIAS,
            [SAL]=@SAL,
            [COMIDA_FAVORITA]=@COMIDA_FAVORITA,
            [COMIDA_NO_FAVORITA]=@COMIDA_NO_FAVORITA,
            [COMIDA_DANINA]=@COMIDA_DANINA
WHERE [ID_PARTICIPANTE]=@ID_PARTICIPANTE";

        public const string Delete =
            @"DELETE [dbo].[PAR.ALIMENTACION]
WHERE [ID_PARTICIPANTE]=@ID_PARTICIPANTE";


    }
}
