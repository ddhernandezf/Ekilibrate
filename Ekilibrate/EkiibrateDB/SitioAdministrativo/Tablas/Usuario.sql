CREATE TABLE [Administracion].[Usuario]
(
	[IdUsuario] INT NOT NULL PRIMARY KEY IDENTITY,
	[NombreUsuario] VARCHAR(100) NOT NULL UNIQUE,
	[Contraseña] VARCHAR(300), 
	[IdPersona] INT NOT NULL,
	[IdTipoUsuario] INT NOT NULL,
	[Activo] BIT NOT NULL,
	CONSTRAINT FK_Usuario_Persona FOREIGN KEY  (IdPersona) REFERENCES [dbo].[GE.Persona], 
	CONSTRAINT FK_Usuario_TipoUsuario FOREIGN KEY  (IdTipoUsuario) REFERENCES Administracion.TipoUsuario 
)
