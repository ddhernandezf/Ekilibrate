CREATE PROCEDURE [Administracion].[SP_PermisoAObjeto_Ins]
         @IdObjeto INT,
           @IdRol INT,
		   @UserTransac VARCHAR(45)
AS




DECLARE @FLAG BIT ;
DECLARE @OBJETO INT;

SELECT @OBJETO = p.IdObjetoPadre  FROM [Administracion].[Objeto]  p WHERE p.IdObjeto = @IdObjeto 
SELECT  @FLAG = 
				CAST(
					 CASE 
						  WHEN ISNULL ( p.IdObjetoPadre, 0) = 0
							 THEN 1 
							 ELSE 0 
					 END AS bit)    FROM [Administracion].[Objeto]  p WHERE p.IdObjeto = @IdObjeto 

WHILE (@FLAG = 0)
	BEGIN 	
		
	

		IF  NOT EXISTS( SELECT * FROM [Administracion].[Permiso] WHERE IdObjeto = @OBJETO AND IdRol = @IdRol)
		BEGIN 
			INSERT INTO [Administracion].[Permiso] 
			   ([IdRol],
			   [IdObjeto]  ,
			   [TransacDateTime],
			   [TransacUser]) 

			 VALUES
			 (@IdRol, @OBJETO, GETDATE(), @UserTransac)
		END 

			SELECT @FLAG = 
				CAST(
					 CASE 
						  WHEN ISNULL ( p.IdObjetoPadre, 0) != 0
							 THEN 1 
							 ELSE 0 
					 END AS bit)  
		FROM [Administracion].[Objeto] p WHERE p.IdObjeto = @IdObjeto
		SELECT @OBJETO = p.IdObjetoPadre  FROM [Administracion].[Objeto]  p WHERE p.IdObjeto = @OBJETO

	END



INSERT INTO [Administracion].[Permiso] 
           ([IdRol],
		   [IdObjeto]  ,
		   [TransacDateTime],
		   [TransacUser]) 

     VALUES
	 (@IdRol, @IdObjeto, GETDATE(), @UserTransac)