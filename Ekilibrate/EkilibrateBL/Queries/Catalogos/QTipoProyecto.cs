using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.BL.Queries.Catalogos
{
    public class QTipoProyecto
    {
        public const string List =
            "SELECT * FROM [CA.TipoProyecto] WHERE 1=1 ";

        public const string Insert =
            @"
INSERT INTO [dbo].[CA.TipoProyecto]
           ([Id],
            [Nombre])
OUTPUT INSERTED.[Id]
     VALUES
           ((SELECT ISNULL(MAX(x.Id), 0) + 1 FROM [dbo].[CA.TipoProyecto] x),
            @Nombre)";

        public const string Update =
            @"UPDATE [dbo].[CA.TipoProyecto]
SET [Nombre]=@Nombre
WHERE [Id] = @Id";

        public const string Delete =
            @"DELETE [dbo].[CA.TipoProyecto]
WHERE [Id] = @Id";
    }
}
