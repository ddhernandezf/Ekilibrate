CREATE TABLE [Administracion].[ParametroGeneral]
(
	[IdParametroGeneral] INT NOT NULL PRIMARY KEY IDENTITY,
	[Nombre] VARCHAR(45) NOT NULL,
	[Valor] VARCHAR(1000),
	[IdParametroTipo] INT,
	[Activo] BIT NOT NULL,
	[IdPropietario] INT NOT NULL,
	[TransacDateTime] DATETIME NOT NULL,
	[TransacUser] VARCHAR(45) NOT NULL,	
	CONSTRAINT FK_Parametro_Type FOREIGN KEY ([IdParametroTipo]) REFERENCES [Administracion].[ParametroTipo]([IdParametroTipo]),
	CONSTRAINT FK_Parametro_Propietario FOREIGN KEY([IdPropietario]) REFERENCES [Administracion].[Propietario]([IdPropietario])
)
