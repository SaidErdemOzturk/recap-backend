USE [RecapDatabase]
GO

/****** Object: Table [dbo].[Colors] Script Date: 26.04.2024 19:18:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Colors] (
    [Id]        INT          IDENTITY (1, 1) NOT NULL,
    [ColorName] VARCHAR (50) NULL
);


