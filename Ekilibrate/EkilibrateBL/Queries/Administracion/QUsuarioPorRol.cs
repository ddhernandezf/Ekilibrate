using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.BL.Queries.Administracion
{
    public class QUsuarioPorRol
    {
        public const string Insert =
            @"
INSERT INTO [Administracion].[UsuarioPorRol]
           ([IdUsuario]
           ,[IdRol]
           ,[TransacDateTime]
           ,[TransacUser])
OUTPUT INSERTED.[IdUsuario]
     VALUES
           (@IdUsuario
           ,@IdRol
           ,@TransacDateTime
           ,@TransacUser);";

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
