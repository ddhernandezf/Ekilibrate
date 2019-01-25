CREATE TABLE [dbo].[NU.PlanAlimentacion]
(
	[CitaId] INT NOT NULL PRIMARY KEY, 
	[ParticipanteId] INT NOT NULL, 
    [FileName] NVARCHAR(MAX) NOT NULL, 
    [File] VARBINARY(MAX) NULL, 
    [Desayuno] NVARCHAR(MAX) NULL, 
    [RefaccionAm] NVARCHAR(MAX) NULL, 
    [Almuerzo] NVARCHAR(MAX) NULL, 
    [RefaccionPm] NVARCHAR(MAX) NULL, 
    [Cena] NVARCHAR(MAX) NULL, 
    [Frutas] INT NULL, 
    [Cereales] INT NULL, 
    [Vegetales] INT NULL, 
    [Carnes] INT NULL, 
    [Azucares] INT NULL, 
    [Lacteos] INT NULL, 
    [LacteosDescremados] INT NULL, 
    [LacteosSemi] INT NULL, 
    [Grasas] NCHAR(10) NULL	
)
