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
USE [$(DatabaseName)];


GO
PRINT N'Modification de Table [dbo].[Client]...';


GO
ALTER TABLE [dbo].[Client]
    ADD [IsActive] BIT DEFAULT 1 NOT NULL;


GO
PRINT N'Modification de Table [dbo].[Produit]...';


GO
ALTER TABLE [dbo].[Produit]
    ADD [isActive] BIT DEFAULT 1 NOT NULL;


GO
PRINT N'Actualisation de Vue [dbo].[ProduitPremium]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[ProduitPremium]';


GO
DELETE FROM ClientProduit;
DELETE FROM Client;
DELETE FROM Produit;


-- CLIENTS
SET IDENTITY_INSERT Client ON;

-- INSERT
INSERT INTO Client ([Id], [Nom], [Prénom], [Adresse], [Email])
VALUES 
	(1, 'Juste', 'Caroline', 'rue de techno 17 Gosselie', 'caro.juste@hotmail.com'),
	(2, 'Dussomeil', 'Thomas', 'rue du Sommeil 61 Spa', 'thomanana@caramail.com')

SET IDENTITY_INSERT Client OFF;


-- PRODUITS
SET IDENTITY_INSERT Produit ON;

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
PRINT N'Mise à jour terminée.';


GO
