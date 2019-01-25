using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.BL.Queries.Administrador
{
    public class QNutricionista
    {

        public const string List =
         @"
SELECT a.*, (SELECT MAX(Fecha) FROM [PR.CitaProgramacion] b
              WHERE b.CitaId IN (SELECT Id 
					            FROM [PR.Cita] c
				               WHERE c.CicloId = 11)
                AND b.NutricionistaId = a.ColaboradorId) MaxFecha
 FROM [PR.Nutricionista] a 
WHERE ProyectoId = @ProyectoId";

        public const string Delete =
         @"

DELETE [dbo].[PR.Nutricionista]
         WHERE
           [ProyectoId] = @ProyectoId AND
           [ColaboradorId] = @ColaboradorId
";


        public const string Insert =
            @"INSERT INTO [dbo].[PR.Nutricionista]
           ([ProyectoId]
           ,[ColaboradorId]
           ,[RolId]
           ,[Capacidad])
     VALUES
           (
           @ProyectoId
           ,@ColaboradorId
           ,@RolId
           ,@Capacidad)";

        public const string UpdateAsignados =
            @"
UPDATE [dbo].[PR.Nutricionista]
   SET [Asignados] = @Asignados
 WHERE ProyectoId = @ProyectoId
   AND ColaboradorId = @ColaboradorId";
    }
}
