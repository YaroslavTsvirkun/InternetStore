
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/15/2017 12:36:24
-- Generated from EDMX file: C:\Users\test\documents\visual studio 2017\Projects\InternetStore\DataAccessLayer\DataStore.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Bookstore];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ImageBooks]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ImageSet] DROP CONSTRAINT [FK_ImageBooks];
GO
IF OBJECT_ID(N'[dbo].[FK_GenresBooks]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GenresSet] DROP CONSTRAINT [FK_GenresBooks];
GO
IF OBJECT_ID(N'[dbo].[FK_GenresGenres]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GenresSet] DROP CONSTRAINT [FK_GenresGenres];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Books]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Books];
GO
IF OBJECT_ID(N'[dbo].[ImageSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ImageSet];
GO
IF OBJECT_ID(N'[dbo].[GenresSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GenresSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Books'
CREATE TABLE [dbo].[Books] (
    [BookId] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Author] nvarchar(max)  NOT NULL,
    [Genre] nvarchar(max)  NOT NULL,
    [Price] int  NOT NULL,
    [Description] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ImageSet'
CREATE TABLE [dbo].[ImageSet] (
    [ImageId] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Picture] nvarchar(max)  NOT NULL,
    [Books_BookId] int  NOT NULL
);
GO

-- Creating table 'GenresSet'
CREATE TABLE [dbo].[GenresSet] (
    [GenreId] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [GenresBooks_Genres_BookId] int  NOT NULL,
    [ParidId_GenreId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [BookId] in table 'Books'
ALTER TABLE [dbo].[Books]
ADD CONSTRAINT [PK_Books]
    PRIMARY KEY CLUSTERED ([BookId] ASC);
GO

-- Creating primary key on [ImageId] in table 'ImageSet'
ALTER TABLE [dbo].[ImageSet]
ADD CONSTRAINT [PK_ImageSet]
    PRIMARY KEY CLUSTERED ([ImageId] ASC);
GO

-- Creating primary key on [GenreId] in table 'GenresSet'
ALTER TABLE [dbo].[GenresSet]
ADD CONSTRAINT [PK_GenresSet]
    PRIMARY KEY CLUSTERED ([GenreId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Books_BookId] in table 'ImageSet'
ALTER TABLE [dbo].[ImageSet]
ADD CONSTRAINT [FK_ImageBooks]
    FOREIGN KEY ([Books_BookId])
    REFERENCES [dbo].[Books]
        ([BookId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ImageBooks'
CREATE INDEX [IX_FK_ImageBooks]
ON [dbo].[ImageSet]
    ([Books_BookId]);
GO

-- Creating foreign key on [GenresBooks_Genres_BookId] in table 'GenresSet'
ALTER TABLE [dbo].[GenresSet]
ADD CONSTRAINT [FK_GenresBooks]
    FOREIGN KEY ([GenresBooks_Genres_BookId])
    REFERENCES [dbo].[Books]
        ([BookId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GenresBooks'
CREATE INDEX [IX_FK_GenresBooks]
ON [dbo].[GenresSet]
    ([GenresBooks_Genres_BookId]);
GO

-- Creating foreign key on [ParidId_GenreId] in table 'GenresSet'
ALTER TABLE [dbo].[GenresSet]
ADD CONSTRAINT [FK_GenresGenres]
    FOREIGN KEY ([ParidId_GenreId])
    REFERENCES [dbo].[GenresSet]
        ([GenreId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GenresGenres'
CREATE INDEX [IX_FK_GenresGenres]
ON [dbo].[GenresSet]
    ([ParidId_GenreId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------