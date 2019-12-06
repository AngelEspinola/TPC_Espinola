USE [TPC_ESPINOLA]
GO
/****** Object:  Table [dbo].[Ventas]    Script Date: 12/06/2019 20:34:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ventas](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[ClienteID] [bigint] NOT NULL,
	[Fecha] [datetime] NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Ventas] ON
INSERT [dbo].[Ventas] ([ID], [ClienteID], [Fecha]) VALUES (1, 1, CAST(0x0000AB1A01817C5F AS DateTime))
INSERT [dbo].[Ventas] ([ID], [ClienteID], [Fecha]) VALUES (2, 1, CAST(0x0000AB1A018B1485 AS DateTime))
INSERT [dbo].[Ventas] ([ID], [ClienteID], [Fecha]) VALUES (3, 4, CAST(0x0000AB1B014608CD AS DateTime))
SET IDENTITY_INSERT [dbo].[Ventas] OFF
/****** Object:  Table [dbo].[Proveedores]    Script Date: 12/06/2019 20:34:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Proveedores](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CUIT] [bigint] NOT NULL,
	[RazonSocial] [varchar](100) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Direccion] [varchar](50) NOT NULL,
	[Ciudad] [varchar](50) NOT NULL,
	[CodigoPostal] [varchar](8) NOT NULL,
	[FechaRegistro] [datetime] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Proveedores] ON
INSERT [dbo].[Proveedores] ([Id], [CUIT], [RazonSocial], [Email], [Direccion], [Ciudad], [CodigoPostal], [FechaRegistro]) VALUES (1, 30707053956, N'Request SA', N'soporte@request.com.ar', N'Machain 4289', N'CABA', N'1430', CAST(0x0000AB1200000000 AS DateTime))
INSERT [dbo].[Proveedores] ([Id], [CUIT], [RazonSocial], [Email], [Direccion], [Ciudad], [CodigoPostal], [FechaRegistro]) VALUES (2, 30546689979, N'YPF S.A.', N'soporte@ypf.com.ar', N'Bv. Macacha Güemes 515', N'CABA', N'1105', CAST(0x0000AB1600000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[Proveedores] OFF
/****** Object:  Table [dbo].[ProductosXProveedores]    Script Date: 12/06/2019 20:34:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductosXProveedores](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[ProductoID] [bigint] NOT NULL,
	[ProveedorID] [bigint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ProductosXProveedores] ON
INSERT [dbo].[ProductosXProveedores] ([ID], [ProductoID], [ProveedorID]) VALUES (1, 1, 14)
INSERT [dbo].[ProductosXProveedores] ([ID], [ProductoID], [ProveedorID]) VALUES (2, 2, 14)
INSERT [dbo].[ProductosXProveedores] ([ID], [ProductoID], [ProveedorID]) VALUES (3, 3, 14)
INSERT [dbo].[ProductosXProveedores] ([ID], [ProductoID], [ProveedorID]) VALUES (13, 2, 4)
INSERT [dbo].[ProductosXProveedores] ([ID], [ProductoID], [ProveedorID]) VALUES (14, 3, 4)
INSERT [dbo].[ProductosXProveedores] ([ID], [ProductoID], [ProveedorID]) VALUES (24, 1, 1)
INSERT [dbo].[ProductosXProveedores] ([ID], [ProductoID], [ProveedorID]) VALUES (25, 2, 1)
INSERT [dbo].[ProductosXProveedores] ([ID], [ProductoID], [ProveedorID]) VALUES (26, 3, 1)
INSERT [dbo].[ProductosXProveedores] ([ID], [ProductoID], [ProveedorID]) VALUES (27, 6, 1)
INSERT [dbo].[ProductosXProveedores] ([ID], [ProductoID], [ProveedorID]) VALUES (28, 2, 2)
INSERT [dbo].[ProductosXProveedores] ([ID], [ProductoID], [ProveedorID]) VALUES (29, 3, 2)
INSERT [dbo].[ProductosXProveedores] ([ID], [ProductoID], [ProveedorID]) VALUES (30, 6, 2)
SET IDENTITY_INSERT [dbo].[ProductosXProveedores] OFF
/****** Object:  Table [dbo].[Productos]    Script Date: 12/06/2019 20:34:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Productos](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Titulo] [varchar](100) NOT NULL,
	[Descripcion] [varchar](250) NOT NULL,
	[URLImagen] [varchar](1000) NOT NULL,
	[Ganancia] [decimal](6, 2) NOT NULL,
	[StockMinimo] [bigint] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Productos] ON
INSERT [dbo].[Productos] ([ID], [Titulo], [Descripcion], [URLImagen], [Ganancia], [StockMinimo]) VALUES (1, N'Violoncello', N'Instrumento de cuerdas de gran tamaño y sonido caracteristico, con caracter y sentimiento.', N'https://www.el-atril.com/orquesta/Instrumentos/imagenes/violonchelo.gif', CAST(100.00 AS Decimal(6, 2)), 20)
INSERT [dbo].[Productos] ([ID], [Titulo], [Descripcion], [URLImagen], [Ganancia], [StockMinimo]) VALUES (2, N'Oboe', N'Instrumento de viento de tamaño medio de buen timbre y mucha vida util.', N'https://images-na.ssl-images-amazon.com/images/I/3110YdN62lL.jpg', CAST(67.00 AS Decimal(6, 2)), NULL)
INSERT [dbo].[Productos] ([ID], [Titulo], [Descripcion], [URLImagen], [Ganancia], [StockMinimo]) VALUES (3, N'Flauta Traversa', N'Instrumento de viento, delgado y de sonido dulce.', N'https://importacioneslunaperu.com/wp-content/uploads/2015/07/flauta-traversa-yamaha.jpg', CAST(90.55 AS Decimal(6, 2)), NULL)
INSERT [dbo].[Productos] ([ID], [Titulo], [Descripcion], [URLImagen], [Ganancia], [StockMinimo]) VALUES (6, N'Viola', N'Instrumento de cuerdas mas grande que el violin y mas pequeño que el violoncello.', N'https://tienda.palomavaleva.com/wp-content/uploads/2019/05/01-Alto-maestro-Stradella.jpg', CAST(90.00 AS Decimal(6, 2)), 5)
SET IDENTITY_INSERT [dbo].[Productos] OFF
/****** Object:  Table [dbo].[DetalleVentas]    Script Date: 12/06/2019 20:34:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleVentas](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[VentaID] [bigint] NOT NULL,
	[ProductoID] [bigint] NOT NULL,
	[Cantidad] [bigint] NOT NULL,
	[Precio] [money] NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[DetalleVentas] ON
INSERT [dbo].[DetalleVentas] ([ID], [VentaID], [ProductoID], [Cantidad], [Precio]) VALUES (1, 1, 2, 2, 8350.0000)
INSERT [dbo].[DetalleVentas] ([ID], [VentaID], [ProductoID], [Cantidad], [Precio]) VALUES (2, 1, 1, 3, 2250.0000)
INSERT [dbo].[DetalleVentas] ([ID], [VentaID], [ProductoID], [Cantidad], [Precio]) VALUES (3, 2, 2, 1, 8350.0000)
INSERT [dbo].[DetalleVentas] ([ID], [VentaID], [ProductoID], [Cantidad], [Precio]) VALUES (4, 3, 1, 2, 2250.0000)
SET IDENTITY_INSERT [dbo].[DetalleVentas] OFF
/****** Object:  Table [dbo].[DetalleCompras]    Script Date: 12/06/2019 20:34:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleCompras](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[CompraID] [bigint] NOT NULL,
	[ProductoID] [bigint] NOT NULL,
	[Cantidad] [bigint] NOT NULL,
	[Precio] [money] NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[DetalleCompras] ON
INSERT [dbo].[DetalleCompras] ([ID], [CompraID], [ProductoID], [Cantidad], [Precio]) VALUES (1, 1, 1, 10, 1500.0000)
INSERT [dbo].[DetalleCompras] ([ID], [CompraID], [ProductoID], [Cantidad], [Precio]) VALUES (2, 1, 2, 1, 3000.0000)
INSERT [dbo].[DetalleCompras] ([ID], [CompraID], [ProductoID], [Cantidad], [Precio]) VALUES (3, 2, 2, 3, 5000.0000)
INSERT [dbo].[DetalleCompras] ([ID], [CompraID], [ProductoID], [Cantidad], [Precio]) VALUES (4, 2, 6, 45, 5500.0000)
INSERT [dbo].[DetalleCompras] ([ID], [CompraID], [ProductoID], [Cantidad], [Precio]) VALUES (5, 2, 3, 24, 3700.0000)
INSERT [dbo].[DetalleCompras] ([ID], [CompraID], [ProductoID], [Cantidad], [Precio]) VALUES (6, 3, 1, 3, 15000.0000)
SET IDENTITY_INSERT [dbo].[DetalleCompras] OFF
/****** Object:  Table [dbo].[Compras]    Script Date: 12/06/2019 20:34:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Compras](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[ProveedorID] [bigint] NOT NULL,
	[Fecha] [datetime] NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Compras] ON
INSERT [dbo].[Compras] ([ID], [ProveedorID], [Fecha]) VALUES (1, 1, CAST(0x0000AB18015BD304 AS DateTime))
INSERT [dbo].[Compras] ([ID], [ProveedorID], [Fecha]) VALUES (2, 1, CAST(0x0000AB1B001D0073 AS DateTime))
INSERT [dbo].[Compras] ([ID], [ProveedorID], [Fecha]) VALUES (3, 1, CAST(0x0000AB1B0146E28E AS DateTime))
SET IDENTITY_INSERT [dbo].[Compras] OFF
/****** Object:  Table [dbo].[Clientes]    Script Date: 12/06/2019 20:34:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Clientes](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[DNI] [bigint] NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Direccion] [varchar](150) NOT NULL,
	[Ciudad] [varchar](100) NOT NULL,
	[CodigoPostal] [varchar](8) NOT NULL,
	[FechaRegistro] [datetime] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Clientes] ON
INSERT [dbo].[Clientes] ([Id], [DNI], [Nombre], [Apellido], [Email], [Direccion], [Ciudad], [CodigoPostal], [FechaRegistro]) VALUES (1, 39515418, N'Miguel Angel', N'Espinola', N'm.espinola@outlook.com', N'Tronador 4007', N'CABA', N'1430', CAST(0x0000AB1200000000 AS DateTime))
INSERT [dbo].[Clientes] ([Id], [DNI], [Nombre], [Apellido], [Email], [Direccion], [Ciudad], [CodigoPostal], [FechaRegistro]) VALUES (4, 38125387, N'Sergio', N'Villanueva', N'svillanueva@outlook.com', N'calleSergio 132', N'Tigre', N'1352', CAST(0x0000AB1B00000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[Clientes] OFF
/****** Object:  Check [CK__Productos__Produ__2F10007B]    Script Date: 12/06/2019 20:34:48 ******/
ALTER TABLE [dbo].[ProductosXProveedores]  WITH CHECK ADD CHECK  ((len([ProductoID])>(0)))
GO
/****** Object:  Check [CK__Productos__Prove__300424B4]    Script Date: 12/06/2019 20:34:48 ******/
ALTER TABLE [dbo].[ProductosXProveedores]  WITH CHECK ADD CHECK  ((len([ProveedorID])>(0)))
GO
