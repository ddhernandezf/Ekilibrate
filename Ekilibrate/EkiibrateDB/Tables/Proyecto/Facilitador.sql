CREATE TABLE [dbo].[PR.Facilitador]
(
	[ProyectoId] INT NOT NULL, 
    [ColaboradorId] INT NOT NULL, 
    [AreaId] INT NOT NULL
	CONSTRAINT [FK_PR.Facilitador_Proyecto] FOREIGN KEY ([ProyectoId]) REFERENCES [PR.Proyecto]([Id]),
	CONSTRAINT [FK_PR.Facilitador_Colaborador] FOREIGN KEY ([ColaboradorId]) REFERENCES [ADM.Colaborador]([Id]),
	CONSTRAINT [FK_PR.Facilitador_Area] FOREIGN KEY ([AreaId]) REFERENCES [CA.Area]([Id]),
	PRIMARY KEY ([ProyectoId],[ColaboradorId])
	
)
