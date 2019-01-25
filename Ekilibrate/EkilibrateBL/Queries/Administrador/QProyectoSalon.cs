using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.BL.Queries.Administrador
{
    class QProyectoSalon
    {
        public const string List =
                 @"SELECT    S.Nombre, s.Id SalonId, IIF( ISNULL(ps.ProyectoId,0) = 0,0 , 1) Seleccionado   FROM [ADM.Salon]s
	                LEFT JOIN (SELECT * FROM  [PR.ProyectoSalon] p WHERE p.ProyectoId = @ProyectoId ) as ps on s.Id = ps.SalonId
	                WHERE s.EmpresaId= @EmpresaId
                 ";

        public const string Insert = @"
            INSERT INTO [dbo].[PR.ProyectoSalon]
           ([ProyectoId]
           ,[SalonId])
     VALUES
           (@ProyectoId
           ,@SalonId)
            ";

        public const string Delete = @"
            DELETE [dbo].[PR.ProyectoSalon]
         WHERE
          ProyectoId =  @ProyectoId AND
           SalonId = @SalonId
            ";
    }
}
