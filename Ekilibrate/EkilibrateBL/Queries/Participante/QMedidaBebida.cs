using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.BL.Queries.Participante
{
    class QMedidaBebida
    {
        public const string List =
                 @"
                 	SELECT S.MEDIDA, s.ID_MEDIDA ID_MEDIDA, IIF( ISNULL(pa.ID_PARTICIPANTE,0) = 0,0,1) Seleccionado , pa.RESPUESTA FROM [PAR.MEDIDA] s
	LEFT JOIN (SELECT * FROM [PAR.MEDIDA_BEBIDA] p WHERE p.ID_PARTICIPANTE = @ID_PARTICIPANTE ) as pa on s.ID_MEDIDA = pa.ID_MEDIDA
                 ";

        public const string Insert =
            @"
INSERT INTO [dbo].[PAR.MEDIDA_BEBIDA]
            ([ID_PARTICIPANTE],
            [ID_MEDIDA],
            [RESPUESTA])
VALUES
    (@ID_PARTICIPANTE,
    @ID_MEDIDA,
@RESPUESTA)";

        public const string Delete =
            @"DELETE [dbo].[PAR.MEDIDA_BEBIDA]
WHERE [ID_PARTICIPANTE]=@ID_PARTICIPANTE
AND [ID_MEDIDA]=@ID_MEDIDA";


    }
}
