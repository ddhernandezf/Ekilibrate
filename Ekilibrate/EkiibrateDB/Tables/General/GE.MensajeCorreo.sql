CREATE TABLE [dbo].[GE.MensajeCorreo]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[Asunto] varchar(MAX),
	[Mensaje] varchar(MAX),
	[EsHTML] varchar(2),
	[Para] varchar(MAX),
	[EsLista] varchar(2),
	[FechaEnvio] datetime,
	[EstadoEnvio] varchar(10)

)
