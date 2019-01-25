CREATE TABLE [dbo].[GE.Lista_Persona]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[Lista] INT NOT NULL CONSTRAINT [FK_GE.Lista_Persona_Lista] FOREIGN KEY ([Lista]) REFERENCES [dbo].[GE.ListaDifusion]([Id]),
	[Persona] INT NOT NULL CONSTRAINT [FK_GE.Lista_Persona_Persona] FOREIGN KEY ([Persona]) REFERENCES [dbo].[GE.Persona]([Id])

)
