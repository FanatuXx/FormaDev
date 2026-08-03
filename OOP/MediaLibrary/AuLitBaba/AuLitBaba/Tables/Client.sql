CREATE TABLE [dbo].[Client]
(
	[Id] INT NOT NULL IDENTITY, 
    [Nom] NVARCHAR(50) NOT NULL, 
    [Prénom] NVARCHAR(50) NOT NULL, 
    [Adresse] NVARCHAR(MAX) NOT NULL,
    [Email] NVARCHAR(MAX) NOT NULL

    CONSTRAINT [PK_Client] 
        PRIMARY KEY([Id]), 
    [IsActive] BIT NOT NULL DEFAULT 1, 
    CONSTRAINT [CK_Client_Mail] 
        CHECK ([Email] LIKE '%@%.%') 
)
