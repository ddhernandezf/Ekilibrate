CREATE TABLE [Administracion].[Menu]
(
	[IdMenu] INT NOT NULL PRIMARY KEY IDENTITY, 
	[Nombre] VARCHAR(45) NOT NULL, 
	[ImageUrl] VARCHAR(150) , 
	[Target] VARCHAR(300),
	[TargetController] VARCHAR(300),
	[IdObjeto] INT NOT NULL, 
	[IdMenuTipo] INT NOT NULL,
	[Activo] BIT NOT NULL,
	CONSTRAINT FK_Menu_Objeto FOREIGN KEY ([IdObjeto]) REFERENCES [Administracion].[Objeto]([IdObjeto]),
	CONSTRAINT FK_Menu_MenuTipo FOREIGN KEY ([IdMenuTipo]) REFERENCES [Administracion].[MenuTipo]([IdMenuTipo])
)
