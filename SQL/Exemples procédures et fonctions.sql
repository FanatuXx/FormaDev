
-- Fonction sans paramètre
CREATE OR ALTER FUNCTION fn_NombreProduits()
RETURNS INT
AS
BEGIN
	DECLARE @total INT;
 
	SELECT @total = COUNT(*) 
	FROM Production.Product
 
	RETURN @total
END
 
GO
 
SELECT [dbo].[fn_NombreProduits](), GETDATE()
 
GO

-- Fonction AVEC parametres
GO 
CREATE OR ALTER FUNCTION fn_CA_ParEmployee(
	@SalesPersonId INT, -- parametre 1
	@year INT -- parametre 2
	)
RETURNS FLOAT
AS
BEGIN
	DECLARE @total FLOAT;

	SELECT @total = SUM(SubTotal)
	FROM Sales.SalesOrderHeader 
	WHERE 
		SalesPersonID = @SalesPersonId
		AND YEAR(OrderDate) = @year

	RETURN @total
END


GO
SELECT dbo.fn_CA_ParEmployee(279, 2013)

---- procédure


GO
CREATE OR ALTER PROCEDURE usp_CommandesClient
	@CustomerId INT
AS
BEGIN

	SELECT DISTINCT CustomerID, SalesOrderID
	FROM Sales.SalesOrderHeader
	WHERE CustomerID = @CustomerId
END


GO
EXEC usp_CommandesClient 11000


-- Procédure avec parametre customerID, commandes et CA
GO
CREATE OR ALTER PROCEDURE sp_getClientStat
	@CustomerId INT,
	@NbCommande INT OUTPUT,
	@CA INT OUTPUT
AS 
BEGIN
	SELECT @CA = SUM(SubTotal), @NbCommande = COUNT(SalesOrderID)
	FROM Sales.SalesOrderHeader
	WHERE CustomerID = 11000
END


GO
DECLARE 
	@CustomerID INT = 11000,
	@NbCommande INT,
	@CA INT

EXEC sp_getClientStat
	@CustomerID,
	@NbCommande OUTPUT,
	@CA OUTPUT

SELECT @NbCommande, @CA



GO
CREATE TYPE product_list AS TABLE(
	id INT)

GO
CREATE PROCEDURE sp_GetProductList
	@Products product_list READONLY
AS

BEGIN

	SELECT ProductID, Name, ListPrice
	FROM Production.Product AS P
	WHERE ProductID IN (
		SELECT id FROM @Products
		)
END


GO
DECLARE @Products product_list;

INSERT INTO @Products VALUES (1), (2), (3), (4)

EXEC sp_GetProductList @Products


----------------------------------------------- EXO MODULE 5


