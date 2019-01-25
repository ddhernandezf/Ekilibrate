CREATE TABLE [Administracion].[TipoUsuario]
(
	[IdTipoUsuario] INT NOT NULL PRIMARY KEY IDENTITY,
	[Nombre] VARCHAR(45)  NOT NULL,
	[Descripcion] VARCHAR(100) NOT NULL,
	[UrlRedireccion] VARCHAR(300),
	[Activo] BIT NOT NULL
)
