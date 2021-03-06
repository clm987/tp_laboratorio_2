USE [master]
GO
/****** Object:  Database [Distribuidora]    Script Date: 30/11/2020 00:36:41 ******/
CREATE DATABASE [Distribuidora]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Distribuidora', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Distribuidora.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Distribuidora_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Distribuidora_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Distribuidora] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Distribuidora].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Distribuidora] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Distribuidora] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Distribuidora] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Distribuidora] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Distribuidora] SET ARITHABORT OFF 
GO
ALTER DATABASE [Distribuidora] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Distribuidora] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Distribuidora] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Distribuidora] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Distribuidora] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Distribuidora] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Distribuidora] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Distribuidora] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Distribuidora] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Distribuidora] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Distribuidora] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Distribuidora] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Distribuidora] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Distribuidora] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Distribuidora] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Distribuidora] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Distribuidora] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Distribuidora] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Distribuidora] SET  MULTI_USER 
GO
ALTER DATABASE [Distribuidora] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Distribuidora] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Distribuidora] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Distribuidora] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Distribuidora] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Distribuidora] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Distribuidora] SET QUERY_STORE = OFF
GO
USE [Distribuidora]
GO
/****** Object:  Table [dbo].[Articulo]    Script Date: 30/11/2020 00:36:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Articulo](
	[Id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Stock] [numeric](18, 0) NOT NULL,
	[Precio] [numeric](18, 2) NOT NULL,
	[Tipo] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tienda]    Script Date: 30/11/2020 00:36:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tienda](
	[Id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Direccion] [nvarchar](50) NOT NULL,
	[Telefono] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Venta]    Script Date: 30/11/2020 00:36:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Venta](
	[Id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[IdTienda] [numeric](18, 0) NOT NULL,
	[IdArticulo] [numeric](18, 0) NOT NULL,
	[Cantidad] [numeric](18, 0) NOT NULL,
	[Monto] [numeric](18, 2) NOT NULL,
	[EstadoVenta] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Articulo] ON 

INSERT [dbo].[Articulo] ([Id], [Nombre], [Stock], [Precio], [Tipo]) VALUES (CAST(1 AS Numeric(18, 0)), N'Heladera Tophouse', CAST(46 AS Numeric(18, 0)), CAST(15000.00 AS Numeric(18, 2)), N'Hogar')
INSERT [dbo].[Articulo] ([Id], [Nombre], [Stock], [Precio], [Tipo]) VALUES (CAST(2 AS Numeric(18, 0)), N'Cocina El Fuego', CAST(60 AS Numeric(18, 0)), CAST(10000.00 AS Numeric(18, 2)), N'Hogar')
INSERT [dbo].[Articulo] ([Id], [Nombre], [Stock], [Precio], [Tipo]) VALUES (CAST(3 AS Numeric(18, 0)), N'Horno SuperMarca', CAST(45 AS Numeric(18, 0)), CAST(18000.00 AS Numeric(18, 2)), N'Hogar')
INSERT [dbo].[Articulo] ([Id], [Nombre], [Stock], [Precio], [Tipo]) VALUES (CAST(4 AS Numeric(18, 0)), N'Horno Microondas', CAST(0 AS Numeric(18, 0)), CAST(8000.00 AS Numeric(18, 2)), N'Hogar')
INSERT [dbo].[Articulo] ([Id], [Nombre], [Stock], [Precio], [Tipo]) VALUES (CAST(5 AS Numeric(18, 0)), N'Heladera Superfrio', CAST(56 AS Numeric(18, 0)), CAST(35000.00 AS Numeric(18, 2)), N'Hogar')
INSERT [dbo].[Articulo] ([Id], [Nombre], [Stock], [Precio], [Tipo]) VALUES (CAST(6 AS Numeric(18, 0)), N'Televisor Latele', CAST(68 AS Numeric(18, 0)), CAST(38000.00 AS Numeric(18, 2)), N'Hogar')
INSERT [dbo].[Articulo] ([Id], [Nombre], [Stock], [Precio], [Tipo]) VALUES (CAST(7 AS Numeric(18, 0)), N'Monitor Dell', CAST(75 AS Numeric(18, 0)), CAST(32000.00 AS Numeric(18, 2)), N'Computacion')
INSERT [dbo].[Articulo] ([Id], [Nombre], [Stock], [Precio], [Tipo]) VALUES (CAST(8 AS Numeric(18, 0)), N'Monitor Hp', CAST(50 AS Numeric(18, 0)), CAST(28000.00 AS Numeric(18, 2)), N'Computacion')
INSERT [dbo].[Articulo] ([Id], [Nombre], [Stock], [Precio], [Tipo]) VALUES (CAST(9 AS Numeric(18, 0)), N'Teclado Hp', CAST(136 AS Numeric(18, 0)), CAST(4000.00 AS Numeric(18, 2)), N'Computacion')
INSERT [dbo].[Articulo] ([Id], [Nombre], [Stock], [Precio], [Tipo]) VALUES (CAST(10 AS Numeric(18, 0)), N'Teclado RedDragon', CAST(100 AS Numeric(18, 0)), CAST(6000.00 AS Numeric(18, 2)), N'Computacion')
INSERT [dbo].[Articulo] ([Id], [Nombre], [Stock], [Precio], [Tipo]) VALUES (CAST(11 AS Numeric(18, 0)), N'Mouse Logitech', CAST(0 AS Numeric(18, 0)), CAST(600.00 AS Numeric(18, 2)), N'Computacion')
INSERT [dbo].[Articulo] ([Id], [Nombre], [Stock], [Precio], [Tipo]) VALUES (CAST(12 AS Numeric(18, 0)), N'Mouse SuperRaton', CAST(150 AS Numeric(18, 0)), CAST(800.00 AS Numeric(18, 2)), N'Computacion')
INSERT [dbo].[Articulo] ([Id], [Nombre], [Stock], [Precio], [Tipo]) VALUES (CAST(13 AS Numeric(18, 0)), N'Auriculares Sony', CAST(200 AS Numeric(18, 0)), CAST(2500.00 AS Numeric(18, 2)), N'Computacion')
INSERT [dbo].[Articulo] ([Id], [Nombre], [Stock], [Precio], [Tipo]) VALUES (CAST(14 AS Numeric(18, 0)), N'Mouse Genius', CAST(400 AS Numeric(18, 0)), CAST(780.00 AS Numeric(18, 2)), N'Computacion')
INSERT [dbo].[Articulo] ([Id], [Nombre], [Stock], [Precio], [Tipo]) VALUES (CAST(15 AS Numeric(18, 0)), N'Mouse inalambrico', CAST(100 AS Numeric(18, 0)), CAST(800.00 AS Numeric(18, 2)), N'Computacion')
SET IDENTITY_INSERT [dbo].[Articulo] OFF
GO
SET IDENTITY_INSERT [dbo].[Tienda] ON 

INSERT [dbo].[Tienda] ([Id], [Nombre], [Direccion], [Telefono]) VALUES (CAST(1 AS Numeric(18, 0)), N'Garbarino Cabildo', N'Av. Cabildo 2323', N'1153393658')
INSERT [dbo].[Tienda] ([Id], [Nombre], [Direccion], [Telefono]) VALUES (CAST(2 AS Numeric(18, 0)), N'Garbarino Centro', N'Av. 9 de Julio 1234', N'1153393675')
INSERT [dbo].[Tienda] ([Id], [Nombre], [Direccion], [Telefono]) VALUES (CAST(3 AS Numeric(18, 0)), N'Tienda Mia', N'Av. 4, 2222', N'1153393660')
INSERT [dbo].[Tienda] ([Id], [Nombre], [Direccion], [Telefono]) VALUES (CAST(4 AS Numeric(18, 0)), N'La tienda Dot', N'Los frailes, 1952', N'1153393784')
INSERT [dbo].[Tienda] ([Id], [Nombre], [Direccion], [Telefono]) VALUES (CAST(5 AS Numeric(18, 0)), N'TecnoTienda', N'Av. El obelisco, 195', N'1123593784')
INSERT [dbo].[Tienda] ([Id], [Nombre], [Direccion], [Telefono]) VALUES (CAST(6 AS Numeric(18, 0)), N'Tienda Hogar', N'Av. Libertador, 1235', N'1123592356')
SET IDENTITY_INSERT [dbo].[Tienda] OFF
GO
SET IDENTITY_INSERT [dbo].[Venta] ON 

INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(1 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(36000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(2 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(36000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(3 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(30000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(4 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)), CAST(6 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(0.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(5 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(35000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(100 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(24000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(101 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(6 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(38000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(102 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(70000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(103 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(30000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(104 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(16000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(105 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(24000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(106 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(16000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(107 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(9 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)), CAST(20000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(108 AS Numeric(18, 0)), CAST(6 AS Numeric(18, 0)), CAST(9 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(8000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(109 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)), CAST(11 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(1800.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(548 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(6 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(38000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(549 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(70000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(113 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(24000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(114 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(6 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(38000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(115 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(70000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(116 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(30000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(117 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(16000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(118 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(24000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(119 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(16000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(120 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(9 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)), CAST(20000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(121 AS Numeric(18, 0)), CAST(6 AS Numeric(18, 0)), CAST(9 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(8000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(122 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)), CAST(11 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(1800.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(123 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(11 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(1200.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(124 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(11 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(1200.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(125 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(11 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(1200.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(126 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(24000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(127 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(6 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(38000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(128 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(70000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(129 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(30000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(130 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(16000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(131 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(24000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(132 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(16000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(133 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(9 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)), CAST(20000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(134 AS Numeric(18, 0)), CAST(6 AS Numeric(18, 0)), CAST(9 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(8000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(135 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)), CAST(11 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(1800.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(176 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(11 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(1200.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(177 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(11 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(1200.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(550 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(30000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(180 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(6 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(38000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(181 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(70000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(182 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(30000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(554 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(9 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)), CAST(20000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(555 AS Numeric(18, 0)), CAST(6 AS Numeric(18, 0)), CAST(9 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(8000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(188 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)), CAST(11 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(1800.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(206 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(6 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(38000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(208 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(30000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(294 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(30000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(295 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(2000 AS Numeric(18, 0)), CAST(30000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(300 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(6 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(38000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(313 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(6 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(38000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(352 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(6 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(38000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(6 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(30000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(7 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(20000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(8 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(36000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(9 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(24000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(10 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(6 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(38000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(11 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(70000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(12 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(30000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(13 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(16000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(14 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(24000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(15 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(16000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(16 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(9 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)), CAST(20000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(17 AS Numeric(18, 0)), CAST(6 AS Numeric(18, 0)), CAST(9 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(8000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(18 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)), CAST(9 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(12000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(136 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(11 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(1200.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(137 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(11 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(1200.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(138 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(11 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(1200.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(139 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(24000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(140 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(6 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(38000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(141 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(70000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(142 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(30000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(146 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(9 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)), CAST(20000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(147 AS Numeric(18, 0)), CAST(6 AS Numeric(18, 0)), CAST(9 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(8000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(149 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(20000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(150 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(11 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(1200.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(154 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(6 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(38000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(155 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(70000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(156 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(30000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(165 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(11 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(1200.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(167 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(6 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(38000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(168 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(70000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(169 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(30000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(175 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)), CAST(11 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(1800.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(219 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(6 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(38000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(232 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(6 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(38000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(284 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(6 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(38000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(293 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(30000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(326 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(6 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(38000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(19 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(30000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(20 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(20000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(21 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(36000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(22 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(24000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(23 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(6 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(38000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(24 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(70000.00 AS Numeric(18, 2)), N'Conforme')
GO
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(25 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(30000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(26 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(16000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(27 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(24000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(28 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(16000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(29 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(9 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)), CAST(20000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(30 AS Numeric(18, 0)), CAST(6 AS Numeric(18, 0)), CAST(9 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(8000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(31 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)), CAST(11 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(1800.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(32 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(30000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(33 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(20000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(34 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(36000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(35 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(24000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(36 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(6 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(38000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(37 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(70000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(38 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(30000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(39 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(16000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(40 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(24000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(41 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(16000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(42 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(9 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)), CAST(20000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(43 AS Numeric(18, 0)), CAST(6 AS Numeric(18, 0)), CAST(9 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(8000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(44 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)), CAST(11 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(1800.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(245 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(6 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(38000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(258 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(6 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(38000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(271 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(6 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(38000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(339 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(6 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(38000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(378 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(6 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(38000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(391 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(6 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(38000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(45 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(11 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(1200.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(46 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(11 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(1200.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(47 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(11 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(1200.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(48 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(24000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(49 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(6 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(38000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(50 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(70000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(51 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(30000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(52 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(16000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(53 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(24000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(54 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(16000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(55 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(9 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)), CAST(20000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(56 AS Numeric(18, 0)), CAST(6 AS Numeric(18, 0)), CAST(9 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(8000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(57 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)), CAST(11 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(1800.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(58 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(11 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(1200.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(59 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(11 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(1200.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(60 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(11 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(1200.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(61 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(24000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(62 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(6 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(38000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(63 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(70000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(64 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(30000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(65 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(16000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(66 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(24000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(67 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(16000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(68 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(9 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)), CAST(20000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(69 AS Numeric(18, 0)), CAST(6 AS Numeric(18, 0)), CAST(9 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(8000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(70 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)), CAST(11 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(1800.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(71 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(11 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(1200.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(72 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(11 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(1200.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(73 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(11 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(1200.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(74 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(24000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(75 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(6 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(38000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(76 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(70000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(77 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(30000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(78 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(16000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(79 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(24000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(80 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(16000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(81 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(9 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)), CAST(20000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(82 AS Numeric(18, 0)), CAST(6 AS Numeric(18, 0)), CAST(9 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(8000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(83 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)), CAST(11 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(1800.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(84 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(11 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(1200.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(85 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(11 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(1200.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(86 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(11 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(1200.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(87 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(24000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(88 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(6 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(38000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(89 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(70000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(90 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(30000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(91 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(16000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(92 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(24000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(93 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(16000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(94 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(9 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)), CAST(20000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(95 AS Numeric(18, 0)), CAST(6 AS Numeric(18, 0)), CAST(9 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(8000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(96 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)), CAST(11 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(1800.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(193 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(6 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(38000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(535 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(6 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(38000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(195 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(30000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(536 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(70000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(537 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(30000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(541 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(9 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)), CAST(20000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(542 AS Numeric(18, 0)), CAST(6 AS Numeric(18, 0)), CAST(9 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(8000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(404 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(6 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(38000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(417 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(6 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(38000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(443 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(6 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(38000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(365 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(6 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(38000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(430 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(6 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(38000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(456 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(6 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(38000.00 AS Numeric(18, 2)), N'Conforme')
INSERT [dbo].[Venta] ([Id], [IdTienda], [IdArticulo], [Cantidad], [Monto], [EstadoVenta]) VALUES (CAST(504 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(30000.00 AS Numeric(18, 2)), N'Conforme')
SET IDENTITY_INSERT [dbo].[Venta] OFF
GO
USE [master]
GO
ALTER DATABASE [Distribuidora] SET  READ_WRITE 
GO
