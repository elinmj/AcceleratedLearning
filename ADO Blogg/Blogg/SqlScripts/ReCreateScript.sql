USE [Blogg]
GO


CREATE TABLE [dbo].[Blogg] (
    [Id]      INT           IDENTITY (1, 1) NOT NULL,
    [Title]   NVARCHAR (50) NOT NULL,
    [Author]  NVARCHAR (50) NOT NULL,
    [Created] DATETIME      NOT NULL
);