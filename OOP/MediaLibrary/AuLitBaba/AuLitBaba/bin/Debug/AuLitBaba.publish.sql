/*
Script de déploiement pour AuLitBaba

Ce code a été généré par un outil.
Toute modification apportée à ce fichier peut entraîner un comportement incorrect et sera perdue en cas de
régénération du code.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "AuLitBaba"
:setvar DefaultFilePrefix "AuLitBaba"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL15.TFTIC\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL15.TFTIC\MSSQL\DATA\"

GO
:on error exit
GO
/*
Détectez le mode SQLCMD et désactivez l’exécution de script si le mode SQLCMD n’est pas pris en charge.
Pour réactiver le script après l’activation du mode SQLCMD, exécutez ce qui suit : 
DÉSACTIVER NOEXEC ; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'Le mode SQLCMD doit être activé de manière à pouvoir exécuter ce script.';
        SET NOEXEC ON;
    END


GO
USE [master];


GO

IF (DB_ID(N'$(DatabaseName)') IS NOT NULL) 
BEGIN
    ALTER DATABASE [$(DatabaseName)]
    SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [$(DatabaseName)];
END

GO
PRINT N'Création de la base de données $(DatabaseName)...'
GO
CREATE DATABASE [$(DatabaseName)]
    ON 
    PRIMARY(NAME = [$(DatabaseName)], FILENAME = N'$(DefaultDataPath)$(DefaultFilePrefix)_Primary.mdf')
    LOG ON (NAME = [$(DatabaseName)_log], FILENAME = N'$(DefaultLogPath)$(DefaultFilePrefix)_Primary.ldf') COLLATE SQL_Latin1_General_CP1_CI_AS
GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CLOSE OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
USE [$(DatabaseName)];


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ANSI_NULLS ON,
                ANSI_PADDING ON,
                ANSI_WARNINGS ON,
                ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                NUMERIC_ROUNDABORT OFF,
                QUOTED_IDENTIFIER ON,
                ANSI_NULL_DEFAULT ON,
                CURSOR_DEFAULT LOCAL,
                RECOVERY FULL,
                CURSOR_CLOSE_ON_COMMIT OFF,
                AUTO_CREATE_STATISTICS ON,
                AUTO_SHRINK OFF,
                AUTO_UPDATE_STATISTICS ON,
                RECURSIVE_TRIGGERS OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ALLOW_SNAPSHOT_ISOLATION OFF;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET READ_COMMITTED_SNAPSHOT OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_UPDATE_STATISTICS_ASYNC OFF,
                PAGE_VERIFY NONE,
                DATE_CORRELATION_OPTIMIZATION OFF,
                DISABLE_BROKER,
                PARAMETERIZATION SIMPLE,
                SUPPLEMENTAL_LOGGING OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET TRUSTWORTHY OFF,
        DB_CHAINING OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'Impossible de modifier les paramètres de base de données. Vous devez être administrateur système pour appliquer ces paramètres.';
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET HONOR_BROKER_PRIORITY OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'Impossible de modifier les paramètres de base de données. Vous devez être administrateur système pour appliquer ces paramètres.';
    END


GO
ALTER DATABASE [$(DatabaseName)]
    SET TARGET_RECOVERY_TIME = 0 SECONDS 
    WITH ROLLBACK IMMEDIATE;


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET FILESTREAM(NON_TRANSACTED_ACCESS = OFF),
                CONTAINMENT = NONE 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CREATE_STATISTICS ON(INCREMENTAL = OFF),
                MEMORY_OPTIMIZED_ELEVATE_TO_SNAPSHOT = OFF,
                DELAYED_DURABILITY = DISABLED 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE (QUERY_CAPTURE_MODE = ALL, DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_PLANS_PER_QUERY = 200, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 367), MAX_STORAGE_SIZE_MB = 100) 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE = OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET TEMPORAL_HISTORY_RETENTION ON 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ACCELERATED_DATABASE_RECOVERY = OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF fulltextserviceproperty(N'IsFulltextInstalled') = 1
    EXECUTE sp_fulltext_database 'enable';


GO
PRINT N'Création de Table [dbo].[Client]...';


GO
CREATE TABLE [dbo].[Client] (
    [Id]      INT            IDENTITY (1, 1) NOT NULL,
    [Nom]     NVARCHAR (50)  NOT NULL,
    [Prénom]  NVARCHAR (50)  NOT NULL,
    [Adresse] NVARCHAR (MAX) NOT NULL,
    [Email]   NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Création de Table [dbo].[ClientProduit]...';


GO
CREATE TABLE [dbo].[ClientProduit] (
    [Id]        INT      IDENTITY (1, 1) NOT NULL,
    [DateAchat] DATETIME NOT NULL,
    [Quantité]  INT      NOT NULL,
    [ClientId]  INT      NOT NULL,
    [ProduitId] INT      NOT NULL,
    CONSTRAINT [PK_Client_Produit] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Création de Index [dbo].[ClientProduit].[IX_ClientProduit_ProduitId]...';


GO
CREATE NONCLUSTERED INDEX [IX_ClientProduit_ProduitId]
    ON [dbo].[ClientProduit]([ProduitId] ASC);


GO
PRINT N'Création de Table [dbo].[Produit]...';


GO
CREATE TABLE [dbo].[Produit] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Nom]         NVARCHAR (50)  NOT NULL,
    [Prix]        MONEY          NOT NULL,
    [Description] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Produit] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Création de Clé étrangère [dbo].[FK_ClientProduit_ClientId]...';


GO
ALTER TABLE [dbo].[ClientProduit]
    ADD CONSTRAINT [FK_ClientProduit_ClientId] FOREIGN KEY ([ClientId]) REFERENCES [dbo].[Client] ([Id]);


GO
PRINT N'Création de Clé étrangère [dbo].[FK_ClientProduit_ProduitId]...';


GO
ALTER TABLE [dbo].[ClientProduit]
    ADD CONSTRAINT [FK_ClientProduit_ProduitId] FOREIGN KEY ([ProduitId]) REFERENCES [dbo].[Produit] ([Id]);


GO
PRINT N'Création de Contrainte de validation [dbo].[CK_Client_Mail]...';


GO
ALTER TABLE [dbo].[Client]
    ADD CONSTRAINT [CK_Client_Mail] CHECK ([Email] LIKE '%@%.%');


GO
PRINT N'Création de Contrainte de validation [dbo].[CK_Produit_Prix]...';


GO
ALTER TABLE [dbo].[Produit]
    ADD CONSTRAINT [CK_Produit_Prix] CHECK (Prix >= 0);


GO
PRINT N'Création de Vue [dbo].[ProduitPremium]...';


GO
CREATE VIEW [dbo].[ProduitPremium]
	AS SELECT * 
		FROM [Produit]
		WHERE [Prix] >= 100
		
-- Quand je vais faire un SELECT sur mes [ProduitPremium], cela va reprendre ma table [Produit] et ne rechercher que parmi les éléments dont le prix est supérieur à 100eu
GO
-- CLIENTS
SET IDENTITY_INSERT Client ON;

-- INSERT
INSERT INTO Client ([Id], [Nom], [Prénom], [Adresse], [Email])
VALUES 
	(1, 'Juste', 'Caroline', 'rue de techno 17 Gosselie', 'caro.juste@hotmail.com'),
	(2, 'Dussomeil', 'Thomas', 'rue du Sommeil 61 Spa', 'thomanana@caramail.com')

SET IDENTITY_INSERT Client OFF;


-- PRODUITS
SET IDENTITY_INSERT Produits ON;

-- INSERT
INSERT INTO Produit ([Id], [Nom], [Prix], [Description])
VALUES
	(1, 'STJÄRNÖ', 119, 'Sommier à lattes, matelas et literie non inclus'),
	(2, 'VESTMARKA', 84.15, 'Matelas à ressorts, mi-ferme/bleu clair, 90x200cm'),
	(3, 'SKOGSFRÄKEN', 12.99,'Oreiller, haut, 50x60cm')

SET IDENTITY_INSERT Produits OFF;



-- CLIENT PRODUITS
SET IDENTITY_INSERT ClientProduit ON;

INSERT INTO ClientProduit ([Id], [DateAchat], [Quantité], [ClientId], [ProduitId])
VALUES 
	(1, GETDATE(), 1, 2, 2),
	(2, GETDATE(), 1, 2, 3),
	(3, GETDATE(), 3, 1, 3),
	(4, GETDATE(), 1, 1, 1),
	(5, GETDATE(), 1, 1, 2);


-- INSERT

SET IDENTITY_INSERT ClientProduit OFF;
GO

GO
DECLARE @VarDecimalSupported AS BIT;

SELECT @VarDecimalSupported = 0;

IF ((ServerProperty(N'EngineEdition') = 3)
    AND (((@@microsoftversion / power(2, 24) = 9)
          AND (@@microsoftversion & 0xffff >= 3024))
         OR ((@@microsoftversion / power(2, 24) = 10)
             AND (@@microsoftversion & 0xffff >= 1600))))
    SELECT @VarDecimalSupported = 1;

IF (@VarDecimalSupported > 0)
    BEGIN
        EXECUTE sp_db_vardecimal_storage_format N'$(DatabaseName)', 'ON';
    END


GO
PRINT N'Mise à jour terminée.';


GO
