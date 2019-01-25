CREATE TABLE [dbo].[PR.Nutricionista]
(
	[ProyectoId] INT NOT NULL , 
	[ColaboradorId] INT NOT NULL, 
    [RolId] INT NOT NULL, 
    [Capacidad] INT NOT NULL,
	[Asignados] INT NULL, 
    CONSTRAINT [FK_PR.Nutricionista_Proyecto] FOREIGN KEY ([ProyectoId]) REFERENCES [PR.Proyecto]([Id]),
	CONSTRAINT [FK_PR.Nutricionista_Colaborador] FOREIGN KEY ([ColaboradorId]) REFERENCES [ADM.Colaborador]([Id]),
	CONSTRAINT [FK_PR.Nutricionista_Rol] FOREIGN KEY ([RolId]) REFERENCES [CA.RolNutricionista]([Id]), 
    PRIMARY KEY ([ProyectoId],[ColaboradorId])
)
