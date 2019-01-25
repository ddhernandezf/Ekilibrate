using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.BL.Queries.Participante
{
    class QCondicionPreExistente
    {
        public const string One =
            @"
SELECT S.NOMBRE_CONDICION, s.ID_CONDICION ID_CONDICION, IIF( ISNULL(pa.ID_PARTICIPANTE,0) = 0,0,1) Seleccionado , pa.RESPUESTA 
  FROM [PAR.CONDICION] s
  LEFT JOIN (SELECT * FROM [PAR.CONDICION_PRE_EXISTENTE] p WHERE p.ID_PARTICIPANTE = @ID_PARTICIPANTE ) as pa on s.ID_CONDICION = pa.ID_CONDICION
 WHERE s.ID_CONDICION = @ID_CONDICION
            ";

        public const string List =
            @"
                SELECT S.NOMBRE_CONDICION, s.ID_CONDICION ID_CONDICION, IIF( ISNULL(pa.ID_PARTICIPANTE,0) = 0,0,1) Seleccionado , pa.RESPUESTA FROM [PAR.CONDICION] s
	LEFT JOIN (SELECT * FROM [PAR.CONDICION_PRE_EXISTENTE] p WHERE p.ID_PARTICIPANTE = @ID_PARTICIPANTE ) as pa on s.ID_CONDICION = pa.ID_CONDICION
            ";

        public const string Insert =
            @"
       INSERT INTO [dbo].[PAR.CONDICION_PRE_EXISTENTE]
            ([ID_PARTICIPANTE],
            [ID_CONDICION],
            [RESPUESTA])
VALUES
    (@ID_PARTICIPANTE,
    @ID_CONDICION,
@RESPUESTA)";

        public const string Delete =
            @"DELETE [dbo].[PAR.CONDICION_PRE_EXISTENTE]
WHERE [ID_PARTICIPANTE]=@ID_PARTICIPANTE
AND [ID_CONDICION]=@ID_CONDICION";

    }
}
