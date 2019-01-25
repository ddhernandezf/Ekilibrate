CREATE TABLE [dbo].[ADM.Empresa]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[Nombre] NVARCHAR(100) NOT NULL,
	[PBX] NVARCHAR(20) NOT NULL,
	[Direccion] NVARCHAR(500) NOT NULL,
	[CantidadTotalEmpleados] INT NOT NULL DEFAULT 0,
	[CantidadAdministrativo] INT NOT NULL DEFAULT 0,
	[CantidadDistribucion] INT NOT NULL DEFAULT 0,
	[CantidadVentas] INT NOT NULL DEFAULT 0,
	[CantidadProduccion] INT  NOT NULL DEFAULT 0,
	[OtrosDescripcion] VARCHAR(50) NOT NULL DEFAULT '',
	[CantidadOtros] INT DEFAULT 0,
	[GiroId] INT NOT NULL,     
    CONSTRAINT [FK_ADM.Empresa_Giro] FOREIGN KEY ([GiroId]) REFERENCES [CA.GiroEmpresa]([Id]),
)
