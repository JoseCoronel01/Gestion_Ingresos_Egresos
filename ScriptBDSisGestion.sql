--SqlServer 2019 18.11.1
CREATE DATABASE Portales;
GO

USE [Portales]
GO
/****** Object:  Table [dbo].[BDS]    Script Date: 18/05/2022 09:33:51 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BDS](
	[Clave] [varchar](20) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[CadenaConexion] [varchar](200) NULL,
 CONSTRAINT [PK_BDS] PRIMARY KEY CLUSTERED 
(
	[Clave] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE DATABASE SisGestion;
GO

USE [SisGestion]
GO
/****** Object:  Table [dbo].[banco]    Script Date: 18/05/2022 09:34:23 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[banco](
	[Clave] [varchar](20) NOT NULL,
	[Nombre] [varchar](70) NULL,
	[CtaBanco] [varchar](70) NULL,
 CONSTRAINT [PK_banco] PRIMARY KEY CLUSTERED 
(
	[Clave] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[concepto]    Script Date: 18/05/2022 09:34:23 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[concepto](
	[Clave] [varchar](20) NOT NULL,
	[Descripcion] [varchar](70) NULL,
 CONSTRAINT [PK_concepto_1] PRIMARY KEY CLUSTERED 
(
	[Clave] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[contacto]    Script Date: 18/05/2022 09:34:23 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[contacto](
	[Persona] [bigint] NOT NULL,
	[Direccion] [varchar](500) NULL,
	[TelefonoCasa] [varchar](10) NULL,
	[TelefonoOficina] [varchar](10) NULL,
	[TelefonoCelular] [varchar](10) NULL,
	[Correo] [varchar](35) NULL,
	[CorreoAlt] [varchar](35) NULL,
 CONSTRAINT [PK_contacto] PRIMARY KEY CLUSTERED 
(
	[Persona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[egresos]    Script Date: 18/05/2022 09:34:23 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[egresos](
	[Id] [bigint] NOT NULL,
	[NoCheque] [varchar](70) NULL,
	[CtaBanco] [varchar](20) NULL,
	[Fecha] [datetime] NULL,
	[TipoEgreso] [varchar](20) NULL,
	[SubTipoEgreso] [varchar](20) NULL,
	[Concepto] [varchar](20) NULL,
	[Proveedor] [bigint] NULL,
	[Subtotal] [decimal](18, 2) NULL,
	[Impuesto] [varchar](20) NULL,
	[Total] [decimal](18, 2) NULL,
	[Estatus] [tinyint] NULL,
 CONSTRAINT [PK_egresos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[impuesto]    Script Date: 18/05/2022 09:34:23 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[impuesto](
	[Clave] [varchar](20) NOT NULL,
	[Tasa] [decimal](18, 2) NULL,
 CONSTRAINT [PK_impuesto] PRIMARY KEY CLUSTERED 
(
	[Clave] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ingresos]    Script Date: 18/05/2022 09:34:23 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ingresos](
	[Id] [bigint] NOT NULL,
	[Serie] [varchar](20) NULL,
	[Folio] [varchar](50) NULL,
	[Emision] [datetime] NULL,
	[Pago] [datetime] NULL,
	[TipoIngreso] [varchar](20) NULL,
	[SubTipoIngreso] [varchar](20) NULL,
	[Concepto] [varchar](20) NULL,
	[Cliente] [bigint] NULL,
	[Subtotal] [decimal](18, 2) NULL,
	[Impuesto] [varchar](20) NULL,
	[Total] [decimal](18, 2) NULL,
	[Estatus] [tinyint] NULL,
 CONSTRAINT [PK_ingresos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[periodicidad]    Script Date: 18/05/2022 09:34:23 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[periodicidad](
	[Id] [int] NOT NULL,
	[Periodicidad] [varchar](40) NULL,
 CONSTRAINT [PK_periodicidad] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[persona]    Script Date: 18/05/2022 09:34:23 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[persona](
	[Id] [bigint] NOT NULL,
	[ApellidoPaterno] [varchar](80) NULL,
	[ApellidoMaterno] [varchar](80) NULL,
	[Nombre] [varchar](80) NULL,
	[FechaNacimiento] [date] NULL,
	[Sexo] [char](1) NULL,
	[FechaRegistro] [datetime] NULL,
	[Curp] [varchar](18) NULL,
	[Rfc] [varchar](13) NULL,
	[RazonSocial] [varchar](80) NULL,
	[NombreComercial] [varchar](80) NULL,
	[Tipo] [tinyint] NULL,
	[Estatus] [tinyint] NULL,
 CONSTRAINT [PK_persona] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[presupuesto]    Script Date: 18/05/2022 09:34:23 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[presupuesto](
	[Clave] [varchar](20) NOT NULL,
	[Tipo] [varchar](20) NULL,
	[Subtipo] [varchar](20) NULL,
	[Anio] [int] NULL,
	[Meses] [varchar](100) NULL,
 CONSTRAINT [PK_presupuesto] PRIMARY KEY CLUSTERED 
(
	[Clave] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[recibo]    Script Date: 18/05/2022 09:34:23 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[recibo](
	[Serie] [varchar](20) NOT NULL,
	[Folio] [varchar](50) NULL,
	[Descripcion] [varchar](155) NULL,
 CONSTRAINT [PK_recibo] PRIMARY KEY CLUSTERED 
(
	[Serie] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[referencia]    Script Date: 18/05/2022 09:34:23 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[referencia](
	[Clave] [varchar](20) NOT NULL,
	[Persona] [bigint] NULL,
	[Nombre] [varchar](50) NULL,
	[Tipo] [int] NULL,
 CONSTRAINT [PK_referencia] PRIMARY KEY CLUSTERED 
(
	[Clave] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[subtipo_egreso_ingreso]    Script Date: 18/05/2022 09:34:23 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[subtipo_egreso_ingreso](
	[Clave] [varchar](20) NOT NULL,
	[Nombre] [varchar](70) NULL,
	[Clave_Tipo] [varchar](20) NULL,
 CONSTRAINT [PK_subtipo_egreso_ingreso] PRIMARY KEY CLUSTERED 
(
	[Clave] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tipo_egreso_ingreso]    Script Date: 18/05/2022 09:34:23 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tipo_egreso_ingreso](
	[Clave] [varchar](20) NOT NULL,
	[Nombre] [varchar](70) NULL,
	[Tipo] [tinyint] NULL,
 CONSTRAINT [PK_tipo_egreso_ingreso] PRIMARY KEY CLUSTERED 
(
	[Clave] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tipo_referencia]    Script Date: 18/05/2022 09:34:23 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tipo_referencia](
	[Id] [int] NOT NULL,
	[Nombre] [varchar](50) NULL,
 CONSTRAINT [PK_tipo_referencia] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsuariosSistema]    Script Date: 18/05/2022 09:34:23 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuariosSistema](
	[Usuario] [varchar](15) NOT NULL,
	[Password] [varchar](15) NOT NULL,
	[Tipo] [char](1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[contacto]  WITH CHECK ADD  CONSTRAINT [FK_contacto_persona] FOREIGN KEY([Persona])
REFERENCES [dbo].[persona] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[contacto] CHECK CONSTRAINT [FK_contacto_persona]
GO
ALTER TABLE [dbo].[egresos]  WITH CHECK ADD  CONSTRAINT [FK_egresos_banco] FOREIGN KEY([CtaBanco])
REFERENCES [dbo].[banco] ([Clave])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[egresos] CHECK CONSTRAINT [FK_egresos_banco]
GO
ALTER TABLE [dbo].[egresos]  WITH CHECK ADD  CONSTRAINT [FK_egresos_concepto1] FOREIGN KEY([Concepto])
REFERENCES [dbo].[concepto] ([Clave])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[egresos] CHECK CONSTRAINT [FK_egresos_concepto1]
GO
ALTER TABLE [dbo].[egresos]  WITH CHECK ADD  CONSTRAINT [FK_egresos_impuesto] FOREIGN KEY([Impuesto])
REFERENCES [dbo].[impuesto] ([Clave])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[egresos] CHECK CONSTRAINT [FK_egresos_impuesto]
GO
ALTER TABLE [dbo].[egresos]  WITH CHECK ADD  CONSTRAINT [FK_egresos_persona] FOREIGN KEY([Proveedor])
REFERENCES [dbo].[persona] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[egresos] CHECK CONSTRAINT [FK_egresos_persona]
GO
ALTER TABLE [dbo].[egresos]  WITH CHECK ADD  CONSTRAINT [FK_egresos_subtipo_egreso_ingreso] FOREIGN KEY([SubTipoEgreso])
REFERENCES [dbo].[subtipo_egreso_ingreso] ([Clave])
GO
ALTER TABLE [dbo].[egresos] CHECK CONSTRAINT [FK_egresos_subtipo_egreso_ingreso]
GO
ALTER TABLE [dbo].[egresos]  WITH CHECK ADD  CONSTRAINT [FK_egresos_tipo_egreso_ingreso] FOREIGN KEY([TipoEgreso])
REFERENCES [dbo].[tipo_egreso_ingreso] ([Clave])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[egresos] CHECK CONSTRAINT [FK_egresos_tipo_egreso_ingreso]
GO
ALTER TABLE [dbo].[ingresos]  WITH CHECK ADD  CONSTRAINT [FK_ingresos_concepto1] FOREIGN KEY([Concepto])
REFERENCES [dbo].[concepto] ([Clave])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ingresos] CHECK CONSTRAINT [FK_ingresos_concepto1]
GO
ALTER TABLE [dbo].[ingresos]  WITH CHECK ADD  CONSTRAINT [FK_ingresos_impuesto] FOREIGN KEY([Impuesto])
REFERENCES [dbo].[impuesto] ([Clave])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ingresos] CHECK CONSTRAINT [FK_ingresos_impuesto]
GO
ALTER TABLE [dbo].[ingresos]  WITH CHECK ADD  CONSTRAINT [FK_ingresos_persona] FOREIGN KEY([Cliente])
REFERENCES [dbo].[persona] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ingresos] CHECK CONSTRAINT [FK_ingresos_persona]
GO
ALTER TABLE [dbo].[ingresos]  WITH CHECK ADD  CONSTRAINT [FK_ingresos_recibo] FOREIGN KEY([Serie])
REFERENCES [dbo].[recibo] ([Serie])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ingresos] CHECK CONSTRAINT [FK_ingresos_recibo]
GO
ALTER TABLE [dbo].[ingresos]  WITH CHECK ADD  CONSTRAINT [FK_ingresos_subtipo_egreso_ingreso] FOREIGN KEY([SubTipoIngreso])
REFERENCES [dbo].[subtipo_egreso_ingreso] ([Clave])
GO
ALTER TABLE [dbo].[ingresos] CHECK CONSTRAINT [FK_ingresos_subtipo_egreso_ingreso]
GO
ALTER TABLE [dbo].[ingresos]  WITH CHECK ADD  CONSTRAINT [FK_ingresos_tipo_egreso_ingreso] FOREIGN KEY([TipoIngreso])
REFERENCES [dbo].[tipo_egreso_ingreso] ([Clave])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ingresos] CHECK CONSTRAINT [FK_ingresos_tipo_egreso_ingreso]
GO
ALTER TABLE [dbo].[presupuesto]  WITH CHECK ADD  CONSTRAINT [FK_presupuesto_subtipo_egreso_ingreso] FOREIGN KEY([Subtipo])
REFERENCES [dbo].[subtipo_egreso_ingreso] ([Clave])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[presupuesto] CHECK CONSTRAINT [FK_presupuesto_subtipo_egreso_ingreso]
GO
ALTER TABLE [dbo].[presupuesto]  WITH CHECK ADD  CONSTRAINT [FK_presupuesto_tipo_egreso_ingreso] FOREIGN KEY([Tipo])
REFERENCES [dbo].[tipo_egreso_ingreso] ([Clave])
GO
ALTER TABLE [dbo].[presupuesto] CHECK CONSTRAINT [FK_presupuesto_tipo_egreso_ingreso]
GO
ALTER TABLE [dbo].[referencia]  WITH CHECK ADD  CONSTRAINT [FK_referencia_persona] FOREIGN KEY([Persona])
REFERENCES [dbo].[persona] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[referencia] CHECK CONSTRAINT [FK_referencia_persona]
GO
ALTER TABLE [dbo].[referencia]  WITH CHECK ADD  CONSTRAINT [FK_referencia_tipo_referencia] FOREIGN KEY([Tipo])
REFERENCES [dbo].[tipo_referencia] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[referencia] CHECK CONSTRAINT [FK_referencia_tipo_referencia]
GO
ALTER TABLE [dbo].[subtipo_egreso_ingreso]  WITH CHECK ADD  CONSTRAINT [FK_subtipo_egreso_ingreso_tipo_egreso_ingreso] FOREIGN KEY([Clave_Tipo])
REFERENCES [dbo].[tipo_egreso_ingreso] ([Clave])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[subtipo_egreso_ingreso] CHECK CONSTRAINT [FK_subtipo_egreso_ingreso_tipo_egreso_ingreso]
GO
