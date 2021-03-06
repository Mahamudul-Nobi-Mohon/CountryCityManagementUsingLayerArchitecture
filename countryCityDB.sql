USE [master]
GO
/****** Object:  Database [CountryCityManagementSystemDB]    Script Date: 10/26/2016 2:49:27 AM ******/
CREATE DATABASE [CountryCityManagementSystemDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CountryCityManagementSystemDB', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\CountryCityManagementSystemDB.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CountryCityManagementSystemDB_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\CountryCityManagementSystemDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CountryCityManagementSystemDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CountryCityManagementSystemDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CountryCityManagementSystemDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CountryCityManagementSystemDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CountryCityManagementSystemDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CountryCityManagementSystemDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CountryCityManagementSystemDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [CountryCityManagementSystemDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CountryCityManagementSystemDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [CountryCityManagementSystemDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CountryCityManagementSystemDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CountryCityManagementSystemDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CountryCityManagementSystemDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CountryCityManagementSystemDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CountryCityManagementSystemDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CountryCityManagementSystemDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CountryCityManagementSystemDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CountryCityManagementSystemDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CountryCityManagementSystemDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CountryCityManagementSystemDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CountryCityManagementSystemDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CountryCityManagementSystemDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CountryCityManagementSystemDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CountryCityManagementSystemDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CountryCityManagementSystemDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CountryCityManagementSystemDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CountryCityManagementSystemDB] SET  MULTI_USER 
GO
ALTER DATABASE [CountryCityManagementSystemDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CountryCityManagementSystemDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CountryCityManagementSystemDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CountryCityManagementSystemDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [CountryCityManagementSystemDB]
GO
/****** Object:  Table [dbo].[City]    Script Date: 10/26/2016 2:49:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[City](
	[cityId] [int] IDENTITY(1,1) NOT NULL,
	[cityName] [varchar](20) NOT NULL,
	[about] [text] NULL,
	[noOfDwellers] [int] NULL,
	[location] [varchar](20) NULL,
	[weather] [text] NULL,
	[countryId] [int] NOT NULL,
 CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED 
(
	[cityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Country]    Script Date: 10/26/2016 2:49:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Country](
	[countryId] [int] IDENTITY(1,1) NOT NULL,
	[countryName] [varchar](10) NOT NULL,
	[about] [text] NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[countryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[ViewAllCityWithCountry]    Script Date: 10/26/2016 2:49:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ViewAllCityWithCountry]
AS
SELECT p.cityId,p.cityName,p.about as cityAbout,p.noOfDwellers,p.location
,p.weather,p.countryId as countryId,c.countryName,c.about as countryAbout
From city p INNER JOIN Country c ON
p.countryId=c.countryId

GO
SET IDENTITY_INSERT [dbo].[City] ON 

INSERT [dbo].[City] ([cityId], [cityName], [about], [noOfDwellers], [location], [weather], [countryId]) VALUES (2, N'dhaka', N'beautiful city', 1000, N'dhaka', N'hot', 1)
INSERT [dbo].[City] ([cityId], [cityName], [about], [noOfDwellers], [location], [weather], [countryId]) VALUES (3, N'pabna', NULL, 8, NULL, NULL, 2)
INSERT [dbo].[City] ([cityId], [cityName], [about], [noOfDwellers], [location], [weather], [countryId]) VALUES (5, N'pabna1', NULL, 9, NULL, NULL, 1)
INSERT [dbo].[City] ([cityId], [cityName], [about], [noOfDwellers], [location], [weather], [countryId]) VALUES (7, N'dhaka2', N'<p>dfdfggf</p>', 300, N'Rangpur Sadar', N'as', 1)
INSERT [dbo].[City] ([cityId], [cityName], [about], [noOfDwellers], [location], [weather], [countryId]) VALUES (11, N'Indoneshiaj', N'<p>fgf</p>', 300, N'Rangpur Sadar', N'as', 2)
INSERT [dbo].[City] ([cityId], [cityName], [about], [noOfDwellers], [location], [weather], [countryId]) VALUES (12, N'sindbad', N'<p>sindbad <strong>city</strong> is good.</p>', 300, N'Rangpur Sadar', N'11', 1)
INSERT [dbo].[City] ([cityId], [cityName], [about], [noOfDwellers], [location], [weather], [countryId]) VALUES (13, N'Indoneshiao', N'<p>ll</p>', 300, N'Rangpur Sadar', N'as', 1)
INSERT [dbo].[City] ([cityId], [cityName], [about], [noOfDwellers], [location], [weather], [countryId]) VALUES (14, N'Indoneshia ffff', N'<p>ff</p>', 11, N'f', N'f', 3)
SET IDENTITY_INSERT [dbo].[City] OFF
SET IDENTITY_INSERT [dbo].[Country] ON 

INSERT [dbo].[Country] ([countryId], [countryName], [about]) VALUES (1, N'Bangladesh', N'Beautiful country.')
INSERT [dbo].[Country] ([countryId], [countryName], [about]) VALUES (2, N'India', N'big country')
INSERT [dbo].[Country] ([countryId], [countryName], [about]) VALUES (3, N'vutan', N'df')
INSERT [dbo].[Country] ([countryId], [countryName], [about]) VALUES (5, N'sri lanka', N'<p>green country</p>
<p>&nbsp;</p>')
INSERT [dbo].[Country] ([countryId], [countryName], [about]) VALUES (6, N'japan', N'<p>ddd</p>')
INSERT [dbo].[Country] ([countryId], [countryName], [about]) VALUES (7, N'pakistan', N'<p>pakistan</p>')
INSERT [dbo].[Country] ([countryId], [countryName], [about]) VALUES (8, N'', N'')
INSERT [dbo].[Country] ([countryId], [countryName], [about]) VALUES (9, N'srilanka', N'<p>df</p>')
INSERT [dbo].[Country] ([countryId], [countryName], [about]) VALUES (10, N'srilanka2', N'<p>df</p>')
INSERT [dbo].[Country] ([countryId], [countryName], [about]) VALUES (11, N'swigerland', N'<p>wow</p>')
INSERT [dbo].[Country] ([countryId], [countryName], [about]) VALUES (13, N'srilanka3', N'<p>3</p>')
SET IDENTITY_INSERT [dbo].[Country] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_City_Name]    Script Date: 10/26/2016 2:49:27 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_City_Name] ON [dbo].[City]
(
	[cityName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Country_Name]    Script Date: 10/26/2016 2:49:27 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Country_Name] ON [dbo].[Country]
(
	[countryName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[City]  WITH CHECK ADD  CONSTRAINT [FK_City_Country] FOREIGN KEY([countryId])
REFERENCES [dbo].[Country] ([countryId])
GO
ALTER TABLE [dbo].[City] CHECK CONSTRAINT [FK_City_Country]
GO
USE [master]
GO
ALTER DATABASE [CountryCityManagementSystemDB] SET  READ_WRITE 
GO
