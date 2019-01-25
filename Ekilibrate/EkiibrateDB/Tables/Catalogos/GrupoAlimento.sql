CREATE TABLE [dbo].[CA.GrupoAlimento]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Nombre] NVARCHAR(50) NOT NULL, 
    [IconoURL] NVARCHAR(100) NULL, 
    [Calorias] INT NOT NULL DEFAULT 0, 
    [Proteinas] INT NOT NULL DEFAULT 0, 
    [Carbohidratos] INT NOT NULL DEFAULT 0, 
    [Grasas] INT NOT NULL DEFAULT 0,
	[NombreColumnaModelo] VARCHAR(50)
)
