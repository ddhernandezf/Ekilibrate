using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.BL.Queries.Nutricionista
{
    public class QDiagnostico
    {
        public const string GetOne =
            @"
SELECT *
  FROM [NU.Diagnostico]
 WHERE ParticipanteId = @ParticipanteId
   AND CitaId = @CitaId";

        public const string Insert =
            @"
DECLARE @Edad INT = 0
DECLARE @MetabolismoBasal INT = 0
DECLARE @Hombre BIT = 1 
SELECT @Edad = DATEDIFF( dd, i.FECHA_NACIMIENTO , GETDATE() ) / 365 , @Hombre = CASE WHEN UPPER( i.Sexo) = 'MASCULINO' then 1 else 0  end FROM [PAR.INFORMACION_GENERAL] i WHERE i.Id_PArticipante =@ParticipanteId
IF(@Hombre = 1)
BEGIN
	 IF(@Edad<= 29)
	 BEGIN
		SET @MetabolismoBasal = ((15.1 * @Peso * 0.453592)+692)
	 END
	 ELSE IF(@Edad<= 60)
	 BEGIN
		SET @MetabolismoBasal = ((11.1 * @Peso * 0.453592)+873)
	 END
	 ELSE
	 BEGIN
		 SET @MetabolismoBasal = ((11.7 * @Peso * 0.453592)+588)
	 END
END
ELSE
BEGIN
	IF(@Edad<= 29)
	 BEGIN
		SET @MetabolismoBasal = ((14.8 * @Peso * 0.453592)+487)
	 END
	 ELSE IF(@Edad<= 60)
	 BEGIN
		SET @MetabolismoBasal = ((8.1 * @Peso * 0.453592)+846)
	 END
	 ELSE
	 BEGIN
		 SET @MetabolismoBasal = ((9.1 * @Peso * 0.453592)+658)
	 END 
END 

INSERT INTO [NU.Diagnostico]
	   (ParticipanteId,
        CitaId,
	    NutricionistaId,
	    Peso,
	    Estatura,
	    CircunferenciaMuneca,
	    CircunferenciaAbdominal,
        CircunferenciaCadera,
	    PorcentajeGrasa,
	    Colesterol,
	    Triglicerios,
	    Glucosa,
	    PresionArterial,
        PresionArterial2,
	    Observaciones,
	    ComentariosRelevantes,
        MetabolismoBasal,
        Genero,
        NivelActividad)
VALUES
	   (@ParticipanteId,
        @CitaId,
	    @NutricionistaId,
	    @Peso,
	    @Estatura,
	    @CircunferenciaMuneca,
	    @CircunferenciaAbdominal,
        @CircunferenciaCadera,
	    @PorcentajeGrasa,
	    @Colesterol,
	    @Triglicerios,
	    @Glucosa,
	    @PresionArterial,
        @PresionArterial2,
	    @Observaciones,
	    @ComentariosRelevantes,
        @MetabolismoBasal,
        @Genero,
        @NivelActividad)";

        public const string Update =
                    @"
DECLARE @Edad INT = 0
DECLARE @MetabolismoBasal INT = 0
DECLARE @Hombre BIT = 1 
SELECT @Edad = DATEDIFF( dd, i.FECHA_NACIMIENTO , GETDATE() ) / 365 , @Hombre = CASE WHEN UPPER( i.Sexo) = 'MASCULINO' then 1 else 0  end FROM [PAR.INFORMACION_GENERAL] i WHERE i.Id_PArticipante =@ParticipanteId
IF(@Hombre = 1)
BEGIN
	 IF(@Edad<= 29)
	 BEGIN
		SET @MetabolismoBasal = ((15.1 * @Peso)+692)
	 END
	 ELSE IF(@Edad<= 60)
	 BEGIN
		SET @MetabolismoBasal = ((11.1 * @Peso)+873)
	 END
	 ELSE
	 BEGIN
		 SET @MetabolismoBasal = ((11.7 * @Peso)+588)
	 END
END
ELSE
BEGIN
	IF(@Edad<= 29)
	 BEGIN
		SET @MetabolismoBasal = ((14.8 * @Peso)+487)
	 END
	 ELSE IF(@Edad<= 60)
	 BEGIN
		SET @MetabolismoBasal = ((8.1 * @Peso)+846)
	 END
	 ELSE
	 BEGIN
		 SET @MetabolismoBasal = ((9.1 * @Peso)+658)
	 END 
END 

UPDATE [NU.Diagnostico]
   SET NutricionistaId = @NutricionistaId,    
	   Peso = @Peso,
	   Estatura = @Estatura,
	   CircunferenciaMuneca = @CircunferenciaMuneca,
	   CircunferenciaAbdominal = @CircunferenciaAbdominal,
       CircunferenciaCadera = @CircunferenciaCadera,
	   PorcentajeGrasa = @PorcentajeGrasa,
	   Colesterol = @Colesterol,
	   Triglicerios = @Triglicerios,
	   Glucosa = @Glucosa,
	   PresionArterial = @PresionArterial,
       PresionArterial2 = @PresionArterial2,
	   Observaciones = @Observaciones,
	   ComentariosRelevantes = @ComentariosRelevantes,
       MetabolismoBasal = @MetabolismoBasal,
       Genero = @Genero,
       NivelActividad = @NivelActividad
 WHERE ParticipanteId = @ParticipanteId
   AND CitaId = @CitaId;";
    }
}
