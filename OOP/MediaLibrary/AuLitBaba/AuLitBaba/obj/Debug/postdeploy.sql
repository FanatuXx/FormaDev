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

SET IDENTITY_INSERT Produit OFF;



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
