-- MODULE 4
GO
USE AdventureWorks2017

DECLARE											--Variable qui vont contenir les informations de chaque ligne à chaque itération du curseur
	@id INT,
	@first_name NVARCHAR(100),
	@last_name NVARCHAR(100)


DECLARE crs CURSOR FOR							--On remplit un curseur avec une requête/table
SELECT BusinessEntityID, FirstName, LastName
FROM Person.Person

OPEN crs										-- Ouvrir le curseur 

FETCH crs INTO 	@id, @first_name, @last_name	-- Fetch initial 

WHILE(@@FETCH_STATUS = 0)
	BEGIN
		PRINT(CONCAT(@id, ' : ', UPPER(@first_name), ' ', LOWER(@last_name))) -- Traitement
		FETCH crs INTO @id, @first_name, @last_name
	END

CLOSE crs										-- Ferme le curseur 

DEALLOCATE crs									-- Libérer la mémoire

------------------------------------------------------------------------------------------------ EXERCICES MODULE 4

-------------------------------- EXO 1
GO

DECLARE 
	@index INT = 1

WHILE (@index < 20)
	BEGIN
		PRINT(@index * @index)
		SET @index += 1

		IF @index = 12
			BEGIN
				BREAK
			END
	END

---------------------------------- EXO 2

-- Incrémenter notre index
-- Mettre une condition avec un Break 

---------------------------------- EXO 3
GO
DECLARE 
	@index INT = 1

WHILE (@index <= 50)
	BEGIN
		IF @index < 20 OR @index > 30
			BEGIN
				PRINT(@index * @index)
			END
		SET @index += 2
	END

---------------- AUTRE MANIERE

GO
DECLARE 
	@index INT = 1

WHILE @index <= 50         ---------- <> signifie "différent de"
	BEGIN
		IF @index < 20 OR @index > 30 AND @index % 2 <> 0
			BEGIN
				PRINT(@index * @index)
			END
		SET @index += 1
	END

--------------------------------- EXO 4

GO
DECLARE 
	@index INT = 3

WHILE (@index <= 30)
	BEGIN
		PRINT(CONCAT('Ceci est un nombre divisible par 3 : ', @index))
		SET @index += 3
	END

---------------------------------- EXO 5

GO
DECLARE 
	@year INT = YEAR(GETDATE()),
	@count INT = 0

WHILE (@year >= 1983)
	BEGIN
		PRINT(@year)
		SET @year -= 1
		SET @count += 1
	END

PRINT(CONCAT(@count, '  années ont été décomptées depuis ', YEAR(GETDATE())))

---------------------------------- EXO 6
GO

DECLARE											--Variable qui vont contenir les informations de chaque ligne à chaque itération du curseur
	@date DATE = GETDATE(),
	@index INT = 1

DECLARE @table TABLE(
		[format] NVARCHAR(100)
		)

WHILE (@index <= 5)
	BEGIN
		INSERT INTO @table VALUES(
		CONVERT(NVARCHAR(50), @date, CAST((FLOOR(RAND() * 10) + 100) AS INT)))
		SET @index += 1
	END

SELECT * FROM @table

----------------------------------- EXO 7
GO
USE AdventureWorks2017

DECLARE 
	@last_name NVARCHAR(100),
	@first_name NVARCHAR(100),
	@job_title NVARCHAR(100),
	@id INT

DECLARE crs CURSOR FOR 
SELECT TOP (200) LastName, FirstName, JobTitle, P.BusinessEntityID
FROM Person.Person AS P JOIN HumanResources.Employee AS E ON P.BusinessEntityID = E.BusinessEntityID

CREATE TABLE #temp(
	last_name NVARCHAR(100),
	first_name NVARCHAR(100),
	job_title NVARCHAR(100),
	id INT
	)

OPEN CRS

FETCH CRS INTO @last_name, @first_name, @job_title, @id
WHILE @@FETCH_STATUS = 0
	BEGIN
		IF @job_title = 'Production Technician - WC60'
			BEGIN
				INSERT INTO #temp VALUES (@last_name, @first_name, @job_title, @id)
			END
		FETCH CRS INTO @last_name, @first_name, @job_title, @id
	END
CLOSE CRS
DEALLOCATE CRS
SELECT * FROM #temp


---------------------------------------- EXO 8

--GO
--USE AdventureWorks2017

--DECLARE											--Variable qui vont contenir les informations de chaque ligne à chaque itération du curseur
--	@id INT,
--	@first_name NVARCHAR(100),
--	@last_name NVARCHAR(100),
--	@job_title NVARCHAR(100)

--CREATE TABLE #myTable(
--	id INT,
--	first_name NVARCHAR(100),
--	last_name NVARCHAR(100),
--	job_title NVARCHAR(100)
--	)

--DECLARE crs CURSOR FOR							--On remplit un curseur avec une requête/table

--SELECT 
--	P.BusinessEntityID, 
--	P.FirstName, 
--	P.LastName, 
--	E.JobTitle
--FROM Person.Person AS P JOIN HumanResources.Employee AS E 
--ON P.BusinessEntityID = E.BusinessEntityID

--OPEN crs										-- Ouvrir le curseur 

--FETCH crs INTO 	@id, @first_name, @last_name, @job_title	-- Fetch initial 

--WHILE(@@FETCH_STATUS = 0)
--	BEGIN
--		IF @job_title = 'Production Technician - WC60'
--			BEGIN
--				FETCH crs INTO @id, @first_name, @last_name, @job_title
--			END
--	END

--CLOSE crs										-- Ferme le curseur 

--DEALLOCATE crs									-- Libérer la mémoire

--USE AdventureWorks2017
--SELECT * FROM HumanResources.Employee


---------------------------------- EXO 12

GO

USE AdventureWorks2017

CREATE TABLE #final_product(
	ProductID INT,
	ProductName NVARCHAR(100),
	LastPrice FLOAT,
	LastDate DATETIME,
	)

DECLARE AP CURSOR FOR -- AP = All Products
SELECT ProductID, Name FROM Production.Product

DECLARE 
	@AP_ProductID INT,
	@AP_Name NVARCHAR(50)

DECLARE LP CURSOR FOR  -- LP = LastPrice
SELECT ProductID, StartDate, StandardCost
FROM Production.ProductCostHistory AS PCH
WHERE StartDate = (
	SELECT MAX(StartDate)
	FROM Production.ProductCostHistory AS PCH2
	WHERE PCH2.ProductID = PCH.ProductID
) -- Sous requête corrélées 

DECLARE 
	@LP_ProductID INT,
	@LP_StartDate DATETIME,
	@LP_StandardCost FLOAT

OPEN AP
FETCH AP INTO @AP_ProductID, @AP_Name

WHILE @@FETCH_STATUS = 0
	BEGIN
		OPEN LP 
		FETCH LP INTO @LP_ProductID, @LP_StartDate, @LP_StandardCost
			WHILE @@FETCH_STATUS = 0
				BEGIN 
					IF @AP_ProductID = @LP_ProductID
						BEGIN
							INSERT INTO #final_product VALUES (@AP_ProductID, @AP_Name, @LP_StandardCost, @LP_StartDate)
						END
					FETCH LP INTO @LP_ProductID, @LP_StartDate, @LP_StandardCost
				END
		FETCH AP INTO @AP_ProductID, @AP_Name
		CLOSE LP
	END
CLOSE AP
DEALLOCATE AP
DEALLOCATE LP

SELECT * FROM #final_product

DROP TABLE #final_product