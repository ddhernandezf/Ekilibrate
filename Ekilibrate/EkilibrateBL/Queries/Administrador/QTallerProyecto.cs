using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.BL.Queries.Administrador
{
    public class QTallerProyecto
    {
        public const string List =
        @" SELECT p.* , T.Nombre AS NombreTaller , A.Nombre AS NombreArea, G.Nombre as NombreGrupo 
	  FROM [PR.Taller] p 
		JOIN [CA.Taller] T ON p.TallerId = T.Id
		JOIN [CA.Area] A ON T.AreaId = A.Id
		JOIN [PR.Grupo] G ON p.GrupoId = G.Id

		WHERE p.ProyectoId =  @ProyectoId ";

        public const string Insert =
            @"

INSERT INTO [dbo].[PR.Taller]
           ([Id]
           ,[ProyectoId]
           ,[SalonId]
           ,[TallerId]
           ,[GrupoId]
           ,[FacilitadorId]
           ,[NoSesiones]
           ,[DuracionSesiones]
           ,[FrecuenciaSesiones]
           ,[FrecuenciaSesionesUnidad]
           ,[HoraInicio]
           ,[HoraFin]
           ,[Lunes]
           ,[Martes]
           ,[Miercoles]
           ,[Jueves]
           ,[Viernes]
           ,[Sabado]
           ,[Domingo])
OUTPUT INSERTED.[Id]
     VALUES
           ((SELECT ISNULL(MAX(x.Id), 0) + 1 FROM [dbo].[PR.Taller] x)
           ,@ProyectoId
           ,@SalonId
           ,@TallerId
           ,@GrupoId
           ,@FacilitadorId
           ,@NoSesiones
           ,@DuracionSesiones
           ,@FrecuenciaSesiones
           ,@FrecuenciaSesionesUnidad
           ,@HoraInicio
           ,@HoraFin
           ,@Lunes
           ,@Martes
           ,@Miercoles
           ,@Jueves
           ,@Viernes
           ,@Sabado
           ,@Domingo
)

";

        public const string Update = @"
UPDATE [dbo].[PR.Taller]
   SET
      [ProyectoId] = @ProyectoId,  
      [TallerId] = @TallerId, 
      [GrupoId] = @GrupoId, 
      [FacilitadorId] = @FacilitadorId, 
      [NoSesiones] = @NoSesiones, 
      [DuracionSesiones] = @DuracionSesiones, 
      [FrecuenciaSesiones] = @FrecuenciaSesiones, 
      [FrecuenciaSesionesUnidad] = @FrecuenciaSesionesUnidad, 
      [SalonId] = @SalonId, 
      [HoraInicio] = @HoraInicio, 
      [HoraFin] = @HoraFin, 
      [Lunes] = @Lunes, 
      [Martes] = @Martes, 
      [Miercoles] = @Miercoles, 
      [Jueves] = @Jueves, 
      [Viernes] = @Viernes, 
      [Sabado] = @Sabado, 
      [Domingo] = @Domingo
 WHERE  [Id] = @Id
";

        public const string Delete = @"
            DELETE [dbo].[PR.Taller]
                 WHERE  [Id] = @Id
";
    }
}
