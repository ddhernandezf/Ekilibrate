﻿CREATE TABLE [dbo].[PR.Proyecto]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [EmpresaId] INT NOT NULL, 
    [Estado] NVARCHAR(50) NOT NULL, 
    [FechaInicio] DATE NOT NULL, 
    [FechaFin] DATE NOT NULL, 
    [NoSemanas] INT NOT NULL, 
    [NoParticipantes] INT NOT NULL, 
    [NoEnfermeras] INT NOT NULL, 
    [NoFacilitadores] INT NOT NULL, 
    [NoAsistentes] INT NOT NULL, 
    [NoConsultasNutricionales] INT NOT NULL, 
    [FrecuenciaConsultas] INT NOT NULL,
	[FrecuenciaAlertas] INT NOT NULL, 
    [FrecuenciaAlertasUnidad] INT NOT NULL, 
	[FrecuenciaConsultasUnidad] INT NOT NULL, 
	[Color] NVARCHAR(10) NULL, 
    [CrearUsuarios] BIT NULL, 
	[LogoURL] NVARCHAR(500) NULL, 
    [AseguradoraId] INT NULL, 
    [IndiceReclamos] DECIMAL(10, 2) NULL, 
    [NoParticipantesPorGrupo] INT NULL, 
    [FechaCorreoInvitacion] DATE NULL, 
    [FechaPrimeraCitaDiagnostico] DATE NULL, 	
    [CitasProgramadas] BIT NULL DEFAULT 0, 
    [MetasCalculadas] BIT NULL DEFAULT 0, 
	[FechaInicioConsultas] DATE NULL, 
	[HoraInicioConsultas] TIME DEFAULT '08:00:00', 
    [HoraFinConsultas] TIME DEFAULT '17:00:00',
	[DuracionConsultas] TIME NULL DEFAULT '00:30:00',
	[NoNutricionistas] INT NOT NULL DEFAULT 1, 
	[TipoProyectoId] INT NULL, 
	[Nombre] VARCHAR(25),
	[CodigoRegistro] VARCHAR(25),
	[Correo] VARCHAR(500),
	[PasswordCorreo] VARCHAR(25),
	[UsuarioCreador] INT NULL, 
	[FechaInicioBx] DATE NULL,
	[HoraInicioBx] TIME DEFAULT '06:00:00', 
    [HoraFinBx] TIME DEFAULT '08:00:00',
	[HoraInicioDN] TIME DEFAULT '08:00:00', 
    [HoraFinDN] TIME DEFAULT '17:00:00',
	[DuracionDN] TIME NULL DEFAULT '00:30:00',
	[HtmlDiagnostico] VARCHAR(MAX),
	[HtmlLanzamiento] VARCHAR(MAX),
	[HtmlConsultas] VARCHAR(MAX),
    CONSTRAINT [FK_PR.Proyecto_TipoProyecto] FOREIGN KEY ([TipoProyectoId]) REFERENCES [CA.TipoProyecto]([Id]),
    CONSTRAINT [FK_PR.Proyecto_Aseguradora] FOREIGN KEY ([AseguradoraId]) REFERENCES [CA.Aseguradora]([Id]),
	CONSTRAINT [FK_PR.Proyecto_Empresa] FOREIGN KEY ([EmpresaId]) REFERENCES [ADM.Empresa]([Id]),	
)
