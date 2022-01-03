--	Write separate queries using a join, a subquery, a CTE,
--	and then an EXISTS to list all AdventureWorks customers who have not placed an order.

--	Using Joins

SELECT c.CustomerID AS 'CustomerID'
FROM Sales.SalesOrderHeader soh
RIGHT JOIN Sales.Customer c ON 
soh.CustomerID=c.CustomerID
WHERE SalesOrderID IS NULL;

--	Using Subquery

SELECT c.CustomerID
FROM Sales.Customer c 
WHERE c.CustomerID NOT IN (SELECT CustomerID FROM Sales.SalesOrderHeader);

--	Using CTE

WITH CustomerNotPlacedOrder(CustomerID)
AS
(
	SELECT c.Customerid
	FROM Sales.SalesOrderHeader soh
	RIGHT JOIN Sales.Customer c ON soh.CustomerID = c.CustomerID
	WHERE SalesOrderID IS NULL
)
SELECT * FROM CustomerNotPlacedOrder;

-- Using Exist

SELECT c.CustomerID
FROM Sales.Customer c
WHERE NOT EXISTS (SELECT s.CustomerID
					FROM Sales.SalesOrderHeader AS s
					WHERE s.CustomerID = c.CustomerID);