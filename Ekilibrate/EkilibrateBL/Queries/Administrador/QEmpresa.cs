using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.BL.Queries.Administrador
{
    public class QEmpresa
    {
        public const string List =
            "SELECT * FROM [ADM.Empresa] WHERE 1=1 ";

        public const string EmpresaContacto =
            @"
SELECT a.*, b.PersonaId, ISNULL(c.PrimerNombre, '') + ' ' + ISNULL(c.PrimerApellido, '') As ContactoNombre, ISNULL(c.Telefono, '') As ContactoTelefono, ISNULL(c.Extension, '') As ContactoExtension, ISNULL(c.Celular, '') As ContactoCelular, ISNULL(c.Correo, '') As ContactoCorreo
  FROM [ADM.Empresa] a
  LEFT JOIN [ADM.Contacto] b ON b.[EmpresaId] = a.[Id] AND b.[EsPrincipal] = 1  
  LEFT JOIN [GE.Persona] c ON c.[Id] = b.[PersonaId]  
 WHERE 1=1
";

        public const string Insert =
            @"
INSERT INTO [dbo].[ADM.Empresa]
           ([Id],
            [Nombre],
            [PBX],
            [Direccion],
            [GiroId],
            [CantidadTotalEmpleados],
            [CantidadAdministrativo],
            [CantidadDistribucion],
            [CantidadVentas],
            [CantidadProduccion],
            [OtrosDescripcion],
            [CantidadOtros])
OUTPUT INSERTED.[Id]
     VALUES
           ((SELECT ISNULL(MAX(x.Id), 0) + 1 FROM [dbo].[ADM.Empresa] x),
            @Nombre,
            @PBX,
            @Direccion,
            @GiroId,
            @CantidadTotalEmpleados,
            @CantidadAdministrativo,
            @CantidadDistribucion,
            @CantidadVentas,
            @CantidadProduccion,
            @OtrosDescripcion,
            @CantidadOtros)";

        public const string Update =
            @"
UPDATE [dbo].[ADM.Empresa]
   SET [Nombre]=@Nombre, 
       [PBX]=@PBX,
       [Direccion]=@Direccion, 
       [GiroId]=@GiroId,
       [CantidadTotalEmpleados] = @CantidadTotalEmpleados, 
       [CantidadAdministrativo] = @CantidadAdministrativo, 
       [CantidadDistribucion] = @CantidadDistribucion, 
       [CantidadVentas] = @CantidadVentas, 
       [CantidadProduccion] = @CantidadProduccion, 
       [OtrosDescripcion] = @OtrosDescripcion, 
       [CantidadOtros] = @CantidadOtros
WHERE [Id] = @Id";

        public const string Delete =
            @"DELETE [dbo].[ADM.Empresa]
WHERE [Id] = @Id";
    }


   
}
