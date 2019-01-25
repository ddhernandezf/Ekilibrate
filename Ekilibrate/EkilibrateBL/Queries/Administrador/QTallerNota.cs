using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.BL.Queries.Administrador
{
    public class QTallerNota
    {
        public const string List =
        @" 
SELECT a.* 
  FROM [PR.TallerNota] a
 INNER JOIN [PR.Taller] b ON b.Id = a.TallerId ";

        public const string Insert =
            @"
INSERT INTO [dbo].[PR.TallerNota]
           ([TallerId]
           ,[NoSesion]
           ,[ParticipanteId]
           ,[Asistencia]
           ,[Tarea])
     VALUES
           (@TallerId
           ,@NoSesion
           ,@ParticipanteId
           ,@Asistencia
           ,@Tarea          
)
";
    }
}
