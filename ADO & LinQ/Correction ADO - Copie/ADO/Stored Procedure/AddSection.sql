CREATE PROCEDURE [dbo].[AddSection]
	@sectionId INT,
	@name NVARCHAR(50)
AS
	INSERT INTO Section 
		(Id, SectionName)
	VALUES
		(@sectionId, @name);
RETURN 0
