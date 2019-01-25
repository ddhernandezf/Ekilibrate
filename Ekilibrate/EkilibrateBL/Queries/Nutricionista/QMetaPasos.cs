using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.BL.Queries.Nutricionista
{
    public class QMetaPasos
    {
        public const string List =
            @"SELECT P.Id [IdPaso], S.Semana, P.Meta, P.ParticipanteId FROM [dbo].[PR.Pasos] P
				JOIN  [PR.Semana]  S ON P.SemanaId = S.Id
				WHERE PARTICIPANTEID =@ParticipanteId";

       


    }
}
