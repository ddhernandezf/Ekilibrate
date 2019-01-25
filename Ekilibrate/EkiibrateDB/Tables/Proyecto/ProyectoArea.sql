CREATE TABLE [dbo].[PR.ProyectoArea]
(
	[ProyectoId] INT NOT NULL , 
    [AreaId] INT NOT NULL, 
    CONSTRAINT [FK_PR.ProyectoArea_Proyecto] FOREIGN KEY ([ProyectoId]) REFERENCES [PR.Proyecto]([Id]),
	CONSTRAINT [FK_PR.ProyectoArea_Area] FOREIGN KEY ([AreaId]) REFERENCES [CA.Area]([Id]), 
    PRIMARY KEY ([AreaId], [ProyectoId])
)
