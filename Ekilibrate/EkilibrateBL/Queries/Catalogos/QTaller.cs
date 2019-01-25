using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.BL.Queries.Catalogos
{
    public class QTaller
    {
        public const string List =
           "SELECT * FROM [CA.Taller] WHERE 1=1 ";

        public const string ListTalleresProyecto =
           @"SELECT * FROM [CA.Taller] WHERE AreaId IN (SELECT AreaId FROM [dbo].[Pr.ProyectoArea]
WHERE ProyectoId = @ProyectoId) ";

    }
}
