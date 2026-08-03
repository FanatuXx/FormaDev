CREATE PROCEDURE [dbo].[DeleteStudent]
	@StudentID INT

AS
BEGIN
	DELETE [Student]
	WHERE [ID] = @StudentID
END