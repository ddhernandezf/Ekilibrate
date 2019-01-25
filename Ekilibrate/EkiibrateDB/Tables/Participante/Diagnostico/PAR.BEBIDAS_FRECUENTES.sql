﻿CREATE TABLE [dbo].[PAR.BEBIDAS_FRECUENTES](
	[ID_PARTICIPANTE] [numeric](18, 0) NOT NULL,
	[ID_BEBIDA] [numeric](18, 0) NOT NULL,
	[RESPUESTA] VARCHAR(50) NULL,
	CONSTRAINT [FK_PAR_BEBIDAS_FRECUENTES_PAR_INFORMACION_GENERAL] FOREIGN KEY ([ID_PARTICIPANTE]) REFERENCES [PAR.INFORMACION_GENERAL]([ID_PARTICIPANTE]),
	CONSTRAINT [FK_PAR_BEBIDAS_FRECUENTES_PAR_BEBIDA] FOREIGN KEY ([ID_BEBIDA]) REFERENCES [PAR.BEBIDA]([ID_BEBIDA]),
	PRIMARY KEY ([ID_PARTICIPANTE], [ID_BEBIDA])
)