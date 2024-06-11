USE [RecapDatabase]
GO

/****** Object: Table [dbo].[Customers] Script Date: 26.04.2024 19:18:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Customers] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [UserId]      INT           NOT NULL,
    [CompanyName] VARCHAR (255) NULL
);


