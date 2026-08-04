CREATE PROCEDURE [dbo].[AddSection]
	@SectionID INT,
	@SectionName NVARCHAR(50)

AS
BEGIN
	INSERT INTO [Section] ([ID], [SectionName])
	VALUES (@SectionID, @SectionName)
END
