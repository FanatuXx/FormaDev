CREATE TRIGGER [InactiveInsteadOfDelete]
	ON [dbo].[Student]
	INSTEAD OF DELETE
	AS
	BEGIN
		SET NOCOUNT ON
		UPDATE [Student]
		SET [Active] = 0
		WHERE [ID] IN ( --IN permet de gérer les cas où il y aurait plusieurs ID renseignés 
			SELECT ID
			FROM deleted
		); 
	END
