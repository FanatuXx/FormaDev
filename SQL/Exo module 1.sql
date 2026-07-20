CREATE DATABASE test;
GO
-- Sert à séquencer l'execution du code ! Ici, on dit au programme d'attendre de créer la DB AVANT de l'utiliser.

USE test;
GO

CREATE TABLE test_table (
	id INT,
	nom NVARCHAR(50)
)

SELECT GETDATE() AS heure INTO #TEMP

SELECT * FROM #TEMP

USE AdventureWorks2017 
SELECT * INTO #product FROM Production.Product

SELECT * FROM #product

DECLARE @query NVARCHAR(500) = 'SELECT * FROM Person.Person'

EXEC(@query)

SELECT * 
FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS

PRINT('test')

DECLARE @text NVARCHAR(500) = 'Hello tout le monde'
PRINT(@text)

SELECT @@VERSION

------------------------------ EXO's 1.1
USE test

CREATE TABLE table_1(
	id INT IDENTITY(1, 1)
)

CREATE DATABASE MyDbExo;

USE MyDbExo;

CREATE TABLE test(
	firstname NVARCHAR(50) UNIQUE,
	surname NVARCHAR(50)
)

PRINT('Bonjour, et bienvenue dans le cours de Transact SQL !')

SELECT 'Bonjour, et bienvenue dans le cours de Transact SQL !' AS message INTO #tempo

SELECT * FROM #tempo

INSERT INTO MyDbExo.dbo.test
VALUES ('Béranger')

SELECT * FROM MyDbExo.dbo.test

DECLARE @test3 NVARCHAR(100) 
SET @test3 = CAST ( 'SELECT * FROM MyDbExo.dbo.test' AS NVARCHAR(100))