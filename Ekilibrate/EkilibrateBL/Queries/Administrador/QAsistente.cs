using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.BL.Queries.Administrador
{
    public class QAsistente
    {

        public const string List =
         "SELECT * FROM [PR.Asistente] WHERE ProyectoId = @ProyectoId ";



        public const string Insert =
            @"

INSERT INTO [dbo].[PR.Asistente]
           (
           ,[ProyectoId]
           ,[ColaboradorId])
     VALUES
           (
           @ProyectoId
           ,@ColaboradorId)
";

        public const string Delete =
            @"

DELETE [dbo].[PR.Asistente]
         WHERE
           [ProyectoId] = @ProyectoId AND
           [ColaboradorId] = @ColaboradorId
";


    }
}
