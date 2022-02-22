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

CREATE TABLE AREA
(
   ID_AREA INT IDENTITY (101,1) PRIMARY KEY NOT NULL,
   NOMBRE VARCHAR(30) NOT NULL,
   OFICINA VARCHAR(30) NOT NULL,
   DIREC VARCHAR(50) NOT NULL,
   ESTADO VARCHAR(10) NOT NULL
)
GO

CREATE TABLE EMPLEADO
(
   ID_EMP INT IDENTITY (10001,1) PRIMARY KEY NOT NULL,
   NOMBRE VARCHAR(30) NOT NULL,
   APELLIDO VARCHAR (20) NOT NULL,
   DNI VARCHAR (20) NOT NULL,
   FECHA_NAC VARCHAR (10) NOT NULL,
   DISTRITO VARCHAR (20) NOT NULL,
   DIR_DOM VARCHAR (50) NOT NULL,
   ESTADO VARCHAR (10) NOT NULL,
   ID_AREA VARCHAR (10)NOT NULL
)
GO

CREATE TABLE USUARIO
(
   USUARIO VARCHAR (20) PRIMARY KEY NOT NULL,
   CONTRASENA VARCHAR (20) NOT NULL,
   PERFIL VARCHAR (20) NOT NULL,
   ESTADO VARCHAR (20)NOT NULL,
   ID_EMP VARCHAR (20)NOT NULL
)
GO

CREATE TABLE ASISTENCIA
(
   ID_ASI INT IDENTITY NOT NULL,
   ID_EMP INT NOT NULL,
   FECHA VARCHAR (12) NOT NULL,
   HORA_INGRESO VARCHAR (20),
   HORA_SALIDA VARCHAR (20),
)
GO


-- =====================================================
--       CARGA DE DATOS A LA TABLA USUARIO
-- =====================================================
INSERT "AREA" VALUES('FINANZAS','Principal','Calle Los Cisnes 322','ACTIVO');
INSERT "AREA" VALUES('MARKETING','Principal','Calle Los Cisnes 322','ACTIVO');
INSERT "AREA" VALUES('RIESGOS','Principal','Calle Los Cisnes 322','ACTIVO');
INSERT "AREA" VALUES('RECURSOS HUMANOS','Principal','Calle Los Cisnes 322','ACTIVO');
INSERT "AREA" VALUES('OPERACIONES','Principal','Calle Los Cisnes 722','ACTIVO');
GO


INSERT "EMPLEADO" VALUES('Cristian','Villafana','12286198','19/04/1893','Los Olivos','Av. Los Olivos','Activo','101');
INSERT "EMPLEADO" VALUES('Cri','Villafana','12286198','19/04/1893','Los Olivos','Av. Los Olivos','Activo','101');
INSERT "EMPLEADO" VALUES('Crist','Villafana','12286198','19/04/1893','Los Olivos','Av. Los Olivos','Activo','101');
INSERT "EMPLEADO" VALUES('Cri','Villafana','12286198','19/04/1893','Los Olivos','Av. Los Olivos','Activo','101');
GO


INSERT "USUARIO" VALUES('cvill','123Cris','ADMINISTRADOR','ACTIVO','10001');
INSERT "USUARIO" VALUES('cv','123Cris','ADMINISTRADOR','ACTIVO','10002');
INSERT "USUARIO" VALUES('c','123Cris','USUARIO AUDITOR','BAJA','10003');
INSERT "USUARIO" VALUES('cr','123Cris','USUARIO AUDITOR','BAJA','10002');
INSERT "USUARIO" VALUES('cri','123Cris','USUARIO AUDITOR','BAJA','10003');
GO

INSERT "ASISTENCIA" VALUES('10001','15/02/2022','08:30:25','15:35:25');
INSERT "ASISTENCIA" VALUES('10002','15/02/2022','08:30:25','15:35:25');
INSERT "ASISTENCIA" VALUES('10003','15/02/2022','08:30:25','15:35:25');

GO
-- =====================================================
--       CREACION DE PROCEDIMIENTOS ALMACENADOS
-- =====================================================

--======= TABLA AREA

--## PROC SELECT
CREATE PROC usp_MostrarAreas
AS
SELECT * FROM AREA
GO

--## PROC AGREGAR
CREATE PROC USP_ADAREA @DIREC VARCHAR(30), @NOMBRE VARCHAR(30), @OFICINA VARCHAR(30),
					 @ESTADO VARCHAR (10)
AS
INSERT AREA (NOMBRE,OFICINA,DIREC,ESTADO)
VALUES (@NOMBRE,@OFICINA,@DIREC,@ESTADO)
GO

--## PROC ACTUALIZAR
CREATE PROC USP_UPDAREA  @ID_AREA INT, @NOMBRE VARCHAR(30), @OFICINA VARCHAR(30),@DIREC VARCHAR(30),
						 @ESTADO VARCHAR (10)
AS
UPDATE AREA SET NOMBRE=@NOMBRE,OFICINA=@OFICINA,DIREC=@DIREC,ESTADO=@ESTADO
WHERE ID_AREA=@ID_AREA
GO
--## PROC ELIMINAR
CREATE PROC USP_DELAREA
@ID_AREA INT
AS
DELETE AREA  WHERE ID_AREA=@ID_AREA
GO

--======= TABLA EMPLEADO

--## PROC SELECT
CREATE PROC usp_MostrarEmpleados
AS
SELECT * FROM EMPLEADO
GO

--## PROC AGREGAR
CREATE PROC USP_ADEMPLEADO @NOMBRE VARCHAR(50), @APELLIDO VARCHAR(50),
						   @DNI VARCHAR(08), @FECHA_NAC VARCHAR(10), @DISTRITO VARCHAR (30),
						   @DIR_DOM VARCHAR (50), @ESTADO VARCHAR (10), @ID_AREA VARCHAR (10)
AS

INSERT EMPLEADO (NOMBRE,APELLIDO,DNI,FECHA_NAC, DISTRITO, DIR_DOM, ESTADO, ID_AREA)
VALUES (@NOMBRE,@APELLIDO,@DNI,@FECHA_NAC,@DISTRITO,@DIR_DOM,@ESTADO,@ID_AREA)
GO

--## PROC ACTUALIZAR
CREATE PROC USP_UPDEMPLEADO  @ID_EMP INT, @NOMBRE VARCHAR(50), @APELLIDO VARCHAR(50),
						     @DNI VARCHAR(08), @FECHA_NAC VARCHAR(10), @DISTRITO VARCHAR (30),
						     @DIR_DOM VARCHAR (50), @ESTADO VARCHAR (10), @ID_AREA VARCHAR (10)
AS
UPDATE EMPLEADO SET NOMBRE=@NOMBRE,APELLIDO=@APELLIDO,DNI=@DNI,FECHA_NAC=@FECHA_NAC, 
					DISTRITO = @DISTRITO, DIR_DOM=@DIR_DOM, ESTADO= @ESTADO, 
					ID_AREA=@ID_AREA
WHERE ID_EMP=@ID_EMP
GO

--## PROC ELIMINAR
CREATE PROC USP_DELEMPLEADO
@ID_EMP INT
AS
DELETE EMPLEADO WHERE ID_EMP=@ID_EMP
GO

--======= TABLA USUARIO
--## PROC SELECT
CREATE PROC usp_MostrarUsuarios
AS
SELECT * FROM USUARIO
GO
--## PROC AGREGAR
CREATE PROC USP_ADUSUARIOS @USUARIO VARCHAR(20), @CONTRASENA VARCHAR(50), @PERFIL VARCHAR(50), @ESTADO VARCHAR (20), @ID_EMP VARCHAR(50)					
AS
INSERT USUARIO (USUARIO,CONTRASENA,PERFIL,ESTADO,ID_EMP)
VALUES (@USUARIO,@CONTRASENA,@PERFIL,@ESTADO,@ID_EMP)
GO

--## PROC ACTUALIZAR
CREATE PROC USP_UPDUSUARIOS @USUARIO VARCHAR(20) ,@CONTRASENA VARCHAR(50), @PERFIL VARCHAR(50), @ESTADO VARCHAR (20), @ID_EMP VARCHAR(50)
AS
UPDATE USUARIO SET USUARIO= @USUARIO,CONTRASENA=@CONTRASENA,PERFIL=@PERFIL,ESTADO= @ESTADO,ID_EMP=@ID_EMP
WHERE USUARIO= @USUARIO
GO

--## PROC ELIMINAR
CREATE PROC USP_DELUSUARIO
@USUARIO VARCHAR (20)
AS
DELETE USUARIO WHERE USUARIO=@USUARIO
GO


--======= TABLA ASISTENCIA
--## PROC SELECT
-----
CREATE PROC usp_MostrarAsistencias
AS
SELECT * FROM ASISTENCIA
GO
--## PROC AGREGAR
CREATE PROC USP_ADASISTENCIA @ID_EMP INT,@FECHA VARCHAR(50), @HORA_INGRESO VARCHAR(50), @HORA_SALIDA VARCHAR(50)					
AS
INSERT ASISTENCIA (ID_EMP,FECHA,HORA_INGRESO,HORA_SALIDA)
VALUES (@ID_EMP,@FECHA,@HORA_INGRESO,@HORA_SALIDA)
GO
--## PROC ACTUALIZAR
CREATE PROC USP_UPDASISTENCIA  @ID_ASI INT, @ID_EMP INT,@FECHA VARCHAR(50), @HORA_INGRESO VARCHAR(50), @HORA_SALIDA VARCHAR(50)
AS
UPDATE ASISTENCIA SET ID_EMP=@ID_EMP,FECHA=@FECHA,HORA_INGRESO=@HORA_INGRESO,HORA_SALIDA=@HORA_SALIDA
WHERE ID_ASI= @ID_ASI
GO
--## PROC ELIMINAR
CREATE PROC USP_DELASISTENCIA
@ID_ASI INT
AS
DELETE ASISTENCIA WHERE ID_ASI= @ID_ASI
GO


-- =====================================================
--       EXEC PROCEDIMEINTOEXEC sp_MostrarAreas
GO

-----
EXEC usp_MostrarAreas
GO
-----
EXEC usp_MostrarEmpleados
GO

-----
EXEC usp_MostrarUsuarios
GO

-----
EXEC usp_MostrarAsistencias
GO

-- =====================================================


CREATE PROC USP_ADRG_ASIEMPLEADO @ID_EMP INT,@FECHA VARCHAR(50), @HORA_INGRESO VARCHAR(50),@HORA_SALIDA VARCHAR(50)					
AS
INSERT ASISTENCIA (ID_EMP,FECHA,HORA_INGRESO,HORA_SALIDA)
VALUES (@ID_EMP,@FECHA,@HORA_INGRESO,@HORA_SALIDA)
GO

