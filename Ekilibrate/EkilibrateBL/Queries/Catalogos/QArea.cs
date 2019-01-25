using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.BL.Queries.Catalogos
{
    public class QArea
    {
        public const string List =
           "SELECT * FROM [CA.Area] WHERE 1=1 ";


        public const string ListPorProyecto =
           @"SELECT a.* FROM [CA.Area]  a
                LEFT JOIN [PR.ProyectoArea] pa ON a.Id = pa.AreaId 
                WHERE  pa.ProyectoId = @ProyectoId";
    }
}
