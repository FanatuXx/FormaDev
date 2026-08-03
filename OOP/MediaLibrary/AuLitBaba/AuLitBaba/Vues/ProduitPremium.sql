CREATE VIEW [dbo].[ProduitPremium]
	AS SELECT * 
		FROM [Produit]
		WHERE [Prix] >= 100
		
-- Quand je vais faire un SELECT sur mes [ProduitPremium], cela va reprendre ma table [Produit] et ne rechercher que parmi les éléments dont le prix est supérieur à 100eu