--	Write a Procedure supplying name information from the Person.Person table and accepting a filter for the first name.
--	Alter the above Store Procedure to supply Default Values if user does not enter any value.( Use AdventureWorks)


--SELECT * FROM Person.Person;
GO
CREATE PROCEDURE Person.up_getNameByType
	@Type nchar(2)='IN'
AS
	SELECT FirstName
	FROM Person.Person
	WHERE PersonType=@Type
GO


--	EXECUTE Person.up_getNameByType;   --FOR DEFAULT TYPE =IN --273 ROWS
--	EXECUTE Person.up_getNameByType @Type ='SC';  -- 753 ROWS
--	EXECUTE Person.up_getNameByType @Type ='EM';  -- 273 ROWS
--	EXECUTE Person.up_getNameByType @Type ='GC';  -- 289 ROWS

