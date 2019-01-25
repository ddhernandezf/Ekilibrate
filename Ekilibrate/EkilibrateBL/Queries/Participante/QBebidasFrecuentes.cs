using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.BL.Queries.Participante
{
    class QBebidasFrecuentes
    {
        public const string GetOne =
                 @"
SELECT * 
  FROM [PAR.BEBIDAS_FRECUENTES] p 
 WHERE p.ID_PARTICIPANTE = @ID_PARTICIPANTE
   AND p.ID_BEBIDA = @ID_BEBIDA
                 ";

        public const string List =
                 @"
                 	SELECT S.NOMBRE_BEBIDA, s.ID_BEBIDA ID_BEBIDA, IIF( ISNULL(pa.ID_PARTICIPANTE,0) = 0,0,1) Seleccionado , pa.RESPUESTA FROM [PAR.BEBIDA] s
	LEFT JOIN (SELECT * FROM [PAR.BEBIDAS_FRECUENTES] p WHERE p.ID_PARTICIPANTE = @ID_PARTICIPANTE ) as pa on s.ID_BEBIDA = pa.ID_BEBIDA
                 ";

        public const string Insert =
            @"
INSERT INTO [dbo].[PAR.BEBIDAS_FRECUENTES]
            ([ID_PARTICIPANTE],
            [ID_BEBIDA],
            [RESPUESTA])
VALUES
    (@ID_PARTICIPANTE,
    @ID_BEBIDA,
@RESPUESTA)";

        public const string Delete =
            @"DELETE [dbo].[PAR.BEBIDAS_FRECUENTES]
WHERE [ID_PARTICIPANTE]=@ID_PARTICIPANTE
AND [ID_BEBIDA]=@ID_BEBIDA";


    }
}