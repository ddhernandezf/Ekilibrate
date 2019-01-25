CREATE TABLE [dbo].[GE.Persona]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [PrimerNombre] NVARCHAR(150) NOT NULL, 
    [PrimerApellido] NVARCHAR(150) NOT NULL, 
    [Telefono] NVARCHAR(24) NULL, 
    [Direccion] NVARCHAR(MAX) NULL, 
    [Correo] NVARCHAR(MAX) NOT NULL, 
    [Extension] NVARCHAR(8) NULL, 
    [Puesto] NVARCHAR(250) NULL, 
    [FotoPerfil] VARBINARY(MAX) NULL, 
	[Celular] NVARCHAR(24) NULL,
	[SegundoNombre] NVARCHAR(150) NULL, 
    [SegundoApellido] NVARCHAR(150) NULL, 
	[ApellidoCasada] NVARCHAR(150) NULL, 
    [Departamento] NCHAR(150) NULL
)
