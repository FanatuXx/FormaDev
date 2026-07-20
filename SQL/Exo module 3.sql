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
DECLARE @anciennete INT

SELECT 
	@anciennete = CAST(GETDATE() - Year(HireDate) AS INT)

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


-----------------------------------------------------------
GO

DECLARE @nb_men INT, @nb_women INT

SELECT 
	@nb_men = COUNT(CASE WHEN Gender = 'M' THEN 1 END), 
	@nb_women = COUNT(CASE WHEN Gender = 'F' THEN 1 END)
FROM HumanResources.Employee

--SELECT @nb_men = COUNT(*)
--FROM HumanResources.Employee 
--WHERE Gender = 'M'

--SELECT @nb_women = COUNT(*)
--FROM HumanResources.Employee 
--WHERE Gender = 'F'

--IF @nb_women > @nb_men 
--	BEGIN
--		'Les femmes domineront le monde !')
--	END
--ELSE
--	BEGIN
--		PRINT('La guerre des sexes n''est pas finie…')
--	END

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


IF @maladie_p21 + @repos_p21 > @maladie_p27 + @repos_p27 OR @maladie_p21 + @repos_p21 < @maladie_p27 + @repos_p27
	BEGIN
	END





