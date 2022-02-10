USE MASTER

IF EXISTS (SELECT * FROM SYSDATABASES WHERE NAME='DB_ADM_ASISTENCIA')
		DROP DATABASE DB_ADM_ASISTENCIA
GO
-- ==================================
--  CREACION DE BD EN EL DIRECTORIO
-- ================================== 
DECLARE @device_directory NVARCHAR(520)
SELECT @device_directory = SUBSTRING(filename, 1, CHARINDEX(N'MASTER.MDF', LOWER(filename)) - 1)
FROM MASTER.dbo.sysaltfiles WHERE dbid = 1 AND fileid = 1

EXECUTE (N'CREATE DATABASE DB_ADM_ASISTENCIA
  ON PRIMARY (NAME = N''DB_ADM_ASISTENCIA_DAT'', FILENAME = N''' + @device_directory + N'DB_ADM_ASISTENCIA_DAT.MDF'',
	SIZE = 50,
	MAXSIZE = 250,
	FILEGROWTH = 50%
  )
  LOG ON (NAME = N''CAMPUS_LOG'',  FILENAME = N''' + @device_directory + N'DB_ADM_ASISTENCIA_LOG.LDF'',
	SIZE = 25,
	MAXSIZE = UNLIMITED,
    FILEGROWTH = 10%
  )')
 GO
-- ==================================
--        CREACION DE TABLAS 
-- ================================== 
USE DB_ADM_ASISTENCIA
GO

CREATE TABLE USUARIO
(
   ID_USUARIO INT IDENTITY (10001,1) PRIMARY KEY NOT NULL,
   USUARIO VARCHAR(30) NOT NULL,
   CONTRASENA VARCHAR (20) NOT NULL,
   PERFIL VARCHAR (20) NOT NULL,
   ESTADO VARCHAR (20)NOT NULL
)
GO

-- =====================================================
--       CARGA DE DATOS A LA TABLA USUARIO
-- =====================================================
INSERT "USUARIO" VALUES('cvilla','123Cri','ADMINISTRADOR','ACTIVO');
INSERT "USUARIO" VALUES('cv','123Cris','USUARIO AUDITOR','BAJA');
GO
-- =====================================================
--       CREACION DE PROCEDIMIENTOS ALMACENADOS
-- =====================================================
CREATE PROC sp_MostrarUsuarios
AS
SELECT * FROM USUARIO
GO
-- =====================================================
--       EXEC PROCEDIMEINTO
-- =====================================================
EXEC sp_MostrarUsuarios
GO

