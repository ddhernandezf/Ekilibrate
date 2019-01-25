CREATE TABLE [dbo].[PAR.PreguntaLiderazgo](
	[Id] [numeric](18, 0) NOT NULL PRIMARY KEY,
	[Nombre] [varchar](max) NULL,
	[PesoSiempre] BIT  NULL DEFAULT 0, 
	[PesoFrecuentemente] BIT NULL DEFAULT 0,
	[PesoCasiNunca] BIT  NULL DEFAULT 0,
	[PesoNunca] BIT NULL DEFAULT 0,
) 