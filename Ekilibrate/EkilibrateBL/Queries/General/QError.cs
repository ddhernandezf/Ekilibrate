using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.BL.Queries.General
{
    public class QError
    {
        public const string Insert =
            @"
INSERT INTO [dbo].[GE.Error]
           ([Id],
            [Mensaje],
            [Pila],
            [Exepcion],
            [Fecha])
    VALUES
           ((SELECT ISNULL(MAX(x.Id), 0) + 1 FROM [dbo].[GE.Error] x),
            @Mensaje,
            @Pila,
            @Excepcion,
            @Fecha)";
    }
}
