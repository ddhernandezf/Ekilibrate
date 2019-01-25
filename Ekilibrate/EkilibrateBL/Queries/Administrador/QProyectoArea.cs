using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.BL.Queries.Administrador
{
    class QProyectoArea 
    {
        public const string List =
                 @"
                 	SELECT S.Nombre, s.Id AreaId, IIF( ISNULL(pa.ProyectoId,0) = 0,0,1) Seleccionado  FROM [CA.Area] s
	LEFT JOIN (SELECT * FROM  [PR.ProyectoArea] p WHERE p.ProyectoId = @ProyectoId ) as pa on s.Id = pa.AreaId
                 ";

        public const string Insert = @"
          INSERT INTO [dbo].[PR.ProyectoArea]
           ([ProyectoId]
           ,[AreaId])
     VALUES
           (@ProyectoId
           ,@AreaId)
            ";

        public const string Delete = @"
            DELETE [dbo].[PR.ProyectoArea]
          WHERE ProyectoId = @ProyectoId AND
           AreaId = @AreaId
            ";
    }
}
