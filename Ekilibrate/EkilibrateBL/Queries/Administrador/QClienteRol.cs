using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.BL.Queries.Administrador
{
    public class QClienteRol
    {
        public const string List =
            "SELECT * FROM [CA.ClienteRol] WHERE 1 = 1";

        public const string Insert =
            @"
INSERT INTO [dbo].[CA.ClienteRol]
           ([Id],
            [Nombre])
OUTPUT INSERTED.[Id]
     VALUES
           ((SELECT ISNULL(MAX(x.Id), 0) + 1 FROM [dbo].[CA.ClienteRol] x),
            @Nombre)";

        public const string Update =
            @"UPDATE [dbo].[CA.ClienteRol]
SET [Nombre]=@Nombre
WHERE [Id] = @Id";

        public const string Delete =
            @"DELETE [dbo].[CA.ClienteRol]
WHERE [Id] = @Id";
    }
}
