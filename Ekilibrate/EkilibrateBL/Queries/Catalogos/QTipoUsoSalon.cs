using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.BL.Queries.Catalogos
{
    public class QTipoUsoSalon
    {
        public const string List =
            "SELECT * FROM [CA.TipoUsoSalon] WHERE 1=1 ";

        public const string Insert =
            @"
INSERT INTO [dbo].[CA.TipoUsoSalon]
           ([Id],
            [Nombre])
OUTPUT INSERTED.[Id]
     VALUES
           ((SELECT ISNULL(MAX(x.Id), 0) + 1 FROM [dbo].[CA.TipoUsoSalon] x),
            @Nombre)";

        public const string Update =
            @"UPDATE [dbo].[CA.TipoUsoSalon]
SET [Nombre]=@Nombre
WHERE [Id] = @Id";

        public const string Delete =
            @"DELETE [dbo].[CA.TipoUsoSalon]
WHERE [Id] = @Id";
    }
}
