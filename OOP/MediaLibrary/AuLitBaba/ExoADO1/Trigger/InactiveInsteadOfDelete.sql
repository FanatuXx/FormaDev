CREATE TRIGGER [InactiveInsteadOfDelete]
	ON [dbo].[Student]
	INSTEAD OF DELETE
	AS
	BEGIN
		SET NOCOUNT ON
		UPDATE [Student]
		SET [Active] = 0
		WHERE [ID] IN inserted 
		JOIN 
			
		
		
		-- deleted.[ID]
	END
