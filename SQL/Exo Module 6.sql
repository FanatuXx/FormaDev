------------------------------------------------------ EXERCICES MODULE 6

----------- EXO 3

CREATE OR ALTER PROCEDURE usp_backup_data_backupList
	@ProductBackup TABLE(
		ProductID INT,
		Name NVARCHAR(50),
		ProductNumber NVARCHAR(50)
	)
	
AS
BEGIN
	INSERT INTO ProductBackup
	SELECT ProductID, Name, ProductNumber
	FROM deleted
END







GO


CREATE TRIGGER tr_backup_deleted_data
	ON Production.Product
	FOR DELETE 
	AS
	BEGIN

		IF OBJECT_ID ('ProductBackup', 'U') IS NULL
			BEGIN
				CREATE TABLE ProductBackup (
					ProductID INT,
					Name NVARCHAR(50),
					ProductNumber NVARCHAR(50)
				)
			END
	END

	SELECT * FROM Production.Product