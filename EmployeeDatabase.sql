USE [master]
GO
/****** Object:  Database [Employees]    Script Date: 4/09/2020 10:40:37 AM ******/
CREATE DATABASE [Employees]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Employees', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Employees.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Employees_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Employees_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Employees] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Employees].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Employees] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Employees] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Employees] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Employees] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Employees] SET ARITHABORT OFF 
GO
ALTER DATABASE [Employees] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Employees] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Employees] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Employees] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Employees] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Employees] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Employees] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Employees] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Employees] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Employees] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Employees] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Employees] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Employees] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Employees] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Employees] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Employees] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Employees] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Employees] SET RECOVERY FULL 
GO
ALTER DATABASE [Employees] SET  MULTI_USER 
GO
ALTER DATABASE [Employees] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Employees] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Employees] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Employees] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Employees] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Employees', N'ON'
GO
ALTER DATABASE [Employees] SET QUERY_STORE = OFF
GO
USE [Employees]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 4/09/2020 10:40:37 AM ******/
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
/****** Object:  Table [dbo].[EmployeesTable]    Script Date: 4/09/2020 10:40:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeesTable](
	[EmployeeId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[HourlyWage] [float] NOT NULL,
	[HireDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_EmployeesTable] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JobOrdersTable]    Script Date: 4/09/2020 10:40:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobOrdersTable](
	[JobOrdersId] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[ProjectId] [int] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[OrderDateTime] [datetime2](7) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [float] NOT NULL,
 CONSTRAINT [PK_JobOrdersTable] PRIMARY KEY CLUSTERED 
(
	[JobOrdersId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProjectEmployeesTable]    Script Date: 4/09/2020 10:40:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectEmployeesTable](
	[ProjectEmployeesId] [int] IDENTITY(1,1) NOT NULL,
	[ProjectId] [int] NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[Hours] [int] NOT NULL,
 CONSTRAINT [PK_ProjectEmployeesTable] PRIMARY KEY CLUSTERED 
(
	[ProjectEmployeesId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProjectsTable]    Script Date: 4/09/2020 10:40:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectsTable](
	[ProjectId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[StartDate] [datetime2](7) NOT NULL,
	[EndDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_ProjectsTable] PRIMARY KEY CLUSTERED 
(
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200901095642_InitialCreate', N'3.1.7')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200901100915_CorrectedProjectEmployeeTable', N'3.1.7')
GO
SET IDENTITY_INSERT [dbo].[EmployeesTable] ON 

INSERT [dbo].[EmployeesTable] ([EmployeeId], [FirstName], [LastName], [HourlyWage], [HireDate]) VALUES (1, N'Atul', N'Mukhija', 68, CAST(N'1999-08-02T00:12:00.0000000' AS DateTime2))
INSERT [dbo].[EmployeesTable] ([EmployeeId], [FirstName], [LastName], [HourlyWage], [HireDate]) VALUES (2, N'ROBIN ', N'SHARMA', 90, CAST(N'2000-05-02T12:34:00.0000000' AS DateTime2))
INSERT [dbo].[EmployeesTable] ([EmployeeId], [FirstName], [LastName], [HourlyWage], [HireDate]) VALUES (3, N'MILAD', N'KATEBI', 70, CAST(N'2002-08-31T16:55:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[EmployeesTable] OFF
GO
SET IDENTITY_INSERT [dbo].[JobOrdersTable] ON 

INSERT [dbo].[JobOrdersTable] ([JobOrdersId], [EmployeeId], [ProjectId], [Description], [OrderDateTime], [Quantity], [Price]) VALUES (1, 1, 1, N'DUMMY FLIGHT ROUTES', CAST(N'1999-10-02T01:01:00.0000000' AS DateTime2), 5, 15000)
INSERT [dbo].[JobOrdersTable] ([JobOrdersId], [EmployeeId], [ProjectId], [Description], [OrderDateTime], [Quantity], [Price]) VALUES (2, 2, 2, N'MAINTAINING SERVERS', CAST(N'2006-07-02T11:11:00.0000000' AS DateTime2), 2, 45000)
SET IDENTITY_INSERT [dbo].[JobOrdersTable] OFF
GO
SET IDENTITY_INSERT [dbo].[ProjectEmployeesTable] ON 

INSERT [dbo].[ProjectEmployeesTable] ([ProjectEmployeesId], [ProjectId], [EmployeeId], [Hours]) VALUES (1, 1, 1, 3500)
INSERT [dbo].[ProjectEmployeesTable] ([ProjectEmployeesId], [ProjectId], [EmployeeId], [Hours]) VALUES (2, 2, 3, 800)
INSERT [dbo].[ProjectEmployeesTable] ([ProjectEmployeesId], [ProjectId], [EmployeeId], [Hours]) VALUES (3, 2, 2, 1300)
SET IDENTITY_INSERT [dbo].[ProjectEmployeesTable] OFF
GO
SET IDENTITY_INSERT [dbo].[ProjectsTable] ON 

INSERT [dbo].[ProjectsTable] ([ProjectId], [Name], [StartDate], [EndDate]) VALUES (1, N'airline', CAST(N'1999-02-18T14:12:00.0000000' AS DateTime2), CAST(N'2010-02-22T15:34:00.0000000' AS DateTime2))
INSERT [dbo].[ProjectsTable] ([ProjectId], [Name], [StartDate], [EndDate]) VALUES (2, N'SERVER MAINTENANCE', CAST(N'2006-09-12T11:22:00.0000000' AS DateTime2), CAST(N'2011-07-08T14:54:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[ProjectsTable] OFF
GO
/****** Object:  Index [IX_JobOrdersTable_EmployeeId]    Script Date: 4/09/2020 10:40:42 AM ******/
CREATE NONCLUSTERED INDEX [IX_JobOrdersTable_EmployeeId] ON [dbo].[JobOrdersTable]
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_JobOrdersTable_ProjectId]    Script Date: 4/09/2020 10:40:42 AM ******/
CREATE NONCLUSTERED INDEX [IX_JobOrdersTable_ProjectId] ON [dbo].[JobOrdersTable]
(
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProjectEmployeesTable_EmployeeId]    Script Date: 4/09/2020 10:40:42 AM ******/
CREATE NONCLUSTERED INDEX [IX_ProjectEmployeesTable_EmployeeId] ON [dbo].[ProjectEmployeesTable]
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProjectEmployeesTable_ProjectId]    Script Date: 4/09/2020 10:40:42 AM ******/
CREATE NONCLUSTERED INDEX [IX_ProjectEmployeesTable_ProjectId] ON [dbo].[ProjectEmployeesTable]
(
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[JobOrdersTable]  WITH CHECK ADD  CONSTRAINT [FK_JobOrdersTable_EmployeesTable_EmployeeId] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[EmployeesTable] ([EmployeeId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[JobOrdersTable] CHECK CONSTRAINT [FK_JobOrdersTable_EmployeesTable_EmployeeId]
GO
ALTER TABLE [dbo].[JobOrdersTable]  WITH CHECK ADD  CONSTRAINT [FK_JobOrdersTable_ProjectsTable_ProjectId] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[ProjectsTable] ([ProjectId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[JobOrdersTable] CHECK CONSTRAINT [FK_JobOrdersTable_ProjectsTable_ProjectId]
GO
ALTER TABLE [dbo].[ProjectEmployeesTable]  WITH CHECK ADD  CONSTRAINT [FK_ProjectEmployeesTable_EmployeesTable_EmployeeId] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[EmployeesTable] ([EmployeeId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProjectEmployeesTable] CHECK CONSTRAINT [FK_ProjectEmployeesTable_EmployeesTable_EmployeeId]
GO
ALTER TABLE [dbo].[ProjectEmployeesTable]  WITH CHECK ADD  CONSTRAINT [FK_ProjectEmployeesTable_ProjectsTable_ProjectId] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[ProjectsTable] ([ProjectId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProjectEmployeesTable] CHECK CONSTRAINT [FK_ProjectEmployeesTable_ProjectsTable_ProjectId]
GO
USE [master]
GO
ALTER DATABASE [Employees] SET  READ_WRITE 
GO
