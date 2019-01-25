CREATE TABLE [dbo].[GE.CorreoElectronico]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[Correo] varchar(100),
	[Host] varchar (MAX),
	[Puerto] int,
	[Usuario] varchar(100),
	[Password] varchar(100),
	[Operacion] varchar(100)

)
