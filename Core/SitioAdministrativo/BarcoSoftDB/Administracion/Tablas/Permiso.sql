CREATE TABLE [Administracion].[Permiso]
(
	[IdRol] INT NOT NULL,
	[IdObjeto] INT NOT NULL, 
	[TransacDateTime] DATETIME NOT NULL,
	[TransacUser] VARCHAR(100) NOT NULL
	CONSTRAINT FK_Rol FOREIGN KEY (IdRol) REFERENCES [Administracion].[Rol]([IdRol]),
	CONSTRAINT FK_Objeto FOREIGN KEY ([IdObjeto]) REFERENCES [Administracion].[Objeto]([IdObjeto]),
	PRIMARY KEY ([IdRol], [IdObjeto]),
)
