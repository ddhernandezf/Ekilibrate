using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.BL.Queries.Nutricionista
{
    public class QAlimentacion
    {
        public const string List =
            @"
SELECT 0 CitaId, PE.PrimerNombre AS Nombre, PE.PrimerApellido AS Apellido, GETDATE() Fecha
  FROM [PAR.Participante] PA
	inner join [GE.Persona] PE 
		on PA.Id = PE.Id
 WHERE PA.ProyectoId = 14
";


        public const string Alimentos =
            @"
SELECT b.Id, a.Id AlimentoId, a.Nombre 'NombreAlimento', b.ParticipanteId, b.NutricionistaId, ISNULL(b.Dias, 0) Dias, ISNULL(b.Porciones, 0) Porciones 
  FROM [CA.Alimento] a
  LEFT JOIN (SELECT * FROM [dbo].[NU.DiagnosticoAlimentacion] d WHERE d.ParticipanteId = @Participante AND d.CitaId = @CitaId) b 
    ON b.AlimentoId = a.Id ";

        public const string Insert =
            @"
INSERT INTO [Nu.DiagnosticoAlimentacion] (id, participanteId, CitaId, NutricionistaId, AlimentoId, Porciones, Dias)
SELECT isnull(max(Id)+1 , 1) Id, @ParticipanteId participanteId, @CitaId CitaId , @NutricionistaId NutricionistaId, @AlimentoId AlimentoId, @Porciones Porciones, @Dias Dias
FROM [Nu.DiagnosticoAlimentacion]
    ";

        public const string Diagnostico =
            @"
SELECT *
  FROM [NU.Diagnostico] 
 WHERE ParticipanteId = @ParticipanteId
   AND CitaId = @CitaId";

        public const string DiagnosticoSinCita =
            @"
SELECT *
  FROM [NU.Diagnostico] 
 WHERE ParticipanteId = @ParticipanteId
   AND CitaId IS NULL";

        public const string GetOne =
            @"
SELECT *
  FROM [NU.DiagnosticoAlimentacion]
 WHERE ParticipanteId = @ParticipanteId
   AND CitaId = @CitaId
   AND AlimentoId = @AlimentoId";

        public const string Update =
                    @"
UPDATE [NU.DiagnosticoAlimentacion]
   SET ParticipanteId = @ParticipanteId,
       CitaId = @CitaId,
       NutricionistaId = @NutricionistaId,
	   AlimentoId = @AlimentoId,
	   Porciones = @Porciones,
	   Dias = @Dias
 WHERE Id = @Id;";
    }
}
