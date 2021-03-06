USE [master]
GO
/****** Object:  Database [AMMPSIDB]    Script Date: 11/06/2020 11:13:42 PM ******/
CREATE DATABASE [AMMPSIDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AMMPSIDB', FILENAME = N'C:\Users\Kevin\AMMPSIDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AMMPSIDB_log', FILENAME = N'C:\Users\Kevin\AMMPSIDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [AMMPSIDB] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AMMPSIDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AMMPSIDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AMMPSIDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AMMPSIDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AMMPSIDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AMMPSIDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [AMMPSIDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [AMMPSIDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AMMPSIDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AMMPSIDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AMMPSIDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AMMPSIDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AMMPSIDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AMMPSIDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AMMPSIDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AMMPSIDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [AMMPSIDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AMMPSIDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AMMPSIDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AMMPSIDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AMMPSIDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AMMPSIDB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [AMMPSIDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AMMPSIDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [AMMPSIDB] SET  MULTI_USER 
GO
ALTER DATABASE [AMMPSIDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AMMPSIDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AMMPSIDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AMMPSIDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [AMMPSIDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [AMMPSIDB] SET QUERY_STORE = OFF
GO
USE [AMMPSIDB]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [AMMPSIDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 11/06/2020 11:13:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 11/06/2020 11:13:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 11/06/2020 11:13:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 11/06/2020 11:13:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 11/06/2020 11:13:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 11/06/2020 11:13:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 11/06/2020 11:13:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[UserName] [nvarchar](256) NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 11/06/2020 11:13:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Asset]    Script Date: 11/06/2020 11:13:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Asset](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryID] [int] NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[DeletedBy] [nvarchar](max) NULL,
	[DeletedDate] [datetime2](7) NULL,
	[DepreciationDuration] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[IsMoveable] [bit] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[UpdatedBy] [nvarchar](max) NULL,
	[UpdatedDate] [datetime2](7) NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_Asset] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 11/06/2020 11:13:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[DeletedBy] [nvarchar](max) NULL,
	[DeletedDate] [datetime2](7) NULL,
	[Name] [nvarchar](max) NULL,
	[UpdatedBy] [nvarchar](max) NULL,
	[UpdatedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Location]    Script Date: 11/06/2020 11:13:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Location](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[DeletedBy] [nvarchar](max) NULL,
	[DeletedDate] [datetime2](7) NULL,
	[Description] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[UpdatedBy] [nvarchar](max) NULL,
	[UpdatedDate] [datetime2](7) NULL,
	[Floor] [nvarchar](max) NULL,
 CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movement]    Script Date: 11/06/2020 11:13:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movement](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ApprovedBy] [nvarchar](max) NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[DeletedBy] [nvarchar](max) NULL,
	[DeletedDate] [datetime2](7) NULL,
	[Description] [nvarchar](max) NULL,
	[LocationID] [int] NOT NULL,
	[MovementDate] [datetime2](7) NOT NULL,
	[Status] [nvarchar](max) NULL,
	[UpdatedBy] [nvarchar](max) NULL,
	[UpdatedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_Movement] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MovementItem]    Script Date: 11/06/2020 11:13:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MovementItem](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AssetID] [int] NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[DeletedBy] [nvarchar](max) NULL,
	[DeletedDate] [datetime2](7) NULL,
	[IsMoved] [bit] NOT NULL,
	[MovementID] [int] NOT NULL,
	[UpdatedBy] [nvarchar](max) NULL,
	[UpdatedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_MovementItem] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MovementLog]    Script Date: 11/06/2020 11:13:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MovementLog](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AssetID] [int] NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[DeletedBy] [nvarchar](max) NULL,
	[DeletedDate] [datetime2](7) NULL,
	[LocationID] [int] NOT NULL,
	[MovedBy] [nvarchar](max) NULL,
	[UpdatedBy] [nvarchar](max) NULL,
	[UpdatedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_MovementLog] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'00000000000000_CreateIdentitySchema', N'2.0.3-rtm-10026')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20181013083432_InitialMigration', N'2.0.3-rtm-10026')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20181111093317_AddFloorProp', N'2.0.3-rtm-10026')
INSERT [dbo].[AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName]) VALUES (N'1c24e78c-26d7-4e3f-9fe0-e98b484c77dd', N'ef8df0c9-be21-44fe-b2a4-604c74787a18', N'Admin', N'ADMIN')
INSERT [dbo].[AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName]) VALUES (N'4b9004bd-3a16-464a-aa8c-0ffe4e80c3ad', N'df9cfa16-ed61-47eb-8bb6-3858ceb4453a', N'Manager', N'MANAGER')
INSERT [dbo].[AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName]) VALUES (N'6741f292-a948-4429-a68f-3e0ca2c9a7c9', N'9c4d950d-4da4-4331-aa85-0e15900d229c', N'Employee', N'EMPLOYEE')
INSERT [dbo].[AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName]) VALUES (N'c1b6a09c-b09f-41b1-8da3-fb8b05c3b317', N'adb3e64b-7897-4f6e-9002-864955f7487c', N'Mover', N'MOVER')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'0b5c9b85-630d-4b33-b191-ed5b5571f561', N'4b9004bd-3a16-464a-aa8c-0ffe4e80c3ad')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'5e8b59e1-1b38-4840-959b-e533dd6def23', N'c1b6a09c-b09f-41b1-8da3-fb8b05c3b317')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'923c925a-9859-4cc9-8c2d-3de2bc9d56b4', N'1c24e78c-26d7-4e3f-9fe0-e98b484c77dd')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'c2a16e9b-ddeb-467e-b5fd-ecf2289b1477', N'6741f292-a948-4429-a68f-3e0ca2c9a7c9')
INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName]) VALUES (N'0b5c9b85-630d-4b33-b191-ed5b5571f561', 0, N'97ba998e-2ea1-42ae-9471-6fae24cd36fb', NULL, 0, 1, NULL, NULL, N'MANAGER', N'AQAAAAEAACcQAAAAEGLVO0j1/LucBKlcNS06ressRQVzi309LUPccQSyuc0itobjOfUKE2sLNnH61My6lQ==', NULL, 0, N'78f93daf-8322-4a64-b73d-90b78af6cbca', 0, N'manager')
INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName]) VALUES (N'5e8b59e1-1b38-4840-959b-e533dd6def23', 0, N'28202396-98de-4963-a092-b1c215a70c45', NULL, 0, 1, NULL, NULL, N'MOVER', N'AQAAAAEAACcQAAAAEPMJIullkF0PuNOHcV6hF22gZwVuKtKd56ENrn3KZjVMIfRyLHDrZFJl6HnyekZRaQ==', NULL, 0, N'77edea4b-41a4-4d7a-b3ed-cf094ae19415', 0, N'mover')
INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName]) VALUES (N'923c925a-9859-4cc9-8c2d-3de2bc9d56b4', 0, N'34b57b82-1227-4751-ab1d-af72b556be81', NULL, 0, 1, NULL, NULL, N'ADMIN', N'AQAAAAEAACcQAAAAEHxxD/RgE9RH3CL3x1k4lFTG8bcebvCRzORp7auxtwQc4JD7oREAHyS6T/Tnszf07A==', NULL, 0, N'1daedd2c-30cc-40a4-a1f6-984fd3052e70', 0, N'admin')
INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName]) VALUES (N'c2a16e9b-ddeb-467e-b5fd-ecf2289b1477', 0, N'fbfcfebe-6ae6-46a8-9491-29e965f040bf', NULL, 0, 1, NULL, NULL, N'EMPLOYEE', N'AQAAAAEAACcQAAAAEPEwhpCjgFCdGCKbkb9iJNh7RiVFTQD7jw+K2fazirBCh6ICOMDomi0L03Ffif9p7w==', NULL, 0, N'1097bf4a-2f4a-48e6-90ee-e659d751151b', 0, N'employee')
SET IDENTITY_INSERT [dbo].[Asset] ON 

INSERT [dbo].[Asset] ([ID], [CategoryID], [CreatedBy], [CreatedDate], [DeletedBy], [DeletedDate], [DepreciationDuration], [Description], [IsMoveable], [Name], [UpdatedBy], [UpdatedDate], [Value]) VALUES (1, 1, N'admin', CAST(N'2018-12-10T13:24:41.0378851' AS DateTime2), NULL, NULL, NULL, NULL, 1, N'Huawei NE20E ', N'admin', CAST(N'2018-12-10T13:26:32.2536232' AS DateTime2), N'100000')
INSERT [dbo].[Asset] ([ID], [CategoryID], [CreatedBy], [CreatedDate], [DeletedBy], [DeletedDate], [DepreciationDuration], [Description], [IsMoveable], [Name], [UpdatedBy], [UpdatedDate], [Value]) VALUES (2, 1, N'admin', CAST(N'2018-12-10T13:27:11.3221474' AS DateTime2), NULL, NULL, NULL, NULL, 1, N'Cisco Catalyst 3850', NULL, NULL, N'1249999')
INSERT [dbo].[Asset] ([ID], [CategoryID], [CreatedBy], [CreatedDate], [DeletedBy], [DeletedDate], [DepreciationDuration], [Description], [IsMoveable], [Name], [UpdatedBy], [UpdatedDate], [Value]) VALUES (3, 2, N'admin', CAST(N'2018-12-10T13:28:51.2411707' AS DateTime2), NULL, NULL, NULL, NULL, 1, N'Herman Miller Aeron 1', N'admin', CAST(N'2018-12-10T13:31:00.1816838' AS DateTime2), N'2500000')
INSERT [dbo].[Asset] ([ID], [CategoryID], [CreatedBy], [CreatedDate], [DeletedBy], [DeletedDate], [DepreciationDuration], [Description], [IsMoveable], [Name], [UpdatedBy], [UpdatedDate], [Value]) VALUES (1002, 2, N'admin', CAST(N'2018-12-10T13:58:22.9845513' AS DateTime2), NULL, NULL, NULL, NULL, 1, N'Ikea Swivel Chair', N'admin', CAST(N'2018-12-10T14:00:07.8133071' AS DateTime2), N'1500000')
INSERT [dbo].[Asset] ([ID], [CategoryID], [CreatedBy], [CreatedDate], [DeletedBy], [DeletedDate], [DepreciationDuration], [Description], [IsMoveable], [Name], [UpdatedBy], [UpdatedDate], [Value]) VALUES (1003, 4, N'admin', CAST(N'2018-12-10T14:38:31.9078892' AS DateTime2), NULL, NULL, NULL, NULL, 1, N'Dell Vostro 001', N'admin', CAST(N'2018-12-10T14:38:42.1243465' AS DateTime2), N'7500000')
INSERT [dbo].[Asset] ([ID], [CategoryID], [CreatedBy], [CreatedDate], [DeletedBy], [DeletedDate], [DepreciationDuration], [Description], [IsMoveable], [Name], [UpdatedBy], [UpdatedDate], [Value]) VALUES (1004, 4, N'admin', CAST(N'2018-12-10T14:42:07.6537198' AS DateTime2), NULL, NULL, NULL, NULL, 1, N'Dell Vostro 002', NULL, NULL, N'7500000')
SET IDENTITY_INSERT [dbo].[Asset] OFF
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([ID], [CreatedBy], [CreatedDate], [DeletedBy], [DeletedDate], [Name], [UpdatedBy], [UpdatedDate]) VALUES (1, N'admin', CAST(N'2018-12-10T12:57:28.2791401' AS DateTime2), NULL, NULL, N'Networking', NULL, NULL)
INSERT [dbo].[Category] ([ID], [CreatedBy], [CreatedDate], [DeletedBy], [DeletedDate], [Name], [UpdatedBy], [UpdatedDate]) VALUES (2, N'admin', CAST(N'2018-12-10T13:06:48.8212907' AS DateTime2), NULL, NULL, N'Office Furniture', N'admin', CAST(N'2018-12-10T13:17:47.3884191' AS DateTime2))
INSERT [dbo].[Category] ([ID], [CreatedBy], [CreatedDate], [DeletedBy], [DeletedDate], [Name], [UpdatedBy], [UpdatedDate]) VALUES (3, N'admin', CAST(N'2018-12-10T13:07:17.3625763' AS DateTime2), N'admin', CAST(N'2018-12-10T13:07:43.5529224' AS DateTime2), N'test', NULL, NULL)
INSERT [dbo].[Category] ([ID], [CreatedBy], [CreatedDate], [DeletedBy], [DeletedDate], [Name], [UpdatedBy], [UpdatedDate]) VALUES (4, N'admin', CAST(N'2018-12-10T13:27:28.0243738' AS DateTime2), NULL, NULL, N'Office Computer', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Category] OFF
SET IDENTITY_INSERT [dbo].[Location] ON 

INSERT [dbo].[Location] ([ID], [CreatedBy], [CreatedDate], [DeletedBy], [DeletedDate], [Description], [Name], [UpdatedBy], [UpdatedDate], [Floor]) VALUES (1, N'admin', CAST(N'2018-12-10T13:59:38.6440786' AS DateTime2), NULL, NULL, N'room where asset stored', N'Warehouse', NULL, NULL, N'1')
INSERT [dbo].[Location] ([ID], [CreatedBy], [CreatedDate], [DeletedBy], [DeletedDate], [Description], [Name], [UpdatedBy], [UpdatedDate], [Floor]) VALUES (2, N'admin', CAST(N'2018-12-10T14:18:26.4670324' AS DateTime2), NULL, NULL, NULL, N'Guest Room', NULL, NULL, N'1')
INSERT [dbo].[Location] ([ID], [CreatedBy], [CreatedDate], [DeletedBy], [DeletedDate], [Description], [Name], [UpdatedBy], [UpdatedDate], [Floor]) VALUES (3, N'admin', CAST(N'2018-12-10T14:18:37.5152650' AS DateTime2), NULL, NULL, NULL, N'Work Room', N'admin', CAST(N'2018-12-10T14:37:36.6085363' AS DateTime2), N'1')
SET IDENTITY_INSERT [dbo].[Location] OFF
SET IDENTITY_INSERT [dbo].[Movement] ON 

INSERT [dbo].[Movement] ([ID], [ApprovedBy], [CreatedBy], [CreatedDate], [DeletedBy], [DeletedDate], [Description], [LocationID], [MovementDate], [Status], [UpdatedBy], [UpdatedDate]) VALUES (1, N'admin', N'admin', CAST(N'2018-12-10T14:48:59.6859817' AS DateTime2), NULL, NULL, N'New Asset move to Warehouse', 1, CAST(N'2018-12-10T00:00:00.0000000' AS DateTime2), N'Done', NULL, CAST(N'2018-12-10T15:02:30.3882676' AS DateTime2))
INSERT [dbo].[Movement] ([ID], [ApprovedBy], [CreatedBy], [CreatedDate], [DeletedBy], [DeletedDate], [Description], [LocationID], [MovementDate], [Status], [UpdatedBy], [UpdatedDate]) VALUES (2, N'manager', N'manager', CAST(N'2018-12-10T15:22:28.3684567' AS DateTime2), NULL, NULL, NULL, 3, CAST(N'2018-12-11T00:00:00.0000000' AS DateTime2), N'Done', NULL, CAST(N'2018-12-10T15:23:20.1769156' AS DateTime2))
INSERT [dbo].[Movement] ([ID], [ApprovedBy], [CreatedBy], [CreatedDate], [DeletedBy], [DeletedDate], [Description], [LocationID], [MovementDate], [Status], [UpdatedBy], [UpdatedDate]) VALUES (1002, NULL, N'admin', CAST(N'2018-12-10T15:45:04.7414847' AS DateTime2), NULL, NULL, NULL, 2, CAST(N'2018-12-10T00:00:00.0000000' AS DateTime2), N'Reject', NULL, CAST(N'2018-12-10T15:45:14.9028972' AS DateTime2))
INSERT [dbo].[Movement] ([ID], [ApprovedBy], [CreatedBy], [CreatedDate], [DeletedBy], [DeletedDate], [Description], [LocationID], [MovementDate], [Status], [UpdatedBy], [UpdatedDate]) VALUES (2002, N'admin', N'admin', CAST(N'2018-12-10T20:21:41.1935345' AS DateTime2), NULL, NULL, NULL, 3, CAST(N'2018-12-12T00:00:00.0000000' AS DateTime2), N'Done', NULL, CAST(N'2018-12-10T20:22:46.0679896' AS DateTime2))
INSERT [dbo].[Movement] ([ID], [ApprovedBy], [CreatedBy], [CreatedDate], [DeletedBy], [DeletedDate], [Description], [LocationID], [MovementDate], [Status], [UpdatedBy], [UpdatedDate]) VALUES (2003, NULL, N'admin', CAST(N'2018-12-10T20:21:45.2421982' AS DateTime2), NULL, NULL, NULL, 3, CAST(N'2018-12-12T00:00:00.0000000' AS DateTime2), N'Order', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Movement] OFF
SET IDENTITY_INSERT [dbo].[MovementItem] ON 

INSERT [dbo].[MovementItem] ([ID], [AssetID], [CreatedBy], [CreatedDate], [DeletedBy], [DeletedDate], [IsMoved], [MovementID], [UpdatedBy], [UpdatedDate]) VALUES (1, 1, N'admin', CAST(N'2018-12-10T14:48:59.7037802' AS DateTime2), NULL, NULL, 1, 1, NULL, CAST(N'2018-12-10T15:07:54.6008618' AS DateTime2))
INSERT [dbo].[MovementItem] ([ID], [AssetID], [CreatedBy], [CreatedDate], [DeletedBy], [DeletedDate], [IsMoved], [MovementID], [UpdatedBy], [UpdatedDate]) VALUES (2, 2, N'admin', CAST(N'2018-12-10T14:48:59.7226144' AS DateTime2), NULL, NULL, 1, 1, NULL, CAST(N'2018-12-10T15:08:03.3455147' AS DateTime2))
INSERT [dbo].[MovementItem] ([ID], [AssetID], [CreatedBy], [CreatedDate], [DeletedBy], [DeletedDate], [IsMoved], [MovementID], [UpdatedBy], [UpdatedDate]) VALUES (3, 3, N'admin', CAST(N'2018-12-10T14:48:59.7227626' AS DateTime2), NULL, NULL, 1, 1, NULL, CAST(N'2018-12-10T15:08:03.3510458' AS DateTime2))
INSERT [dbo].[MovementItem] ([ID], [AssetID], [CreatedBy], [CreatedDate], [DeletedBy], [DeletedDate], [IsMoved], [MovementID], [UpdatedBy], [UpdatedDate]) VALUES (4, 1002, N'admin', CAST(N'2018-12-10T14:48:59.7228114' AS DateTime2), NULL, NULL, 1, 1, NULL, CAST(N'2018-12-10T15:08:03.3554117' AS DateTime2))
INSERT [dbo].[MovementItem] ([ID], [AssetID], [CreatedBy], [CreatedDate], [DeletedBy], [DeletedDate], [IsMoved], [MovementID], [UpdatedBy], [UpdatedDate]) VALUES (5, 1003, N'admin', CAST(N'2018-12-10T14:48:59.7228537' AS DateTime2), NULL, NULL, 1, 1, NULL, CAST(N'2018-12-10T15:08:03.3600803' AS DateTime2))
INSERT [dbo].[MovementItem] ([ID], [AssetID], [CreatedBy], [CreatedDate], [DeletedBy], [DeletedDate], [IsMoved], [MovementID], [UpdatedBy], [UpdatedDate]) VALUES (6, 1004, N'admin', CAST(N'2018-12-10T14:48:59.7228939' AS DateTime2), NULL, NULL, 1, 1, NULL, CAST(N'2018-12-10T15:08:03.3640858' AS DateTime2))
INSERT [dbo].[MovementItem] ([ID], [AssetID], [CreatedBy], [CreatedDate], [DeletedBy], [DeletedDate], [IsMoved], [MovementID], [UpdatedBy], [UpdatedDate]) VALUES (7, 1003, N'manager', CAST(N'2018-12-10T15:22:28.4017428' AS DateTime2), NULL, NULL, 1, 2, NULL, CAST(N'2018-12-10T15:24:33.5429527' AS DateTime2))
INSERT [dbo].[MovementItem] ([ID], [AssetID], [CreatedBy], [CreatedDate], [DeletedBy], [DeletedDate], [IsMoved], [MovementID], [UpdatedBy], [UpdatedDate]) VALUES (8, 1004, N'manager', CAST(N'2018-12-10T15:22:28.4196040' AS DateTime2), NULL, NULL, 1, 2, NULL, CAST(N'2018-12-10T15:24:57.6361057' AS DateTime2))
INSERT [dbo].[MovementItem] ([ID], [AssetID], [CreatedBy], [CreatedDate], [DeletedBy], [DeletedDate], [IsMoved], [MovementID], [UpdatedBy], [UpdatedDate]) VALUES (1007, 1, N'admin', CAST(N'2018-12-10T15:45:04.7601333' AS DateTime2), NULL, NULL, 0, 1002, NULL, NULL)
INSERT [dbo].[MovementItem] ([ID], [AssetID], [CreatedBy], [CreatedDate], [DeletedBy], [DeletedDate], [IsMoved], [MovementID], [UpdatedBy], [UpdatedDate]) VALUES (1008, 2, N'admin', CAST(N'2018-12-10T15:45:04.7662014' AS DateTime2), NULL, NULL, 0, 1002, NULL, NULL)
INSERT [dbo].[MovementItem] ([ID], [AssetID], [CreatedBy], [CreatedDate], [DeletedBy], [DeletedDate], [IsMoved], [MovementID], [UpdatedBy], [UpdatedDate]) VALUES (1009, 3, N'admin', CAST(N'2018-12-10T15:45:04.7671366' AS DateTime2), NULL, NULL, 0, 1002, NULL, NULL)
INSERT [dbo].[MovementItem] ([ID], [AssetID], [CreatedBy], [CreatedDate], [DeletedBy], [DeletedDate], [IsMoved], [MovementID], [UpdatedBy], [UpdatedDate]) VALUES (1010, 1002, N'admin', CAST(N'2018-12-10T15:45:04.7672159' AS DateTime2), NULL, NULL, 0, 1002, NULL, NULL)
INSERT [dbo].[MovementItem] ([ID], [AssetID], [CreatedBy], [CreatedDate], [DeletedBy], [DeletedDate], [IsMoved], [MovementID], [UpdatedBy], [UpdatedDate]) VALUES (1011, 1003, N'admin', CAST(N'2018-12-10T15:45:04.7673173' AS DateTime2), NULL, NULL, 0, 1002, NULL, NULL)
INSERT [dbo].[MovementItem] ([ID], [AssetID], [CreatedBy], [CreatedDate], [DeletedBy], [DeletedDate], [IsMoved], [MovementID], [UpdatedBy], [UpdatedDate]) VALUES (1012, 1004, N'admin', CAST(N'2018-12-10T15:45:04.7673768' AS DateTime2), NULL, NULL, 0, 1002, NULL, NULL)
INSERT [dbo].[MovementItem] ([ID], [AssetID], [CreatedBy], [CreatedDate], [DeletedBy], [DeletedDate], [IsMoved], [MovementID], [UpdatedBy], [UpdatedDate]) VALUES (2007, 1, N'admin', CAST(N'2018-12-10T20:21:41.2133725' AS DateTime2), NULL, NULL, 1, 2002, NULL, CAST(N'2018-12-10T20:23:27.4061416' AS DateTime2))
INSERT [dbo].[MovementItem] ([ID], [AssetID], [CreatedBy], [CreatedDate], [DeletedBy], [DeletedDate], [IsMoved], [MovementID], [UpdatedBy], [UpdatedDate]) VALUES (2008, 2, N'admin', CAST(N'2018-12-10T20:21:41.2175099' AS DateTime2), NULL, NULL, 1, 2002, NULL, CAST(N'2018-12-10T20:23:27.4352611' AS DateTime2))
INSERT [dbo].[MovementItem] ([ID], [AssetID], [CreatedBy], [CreatedDate], [DeletedBy], [DeletedDate], [IsMoved], [MovementID], [UpdatedBy], [UpdatedDate]) VALUES (2009, 1, N'admin', CAST(N'2018-12-10T20:21:45.2432426' AS DateTime2), NULL, NULL, 0, 2003, NULL, NULL)
INSERT [dbo].[MovementItem] ([ID], [AssetID], [CreatedBy], [CreatedDate], [DeletedBy], [DeletedDate], [IsMoved], [MovementID], [UpdatedBy], [UpdatedDate]) VALUES (2010, 2, N'admin', CAST(N'2018-12-10T20:21:45.2434372' AS DateTime2), NULL, NULL, 0, 2003, NULL, NULL)
SET IDENTITY_INSERT [dbo].[MovementItem] OFF
SET IDENTITY_INSERT [dbo].[MovementLog] ON 

INSERT [dbo].[MovementLog] ([ID], [AssetID], [CreatedBy], [CreatedDate], [DeletedBy], [DeletedDate], [LocationID], [MovedBy], [UpdatedBy], [UpdatedDate]) VALUES (1, 1, N'admin', CAST(N'2018-12-10T15:07:54.6116661' AS DateTime2), NULL, NULL, 1, N'admin', NULL, NULL)
INSERT [dbo].[MovementLog] ([ID], [AssetID], [CreatedBy], [CreatedDate], [DeletedBy], [DeletedDate], [LocationID], [MovedBy], [UpdatedBy], [UpdatedDate]) VALUES (2, 2, N'admin', CAST(N'2018-12-10T15:08:03.3458177' AS DateTime2), NULL, NULL, 1, N'admin', NULL, NULL)
INSERT [dbo].[MovementLog] ([ID], [AssetID], [CreatedBy], [CreatedDate], [DeletedBy], [DeletedDate], [LocationID], [MovedBy], [UpdatedBy], [UpdatedDate]) VALUES (3, 3, N'admin', CAST(N'2018-12-10T15:08:03.3513167' AS DateTime2), NULL, NULL, 1, N'admin', NULL, NULL)
INSERT [dbo].[MovementLog] ([ID], [AssetID], [CreatedBy], [CreatedDate], [DeletedBy], [DeletedDate], [LocationID], [MovedBy], [UpdatedBy], [UpdatedDate]) VALUES (4, 1002, N'admin', CAST(N'2018-12-10T15:08:03.3557056' AS DateTime2), NULL, NULL, 1, N'admin', NULL, NULL)
INSERT [dbo].[MovementLog] ([ID], [AssetID], [CreatedBy], [CreatedDate], [DeletedBy], [DeletedDate], [LocationID], [MovedBy], [UpdatedBy], [UpdatedDate]) VALUES (5, 1003, N'admin', CAST(N'2018-12-10T15:08:03.3605857' AS DateTime2), NULL, NULL, 1, N'admin', NULL, NULL)
INSERT [dbo].[MovementLog] ([ID], [AssetID], [CreatedBy], [CreatedDate], [DeletedBy], [DeletedDate], [LocationID], [MovedBy], [UpdatedBy], [UpdatedDate]) VALUES (6, 1004, N'admin', CAST(N'2018-12-10T15:08:03.3645000' AS DateTime2), NULL, NULL, 1, N'admin', NULL, NULL)
INSERT [dbo].[MovementLog] ([ID], [AssetID], [CreatedBy], [CreatedDate], [DeletedBy], [DeletedDate], [LocationID], [MovedBy], [UpdatedBy], [UpdatedDate]) VALUES (7, 1003, N'manager', CAST(N'2018-12-10T15:24:33.5438271' AS DateTime2), NULL, NULL, 3, N'manager', NULL, NULL)
INSERT [dbo].[MovementLog] ([ID], [AssetID], [CreatedBy], [CreatedDate], [DeletedBy], [DeletedDate], [LocationID], [MovedBy], [UpdatedBy], [UpdatedDate]) VALUES (8, 1004, N'manager', CAST(N'2018-12-10T15:24:57.6362938' AS DateTime2), NULL, NULL, 3, N'manager', NULL, NULL)
INSERT [dbo].[MovementLog] ([ID], [AssetID], [CreatedBy], [CreatedDate], [DeletedBy], [DeletedDate], [LocationID], [MovedBy], [UpdatedBy], [UpdatedDate]) VALUES (1007, 1, N'admin', CAST(N'2018-12-10T20:23:27.4068259' AS DateTime2), NULL, NULL, 3, N'admin', NULL, NULL)
INSERT [dbo].[MovementLog] ([ID], [AssetID], [CreatedBy], [CreatedDate], [DeletedBy], [DeletedDate], [LocationID], [MovedBy], [UpdatedBy], [UpdatedDate]) VALUES (1008, 2, N'admin', CAST(N'2018-12-10T20:23:27.4355296' AS DateTime2), NULL, NULL, 3, N'admin', NULL, NULL)
SET IDENTITY_INSERT [dbo].[MovementLog] OFF
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 11/06/2020 11:13:44 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 11/06/2020 11:13:44 PM ******/
CREATE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 11/06/2020 11:13:44 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 11/06/2020 11:13:44 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 11/06/2020 11:13:44 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_UserId]    Script Date: 11/06/2020 11:13:44 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_UserId] ON [dbo].[AspNetUserRoles]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 11/06/2020 11:13:44 PM ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 11/06/2020 11:13:44 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Asset_CategoryID]    Script Date: 11/06/2020 11:13:44 PM ******/
CREATE NONCLUSTERED INDEX [IX_Asset_CategoryID] ON [dbo].[Asset]
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Movement_LocationID]    Script Date: 11/06/2020 11:13:44 PM ******/
CREATE NONCLUSTERED INDEX [IX_Movement_LocationID] ON [dbo].[Movement]
(
	[LocationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_MovementItem_AssetID]    Script Date: 11/06/2020 11:13:44 PM ******/
CREATE NONCLUSTERED INDEX [IX_MovementItem_AssetID] ON [dbo].[MovementItem]
(
	[AssetID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_MovementItem_MovementID]    Script Date: 11/06/2020 11:13:44 PM ******/
CREATE NONCLUSTERED INDEX [IX_MovementItem_MovementID] ON [dbo].[MovementItem]
(
	[MovementID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_MovementLog_AssetID]    Script Date: 11/06/2020 11:13:44 PM ******/
CREATE NONCLUSTERED INDEX [IX_MovementLog_AssetID] ON [dbo].[MovementLog]
(
	[AssetID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_MovementLog_LocationID]    Script Date: 11/06/2020 11:13:44 PM ******/
CREATE NONCLUSTERED INDEX [IX_MovementLog_LocationID] ON [dbo].[MovementLog]
(
	[LocationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Asset]  WITH CHECK ADD  CONSTRAINT [FK_Asset_Category_CategoryID] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Asset] CHECK CONSTRAINT [FK_Asset_Category_CategoryID]
GO
ALTER TABLE [dbo].[Movement]  WITH CHECK ADD  CONSTRAINT [FK_Movement_Location_LocationID] FOREIGN KEY([LocationID])
REFERENCES [dbo].[Location] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Movement] CHECK CONSTRAINT [FK_Movement_Location_LocationID]
GO
ALTER TABLE [dbo].[MovementItem]  WITH CHECK ADD  CONSTRAINT [FK_MovementItem_Asset_AssetID] FOREIGN KEY([AssetID])
REFERENCES [dbo].[Asset] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MovementItem] CHECK CONSTRAINT [FK_MovementItem_Asset_AssetID]
GO
ALTER TABLE [dbo].[MovementItem]  WITH CHECK ADD  CONSTRAINT [FK_MovementItem_Movement_MovementID] FOREIGN KEY([MovementID])
REFERENCES [dbo].[Movement] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MovementItem] CHECK CONSTRAINT [FK_MovementItem_Movement_MovementID]
GO
ALTER TABLE [dbo].[MovementLog]  WITH CHECK ADD  CONSTRAINT [FK_MovementLog_Asset_AssetID] FOREIGN KEY([AssetID])
REFERENCES [dbo].[Asset] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MovementLog] CHECK CONSTRAINT [FK_MovementLog_Asset_AssetID]
GO
ALTER TABLE [dbo].[MovementLog]  WITH CHECK ADD  CONSTRAINT [FK_MovementLog_Location_LocationID] FOREIGN KEY([LocationID])
REFERENCES [dbo].[Location] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MovementLog] CHECK CONSTRAINT [FK_MovementLog_Location_LocationID]
GO
USE [master]
GO
ALTER DATABASE [AMMPSIDB] SET  READ_WRITE 
GO
