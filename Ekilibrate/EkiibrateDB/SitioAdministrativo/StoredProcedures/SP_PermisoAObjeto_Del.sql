CREATE PROCEDURE [Administracion].[SP_PermisoAObjeto_Del]
         @IdObjeto INT,
           @IdRol INT,
		   @UserTransac VARCHAR(45)
AS


INSERT INTO [Administracion].[HistoricoPermiso] 
SELECT pr.* , getdate(), @UserTransac FROM [Administracion].[Permiso]  pr JOIN [Administracion].[Objeto] p ON p.IdObjeto= pr.IdObjeto 
	WHERE IdRol  = @IdRol AND IdObjetoPadre = @IdObjeto

DELETE pr FROM [Administracion].[Permiso] pr  JOIN [Administracion].[Objeto] p ON p.IdObjeto = pr.IdObjeto WHERE  P.IdObjetoPadre = @IdObjeto AND PR.IdRol = @IdRol

 
INSERT INTO [Administracion].[HistoricoPermiso] 
SELECT TOP(1) * , getdate(), @UserTransac FROM [Administracion].[Permiso] 
	WHERE IdRol  = @IdRol AND IdObjeto  = @IdObjeto 

DELETE [Administracion].[Permiso] WHERE  IdObjeto  = @IdObjeto AND IdRol  = @IdRol