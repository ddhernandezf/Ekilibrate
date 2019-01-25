CREATE TABLE [Administracion].[HistoricoUsuarioPorRol]
(
	[IdUsuario] INT NOT NULL,
	[IdRol] INT NOT NULL, 
	[TransacDateTime] DATETIME NOT NULL,
	[TransacUser] VARCHAR(100) NOT NULL,
	[HistoricTransacDateTime] DATETIME NOT NULL,
	[HistoricTransacUser] VARCHAR(100) NOT NULL,
	PRIMARY KEY ([IdRol], [IdUsuario],[TransacDateTime]),
)
