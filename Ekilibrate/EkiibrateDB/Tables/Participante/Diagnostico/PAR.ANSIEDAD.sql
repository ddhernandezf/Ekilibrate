﻿CREATE TABLE [dbo].[PAR.ANSIEDAD](
	[ID_PARTICIPANTE] [numeric](18, 0) NOT NULL,
	[ID_ANSIEDAD] [numeric](18, 0) NOT NULL,
	[RESPUESTA] [bit] NULL,
	CONSTRAINT [FK_PAR_ANSIEDAD_PAR_INFORMACION_GENERAL] FOREIGN KEY ([ID_PARTICIPANTE]) REFERENCES [PAR.INFORMACION_GENERAL]([ID_PARTICIPANTE]),
	CONSTRAINT [FK_PAR_ANSIEDAD_PAR_RESP_ANSIEDAD] FOREIGN KEY ([ID_ANSIEDAD]) REFERENCES [PAR.RESP_ANSIEDAD]([ID_ANSIEDAD]),
	PRIMARY KEY ([ID_PARTICIPANTE], [ID_ANSIEDAD])
)