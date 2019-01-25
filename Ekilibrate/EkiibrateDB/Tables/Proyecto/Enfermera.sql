CREATE TABLE [dbo].[PR.Enfermera]
(
	[ProyectoId] INT NOT NULL , 
    [ColaboradorId] INT NOT NULL,
	CONSTRAINT [FK_PR.Enfermera_Proyecto] FOREIGN KEY ([ProyectoId]) REFERENCES [PR.Proyecto]([Id]),
	CONSTRAINT [FK_PR.Enfermera_Colaborador] FOREIGN KEY ([ColaboradorId]) REFERENCES [ADM.Colaborador]([Id]), 
	PRIMARY KEY ([ProyectoId],[ColaboradorId])
)