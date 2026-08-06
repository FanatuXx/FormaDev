CREATE PROCEDURE [dbo].[AddStudent]
	@firstName NVARCHAR(50),
	@lastName NVARCHAR(50),
	@birthDate DATETIME2,
	@sectionID INT,
	@yearResult INT,
	@active BIT = 1
AS

	INSERT INTO student 
		(FirstName, LastName, BirthDate, SectionID, YearResult, Active) 
	VALUES
		(@firstName, @lastName, @birthDate, @sectionID, @yearResult, @active);

RETURN 0
