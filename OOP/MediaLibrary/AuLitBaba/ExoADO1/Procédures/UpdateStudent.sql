CREATE PROCEDURE [dbo].[UpdateStudent]
	@StudentID INT,
	@SectionID INT,
	@YearResult INT

AS
BEGIN
	UPDATE [Student] 
	SET [SectionID] = @SectionID, [YearResult] = @YearResult
	WHERE [ID] = @StudentID
END
