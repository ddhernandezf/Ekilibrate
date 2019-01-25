CREATE TABLE [Administracion].[UsuarioPorRol]
(
	[IdUsuario] INT NOT NULL,
	[IdRol] INT NOT NULL, 
	[TransacDateTime] DATETIME NOT NULL,
	[TransacUser] VARCHAR(100) NOT NULL,
	
	CONSTRAINT FK_RoleToUser FOREIGN KEY ([IdRol]) REFERENCES [Administracion].[Rol]([IdRol]),
	CONSTRAINT FK_UserToRole FOREIGN KEY ([IdUsuario]) REFERENCES [Administracion].[Usuario]([IdUsuario]),
	PRIMARY KEY([IdUsuario] ,[IdRol])
)
