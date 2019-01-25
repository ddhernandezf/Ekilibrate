using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.BL.Queries.Administrador
{
    public class QTallerProgramacion
    {
        public const string List =
        @" 
SELECT a.* 
  FROM [PR.TallerProgramacion] a
 INNER JOIN [PR.Taller] b ON b.Id = a.TallerId ";

        public const string Insert =
            @"
INSERT INTO [dbo].[PR.TallerProgramacion]
           ([TallerId]
           ,[NoSesion]
           ,[HoraInicio]
           ,[HoraFin])
     VALUES
           (@TallerId
           ,@NoSesion
           ,@HoraInicio
           ,@HoraFin          
)
";
    }
}
