CREATE PROCEDURE [dbo].[DeleteStudent]
	@studentID int
AS
	DELETE FROM Student
	WHERE Id = @studentID
RETURN 0
