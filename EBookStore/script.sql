USE [master]
GO
/****** Object:  Database [AS2]    Script Date: 21/02/2023 07:45:33 ******/
CREATE DATABASE [AS2]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AS2', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\AS2.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AS2_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\AS2_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [AS2] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AS2].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AS2] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AS2] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AS2] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AS2] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AS2] SET ARITHABORT OFF 
GO
ALTER DATABASE [AS2] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AS2] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AS2] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AS2] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AS2] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AS2] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AS2] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AS2] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AS2] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AS2] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AS2] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AS2] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AS2] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AS2] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AS2] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AS2] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AS2] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AS2] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [AS2] SET  MULTI_USER 
GO
ALTER DATABASE [AS2] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AS2] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AS2] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AS2] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [AS2] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [AS2] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [AS2] SET QUERY_STORE = ON
GO
ALTER DATABASE [AS2] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [AS2]
GO
/****** Object:  Table [dbo].[Author]    Script Date: 21/02/2023 07:45:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Author](
	[author_id] [char](10) NOT NULL,
	[last_name] [nvarchar](15) NOT NULL,
	[first_name] [nvarchar](15) NOT NULL,
	[phone] [varchar](15) NULL,
	[address] [nvarchar](50) NULL,
	[city] [nvarchar](20) NULL,
	[state] [nvarchar](20) NULL,
	[zip] [varchar](20) NULL,
	[email_address] [varchar](50) NULL,
 CONSTRAINT [PK_Author] PRIMARY KEY CLUSTERED 
(
	[author_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Book]    Script Date: 21/02/2023 07:45:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[book_id] [char](10) NOT NULL,
	[title] [nvarchar](50) NOT NULL,
	[type] [nvarchar](20) NULL,
	[pub_id] [char](10) NOT NULL,
	[price] [decimal](10, 2) NULL,
	[advance] [decimal](10, 2) NULL,
	[royalty] [decimal](10, 2) NULL,
	[ytd_sales] [int] NULL,
	[notes] [nvarchar](50) NULL,
	[published_date] [date] NULL,
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[book_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookAuthor]    Script Date: 21/02/2023 07:45:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookAuthor](
	[author_id] [char](10) NOT NULL,
	[book_id] [char](10) NOT NULL,
	[author_order] [tinyint] NULL,
	[royality_percentage] [tinyint] NULL,
 CONSTRAINT [PK_BookAuthor] PRIMARY KEY CLUSTERED 
(
	[author_id] ASC,
	[book_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Publisher]    Script Date: 21/02/2023 07:45:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Publisher](
	[pub_id] [char](10) NOT NULL,
	[publisher_name] [nvarchar](50) NOT NULL,
	[city] [nvarchar](20) NULL,
	[state] [nvarchar](20) NULL,
	[country] [nvarchar](20) NULL,
 CONSTRAINT [PK_Publisher] PRIMARY KEY CLUSTERED 
(
	[pub_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 21/02/2023 07:45:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[role_id] [bit] NOT NULL,
	[role_desc] [nvarchar](50) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[role_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 21/02/2023 07:45:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[user_id] [char](10) NOT NULL,
	[email_address] [varchar](50) NOT NULL,
	[password] [varchar](15) NOT NULL,
	[source] [nvarchar](50) NULL,
	[first_name] [nvarchar](15) NULL,
	[middle_name] [nvarchar](15) NULL,
	[last_name] [nvarchar](15) NULL,
	[role_id] [bit] NOT NULL,
	[pub_id] [char](10) NOT NULL,
	[hire_date] [date] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Author] ([author_id], [last_name], [first_name], [phone], [address], [city], [state], [zip], [email_address]) VALUES (N'0b4v5i1Y0Z', N'Ghelardi', N'Phillipe', N'6065268206', NULL, N'Jianqiao', NULL, N'CN', N'pghelardib@techcrunch.com')
INSERT [dbo].[Author] ([author_id], [last_name], [first_name], [phone], [address], [city], [state], [zip], [email_address]) VALUES (N'0L3Y1Y6o8j', N'Laugier', N'Verna', N'3745088510', NULL, N'Ozalj', NULL, N'JO', N'vlaugierh@bravesites.com')
INSERT [dbo].[Author] ([author_id], [last_name], [first_name], [phone], [address], [city], [state], [zip], [email_address]) VALUES (N'0N3u9Q756W', N'Tolefree', N'Korella', N'5065622868', NULL, N'Sviblovo', NULL, N'RU', N'ktolefree7@skyrock.com')
INSERT [dbo].[Author] ([author_id], [last_name], [first_name], [phone], [address], [city], [state], [zip], [email_address]) VALUES (N'0R0p4x8I1S', N'Spearman', N'Sammy', N'6648473519', NULL, N'Sanyang', NULL, N'CN', N'sspearman3@usda.gov')
INSERT [dbo].[Author] ([author_id], [last_name], [first_name], [phone], [address], [city], [state], [zip], [email_address]) VALUES (N'0R0w8P9R65', N'Hatton', N'Albertine', N'4195657274', NULL, N'Qalqaman', NULL, N'KZ', N'ahatton4@is.gd')
INSERT [dbo].[Author] ([author_id], [last_name], [first_name], [phone], [address], [city], [state], [zip], [email_address]) VALUES (N'0X1X8j124N', N'Weedenburg', N'Olvan', N'1362321851', NULL, N'Zhujiatai', NULL, N'CN', N'oweedenburgf@hugedomains.com')
INSERT [dbo].[Author] ([author_id], [last_name], [first_name], [phone], [address], [city], [state], [zip], [email_address]) VALUES (N'1X3r458Y1S', N'Schule', N'Dorisa', N'2214782713', NULL, N'Los Pinos', N'Veracruz Llave', N'MX', N'dschulen@examiner.com')
INSERT [dbo].[Author] ([author_id], [last_name], [first_name], [phone], [address], [city], [state], [zip], [email_address]) VALUES (N'213L1a6x01', N'Turvey', N'Nathanael', N'7917475336', NULL, N'Zhuqi', NULL, N'CN', N'nturveya@mtv.com')
INSERT [dbo].[Author] ([author_id], [last_name], [first_name], [phone], [address], [city], [state], [zip], [email_address]) VALUES (N'261V5b5j0q', N'Auchterlonie', N'Gayler', N'7336137673', NULL, N'Ozalj', NULL, N'HR', N'gauchterloniei@g.co')
INSERT [dbo].[Author] ([author_id], [last_name], [first_name], [phone], [address], [city], [state], [zip], [email_address]) VALUES (N'2J6s7d8t4t', N'Attryde', N'Rina', N'5983522955', N'5746 Atwood Street', N'Vitrolles', NULL, N'GR', N'rattrydep@amazon.co.uk')
INSERT [dbo].[Author] ([author_id], [last_name], [first_name], [phone], [address], [city], [state], [zip], [email_address]) VALUES (N'300E0t6d3W', N'Philbrook', N'Juline', N'9202709146', NULL, N'Esperanza', NULL, N'AR', N'jphilbrookj@thetimes.co.uk')
INSERT [dbo].[Author] ([author_id], [last_name], [first_name], [phone], [address], [city], [state], [zip], [email_address]) VALUES (N'3O6q5K3T7N', N'Siggery', N'Julissa', N'5222004904', NULL, N'Zhongshangang', NULL, N'CN', N'jsiggery6@biglobe.ne.jp')
INSERT [dbo].[Author] ([author_id], [last_name], [first_name], [phone], [address], [city], [state], [zip], [email_address]) VALUES (N'3Q2I4b6M2V', N'Frane', N'Min', N'1215402412', NULL, N'Gubeikou', NULL, N'CN', N'mfraned@intel.com')
INSERT [dbo].[Author] ([author_id], [last_name], [first_name], [phone], [address], [city], [state], [zip], [email_address]) VALUES (N'4m9e047U5M', N'Marquez', N'Ajay', N'9665386597', NULL, N'Karolino-Buhaz', NULL, N'UA', N'amarquez8@biblegateway.com')
INSERT [dbo].[Author] ([author_id], [last_name], [first_name], [phone], [address], [city], [state], [zip], [email_address]) VALUES (N'5c5Y7X0B0o', N'Haug', N'Gris', N'8452007410', N'062 Fallview Terrace', N'Kuala Terengganu', N'Terengganu', N'MY', N'ghaug9@yahoo.com')
INSERT [dbo].[Author] ([author_id], [last_name], [first_name], [phone], [address], [city], [state], [zip], [email_address]) VALUES (N'5V228e2w1H', N'Wrightam', N'Phaedra', N'2917400954', NULL, N'Gubukjero Timuk', NULL, N'ID', N'pwrightame@fema.gov')
INSERT [dbo].[Author] ([author_id], [last_name], [first_name], [phone], [address], [city], [state], [zip], [email_address]) VALUES (N'5x1d070Y3r', N'Took', N'Cara', N'4397481845', NULL, N'Burgas', NULL, N'BG', N'ctookk@canalblog.com')
INSERT [dbo].[Author] ([author_id], [last_name], [first_name], [phone], [address], [city], [state], [zip], [email_address]) VALUES (N'6G4t7B335T', N'Jardine', N'Rafael', N'1211124671', N'9644 Sloan Park', N'Sendafa', NULL, N'ET', N'rjardineq@tmall.com')
INSERT [dbo].[Author] ([author_id], [last_name], [first_name], [phone], [address], [city], [state], [zip], [email_address]) VALUES (N'6w1t7d336B', N'Brundale', N'Waverly', N'9723611728', NULL, N'Jalasenga', NULL, N'ID', N'wbrundalem@usgs.gov')
INSERT [dbo].[Author] ([author_id], [last_name], [first_name], [phone], [address], [city], [state], [zip], [email_address]) VALUES (N'6w8k7P9Q6x', N'Castagneri', N'Sella', N'8931203550', NULL, N'Oslo', N'Oslo', N'NO', N'scastagnerig@naver.com')
INSERT [dbo].[Author] ([author_id], [last_name], [first_name], [phone], [address], [city], [state], [zip], [email_address]) VALUES (N'732i4O4Q2C', N'Libbe', N'Brnaby', N'4918729014', NULL, N'Chelgard', NULL, N'IR', N'blibbel@mapy.cz')
INSERT [dbo].[Author] ([author_id], [last_name], [first_name], [phone], [address], [city], [state], [zip], [email_address]) VALUES (N'7a0X5N840h', N'Ivanovic', N'Odetta', N'6508728965', NULL, N'Pasadena', N'California', N'US', N'oivanovic1@blog.com')
INSERT [dbo].[Author] ([author_id], [last_name], [first_name], [phone], [address], [city], [state], [zip], [email_address]) VALUES (N'7c4l6M2E6g', N'Ragge', N'Brita', N'4919039710', NULL, N'Qalqaman', NULL, N'PL', N'bragge5@mashable.com')
INSERT [dbo].[Author] ([author_id], [last_name], [first_name], [phone], [address], [city], [state], [zip], [email_address]) VALUES (N'7F027I4H4i', N'Kitteringham', N'Britta', N'3424523137', NULL, N'Khiv', NULL, N'RU', N'bkitteringham2@dagondesign.com')
INSERT [dbo].[Author] ([author_id], [last_name], [first_name], [phone], [address], [city], [state], [zip], [email_address]) VALUES (N'7k4O3J5L7r', N'Jimes', N'Dody', N'7674475881', NULL, N'Vitrolles', NULL, N'FR', N'djimeso@dropbox.com')
INSERT [dbo].[Author] ([author_id], [last_name], [first_name], [phone], [address], [city], [state], [zip], [email_address]) VALUES (N'7R2X6c2j6p', N'Ochterlony', N'Granger', N'3093790210', NULL, N'Santa Cruz de Yojoa', NULL, N'HN', N'gochterlony0@state.gov')
INSERT [dbo].[Author] ([author_id], [last_name], [first_name], [phone], [address], [city], [state], [zip], [email_address]) VALUES (N'8C8C8z5C5W', N'Stoyle', N'Britt', N'7246391026', NULL, N'Handaqi', NULL, N'CN', N'bstoylec@prlog.org')
GO
INSERT [dbo].[Book] ([book_id], [title], [type], [pub_id], [price], [advance], [royalty], [ytd_sales], [notes], [published_date]) VALUES (N'0b2I8b4z0e', N'The Little Book of Joy', N'Memoir', N'349       ', CAST(10.00 AS Decimal(10, 2)), CAST(5.00 AS Decimal(10, 2)), CAST(3.00 AS Decimal(10, 2)), 14, N'Dental restoration NEC', CAST(N'2022-08-18' AS Date))
INSERT [dbo].[Book] ([book_id], [title], [type], [pub_id], [price], [advance], [royalty], [ytd_sales], [notes], [published_date]) VALUES (N'1z7n6X0k1n', N'Sach Kahun Toh', N'Autobiography', N'150       ', CAST(10.00 AS Decimal(10, 2)), CAST(5.00 AS Decimal(10, 2)), CAST(3.00 AS Decimal(10, 2)), 30, N'Ovarian wedge resection', CAST(N'2022-03-17' AS Date))
INSERT [dbo].[Book] ([book_id], [title], [type], [pub_id], [price], [advance], [royalty], [ytd_sales], [notes], [published_date]) VALUES (N'2l8Z5Z7K6E', N'The India Story', N'Autobiography', N'101       ', CAST(10.00 AS Decimal(10, 2)), CAST(5.00 AS Decimal(10, 2)), CAST(3.00 AS Decimal(10, 2)), 1, N'Thermokeratoplasty', CAST(N'2022-03-09' AS Date))
INSERT [dbo].[Book] ([book_id], [title], [type], [pub_id], [price], [advance], [royalty], [ytd_sales], [notes], [published_date]) VALUES (N'2m9R6J5w13', N'Right Under Our Nose', N'Mystery', N'386       ', CAST(10.00 AS Decimal(10, 2)), CAST(5.00 AS Decimal(10, 2)), CAST(3.00 AS Decimal(10, 2)), 21, N'Destruc hepatic les NEC', CAST(N'2022-09-29' AS Date))
INSERT [dbo].[Book] ([book_id], [title], [type], [pub_id], [price], [advance], [royalty], [ytd_sales], [notes], [published_date]) VALUES (N'2N392d3J16', N'Decoding Indian Babudom', N'Prayer', N'178       ', CAST(10.00 AS Decimal(10, 2)), CAST(5.00 AS Decimal(10, 2)), CAST(3.00 AS Decimal(10, 2)), 8, N'Therapeu plasmapheresis', CAST(N'2022-08-11' AS Date))
INSERT [dbo].[Book] ([book_id], [title], [type], [pub_id], [price], [advance], [royalty], [ytd_sales], [notes], [published_date]) VALUES (N'2V70323k7V', N'Monsoon', N'Philosophy', N'338       ', CAST(10.00 AS Decimal(10, 2)), CAST(5.00 AS Decimal(10, 2)), CAST(3.00 AS Decimal(10, 2)), 13, N'Destruct scleral lesion', CAST(N'2022-04-26' AS Date))
INSERT [dbo].[Book] ([book_id], [title], [type], [pub_id], [price], [advance], [royalty], [ytd_sales], [notes], [published_date]) VALUES (N'2Y3R4w1l2X', N'The Commonwealth of Cricket', N'Humor', N'389       ', CAST(10.00 AS Decimal(10, 2)), CAST(5.00 AS Decimal(10, 2)), CAST(3.00 AS Decimal(10, 2)), 22, N'Bact smear-spleen/marrow', CAST(N'2022-04-13' AS Date))
INSERT [dbo].[Book] ([book_id], [title], [type], [pub_id], [price], [advance], [royalty], [ytd_sales], [notes], [published_date]) VALUES (N'40598O6v49', N'The Living Mountain', N'Humor', N'107       ', CAST(10.00 AS Decimal(10, 2)), CAST(5.00 AS Decimal(10, 2)), CAST(3.00 AS Decimal(10, 2)), 28, N'Mastotomy', CAST(N'2023-01-24' AS Date))
INSERT [dbo].[Book] ([book_id], [title], [type], [pub_id], [price], [advance], [royalty], [ytd_sales], [notes], [published_date]) VALUES (N'492C4b2n5l', N'Names of the Women', N'Romance', N'226       ', CAST(10.00 AS Decimal(10, 2)), CAST(5.00 AS Decimal(10, 2)), CAST(3.00 AS Decimal(10, 2)), 25, N'Incisional hernia repair', CAST(N'2022-05-25' AS Date))
INSERT [dbo].[Book] ([book_id], [title], [type], [pub_id], [price], [advance], [royalty], [ytd_sales], [notes], [published_date]) VALUES (N'4D3i9e9Q7k', N'Whereabouts', N'Mystery', N'105       ', CAST(10.00 AS Decimal(10, 2)), CAST(5.00 AS Decimal(10, 2)), CAST(3.00 AS Decimal(10, 2)), 27, N'Excis tonsil/adenoid les', CAST(N'2022-04-09' AS Date))
INSERT [dbo].[Book] ([book_id], [title], [type], [pub_id], [price], [advance], [royalty], [ytd_sales], [notes], [published_date]) VALUES (N'4E5i1k5n3y', N'Unfinished', N'Science fiction', N'397       ', CAST(10.00 AS Decimal(10, 2)), CAST(5.00 AS Decimal(10, 2)), CAST(3.00 AS Decimal(10, 2)), 23, N'Oth rep int cervical os', CAST(N'2022-12-11' AS Date))
INSERT [dbo].[Book] ([book_id], [title], [type], [pub_id], [price], [advance], [royalty], [ytd_sales], [notes], [published_date]) VALUES (N'4W2o9J4C0R', N'Fearless Governance', N'History', N'350       ', CAST(10.00 AS Decimal(10, 2)), CAST(5.00 AS Decimal(10, 2)), CAST(3.00 AS Decimal(10, 2)), 15, N'Revise disc prosth lumb', CAST(N'2022-04-15' AS Date))
INSERT [dbo].[Book] ([book_id], [title], [type], [pub_id], [price], [advance], [royalty], [ytd_sales], [notes], [published_date]) VALUES (N'4y0x9I3x5b', N'Tomb of Sand', N'Philosophy', N'337       ', CAST(10.00 AS Decimal(10, 2)), CAST(5.00 AS Decimal(10, 2)), CAST(3.00 AS Decimal(10, 2)), 12, N'Oth simple suture ovary', CAST(N'2022-10-24' AS Date))
INSERT [dbo].[Book] ([book_id], [title], [type], [pub_id], [price], [advance], [royalty], [ytd_sales], [notes], [published_date]) VALUES (N'4z4x1R2M9k', N'Queen of Fire', N'History', N'150       ', CAST(10.00 AS Decimal(10, 2)), CAST(5.00 AS Decimal(10, 2)), CAST(3.00 AS Decimal(10, 2)), 7, N'Attach pedicle graft NEC', CAST(N'2022-08-03' AS Date))
INSERT [dbo].[Book] ([book_id], [title], [type], [pub_id], [price], [advance], [royalty], [ytd_sales], [notes], [published_date]) VALUES (N'5F2w6u6n0e', N'The $10 Trillion Dream', N'Self help', N'365       ', CAST(10.00 AS Decimal(10, 2)), CAST(5.00 AS Decimal(10, 2)), CAST(3.00 AS Decimal(10, 2)), 19, N'Esoph fistula repair NEC', CAST(N'2023-01-19' AS Date))
INSERT [dbo].[Book] ([book_id], [title], [type], [pub_id], [price], [advance], [royalty], [ytd_sales], [notes], [published_date]) VALUES (N'5y6Q3G4a0K', N'The Christmas Pig', N'Prayer', N'118       ', CAST(10.00 AS Decimal(10, 2)), CAST(5.00 AS Decimal(10, 2)), CAST(3.00 AS Decimal(10, 2)), 26, N'Remov trunk device NEC', CAST(N'2022-04-27' AS Date))
INSERT [dbo].[Book] ([book_id], [title], [type], [pub_id], [price], [advance], [royalty], [ytd_sales], [notes], [published_date]) VALUES (N'6A4H1H367W', N'Yesterday''s Enemy', N'Autobiography', N'111       ', CAST(10.00 AS Decimal(10, 2)), CAST(5.00 AS Decimal(10, 2)), CAST(3.00 AS Decimal(10, 2)), 4, N'Magnet remov ant seg FB', CAST(N'2022-09-20' AS Date))
INSERT [dbo].[Book] ([book_id], [title], [type], [pub_id], [price], [advance], [royalty], [ytd_sales], [notes], [published_date]) VALUES (N'6I665D8d4k', N'ASOCA: A Sutra', N'Humor', N'178       ', CAST(10.00 AS Decimal(10, 2)), CAST(5.00 AS Decimal(10, 2)), CAST(3.00 AS Decimal(10, 2)), 24, N'Revision rhinoplasty', CAST(N'2022-05-03' AS Date))
INSERT [dbo].[Book] ([book_id], [title], [type], [pub_id], [price], [advance], [royalty], [ytd_sales], [notes], [published_date]) VALUES (N'6K5L1V9J9p', N'Operation Khatma', N'Religion', N'351       ', CAST(10.00 AS Decimal(10, 2)), CAST(5.00 AS Decimal(10, 2)), CAST(3.00 AS Decimal(10, 2)), 16, N'Repl tv atri-vent lead', CAST(N'2022-06-01' AS Date))
INSERT [dbo].[Book] ([book_id], [title], [type], [pub_id], [price], [advance], [royalty], [ytd_sales], [notes], [published_date]) VALUES (N'7R7G7q6X4A', N'Listen to Your Heart: The London Adventure', N'History', N'105       ', CAST(10.00 AS Decimal(10, 2)), CAST(5.00 AS Decimal(10, 2)), CAST(3.00 AS Decimal(10, 2)), 2, N'Endosc destruc anus les', CAST(N'2022-08-27' AS Date))
INSERT [dbo].[Book] ([book_id], [title], [type], [pub_id], [price], [advance], [royalty], [ytd_sales], [notes], [published_date]) VALUES (N'883k3M8K6w', N'Lal Salam', N'Journal', N'118       ', CAST(10.00 AS Decimal(10, 2)), CAST(5.00 AS Decimal(10, 2)), CAST(3.00 AS Decimal(10, 2)), 5, N'Abd region dx proc NEC', CAST(N'2022-06-26' AS Date))
INSERT [dbo].[Book] ([book_id], [title], [type], [pub_id], [price], [advance], [royalty], [ytd_sales], [notes], [published_date]) VALUES (N'8a2w2U524F', N'Golden Boy Neeraj Chopra', N'Autobiography', N'352       ', CAST(10.00 AS Decimal(10, 2)), CAST(5.00 AS Decimal(10, 2)), CAST(3.00 AS Decimal(10, 2)), 17, N'Excis external ear NEC', CAST(N'2022-04-12' AS Date))
INSERT [dbo].[Book] ([book_id], [title], [type], [pub_id], [price], [advance], [royalty], [ytd_sales], [notes], [published_date]) VALUES (N'8G760d1N7F', N'Mamata: Beyond 2021', N'Humor', N'364       ', CAST(10.00 AS Decimal(10, 2)), CAST(5.00 AS Decimal(10, 2)), CAST(3.00 AS Decimal(10, 2)), 18, N'Other fusion of foot', CAST(N'2022-04-12' AS Date))
INSERT [dbo].[Book] ([book_id], [title], [type], [pub_id], [price], [advance], [royalty], [ytd_sales], [notes], [published_date]) VALUES (N'8l2p4g9P6X', N'A Place Called Home', N'Memoir', N'107       ', CAST(10.00 AS Decimal(10, 2)), CAST(5.00 AS Decimal(10, 2)), CAST(3.00 AS Decimal(10, 2)), 3, N'Lap thorc app-diaph hern', CAST(N'2022-03-23' AS Date))
INSERT [dbo].[Book] ([book_id], [title], [type], [pub_id], [price], [advance], [royalty], [ytd_sales], [notes], [published_date]) VALUES (N'8p4z277a7c', N'Vahana Masterclass', N'Self help', N'368       ', CAST(10.00 AS Decimal(10, 2)), CAST(5.00 AS Decimal(10, 2)), CAST(3.00 AS Decimal(10, 2)), 20, N'Pterygium excision NEC', CAST(N'2023-01-22' AS Date))
INSERT [dbo].[Book] ([book_id], [title], [type], [pub_id], [price], [advance], [royalty], [ytd_sales], [notes], [published_date]) VALUES (N'8Y1U4Q4m1U', N'The Boy Who Wrote a Constitution', N'History', N'250       ', CAST(10.00 AS Decimal(10, 2)), CAST(5.00 AS Decimal(10, 2)), CAST(3.00 AS Decimal(10, 2)), 10, N'Retinal tear laser coag', CAST(N'2023-02-16' AS Date))
INSERT [dbo].[Book] ([book_id], [title], [type], [pub_id], [price], [advance], [royalty], [ytd_sales], [notes], [published_date]) VALUES (N'9G6I8Y0D9x', N'The Bench', N'Review', N'111       ', CAST(10.00 AS Decimal(10, 2)), CAST(5.00 AS Decimal(10, 2)), CAST(3.00 AS Decimal(10, 2)), 29, N'Oth perc proc bil trct', CAST(N'2022-10-15' AS Date))
INSERT [dbo].[Book] ([book_id], [title], [type], [pub_id], [price], [advance], [royalty], [ytd_sales], [notes], [published_date]) VALUES (N'9V0B3Z4c57', N'Ungalil Oruvan', N'Autobiography', N'319       ', CAST(10.00 AS Decimal(10, 2)), CAST(5.00 AS Decimal(10, 2)), CAST(3.00 AS Decimal(10, 2)), 11, N'Trnsplnt islets lang NOS', CAST(N'2022-08-24' AS Date))
INSERT [dbo].[Book] ([book_id], [title], [type], [pub_id], [price], [advance], [royalty], [ytd_sales], [notes], [published_date]) VALUES (N'9w0g591b6H', N'Hear Yourself', N'Self help', N'226       ', CAST(10.00 AS Decimal(10, 2)), CAST(5.00 AS Decimal(10, 2)), CAST(3.00 AS Decimal(10, 2)), 9, N'C & s-female genital', CAST(N'2022-04-29' AS Date))
GO
INSERT [dbo].[BookAuthor] ([author_id], [book_id], [author_order], [royality_percentage]) VALUES (N'0b4v5i1Y0Z', N'2V70323k7V', 10, 5)
INSERT [dbo].[BookAuthor] ([author_id], [book_id], [author_order], [royality_percentage]) VALUES (N'0L3Y1Y6o8j', N'5F2w6u6n0e', 10, 5)
INSERT [dbo].[BookAuthor] ([author_id], [book_id], [author_order], [royality_percentage]) VALUES (N'0N3u9Q756W', N'9w0g591b6H', 10, 5)
INSERT [dbo].[BookAuthor] ([author_id], [book_id], [author_order], [royality_percentage]) VALUES (N'0R0p4x8I1S', N'6A4H1H367W', 10, 5)
INSERT [dbo].[BookAuthor] ([author_id], [book_id], [author_order], [royality_percentage]) VALUES (N'0R0w8P9R65', N'883k3M8K6w', 10, 5)
INSERT [dbo].[BookAuthor] ([author_id], [book_id], [author_order], [royality_percentage]) VALUES (N'0X1X8j124N', N'8a2w2U524F', 10, 5)
INSERT [dbo].[BookAuthor] ([author_id], [book_id], [author_order], [royality_percentage]) VALUES (N'0X1X8j124N', N'9G6I8Y0D9x', 10, 5)
INSERT [dbo].[BookAuthor] ([author_id], [book_id], [author_order], [royality_percentage]) VALUES (N'1X3r458Y1S', N'492C4b2n5l', 10, 5)
INSERT [dbo].[BookAuthor] ([author_id], [book_id], [author_order], [royality_percentage]) VALUES (N'213L1a6x01', N'4y0x9I3x5b', 10, 5)
INSERT [dbo].[BookAuthor] ([author_id], [book_id], [author_order], [royality_percentage]) VALUES (N'261V5b5j0q', N'8p4z277a7c', 10, 5)
INSERT [dbo].[BookAuthor] ([author_id], [book_id], [author_order], [royality_percentage]) VALUES (N'2J6s7d8t4t', N'4D3i9e9Q7k', 10, 5)
INSERT [dbo].[BookAuthor] ([author_id], [book_id], [author_order], [royality_percentage]) VALUES (N'300E0t6d3W', N'2m9R6J5w13', 10, 5)
INSERT [dbo].[BookAuthor] ([author_id], [book_id], [author_order], [royality_percentage]) VALUES (N'3O6q5K3T7N', N'2N392d3J16', 10, 5)
INSERT [dbo].[BookAuthor] ([author_id], [book_id], [author_order], [royality_percentage]) VALUES (N'3Q2I4b6M2V', N'4W2o9J4C0R', 10, 5)
INSERT [dbo].[BookAuthor] ([author_id], [book_id], [author_order], [royality_percentage]) VALUES (N'4m9e047U5M', N'8Y1U4Q4m1U', 10, 5)
INSERT [dbo].[BookAuthor] ([author_id], [book_id], [author_order], [royality_percentage]) VALUES (N'5c5Y7X0B0o', N'9V0B3Z4c57', 10, 5)
INSERT [dbo].[BookAuthor] ([author_id], [book_id], [author_order], [royality_percentage]) VALUES (N'5V228e2w1H', N'6K5L1V9J9p', 10, 5)
INSERT [dbo].[BookAuthor] ([author_id], [book_id], [author_order], [royality_percentage]) VALUES (N'5x1d070Y3r', N'2Y3R4w1l2X', 10, 5)
INSERT [dbo].[BookAuthor] ([author_id], [book_id], [author_order], [royality_percentage]) VALUES (N'6G4t7B335T', N'40598O6v49', 10, 5)
INSERT [dbo].[BookAuthor] ([author_id], [book_id], [author_order], [royality_percentage]) VALUES (N'6w1t7d336B', N'6I665D8d4k', 10, 5)
INSERT [dbo].[BookAuthor] ([author_id], [book_id], [author_order], [royality_percentage]) VALUES (N'6w8k7P9Q6x', N'8G760d1N7F', 10, 5)
INSERT [dbo].[BookAuthor] ([author_id], [book_id], [author_order], [royality_percentage]) VALUES (N'732i4O4Q2C', N'4E5i1k5n3y', 10, 5)
INSERT [dbo].[BookAuthor] ([author_id], [book_id], [author_order], [royality_percentage]) VALUES (N'7a0X5N840h', N'7R7G7q6X4A', 10, 5)
INSERT [dbo].[BookAuthor] ([author_id], [book_id], [author_order], [royality_percentage]) VALUES (N'7c4l6M2E6g', N'4z4x1R2M9k', 10, 5)
INSERT [dbo].[BookAuthor] ([author_id], [book_id], [author_order], [royality_percentage]) VALUES (N'7F027I4H4i', N'8l2p4g9P6X', 10, 5)
INSERT [dbo].[BookAuthor] ([author_id], [book_id], [author_order], [royality_percentage]) VALUES (N'7k4O3J5L7r', N'1z7n6X0k1n', 10, 5)
INSERT [dbo].[BookAuthor] ([author_id], [book_id], [author_order], [royality_percentage]) VALUES (N'7k4O3J5L7r', N'5y6Q3G4a0K', 10, 5)
INSERT [dbo].[BookAuthor] ([author_id], [book_id], [author_order], [royality_percentage]) VALUES (N'7R2X6c2j6p', N'2l8Z5Z7K6E', 10, 5)
INSERT [dbo].[BookAuthor] ([author_id], [book_id], [author_order], [royality_percentage]) VALUES (N'8C8C8z5C5W', N'0b2I8b4z0e', 10, 5)
GO
INSERT [dbo].[Publisher] ([pub_id], [publisher_name], [city], [state], [country]) VALUES (N'101       ', N'Tundra Books', N'Evansville', N'Indiana', N'US')
INSERT [dbo].[Publisher] ([pub_id], [publisher_name], [city], [state], [country]) VALUES (N'105       ', N'Lulu.com', N'Paterson', N'New Jersey', N'US')
INSERT [dbo].[Publisher] ([pub_id], [publisher_name], [city], [state], [country]) VALUES (N'107       ', N'Cambridge University Press', N'Kansas City', N'Missouri', N'US')
INSERT [dbo].[Publisher] ([pub_id], [publisher_name], [city], [state], [country]) VALUES (N'111       ', N'Delmar', N'Denton', N'Texas', N'US')
INSERT [dbo].[Publisher] ([pub_id], [publisher_name], [city], [state], [country]) VALUES (N'118       ', N'For Dummies', N'Madison', N'Wisconsin', N'US')
INSERT [dbo].[Publisher] ([pub_id], [publisher_name], [city], [state], [country]) VALUES (N'138       ', N'Routledge', N'Syracuse', N'New York', N'US')
INSERT [dbo].[Publisher] ([pub_id], [publisher_name], [city], [state], [country]) VALUES (N'150       ', N'General Books', N'Saint Petersburg', N'Florida', N'US')
INSERT [dbo].[Publisher] ([pub_id], [publisher_name], [city], [state], [country]) VALUES (N'178       ', N'Verso', N'Augusta', N'Georgia', N'US')
INSERT [dbo].[Publisher] ([pub_id], [publisher_name], [city], [state], [country]) VALUES (N'226       ', N'"Chicago Press	"', N'Denver', N'Colorado', N'US')
INSERT [dbo].[Publisher] ([pub_id], [publisher_name], [city], [state], [country]) VALUES (N'250       ', N'St.Martin''s Press', N'Irvine', N'California', N'US')
INSERT [dbo].[Publisher] ([pub_id], [publisher_name], [city], [state], [country]) VALUES (N'319       ', N'MacMillan', N'Phoenix', N'Arizona', N'US')
INSERT [dbo].[Publisher] ([pub_id], [publisher_name], [city], [state], [country]) VALUES (N'337       ', N'Cengage', N'Chicago', N'Illinois', N'US')
INSERT [dbo].[Publisher] ([pub_id], [publisher_name], [city], [state], [country]) VALUES (N'338       ', N'Scholastic', N'Sunnyvale', N'California', N'US')
INSERT [dbo].[Publisher] ([pub_id], [publisher_name], [city], [state], [country]) VALUES (N'349       ', N'Springer Nature', N'Conroe', N'Texas', N'US')
INSERT [dbo].[Publisher] ([pub_id], [publisher_name], [city], [state], [country]) VALUES (N'350       ', N'Bloomsbury Academic', N'Wichita Falls', N'Texas', N'US')
INSERT [dbo].[Publisher] ([pub_id], [publisher_name], [city], [state], [country]) VALUES (N'351       ', N'Taylor & Francis', N'Troy', N'Michigan', N'US')
INSERT [dbo].[Publisher] ([pub_id], [publisher_name], [city], [state], [country]) VALUES (N'352       ', N'Nature', N'Philadelphia', N'Pennsylvania', N'US')
INSERT [dbo].[Publisher] ([pub_id], [publisher_name], [city], [state], [country]) VALUES (N'364       ', N'Blurb', N'Wilkes Barre', N'Pennsylvania', N'US')
INSERT [dbo].[Publisher] ([pub_id], [publisher_name], [city], [state], [country]) VALUES (N'365       ', N'Fc&c', N'Detroit', N'Michigan', N'US')
INSERT [dbo].[Publisher] ([pub_id], [publisher_name], [city], [state], [country]) VALUES (N'368       ', N'Disney', N'Sacramento', N'California', N'US')
INSERT [dbo].[Publisher] ([pub_id], [publisher_name], [city], [state], [country]) VALUES (N'386       ', N'Stark Publishing', N'Bridgeport', N'Connecticut', N'US')
INSERT [dbo].[Publisher] ([pub_id], [publisher_name], [city], [state], [country]) VALUES (N'389       ', N'FB&c', N'Washington', N'District of Columbia', N'US')
INSERT [dbo].[Publisher] ([pub_id], [publisher_name], [city], [state], [country]) VALUES (N'397       ', N'Linoel Obell', N'Manchester', N'New Hampshire', N'US')
GO
INSERT [dbo].[Role] ([role_id], [role_desc]) VALUES (0, N'admin')
INSERT [dbo].[Role] ([role_id], [role_desc]) VALUES (1, N'user')
GO
INSERT [dbo].[User] ([user_id], [email_address], [password], [source], [first_name], [middle_name], [last_name], [role_id], [pub_id], [hire_date]) VALUES (N'0F3D3C0H4N', N'igrovers@merriam-webster.com', N'1', NULL, N'Ivor', NULL, N'Grover', 1, N'397       ', CAST(N'2022-11-06' AS Date))
INSERT [dbo].[User] ([user_id], [email_address], [password], [source], [first_name], [middle_name], [last_name], [role_id], [pub_id], [hire_date]) VALUES (N'0i6q7T0i5e', N'sabbetsj@ted.com', N'1', NULL, N'Shelden', NULL, N'Abbets', 1, N'349       ', CAST(N'2021-03-31' AS Date))
INSERT [dbo].[User] ([user_id], [email_address], [password], [source], [first_name], [middle_name], [last_name], [role_id], [pub_id], [hire_date]) VALUES (N'2v659X2X2Q', N'gworledge7@hubpages.com', N'1', NULL, N'Geordie', NULL, N'Worledge', 1, N'111       ', CAST(N'2021-12-29' AS Date))
INSERT [dbo].[User] ([user_id], [email_address], [password], [source], [first_name], [middle_name], [last_name], [role_id], [pub_id], [hire_date]) VALUES (N'36262M9G4A', N'dstendalln@dagondesign.com', N'1', NULL, N'Denna', NULL, N'Stendall', 1, N'364       ', CAST(N'2022-11-08' AS Date))
INSERT [dbo].[User] ([user_id], [email_address], [password], [source], [first_name], [middle_name], [last_name], [role_id], [pub_id], [hire_date]) VALUES (N'3e326V2U7I', N'sholcrofto@whitehouse.gov', N'1', NULL, N'Sherwin', NULL, N'Holcroft', 1, N'365       ', CAST(N'2020-11-11' AS Date))
INSERT [dbo].[User] ([user_id], [email_address], [password], [source], [first_name], [middle_name], [last_name], [role_id], [pub_id], [hire_date]) VALUES (N'3M8U3F0E5M', N'nbanbrookd@prnewswire.com', N'1', NULL, N'Nadya', NULL, N'Banbrook', 1, N'178       ', CAST(N'2022-10-20' AS Date))
INSERT [dbo].[User] ([user_id], [email_address], [password], [source], [first_name], [middle_name], [last_name], [role_id], [pub_id], [hire_date]) VALUES (N'3T6s681e4l', N'ktoon5@gnu.org', N'1', NULL, N'Kleon', NULL, N'Toon', 1, N'107       ', CAST(N'2020-12-13' AS Date))
INSERT [dbo].[User] ([user_id], [email_address], [password], [source], [first_name], [middle_name], [last_name], [role_id], [pub_id], [hire_date]) VALUES (N'3Y6S1J1L9L', N'dmarkushkini@upenn.edu', N'1', NULL, N'Dusty', NULL, N'Markushkin', 1, N'338       ', CAST(N'2019-03-31' AS Date))
INSERT [dbo].[User] ([user_id], [email_address], [password], [source], [first_name], [middle_name], [last_name], [role_id], [pub_id], [hire_date]) VALUES (N'4C0y1f6o15', N'rmacdermottk@goo.ne.jp', N'1', NULL, N'Ric', NULL, N'MacDermott', 1, N'350       ', CAST(N'2022-01-06' AS Date))
INSERT [dbo].[User] ([user_id], [email_address], [password], [source], [first_name], [middle_name], [last_name], [role_id], [pub_id], [hire_date]) VALUES (N'4h3w268K2v', N'aasmusp@sciencedirect.com', N'1', NULL, N'Alameda', NULL, N'Asmus', 1, N'368       ', CAST(N'2021-09-27' AS Date))
INSERT [dbo].[User] ([user_id], [email_address], [password], [source], [first_name], [middle_name], [last_name], [role_id], [pub_id], [hire_date]) VALUES (N'4Y6X1C0d0F', N'mboyles3@pinterest.com', N'1', NULL, N'Marchall', NULL, N'Boyles', 1, N'105       ', CAST(N'2021-02-13' AS Date))
INSERT [dbo].[User] ([user_id], [email_address], [password], [source], [first_name], [middle_name], [last_name], [role_id], [pub_id], [hire_date]) VALUES (N'575o4H7f9L', N'ccartinq@quantcast.com', N'1', NULL, N'Cynthy', NULL, N'Cartin', 1, N'386       ', CAST(N'2022-10-01' AS Date))
INSERT [dbo].[User] ([user_id], [email_address], [password], [source], [first_name], [middle_name], [last_name], [role_id], [pub_id], [hire_date]) VALUES (N'5m8M6z3b5G', N'apedrazzil@icq.com', N'1', NULL, N'Ajay', NULL, N'Pedrazzi', 1, N'351       ', CAST(N'2022-11-06' AS Date))
INSERT [dbo].[User] ([user_id], [email_address], [password], [source], [first_name], [middle_name], [last_name], [role_id], [pub_id], [hire_date]) VALUES (N'5t1j6V794y', N'user@gmail.com', N'1', NULL, N'Maible', NULL, N'Spikings', 1, N'101       ', CAST(N'2019-11-05' AS Date))
INSERT [dbo].[User] ([user_id], [email_address], [password], [source], [first_name], [middle_name], [last_name], [role_id], [pub_id], [hire_date]) VALUES (N'5T8B7f2W8T', N'wtellwrightb@discuz.net', N'1', NULL, N'Waring', NULL, N'Tellwright', 1, N'138       ', CAST(N'2019-10-08' AS Date))
INSERT [dbo].[User] ([user_id], [email_address], [password], [source], [first_name], [middle_name], [last_name], [role_id], [pub_id], [hire_date]) VALUES (N'6H1G2V7K22', N'mwanderschek4@wikispaces.com', N'1', NULL, N'Mable', NULL, N'Wanderschek', 1, N'105       ', CAST(N'2018-02-13' AS Date))
INSERT [dbo].[User] ([user_id], [email_address], [password], [source], [first_name], [middle_name], [last_name], [role_id], [pub_id], [hire_date]) VALUES (N'6M8L3u794B', N'cpunshonm@cafepress.com', N'1', NULL, N'Charla', NULL, N'Punshon', 1, N'352       ', CAST(N'2021-04-25' AS Date))
INSERT [dbo].[User] ([user_id], [email_address], [password], [source], [first_name], [middle_name], [last_name], [role_id], [pub_id], [hire_date]) VALUES (N'6r2w3Y2A4U', N'vbrose1@unicef.org', N'1', NULL, N'Vinita', NULL, N'Brose', 1, N'101       ', CAST(N'2019-11-05' AS Date))
INSERT [dbo].[User] ([user_id], [email_address], [password], [source], [first_name], [middle_name], [last_name], [role_id], [pub_id], [hire_date]) VALUES (N'6W63006S5l', N'bsynec@biblegateway.com', N'1', NULL, N'Beverley', NULL, N'Syne', 1, N'150       ', CAST(N'2022-10-20' AS Date))
INSERT [dbo].[User] ([user_id], [email_address], [password], [source], [first_name], [middle_name], [last_name], [role_id], [pub_id], [hire_date]) VALUES (N'6w9O860o5l', N'semery9@craigslist.org', N'1', NULL, N'Selby', NULL, N'Emery', 1, N'118       ', CAST(N'2019-07-09' AS Date))
INSERT [dbo].[User] ([user_id], [email_address], [password], [source], [first_name], [middle_name], [last_name], [role_id], [pub_id], [hire_date]) VALUES (N'764X9D7v6N', N'mgregolina@hexun.com', N'1', NULL, N'Marthena', NULL, N'Gregolin', 1, N'138       ', CAST(N'2022-04-01' AS Date))
INSERT [dbo].[User] ([user_id], [email_address], [password], [source], [first_name], [middle_name], [last_name], [role_id], [pub_id], [hire_date]) VALUES (N'7C8H327s3Q', N'cpowner6@usgs.gov', N'1', NULL, N'Charmian', NULL, N'Powner', 1, N'107       ', CAST(N'2022-03-29' AS Date))
INSERT [dbo].[User] ([user_id], [email_address], [password], [source], [first_name], [middle_name], [last_name], [role_id], [pub_id], [hire_date]) VALUES (N'7y9J5g2U0H', N'ecoskerryr@gov.uk', N'1', NULL, N'Elane', NULL, N'Coskerry', 1, N'389       ', CAST(N'2021-12-08' AS Date))
INSERT [dbo].[User] ([user_id], [email_address], [password], [source], [first_name], [middle_name], [last_name], [role_id], [pub_id], [hire_date]) VALUES (N'806a1I7I7w', N'kmilmithf@google.de', N'1', NULL, N'Keven', NULL, N'Milmith', 1, N'250       ', CAST(N'2022-08-23' AS Date))
INSERT [dbo].[User] ([user_id], [email_address], [password], [source], [first_name], [middle_name], [last_name], [role_id], [pub_id], [hire_date]) VALUES (N'8E8o1R237X', N'kfarrah@jiathis.com', N'1', NULL, N'Krystle', NULL, N'Farra', 1, N'337       ', CAST(N'2019-08-11' AS Date))
INSERT [dbo].[User] ([user_id], [email_address], [password], [source], [first_name], [middle_name], [last_name], [role_id], [pub_id], [hire_date]) VALUES (N'8F8B5j3b7b', N'ptunnocke@eventbrite.com', N'1', NULL, N'Pearl', NULL, N'Tunnock', 1, N'226       ', CAST(N'2022-08-23' AS Date))
INSERT [dbo].[User] ([user_id], [email_address], [password], [source], [first_name], [middle_name], [last_name], [role_id], [pub_id], [hire_date]) VALUES (N'8w8T8Q4Z6B', N'bcall8@live.com', N'1', NULL, N'Brannon', NULL, N'Call', 1, N'111       ', CAST(N'2019-07-09' AS Date))
INSERT [dbo].[User] ([user_id], [email_address], [password], [source], [first_name], [middle_name], [last_name], [role_id], [pub_id], [hire_date]) VALUES (N'991b4z6V7f', N'kkerss2@mashable.com', N'1', NULL, N'Kitti', NULL, N'Kerss', 1, N'105       ', CAST(N'2021-02-13' AS Date))
INSERT [dbo].[User] ([user_id], [email_address], [password], [source], [first_name], [middle_name], [last_name], [role_id], [pub_id], [hire_date]) VALUES (N'9y2J7E1z5k', N'ewheatcroftg@fastcompany.com', N'1', NULL, N'Ellene', NULL, N'Wheatcroft', 1, N'319       ', CAST(N'2019-08-11' AS Date))
INSERT [dbo].[User] ([user_id], [email_address], [password], [source], [first_name], [middle_name], [last_name], [role_id], [pub_id], [hire_date]) VALUES (N'adminadmin', N'admin@gmail.com', N'1', NULL, N'Admin', NULL, N'Admin', 0, N'0         ', CAST(N'2022-08-12' AS Date))
GO
ALTER TABLE [dbo].[Book]  WITH NOCHECK ADD  CONSTRAINT [FK_Book_Publisher] FOREIGN KEY([pub_id])
REFERENCES [dbo].[Publisher] ([pub_id])
GO
ALTER TABLE [dbo].[Book] CHECK CONSTRAINT [FK_Book_Publisher]
GO
ALTER TABLE [dbo].[BookAuthor]  WITH NOCHECK ADD  CONSTRAINT [FK_BookAuthor_Author] FOREIGN KEY([author_id])
REFERENCES [dbo].[Author] ([author_id])
GO
ALTER TABLE [dbo].[BookAuthor] CHECK CONSTRAINT [FK_BookAuthor_Author]
GO
ALTER TABLE [dbo].[BookAuthor]  WITH NOCHECK ADD  CONSTRAINT [FK_BookAuthor_Book] FOREIGN KEY([book_id])
REFERENCES [dbo].[Book] ([book_id])
GO
ALTER TABLE [dbo].[BookAuthor] CHECK CONSTRAINT [FK_BookAuthor_Book]
GO
ALTER TABLE [dbo].[User]  WITH NOCHECK ADD  CONSTRAINT [FK_User_Publisher] FOREIGN KEY([pub_id])
REFERENCES [dbo].[Publisher] ([pub_id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Publisher]
GO
ALTER TABLE [dbo].[User]  WITH NOCHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([role_id])
REFERENCES [dbo].[Role] ([role_id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
GO
USE [master]
GO
ALTER DATABASE [AS2] SET  READ_WRITE 
GO
