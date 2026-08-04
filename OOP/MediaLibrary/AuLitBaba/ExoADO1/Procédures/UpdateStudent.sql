CREATE PROCEDURE [dbo].[UpdateStudent]
	@StudentID INT,
	@SectionID INT = NULL,
	@YearResult INT = NULL

AS
	IF (@SectionID IS NOT NULL)
	BEGIN
		UPDATE [Student] 
		SET [SectionID] = @SectionID
		WHERE [ID] = @StudentID
	END

	IF (@YearResult IS NOT NULL)
	BEGIN
		UPDATE [Student] 
		SET [YearResult] = @YearResult
		WHERE [ID] = @StudentID
	END