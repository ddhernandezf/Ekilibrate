CREATE TABLE [Administracion].[Propietario]
(
	[IdPropietario] INT NOT NULL PRIMARY KEY IDENTITY,
	[Nombre] VARCHAR(45) NOT NULL,
	[Descripcion] VARCHAR(100) NOT NULL,
	[Activo] BIT NOT NULL
)
