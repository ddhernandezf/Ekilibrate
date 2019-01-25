﻿CREATE TABLE [dbo].[PAR.ALIMENTACION](
	[ID_PARTICIPANTE] [numeric](18, 0) NOT NULL,
	[DESAYUNO] [bit] NULL,
	[REFACCION_AM] [bit] NULL,
	[ALMUERZO] [bit] NULL,
	[REFACCION_TARDE] [bit] NULL,
	[CENA] [bit] NULL,
	[ID_VASOS] [numeric](18, 0) NOT NULL,
	[CUCHARADAS_DIARIAS] [numeric](18, 0) NULL,
	[SAL] [bit] NULL,
	[COMIDA_FAVORITA] [varchar](50) NULL,
	[COMIDA_NO_FAVORITA] [varchar](max) NULL,
	[COMIDA_DANINA] [varchar](max) NULL,
	[REFACCION_NOCHE] [bit] NULL,
	CONSTRAINT [PK_PAR.ALIMENTACION] PRIMARY KEY ([ID_PARTICIPANTE]),
	CONSTRAINT [FK_PAR_ALIMENTACION_PAR_ALIMENTACION_VASOS] FOREIGN KEY ([ID_VASOS]) REFERENCES [PAR.ALIMENTACION_VASOS]([ID_VASOS]),
)