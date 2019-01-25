using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.BL.Queries.Participante
{
    public class QParticipante
    {
        public const string List =
            @"
SELECT a.Id, b.PrimerNombre, b.SegundoNombre, b.PrimerApellido, b.SegundoApellido, c.Nombre AS Grupo, b.Correo, a.Baja, a.NutricionistaId, 
	   co.PrimerNombre + ' ' + co.PrimerApellido AS CompaNombre, n.PrimerNombre + ' ' + n.PrimerApellido AS NutricionistaNombre,
       a.Compa, a.CitaDia, a.CitaHora, a.PrimeraCita, a.FechaDiagnosticoFinal, a.FechaBxFinal
  FROM [dbo].[PAR.Participante] a
  LEFT JOIN [dbo].[GE.Persona] b ON b.Id = a.Id
  LEFT JOIN [dbo].[PR.Grupo] c ON c.Id = a.GrupoId
  LEFT JOIN [dbo].[CA.Pais] d ON d.Id = a.PaisId
  LEFT JOIN [dbo].[GE.Persona] co ON co.Id = a.Compa
  LEFT JOIN [dbo].[GE.Persona] n ON n.Id = a.NutricionistaId
 WHERE a.ProyectoId = @ProyectoId
   AND a.Baja = 0";

        public const string ListTest =
            @"
SELECT a.Id, b.PrimerNombre, b.SegundoNombre, b.PrimerApellido, b.SegundoApellido, c.Nombre AS Grupo, b.Correo, a.Baja, a.NutricionistaId, 
	   co.PrimerNombre + ' ' + co.PrimerApellido AS CompaNombre, n.PrimerNombre + ' ' + n.PrimerApellido AS NutricionistaNombre,
       a.Compa, a.CitaDia, a.CitaHora, a.PrimeraCita, a.FechaDiagnosticoFinal, a.FechaBxFinal
  FROM [dbo].[PAR.Participante] a
  LEFT JOIN [dbo].[GE.Persona] b ON b.Id = a.Id
  LEFT JOIN [dbo].[PR.Grupo] c ON c.Id = a.GrupoId
  LEFT JOIN [dbo].[CA.Pais] d ON d.Id = a.PaisId
  LEFT JOIN [dbo].[GE.Persona] co ON co.Id = a.Compa
  LEFT JOIN [dbo].[GE.Persona] n ON n.Id = a.NutricionistaId
 WHERE a.Id IN (80)";

        public const string ListSinCitas =
            @"
SELECT a.Id, b.PrimerNombre, b.SegundoNombre, b.PrimerApellido, b.SegundoApellido, c.Nombre AS Grupo, b.Correo, a.Baja, a.NutricionistaId, 
	   co.PrimerNombre + ' ' + co.PrimerApellido AS CompaNombre, n.PrimerNombre + ' ' + n.PrimerApellido AS NutricionistaNombre,
       a.Compa, a.CitaDia, a.CitaHora, a.PrimeraCita
  FROM [dbo].[PAR.Participante] a
  LEFT JOIN [dbo].[GE.Persona] b ON b.Id = a.Id
  LEFT JOIN [dbo].[PR.Grupo] c ON c.Id = a.GrupoId
  LEFT JOIN [dbo].[CA.Pais] d ON d.Id = a.PaisId
  LEFT JOIN [dbo].[GE.Persona] co ON co.Id = a.Compa
  LEFT JOIN [dbo].[GE.Persona] n ON n.Id = a.NutricionistaId
 WHERE a.ProyectoId = @ProyectoId
   AND a.Baja = 0
   AND a.PrimeraCita IS NULL";

        public const string ListProgramacion =
            @"
select p.PrimerNombre + ' ' + p.PrimerApellido AS Participante, 
	   n.PrimerNombre + ' ' + n.PrimerApellido AS Nutricionista,
	   cast(cast(cp.Fecha as date)as varchar)Fecha,
	   datename(dw,cp.Fecha) Dia,
	   cast(datepart(HH,cp.Fecha) as varchar) +':' + CASE datepart(mi,cp.Fecha) when 0 then cast(datepart(mi,cp.Fecha) as varchar)+ '0' else cast(datepart(mi,cp.Fecha) as varchar) end Hora,
	   co.PrimerNombre + ' ' + co.PrimerApellido AS Compa
  from [dbo].[PR.CitaProgramacion] cp
 left join [dbo].[PR.Cita] c ON c.Id = cp.CitaId
 left join [dbo].[GE.Persona] p ON  p.Id = c.ParticipanteId
 left join [dbo].[PAR.Participante] pa ON  pa.Id = c.ParticipanteId
 left join [dbo].[GE.Persona] n ON  n.Id = cp.NutricionistaId
 left join [dbo].[GE.Persona] co ON  co.Id = pa.Compa
 WHERE pa.ProyectoId = 20
   and c.CicloId = 11 
 order BY FEcha, cp.NutricionistaId";

        public const string ListRecordatorio =
            @"
SELECT *
  FROM [dbo].[vw_AvanceCuestionarios] a
 WHERE a.[ProyectoId] = @ProyectoId
   and Porcentaje < 80";

        public const string ListRecordatorioCita =
            @"
SELECT a.Id, b.PrimerNombre, b.SegundoNombre, b.PrimerApellido, b.SegundoApellido, c.Nombre AS Grupo, b.Correo, a.Baja, a.NutricionistaId, 
	   co.PrimerNombre + ' ' + co.PrimerApellido AS CompaNombre, n.PrimerNombre + ' ' + n.PrimerApellido AS NutricionistaNombre,
       a.Compa, a.CitaDia, a.CitaHora, cp.Fecha PrimeraCita, ci.No As CitaNo
  FROM [dbo].[PAR.Participante] a
  LEFT JOIN [dbo].[GE.Persona] b ON b.Id = a.Id
  LEFT JOIN [dbo].[PR.Grupo] c ON c.Id = a.GrupoId
  LEFT JOIN [dbo].[CA.Pais] d ON d.Id = a.PaisId
  LEFT JOIN [dbo].[GE.Persona] co ON co.Id = a.Compa
  LEFT JOIN [dbo].[GE.Persona] n ON n.Id = a.NutricionistaId
  LEFT JOIN [dbo].[PR.Ciclo] ci ON DATEADD(HOUR, -6, GETDATE()) BETWEEN DATEADD(DAY, -3, DATEADD(HOUR, -6, ci.FechaInicio) ) AND ci.FechaFin AND ci.ProyectoId = a.ProyectoId
  LEFT JOIN [dbo].[PR.Cita] ct ON ct.ParticipanteId = a.Id AND ct.CicloId = ci.Id
  LEFT JOIN [dbo].[PR.CitaProgramacion] cp ON cp.CitaId = ct.Id AND cp.Cancelada = 0
 WHERE a.ProyectoId = @ProyectoId
   AND a.Baja = 0
   AND a.PrimeraCita IS NOT NULL
   AND CitaDia IN ({0})
   AND cp.Fecha > DATEADD(HOUR, -6, GETDATE())
   AND cp.Fecha < DATEADD(DAY, 7, DATEADD(HOUR, -6, GETDATE()))
 ORDER BY cp.Fecha
";

        public const string ListAvance =
            @"
SELECT *
  FROM [dbo].[vw_AvanceCuestionarios] a
 WHERE a.[ProyectoId] = @ProyectoId";

        public const string GetAvance =
            @"
SELECT *
  FROM [dbo].[vw_AvanceCuestionarios] a
 WHERE a.[Id] = @ParticipanteId";

        public const string ListPorGrupo =
            @"
SELECT a.Id, b.PrimerNombre, b.SegundoNombre, b.PrimerApellido, b.SegundoApellido, c.Nombre AS Grupo  
  FROM [dbo].[PAR.Participante] a
  LEFT JOIN [dbo].[GE.Persona] b ON b.Id = a.Id
  LEFT JOIN [dbo].[PR.Grupo] c ON c.Id = a.GrupoId
  LEFT JOIN [dbo].[CA.Pais] d ON d.Id = a.PaisId
 WHERE a.GrupoId = @GrupoId";

        public const string GetCompa =
            @"
SELECT a.Id, b.PrimerNombre, b.SegundoNombre, b.PrimerApellido, b.SegundoApellido, c.Nombre AS Grupo, b.Correo
  FROM [dbo].[PAR.Participante] a
  LEFT JOIN [dbo].[GE.Persona] b ON b.Id = a.Id
  LEFT JOIN [dbo].[PR.Grupo] c ON c.Id = a.GrupoId
  LEFT JOIN [dbo].[CA.Pais] d ON d.Id = a.PaisId
 WHERE a.Compa = @Compa
   AND a.ProyectoId = @ProyectoId";

        public const string GetById =
            @"
SELECT a.Id, b.PrimerNombre, b.SegundoNombre, b.PrimerApellido, b.SegundoApellido, c.Nombre AS Grupo, b.Correo
  FROM [dbo].[PAR.Participante] a
  LEFT JOIN [dbo].[GE.Persona] b ON b.Id = a.Id
  LEFT JOIN [dbo].[PR.Grupo] c ON c.Id = a.GrupoId
  LEFT JOIN [dbo].[CA.Pais] d ON d.Id = a.PaisId
 WHERE a.Id = @Id
   AND a.ProyectoId = @ProyectoId";

        public const string Insert =
                @"
INSERT INTO [dbo].[PAR.Participante]
            ([Id],
            [PaisId],
            [GrupoId],
            [Compa],
            [ProyectoId])
     VALUES (@Id,
             @PaisId,
             @GrupoId,
             @Compa,
             @ProyectoId)";

        public const string Update =
            @"
UPDATE [dbo].[PAR.Participante]
   SET [PaisId]=@PaisId,
       [GrupoId]=@GrupoId, 
       [Compa]=@Compa
 WHERE [Id] = @Id
   AND [ProyectoId]=@ProyectoId";

        public const string Compa =
            @"
UPDATE [dbo].[PAR.Participante]
   SET [Compa]=@Compa       
 WHERE [Id] = @Id
   AND [ProyectoId]=@ProyectoId";

        public const string Nutricionista =
            @"
UPDATE [dbo].[PAR.Participante]
   SET [NutricionistaId]=@NutricionistaId
 WHERE [Id] = @Id";

        public const string Cita =
            @"
UPDATE [dbo].[PAR.Participante]
   SET [CitaDia] = @CitaDia,
       [CitaHora] = @CitaHora,
       [PrimeraCita] = @PrimeraCita
 WHERE [Id] = @Id";

        public const string Delete =
            @"
DELETE [dbo].[PAR.Participante]
 WHERE [Id] = @Id
   AND [ProyectoId]=@ProyectoId";
    }
}
