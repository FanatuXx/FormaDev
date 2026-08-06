CREATE TRIGGER [DeactivateStudent]
	ON [dbo].[Student]
	INSTEAD OF DELETE
	AS
	BEGIN
		UPDATE Student
		SET Active = 0
		WHERE Id IN (
			SELECT Id 
			FROM deleted
		);
	END
