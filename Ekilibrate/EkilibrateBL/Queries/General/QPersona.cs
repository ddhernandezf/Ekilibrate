using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.BL.Queries.General
{
    public class QPersona
    {
        public const string List =
            @"
SELECT Id, Nombre, Apellido, Telefono, Direccion, Correo, Extension, Puesto
  FROM [dbo].[GE.Persona] ";

        public const string GetOne =
            @"
SELECT *
  FROM [dbo].[GE.Persona] 
 WHERE Id = @Id";

        public const string GetByCorreo =
            @"
SELECT *
  FROM [dbo].[GE.Persona] 
 WHERE Correo = @Correo";

            public const string Insert =
                @"
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
            ((SELECT ISNULL(MAX(x.Id),0) + 1 FROM [dbo].[GE.Persona] X),
            @PrimerNombre,
            @SegundoNombre,
            @PrimerApellido,
            @SegundoApellido,
            @Telefono,
            @Correo,
            @Extension,
            @Puesto,
            @Celular)";

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
       [Celular]=@Celular,
       [ApellidoCasada]=@ApellidoCasada
 WHERE [Id] = @Id";

        public const string FotoPerfil =
                @"
UPDATE [dbo].[GE.Persona]
   SET [FotoPerfil]=@FotoPerfil       
 WHERE [Id] = @Id";

        public const string Delete =
                @"
    DELETE [dbo].[GE.Persona]   
     WHERE [Id] = @Id";
    }
}
