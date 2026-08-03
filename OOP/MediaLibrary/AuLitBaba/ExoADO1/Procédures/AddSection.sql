CREATE PROCEDURE [dbo].[AddSection]
	@SectionID INT,
	@SectionName NVARCHAR

AS
BEGIN
	INSERT INTO [Section] ([ID], [SectionName])
	VALUES (@SectionID, @SectionName)
END
