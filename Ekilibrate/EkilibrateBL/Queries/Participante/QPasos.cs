using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.BL.Queries.Participante
{
    public class QPasos
    {
        public const string GetOne =
            @"
SELECT *
  FROM [PR.Pasos]
 WHERE ParticipanteId = @ParticipanteId
   AND SemanaId = @SemanaId";

        public const string Insert =
            @"
INSERT INTO [dbo].[PR.Pasos]
SELECT (SELECT MAX(x.Id) FROM [dbo].[PR.Pasos] x) + ROW_NUMBER() OVER (Order by Id) Id, @SemanaId Semana, Id, [dbo].[f_calcular_meta3] (@SemanaId, [Id]) Meta,  
	   ISNULL((SELECT SUM(x.Caminados) FROM [dbo].[PR.PasosDia] x WHERE x.ParticipanteId = a.Id AND x.SemanaId = @SemanaId), 0) Caminados,
	   GETDATE() Fecha,
	   ISNULL((SELECT COUNT(x.Caminados) FROM [dbo].[PR.PasosDia] x WHERE x.ParticipanteId = a.Id AND x.SemanaId = @SemanaId), 0) Registros,
	   0,
	   0
  FROM [dbo].[PAR.Participante] a
 WHERE ProyectoId = (SELECT x.ProyectoId FROM [dbo].[PAR.Participante] x WHERE x.Id = @ParticipanteId)
   AND Baja = 0";

        public const string Update =
            @"
UPDATE [PR.Pasos]
   SET Caminados = ISNULL((SELECT SUM(x.Caminados) FROM [dbo].[PR.PasosDia] x WHERE x.ParticipanteId = [PR.Pasos].ParticipanteId AND x.SemanaId = [PR.Pasos].SemanaId), 0),
       Registros = ISNULL((SELECT COUNT(x.Caminados) FROM [dbo].[PR.PasosDia] x WHERE x.ParticipanteId = [PR.Pasos].ParticipanteId AND x.SemanaId = [PR.Pasos].SemanaId), 0),
       FEchaRegistro = GETDATE()
 WHERE ParticipanteId = @ParticipanteId
   AND SemanaId = @SemanaId";

        public const string Delete =
            @"delete from [PR.PasosDia] where Id = @Id";
    }
}
