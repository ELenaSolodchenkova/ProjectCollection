USE [master]
GO
/****** Object:  Database [Esoft]    Script Date: 08.04.2019 15:49:40 ******/
CREATE DATABASE [Esoft]
 CONTAINMENT = NONE
GO
ALTER DATABASE [Esoft] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Esoft].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Esoft] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Esoft] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Esoft] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Esoft] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Esoft] SET ARITHABORT OFF 
GO
ALTER DATABASE [Esoft] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Esoft] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Esoft] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Esoft] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Esoft] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Esoft] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Esoft] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Esoft] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Esoft] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Esoft] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Esoft] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Esoft] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Esoft] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Esoft] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Esoft] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Esoft] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Esoft] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Esoft] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Esoft] SET  MULTI_USER 
GO
ALTER DATABASE [Esoft] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Esoft] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Esoft] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Esoft] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Esoft] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Esoft]
GO
/****** Object:  Table [dbo].[Agent]    Script Date: 08.04.2019 15:49:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Agent](
	[IdAgent] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[MiddleName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[DealShare] [int] NULL,
 CONSTRAINT [PK_Agent] PRIMARY KEY CLUSTERED 
(
	[IdAgent] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Apartment]    Script Date: 08.04.2019 15:49:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Apartment](
	[IdApartment] [int] NOT NULL,
	[TotalArea] [float] NULL,
	[Rooms] [int] NULL,
	[Floor] [int] NULL,
 CONSTRAINT [PK_Apartment] PRIMARY KEY CLUSTERED 
(
	[IdApartment] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ApartmentFilter]    Script Date: 08.04.2019 15:49:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApartmentFilter](
	[IdApartmentFilter] [int] NOT NULL,
	[MinArea] [float] NULL,
	[MaxArea] [float] NULL,
	[MinRooms] [int] NULL,
	[MaxRooms] [int] NULL,
	[MinFloor] [int] NULL,
	[MaxFloor] [int] NULL,
 CONSTRAINT [PK_ApartmantFilter] PRIMARY KEY CLUSTERED 
(
	[IdApartmentFilter] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Client]    Script Date: 08.04.2019 15:49:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[IdClient] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[MiddleName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[IdClient] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Deal]    Script Date: 08.04.2019 15:49:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Deal](
	[IdDeal] [int] IDENTITY(1,1) NOT NULL,
	[IdDemand] [int] NULL,
	[IdSupply] [int] NULL,
 CONSTRAINT [PK_Deal] PRIMARY KEY CLUSTERED 
(
	[IdDeal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Demand]    Script Date: 08.04.2019 15:49:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Demand](
	[IdDemand] [int] IDENTITY(1,1) NOT NULL,
	[AddressCity] [nvarchar](max) NULL,
	[AddressStreet] [nvarchar](max) NULL,
	[AddressHouse] [nvarchar](max) NULL,
	[AddressNumber] [nvarchar](max) NULL,
	[MinPrice] [bigint] NULL,
	[MaxPrice] [bigint] NULL,
	[IdAgent] [int] NULL,
	[IdClient] [int] NULL,
 CONSTRAINT [PK_Demand] PRIMARY KEY CLUSTERED 
(
	[IdDemand] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[House]    Script Date: 08.04.2019 15:49:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[House](
	[IdHouse] [int] NOT NULL,
	[TotalFloors] [int] NULL,
	[TotalArea] [float] NULL,
	[TotalRooms] [int] NULL,
 CONSTRAINT [PK_House] PRIMARY KEY CLUSTERED 
(
	[IdHouse] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HouseFilter]    Script Date: 08.04.2019 15:49:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HouseFilter](
	[IdHouseFilter] [int] NOT NULL,
	[MinFloors] [int] NULL,
	[MaxFloors] [int] NULL,
	[MinArea] [float] NULL,
	[MaxArea] [float] NULL,
	[MinRooms] [int] NULL,
	[MaxRooms] [int] NULL,
 CONSTRAINT [PK_HouseFilter] PRIMARY KEY CLUSTERED 
(
	[IdHouseFilter] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Land]    Script Date: 08.04.2019 15:49:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Land](
	[IdLand] [int] NOT NULL,
	[TotalArea] [float] NULL,
 CONSTRAINT [PK_Land] PRIMARY KEY CLUSTERED 
(
	[IdLand] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LandFilter]    Script Date: 08.04.2019 15:49:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LandFilter](
	[IdLaneFilter] [int] NOT NULL,
	[MinArea] [float] NULL,
	[MaxArea] [float] NULL,
 CONSTRAINT [PK_LandFilter] PRIMARY KEY CLUSTERED 
(
	[IdLaneFilter] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RealEstate]    Script Date: 08.04.2019 15:49:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RealEstate](
	[IdRealEstate] [int] NOT NULL,
	[AddressCity] [nvarchar](max) NULL,
	[AddressStreet] [nvarchar](max) NULL,
	[AddressHouse] [nvarchar](max) NULL,
	[AddressNumder] [nvarchar](max) NULL,
	[CoordinateLatitude] [float] NULL,
	[CoordinateLongitude] [float] NULL,
	[Type] [int] NULL,
 CONSTRAINT [PK_RealEstate] PRIMARY KEY CLUSTERED 
(
	[IdRealEstate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RealEstateFilter]    Script Date: 08.04.2019 15:49:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RealEstateFilter](
	[IdRealEstateFilter] [int] NOT NULL,
	[Type] [int] NULL,
 CONSTRAINT [PK_RealEstateFilter] PRIMARY KEY CLUSTERED 
(
	[IdRealEstateFilter] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Supply]    Script Date: 08.04.2019 15:49:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supply](
	[IdSupply] [int] IDENTITY(1,1) NOT NULL,
	[Price] [bigint] NULL,
	[IdAgent] [int] NULL,
	[IdClient] [int] NULL,
	[IdRealEstate] [int] NULL,
 CONSTRAINT [PK_Supply] PRIMARY KEY CLUSTERED 
(
	[IdSupply] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TypeEstate]    Script Date: 08.04.2019 15:49:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeEstate](
	[IdType] [int] NOT NULL,
	[Type] [nvarchar](50) NULL,
 CONSTRAINT [PK_TypeEstate] PRIMARY KEY CLUSTERED 
(
	[IdType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Agent] ON 

INSERT [dbo].[Agent] ([IdAgent], [FirstName], [MiddleName], [LastName], [DealShare]) VALUES (1, N'Фахрутдинов', N'Роман', N'Рубинович', 20)
INSERT [dbo].[Agent] ([IdAgent], [FirstName], [MiddleName], [LastName], [DealShare]) VALUES (4, N'Устинов', N'Максим', N'Алексеевич', 45)
INSERT [dbo].[Agent] ([IdAgent], [FirstName], [MiddleName], [LastName], [DealShare]) VALUES (7, N'Сысоева', N'Людмила', N'Валентиновна', 40)
INSERT [dbo].[Agent] ([IdAgent], [FirstName], [MiddleName], [LastName], [DealShare]) VALUES (9, N'Додонов', N'Илья', N'Геннадьевич', 45)
INSERT [dbo].[Agent] ([IdAgent], [FirstName], [MiddleName], [LastName], [DealShare]) VALUES (11, N'Мухтаруллин', N'Руслан', N'Расыхович', 45)
INSERT [dbo].[Agent] ([IdAgent], [FirstName], [MiddleName], [LastName], [DealShare]) VALUES (13, N'Мосеева', N'Любовь', N'Александровна', 45)
INSERT [dbo].[Agent] ([IdAgent], [FirstName], [MiddleName], [LastName], [DealShare]) VALUES (15, N'Киселев', N'Алексей', N'Геннадьевич', 45)
INSERT [dbo].[Agent] ([IdAgent], [FirstName], [MiddleName], [LastName], [DealShare]) VALUES (19, N'Клюйков', N'Евгений', N'Николаевич', 50)
INSERT [dbo].[Agent] ([IdAgent], [FirstName], [MiddleName], [LastName], [DealShare]) VALUES (24, N'Жданова', N'Галина', N'Николаевна', 45)
INSERT [dbo].[Agent] ([IdAgent], [FirstName], [MiddleName], [LastName], [DealShare]) VALUES (34, N'Басырова', N'Елена', N'Азатовна', 45)
INSERT [dbo].[Agent] ([IdAgent], [FirstName], [MiddleName], [LastName], [DealShare]) VALUES (37, N'Швецов', N'Виталий', N'Олегович', 45)
INSERT [dbo].[Agent] ([IdAgent], [FirstName], [MiddleName], [LastName], [DealShare]) VALUES (38, N'Глушаков', N'Александр', N'Николаевич', 30)
SET IDENTITY_INSERT [dbo].[Agent] OFF
INSERT [dbo].[Apartment] ([IdApartment], [TotalArea], [Rooms], [Floor]) VALUES (1, 41.7, 1, 3)
INSERT [dbo].[Apartment] ([IdApartment], [TotalArea], [Rooms], [Floor]) VALUES (2, 105, 3, 5)
INSERT [dbo].[Apartment] ([IdApartment], [TotalArea], [Rooms], [Floor]) VALUES (3, 62, 3, 2)
INSERT [dbo].[Apartment] ([IdApartment], [TotalArea], [Rooms], [Floor]) VALUES (4, 50, 2, 7)
INSERT [dbo].[Apartment] ([IdApartment], [TotalArea], [Rooms], [Floor]) VALUES (5, 51.7, 2, 2)
INSERT [dbo].[Apartment] ([IdApartment], [TotalArea], [Rooms], [Floor]) VALUES (6, 44, 2, 1)
INSERT [dbo].[Apartment] ([IdApartment], [TotalArea], [Rooms], [Floor]) VALUES (7, 43.1, 1, 5)
INSERT [dbo].[Apartment] ([IdApartment], [TotalArea], [Rooms], [Floor]) VALUES (8, 92, 3, 1)
INSERT [dbo].[ApartmentFilter] ([IdApartmentFilter], [MinArea], [MaxArea], [MinRooms], [MaxRooms], [MinFloor], [MaxFloor]) VALUES (1, NULL, NULL, NULL, 5, NULL, NULL)
INSERT [dbo].[ApartmentFilter] ([IdApartmentFilter], [MinArea], [MaxArea], [MinRooms], [MaxRooms], [MinFloor], [MaxFloor]) VALUES (6, 20, NULL, 2, 3, 4, 10)
INSERT [dbo].[ApartmentFilter] ([IdApartmentFilter], [MinArea], [MaxArea], [MinRooms], [MaxRooms], [MinFloor], [MaxFloor]) VALUES (7, NULL, NULL, 1, 2, 5, 9)
INSERT [dbo].[ApartmentFilter] ([IdApartmentFilter], [MinArea], [MaxArea], [MinRooms], [MaxRooms], [MinFloor], [MaxFloor]) VALUES (8, NULL, NULL, 3, 5, 3, 5)
INSERT [dbo].[ApartmentFilter] ([IdApartmentFilter], [MinArea], [MaxArea], [MinRooms], [MaxRooms], [MinFloor], [MaxFloor]) VALUES (9, 0, 0, 1, 4, 1, 3)
INSERT [dbo].[ApartmentFilter] ([IdApartmentFilter], [MinArea], [MaxArea], [MinRooms], [MaxRooms], [MinFloor], [MaxFloor]) VALUES (10, 60, NULL, 2, 3, 2, 6)
INSERT [dbo].[ApartmentFilter] ([IdApartmentFilter], [MinArea], [MaxArea], [MinRooms], [MaxRooms], [MinFloor], [MaxFloor]) VALUES (11, NULL, NULL, NULL, NULL, 4, 4)
INSERT [dbo].[ApartmentFilter] ([IdApartmentFilter], [MinArea], [MaxArea], [MinRooms], [MaxRooms], [MinFloor], [MaxFloor]) VALUES (12, NULL, NULL, NULL, 2, 2, 5)
INSERT [dbo].[ApartmentFilter] ([IdApartmentFilter], [MinArea], [MaxArea], [MinRooms], [MaxRooms], [MinFloor], [MaxFloor]) VALUES (13, NULL, NULL, 2, NULL, 7, 9)
INSERT [dbo].[ApartmentFilter] ([IdApartmentFilter], [MinArea], [MaxArea], [MinRooms], [MaxRooms], [MinFloor], [MaxFloor]) VALUES (14, NULL, NULL, 3, NULL, 2, 5)
INSERT [dbo].[ApartmentFilter] ([IdApartmentFilter], [MinArea], [MaxArea], [MinRooms], [MaxRooms], [MinFloor], [MaxFloor]) VALUES (15, 30, NULL, NULL, 2, 4, 4)
INSERT [dbo].[ApartmentFilter] ([IdApartmentFilter], [MinArea], [MaxArea], [MinRooms], [MaxRooms], [MinFloor], [MaxFloor]) VALUES (16, NULL, NULL, NULL, 2, NULL, 8)
INSERT [dbo].[ApartmentFilter] ([IdApartmentFilter], [MinArea], [MaxArea], [MinRooms], [MaxRooms], [MinFloor], [MaxFloor]) VALUES (25, 0, 0, 2, 1, 9, 0)
SET IDENTITY_INSERT [dbo].[Client] ON 

INSERT [dbo].[Client] ([IdClient], [FirstName], [MiddleName], [LastName], [Phone], [Email]) VALUES (2, N'Семенов', N'Евгений ', N'Николаевич', N'32-25-55', N'')
INSERT [dbo].[Client] ([IdClient], [FirstName], [MiddleName], [LastName], [Phone], [Email]) VALUES (3, N'Денисова', N'Анна', N'Леонидовна', N'25-65-85', N'dummy@email.ru')
INSERT [dbo].[Client] ([IdClient], [FirstName], [MiddleName], [LastName], [Phone], [Email]) VALUES (5, N'Сафронов', N'Алексей', N'Вячеславович', N'', N'client@esoft.tech')
INSERT [dbo].[Client] ([IdClient], [FirstName], [MiddleName], [LastName], [Phone], [Email]) VALUES (6, N'Кудряшов', N'Александр', N'Витальевич', N'551988', N'')
INSERT [dbo].[Client] ([IdClient], [FirstName], [MiddleName], [LastName], [Phone], [Email]) VALUES (8, N'Фёдоров', N'Алексей', N'Николаевич', N'', N'fedorov@mail.ru')
INSERT [dbo].[Client] ([IdClient], [FirstName], [MiddleName], [LastName], [Phone], [Email]) VALUES (10, N'Пелымская', N'Светлана', N'Александровна', N'83452112233', N'')
INSERT [dbo].[Client] ([IdClient], [FirstName], [MiddleName], [LastName], [Phone], [Email]) VALUES (12, N'Коновальчик', N'Татьяна', N'Геннадьевна', N'', N'dummy@email.ru')
INSERT [dbo].[Client] ([IdClient], [FirstName], [MiddleName], [LastName], [Phone], [Email]) VALUES (14, N'Молоковская', N'Светлана', N'Михайловна', N'898489848', N'')
INSERT [dbo].[Client] ([IdClient], [FirstName], [MiddleName], [LastName], [Phone], [Email]) VALUES (16, N'Моторина', N'Анастасия', N'Сергеевна', N'895159848', N'')
INSERT [dbo].[Client] ([IdClient], [FirstName], [MiddleName], [LastName], [Phone], [Email]) VALUES (17, N'Поспелова', N'Ольга', N'Александровна', N'', N'angel@mail.ru')
INSERT [dbo].[Client] ([IdClient], [FirstName], [MiddleName], [LastName], [Phone], [Email]) VALUES (18, N'Жиляков', N'Владимир', N'Владимирович', N'445588', N'445588@email.ru')
INSERT [dbo].[Client] ([IdClient], [FirstName], [MiddleName], [LastName], [Phone], [Email]) VALUES (20, N'Ефремов', N'Владислав', N'Николаевич', N'', N'parampampam@mail.ru')
INSERT [dbo].[Client] ([IdClient], [FirstName], [MiddleName], [LastName], [Phone], [Email]) VALUES (21, N'Баль', N'Валентина', N'Сергеевна', N'7998888444', N'')
INSERT [dbo].[Client] ([IdClient], [FirstName], [MiddleName], [LastName], [Phone], [Email]) VALUES (22, N'Стрелков', N'Артем', N'Николаевич', N'', N'test@test.test')
INSERT [dbo].[Client] ([IdClient], [FirstName], [MiddleName], [LastName], [Phone], [Email]) VALUES (23, N'Луканин', N'Павел', N'Валерьевич', N'', N'foo@bar.ru')
INSERT [dbo].[Client] ([IdClient], [FirstName], [MiddleName], [LastName], [Phone], [Email]) VALUES (25, N'Шарипова', N'Эльвира', N'Закирчановна', N'12345678910', N'')
INSERT [dbo].[Client] ([IdClient], [FirstName], [MiddleName], [LastName], [Phone], [Email]) VALUES (26, N'Фомина', N'Маргарита', N'Николаевна', N'', N'fomina@email.ru')
INSERT [dbo].[Client] ([IdClient], [FirstName], [MiddleName], [LastName], [Phone], [Email]) VALUES (27, N'Кремлев', N'Владислав', N'Юрьевич', N'777', N'kremlevvu@gmail.ru')
INSERT [dbo].[Client] ([IdClient], [FirstName], [MiddleName], [LastName], [Phone], [Email]) VALUES (28, N'Пономарева', N'Елена', N'Сергеевна', N'', N'ponomareva@gmail.ru')
INSERT [dbo].[Client] ([IdClient], [FirstName], [MiddleName], [LastName], [Phone], [Email]) VALUES (29, N'Шелест', N'Тамара', N'Васильевна', N'112', N'')
INSERT [dbo].[Client] ([IdClient], [FirstName], [MiddleName], [LastName], [Phone], [Email]) VALUES (30, N'Шарипов', N'Рустам', N'Владимирович', N'', N'sharipov@yandex.ru')
INSERT [dbo].[Client] ([IdClient], [FirstName], [MiddleName], [LastName], [Phone], [Email]) VALUES (31, N'Романов', N'Сергей', N'Федорович', N'2', N'')
INSERT [dbo].[Client] ([IdClient], [FirstName], [MiddleName], [LastName], [Phone], [Email]) VALUES (32, N'Кручинин', N'Иван', N'Андреевич', N'', N'kruch@list.ru')
INSERT [dbo].[Client] ([IdClient], [FirstName], [MiddleName], [LastName], [Phone], [Email]) VALUES (33, N'Алферов', N'Алексей', N'Николаевич', N'688899444', N'')
INSERT [dbo].[Client] ([IdClient], [FirstName], [MiddleName], [LastName], [Phone], [Email]) VALUES (35, N'Попов ', N'Алексей', N'Николаевич', N'489848565', N'popovan@bik.ru')
INSERT [dbo].[Client] ([IdClient], [FirstName], [MiddleName], [LastName], [Phone], [Email]) VALUES (36, N'Неезжала', N'Наталья', N'Леонидовна', N'55-96-74', N'neez@mail.ru')
INSERT [dbo].[Client] ([IdClient], [FirstName], [MiddleName], [LastName], [Phone], [Email]) VALUES (37, N'Васильева', N'Анна', N'', N'88-41-52', N'')
INSERT [dbo].[Client] ([IdClient], [FirstName], [MiddleName], [LastName], [Phone], [Email]) VALUES (38, N'Фомина', N'Маргарита', N'Николаевна', N'', N'fomina@email.ru')
SET IDENTITY_INSERT [dbo].[Client] OFF
SET IDENTITY_INSERT [dbo].[Deal] ON 

INSERT [dbo].[Deal] ([IdDeal], [IdDemand], [IdSupply]) VALUES (1, 1, 1)
INSERT [dbo].[Deal] ([IdDeal], [IdDemand], [IdSupply]) VALUES (2, 3, 2)
INSERT [dbo].[Deal] ([IdDeal], [IdDemand], [IdSupply]) VALUES (3, 5, 3)
INSERT [dbo].[Deal] ([IdDeal], [IdDemand], [IdSupply]) VALUES (4, 7, 4)
INSERT [dbo].[Deal] ([IdDeal], [IdDemand], [IdSupply]) VALUES (6, 2, 5)
SET IDENTITY_INSERT [dbo].[Deal] OFF
SET IDENTITY_INSERT [dbo].[Demand] ON 

INSERT [dbo].[Demand] ([IdDemand], [AddressCity], [AddressStreet], [AddressHouse], [AddressNumber], [MinPrice], [MaxPrice], [IdAgent], [IdClient]) VALUES (1, N'Тюмень', N'1-й Заречный', N'52', N'200', 2000000, 2500000, 4, 23)
INSERT [dbo].[Demand] ([IdDemand], [AddressCity], [AddressStreet], [AddressHouse], [AddressNumber], [MinPrice], [MaxPrice], [IdAgent], [IdClient]) VALUES (2, N'Тюмень', N'Пролетарская', N'2', N'15', 1500000, 2000000, 4, 16)
INSERT [dbo].[Demand] ([IdDemand], [AddressCity], [AddressStreet], [AddressHouse], [AddressNumber], [MinPrice], [MaxPrice], [IdAgent], [IdClient]) VALUES (3, N'Тюмень', N'Луговое', N'', N'5', 3500000, 4000000, 19, 10)
INSERT [dbo].[Demand] ([IdDemand], [AddressCity], [AddressStreet], [AddressHouse], [AddressNumber], [MinPrice], [MaxPrice], [IdAgent], [IdClient]) VALUES (4, N'Тюмень', N'Пролетарская', N'9', N'115', 3000000, 3200000, 15, 12)
INSERT [dbo].[Demand] ([IdDemand], [AddressCity], [AddressStreet], [AddressHouse], [AddressNumber], [MinPrice], [MaxPrice], [IdAgent], [IdClient]) VALUES (5, N'Тюмень', N'1-й Заречный', N'65', N'66', 2800000, 3000000, 1, 14)
INSERT [dbo].[Demand] ([IdDemand], [AddressCity], [AddressStreet], [AddressHouse], [AddressNumber], [MinPrice], [MaxPrice], [IdAgent], [IdClient]) VALUES (6, N'Тюмень', N'Луговое', N'85', N'35', 3000000, 3100000, 7, 5)
INSERT [dbo].[Demand] ([IdDemand], [AddressCity], [AddressStreet], [AddressHouse], [AddressNumber], [MinPrice], [MaxPrice], [IdAgent], [IdClient]) VALUES (7, N'Тюмень', N'Широтная', N'', N'39', 3000000, 3200000, 24, 25)
INSERT [dbo].[Demand] ([IdDemand], [AddressCity], [AddressStreet], [AddressHouse], [AddressNumber], [MinPrice], [MaxPrice], [IdAgent], [IdClient]) VALUES (8, N'Тюмень', N'Пролетарская', N'2', N'25', 3000000, 3600000, 1, 26)
INSERT [dbo].[Demand] ([IdDemand], [AddressCity], [AddressStreet], [AddressHouse], [AddressNumber], [MinPrice], [MaxPrice], [IdAgent], [IdClient]) VALUES (9, N'Тюмень', N'Тараскульская', N'4', N'125', 1500000, 1800000, 15, 27)
INSERT [dbo].[Demand] ([IdDemand], [AddressCity], [AddressStreet], [AddressHouse], [AddressNumber], [MinPrice], [MaxPrice], [IdAgent], [IdClient]) VALUES (10, N'Тюмень', N'Алексеевский хутор', N'9', N'176', 1500000, 1600000, 19, 28)
INSERT [dbo].[Demand] ([IdDemand], [AddressCity], [AddressStreet], [AddressHouse], [AddressNumber], [MinPrice], [MaxPrice], [IdAgent], [IdClient]) VALUES (11, N'Тюмень', N'Алексеевский хутор', N'12', N'2', 1500000, 1800000, 4, 29)
INSERT [dbo].[Demand] ([IdDemand], [AddressCity], [AddressStreet], [AddressHouse], [AddressNumber], [MinPrice], [MaxPrice], [IdAgent], [IdClient]) VALUES (12, N'Тюмень', N'Луговое', N'35', N'3', 1500000, 2000000, 7, 30)
INSERT [dbo].[Demand] ([IdDemand], [AddressCity], [AddressStreet], [AddressHouse], [AddressNumber], [MinPrice], [MaxPrice], [IdAgent], [IdClient]) VALUES (13, N'Тюмень', N'Елизарова', N'12', N'1', 2800000, 3000000, 9, 31)
INSERT [dbo].[Demand] ([IdDemand], [AddressCity], [AddressStreet], [AddressHouse], [AddressNumber], [MinPrice], [MaxPrice], [IdAgent], [IdClient]) VALUES (14, N'Тюмень', N'Елизарова', N'85', N'', 2800000, 3100000, 11, 32)
INSERT [dbo].[Demand] ([IdDemand], [AddressCity], [AddressStreet], [AddressHouse], [AddressNumber], [MinPrice], [MaxPrice], [IdAgent], [IdClient]) VALUES (15, N'Тюмень', N'Республики', N'2', N'9', 2800000, 3200000, 13, 33)
INSERT [dbo].[Demand] ([IdDemand], [AddressCity], [AddressStreet], [AddressHouse], [AddressNumber], [MinPrice], [MaxPrice], [IdAgent], [IdClient]) VALUES (16, N'Тюмень', N'Республики', N'9', N'6', 2800000, 3000000, 34, 35)
INSERT [dbo].[Demand] ([IdDemand], [AddressCity], [AddressStreet], [AddressHouse], [AddressNumber], [MinPrice], [MaxPrice], [IdAgent], [IdClient]) VALUES (24, N'Томск', N'', N'4', N'54', 200000, 300000, 4, 6)
INSERT [dbo].[Demand] ([IdDemand], [AddressCity], [AddressStreet], [AddressHouse], [AddressNumber], [MinPrice], [MaxPrice], [IdAgent], [IdClient]) VALUES (25, N'Смоленск', N'Николаева', N'65', N'2', 0, 800000, 11, 32)
SET IDENTITY_INSERT [dbo].[Demand] OFF
INSERT [dbo].[House] ([IdHouse], [TotalFloors], [TotalArea], [TotalRooms]) VALUES (9, 2, 84.4, 2)
INSERT [dbo].[House] ([IdHouse], [TotalFloors], [TotalArea], [TotalRooms]) VALUES (10, 3, 130, 3)
INSERT [dbo].[House] ([IdHouse], [TotalFloors], [TotalArea], [TotalRooms]) VALUES (11, 1, 120, 4)
INSERT [dbo].[HouseFilter] ([IdHouseFilter], [MinFloors], [MaxFloors], [MinArea], [MaxArea], [MinRooms], [MaxRooms]) VALUES (2, 2, NULL, NULL, 1000, 3, 5)
INSERT [dbo].[HouseFilter] ([IdHouseFilter], [MinFloors], [MaxFloors], [MinArea], [MaxArea], [MinRooms], [MaxRooms]) VALUES (3, 3, NULL, NULL, 500, 2, 6)
INSERT [dbo].[Land] ([IdLand], [TotalArea]) VALUES (12, 20.3)
INSERT [dbo].[Land] ([IdLand], [TotalArea]) VALUES (13, 12.45)
INSERT [dbo].[Land] ([IdLand], [TotalArea]) VALUES (14, 12)
INSERT [dbo].[LandFilter] ([IdLaneFilter], [MinArea], [MaxArea]) VALUES (4, 50, 30)
INSERT [dbo].[LandFilter] ([IdLaneFilter], [MinArea], [MaxArea]) VALUES (5, 90, 100)
INSERT [dbo].[LandFilter] ([IdLaneFilter], [MinArea], [MaxArea]) VALUES (24, 1000, 2000)
INSERT [dbo].[RealEstate] ([IdRealEstate], [AddressCity], [AddressStreet], [AddressHouse], [AddressNumder], [CoordinateLatitude], [CoordinateLongitude], [Type]) VALUES (1, N'Тюмень', N'Энергостроителей', N'25', N'12', 0, 0, 2)
INSERT [dbo].[RealEstate] ([IdRealEstate], [AddressCity], [AddressStreet], [AddressHouse], [AddressNumder], [CoordinateLatitude], [CoordinateLongitude], [Type]) VALUES (2, N'Тюмень', N'Елизарова', N'8', N'44', 0, 0, 2)
INSERT [dbo].[RealEstate] ([IdRealEstate], [AddressCity], [AddressStreet], [AddressHouse], [AddressNumder], [CoordinateLatitude], [CoordinateLongitude], [Type]) VALUES (3, N'Тюмень', N'Московский тракт', N'139', N'6', 0, 0, 2)
INSERT [dbo].[RealEstate] ([IdRealEstate], [AddressCity], [AddressStreet], [AddressHouse], [AddressNumder], [CoordinateLatitude], [CoordinateLongitude], [Type]) VALUES (4, N'Тюмень', N'Широтная', N'189', N'5', 0, 0, 2)
INSERT [dbo].[RealEstate] ([IdRealEstate], [AddressCity], [AddressStreet], [AddressHouse], [AddressNumder], [CoordinateLatitude], [CoordinateLongitude], [Type]) VALUES (5, N'Тюмень', N'Пролетарская', N'110', N'99', 0, 0, 2)
INSERT [dbo].[RealEstate] ([IdRealEstate], [AddressCity], [AddressStreet], [AddressHouse], [AddressNumder], [CoordinateLatitude], [CoordinateLongitude], [Type]) VALUES (6, N'Тюмень', N'Тараскульская', N'189', N'1', 0, 0, 2)
INSERT [dbo].[RealEstate] ([IdRealEstate], [AddressCity], [AddressStreet], [AddressHouse], [AddressNumder], [CoordinateLatitude], [CoordinateLongitude], [Type]) VALUES (7, N'Тюмень', N'Парфенова', N'22', N'1', 0, 0, 2)
INSERT [dbo].[RealEstate] ([IdRealEstate], [AddressCity], [AddressStreet], [AddressHouse], [AddressNumder], [CoordinateLatitude], [CoordinateLongitude], [Type]) VALUES (8, N'Тюмень', N'Республики', N'144', N'16', 0, 0, 2)
INSERT [dbo].[RealEstate] ([IdRealEstate], [AddressCity], [AddressStreet], [AddressHouse], [AddressNumder], [CoordinateLatitude], [CoordinateLongitude], [Type]) VALUES (9, N'Тюмень', N'1-й Заречный', N'25', N'', 0, 0, 1)
INSERT [dbo].[RealEstate] ([IdRealEstate], [AddressCity], [AddressStreet], [AddressHouse], [AddressNumder], [CoordinateLatitude], [CoordinateLongitude], [Type]) VALUES (10, N'Тюмень', N'Ялyтopoвcкий тpaкт', N'', N'', 0, 0, 1)
INSERT [dbo].[RealEstate] ([IdRealEstate], [AddressCity], [AddressStreet], [AddressHouse], [AddressNumder], [CoordinateLatitude], [CoordinateLongitude], [Type]) VALUES (11, N'Тюмень', N'Березняковский п', N'', N'', 0, 0, 1)
INSERT [dbo].[RealEstate] ([IdRealEstate], [AddressCity], [AddressStreet], [AddressHouse], [AddressNumder], [CoordinateLatitude], [CoordinateLongitude], [Type]) VALUES (12, N'Тюмень', N'Луговое', N'', N'', 0, 0, 3)
INSERT [dbo].[RealEstate] ([IdRealEstate], [AddressCity], [AddressStreet], [AddressHouse], [AddressNumder], [CoordinateLatitude], [CoordinateLongitude], [Type]) VALUES (13, N'Тюмень', N'Алексеевский хутор', N'', N'', 0, 0, 3)
INSERT [dbo].[RealEstate] ([IdRealEstate], [AddressCity], [AddressStreet], [AddressHouse], [AddressNumder], [CoordinateLatitude], [CoordinateLongitude], [Type]) VALUES (14, N'Тюмень', N'Суходольский мкр', N'', N'', 0, 0, 3)
INSERT [dbo].[RealEstateFilter] ([IdRealEstateFilter], [Type]) VALUES (1, 2)
INSERT [dbo].[RealEstateFilter] ([IdRealEstateFilter], [Type]) VALUES (2, 1)
INSERT [dbo].[RealEstateFilter] ([IdRealEstateFilter], [Type]) VALUES (3, 1)
INSERT [dbo].[RealEstateFilter] ([IdRealEstateFilter], [Type]) VALUES (4, 3)
INSERT [dbo].[RealEstateFilter] ([IdRealEstateFilter], [Type]) VALUES (5, 3)
INSERT [dbo].[RealEstateFilter] ([IdRealEstateFilter], [Type]) VALUES (6, 2)
INSERT [dbo].[RealEstateFilter] ([IdRealEstateFilter], [Type]) VALUES (7, 2)
INSERT [dbo].[RealEstateFilter] ([IdRealEstateFilter], [Type]) VALUES (8, 2)
INSERT [dbo].[RealEstateFilter] ([IdRealEstateFilter], [Type]) VALUES (9, 2)
INSERT [dbo].[RealEstateFilter] ([IdRealEstateFilter], [Type]) VALUES (10, 2)
INSERT [dbo].[RealEstateFilter] ([IdRealEstateFilter], [Type]) VALUES (11, 2)
INSERT [dbo].[RealEstateFilter] ([IdRealEstateFilter], [Type]) VALUES (12, 2)
INSERT [dbo].[RealEstateFilter] ([IdRealEstateFilter], [Type]) VALUES (13, 2)
INSERT [dbo].[RealEstateFilter] ([IdRealEstateFilter], [Type]) VALUES (14, 2)
INSERT [dbo].[RealEstateFilter] ([IdRealEstateFilter], [Type]) VALUES (15, 2)
INSERT [dbo].[RealEstateFilter] ([IdRealEstateFilter], [Type]) VALUES (16, 2)
INSERT [dbo].[RealEstateFilter] ([IdRealEstateFilter], [Type]) VALUES (24, 3)
INSERT [dbo].[RealEstateFilter] ([IdRealEstateFilter], [Type]) VALUES (25, 2)
SET IDENTITY_INSERT [dbo].[Supply] ON 

INSERT [dbo].[Supply] ([IdSupply], [Price], [IdAgent], [IdClient], [IdRealEstate]) VALUES (1, 2500000, 1, 2, 1)
INSERT [dbo].[Supply] ([IdSupply], [Price], [IdAgent], [IdClient], [IdRealEstate]) VALUES (2, 5000000, 7, 8, 3)
INSERT [dbo].[Supply] ([IdSupply], [Price], [IdAgent], [IdClient], [IdRealEstate]) VALUES (3, 1300000, 11, 12, 3)
INSERT [dbo].[Supply] ([IdSupply], [Price], [IdAgent], [IdClient], [IdRealEstate]) VALUES (4, 5000000, 15, 16, 4)
INSERT [dbo].[Supply] ([IdSupply], [Price], [IdAgent], [IdClient], [IdRealEstate]) VALUES (5, 4700000, 1, 3, 2)
INSERT [dbo].[Supply] ([IdSupply], [Price], [IdAgent], [IdClient], [IdRealEstate]) VALUES (6, 3750000, 4, 5, 3)
INSERT [dbo].[Supply] ([IdSupply], [Price], [IdAgent], [IdClient], [IdRealEstate]) VALUES (7, 1900000, 4, 6, 3)
INSERT [dbo].[Supply] ([IdSupply], [Price], [IdAgent], [IdClient], [IdRealEstate]) VALUES (8, 4300000, 9, 10, 3)
INSERT [dbo].[Supply] ([IdSupply], [Price], [IdAgent], [IdClient], [IdRealEstate]) VALUES (9, 1750000, 13, 14, 3)
INSERT [dbo].[Supply] ([IdSupply], [Price], [IdAgent], [IdClient], [IdRealEstate]) VALUES (10, 5850000, 15, 17, 5)
INSERT [dbo].[Supply] ([IdSupply], [Price], [IdAgent], [IdClient], [IdRealEstate]) VALUES (11, 6800000, 15, 18, 6)
INSERT [dbo].[Supply] ([IdSupply], [Price], [IdAgent], [IdClient], [IdRealEstate]) VALUES (12, 950000, 19, 20, 7)
INSERT [dbo].[Supply] ([IdSupply], [Price], [IdAgent], [IdClient], [IdRealEstate]) VALUES (13, 700000, 19, 21, 8)
INSERT [dbo].[Supply] ([IdSupply], [Price], [IdAgent], [IdClient], [IdRealEstate]) VALUES (14, 700000, 24, 22, 9)
INSERT [dbo].[Supply] ([IdSupply], [Price], [IdAgent], [IdClient], [IdRealEstate]) VALUES (15, 3200000, 4, 36, 10)
SET IDENTITY_INSERT [dbo].[Supply] OFF
INSERT [dbo].[TypeEstate] ([IdType], [Type]) VALUES (1, N'Дом')
INSERT [dbo].[TypeEstate] ([IdType], [Type]) VALUES (2, N'Квартира')
INSERT [dbo].[TypeEstate] ([IdType], [Type]) VALUES (3, N'Участок')
ALTER TABLE [dbo].[Apartment]  WITH CHECK ADD  CONSTRAINT [FK_Apartment_RealEstate] FOREIGN KEY([IdApartment])
REFERENCES [dbo].[RealEstate] ([IdRealEstate])
GO
ALTER TABLE [dbo].[Apartment] CHECK CONSTRAINT [FK_Apartment_RealEstate]
GO
ALTER TABLE [dbo].[ApartmentFilter]  WITH CHECK ADD  CONSTRAINT [FK_ApartmentFilter_RealEstateFilter] FOREIGN KEY([IdApartmentFilter])
REFERENCES [dbo].[RealEstateFilter] ([IdRealEstateFilter])
GO
ALTER TABLE [dbo].[ApartmentFilter] CHECK CONSTRAINT [FK_ApartmentFilter_RealEstateFilter]
GO
ALTER TABLE [dbo].[Deal]  WITH CHECK ADD  CONSTRAINT [FK_Deal_Demand] FOREIGN KEY([IdDemand])
REFERENCES [dbo].[Demand] ([IdDemand])
GO
ALTER TABLE [dbo].[Deal] CHECK CONSTRAINT [FK_Deal_Demand]
GO
ALTER TABLE [dbo].[Deal]  WITH CHECK ADD  CONSTRAINT [FK_Deal_Supply] FOREIGN KEY([IdSupply])
REFERENCES [dbo].[Supply] ([IdSupply])
GO
ALTER TABLE [dbo].[Deal] CHECK CONSTRAINT [FK_Deal_Supply]
GO
ALTER TABLE [dbo].[Demand]  WITH CHECK ADD  CONSTRAINT [FK_Demand_Agent] FOREIGN KEY([IdAgent])
REFERENCES [dbo].[Agent] ([IdAgent])
GO
ALTER TABLE [dbo].[Demand] CHECK CONSTRAINT [FK_Demand_Agent]
GO
ALTER TABLE [dbo].[Demand]  WITH CHECK ADD  CONSTRAINT [FK_Demand_Client] FOREIGN KEY([IdClient])
REFERENCES [dbo].[Client] ([IdClient])
GO
ALTER TABLE [dbo].[Demand] CHECK CONSTRAINT [FK_Demand_Client]
GO
ALTER TABLE [dbo].[House]  WITH CHECK ADD  CONSTRAINT [FK_House_RealEstate] FOREIGN KEY([IdHouse])
REFERENCES [dbo].[RealEstate] ([IdRealEstate])
GO
ALTER TABLE [dbo].[House] CHECK CONSTRAINT [FK_House_RealEstate]
GO
ALTER TABLE [dbo].[HouseFilter]  WITH CHECK ADD  CONSTRAINT [FK_HouseFilter_RealEstateFilter] FOREIGN KEY([IdHouseFilter])
REFERENCES [dbo].[RealEstateFilter] ([IdRealEstateFilter])
GO
ALTER TABLE [dbo].[HouseFilter] CHECK CONSTRAINT [FK_HouseFilter_RealEstateFilter]
GO
ALTER TABLE [dbo].[Land]  WITH CHECK ADD  CONSTRAINT [FK_Land_RealEstate] FOREIGN KEY([IdLand])
REFERENCES [dbo].[RealEstate] ([IdRealEstate])
GO
ALTER TABLE [dbo].[Land] CHECK CONSTRAINT [FK_Land_RealEstate]
GO
ALTER TABLE [dbo].[LandFilter]  WITH CHECK ADD  CONSTRAINT [FK_LandFilter_RealEstateFilter] FOREIGN KEY([IdLaneFilter])
REFERENCES [dbo].[RealEstateFilter] ([IdRealEstateFilter])
GO
ALTER TABLE [dbo].[LandFilter] CHECK CONSTRAINT [FK_LandFilter_RealEstateFilter]
GO
ALTER TABLE [dbo].[RealEstate]  WITH CHECK ADD  CONSTRAINT [FK_RealEstate_TypeEstate] FOREIGN KEY([Type])
REFERENCES [dbo].[TypeEstate] ([IdType])
GO
ALTER TABLE [dbo].[RealEstate] CHECK CONSTRAINT [FK_RealEstate_TypeEstate]
GO
ALTER TABLE [dbo].[RealEstateFilter]  WITH CHECK ADD  CONSTRAINT [FK_RealEstateFilter_Demand] FOREIGN KEY([IdRealEstateFilter])
REFERENCES [dbo].[Demand] ([IdDemand])
GO
ALTER TABLE [dbo].[RealEstateFilter] CHECK CONSTRAINT [FK_RealEstateFilter_Demand]
GO
ALTER TABLE [dbo].[RealEstateFilter]  WITH CHECK ADD  CONSTRAINT [FK_RealEstateFilter_TypeEstate] FOREIGN KEY([Type])
REFERENCES [dbo].[TypeEstate] ([IdType])
GO
ALTER TABLE [dbo].[RealEstateFilter] CHECK CONSTRAINT [FK_RealEstateFilter_TypeEstate]
GO
ALTER TABLE [dbo].[Supply]  WITH CHECK ADD  CONSTRAINT [FK_Supply_Agent] FOREIGN KEY([IdAgent])
REFERENCES [dbo].[Agent] ([IdAgent])
GO
ALTER TABLE [dbo].[Supply] CHECK CONSTRAINT [FK_Supply_Agent]
GO
ALTER TABLE [dbo].[Supply]  WITH CHECK ADD  CONSTRAINT [FK_Supply_Client] FOREIGN KEY([IdClient])
REFERENCES [dbo].[Client] ([IdClient])
GO
ALTER TABLE [dbo].[Supply] CHECK CONSTRAINT [FK_Supply_Client]
GO
ALTER TABLE [dbo].[Supply]  WITH CHECK ADD  CONSTRAINT [FK_Supply_RealEstate] FOREIGN KEY([IdRealEstate])
REFERENCES [dbo].[RealEstate] ([IdRealEstate])
GO
ALTER TABLE [dbo].[Supply] CHECK CONSTRAINT [FK_Supply_RealEstate]
GO
ALTER TABLE [dbo].[Agent]  WITH CHECK ADD  CONSTRAINT [CK_Agent] CHECK  (([DealShare]>=(0) AND [DealShare]<(100)))
GO
ALTER TABLE [dbo].[Agent] CHECK CONSTRAINT [CK_Agent]
GO
ALTER TABLE [dbo].[RealEstate]  WITH CHECK ADD  CONSTRAINT [CK_RealEstate_Latitude] CHECK  (([CoordinateLatitude]>=(-90) AND [CoordinateLatitude]<=(90)))
GO
ALTER TABLE [dbo].[RealEstate] CHECK CONSTRAINT [CK_RealEstate_Latitude]
GO
ALTER TABLE [dbo].[RealEstate]  WITH CHECK ADD  CONSTRAINT [CK_RealEstate_Longitude] CHECK  (([CoordinateLongitude]>=(-180) AND [CoordinateLongitude]<=(180)))
GO
ALTER TABLE [dbo].[RealEstate] CHECK CONSTRAINT [CK_RealEstate_Longitude]
GO
USE [master]
GO
ALTER DATABASE [Esoft] SET  READ_WRITE 
GO
