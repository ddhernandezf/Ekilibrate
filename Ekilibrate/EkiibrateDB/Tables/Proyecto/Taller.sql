CREATE TABLE [dbo].[PR.Taller]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [ProyectoId] INT NOT NULL,
    [TallerId] INT NOT NULL, 
    [GrupoId] INT NOT NULL, 
	[FacilitadorId] INT NOT NULL,
	[NoSesiones] INT NOT NULL, 
    [DuracionSesiones] TIME NOT NULL, 
	[FrecuenciaSesiones] INT NOT NULL, 
    [FrecuenciaSesionesUnidad] INT NOT NULL, 
	[SalonId] INT NOT NULL,
	[HoraInicio] TIME NOT NULL,
	[HoraFin] TIME NOT NULL,
	[Lunes] BIT NOT NULL DEFAULT 0, 
    [Martes] BIT NOT NULL DEFAULT 0, 
    [Miercoles] BIT NOT NULL DEFAULT 0, 
    [Jueves] BIT NOT NULL DEFAULT 0, 
    [Viernes] BIT NOT NULL DEFAULT 0, 
    [Sabado] BIT NOT NULL DEFAULT 0, 
    [Domingo] BIT NOT NULL DEFAULT 0
    CONSTRAINT [FK_PR.Taller_Proyecto] FOREIGN KEY ([ProyectoId]) REFERENCES [PR.Proyecto]([Id]),
	CONSTRAINT [FK_FR.Taller_Grupo] FOREIGN KEY ([GrupoId]) REFERENCES [PR.Grupo]([Id]),
	CONSTRAINT [FK_FR.Taller_Facilitador] FOREIGN KEY ([FacilitadorId]) REFERENCES [ADM.Colaborador]([Id]),
	CONSTRAINT [FK_FR.Taller_CA_Taller] FOREIGN KEY ([TallerId]) REFERENCES [CA.Taller]([Id]),
	CONSTRAINT [FK_FR.Taller_Salon] FOREIGN KEY ([SalonId]) REFERENCES [ADM.Salon]([Id])
)
