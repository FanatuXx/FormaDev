CREATE PROCEDURE [dbo].[UpdateStudent]
	@studentID int,
	@sectionID int = NULL,
	@yearResult int = NULL
AS
	IF (@sectionID IS NOT NULL)
	BEGIN
		UPDATE Student
		SET SectionID = @sectionID
		WHERE Id = @studentID
	END
	
	IF (@yearResult IS NOT NULL)
	BEGIN
		UPDATE Student
		SET YearResult = @yearResult
		WHERE Id = @studentID
	END
RETURN 0
