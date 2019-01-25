using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.BL.Queries.Nutricionista
{
    public class QCalificacionTaller
    {
        public const string List =
            @"SELECT ct.AreaId, ct.Nombre,ct.Id [IdTaller], tn.Asistencia, tn.Tarea, tn.NoSesion
	 FROM [dbo].[PR.TallerNota] tn
	JOIN [PR.Taller] t on tn.TallerId = t.Id
	JOIN [CA.Taller] ct on t.TallerId = ct.Id
        WHERE tn.ParticipanteId = @ParticipanteId AND ct.id = @TallerId
";

       


    }
}
