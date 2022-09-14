--1.	Display the number of records in the [SalesPerson] table. (Schema(s) involved: Sales)
SELECT COUNT(*) AS 'NumberOfRecords'
FROM Sales.SalesPerson;

--2.	Select both the FirstName and LastName of records from the Person table 
--      where the FirstName begins with the letter ‘B’. (Schema(s) involved: Person)

SELECT FirstName ,LastName
FROM Person.Person 
WHERE FirstName LIKE 'B%';

--3.	Select a list of FirstName and LastName for employees where Title is one of 
--		Design Engineer, Tool Designer or Marketing Assistant. (Schema(s) involved: HumanResources, Person)

SELECT P.FirstName AS FirstName,P.LastName AS LastName
FROM Person.Person P
INNER JOIN HumanResources.Employee E ON
P.BusinessEntityID=E.BusinessEntityID
WHERE E.JobTitle IN ('Design Engineer', 'Tool Designer' ,'Marketing Assistant');


--4.	Display the Name and Color of the Product with the maximum weight. (Schema(s) involved: Production)

SELECT Name , COLOR
--,[Weight] 
FROM Production.Product 
WHERE [Weight] = (SELECT MAX([Weight]) FROM Production.Product);

SELECT TOP 1 Name,Color--,[Weight] 
FROM Production.Product ORDER BY [Weight] DESC;

--5.	Display Description and MaxQty fields from the SpecialOffer table.
--		Some of the MaxQty values are NULL, in this case display the value 0.00 instead. (Schema(s) involved: Sales)

SELECT Description,COALESCE(MaxQty,0.00)
FROM Sales.SpecialOffer;

--6.	Display the overall Average of the [CurrencyRate].[AverageRate] values for the exchange rate ‘USD’ to ‘GBP’
--		for the year 2005 i.e. FromCurrencyCode = ‘USD’ and ToCurrencyCode = ‘GBP’.
--		Note: The field [CurrencyRate].[AverageRate] is defined as 'Average exchange rate for the day.' 
--		(Schema(s) involved: Sales)

SELECT AVG(AverageRate) AS 'Average Exchange Rate For The Day'
FROM Sales.CurrencyRate
WHERE FromCurrencyCode='USD'
AND ToCurrencyCode='GBP'
AND YEAR(CurrencyRateDate)=2005;

--7.	Display the FirstName and LastName of records from the Person table where FirstName contains the letters ‘ss’. 
--		Display an additional column with sequential numbers for each row returned beginning at integer 1. (Schema(s) involved: Person)

SELECT FirstName +' '+LastName AS FullName,
	ROW_NUMBER() OVER (
		ORDER BY FirstName
	) AS Sequence
FROM Person.Person
WHERE FirstName LIKE '%ss%';

--8.	Sales people receive various commission rates that belong to 1 of 4 bands. (Schema(s) involved: Sales)
--		CommissionPct	Commission Band
--				0.00	Band 0
--			Up To 1%	Band 1
--			Up To 1.5%	Band 2
--		Greater 1.5%	Band 3
--		Display the [SalesPersonID] with an additional column entitled ‘Commission Band’ indicating the appropriate band as above.


SELECT BusinessEntityID,
CASE WHEN CommissionPct = 0.00 THEN 'BAND 0'
WHEN CommissionPct >0.00 AND CommissionPct<=1 THEN 'BAND 1'
WHEN CommissionPct >1 AND CommissionPct<=1.5 THEN 'BAND 2'
ELSE 'BAND 3'
END AS 'Commmision Band'
FROM Sales.SalesPerson;

--9.	Display the managerial hierarchy from Ruth Ellerbrock (person type – EM) up to CEO Ken Sanchez.
--		Hint: use [uspGetEmployeeManagers] (Schema(s) involved: [Person], [HumanResources]) 

DECLARE @ID int;
SELECT @ID = BusinessEntityID
FROM Person.Person
WHERE FirstName='Ruth'
AND LastName='Ellerbrock'
AND PersonType='EM';
EXECUTE dbo.uspGetEmployeeManagers @BusinessEntityID=@ID;

--10.	Display the ProductId of the product with the largest stock level. 
--		Hint: Use the Scalar-valued function [dbo]. [UfnGetStock]. (Schema(s) involved: Production)

SELECT MAX(dbo.ufnGetStock(ProductId)) AS 'ProductID' FROM Production.Product;
