/*    ==Scripting Parameters==

    Source Server Version : SQL Server 2016 (13.0.4001)
    Source Database Engine Edition : Microsoft SQL Server Express Edition
    Source Database Engine Type : Standalone SQL Server

    Target Server Version : SQL Server 2017
    Target Database Engine Edition : Microsoft SQL Server Standard Edition
    Target Database Engine Type : Standalone SQL Server
*/
USE [master]
GO
/****** Object:  Database [LibraryDb]    Script Date: 2018-12-20 11:15:21 AM ******/
CREATE DATABASE [LibraryDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LibraryDb', FILENAME = N'C:\Users\happy\LibraryDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'LibraryDb_log', FILENAME = N'C:\Users\happy\LibraryDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [LibraryDb] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LibraryDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LibraryDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LibraryDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LibraryDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LibraryDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LibraryDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [LibraryDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [LibraryDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LibraryDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LibraryDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LibraryDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LibraryDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LibraryDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LibraryDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LibraryDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LibraryDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [LibraryDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LibraryDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LibraryDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LibraryDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LibraryDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LibraryDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [LibraryDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LibraryDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [LibraryDb] SET  MULTI_USER 
GO
ALTER DATABASE [LibraryDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LibraryDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LibraryDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LibraryDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [LibraryDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [LibraryDb] SET QUERY_STORE = OFF
GO
USE [LibraryDb]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [LibraryDb]
GO
/****** Object:  Table [dbo].[Author]    Script Date: 2018-12-20 11:15:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Author](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Author] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Book]    Script Date: 2018-12-20 11:15:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NULL,
	[Genre] [nvarchar](50) NULL,
	[LibraryId] [int] NULL,
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookWrittenByAuthor]    Script Date: 2018-12-20 11:15:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookWrittenByAuthor](
	[BookId] [int] NOT NULL,
	[AuthorId] [int] NOT NULL,
 CONSTRAINT [PK_BookWrittenByAuthor] PRIMARY KEY CLUSTERED 
(
	[BookId] ASC,
	[AuthorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Library]    Script Date: 2018-12-20 11:15:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Library](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Library] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD  CONSTRAINT [FK_Book_Library] FOREIGN KEY([LibraryId])
REFERENCES [dbo].[Library] ([Id])
GO
ALTER TABLE [dbo].[Book] CHECK CONSTRAINT [FK_Book_Library]
GO
ALTER TABLE [dbo].[BookWrittenByAuthor]  WITH CHECK ADD  CONSTRAINT [FK_BookWrittenByAuthor_Author] FOREIGN KEY([AuthorId])
REFERENCES [dbo].[Author] ([Id])
GO
ALTER TABLE [dbo].[BookWrittenByAuthor] CHECK CONSTRAINT [FK_BookWrittenByAuthor_Author]
GO
ALTER TABLE [dbo].[BookWrittenByAuthor]  WITH CHECK ADD  CONSTRAINT [FK_BookWrittenByAuthor_Book] FOREIGN KEY([BookId])
REFERENCES [dbo].[Book] ([Id])
GO
ALTER TABLE [dbo].[BookWrittenByAuthor] CHECK CONSTRAINT [FK_BookWrittenByAuthor_Book]
GO
USE [master]
GO
ALTER DATABASE [LibraryDb] SET  READ_WRITE 
GO
