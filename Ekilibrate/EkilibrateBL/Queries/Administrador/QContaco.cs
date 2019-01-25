using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.BL.Queries.Administrador
{
    public class QContaco
    {
        public const string List =
            @"
SELECT p.Id IdPersona, p.*, ec.EsPrincipal, ec.EmpresaId
  FROM [dbo].[ADM.Contacto] ec 
 INNER JOIN [GE.Persona] p ON p.Id = ec.PersonaId
 WHERE ec.EmpresaId = @EmpresaId";

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

    insert into [dbo].[ADM.Contacto]
    (
	    EmpresaId,
		PersonaId,
        EsPrincipal
    )
    values
    (
		@EmpresaId,
	    @sId,
        @EsPrincipal
    );";

        public const string InsertPrincipal =
            @"
DECLARE @sId int;
    SET @sId = (SELECT ISNULL(MAX(x.Id), 0) + 1 FROM [dbo].[GE.Persona] x);

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

    insert into [dbo].[ADM.Contacto]
    (
	    EmpresaId,
		PersonaId,
        EsPrincipal
    )
    values
    (
		@EmpresaId,
	    @sId,
        @EsPrincipal
    );

UPDATE	[ADM.Contacto]
   SET	EsPrincipal = 0
 WHERE	PersonaId <> @sId
   AND EmpresaId = @EmpresaId;";

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

UPDATE	[ADM.Contacto]
   SET	EsPrincipal = 0
 WHERE	PersonaId = @Id
   AND EmpresaId = @EmpresaId;";

        public const string UpdatePrincipal =
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

UPDATE	[ADM.Contacto]
   SET	EsPrincipal = 1
 WHERE	PersonaId = @Id
   AND EmpresaId = @EmpresaId;

UPDATE	[ADM.Contacto]
   SET	EsPrincipal = 0
 WHERE	PersonaId <> @Id
   AND EmpresaId = @EmpresaId;";

        public const string Delete =
            @"delete from [ADM.Contacto] where PersonaId = @Id;
DELETE [GE.Persona] WHERE [Id] = @Id;";
    }
}
