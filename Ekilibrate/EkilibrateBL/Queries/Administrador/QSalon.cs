using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.BL.Queries.Administrador
{
    public class QSalon
    {
        public const string List =
            @"SELECT * FROM [ADM.Salon]  
                WHERE EmpresaId = @EmpresaId
            ";

        public const string ListPorProyecto =
           @"SELECT s.* FROM [ADM.Salon]  s
                LEFT JOIN [PR.ProyectoSAlon] ps ON s.Id = ps.SalonId 
                WHERE  ps.ProyectoId = @ProyectoId
            ";

        public const string Insert =
            @"
INSERT INTO [dbo].[ADM.Salon]
           ([Id],
            [Nombre],
            [Capacidad],
            [TipoUsoId],
            [EmpresaId])
OUTPUT INSERTED.[Id]
     VALUES
           ((SELECT ISNULL(MAX(x.Id), 0) + 1 FROM [dbo].[ADM.Salon] x),
            @Nombre,
            @Capacidad,
            @TipoUsoId,
            @EmpresaId)";

        public const string Update =
            @"UPDATE [dbo].[ADM.Salon]
SET [Nombre]=@Nombre, 
    [Capacidad]=@Capacidad,
    [TipoUsoId]=@TipoUsoId,
    [EmpresaId]=@EmpresaId
WHERE [Id] = @Id";

        public const string Delete =
            @"DELETE [dbo].[ADM.Salon]
WHERE [Id] = @Id";
    }
}
