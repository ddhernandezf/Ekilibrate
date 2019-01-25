using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.BL.Queries.Administrador
{
    public class QColaboradores
    {
        public const string List =
            @"
SELECT p.*, c.Id, c.Estado, c.Nutricionista, c.Facilitador, c.Asistente, c.[Enfermero(a)] as Enfermero
  FROM [ADM.Colaborador] c 
 INNER JOIN [GE.Persona] p ON p.Id = c.Id
 WHERE 1=1";

        public const string Insert =
            @"
DECLARE @sId int;
    set @sId = (SELECT ISNULL(MAX(x.Id), 0) + 1 FROM [dbo].[GE.Persona] x);

INSERT INTO [dbo].[GE.Persona]
            ([Id],
            [PrimerNombre],
            [SegundoNombre],
            [PrimerApellido],
            [SegundoApellido],
            [Telefono],
            [Correo],
            [Extension],
            [Puesto],
            [Celular])
OUTPUT INSERTED.[Id]
VALUES          
       (@sId,
        @PrimerNombre,
        @SegundoNombre,
        @PrimerApellido,
        @SegundoApellido,
        @Telefono,
        @Correo,
        @Extension,
        @Puesto,
        @Celular);

    insert into [dbo].[ADM.Colaborador]
    (
	    Id,
	    Nutricionista,
	    Facilitador,
	    Asistente,
	    [Enfermero(a)],
	    Estado
    )
    values
    (
	    @sId,
	    @Nutricionista,
	    @Facilitador,
	    @Asistente,
	    @Enfermero,
	    'Alta'
    );";

        public const string Update =
            @"
UPDATE [dbo].[GE.Persona]
   SET [PrimerNombre]=@PrimerNombre,
       [SegundoNombre]=@SegundoNombre,
       [PrimerApellido]=@PrimerApellido,
       [SegundoApellido]=@SegundoApellido,
       [Puesto]=@Puesto,
       [Correo]=@Correo,
       [Telefono]=@Telefono,
       [Extension]=@Extension,
       [Celular]=@Celular
 WHERE [Id] = @Id;

UPDATE	[ADM.Colaborador]
   SET	Nutricionista = @Nutricionista,
		Facilitador = @Facilitador,
		Asistente = @Asistente,
		[Enfermero(a)] = @Enfermero,
        Estado = @Estado
 WHERE	Id = @Id;";

        public const string Delete =
            @"DELETE [ADM.Colaborador] WHERE [Id] = @Id;
DELETE [GE.Persona] WHERE [Id] = @Id;";
    }
}
