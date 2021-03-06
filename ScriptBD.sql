CREATE DATABASE SisGestion
go
USE SisGestion
go

CREATE TABLE banco
(
	Clave varchar(20) NOT NULL,
	Nombre varchar(70) NULL,
	CtaBanco varchar(70) NULL,
	CONSTRAINT PK_banco PRIMARY KEY CLUSTERED (Clave) 
)
go

CREATE TABLE concepto
(
	Clave varchar(20) NOT NULL,
	Descripcion varchar(70) NULL,
	CONSTRAINT PK_concepto_1 PRIMARY KEY CLUSTERED (Clave)
)
go

CREATE TABLE contacto
(
	Persona bigint NOT NULL,
	Direccion varchar(500) NULL,
	TelefonoCasa varchar(10) NULL,
	TelefonoOficina varchar(10) NULL,
	TelefonoCelular varchar(10) NULL,
	Correo varchar(35) NULL,
	CorreoAlt varchar(35) NULL,
	CONSTRAINT PK_contacto PRIMARY KEY CLUSTERED (Persona) 
)
go

CREATE TABLE egresos
(
	Id bigint NOT NULL,
	NoCheque varchar(70) NULL,
	CtaBanco varchar(20) NULL,
	Fecha datetime NULL,
	TipoEgreso varchar(20) NULL,
	SubTipoEgreso varchar(20) NULL,
	Concepto varchar(20) NULL,
	Proveedor bigint NULL,
	Subtotal decimal(18, 2) NULL,
	Impuesto varchar(20) NULL,
	Total decimal(18, 2) NULL,
	Estatus tinyint NULL,
	CONSTRAINT PK_egresos PRIMARY KEY CLUSTERED (Id) 
)
go

CREATE TABLE impuesto
(
	Clave varchar(20) NOT NULL,
	Tasa decimal(18, 2) NULL,
	CONSTRAINT PK_impuesto PRIMARY KEY CLUSTERED (Clave) 
)
go

CREATE TABLE ingresos
(
	Id bigint NOT NULL,
	Serie varchar(20) NULL,
	Folio varchar(50) NULL,
	Emision datetime NULL,
	Pago datetime NULL,
	TipoIngreso varchar(20) NULL,
	SubTipoIngreso varchar(20) NULL,
	Concepto varchar(20) NULL,
	Cliente bigint NULL,
	Subtotal decimal(18, 2) NULL,
	Impuesto varchar(20) NULL,
	Total decimal(18, 2) NULL,
	Estatus tinyint NULL,
	CONSTRAINT PK_ingresos PRIMARY KEY CLUSTERED (Id) 
)

CREATE TABLE periodicidad
(
	Id int NOT NULL,
	Periodicidad varchar(40) NULL,
	CONSTRAINT PK_periodicidad PRIMARY KEY CLUSTERED (Id) 
)
go

CREATE TABLE persona
(
	Id bigint NOT NULL,
	ApellidoPaterno varchar(80) NULL,
	ApellidoMaterno varchar(80) NULL,
	Nombre varchar(80) NULL,
	FechaNacimiento date NULL,
	Sexo char(1) NULL,
	FechaRegistro datetime NULL,
	Curp varchar(18) NULL,
	Rfc varchar(13) NULL,
	RazonSocial varchar(80) NULL,
	NombreComercial varchar(80) NULL,
	Tipo tinyint NULL,
	Estatus tinyint NULL,
	CONSTRAINT PK_persona PRIMARY KEY CLUSTERED (Id) 
)
go

CREATE TABLE presupuesto
(
	Clave varchar(20) NOT NULL,
	Tipo varchar(20) NULL,
	Subtipo varchar(20) NULL,
	Anio int NULL,
	Meses varchar(100) NULL,
	CONSTRAINT PK_presupuesto PRIMARY KEY CLUSTERED (Clave) 
)
go

CREATE TABLE recibo
(
	Serie varchar(20) NOT NULL,
	Folio varchar(50) NULL,
	Descripcion varchar(155) NULL,
	CONSTRAINT PK_recibo PRIMARY KEY CLUSTERED (Serie) 
)
go

CREATE TABLE referencia
(
	Clave varchar(20) NOT NULL,
	Persona bigint NULL,
	Nombre varchar(50) NULL,
	Tipo int NULL,
	CONSTRAINT PK_referencia PRIMARY KEY CLUSTERED (Clave) 
)
go

CREATE TABLE subtipo_egreso_ingreso
(
	Clave varchar(20) NOT NULL,
	Nombre varchar(70) NULL,
	Clave_Tipo varchar(20) NULL,
	CONSTRAINT PK_subtipo_egreso_ingreso PRIMARY KEY CLUSTERED (Clave) 
)
go

CREATE TABLE tipo_egreso_ingreso
(
	Clave varchar(20) NOT NULL,
	Nombre varchar(70) NULL,
	Tipo tinyint NULL,
	CONSTRAINT PK_tipo_egreso_ingreso PRIMARY KEY CLUSTERED (Clave) 
)
go

CREATE TABLE tipo_referencia
(
	Id int NOT NULL,
	Nombre varchar(50) NULL,
	CONSTRAINT PK_tipo_referencia PRIMARY KEY CLUSTERED (Id) 
)
go

CREATE TABLE UsuariosSistema
(
	Usuario varchar(15) NOT NULL,
	Password varchar(15) NOT NULL,
	Tipo char(1) NOT NULL,
	PRIMARY KEY CLUSTERED (Usuario) 
)
go

ALTER TABLE contacto  WITH CHECK ADD  CONSTRAINT FK_contacto_persona FOREIGN KEY (Persona)
REFERENCES persona (Id)
ON UPDATE CASCADE
ON DELETE CASCADE
go

ALTER TABLE contacto CHECK CONSTRAINT FK_contacto_persona
go

ALTER TABLE egresos  WITH CHECK ADD  CONSTRAINT FK_egresos_banco FOREIGN KEY (CtaBanco)
REFERENCES banco (Clave)
ON UPDATE CASCADE
ON DELETE CASCADE
go

ALTER TABLE egresos CHECK CONSTRAINT FK_egresos_banco
go

ALTER TABLE egresos  WITH CHECK ADD  CONSTRAINT FK_egresos_concepto1 FOREIGN KEY (Concepto)
REFERENCES concepto (Clave)
ON UPDATE CASCADE
ON DELETE CASCADE
go

ALTER TABLE egresos CHECK CONSTRAINT FK_egresos_concepto1
go

ALTER TABLE egresos  WITH CHECK ADD  CONSTRAINT FK_egresos_impuesto FOREIGN KEY (Impuesto)
REFERENCES impuesto (Clave)
ON UPDATE CASCADE
ON DELETE CASCADE
go

ALTER TABLE egresos CHECK CONSTRAINT FK_egresos_impuesto
go

ALTER TABLE egresos  WITH CHECK ADD  CONSTRAINT FK_egresos_persona FOREIGN KEY (Proveedor)
REFERENCES persona (Id)
ON UPDATE CASCADE
ON DELETE CASCADE
go

ALTER TABLE egresos CHECK CONSTRAINT FK_egresos_persona
go

ALTER TABLE egresos  WITH CHECK ADD  CONSTRAINT FK_egresos_subtipo_egreso_ingreso FOREIGN KEY (SubTipoEgreso)
REFERENCES subtipo_egreso_ingreso (Clave)
go

ALTER TABLE egresos CHECK CONSTRAINT FK_egresos_subtipo_egreso_ingreso
go

ALTER TABLE egresos  WITH CHECK ADD  CONSTRAINT FK_egresos_tipo_egreso_ingreso FOREIGN KEY (TipoEgreso)
REFERENCES tipo_egreso_ingreso (Clave)
ON UPDATE CASCADE
ON DELETE CASCADE
go

ALTER TABLE egresos CHECK CONSTRAINT FK_egresos_tipo_egreso_ingreso
go

ALTER TABLE ingresos  WITH CHECK ADD  CONSTRAINT FK_ingresos_concepto1 FOREIGN KEY (Concepto)
REFERENCES concepto (Clave)
ON UPDATE CASCADE
ON DELETE CASCADE
go

ALTER TABLE ingresos CHECK CONSTRAINT FK_ingresos_concepto1
go

ALTER TABLE ingresos  WITH CHECK ADD  CONSTRAINT FK_ingresos_impuesto FOREIGN KEY (Impuesto)
REFERENCES impuesto (Clave)
ON UPDATE CASCADE
ON DELETE CASCADE
go

ALTER TABLE ingresos CHECK CONSTRAINT FK_ingresos_impuesto
go

ALTER TABLE ingresos  WITH CHECK ADD  CONSTRAINT FK_ingresos_persona FOREIGN KEY (Cliente)
REFERENCES persona (Id)
ON UPDATE CASCADE
ON DELETE CASCADE
go

ALTER TABLE ingresos CHECK CONSTRAINT FK_ingresos_persona
go

ALTER TABLE ingresos  WITH CHECK ADD  CONSTRAINT FK_ingresos_recibo FOREIGN KEY (Serie)
REFERENCES recibo (Serie)
ON UPDATE CASCADE
ON DELETE CASCADE
go

ALTER TABLE ingresos CHECK CONSTRAINT FK_ingresos_recibo
go

ALTER TABLE ingresos  WITH CHECK ADD  CONSTRAINT FK_ingresos_subtipo_egreso_ingreso FOREIGN KEY (SubTipoIngreso)
REFERENCES subtipo_egreso_ingreso (Clave)
go

ALTER TABLE ingresos CHECK CONSTRAINT FK_ingresos_subtipo_egreso_ingreso
go

ALTER TABLE ingresos  WITH CHECK ADD  CONSTRAINT FK_ingresos_tipo_egreso_ingreso FOREIGN KEY (TipoIngreso)
REFERENCES tipo_egreso_ingreso (Clave)
ON UPDATE CASCADE
ON DELETE CASCADE
go

ALTER TABLE ingresos CHECK CONSTRAINT FK_ingresos_tipo_egreso_ingreso
go

ALTER TABLE presupuesto  WITH CHECK ADD  CONSTRAINT FK_presupuesto_subtipo_egreso_ingreso FOREIGN KEY (Subtipo)
REFERENCES subtipo_egreso_ingreso (Clave)
ON UPDATE CASCADE
ON DELETE CASCADE
go

ALTER TABLE presupuesto CHECK CONSTRAINT FK_presupuesto_subtipo_egreso_ingreso
go

ALTER TABLE presupuesto  WITH CHECK ADD  CONSTRAINT FK_presupuesto_tipo_egreso_ingreso FOREIGN KEY (Tipo)
REFERENCES tipo_egreso_ingreso (Clave)
go

ALTER TABLE presupuesto CHECK CONSTRAINT FK_presupuesto_tipo_egreso_ingreso
go

ALTER TABLE referencia  WITH CHECK ADD  CONSTRAINT FK_referencia_persona FOREIGN KEY (Persona)
REFERENCES persona (Id)
ON UPDATE CASCADE
ON DELETE CASCADE
go

ALTER TABLE referencia CHECK CONSTRAINT FK_referencia_persona
go

ALTER TABLE referencia  WITH CHECK ADD  CONSTRAINT FK_referencia_tipo_referencia FOREIGN KEY (Tipo)
REFERENCES tipo_referencia (Id)
ON UPDATE CASCADE
ON DELETE CASCADE
go

ALTER TABLE referencia CHECK CONSTRAINT FK_referencia_tipo_referencia
go

ALTER TABLE subtipo_egreso_ingreso  WITH CHECK ADD  CONSTRAINT FK_subtipo_egreso_ingreso_tipo_egreso_ingreso FOREIGN KEY (Clave_Tipo)
REFERENCES tipo_egreso_ingreso (Clave)
ON UPDATE CASCADE
ON DELETE CASCADE
go

ALTER TABLE subtipo_egreso_ingreso CHECK CONSTRAINT FK_subtipo_egreso_ingreso_tipo_egreso_ingreso
go

INSERT INTO UsuariosSistema (Usuario,Password,Tipo) VALUES ('Admin', '123456', 1)
go
