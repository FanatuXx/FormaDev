
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

CREATE OR ALTER PROCEDURE CategorizeEmployees AS
BEGIN
	DECLARE @young TABLE(
		FirstName NVARCHAR(50),
		LastName NVARCHAR(50),
		BirthDate DATETIME,
		HireDate INT	
	)

	DECLARE @old TABLE(
		FirstName NVARCHAR(50),
		LastName NVARCHAR(50),
		BirthDate DATETIME,
		HireDate INT
	)		

	INSERT INTO @old
	SELECT P.FirstName, P.LastName, E.BirthDate, YEAR(E.HireDate)
	FROM AdventureWorks2017.Person.Person AS P 
	JOIN AdventureWorks2017.HumanResources.Employee AS E
	ON P.BusinessEntityID = E.BusinessEntityID
	WHERE 
		YEAR(E.BirthDate) < 1980 AND
		YEAR(E.BirthDate) > 1970 AND
		YEAR(E.HireDate) < 2008

	SELECT *
	FROM @old

	INSERT INTO @young
	SELECT P.FirstName, P.LastName, E.BirthDate, YEAR(E.HireDate)
	FROM AdventureWorks2017.Person.Person AS P 
	JOIN AdventureWorks2017.HumanResources.Employee AS E
	ON P.BusinessEntityID = E.BusinessEntityID
	WHERE YEAR(E.BirthDate) > 1990 AND YEAR(E.HireDate) > 2010

	SELECT *
	FROM @young
END

GO
EXEC dbo.CategorizeEmployees

-------------------------- EXO 5
GO

CREATE OR ALTER FUNCTION fn_LinesCount()
RETURNS INT
AS 
BEGIN
	DECLARE @linesNb INT

	SELECT @linesNb = COUNT(BusinessEntityID) 
	FROM AdventureWorks2017.HumanResources.Employee

	RETURN @linesNb
END
 
GO
SELECT [dbo].[fn_LinesCount]()

------------------------- EXO 6
GO

CREATE OR ALTER FUNCTION fn_MostModifiedPriceProduct()
RETURNS NVARCHAR(50)
AS 
BEGIN
	DECLARE AP CURSOR FOR -- AP = All Products
	SELECT ProductID, Name FROM Production.Product

	DECLARE 
		@AP_ProductID INT,
		@AP_Name NVARCHAR(50)

	DECLARE MMP CURSOR FOR  -- MMP = MostModifiedPrice
	SELECT ProductID, StandardCost
	FROM Production.ProductCostHistory AS PCH
	WHERE StandardCost = (
		SELECT StandardCost
		FROM Production.ProductCostHistory AS PCH2
		WHERE PCH2.ProductID = PCH.ProductID AND COUNT(StandardCost) = MAX(COUNT(StandardCost))
	) -- Sous requête corrélées 

	DECLARE 
		@MMP_ProductID INT,
		@MMP_StandardCost FLOAT

	OPEN AP
	FETCH AP INTO @AP_ProductID, @AP_Name

	WHILE @@FETCH_STATUS = 0
		BEGIN
			OPEN MMP 
			FETCH MMP INTO @MMP_ProductID, @MMP_StandardCost
				WHILE @@FETCH_STATUS = 0
					BEGIN 
						IF @AP_ProductID = @MMP_ProductID
							BEGIN
								IF 
									BEGIN 
									END
							END
						FETCH MMP INTO @MMP_ProductID, @MMP_StandardCost
					END
			FETCH AP INTO @AP_ProductID, @AP_Name
			CLOSE MMP
		END
	CLOSE AP
	DEALLOCATE AP
	DEALLOCATE MMP
END

SELECT * 
FROM Production.ProductCostHistory



-------------- CORRECTION

GO

CREATE OR ALTER FUNCTION fn_most_modified_product()
RETURNS NVARCHAR(MAX) 
AS
BEGIN
	DECLARE 
		@Product NVARCHAR(50),
		@ConcatenatedProduct NVARCHAR(MAX)

	DECLARE ProductList CURSOR FOR
		SELECT Name
		FROM Production.Product
		WHERE ProductID IN (
			SELECT ProductID
			FROM Production.ProductCostHistory
			GROUP BY ProductID
			HAVING COUNT (*) = (
				SELECT TOP (1) COUNT (*)
				FROM Production.ProductCostHistory
				GROUP BY ProductID
				ORDER BY COUNT (*) DESC
			)
		)

	OPEN ProductList
	FETCH ProductList INTO @Product 
	WHILE @@FETCH_STATUS = 0
		BEGIN
		
			SET @ConcatenatedProduct = CONCAT(@ConcatenatedProduct, ' - ', @Product)
			FETCH ProductList INTO @Product 
		END
	CLOSE ProductList
	DEALLOCATE ProductList
	RETURN @ConcatenatedProduct
END
GO

SELECT dbo.fn_most_modified_product()
GO

------------- Autre méthode 

CREATE OR ALTER FUNCTION fn_most_modified_product()
RETURNS NVARCHAR(MAX) 
AS
BEGIN
	DECLARE
		@ConcatenatedProduct NVARCHAR(MAX)

		SELECT @ConcatenatedProduct = STRING_AGG(Name, '-') -- STRING_AGG = concat en colonne
		FROM Production.Product
		WHERE ProductID IN (
			SELECT ProductID
			FROM Production.ProductCostHistory
			GROUP BY ProductID
			HAVING COUNT (*) = (
				SELECT TOP (1) COUNT (*)
				FROM Production.ProductCostHistory
				GROUP BY ProductID
				ORDER BY COUNT (*) DESC
			)
		)

	RETURN @ConcatenatedProduct
END



----------------------------------- EXO 7

GO

CREATE OR ALTER PROCEDURE usp_UpdateModifiedDate
	@UpdatedLines INT OUTPUT
AS
BEGIN
	UPDATE HumanResources.Employee
	SET ModifiedDate = GETDATE()
	FROM HumanResources.Employee
	WHERE ModifiedDate <> '2008-07-31 00:00:00.000'

	SELECT @UpdatedLines = COUNT(ModifiedDate)
	FROM HumanResources.Employee
	WHERE ModifiedDate <> '2008-07-31 00:00:00.000'
		
END

GO
DECLARE @UpdatedLines INT

EXEC usp_UpdateModifiedDate
	@UpdatedLines OUTPUT

SELECT @UpdatedLines

-------------------------- EXO 9.1
GO
CREATE OR ALTER FUNCTION fn_NbEmployee_ParJobTitle(
	@JobTitle NVARCHAR(50)
	)
RETURNS INT
AS 
BEGIN 
	DECLARE
		@NbEmployee INT;

	SELECT @NbEmployee = COUNT(*)
	FROM HumanResources.Employee
	WHERE JobTitle = @JobTitle

	RETURN @NbEmployee
END

GO 
SELECT [dbo].fn_NbEmployee_ParJobTitle('Marketing Assistant')

-------------------------- EXO 9.2

--CREATE OR ALTER PROCEDURE usp_









-- EXO 11 CORRECTION

GO

CREATE TABLE employes (
	id INT,
	last_name NVARCHAR(100),
	first_name NVARCHAR(100),
	birthdate DATETIME,
	hiredate DATETIME
)
SELECT * FROM employes

GO
CREATE TYPE TT_employee AS TABLE(
	id INT,
	last_name NVARCHAR(100),
	first_name NVARCHAR(100),
	birthdate DATETIME,
	hiredate DATETIME	
)

GO

CREATE PROCEDURE sp_archiver_employee @list_emp TT_employee READONLY
AS
BEGIN
	INSERT INTO employes
	SELECT id, last_name, first_name, birthdate, GETDATE() FROM @list_emp

END

GO

DECLARE @empList TT_employee 

INSERT INTO @empList
SELECT P.BusinessEntityID, P.LastName, P.FirstName, E.BirthDate, E.HireDate
FROM HumanResources.Employee AS E LEFT JOIN Person.Person AS P ON P.BusinessEntityID = E.BusinessEntityID 

EXEC sp_archiver_employee @empList 
SELECT * FROM employes


--------- EXO 12 CORRECTION

-- Modifier la table 

SELECT * 
FROM employes

ALTER TABLE employes ADD num_tel NVARCHAR(100)
GO

SELECT BusinessEntityID, PhoneNumber, PhoneNumberTypeID
FROM Person.PersonPhone

CREATE TYPE TT_phoneData AS TABLE(
	ID INT,
	Phone NVARCHAR(100),
	PhoneType INT
)

GO
CREATE OR ALTER PROCEDURE sp_update_phone_data 
	 @phoneData TT_phonedata READONLY,
	 @nbLines INT OUTPUT
AS
BEGIN
	DECLARE @id INT, @phone NVARCHAR(100), @phoneType INT
	DECLARE CRS CURSOR FOR SELECT * FROM @phoneData

	OPEN CRS
	FETCH CRS INTO @id, @phone, @phoneType

	WHILE @@FETCH_STATUS = 0
	BEGIN
		IF @phoneType = 3
			BEGIN
				UPDATE employes 
				SET num_tel = @phone 
				WHERE id = @id
			END


		FETCH CRS INTO @id, @phone, @phoneType
	END
END


---- Test
GO

DECLARE @phoneData TT_phoneData;
DECLARE @lines INT = 0
INSERT INTO @phoneData
SELECT BusinessEntityID, PhoneNumber, PhoneNumberTypeID
FROM Person.PersonPhone

EXEC sp_update_phone_data @phoneData, @lines OUTPUT
PRINT(@lines)
SELECT * FROM employes












	









