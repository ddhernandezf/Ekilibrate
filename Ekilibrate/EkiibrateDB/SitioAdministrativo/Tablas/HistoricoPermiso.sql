CREATE TABLE [Administracion].[HistoricoPermiso]
(
	[IdRol] INT NOT NULL,
	[IdObjeto] INT NOT NULL, 
	[TransacDateTime] DATETIME NOT NULL,
	[TransacUser] VARCHAR(100) NOT NULL,
	[HistoricTransacDateTime] DATETIME NOT NULL,
	[HistoricTransacUser] VARCHAR(100) NOT NULL, 
    CONSTRAINT [PK_HistoricoPermiso] PRIMARY KEY ([TransacDateTime], [IdObjeto], [IdRol]),	
)
