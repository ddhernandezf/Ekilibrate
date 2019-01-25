using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.BL.Queries.Participante
{
    public class QExpediente
    {
        public const string GetEstadoSalud =
            @"
select [Id], [Nombre], [Sexo], [estatura], [circunferenciamuneca], [peso], [peso_teorico],
	   [PT], [PTColor], [PTTexto], [PorcentajeGrasa], [PorcentajeGrasaColor],
	   [PorcentajeGrasaTexto], [TGL], [TGLColor], [TGLTexto], [CHOL], [CHOLColor],
	   [CHOLTexto], [GLI], [GLIColor], [GLITexto], 
	   RED [ConsumoCalorias],
	   [ObservacionNutricional],
	   [ConsumoAgua], [ConsumoSal], [ConsumoAzucar],
	   [ObservacionesHabitosAlimentarios],
	   [Fuma], [Bebe], [ObservacionesFactoresRiesgo],	
	   PorcentajeGrasa, [AFMinutos] MinutosActividadFisica,
	   [ObservacionesEstilovida]  
  from [dbo].[vw_ReporteBase] 
 where Id = @IdParticipante
";

        public const string CondicionesPreexistentes =
            @"
    select C.Nombre_Condicion from [dbo].[PAR.CONDICION_PRE_EXISTENTE] Pre
    	JOIN  [dbo].[PAR.CONDICION] C ON Pre.ID_CONDICION = C.ID_CONDICION 
            WHERE Pre.id_participante = @IdParticipante
";

        public const string Efermedades =
          @"
select C.Nombre_Condicion from [PAR.ENFERMEDAD] Enf
	JOIN  [dbo].[PAR.CONDICION] C ON Enf.ID_ENFERMEDAD = C.ID_CONDICION 
        WHERE Enf.id_participante = @IdParticipante
";
        public const string GetManejoEmociones = @"
        select top 1 @IdParticipante[Id] , ISNULL(SUM(AR.Peso),0) [RiesgoEnfermedadEstress]  ,'Observación' [ObservacionesFactoresRiesgo] from  [dbo].[PAR.ANSIEDAD] A
		JOIN [dbo].[PAR.RESP_ANSIEDAD] AR ON A.ID_Ansiedad = AR.ID_Ansiedad
		 where	A.id_participante = @IdParticipante;
";

        public const string GetCrecimientoPersonal = @"

SELECT [Id], LiderazgoNota [FactorLiderazgo], LiderazgoColor, LiderazgoTexto,
	   'Observación' [ObservacionesLiderazgo],
	   Id, FinanzasFactor [FactorFinanzas], FinanzasColor, FinanzasTexto,
	   'Observación' [ObservacionesFinanzas]
  FROM [dbo].[vw_ReporteBase] 
 where Id = @IdParticipante
";

        public const string GetRelacionesInterpersonales = @"
SELECT [Id], ManejoTiempoNota [FactorAdministracionTiempo], ManejoTiempoColor, ManejoTiempoTexto,
	   'Observación' [ObservacionesManejoTiempo],
	   Id, ComunicacionAsertivaNota [FactorComunicacionAsertiva], ComunicacionAsertivaColor, ComunicacionAsertivaTexto,
	   'Observación' [ObservacionesComunicacionAsertiva]
  FROM [dbo].[vw_ReporteBase] 
 where Id = @IdParticipante
";
        public const string GetResumen = @"
SELECT [Id], [Nombre], [Puesto], [Correo], [Telefono], [MedioComunicacion], [Sexo], [EsEmbarazada], [Edad], 
	   [FechaUltimaMenstruacion], [EdadGestacional], [FechaNacimientoBebe], [Menopausia],
	   [Estatura], [Peso] [PesoReal], [PesoActual], peso_teorico [PesoDeseable], [PT] [PorcPT], CircunferenciaAbdominal [Abdomen], 
	   [CHOL], [TGL], [GLI], [Fuma], FumaCantidad [CantidadFuma], FumaFrecuencia [FrecuenciaFuma],
	   FumaInterpretacion [FrecuenciaFumaTexto], [Bebe], BebeCantidad [CantidadBebe], BebeFrecuencia [FrecuenciaBebe], 
	   BebeInterpretacion [FrecuenciaBebeTexto], [Diabetes],
	   [VET], [RED], [ComidasFavoritas], [ComidasNoGustan], [ComidasDaninas],
	   [Calorias], [Proteinas], [Carbohidratos], [Grasas], 
	   [ConsumoAgua] [Agua], [ConsumoSal] [Sal], [ConsumoAzucar] [Azucar],
	   [Desayuno], [RefaccionMañana] [RefaAM], [Almuerzo], [RefaccionTarde] [RefaPM], [Cena],
	   ConteoEnfermedades [Enfermo], PorcentajeGrasa,  [FrecuenciaGrasa],  [FrecuenciaAzucar],  [FrecuenciaSal], [FrecuenciaFibra]
  FROM [dbo].[vw_ReporteBase]
 WHERE Id = @IdParticipante
";

      
    }
}
