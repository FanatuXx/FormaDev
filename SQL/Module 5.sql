---------------------------------- EXO 1
CREATE PROCEDURE GetDateV2 AS
BEGIN
	PRINT(GETDATE())
END

EXECUTE GetDateV2

----------------------------------- EXO 2
GO

CREATE PROCEDURE GetDateV3 AS
BEGIN
	PRINT(CONCAT_WS(' ', 'Nous sommes le', CAST(GETDATE() AS DATE), 'et il est actuellement', CAST(GETDATE() AS TIME)))
END

EXECUTE GetDateV3

----------------------------------- EXO 3
GO

CREATE PROCEDURE ShowInfo (@first_name NVARCHAR(50), @last_name NVARCHAR(50), @age INT) AS
BEGIN
	DECLARE @info TABLE(
		FirstName NVARCHAR(50),
		LastName NVARCHAR(50),
		Age INT
		)

	INSERT INTO @info VALUES (@first_name, @last_name, @age)

	SELECT * FROM @info 
END

EXECUTE ShowInfo 'Antoine', 'Dufour', 28

----------------------------------- EXO 4
GO

CREATE PROCEDURE CategorizeEmployees AS
BEGIN
	
	SELECT * FROM Human

END

