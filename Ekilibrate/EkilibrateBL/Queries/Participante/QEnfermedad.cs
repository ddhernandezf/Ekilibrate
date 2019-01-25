using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.BL.Queries.Participante
{
    class QEnfermedad
    {
        public const string Get =
                 @"
SELECT * 
  FROM [PAR.ENFERMEDAD] 
 WHERE ID_PARTICIPANTE =@ID_PARTICIPANTE
   AND ID_ENFERMEDAD = @ID_ENFERMEDAD
";

        public const string List =
                 @"
SELECT S.ENFERMEDAD, s.ID_ENFERMEDAD, IIF( ISNULL(pa.ID_PARTICIPANTE,0) = 0,0,1) Seleccionado , pa.RESPUESTA 
  FROM [PAR.TIPO_ENFERMEDAD] s
  LEFT JOIN (SELECT * FROM [PAR.ENFERMEDAD] p WHERE p.ID_PARTICIPANTE =@ID_PARTICIPANTE) as pa on s.ID_ENFERMEDAD = pa.ID_ENFERMEDAD                 	
                 ";

        public const string Insert =
            @"
INSERT INTO [dbo].[PAR.ENFERMEDAD]
            ([ID_PARTICIPANTE],
            [ID_ENFERMEDAD])
VALUES
    (@ID_PARTICIPANTE,
    @ID_ENFERMEDAD)";

        public const string Delete =
            @"DELETE [dbo].[PAR.ENFERMEDAD]
WHERE [ID_PARTICIPANTE]=@ID_PARTICIPANTE
AND [ID_ENFERMEDAD]=@ID_ENFERMEDAD";


    }
}
