USE [master]
GO
/****** Object:  Database [EnesOzmus.03Week]    Script Date: 25.04.2022 13:00:30 ******/
CREATE DATABASE [EnesOzmus.03Week]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EnesOzmus.03Week', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\EnesOzmus.03Week.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EnesOzmus.03Week_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\EnesOzmus.03Week_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [EnesOzmus.03Week] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EnesOzmus.03Week].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EnesOzmus.03Week] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EnesOzmus.03Week] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EnesOzmus.03Week] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EnesOzmus.03Week] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EnesOzmus.03Week] SET ARITHABORT OFF 
GO
ALTER DATABASE [EnesOzmus.03Week] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EnesOzmus.03Week] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EnesOzmus.03Week] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EnesOzmus.03Week] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EnesOzmus.03Week] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EnesOzmus.03Week] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EnesOzmus.03Week] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EnesOzmus.03Week] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EnesOzmus.03Week] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EnesOzmus.03Week] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EnesOzmus.03Week] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EnesOzmus.03Week] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EnesOzmus.03Week] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EnesOzmus.03Week] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EnesOzmus.03Week] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EnesOzmus.03Week] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [EnesOzmus.03Week] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EnesOzmus.03Week] SET RECOVERY FULL 
GO
ALTER DATABASE [EnesOzmus.03Week] SET  MULTI_USER 
GO
ALTER DATABASE [EnesOzmus.03Week] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EnesOzmus.03Week] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EnesOzmus.03Week] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EnesOzmus.03Week] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EnesOzmus.03Week] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EnesOzmus.03Week] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'EnesOzmus.03Week', N'ON'
GO
ALTER DATABASE [EnesOzmus.03Week] SET QUERY_STORE = OFF
GO
USE [EnesOzmus.03Week]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 5.05.2022 15:07:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[OldPrice] [decimal](18, 2) NULL,
	[Discount] [decimal](18, 2) NULL,
	[UnitInStock] [int] NOT NULL,
	[ProductAvailable] [bit] NOT NULL,
	[Picture1] [image] NULL,
	[Picture2] [image] NULL,
	[Picture3] [image] NULL,
	[Picture4] [image] NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[LastModifiedDate] [datetime2](7) NULL,
	[CategoryId] [int] NOT NULL,
	[SupplierId] [int] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 5.05.2022 15:07:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](15) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Picture1] [image] NULL,
	[Picture2] [image] NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[LastModifiedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[View_Products]    Script Date: 5.05.2022 15:07:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE View [dbo].[View_Products]
AS
SELECT p1.Name, c1.CategoryName, p1.Price, p1.Discount, p1.ProductAvailable
from Products p1
left join Categories c1
on p1.CategoryId = c1.Id
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 5.05.2022 15:07:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](15) NOT NULL,
	[LastName] [nvarchar](15) NOT NULL,
	[UserName] [nvarchar](15) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](15) NULL,
	[Gender] [nvarchar](10) NULL,
	[BirthDate] [date] NULL,
	[City] [nvarchar](15) NULL,
	[Country] [nvarchar](15) NULL,
	[Phone1] [nvarchar](15) NULL,
	[Phone2] [nvarchar](15) NULL,
	[Address1] [nvarchar](max) NULL,
	[Address2] [nvarchar](max) NULL,
	[CreditCard] [nvarchar](10) NULL,
	[CreditCardType] [nvarchar](25) NULL,
	[CreditCardNumber] [nvarchar](25) NULL,
	[Picture] [image] NULL,
	[Status] [bit] NOT NULL,
	[LastLogin] [datetime] NULL,
	[RoleType] [int] NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[View_Customers]    Script Date: 5.05.2022 15:07:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE View [dbo].[View_Customers]
AS
SELECT a1.UserName, a1.City, a1.Picture
from Customers a1
GO
/****** Object:  View [dbo].[View_CustomerInformation]    Script Date: 5.05.2022 15:07:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[View_CustomerInformation]
WITH SCHEMABINDING AS
SELECT CONCAT(n.FirstName,' ' , n.LastName) as 'FullName',
n.Email,n.Password
FROM [dbo].[Customers] n
GO
/****** Object:  View [dbo].[View_ProductsCategories]    Script Date: 5.05.2022 15:07:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE View [dbo].[View_ProductsCategories]
AS
SELECT Products.*, Categories.CategoryName
FROM Categories INNER JOIN Products ON Categories.Id = Products.CategoryId
WHERE (((Products.ProductAvailable)=1))
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 5.05.2022 15:07:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](15) NOT NULL,
	[LastName] [nvarchar](15) NOT NULL,
	[Title] [nvarchar](20) NOT NULL,
	[Email] [nvarchar](50) NULL,
	[BirthDate] [date] NOT NULL,
	[HireDate] [date] NOT NULL,
	[Address] [nvarchar](max) NULL,
	[City] [nvarchar](15) NULL,
	[Country] [nvarchar](15) NULL,
	[Phone] [nvarchar](15) NULL,
	[Photo] [image] NULL,
	[PhotoPath] [nvarchar](255) NULL,
	[RoleType] [int] NOT NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Logging]    Script Date: 5.05.2022 15:07:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Logging](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](15) NOT NULL,
	[Password] [nvarchar](15) NOT NULL,
	[RoleType] [int] NOT NULL,
 CONSTRAINT [PK_Logging] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 5.05.2022 15:07:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderNumber] [int] NOT NULL,
	[TotalPrice] [decimal](18, 2) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Taxes] [decimal](18, 2) NOT NULL,
	[Discount] [decimal](18, 2) NULL,
	[OrderId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
 CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 5.05.2022 15:07:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderDate] [datetime] NOT NULL,
	[IsCompleted] [bit] NOT NULL,
	[IsShipped] [bit] NOT NULL,
	[ShippingDate] [datetime] NOT NULL,
	[IsDelivered] [bit] NOT NULL,
	[DeliveryDate] [datetime] NOT NULL,
	[Notes] [nvarchar](max) NULL,
	[CancelOrder] [bit] NULL,
	[ErrorMessage] [nvarchar](50) NULL,
	[CustomerId] [int] NOT NULL,
	[PaymentId] [int] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payments]    Script Date: 5.05.2022 15:07:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PaymentType] [nvarchar](50) NULL,
	[Allowed] [money] NULL,
	[PaymentDateTime] [datetime2](7) NULL,
 CONSTRAINT [PK_Payments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductDetails]    Script Date: 5.05.2022 15:07:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ShortDescription] [nvarchar](60) NULL,
	[LongDescription] [nvarchar](max) NULL,
	[Brand] [nvarchar](15) NOT NULL,
	[Size] [nvarchar](15) NOT NULL,
	[Fabric] [nvarchar](15) NULL,
	[UnitWeight] [decimal](18, 2) NULL,
	[Color] [nvarchar](15) NULL,
	[QuantityPerUnit] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
 CONSTRAINT [PK_ProductDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 5.05.2022 15:07:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](8) NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Suppliers]    Script Date: 5.05.2022 15:07:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Suppliers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [nvarchar](15) NOT NULL,
	[ContactName] [nvarchar](15) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[Phone] [nvarchar](15) NOT NULL,
	[Fax] [nvarchar](15) NOT NULL,
	[Email] [nvarchar](20) NOT NULL,
	[City] [nvarchar](15) NOT NULL,
	[Country] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK_Suppliers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([Id], [CategoryName], [Description], [Picture1], [Picture2], [CreatedDate], [LastModifiedDate]) VALUES (1, N'Mont', N'Kýþ Sezonu', NULL, NULL, CAST(N'2022-05-01T00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Categories] ([Id], [CategoryName], [Description], [Picture1], [Picture2], [CreatedDate], [LastModifiedDate]) VALUES (2, N'Hýrka', N'Kýþ Sezonu', NULL, NULL, CAST(N'2022-05-01T00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Categories] ([Id], [CategoryName], [Description], [Picture1], [Picture2], [CreatedDate], [LastModifiedDate]) VALUES (3, N'Kazak', N'Kýþ Sezonu', NULL, NULL, CAST(N'2022-05-01T00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Categories] ([Id], [CategoryName], [Description], [Picture1], [Picture2], [CreatedDate], [LastModifiedDate]) VALUES (4, N'Tiþört', N'Yaz Sezonu', NULL, NULL, CAST(N'2022-05-01T00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Categories] ([Id], [CategoryName], [Description], [Picture1], [Picture2], [CreatedDate], [LastModifiedDate]) VALUES (5, N'Gömlek', N'Yaz Sezonu', NULL, NULL, CAST(N'2022-05-01T00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Categories] ([Id], [CategoryName], [Description], [Picture1], [Picture2], [CreatedDate], [LastModifiedDate]) VALUES (6, N'Pantolon', N'Bütün Sezonlar', NULL, NULL, CAST(N'2022-05-01T00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Categories] ([Id], [CategoryName], [Description], [Picture1], [Picture2], [CreatedDate], [LastModifiedDate]) VALUES (7, N'Süveter', N'Kýþ Sezonu', NULL, NULL, CAST(N'2022-05-01T00:00:00.0000000' AS DateTime2), NULL)
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Customers] ON 

INSERT [dbo].[Customers] ([Id], [FirstName], [LastName], [UserName], [Email], [Password], [Gender], [BirthDate], [City], [Country], [Phone1], [Phone2], [Address1], [Address2], [CreditCard], [CreditCardType], [CreditCardNumber], [Picture], [Status], [LastLogin], [RoleType]) VALUES (1, N'Ýhsan', N'Yenilmez', N'ihsan', N'ihsan@seeddata.com', N'ihsan123*', N'Erkek', CAST(N'1990-07-01' AS Date), N'Muðla', NULL, N'0505 555 1111', N'---', N'address1', N'---', N'Bank1', N'Ticari Kart', N'5454 5454 5454 5454', NULL, 1, CAST(N'2022-05-01T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Customers] ([Id], [FirstName], [LastName], [UserName], [Email], [Password], [Gender], [BirthDate], [City], [Country], [Phone1], [Phone2], [Address1], [Address2], [CreditCard], [CreditCardType], [CreditCardNumber], [Picture], [Status], [LastLogin], [RoleType]) VALUES (2, N'Umay', N'Zengin', N'umay', N'umay@seeddata.com', N'umay123*', N'Kadýn', CAST(N'1990-06-01' AS Date), N'Aydýn', NULL, N'0505 555 2222', N'---', N'address2', N'---', N'Bank2', N'Ticari Kart', N'5454 5454 5454 5454', NULL, 1, CAST(N'2022-05-01T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Customers] ([Id], [FirstName], [LastName], [UserName], [Email], [Password], [Gender], [BirthDate], [City], [Country], [Phone1], [Phone2], [Address1], [Address2], [CreditCard], [CreditCardType], [CreditCardNumber], [Picture], [Status], [LastLogin], [RoleType]) VALUES (3, N'Emre', N'Demir', N'emre', N'emre@seeddata.com', N'emre123*', N'Erkek', CAST(N'1990-05-01' AS Date), N'Çanakkale', NULL, N'0505 555 3333', N'---', N'address3', N'---', N'Bank3', N'Ticari Kart', N'5454 5454 5454 5454', NULL, 1, CAST(N'2022-05-01T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Customers] ([Id], [FirstName], [LastName], [UserName], [Email], [Password], [Gender], [BirthDate], [City], [Country], [Phone1], [Phone2], [Address1], [Address2], [CreditCard], [CreditCardType], [CreditCardNumber], [Picture], [Status], [LastLogin], [RoleType]) VALUES (4, N'Emine', N'Yýldýrým', N'emine', N'emine@seeddata.com', N'emine123-', N'Kadýn', CAST(N'1990-04-01' AS Date), N'Ýzmir', NULL, N'0505 555 4444', N'---', N'address4', N'---', N'Bank4', N'Ticari Kart', N'5454 5454 5454 5454', NULL, 1, CAST(N'2022-05-01T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Customers] ([Id], [FirstName], [LastName], [UserName], [Email], [Password], [Gender], [BirthDate], [City], [Country], [Phone1], [Phone2], [Address1], [Address2], [CreditCard], [CreditCardType], [CreditCardNumber], [Picture], [Status], [LastLogin], [RoleType]) VALUES (5, N'Salih', N'Yurdakul', N'salih', N'salih@seeddata.com', N'salih123*', N'Erkek', CAST(N'1990-03-01' AS Date), N'Yalova', NULL, N'0505 555 5555', N'---', N'address5', N'---', N'Bank5', N'Ticari Kart', N'5454 5454 5454 5454', NULL, 1, CAST(N'2022-05-01T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Customers] ([Id], [FirstName], [LastName], [UserName], [Email], [Password], [Gender], [BirthDate], [City], [Country], [Phone1], [Phone2], [Address1], [Address2], [CreditCard], [CreditCardType], [CreditCardNumber], [Picture], [Status], [LastLogin], [RoleType]) VALUES (6, N'Zafer', N'Çaðlayan', N'zafer', N'zafer@seeddata.com', N'zafer123*', N'Erkek', CAST(N'1990-02-01' AS Date), N'Rize', NULL, N'0505 555 6666', N'---', N'address6', N'---', N'Bank6', N'Ticari Kart', N'5454 5454 5454 5454', NULL, 1, CAST(N'2022-05-01T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Customers] ([Id], [FirstName], [LastName], [UserName], [Email], [Password], [Gender], [BirthDate], [City], [Country], [Phone1], [Phone2], [Address1], [Address2], [CreditCard], [CreditCardType], [CreditCardNumber], [Picture], [Status], [LastLogin], [RoleType]) VALUES (7, N'Hakan', N'Filiz', N'hakan', N'hakan@seeddata.com', N'hakan123*', N'Erkek', CAST(N'1990-01-01' AS Date), N'Amasya', NULL, N'0505 555 7777', N'---', N'address7', N'---', N'Bank7', N'Ticari Kart', N'5454 5454 5454 5454', NULL, 1, CAST(N'2022-05-01T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Customers] ([Id], [FirstName], [LastName], [UserName], [Email], [Password], [Gender], [BirthDate], [City], [Country], [Phone1], [Phone2], [Address1], [Address2], [CreditCard], [CreditCardType], [CreditCardNumber], [Picture], [Status], [LastLogin], [RoleType]) VALUES (8, N'Berrin', N'Miral', N'berrin', N'berrin@seeddata.com', N'berrin123*', N'Kadýn', CAST(N'1989-12-01' AS Date), N'Ýstanbul', NULL, N'0505 555 8888', N'---', N'address8', N'---', N'Bank8', N'Ticari Kart', N'5454 5454 5454 5454', NULL, 1, CAST(N'2022-05-01T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Customers] ([Id], [FirstName], [LastName], [UserName], [Email], [Password], [Gender], [BirthDate], [City], [Country], [Phone1], [Phone2], [Address1], [Address2], [CreditCard], [CreditCardType], [CreditCardNumber], [Picture], [Status], [LastLogin], [RoleType]) VALUES (9, N'Selim', N'Karaca', N'selim', N'selim@seeddata.com', N'selim123-', N'Erkek', CAST(N'1989-11-01' AS Date), N'Bursa', NULL, N'0505 555 9999', N'---', N'address9', N'---', N'Bank9', N'Ticari Kart', NULL, NULL, 1, CAST(N'2022-05-01T00:00:00.000' AS DateTime), 2)
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
SET IDENTITY_INSERT [dbo].[Employees] ON 

INSERT [dbo].[Employees] ([Id], [FirstName], [LastName], [Title], [Email], [BirthDate], [HireDate], [Address], [City], [Country], [Phone], [Photo], [PhotoPath], [RoleType]) VALUES (1, N'Tolga', N'Kardeþler', N'Uzman Yardýmcýsý', NULL, CAST(N'1985-07-01' AS Date), CAST(N'2022-05-02' AS Date), NULL, N'Ýstanbul', N'Türkiye', N'0505 555 5555', NULL, NULL, 3)
INSERT [dbo].[Employees] ([Id], [FirstName], [LastName], [Title], [Email], [BirthDate], [HireDate], [Address], [City], [Country], [Phone], [Photo], [PhotoPath], [RoleType]) VALUES (2, N'Yeliz', N'Ýþler', N'Uzman Yardýmcýsý', NULL, CAST(N'1985-07-02' AS Date), CAST(N'2022-05-02' AS Date), NULL, N'Ýstanbul', N'Türkiye', N'0505 444 4444', NULL, NULL, 3)
INSERT [dbo].[Employees] ([Id], [FirstName], [LastName], [Title], [Email], [BirthDate], [HireDate], [Address], [City], [Country], [Phone], [Photo], [PhotoPath], [RoleType]) VALUES (3, N'Berkay', N'Kurt', N'Uzman Yardýmcýsý', NULL, CAST(N'1985-07-03' AS Date), CAST(N'2022-05-02' AS Date), NULL, N'Ýstanbul', N'Türkiye', N'0505 333 333', NULL, NULL, 3)
INSERT [dbo].[Employees] ([Id], [FirstName], [LastName], [Title], [Email], [BirthDate], [HireDate], [Address], [City], [Country], [Phone], [Photo], [PhotoPath], [RoleType]) VALUES (4, N'Melis', N'Semer', N'Uzman Yardýmcýsý', NULL, CAST(N'1985-07-04' AS Date), CAST(N'2022-05-02' AS Date), NULL, N'Ýstanbul', N'Türkiye', N'0505 222 2222', NULL, NULL, 3)
INSERT [dbo].[Employees] ([Id], [FirstName], [LastName], [Title], [Email], [BirthDate], [HireDate], [Address], [City], [Country], [Phone], [Photo], [PhotoPath], [RoleType]) VALUES (5, N'Hakan', N'Biral', N'Uzman Yardýmcýsý', NULL, CAST(N'1985-07-05' AS Date), CAST(N'2022-05-02' AS Date), NULL, N'Ýstanbul', N'Türkiye', N'0505 111 1111', NULL, NULL, 3)
INSERT [dbo].[Employees] ([Id], [FirstName], [LastName], [Title], [Email], [BirthDate], [HireDate], [Address], [City], [Country], [Phone], [Photo], [PhotoPath], [RoleType]) VALUES (6, N'Selin', N'Kýþla', N'Uzman Yardýmcýsý', NULL, CAST(N'1985-07-06' AS Date), CAST(N'2022-05-02' AS Date), NULL, N'Ýstanbul', N'Türkiye', N'0505 000 0000', NULL, NULL, 3)
INSERT [dbo].[Employees] ([Id], [FirstName], [LastName], [Title], [Email], [BirthDate], [HireDate], [Address], [City], [Country], [Phone], [Photo], [PhotoPath], [RoleType]) VALUES (7, N'Bülent', N'Zor', N'Uzman Yardýmcýsý', NULL, CAST(N'1985-07-07' AS Date), CAST(N'2022-05-02' AS Date), NULL, N'Ýstanbul', N'Türkiye', N'0505 777 777', NULL, NULL, 3)
SET IDENTITY_INSERT [dbo].[Employees] OFF
GO
SET IDENTITY_INSERT [dbo].[Logging] ON 

INSERT [dbo].[Logging] ([Id], [UserName], [Password], [RoleType]) VALUES (1, N'EnesOzmus      ', N'Admin123*      ', 1)
INSERT [dbo].[Logging] ([Id], [UserName], [Password], [RoleType]) VALUES (2, N'Bootcamp       ', N'camp123*       ', 2)
SET IDENTITY_INSERT [dbo].[Logging] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductDetails] ON 

INSERT [dbo].[ProductDetails] ([Id], [ShortDescription], [LongDescription], [Brand], [Size], [Fabric], [UnitWeight], [Color], [QuantityPerUnit], [ProductId]) VALUES (1, NULL, NULL, N'LCW', N'XS', N'deri', NULL, N'siyah', 1, 1)
INSERT [dbo].[ProductDetails] ([Id], [ShortDescription], [LongDescription], [Brand], [Size], [Fabric], [UnitWeight], [Color], [QuantityPerUnit], [ProductId]) VALUES (2, NULL, NULL, N'LCW', N'XS', N'pamuk', NULL, N'beyaz', 1, 2)
INSERT [dbo].[ProductDetails] ([Id], [ShortDescription], [LongDescription], [Brand], [Size], [Fabric], [UnitWeight], [Color], [QuantityPerUnit], [ProductId]) VALUES (3, NULL, NULL, N'LCW', N'S', N'pamuk', NULL, N'kýrmýzý', 1, 3)
INSERT [dbo].[ProductDetails] ([Id], [ShortDescription], [LongDescription], [Brand], [Size], [Fabric], [UnitWeight], [Color], [QuantityPerUnit], [ProductId]) VALUES (4, NULL, NULL, N'LCW', N'S', N'pamuk', NULL, N'mavi', 1, 4)
INSERT [dbo].[ProductDetails] ([Id], [ShortDescription], [LongDescription], [Brand], [Size], [Fabric], [UnitWeight], [Color], [QuantityPerUnit], [ProductId]) VALUES (5, NULL, NULL, N'LCW', N'M', N'triko', NULL, N'siyah', 1, 5)
INSERT [dbo].[ProductDetails] ([Id], [ShortDescription], [LongDescription], [Brand], [Size], [Fabric], [UnitWeight], [Color], [QuantityPerUnit], [ProductId]) VALUES (6, NULL, NULL, N'LCW', N'M', N'triko', NULL, N'siyah', 1, 6)
INSERT [dbo].[ProductDetails] ([Id], [ShortDescription], [LongDescription], [Brand], [Size], [Fabric], [UnitWeight], [Color], [QuantityPerUnit], [ProductId]) VALUES (7, NULL, NULL, N'LCW', N'M', N'triko', NULL, N'beyaz', 1, 7)
INSERT [dbo].[ProductDetails] ([Id], [ShortDescription], [LongDescription], [Brand], [Size], [Fabric], [UnitWeight], [Color], [QuantityPerUnit], [ProductId]) VALUES (8, NULL, NULL, N'LCW', N'X', N'triko', NULL, N'siyah', 1, 8)
INSERT [dbo].[ProductDetails] ([Id], [ShortDescription], [LongDescription], [Brand], [Size], [Fabric], [UnitWeight], [Color], [QuantityPerUnit], [ProductId]) VALUES (9, NULL, NULL, N'LCW', N'XL', N'poplin', NULL, N'mavi', 1, 9)
INSERT [dbo].[ProductDetails] ([Id], [ShortDescription], [LongDescription], [Brand], [Size], [Fabric], [UnitWeight], [Color], [QuantityPerUnit], [ProductId]) VALUES (10, NULL, NULL, N'LCW', N'XL', N'poplin', NULL, N'beyaz', 1, 10)
INSERT [dbo].[ProductDetails] ([Id], [ShortDescription], [LongDescription], [Brand], [Size], [Fabric], [UnitWeight], [Color], [QuantityPerUnit], [ProductId]) VALUES (11, NULL, NULL, N'LCW', N'XLL', N'kadife', NULL, N'siyah', 1, 11)
INSERT [dbo].[ProductDetails] ([Id], [ShortDescription], [LongDescription], [Brand], [Size], [Fabric], [UnitWeight], [Color], [QuantityPerUnit], [ProductId]) VALUES (12, NULL, NULL, N'LCW', N'XLL', N'kadife', NULL, N'siyah', 1, 12)
SET IDENTITY_INSERT [dbo].[ProductDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([Id], [Name], [Price], [OldPrice], [Discount], [UnitInStock], [ProductAvailable], [Picture1], [Picture2], [Picture3], [Picture4], [CreatedDate], [LastModifiedDate], [CategoryId], [SupplierId]) VALUES (1, N'Standart Kalýp Kapüþonlu Mont', CAST(419.90 AS Decimal(18, 2)), NULL, NULL, 250, 1, NULL, NULL, NULL, NULL, CAST(N'2022-05-01T00:00:00.0000000' AS DateTime2), NULL, 1, 1)
INSERT [dbo].[Products] ([Id], [Name], [Price], [OldPrice], [Discount], [UnitInStock], [ProductAvailable], [Picture1], [Picture2], [Picture3], [Picture4], [CreatedDate], [LastModifiedDate], [CategoryId], [SupplierId]) VALUES (2, N'Standart Kalýp Ýnce Mont', CAST(417.90 AS Decimal(18, 2)), NULL, NULL, 250, 1, NULL, NULL, NULL, NULL, CAST(N'2022-05-01T00:00:00.0000000' AS DateTime2), NULL, 1, 1)
INSERT [dbo].[Products] ([Id], [Name], [Price], [OldPrice], [Discount], [UnitInStock], [ProductAvailable], [Picture1], [Picture2], [Picture3], [Picture4], [CreatedDate], [LastModifiedDate], [CategoryId], [SupplierId]) VALUES (3, N'Outdoor Dik Yaka Erkek Polar Hýrka', CAST(149.99 AS Decimal(18, 2)), NULL, NULL, 250, 1, NULL, NULL, NULL, NULL, CAST(N'2022-05-01T00:00:00.0000000' AS DateTime2), NULL, 2, 1)
INSERT [dbo].[Products] ([Id], [Name], [Price], [OldPrice], [Discount], [UnitInStock], [ProductAvailable], [Picture1], [Picture2], [Picture3], [Picture4], [CreatedDate], [LastModifiedDate], [CategoryId], [SupplierId]) VALUES (4, N'Uzun Kollu Erkek Triko Hýrka', CAST(149.99 AS Decimal(18, 2)), NULL, NULL, 250, 1, NULL, NULL, NULL, NULL, CAST(N'2022-05-01T00:00:00.0000000' AS DateTime2), NULL, 2, 1)
INSERT [dbo].[Products] ([Id], [Name], [Price], [OldPrice], [Discount], [UnitInStock], [ProductAvailable], [Picture1], [Picture2], [Picture3], [Picture4], [CreatedDate], [LastModifiedDate], [CategoryId], [SupplierId]) VALUES (5, N'Kýsa Kollu Triko Kazak', CAST(109.99 AS Decimal(18, 2)), NULL, NULL, 250, 1, NULL, NULL, NULL, NULL, CAST(N'2022-05-01T00:00:00.0000000' AS DateTime2), NULL, 3, 1)
INSERT [dbo].[Products] ([Id], [Name], [Price], [OldPrice], [Discount], [UnitInStock], [ProductAvailable], [Picture1], [Picture2], [Picture3], [Picture4], [CreatedDate], [LastModifiedDate], [CategoryId], [SupplierId]) VALUES (6, N'Yarým Balýkçý Yaka Triko Kazak', CAST(109.99 AS Decimal(18, 2)), NULL, NULL, 250, 0, NULL, NULL, NULL, NULL, CAST(N'2022-05-01T00:00:00.0000000' AS DateTime2), NULL, 3, 1)
INSERT [dbo].[Products] ([Id], [Name], [Price], [OldPrice], [Discount], [UnitInStock], [ProductAvailable], [Picture1], [Picture2], [Picture3], [Picture4], [CreatedDate], [LastModifiedDate], [CategoryId], [SupplierId]) VALUES (7, N'Baskýlý Penye Tiþört', CAST(89.99 AS Decimal(18, 2)), NULL, NULL, 250, 1, NULL, NULL, NULL, NULL, CAST(N'2022-05-01T00:00:00.0000000' AS DateTime2), NULL, 4, 2)
INSERT [dbo].[Products] ([Id], [Name], [Price], [OldPrice], [Discount], [UnitInStock], [ProductAvailable], [Picture1], [Picture2], [Picture3], [Picture4], [CreatedDate], [LastModifiedDate], [CategoryId], [SupplierId]) VALUES (8, N'Polo Yaka Kýsa Kollu Pike Tiþört', CAST(89.99 AS Decimal(18, 2)), NULL, NULL, 250, 0, NULL, NULL, NULL, NULL, CAST(N'2022-05-01T00:00:00.0000000' AS DateTime2), NULL, 4, 2)
INSERT [dbo].[Products] ([Id], [Name], [Price], [OldPrice], [Discount], [UnitInStock], [ProductAvailable], [Picture1], [Picture2], [Picture3], [Picture4], [CreatedDate], [LastModifiedDate], [CategoryId], [SupplierId]) VALUES (9, N'Jean Gömlek', CAST(199.99 AS Decimal(18, 2)), NULL, NULL, 250, 1, NULL, NULL, NULL, NULL, CAST(N'2022-05-01T00:00:00.0000000' AS DateTime2), NULL, 5, 2)
INSERT [dbo].[Products] ([Id], [Name], [Price], [OldPrice], [Discount], [UnitInStock], [ProductAvailable], [Picture1], [Picture2], [Picture3], [Picture4], [CreatedDate], [LastModifiedDate], [CategoryId], [SupplierId]) VALUES (10, N'Slim Gömlek', CAST(199.99 AS Decimal(18, 2)), NULL, NULL, 250, 1, NULL, NULL, NULL, NULL, CAST(N'2022-05-01T00:00:00.0000000' AS DateTime2), NULL, 5, 2)
INSERT [dbo].[Products] ([Id], [Name], [Price], [OldPrice], [Discount], [UnitInStock], [ProductAvailable], [Picture1], [Picture2], [Picture3], [Picture4], [CreatedDate], [LastModifiedDate], [CategoryId], [SupplierId]) VALUES (11, N'Kargo Pantolon', CAST(149.99 AS Decimal(18, 2)), NULL, NULL, 0, 1, NULL, NULL, NULL, NULL, CAST(N'2022-05-01T00:00:00.0000000' AS DateTime2), NULL, 6, 1)
INSERT [dbo].[Products] ([Id], [Name], [Price], [OldPrice], [Discount], [UnitInStock], [ProductAvailable], [Picture1], [Picture2], [Picture3], [Picture4], [CreatedDate], [LastModifiedDate], [CategoryId], [SupplierId]) VALUES (12, N'Armürlü Pantolon', CAST(149.99 AS Decimal(18, 2)), NULL, NULL, 5, 1, NULL, NULL, NULL, NULL, CAST(N'2022-05-01T00:00:00.0000000' AS DateTime2), NULL, 6, 1)
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([Id], [RoleName], [Description]) VALUES (1, N'Admin', N'Manager')
INSERT [dbo].[Roles] ([Id], [RoleName], [Description]) VALUES (2, N'User ', N'Customer')
INSERT [dbo].[Roles] ([Id], [RoleName], [Description]) VALUES (3, N'Employee', N'Worker')
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Suppliers] ON 

INSERT [dbo].[Suppliers] ([Id], [CompanyName], [ContactName], [Address], [Phone], [Fax], [Email], [City], [Country]) VALUES (1, N'LC Waikiki', N'Tedarikçi', N'Fýrtýna Mahallesi Yýldýrým Sokak', N'05055055555', N'94874563748', N'test@gmail.com', N'Ýstanbul', N'Türkiye')
INSERT [dbo].[Suppliers] ([Id], [CompanyName], [ContactName], [Address], [Phone], [Fax], [Email], [City], [Country]) VALUES (2, N'LC Waikiki', N'Diðer Tedarikçi', N'Yeni Mahalle Demir Sokak', N'04044044444', N'98754357897', N'demo@gmail.com', N'Ankara', N'Türkiye')
SET IDENTITY_INSERT [dbo].[Suppliers] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [idx_Name]    Script Date: 5.05.2022 15:07:20 ******/
CREATE NONCLUSTERED INDEX [idx_Name] ON [dbo].[Categories]
(
	[CategoryName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [idx_City]    Script Date: 5.05.2022 15:07:20 ******/
CREATE NONCLUSTERED INDEX [idx_City] ON [dbo].[Customers]
(
	[City] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [idx_LastName]    Script Date: 5.05.2022 15:07:20 ******/
CREATE NONCLUSTERED INDEX [idx_LastName] ON [dbo].[Customers]
(
	[LastName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [idx_Email]    Script Date: 5.05.2022 15:07:20 ******/
CREATE NONCLUSTERED INDEX [idx_Email] ON [dbo].[Employees]
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [idx_LastName]    Script Date: 5.05.2022 15:07:20 ******/
CREATE NONCLUSTERED INDEX [idx_LastName] ON [dbo].[Employees]
(
	[LastName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [idx_OrderID]    Script Date: 5.05.2022 15:07:20 ******/
CREATE NONCLUSTERED INDEX [idx_OrderID] ON [dbo].[OrderDetails]
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [idx_ProductID]    Script Date: 5.05.2022 15:07:20 ******/
CREATE NONCLUSTERED INDEX [idx_ProductID] ON [dbo].[OrderDetails]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [idx_CustomerID]    Script Date: 5.05.2022 15:07:20 ******/
CREATE NONCLUSTERED INDEX [idx_CustomerID] ON [dbo].[Orders]
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [idx_OrderDate]    Script Date: 5.05.2022 15:07:20 ******/
CREATE NONCLUSTERED INDEX [idx_OrderDate] ON [dbo].[Orders]
(
	[OrderDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [idx_CategoryID]    Script Date: 5.05.2022 15:07:20 ******/
CREATE NONCLUSTERED INDEX [idx_CategoryID] ON [dbo].[Products]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [idx_Name]    Script Date: 5.05.2022 15:07:20 ******/
CREATE NONCLUSTERED INDEX [idx_Name] ON [dbo].[Products]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [idx_CompanyName]    Script Date: 5.05.2022 15:07:20 ******/
CREATE NONCLUSTERED INDEX [idx_CompanyName] ON [dbo].[Suppliers]
(
	[CompanyName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [idx_Email]    Script Date: 5.05.2022 15:07:20 ******/
CREATE NONCLUSTERED INDEX [idx_Email] ON [dbo].[Suppliers]
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Customers]  WITH CHECK ADD  CONSTRAINT [FK_Customers_Roles] FOREIGN KEY([RoleType])
REFERENCES [dbo].[Roles] ([Id])
GO
ALTER TABLE [dbo].[Customers] CHECK CONSTRAINT [FK_Customers_Roles]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Roles] FOREIGN KEY([RoleType])
REFERENCES [dbo].[Roles] ([Id])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Roles]
GO
ALTER TABLE [dbo].[Logging]  WITH CHECK ADD  CONSTRAINT [FK_Logging_Roles] FOREIGN KEY([RoleType])
REFERENCES [dbo].[Roles] ([Id])
GO
ALTER TABLE [dbo].[Logging] CHECK CONSTRAINT [FK_Logging_Roles]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Orders] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([Id])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Orders]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Products] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Products]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Customers] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Customers]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Payments] FOREIGN KEY([PaymentId])
REFERENCES [dbo].[Payments] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Payments]
GO
ALTER TABLE [dbo].[ProductDetails]  WITH CHECK ADD  CONSTRAINT [FK_ProductDetails_Products] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[ProductDetails] CHECK CONSTRAINT [FK_ProductDetails_Products]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Categories]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Suppliers] FOREIGN KEY([SupplierId])
REFERENCES [dbo].[Suppliers] ([Id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Suppliers]
GO
/****** Object:  StoredProcedure [dbo].[AboutToFinish_Products]    Script Date: 5.05.2022 15:07:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AboutToFinish_Products]
AS
SELECT * FROM Products
WHERE Products.UnitInStock < 10
GO
/****** Object:  StoredProcedure [dbo].[OutofStock]    Script Date: 5.05.2022 15:07:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[OutofStock]
AS
SELECT * FROM Products
WHERE Products.UnitInStock = 0
GO
/****** Object:  StoredProcedure [dbo].[SelectAvailableProducts]    Script Date: 5.05.2022 15:07:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectAvailableProducts]
AS
SELECT * FROM Products
WHERE Products.ProductAvailable = 1
GO
/****** Object:  Trigger [dbo].[Trigger_createTotalPrice]    Script Date: 5.05.2022 15:07:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Trigger [dbo].[Trigger_createTotalPrice]
on [dbo].[OrderDetails]
after insert 
as 
begin
update OrderDetails
set  TotalPrice = Price * Quantity
end
GO
ALTER TABLE [dbo].[OrderDetails] ENABLE TRIGGER [Trigger_createTotalPrice]
GO
/****** Object:  Trigger [dbo].[Trigger_DeleteOrder]    Script Date: 5.05.2022 15:07:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[Trigger_DeleteOrder]
ON  [dbo].[Products]
AFTER DELETE
AS 
BEGIN
DECLARE @id int
SELECT @id = Id from Products
UPDATE Orders SET IsCompleted = 0 where CustomerId = @id
END
GO
ALTER TABLE [dbo].[Products] ENABLE TRIGGER [Trigger_DeleteOrder]
GO
/****** Object:  Trigger [dbo].[Trigger_InsertProducts]    Script Date: 5.05.2022 15:07:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[Trigger_InsertProducts]
ON [dbo].[Products]
AFTER INSERT
AS
BEGIN
	PRINT('PRODUCT SUCCESSFULLY ADDED!')
END
GO
ALTER TABLE [dbo].[Products] ENABLE TRIGGER [Trigger_InsertProducts]
GO
ALTER DATABASE [EnesOzmus.03Week] SET  READ_WRITE 
GO