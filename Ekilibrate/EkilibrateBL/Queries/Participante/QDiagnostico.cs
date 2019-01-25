using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.BL.Queries.Participante
{
    public class QDiagnostico
    {
        public const string GetOne =
            @"
SELECT * 
  FROM [PAR.INFORMACION_GENERAL] a
 INNER JOIN [dbo].[GE.Persona] b ON b.Id = a.[ID_PARTICIPANTE]
 WHERE a.[ID_PARTICIPANTE] = @ID_PARTICIPANTE ";

        public const string List =
            @"
SELECT * 
  FROM [PAR.INFORMACION_GENERAL] a
 INNER JOIN [dbo].[GE.Persona] b ON b.Id = a.[ID_PARTICIPANTE]
 WHERE a.[ID_PARTICIPANTE] = @ID_PARTICIPANTE ";

        public const string Insert =
            @"
INSERT INTO [dbo].[PAR.INFORMACION_GENERAL]
            ([ID_PARTICIPANTE],
            [FACEBOOK],
            [ID_MEDIO_COMUNICACION],
            [SEXO],
            [FECHA_NACIMIENTO],
            [MUJER_EMBARAZADA],
            [FEC_ULT_MENSTRUACION],
            [EDAD_GESTACIONAL],
            [PESO_ANTERIOR],
            [MUJER_LACTANCIA],
            [FEC_NAC_BEBE],
            [EDAD],
            [MENOPAUSIA])
    VALUES (@ID_PARTICIPANTE,
            @FACEBOOK,
            @ID_MEDIO_COMUNICACION,
            @SEXO,
            @FECHA_NACIMIENTO,
            @MUJER_EMBARAZADA,
            @FEC_ULT_MENSTRUACION,
            @EDAD_GESTACIONAL,
            @PESO_ANTERIOR,
            @MUJER_LACTANCIA,
            @FEC_NAC_BEBE,
            @EDAD,
            @MENOPAUSIA);

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
       [ApellidoCasada]=@ApellidoCasada,
       [Departamento]=@Departamento
 WHERE [Id] = @ID_PARTICIPANTE;
";

        public const string Update =
            @"
UPDATE [dbo].[PAR.INFORMACION_GENERAL]
   SET [FACEBOOK]=@FACEBOOK,
       [ID_MEDIO_COMUNICACION]=@ID_MEDIO_COMUNICACION,
       [SEXO]=@SEXO,
       [FECHA_NACIMIENTO]=@FECHA_NACIMIENTO,
       [MUJER_EMBARAZADA]=@MUJER_EMBARAZADA,
       [FEC_ULT_MENSTRUACION]=@FEC_ULT_MENSTRUACION,
       [EDAD_GESTACIONAL]=@EDAD_GESTACIONAL,
       [PESO_ANTERIOR]=@PESO_ANTERIOR,
       [MUJER_LACTANCIA]=@MUJER_LACTANCIA,
       [FEC_NAC_BEBE]=@FEC_NAC_BEBE,
       [EDAD]=@EDAD,
       [MENOPAUSIA]=@MENOPAUSIA
WHERE [ID_PARTICIPANTE]=@ID_PARTICIPANTE;

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
       [ApellidoCasada]=@ApellidoCasada,
       [Departamento]=@Departamento
 WHERE [Id] = @ID_PARTICIPANTE;
";

        public const string Delete =
            @"DELETE [dbo].[PAR.INFORMACION_GENERAL]
WHERE [ID_PARTICIPANTE] =@ID_PARTICIPANTE";

    }
}
