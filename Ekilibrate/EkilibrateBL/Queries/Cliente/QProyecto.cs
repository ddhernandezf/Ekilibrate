using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.BL.Queries.Cliente
{
    public class QProyecto
    {
        public const string List =
            "SELECT * FROM [PR.Proyecto] WHERE 1=1 ";
//            @"
//SELECT a.Id, a.EmpresaId, a.Estado, CONVERT(VARCHAR(10), a.FechaInicio, 103) FechaInicio, CONVERT(VARCHAR(10), a.FechaFin, 103) FechaFin, 
//       b.nombre As Empresa, c.Nombre As Aseguradora
//  FROM [dbo].[PR.Proyecto] a
// INNER JOIN [dbo].[ADM.Empresa] b ON b.Id = a.EmpresaId
// LEFT JOIN [dbo].[CA.Aseguradora] c ON c.Id = a.AseguradoraId
// WHERE Estado NOT IN ('Finalizado', 'Rechazado') ";

        public const string Update =
            @"UPDATE [dbo].[PR.Proyecto]
SET [Color]=@Color, 
    [CrearUsuarios]=@CrearUsuarios,
    [Direccion]=@Direccion, 
    [LogoURL]=@LogoURL,
    [AseguradoraId]=@AseguradoraId,
    [IndiceReclamos]=@IndiceReclamos
WHERE [Id] = @Id";
    }
}
