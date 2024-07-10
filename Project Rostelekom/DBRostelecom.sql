USE [master]
GO
/****** Object:  Database [DB_Rostelecom]    Script Date: 30.01.2023 18:01:02 ******/
CREATE DATABASE [DB_Rostelecom]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DB_Rostelecom', FILENAME = N'E:Coding\Project Rostelecom\DB_Rostelecom.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DB_Rostelecom_log', FILENAME = N'E:Coding\Project Rostelecom\DB_Rostelecom_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DB_Rostelecom] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DB_Rostelecom].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DB_Rostelecom] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DB_Rostelecom] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DB_Rostelecom] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DB_Rostelecom] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DB_Rostelecom] SET ARITHABORT OFF 
GO
ALTER DATABASE [DB_Rostelecom] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DB_Rostelecom] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DB_Rostelecom] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DB_Rostelecom] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DB_Rostelecom] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DB_Rostelecom] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DB_Rostelecom] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DB_Rostelecom] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DB_Rostelecom] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DB_Rostelecom] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DB_Rostelecom] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DB_Rostelecom] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DB_Rostelecom] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DB_Rostelecom] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DB_Rostelecom] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DB_Rostelecom] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DB_Rostelecom] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DB_Rostelecom] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DB_Rostelecom] SET  MULTI_USER 
GO
ALTER DATABASE [DB_Rostelecom] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DB_Rostelecom] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DB_Rostelecom] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DB_Rostelecom] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DB_Rostelecom] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DB_Rostelecom] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [DB_Rostelecom] SET QUERY_STORE = OFF
GO
USE [DB_Rostelecom]
GO
/****** Object:  Table [dbo].[AllUsers]    Script Date: 30.01.2023 18:01:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AllUsers](
	[UserId] [int] IDENTITY(100000,1) NOT NULL,
	[FirstName] [nvarchar](20) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Patronymic] [nvarchar](50) NULL,
	[Login] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Position] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_AllUsers] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 30.01.2023 18:01:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clients](
	[IdClient] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](25) NOT NULL,
	[Patronymic] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Phone] [bigint] NULL,
	[Email] [nvarchar](50) NULL,
	[Address] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED 
(
	[IdClient] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EquipmentList]    Script Date: 30.01.2023 18:01:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EquipmentList](
	[IdEquipment] [int] IDENTITY(301,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Description] [nvarchar](500) NULL,
	[Price] [money] NULL,
 CONSTRAINT [PK_EquipmentList] PRIMARY KEY CLUSTERED 
(
	[IdEquipment] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InstalledEquipment]    Script Date: 30.01.2023 18:01:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InstalledEquipment](
	[IdCE] [int] IDENTITY(1000,1) NOT NULL,
	[IdClient] [int] NOT NULL,
	[IdEquipment] [int] NOT NULL,
	[Date] [date] NOT NULL,
 CONSTRAINT [PK_InstalledEquipment] PRIMARY KEY CLUSTERED 
(
	[IdCE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InstalledServices]    Script Date: 30.01.2023 18:01:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InstalledServices](
	[IdES] [int] IDENTITY(201,1) NOT NULL,
	[IdClient] [int] NOT NULL,
	[IdService] [int] NOT NULL,
	[Date] [date] NOT NULL,
 CONSTRAINT [PK_InstalledServices] PRIMARY KEY CLUSTERED 
(
	[IdES] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServicesList]    Script Date: 30.01.2023 18:01:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServicesList](
	[IdService] [int] IDENTITY(201,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](500) NULL,
	[Price] [money] NULL,
 CONSTRAINT [PK_ServicesList] PRIMARY KEY CLUSTERED 
(
	[IdService] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[InstalledEquipment]  WITH CHECK ADD  CONSTRAINT [FK_InstalledEquipment_Clients] FOREIGN KEY([IdClient])
REFERENCES [dbo].[Clients] ([IdClient])
GO
ALTER TABLE [dbo].[InstalledEquipment] CHECK CONSTRAINT [FK_InstalledEquipment_Clients]
GO
ALTER TABLE [dbo].[InstalledEquipment]  WITH CHECK ADD  CONSTRAINT [FK_InstalledEquipment_EquipmentList] FOREIGN KEY([IdEquipment])
REFERENCES [dbo].[EquipmentList] ([IdEquipment])
GO
ALTER TABLE [dbo].[InstalledEquipment] CHECK CONSTRAINT [FK_InstalledEquipment_EquipmentList]
GO
ALTER TABLE [dbo].[InstalledServices]  WITH CHECK ADD  CONSTRAINT [FK_InstalledServices_Clients] FOREIGN KEY([IdClient])
REFERENCES [dbo].[Clients] ([IdClient])
GO
ALTER TABLE [dbo].[InstalledServices] CHECK CONSTRAINT [FK_InstalledServices_Clients]
GO
ALTER TABLE [dbo].[InstalledServices]  WITH CHECK ADD  CONSTRAINT [FK_InstalledServices_ServicesList] FOREIGN KEY([IdService])
REFERENCES [dbo].[ServicesList] ([IdService])
GO
ALTER TABLE [dbo].[InstalledServices] CHECK CONSTRAINT [FK_InstalledServices_ServicesList]
GO
USE [master]
GO
ALTER DATABASE [DB_Rostelecom] SET  READ_WRITE 
GO