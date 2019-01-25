-- [dbo].[CA.RolNutricionista]
INSERT INTO [dbo].[CA.RolNutricionista] VALUES (1, 'Líder');
INSERT INTO [dbo].[CA.RolNutricionista] VALUES (2, 'Clínica');
GO
-- [dbo].[CA.Area]
INSERT INTO [dbo].[CA.Area] VALUES (1, 'Cuidado de la Salud', 0);
INSERT INTO [dbo].[CA.Area] VALUES (2, 'Manejo de Emociones', 0);
INSERT INTO [dbo].[CA.Area] VALUES (3, 'Relaciones Interpersonales', 0);
INSERT INTO [dbo].[CA.Area] VALUES (4, 'Desarrollo Personal', 0);
GO
-- [dbo].[CA.GiroEmpresa]
INSERT INTO [dbo].[CA.GiroEmpresa] VALUES (1, 'Banca y Finanzas', 0);
INSERT INTO [dbo].[CA.GiroEmpresa] VALUES (2, 'Alimentos y Bebidas', 0);
INSERT INTO [dbo].[CA.GiroEmpresa] VALUES (3, 'Servicios Generales', 0);
INSERT INTO [dbo].[CA.GiroEmpresa] VALUES (4, 'Maquinaria y Construcción', 0);
INSERT INTO [dbo].[CA.GiroEmpresa] VALUES (5, 'Agrícola', 0);
GO
-- [dbo].[CA.TipoUsoSalon]
INSERT INTO [dbo].[CA.TipoUsoSalon] VALUES (1, 'Reuniones');
INSERT INTO [dbo].[CA.TipoUsoSalon] VALUES (2, 'Capacitaciones');
INSERT INTO [dbo].[CA.TipoUsoSalon] VALUES (3, 'Conferencias');
GO
-- [dbo].[CA.Pais]
INSERT INTO [dbo].[CA.Pais] VALUES (1, 'Guatemala');
INSERT INTO [dbo].[CA.Pais] VALUES (2, 'El Salvador');
INSERT INTO [dbo].[CA.Pais] VALUES (3, 'Honduras');
INSERT INTO [dbo].[CA.Pais] VALUES (4, 'Nicaragua');
INSERT INTO [dbo].[CA.Pais] VALUES (5, 'Costa Rica');
INSERT INTO [dbo].[CA.Pais] VALUES (6, 'Panamá');
GO
-- [dbo].[CA.MedioComunicacion]
INSERT INTO [dbo].[CA.MedioComunicacion] VALUES (1, 'Llamada');
INSERT INTO [dbo].[CA.MedioComunicacion] VALUES (2, 'Mensajito');
INSERT INTO [dbo].[CA.MedioComunicacion] VALUES (3, 'Whatsapp');
INSERT INTO [dbo].[CA.MedioComunicacion] VALUES (4, 'Correo');
GO
-- [dbo].[CA.Aseguradora]
INSERT INTO [dbo].[CA.Aseguradora] VALUES (1, 'El Roble');
INSERT INTO [dbo].[CA.Aseguradora] VALUES (2, 'Aseguradora General');
INSERT INTO [dbo].[CA.Aseguradora] VALUES (3, 'Panamerican Life');
INSERT INTO [dbo].[CA.Aseguradora] VALUES (4, 'Seguros Gyt');
INSERT INTO [dbo].[CA.Aseguradora] VALUES (5, 'Seguros Universales');
INSERT INTO [dbo].[CA.Aseguradora] VALUES (6, 'Seguros de Occidente');
INSERT INTO [dbo].[CA.Aseguradora] VALUES (7, 'Mafpre');
INSERT INTO [dbo].[CA.Aseguradora] VALUES (8, 'BMI');
INSERT INTO [dbo].[CA.Aseguradora] VALUES (9, 'La Ceiba');
INSERT INTO [dbo].[CA.Aseguradora] VALUES (10, 'Seguros Agromercantil');
INSERT INTO [dbo].[CA.Aseguradora] VALUES (11, 'Aseguradora Rural');
GO
-- [dbo].[CA.UnidadTiempo]
INSERT INTO [dbo].[CA.UnidadTiempo] VALUES (1, 'Minutos');
INSERT INTO [dbo].[CA.UnidadTiempo] VALUES (2, 'Horas');
GO
-- [dbo].[CA.CitaDia]
INSERT INTO [dbo].[CA.CitaDia] VALUES (1, 'Lunes');
INSERT INTO [dbo].[CA.CitaDia] VALUES (2, 'Martes');
INSERT INTO [dbo].[CA.CitaDia] VALUES (3, 'Miércoles');
INSERT INTO [dbo].[CA.CitaDia] VALUES (4, 'Jueves');
INSERT INTO [dbo].[CA.CitaDia] VALUES (5, 'Viernes');
INSERT INTO [dbo].[CA.CitaDia] VALUES (6, 'Sábado');
INSERT INTO [dbo].[CA.CitaDia] VALUES (7, 'Domingo');
GO
-- [dbo].[CA.CitaDuracion]
INSERT INTO [dbo].[CA.CitaDuracion] VALUES (1, '30 Minutos', '00:30', 30, 1);
GO
-- [dbo].[CA.CitaHora]
INSERT INTO [dbo].[CA.CitaHora] VALUES (1, 1, '00:00');
INSERT INTO [dbo].[CA.CitaHora] VALUES (2, 1, '00:30');
INSERT INTO [dbo].[CA.CitaHora] VALUES (3, 1, '01:00');
INSERT INTO [dbo].[CA.CitaHora] VALUES (4, 1, '01:30');
INSERT INTO [dbo].[CA.CitaHora] VALUES (5, 1, '02:00');
INSERT INTO [dbo].[CA.CitaHora] VALUES (6, 1, '02:30');
INSERT INTO [dbo].[CA.CitaHora] VALUES (7, 1, '03:00');
INSERT INTO [dbo].[CA.CitaHora] VALUES (8, 1, '03:30');
INSERT INTO [dbo].[CA.CitaHora] VALUES (9, 1, '04:00');
INSERT INTO [dbo].[CA.CitaHora] VALUES (10, 1, '04:30');
INSERT INTO [dbo].[CA.CitaHora] VALUES (11, 1, '05:00');
INSERT INTO [dbo].[CA.CitaHora] VALUES (12, 1, '05:30');
INSERT INTO [dbo].[CA.CitaHora] VALUES (13, 1, '06:00');
INSERT INTO [dbo].[CA.CitaHora] VALUES (14, 1, '06:30');
INSERT INTO [dbo].[CA.CitaHora] VALUES (15, 1, '07:00');
INSERT INTO [dbo].[CA.CitaHora] VALUES (16, 1, '07:30');
INSERT INTO [dbo].[CA.CitaHora] VALUES (17, 1, '08:00');
INSERT INTO [dbo].[CA.CitaHora] VALUES (18, 1, '08:30');
INSERT INTO [dbo].[CA.CitaHora] VALUES (19, 1, '09:00');
INSERT INTO [dbo].[CA.CitaHora] VALUES (20, 1, '09:30');
INSERT INTO [dbo].[CA.CitaHora] VALUES (21, 1, '10:00');
INSERT INTO [dbo].[CA.CitaHora] VALUES (22, 1, '10:30');
INSERT INTO [dbo].[CA.CitaHora] VALUES (23, 1, '11:00');
INSERT INTO [dbo].[CA.CitaHora] VALUES (24, 1, '11:30');
INSERT INTO [dbo].[CA.CitaHora] VALUES (25, 1, '12:00');
INSERT INTO [dbo].[CA.CitaHora] VALUES (26, 1, '12:30');
INSERT INTO [dbo].[CA.CitaHora] VALUES (27, 1, '13:00');
INSERT INTO [dbo].[CA.CitaHora] VALUES (28, 1, '13:30');
INSERT INTO [dbo].[CA.CitaHora] VALUES (29, 1, '14:00');
INSERT INTO [dbo].[CA.CitaHora] VALUES (30, 1, '14:30');
INSERT INTO [dbo].[CA.CitaHora] VALUES (31, 1, '15:00');
INSERT INTO [dbo].[CA.CitaHora] VALUES (32, 1, '15:30');
INSERT INTO [dbo].[CA.CitaHora] VALUES (33, 1, '16:00');
INSERT INTO [dbo].[CA.CitaHora] VALUES (34, 1, '16:30');
INSERT INTO [dbo].[CA.CitaHora] VALUES (35, 1, '17:00');
INSERT INTO [dbo].[CA.CitaHora] VALUES (36, 1, '17:30');
INSERT INTO [dbo].[CA.CitaHora] VALUES (37, 1, '18:00');
INSERT INTO [dbo].[CA.CitaHora] VALUES (38, 1, '18:30');
INSERT INTO [dbo].[CA.CitaHora] VALUES (39, 1, '19:00');
INSERT INTO [dbo].[CA.CitaHora] VALUES (40, 1, '19:30');
INSERT INTO [dbo].[CA.CitaHora] VALUES (41, 1, '20:00');
INSERT INTO [dbo].[CA.CitaHora] VALUES (42, 1, '20:30');
INSERT INTO [dbo].[CA.CitaHora] VALUES (43, 1, '21:00');
INSERT INTO [dbo].[CA.CitaHora] VALUES (44, 1, '21:30');
INSERT INTO [dbo].[CA.CitaHora] VALUES (45, 1, '22:00');
INSERT INTO [dbo].[CA.CitaHora] VALUES (46, 1, '22:30');
INSERT INTO [dbo].[CA.CitaHora] VALUES (47, 1, '23:00');
INSERT INTO [dbo].[CA.CitaHora] VALUES (48, 1, '23:30');
-- [dbo].[CA.GrupoAlimento]
INSERT INTO [dbo].[CA.GrupoAlimento] VALUES (1, 'Lácteos');
INSERT INTO [dbo].[CA.GrupoAlimento] VALUES (2, 'Cereales');
INSERT INTO [dbo].[CA.GrupoAlimento] VALUES (3, 'Vegetales');
INSERT INTO [dbo].[CA.GrupoAlimento] VALUES (4, 'Frutas');
INSERT INTO [dbo].[CA.GrupoAlimento] VALUES (5, 'Carnes');
INSERT INTO [dbo].[CA.GrupoAlimento] VALUES (6, 'Grasas');
INSERT INTO [dbo].[CA.GrupoAlimento] VALUES (7, 'Azúcares');
