using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.BL.Queries.Administrador
{
    public class QFacilitador
    {

        public const string List =
         @"
SELECT F.*, C.PrimerNombre +' ' + C.PrimerApellido as NombreColaborador FROM [PR.Facilitador] F
 INNER JOIN [GE.Persona] C ON C.Id  = F.ColaboradorId 
 WHERE ProyectoId =  @ProyectoId ";


        public const string Insert =
            @"

INSERT INTO [dbo].[PR.Facilitador]
           (
           [ProyectoId]
           ,[ColaboradorId]     
           ,[AreaId])
     VALUES
           (@ProyectoId
           ,@ColaboradorId
           ,@AreaId)
";

        public const string Delete =
           @"

DELETE [dbo].[PR.Facilitador]
         WHERE
           [ProyectoId] = @ProyectoId AND
           [ColaboradorId] = @ColaboradorId
";
    }
}
