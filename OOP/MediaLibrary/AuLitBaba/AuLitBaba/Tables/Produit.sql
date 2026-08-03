CREATE TABLE [dbo].[Produit]
(
	[Id] INT NOT NULL IDENTITY, 
    [Nom] NVARCHAR(50) NOT NULL,
	[Prix] MONEY NOT NULL, 
	[Description] NVARCHAR(MAX),

	[isActive] BIT NOT NULL DEFAULT 1, 
    CONSTRAINT [PK_Produit] 
		PRIMARY KEY([Id]), 
    CONSTRAINT [CK_Produit_Prix] 
		CHECK (Prix >= 0)	-- Prix peut se noter [Prix] dans la condition
)
