USE [master]
GO

/****** Object:  Database [SpectreDB]    Script Date: 16/10/2018 14:06:43 ******/
CREATE DATABASE [SpectreDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SpectreDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\SpectreDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SpectreDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\SpectreDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO

ALTER DATABASE [SpectreDB] SET COMPATIBILITY_LEVEL = 130
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SpectreDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [SpectreDB] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [SpectreDB] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [SpectreDB] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [SpectreDB] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [SpectreDB] SET ARITHABORT OFF 
GO

ALTER DATABASE [SpectreDB] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [SpectreDB] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [SpectreDB] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [SpectreDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [SpectreDB] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [SpectreDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [SpectreDB] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [SpectreDB] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [SpectreDB] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [SpectreDB] SET  ENABLE_BROKER 
GO

ALTER DATABASE [SpectreDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [SpectreDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [SpectreDB] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [SpectreDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [SpectreDB] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [SpectreDB] SET READ_COMMITTED_SNAPSHOT ON 
GO

ALTER DATABASE [SpectreDB] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [SpectreDB] SET RECOVERY FULL 
GO

ALTER DATABASE [SpectreDB] SET  MULTI_USER 
GO

ALTER DATABASE [SpectreDB] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [SpectreDB] SET DB_CHAINING OFF 
GO

ALTER DATABASE [SpectreDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [SpectreDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [SpectreDB] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [SpectreDB] SET QUERY_STORE = OFF
GO

USE [SpectreDB]
GO

ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO

ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO

ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO

ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO

ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO

ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO

ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO

ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO

ALTER DATABASE [SpectreDB] SET  READ_WRITE 
GO



USE [SpectreDB]
GO
/****** Object:  Table [dbo].[APICallLog]    Script Date: 16/10/2018 14:06:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[APICallLog](
	[PK] [bigint] IDENTITY(1,1) NOT NULL,
	[EndPoint] [nvarchar](250) NOT NULL,
	[RequestBody] [nvarchar](max) NULL,
	[ResponseCode] [nvarchar](50) NOT NULL,
	[ResponseBody] [nvarchar](max) NULL,
	[InvokationTimeStamp] [datetime] NOT NULL,
	[ResponseTimestamp] [datetime] NOT NULL,
 CONSTRAINT [PK_APICallLog] PRIMARY KEY CLUSTERED 
(
	[PK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AppUser]    Script Date: 16/10/2018 14:06:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppUser](
	[Id] [nvarchar](128) NOT NULL,
	[FirstName] [nvarchar](25) NOT NULL,
	[LastName] [nvarchar](25) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[Country] [nvarchar](25) NOT NULL,
	[IsBlocked] [bit] NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AppUser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AppUserHistory]    Script Date: 16/10/2018 14:06:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppUserHistory](
	[HistPK] [bigint] IDENTITY(1,1) NOT NULL,
	[Id] [nvarchar](128) NOT NULL,
	[FirstName] [nvarchar](25) NOT NULL,
	[LastName] [nvarchar](25) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[Country] [nvarchar](25) NOT NULL,
	[IsBlocked] [bit] NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
	[UpdatedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.AppUserHistory] PRIMARY KEY CLUSTERED 
(
	[HistPK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AppUserTransaction]    Script Date: 16/10/2018 14:06:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppUserTransaction](
	[PK] [bigint] IDENTITY(1,1) NOT NULL,
	[TransactionDate] [datetime] NOT NULL,
	[Amount] [int] NOT NULL,
	[AppUser_FK] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AppUserTransaction] PRIMARY KEY CLUSTERED 
(
	[PK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AppUserTransactionHistory]    Script Date: 16/10/2018 14:06:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppUserTransactionHistory](
	[HistPK] [bigint] IDENTITY(1,1) NOT NULL,
	[PK] [bigint] NOT NULL,
	[TransactionDate] [datetime] NOT NULL,
	[Amount] [int] NOT NULL,
	[AppUser_FK] [nvarchar](128) NOT NULL,
	[UpdatedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.AppUserTransactionHistory] PRIMARY KEY CLUSTERED 
(
	[HistPK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 16/10/2018 14:06:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 16/10/2018 14:06:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Logs]    Script Date: 16/10/2018 14:06:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Logs](
	[PK] [bigint] IDENTITY(1,1) NOT NULL,
	[Table_PK] [nvarchar](128) NOT NULL,
	[Table_Name] [nvarchar](50) NOT NULL,
	[LogType] [char](1) NOT NULL,
	[Timestamp] [datetime] NOT NULL,
 CONSTRAINT [PK_Logs] PRIMARY KEY CLUSTERED 
(
	[PK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserClaim]    Script Date: 16/10/2018 14:06:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserClaim](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.UserClaim] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserLogin]    Script Date: 16/10/2018 14:06:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserLogin](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.UserLogin] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UserNameIndex]    Script Date: 16/10/2018 14:06:28 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AppUser]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_AppUser_FK]    Script Date: 16/10/2018 14:06:28 ******/
CREATE NONCLUSTERED INDEX [IX_AppUser_FK] ON [dbo].[AppUserTransaction]
(
	[AppUser_FK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [RoleNameIndex]    Script Date: 16/10/2018 14:06:28 ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_RoleId]    Script Date: 16/10/2018 14:06:28 ******/
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 16/10/2018 14:06:28 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserRoles]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 16/10/2018 14:06:28 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[UserClaim]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 16/10/2018 14:06:28 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[UserLogin]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AppUserTransaction]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AppUserTransaction_dbo.AppUser_AppUser_FK] FOREIGN KEY([AppUser_FK])
REFERENCES [dbo].[AppUser] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AppUserTransaction] CHECK CONSTRAINT [FK_dbo.AppUserTransaction_dbo.AppUser_AppUser_FK]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AppUser_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AppUser] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AppUser_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[UserClaim]  WITH CHECK ADD  CONSTRAINT [FK_dbo.UserClaim_dbo.AppUser_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AppUser] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserClaim] CHECK CONSTRAINT [FK_dbo.UserClaim_dbo.AppUser_UserId]
GO
ALTER TABLE [dbo].[UserLogin]  WITH CHECK ADD  CONSTRAINT [FK_dbo.UserLogin_dbo.AppUser_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AppUser] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserLogin] CHECK CONSTRAINT [FK_dbo.UserLogin_dbo.AppUser_UserId]
GO
/****** Object:  StoredProcedure [dbo].[LogAPICall]    Script Date: 16/10/2018 14:06:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[LogAPICall]
(
@endPoint nvarchar(250),
@requestBody nvarchar(MAX),
@responseCode nvarchar(20),
@responseBody nvarchar(MAX),
@invokationTimeStamp datetime,
@responseTimeStamp datetime
)
AS

	INSERT INTO [dbo].[APICallLog]
           ([EndPoint], [RequestBody], [ResponseCode], [ResponseBody], [InvokationTimeStamp], [ResponseTimestamp])
     VALUES
           (@endPoint, @requestBody, @responseCode, @responseBody, @invokationTimeStamp, @responseTimeStamp)

GO
/****** Object:  Trigger [dbo].[AppUserDelTrig]    Script Date: 16/10/2018 14:06:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Trigger [dbo].[AppUserDelTrig] on [dbo].[AppUser]
after delete
as 
begin

insert into dbo.Logs
(Table_PK, Table_Name, LogType, Timestamp)
select del.Id, 'AppUser', 'D', GETDATE() from deleted del
end



GO
ALTER TABLE [dbo].[AppUser] ENABLE TRIGGER [AppUserDelTrig]
GO
/****** Object:  Trigger [dbo].[AppUserInsTrig]    Script Date: 16/10/2018 14:06:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE Trigger [dbo].[AppUserInsTrig] on [dbo].[AppUser]
after insert
as 
begin

insert into dbo.Logs
(Table_PK, Table_Name, LogType, Timestamp)
select ins.Id, 'AppUser', 'I', GETDATE() from inserted ins;
end



GO
ALTER TABLE [dbo].[AppUser] ENABLE TRIGGER [AppUserInsTrig]
GO
/****** Object:  Trigger [dbo].[AppUserUpdTrig]    Script Date: 16/10/2018 14:06:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Trigger [dbo].[AppUserUpdTrig] on [dbo].[AppUser]
after Update
as 
begin

insert into dbo.AppUserHistory
([Id], [FirstName], [LastName], [Address], [Country], [IsBlocked], [Email], [EmailConfirmed], [PasswordHash],
[SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled],
[AccessFailedCount], [UserName], [UpdatedOn])
select del.[Id], del.[FirstName], del.[LastName], del.[Address], del.[Country], del.[IsBlocked], del.[Email], 
       del.[EmailConfirmed], del.[PasswordHash], del.[SecurityStamp], del.[PhoneNumber], del.[PhoneNumberConfirmed], 
	   del.[TwoFactorEnabled], del.[LockoutEndDateUtc], del.[LockoutEnabled], del.[AccessFailedCount], del.[UserName], 
	   GETDATE() from deleted del;
end



GO
ALTER TABLE [dbo].[AppUser] ENABLE TRIGGER [AppUserUpdTrig]
GO
/****** Object:  Trigger [dbo].[AppUserTransDelTrig]    Script Date: 16/10/2018 14:06:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Trigger [dbo].[AppUserTransDelTrig] on [dbo].[AppUserTransaction]
after delete
as 
begin

insert into dbo.Logs
(Table_PK, Table_Name, LogType, Timestamp)
select del.PK, 'AppUserTransaction', 'D', GETDATE() from deleted del
end



GO
ALTER TABLE [dbo].[AppUserTransaction] ENABLE TRIGGER [AppUserTransDelTrig]
GO
/****** Object:  Trigger [dbo].[AppUserTransInsTrig]    Script Date: 16/10/2018 14:06:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE Trigger [dbo].[AppUserTransInsTrig] on [dbo].[AppUserTransaction]
after insert
as 
begin

insert into dbo.Logs
(Table_PK, Table_Name, LogType, Timestamp)
select ins.PK, 'AppUserTransaction', 'I', GETDATE() from inserted ins
end



GO
ALTER TABLE [dbo].[AppUserTransaction] ENABLE TRIGGER [AppUserTransInsTrig]
GO
/****** Object:  Trigger [dbo].[AppUserTransUpdTrig]    Script Date: 16/10/2018 14:06:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Trigger [dbo].[AppUserTransUpdTrig] on [dbo].[AppUserTransaction]
after Update
as 
begin

insert into dbo.AppUserTransactionHistory
([PK], [TransactionDate], [Amount], [AppUser_FK], [UpdatedOn])
select del.[PK], del.[TransactionDate], del.[Amount], del.[AppUser_FK],
	   GETDATE() from deleted del;
end



GO
ALTER TABLE [dbo].[AppUserTransaction] ENABLE TRIGGER [AppUserTransUpdTrig]
GO
/****** Object:  Trigger [dbo].[CheckUserBalance]    Script Date: 16/10/2018 14:06:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[CheckUserBalance] ON [dbo].[AppUserTransaction]
AFTER INSERT
AS
DECLARE @balance decimal(18,2)
SELECT @balance = ISNULL(SUM(aut.Amount), 0)
FROM [dbo].[AppUserTransaction] AS aut
	 INNER JOIN inserted AS i  ON aut.AppUser_FK = i.AppUser_FK 

IF (@balance < 0)       
	BEGIN
	RAISERROR ('Balance cannot be negtive.', 16, 1);
	ROLLBACK TRANSACTION;
	RETURN 
END;

GO
ALTER TABLE [dbo].[AppUserTransaction] ENABLE TRIGGER [CheckUserBalance]
GO
