PRINT('Le T-SQL, c''est bien pratique !')

--------------------------------------
GO
DECLARE @variable NVARCHAR(100)
SET @variable = 'Le T-SQL, c''est bien pratique !'
PRINT(@variable)

--------------------------------------
GO
USE AdventureWorks2017

DECLARE @nb_employees INT 
SELECT @nb_employees = COUNT(*) FROM Person.Person 
PRINT(@nb_employees)

--------------------------------------
GO
DECLARE @prenom_emp NVARCHAR(50)
SELECT FirstName FROM Person.Person
WHERE LastName = 'Eminhizer'
PRINT(@prenom_emp)

--------------------------------------
GO
DECLARE @x INT, @y INT, @z NVARCHAR
SET @z = @x + @y
PRINT(@z)

--------------------------------------
GO
DECLARE @a NVARCHAR(50), @b NVARCHAR(50), @c INT
SET @a = 'La valeur de '
SET @b = @a + '@c ' + 'est '
SET @c = 50
PRINT(@b + CAST(@c AS NVARCHAR(50)))

---------------------------------------
GO
DECLARE @date_du_jour DATETIME 
SET @date_du_jour = GETDATE()
PRINT(@date_du_jour)

----------------------------------------
GO
DECLARE 
	@lastName NVARCHAR(50), 
	@firstName NVARCHAR(50), 
	@id INT, 
	@date_of_entry DATETIME, 
	@gender NVARCHAR(50)

SELECT 
	@id = P.BusinessEntityID, 
	@firstName = P.FirstName, 
	@lastName = P.LastName, 
	@date_of_entry = E.HireDate,
	@gender = 
		CASE E.Gender 
			WHEN 'F' THEN 'femme' 
			WHEN 'M' THEN 'homme' 
		END
FROM Person.Person AS P JOIN HumanResources.Employee AS E ON P.BusinessEntityID = E.BusinessEntityID
WHERE P.BusinessEntityID = 100

PRINT(
	CONCAT('M. ', @lastName, ' ', @firstName, ' est l''employé numéro ', @id,
	'. Il a été engagé le ', @date_of_entry, ' et est un ', @gender))


----------------------------------------
GO
DECLARE @age INT, @name NVARCHAR(50)
SET @age = 28
SET @name = 'Antoine'
-- PRINT(CAST(@age AS NVARCHAR(50)) + @name)
PRINT(CONVERT(NVARCHAR(50), @age) + @name)

---------------------------------------- 
GO
DECLARE @var1 INT = 0, @var2 INT = 3, @var3 INT = 6, @sum INT
DECLARE @table1 TABLE (
	Resultat INT
);

SET @sum = @var1 + @var2 + @var3

INSERT INTO @table1 SELECT @sum

SELECT * FROM @table1

-----------------------------------------
GO
USE AdventureWorks2017

DECLARE  
@id INT, 
@birth_date DATETIME, 
@job_title NVARCHAR(50)

SELECT @id = BusinessEntityID, @job_title = JobTitle, @birth_date = BirthDate 
FROM HumanResources.Employee

PRINT(CAST(@id AS NVARCHAR(10)) + ' ' + @job_title + ' ' + CAST(@birth_date AS NVARCHAR(50)))

----------------------------------------- 14
GO

DECLARE @my_emp TABLE(
	job_title NVARCHAR(50),
	date_embauche DATETIME,
	h_mal INT,
	h_vac INT
	)

INSERT INTO @my_emp SELECT JobTitle, HireDate, VacationHours, SickLeaveHours
FROM HumanResources.Employee
WHERE JobTitle = 'Production Technician - WC60'

SELECT * FROM @my_emp
 ----------------------------------------- 14 v2

SELECT JobTitle, HireDate, VacationHours, SickLeaveHours INTO #my_emp
FROM HumanResources.Employee
WHERE JobTitle = 'Production Technician - WC60'

SELECT * FROM #my_emp

---------------------------------------- 14 v3

CREATE TABLE #my_emp2 (
	job_title NVARCHAR(50),
	date_embauche DATETIME,
	h_mal INT,
	h_vac INT
	)

INSERT INTO #my_emp2
SELECT JobTitle, HireDate, VacationHours, SickLeaveHours
FROM HumanResources.Employee
WHERE JobTitle = 'Production Technician - WC60'

SELECT * FROM #my_emp2

---------------------------------------- 15

CREATE TABLE #my_friends (
	month INT,
	last_name VARCHAR(20),
	residence VARCHAR(50)
	)

INSERT INTO #my_friends (month, last_name, residence) VALUES 
	(6, 'nico1', 'Namur'),
	(7, 'nico2', 'Namur'),
	(8, 'nico3', 'Namur'),
	(9, 'nico4', 'Namur'),
	(10, 'nico5', 'Namur')

DECLARE @my_firends_var TABLE (
	month INT,
	last_name VARCHAR(20),
	residence VARCHAR(50)
	)

INSERT INTO @my_firends_var SELECT * FROM #my_friends
SELECT * FROM @my_firends_var

UPDATE #my_friends SET residence = 'BXL' Where last_name = 'nico1'
UPDATE #my_friends SET residence = 'BXL' Where last_name = 'nico2'

SELECT * FROM @my_firends_var

--------------------------------------------------------------
DECLARE @wc TABLE (
	last_name NVARCHAR(50),
	first_name NVARCHAR(50),
	person_type NVARCHAR(50)
	)

INSERT INTO @wc

SELECT LastName, FirstName, PersonType
FROM Person.Person
WHERE BusinessEntityID IN
	(SELECT BusinessEntityID 
	FROM HumanResources.Employee 
	WHERE JobTitle = 'Production Technician - WC60')

SELECT * FROM @wc

