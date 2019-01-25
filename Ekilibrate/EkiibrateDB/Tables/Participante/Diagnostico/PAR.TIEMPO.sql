﻿CREATE TABLE [dbo].[PAR.TIEMPO](
	[ID_PARTICIPANTE] [numeric](18, 0) NOT NULL,
	[ID_PREGUNTA] [numeric](18, 0) NOT NULL,
	[SIEMPRE] [bit] NULL,
	[FRECUENTE] [bit] NULL,
	[CASI_NUNCA] [bit] NULL,
	[NUNCA] [bit] NULL,
 CONSTRAINT [PK_PAR_TIEMPO] PRIMARY KEY CLUSTERED 
(
	[ID_PARTICIPANTE] ASC,
	[ID_PREGUNTA] ASC
) 
)

GO
ALTER TABLE [dbo].[PAR.TIEMPO]  ADD  CONSTRAINT [FK_PAR_TIEMPO_PAR_INFORMACION_GENERAL] FOREIGN KEY([ID_PARTICIPANTE])
REFERENCES [dbo].[PAR.INFORMACION_GENERAL] ([ID_PARTICIPANTE])
GO

ALTER TABLE [dbo].[PAR.TIEMPO] CHECK CONSTRAINT [FK_PAR_TIEMPO_PAR_INFORMACION_GENERAL]
GO
ALTER TABLE [dbo].[PAR.TIEMPO]   ADD  CONSTRAINT [FK_PAR_TIEMPO_PAR_PREGUNTA_TIEMPO] FOREIGN KEY([ID_PREGUNTA])
REFERENCES [dbo].[PAR.PREGUNTA_TIEMPO] ([ID_PREGUNTA])
GO

ALTER TABLE [dbo].[PAR.TIEMPO] CHECK CONSTRAINT [FK_PAR_TIEMPO_PAR_PREGUNTA_TIEMPO]