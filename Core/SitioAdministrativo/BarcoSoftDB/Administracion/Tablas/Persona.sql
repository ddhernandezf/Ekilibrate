CREATE TABLE [Administracion].[Persona]
(
	[IdPersona] INT NOT NULL PRIMARY KEY IDENTITY, 
	[Nombres] VARCHAR(75) NOT NULL,
	[Apellidos] VARCHAR(75) NOT NULL,
	[NombreCompleto] VARCHAR(150) NOT NULL,
	[Telefono] VARCHAR(15), 
	[Email] VARCHAR(360) NULL,
	[Activo]  BIT NOT NULL
	  
)
