USE [master]
GO
/****** Object:  Database [dbIntelutions]    Script Date: 19/11/2020 18:11:36 ******/
CREATE DATABASE [dbIntelutions]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'dbIntelutions', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\dbIntelutions.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'dbIntelutions_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\dbIntelutions_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [dbIntelutions] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dbIntelutions].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [dbIntelutions] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [dbIntelutions] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [dbIntelutions] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [dbIntelutions] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [dbIntelutions] SET ARITHABORT OFF 
GO
ALTER DATABASE [dbIntelutions] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [dbIntelutions] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [dbIntelutions] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [dbIntelutions] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [dbIntelutions] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [dbIntelutions] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [dbIntelutions] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [dbIntelutions] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [dbIntelutions] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [dbIntelutions] SET  DISABLE_BROKER 
GO
ALTER DATABASE [dbIntelutions] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [dbIntelutions] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [dbIntelutions] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [dbIntelutions] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [dbIntelutions] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [dbIntelutions] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [dbIntelutions] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [dbIntelutions] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [dbIntelutions] SET  MULTI_USER 
GO
ALTER DATABASE [dbIntelutions] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [dbIntelutions] SET DB_CHAINING OFF 
GO
ALTER DATABASE [dbIntelutions] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [dbIntelutions] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [dbIntelutions] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [dbIntelutions] SET QUERY_STORE = OFF
GO
USE [dbIntelutions]
GO
/****** Object:  Table [dbo].[Permiso]    Script Date: 19/11/2020 18:11:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permiso](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmpleadoNombre] [nvarchar](255) NOT NULL,
	[EmpleadoApellidos] [nvarchar](255) NOT NULL,
	[TipoPermisoId] [int] NOT NULL,
	[FechaPermiso] [date] NOT NULL,
 CONSTRAINT [PK_Permiso] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoPermiso]    Script Date: 19/11/2020 18:11:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoPermiso](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_TipoPermiso] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Permiso] ON 

INSERT [dbo].[Permiso] ([Id], [EmpleadoNombre], [EmpleadoApellidos], [TipoPermisoId], [FechaPermiso]) VALUES (2, N'Andres', N'Miretti', 4, CAST(N'2020-11-25' AS Date))
SET IDENTITY_INSERT [dbo].[Permiso] OFF
SET IDENTITY_INSERT [dbo].[TipoPermiso] ON 

INSERT [dbo].[TipoPermiso] ([Id], [Descripcion]) VALUES (1, N'Enfermedad')
INSERT [dbo].[TipoPermiso] ([Id], [Descripcion]) VALUES (2, N'Nacimiento de hijo')
INSERT [dbo].[TipoPermiso] ([Id], [Descripcion]) VALUES (3, N'Matrimonio')
INSERT [dbo].[TipoPermiso] ([Id], [Descripcion]) VALUES (4, N'Mudanza')
INSERT [dbo].[TipoPermiso] ([Id], [Descripcion]) VALUES (5, N'Día de exámen')
INSERT [dbo].[TipoPermiso] ([Id], [Descripcion]) VALUES (6, N'Trámites personales')
INSERT [dbo].[TipoPermiso] ([Id], [Descripcion]) VALUES (7, N'Sin justificación (Sin goce de sueldo)')
SET IDENTITY_INSERT [dbo].[TipoPermiso] OFF
ALTER TABLE [dbo].[Permiso]  WITH CHECK ADD  CONSTRAINT [FK_Permiso_TipoPermiso] FOREIGN KEY([TipoPermisoId])
REFERENCES [dbo].[TipoPermiso] ([Id])
GO
ALTER TABLE [dbo].[Permiso] CHECK CONSTRAINT [FK_Permiso_TipoPermiso]
GO
USE [master]
GO
ALTER DATABASE [dbIntelutions] SET  READ_WRITE 
GO
