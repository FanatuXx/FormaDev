CREATE PROCEDURE [dbo].[AddStudent]
	@FirstName NVARCHAR(50),
	@LastName NVARCHAR(50),
	@BirthDate DATE,
	@SectionID NVARCHAR(50),
	@YearResult INT,
	@Active BIT = 1
	
AS
BEGIN
	INSERT INTO [Student] ([FirstName], [LastName], [BirthDate], [SectionID], [YearResult], [Active])
	VALUES (@FirstName, 
			@LastName, 
			@BirthDate,
			@SectionID, 
			@YearResult, 
			@Active)
END
