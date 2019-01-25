using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.BL.Queries.Participante
{
    public class QRiesgo
    {
        public const string List =
            @"SELECT * FROM [PAR.FAC_RIESGO] WHERE [ID_PARTICIPANTE]=@ID_PARTICIPANTE ";

        public const string Insert =
            @"
INSERT INTO [dbo].[PAR.FAC_RIESGO]
([ID_PARTICIPANTE],
[FUMAR],
[CODIGO_FRECUENCIA_FUMAR],
[NUM_CIGARROS],
[BEBER],
[CODIGO_FRECUENTE_BEBER],
[NUMERO_BEBIDA])
VALUES
    (@ID_PARTICIPANTE,
@FUMAR,
@CODIGO_FRECUENCIA_FUMAR,
@NUM_CIGARROS,
@BEBER,
@CODIGO_FRECUENTE_BEBER,
@NUMERO_BEBIDA)";

        public const string Update =
            @"UPDATE [dbo].[PAR.FAC_RIESGO]
SET[FUMAR] =@FUMAR,
[CODIGO_FRECUENCIA_FUMAR]=@CODIGO_FRECUENCIA_FUMAR,
[NUM_CIGARROS]=@NUM_CIGARROS,
[BEBER]=@BEBER,
[CODIGO_FRECUENTE_BEBER]=@CODIGO_FRECUENTE_BEBER,
[NUMERO_BEBIDA]=@NUMERO_BEBIDA
WHERE [ID_PARTICIPANTE]=@ID_PARTICIPANTE";

        public const string Delete=
            @"DELETE [dbo].[PAR.FAC_RIESGO]
WHERE [ID_PARTICIPANTE]=@ID_PARTICIPANTE";
    }
}
