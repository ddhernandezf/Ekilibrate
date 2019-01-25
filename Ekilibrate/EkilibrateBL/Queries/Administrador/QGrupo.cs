using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.BL.Queries.Administrador
{
    public class QGrupo
    {
        public const string GetByNombre = @"
SELECT * 
  FROM [PR.Grupo] 
 WHERE Nombre = @Nombre 
   AND ProyectoId = @ProyectoId
";

        public const string List =
         @"
SELECT * 
  FROM [PR.Grupo] 
 WHERE ProyectoId = @ProyectoId";

        public const string Insert =
            @"
INSERT INTO [dbo].[PR.Grupo]
           ([Id]
           ,[Nombre]
           ,[ProyectoId])
OUTPUT INSERTED.[Id]
     VALUES
           ((SELECT ISNULL(MAX(x.Id), 0) + 1 FROM [dbo].[PR.Grupo] x)
           ,@Nombre
           ,@ProyectoId                
)
";
    }
}
