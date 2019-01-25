CREATE TABLE [dbo].[PR.Asistente]
(
	[ProyectoId] INT NOT NULL , 
    [ColaboradorId] INT NOT NULL,
	CONSTRAINT [FK_PR.Asistente_Proyecto] FOREIGN KEY ([ProyectoId]) REFERENCES [PR.Proyecto]([Id]),
	CONSTRAINT [FK_PR.Asistente_Colaborador] FOREIGN KEY ([ColaboradorId]) REFERENCES [ADM.Colaborador]([Id]), 
	PRIMARY KEY ([ProyectoId],[ColaboradorId])
    
)
