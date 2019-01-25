CREATE TABLE [Administracion].[Rol]
(
	[IdRol] INT NOT NULL PRIMARY KEY IDENTITY,
	[Nombre] VARCHAR(45)  NOT NULL,
	[Descripcion] VARCHAR(100) NOT NULL,
	[IdPropietario] INT NOT NULL,
	[Activo] BIT NOT NULL,
	CONSTRAINT FK_Rol_Propietario   FOREIGN KEY (IdPropietario) REFERENCES Administracion.Propietario

)
