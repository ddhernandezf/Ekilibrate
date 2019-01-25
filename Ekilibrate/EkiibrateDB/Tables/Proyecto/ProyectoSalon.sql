CREATE TABLE [dbo].[PR.ProyectoSalon]
(
	[ProyectoId] INT NOT NULL PRIMARY KEY, 
    [SalonId] INT NOT NULL, 
    CONSTRAINT [FK_PR.ProyectoSalon_Proyecto] FOREIGN KEY ([ProyectoId]) REFERENCES [PR.Proyecto]([Id]),
	CONSTRAINT [FK_PR.ProyectoSalon_Salon] FOREIGN KEY ([SalonId]) REFERENCES [ADM.Salon]([Id])
)
