using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.BL.Queries.Participante
{
    public class QActividadFisica
    {
        public const string List =
             "SELECT * FROM [PAR.ACTIVIDAD_FISICA] WHERE [ID_PARTICIPANTE] = @ID_PARTICIPANTE";

        public const string ListTipoEjercicio =
             "SELECT * FROM [PAR.TIPO_EJERCICIO]";

        public const string Insert =
            @"
DECLARE @Minutos INT = 0
 SET @Minutos = @SECUNDARIO_TIEMPO * @SECUNDARIO_VECES + @PRINCIPAL_TIEMPO * @PRINCIPAL_VECES
 DECLARE @FACTOR_ACTIVIDAD DECIMAL(15,2) = 1.3
 
	IF (@REALIZA_ACTIVIDAD=0)
	BEGIN 
		SET @FACTOR_ACTIVIDAD = 1.3
	END
	ELSE
	BEGIN
		IF(@MINUTOS < 150)
		BEGIN 
			SET @FACTOR_ACTIVIDAD = 1.3
		END 
		ELSE IF(@MINUTOS < 200)
		BEGIN 
			SET @FACTOR_ACTIVIDAD = 1.4
		END 
		ELSE
		BEGIN 
			SET @FACTOR_ACTIVIDAD = 1.5
		END

	END

INSERT INTO [dbo].[PAR.ACTIVIDAD_FISICA]
            ([ID_PARTICIPANTE],
            [REALIZA_ACTIVIDAD],
            [ID_PRINCIPAL],
            [PRINCIPAL_VECES],
            [PRINCIPAL_TIEMPO],
            [ID_SECUNDARIO],
            [SECUNDARIO_VECES],
            [SECUNDARIO_TIEMPO], 
            [FACTOR_ACTIVIDAD])

VALUES
    (@ID_PARTICIPANTE,
    @REALIZA_ACTIVIDAD,
@ID_PRINCIPAL,
@PRINCIPAL_VECES,
@PRINCIPAL_TIEMPO,
@ID_SECUNDARIO,
@SECUNDARIO_VECES,
@SECUNDARIO_TIEMPO,
@FACTOR_ACTIVIDAD)";

        public const string Update =
            @"
DECLARE @Minutos INT = 0
 SET @Minutos = @SECUNDARIO_TIEMPO + @PRINCIPAL_TIEMPO
 DECLARE @FACTOR_ACTIVIDAD DECIMAL(15,2) = 1.3
 
	IF (@REALIZA_ACTIVIDAD=0)
	BEGIN 
		SET @FACTOR_ACTIVIDAD = 1.3
	END
	ELSE
	BEGIN
		IF(@MINUTOS < 150)
		BEGIN 
			SET @FACTOR_ACTIVIDAD = 1.3
		END 
		ELSE IF(@MINUTOS < 200)
		BEGIN 
			SET @FACTOR_ACTIVIDAD = 1.4
		END 
		ELSE
		BEGIN 
			SET @FACTOR_ACTIVIDAD = 1.5
		END

	END

UPDATE [dbo].[PAR.ACTIVIDAD_FISICA]
SET [REALIZA_ACTIVIDAD]=@REALIZA_ACTIVIDAD,
            [ID_PRINCIPAL]=@ID_PRINCIPAL,
            [PRINCIPAL_VECES]=@PRINCIPAL_VECES,
            [PRINCIPAL_TIEMPO]=@PRINCIPAL_TIEMPO,
            [ID_SECUNDARIO]=@ID_SECUNDARIO,
            [SECUNDARIO_VECES]=@SECUNDARIO_VECES,
            [SECUNDARIO_TIEMPO]=@SECUNDARIO_TIEMPO,
            [FACTOR_ACTIVIDAD] = @FACTOR_ACTIVIDAD
WHERE [ID_PARTICIPANTE]=@ID_PARTICIPANTE";

        public const string Delete =
            @"DELETE [dbo].[PAR.ACTIVIDAD_FISICA]
WHERE [ID_PARTICIPANTE]=@ID_PARTICIPANTE";


    }
}
