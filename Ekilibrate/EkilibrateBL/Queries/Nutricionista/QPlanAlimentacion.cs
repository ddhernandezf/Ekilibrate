using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.BL.Queries.Nutricionista
{
    public class QPlanAlimentacion
    {
        public const string GetOne =
            @"
SELECT * 
  FROM [dbo].[NU.PlanAlimentacion]
 WHERE CitaId = @CitaId
";
        public const string Get =
            @"
SELECT Id ParticipanteId,
	   @CitaId CitaId,
	   RED, 
	   ISNULL(ISNULL(b.Cereales, c.Cereales), 0) Cereales,
	   ISNULL(ISNULL(b.Lacteos, c.Lacteos), 0) Lacteos,
	   ISNULL(ISNULL(b.Frutas, c.Frutas), 0) Frutas,
	   ISNULL(ISNULL(b.Vegetales, c.Vegetales), 0) Vegetales,
	   ISNULL(ISNULL(b.Azucares, c.Azucares), 0) Azucares,
	   ISNULL(ISNULL(b.Carnes, c.Carnes), 0) Carnes,
	   ISNULL(ISNULL(b.Grasas, c.Grasas), 0) Grasas,
       ISNULL(b.Desayuno, c.Desayuno) Desayuno,
       ISNULL(b.RefaccionAm, c.RefaccionAm) RefaccionAm,
       ISNULL(b.Almuerzo, c.Almuerzo) Almuerzo,
	   ISNULL(b.RefaccionPm, c.RefaccionPm) RefaccionPm,
	   ISNULL(b.Cena, c.Cena) Cena,
       IIF(ISNULL(b.CitaId,0) = 0,1,0) Nuevo       
  FROM [dbo].[vw_CalculoRed] a
  LEFT JOIN (SELECT * FROM [dbo].[NU.PlanAlimentacion] x WHERE CitaId = @CitaId) b ON b.ParticipanteId = a.Id
  LEFT JOIN (SELECT * 
			    FROM [dbo].[NU.PlanAlimentacion] x
			   WHERE x.[CitaId] = (SELECT MAX(CitaId) 
									 FROM [NU.PlanAlimentacion] y
									WHERE y.[CitaId] < @CitaId
									  AND y.ParticipanteId = @ParticipanteId)
			  ) AS c ON c.ParticipanteId = a.Id
 WHERE Id = @ParticipanteId
";
        
        public const string Insert =
            @"
INSERT INTO [Nu.PlanAlimentacion] 
       (CitaId, ParticipanteId, Desayuno, RefaccionAm, Almuerzo, RefaccionPm, Cena, Cereales, Lacteos, Frutas, Vegetales, Azucares, Carnes, Grasas)
VALUES (@CitaId, @ParticipanteId, @Desayuno, @RefaccionAm, @Almuerzo, @RefaccionPm, @Cena, @Cereales, @Lacteos, @Frutas, @Vegetales, @Azucares, @Carnes, @Grasas)
    ";

        public const string Update =
                    @"
UPDATE [Nu.PlanAlimentacion] 
   SET Desayuno = @Desayuno,
	   RefaccionAm = @RefaccionAm,
       Almuerzo = @Almuerzo,
	   RefaccionPm = @RefaccionPm,
       Cena = @Cena,
       Cereales = @Cereales, 
       Lacteos = @Lacteos, 
       Frutas = @Frutas, 
       Vegetales = @Vegetales, 
       Azucares = @Azucares, 
       Carnes = @Carnes, 
       Grasas = @Grasas
 WHERE CitaId = @CitaId;";
    }
}
