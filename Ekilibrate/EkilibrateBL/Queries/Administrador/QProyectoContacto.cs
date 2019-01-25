using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.BL.Queries.Administrador
{
    class QProyectoContacto
    {
        public const string List =
                 @"
SELECT p.*, s.PersonaId ContactoId, IIF( ISNULL(ps.ProyectoId,0) = 0,0 , 1) Seleccionado, p.PrimerNombre + ' ' + p.PrimerApellido AS Nombre
  FROM [ADM.Contacto]  s
 INNER JOIN  [GE.Persona] p on p.Id = s.PersonaId
  LEFT JOIN (SELECT * FROM  [PR.ContactoProyecto] p WHERE p.ProyectoId = @ProyectoId ) as ps on s.PersonaId = ps.ContactoId
 WHERE s.EmpresaId= @EmpresaId
                 ";

        public const string ListbyProyecto =
                 @"
SELECT pe.*, pe.Id AS PersonaId, pe.Correo, pe.PrimerNombre + ' ' + pe.PrimerApellido AS Nombre
  FROM [PR.ContactoProyecto] pc
 INNER JOIN [GE.Persona] pe ON pe.Id = pc.ContactoId
 WHERE pc.ProyectoId = @ProyectoId
";

        public const string Insert = @"
            INSERT INTO [dbo].[PR.ContactoProyecto] 
           ([ProyectoId]
           ,[ContactoId])
     VALUES
           (@ProyectoId
           ,@ContactoId)
            ";

        public const string Delete = @"
            DELETE [dbo].[PR.ContactoProyecto] 
         WHERE
          ProyectoId =  @ProyectoId AND
           ContactoId = @ContactoId
            ";
    }
}
