CREATE TABLE [dbo].[ClientProduit]
(
	[Id] INT NOT NULL IDENTITY,
	[DateAchat] DATETIME NOT NULL,
	[Quantité] INT NOT NULL,
	[ClientId] INT NOT NULL,

	[ProduitId] INT NOT NULL, 
    CONSTRAINT [PK_Client_Produit] 
		PRIMARY KEY ([Id]),
	CONSTRAINT [FK_ClientProduit_ClientId] 
		FOREIGN KEY ([ClientId]) 
		REFERENCES [Client] ([Id]), 
    CONSTRAINT [FK_ClientProduit_ProduitId] 
		FOREIGN KEY ([ProduitId]) 
		REFERENCES [Produit] ([Id])
)

GO

CREATE INDEX [IX_ClientProduit_ProduitId] ON [dbo].[ClientProduit] ([ProduitId])
