CREATE TABLE [dbo].[Student]
(
	[ID] INT NOT NULL IDENTITY, 
    [FirstName] VARCHAR(50) NOT NULL, 
    [LastName] VARCHAR(50) NOT NULL, 
    [BirthDate] DATETIME2 NOT NULL, 
    [YearResult] INT NOT NULL, 
    [SectionID] INT NOT NULL, 

    CONSTRAINT [PK_Student] 
        PRIMARY KEY ([ID]),
    [Active] BIT NOT NULL DEFAULT 1, 
    CONSTRAINT [FK_Student_Section] 
		FOREIGN KEY ([SectionID]) 
		REFERENCES [Section] ([ID]),
    CONSTRAINT [CK_Student_YearResult]
        CHECK ([YearResult] BETWEEN 0 AND 20),
    CONSTRAINT [CK_Student_BirthDate]
        CHECK ([BirthDate] > '1930-01-01')
)
