using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.BL.Queries.Administrador
{
    public class QMail
    {

        public const string MensajesSinEnviar =
         "SELECT * FROM [GE.MensajeCorreo] WHERE (EstadoEnvio IS NULL) or (EstadoEnvio = 'ERROR')";

        public const string CorreoEnvio =
         "SELECT * FROM [GE.CorreoElectronico]";


        public const string Insert =
            @"
INSERT INTO [dbo].[GE.MensajeCorreo]
           ([Id],
            [Asunto],
            [Mensaje],
            [EsHTML],
            [Para],
            [EsLista],
            [FechaEnvio],
            [EstadoEnvio])
     VALUES
           ((SELECT ISNULL(MAX(x.Id), 0) + 1 FROM [dbo].[GE.MensajeCorreo] x),
            @Asunto,
            @Mensaje,
            @EsHTML,
            @Para,
            @EsLista,
            @FechaEnvio,
            @EstadoEnvio)";

        public const string Update = 
            @"
            UPDATE [GE.MensajeCorreo] SET EstadoEnvio = @EstadoEnvio where Id = @Id";

    }
}
