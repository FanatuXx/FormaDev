CREATE TABLE [dbo].[Student]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[FirstName] NVARCHAR(50) NOT NULL,
	[LastName] NVARCHAR(50) NOT NULL,
	[BirthDate] DATETIME2  NOT NULL,
	[YearResult] INT NOT NULL,
	[SectionID] INT NOT NULL,
	[Active] BIT NOT NULL DEFAULT 1,

	CONSTRAINT FK_Student_SectionID 
		FOREIGN KEY ([SectionID]) 
		REFERENCES [Section]([Id]),
	CONSTRAINT CK_Student_YearResult
		CHECK ([yearResult] BETWEEN 0 AND 20),
	CONSTRAINT CK_Student_BirthDate
		CHECK ([BirthDate] >= '1930-01-01')
)

GO
