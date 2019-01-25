using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.BL.Queries.Administracion
{
    public class QUsuario
    {
        public const string GetByPersona =
            @"
SELECT *
  FROM [Administracion].[Usuario] 
 WHERE IdPersona = @IdPersona";

        public const string GetNick =
            @"
SELECT *
  FROM [Administracion].[Usuario] 
 WHERE SUBSTRING(NombreUsuario, 1, CHARINDEX('@', NombreUsuario) - 1) = @NombreUsuario";

        public const string Insert =
            @"
INSERT INTO [Administracion].[Usuario]
           ([NombreUsuario]
           ,[Contraseña]
           ,[IdPersona]
           ,[IdTipoUsuario]
           ,[Activo])
OUTPUT INSERTED.[IdUsuario]
     VALUES
           (@NombreUsuario
           ,@Contraseña
           ,@IdPersona
           ,@IdTipoUsuario
           ,@Activo);";

        public const string Update =
            @"
UPDATE [Administracion].[Usuario]
   SET [IdTipoUsuario] = @IdTipoUsuario,
       [Activo] = @Activo
 WHERE [IdUsuario] = @IdUsuario;";

//        public const string Update =
//            @"
//    UPDATE [dbo].[GE.Persona]
//       SET [Nombre]=@Nombre, 
//           [Apellido]=@Apellido,
//           [Telefono]=@Telefono, 
//           [Direccion]=@Direccion,
//           [Correo]=@Correo,
//           [Extension]=@Extension,
//           [Puesto]=@Puesto
//     WHERE [Id] = @Id";

//        public const string Delete =
//            @"
//    DELETE [dbo].[GE.Persona]   
//     WHERE [Id] = @Id";
    }
}
