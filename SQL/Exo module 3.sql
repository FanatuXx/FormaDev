DECLARE @nb INT = 25

IF @nb < 20 
	BEGIN 
		PRINT('Le nb est inférieur à 20')
		SELECT * FROM Person.Person 
	END
ELSE
	BEGIN 
		PRINT('Le nb est sûpérieur à 20')
		SELECT * FROM Production.Product
	END

SELECT 
	BusinessEntityID, 
	Gender,
	CASE Gender 
		WHEN 'M' THEN 'Male'
		WHEN 'F' THEN 'Female'
	END,

	CASE 
		WHEN Year(BirthDate) > 2000 THEN 'jeune'
		WHEN Year(BirthDate) > 1980 THEN 'encore jeune'
		ELSE 'c''est bientot la fin'
	END,

	IIF(Gender = 'M', 'Male', 'Female')

FROM HumanResources.Employee

----------------------------------------------------------
GO
DECLARE @anciennete INT

SELECT 
	@anciennete = DATEDIFF (YEAR, HireDate, GETDATE()) 
FROM HumanResources.Employee
WHERE BusinessEntityID = 21

IF @anciennete > 9 
	BEGIN 
		PRINT('L''employé 21 est un Senior')
	END
ELSE 
	BEGIN 
		PRINT('L''employé 21 est un Junior')
	END

----------------------------------------------------------
GO
DECLARE @isListed bit 

SELECT @isListed =
	CASE 
		WHEN LastName is NOT NULL THEN 1
	ELSE 0
	END

FROM Person.Person 
WHERE LastName = 'Zugelder'

PRINT(@isListed)

IF @isListed = 1
	BEGIN 
		SELECT 
			FirstName,
			MiddleName,
			LastName
		FROM Person.Person
		WHERE LastName = 'Zugelder'
	END
ELSE 
	BEGIN 
		PRINT('Il n''existe personne portant ce nom !')
	END


-- CORRECTION :
GO
DECLARE 
	@last_name NVARCHAR(50),
	@first_name NVARCHAR(50),
	@middle_name NVARCHAR(50)

-- SELECT * FROM Person.Person WHERE LastName LIKE 'Zugelder'

IF EXISTS(SELECT * FROM Person.Person WHERE LastName LIKE 'Zugelder')
	BEGIN
		SELECT 
			@first_name = FirstName,
			@middle_name = MiddleName,
			@last_name = LastName 
		FROM Person.Person WHERE LastName LIKE 'Zugelder'
		PRINT(CONCAT(@first_name, ' ', @middle_name, ' ', @last_name))
	END
ELSE 
	BEGIN
		PRINT('Pas de Zugelder ici')
	END

-----------------------------------------------------------
GO

DECLARE @nb_men INT, 
		@nb_women INT

SELECT 
	@nb_men = COUNT(CASE Gender WHEN 'M' THEN 1 END), 
	@nb_women = COUNT(CASE Gender WHEN 'F' THEN 1 END)
FROM HumanResources.Employee

IF @nb_women > @nb_men 
	BEGIN
		PRINT('Les femmes domineront le monde !')
	END
ELSE
	BEGIN
		PRINT('La guerre des sexes n''est pas finie…')
	END


------------------------------------
DECLARE @maladie_p21 INT, @maladie_p27 INT, @repos_p21 INT, @repos_p27 INT

SELECT 
	@maladie_p21 = 
		CASE 
			WHEN BusinessEntityID = 21 THEN SickLeaveHours END,
	@maladie_p27 = 
		CASE 
			WHEN BusinessEntityID = 27 THEN SickLeaveHours END,
	@repos_p21 = 
		CASE 
			WHEN BusinessEntityID = 21 THEN VacationHours END,
	@repos_p27 = 
		CASE 
			WHEN BusinessEntityID = 27 THEN VacationHours END
FROM HumanResources.Employee


IF @maladie_p21 + @repos_p21 > @maladie_p27 + @repos_p27 -- OR @maladie_p21 + @repos_p21 < @maladie_p27 + @repos_p27
	BEGIN
		PRINT('Attention ! Le nombre d''heure de repos ET de maladie de l''employé 21 est plus grand que celui de l''employé 27.')
	END

ELSE IF @maladie_p21 > @maladie_p27 AND @repos_p21 < @repos_p27
	BEGIN 
		PRINT('Tout va bien !')
	END 

------------------------------------------------- Exo 3.8
GO

DECLARE @nb_employees INT,
		@nb_employees80_90 INT

SELECT @nb_employees = COUNT(*) FROM HumanResources.Employee WHERE YEAR(BirthDate) < 1975
SELECT @nb_employees80_90 = COUNT(*) FROM HumanResources.Employee WHERE YEAR(BirthDate) BETWEEN 1980 AND 1990

IF @nb_employees > 20 OR @nb_employees80_90 > 20
	BEGIN 
		SELECT 
			BusinessEntityID, 
			YEAR(BirthDate) AS BirthYear,
			SickLeaveHours,
			VacationHours,

			CASE 
				WHEN SickLeaveHours + VacationHours BETWEEN 60 AND 80 THEN 'Dans la norme'
				WHEN SickLeaveHours + VacationHours BETWEEN 40 AND 60 THEN 'Bons éléments'
				ELSE 'A réviser'
			END AS status_employee --Donne un nom à la colonne créée par le case 
		INTO #temp -- Crée la table temporaire 
		FROM HumanResources.Employee WHERE YEAR(BirthDate) < 1975 OR YEAR(BirthDate) BETWEEN 1980 AND 1990
	END

SELECT * FROM #temp

DROP TABLE #temp








