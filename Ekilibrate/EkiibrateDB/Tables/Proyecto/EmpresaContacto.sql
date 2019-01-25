CREATE TABLE [dbo].[PR.ContactoProyecto]
(
	[ProyectoId] INT NOT NULL, 
    [ContactoId] INT NOT NULL,
    CONSTRAINT [PK_ContactoProyecto] PRIMARY KEY ([ProyectoId], [ContactoId]),
	CONSTRAINT [FK_ADM.ContactoProyecto_Proyecto] FOREIGN KEY ([ProyectoId]) REFERENCES [PR.Proyecto]([Id]),
	CONSTRAINT [FK_ADM.ContactoProyecto_Empresa] FOREIGN KEY ([ContactoId]) REFERENCES [ADM.Contacto]([PersonaId])
)
