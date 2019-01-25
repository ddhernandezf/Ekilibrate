using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.BL.Queries.Participante
{
    class QRespAnsiedad
    {
        public const string Get =
        @"
SELECT *
  FROM [PAR.ANSIEDAD] 
 WHERE ID_PARTICIPANTE = @ID_PARTICIPANTE
   AND ID_ANSIEDAD = @ID_ANSIEDAD
                 ";

        public const string List =
        @"
                 	SELECT S.ANSIEDAD, s.ID_ANSIEDAD ID_ANSIEDAD, IIF( ISNULL(pa.ID_PARTICIPANTE,0) = 0,0,1) Seleccionado , pa.RESPUESTA FROM [PAR.RESP_ANSIEDAD] s
	LEFT JOIN (SELECT * FROM [PAR.ANSIEDAD] p WHERE p.ID_PARTICIPANTE = @ID_PARTICIPANTE ) as pa on s.ID_ANSIEDAD = pa.ID_ANSIEDAD
                 ";
        public const string Insert =
           @"
INSERT INTO [dbo].[PAR.ANSIEDAD]
            ([ID_PARTICIPANTE],
            [ID_ANSIEDAD],
            [RESPUESTA])
 VALUES (@ID_PARTICIPANTE,
         @ID_ANSIEDAD,
         @RESPUESTA)";

        public const string Delete =
            @"DELETE [dbo].[PAR.ANSIEDAD]
WHERE [ID_PARTICIPANTE]=@ID_PARTICIPANTE
AND [ID_ANSIEDAD]=@ID_ANSIEDAD";


    }
}
