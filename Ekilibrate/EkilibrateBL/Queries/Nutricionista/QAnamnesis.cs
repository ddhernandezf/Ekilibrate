using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.BL.Queries.Nutricionista
{
    public class QAnamnesis
    {
        public const string List =
            @"
select Id, ParticipanteId, CitaId, NutricionistaId, GrupoAlimentoId,TiempoComidaId, TiempoComida,
       [Lácteos enteros] 'Lacteos_Enteros',[Cereales] ,[Vegetales],[Frutas],[Carnes],[Grasas],[Azúcares] 'Azucares',
       [Lácteos semi-descremados] 'Lacteos_Semi_descremados',[Lácteos descremados] 'Lacteos_Descremados'
  from VW_DiagnosticoAnamnesis 
 pivot (avg (Porciones) for GRUPOALIMENTICIO  in ([Lácteos enteros],[Cereales],[Vegetales],[Frutas],[Carnes],[Grasas],[Azúcares],[Lácteos semi-descremados],[Lácteos descremados])) as AvgIncomePerDay
 where ParticipanteId = @ParticipanteId 
   and CitaId = @CitaId
 order by TiempoComidaId
";

        public const string PrimeraAnamnesis =
            @"
            select  
        Id, ParticipanteId, CitaId, NutricionistaId, GrupoAlimentoId,TiempoComidaId, TiempoComida,
        [Lácteos enteros] 'Lacteos_Enteros',[Cereales] ,[Vegetales],[Frutas],[Carnes],[Grasas],[Azúcares] 'Azucares',
        [Lácteos semi-descremados] 'Lacteos_Semi_descremados',[Lácteos descremados] 'Lacteos_Descremados'
from sp_DiagnosticoAnamnesis (@ParticipanteId, @CitaId)
    pivot (avg (Porciones) for GRUPOALIMENTICIO  in ([Lácteos enteros],[Cereales],[Vegetales],[Frutas],[Carnes],[Grasas],[Azúcares],[Lácteos semi-descremados],[Lácteos descremados])) as AvgIncomePerDay
--where ParticipanteId = @ParticipanteId
  --and NutricionistaId = @NutricionistaId
order by TiempoComidaId

        ";

        public const string InsertAnamnesis =
            @"
INSERT INTO [NU.DiagnosticoAnamnesis] 
	(Id, ParticipanteId, CitaId, NutricionistaId, GrupoAlimentoId, TiempoComidaId, Porciones)
SELECT
    isnull(max(Id)+1 , 1) Id, @ParticipanteId ParticipanteId , @CitaId CitaId ,@NutricionistaId NutricionistaId, @GrupoAlimentoId GrupoAlimentoId, @TiempoComidaId TiempoComidaId, @Porciones Porciones
FROM
	[NU.DiagnosticoAnamnesis] ";
    }
}
