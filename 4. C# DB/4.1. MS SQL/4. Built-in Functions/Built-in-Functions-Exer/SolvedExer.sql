USE SoftUniCRUD

--exer 1
SELECT FirstName, LastName FROM Employees
WHERE LEFT(FirstName, 2) = 'Sa'

--exer 2
SELECT FirstName, LastName FROM Employees
WHERE CHARINDEX('ei', LastName) > 0

--exer 3
SELECT FirstName FROM Employees
WHERE DepartmentId IN (3, 10) AND YEAR(HireDate) BETWEEN 1995 AND 2005

--exer 4
SELECT FirstName, LastName FROM Employees
WHERE CHARINDEX('engineer', JobTitle) = 0

--exer 5
SELECT [Name] FROM Towns
WHERE LEN([Name]) IN (5, 6)
ORDER BY [Name]

--exer 6
SELECT TownID, [Name] FROM Towns
WHERE LEFT([Name], 1) IN ('M', 'K', 'B', 'E')
ORDER BY [Name]

--exer 7
SELECT TownID, [Name] FROM Towns
WHERE LEFT([Name], 1) NOT IN ('R', 'B', 'D')
ORDER BY [Name]

--exer 8
CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT FirstName, LastName FROM Employees
WHERE YEAR(HireDate) > 2000

SELECT * FROM V_EmployeesHiredAfter2000

--exer 9
SELECT FirstName, LastName FROM Employees
WHERE LEN(lastName) = 5

--exer 10 
SELECT EmployeeID, 
	   FirstName, 
	   LastName, 
	   Salary, 
	   DENSE_RANK() OVER   
       (PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
FROM Employees
WHERE Salary BETWEEN 10000 AND 50000
ORDER BY Salary DESC

--exer 11
SELECT * FROM (
	SELECT EmployeeID, 
		   FirstName, 
	       LastName, 
	       Salary, 
	       DENSE_RANK() OVER   
           (PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
    FROM Employees) AS a
WHERE a.Salary BETWEEN 10000 AND 50000 AND a.[Rank] = 2
ORDER BY a.Salary DESC

--exer 12
USE Geography

SELECT CountryName, IsoCode FROM Countries
WHERE LEN(CountryName) - LEN(REPLACE(UPPER(CountryName), 'A', '')) >= 3
ORDER BY IsoCode

--exer 13
SELECT * FROM (
SELECT p.PeakName, r.RiverName, LOWER(CONCAT(p.PeakName, RIGHT(r.RiverName, LEN(r.RiverName) - 1))) AS Mix 
FROM Peaks AS p
JOIN Rivers AS r ON LEFT(r.RiverName, 1) = RIGHT(p.PeakName, 1)) AS a
ORDER BY a.Mix

--exer 14
USE Diablo

SELECT TOP(50) [Name], FORMAT([Start], 'yyyy-MM-dd') AS [Start] FROM Games
WHERE YEAR([Start]) BETWEEN 2011 AND 2012
ORDER BY [Start], [Name]

--exer 15
SELECT Username,  
	RIGHT(Email, LEN(Email) - CHARINDEX('@', Email)) AS [Email Provider] 
FROM Users
ORDER BY [Email Provider], Username

--exer 16
SELECT Username, IpAddress AS [IP Address] FROM Users
WHERE IpAddress LIKE '___.1_%._%.___'
ORDER BY Username

--exer 17
SELECT [Name] AS Game,
	   [Part of the Day] = CASE 
	   WHEN DATEPART(hour, [Start]) >= 0 AND DATEPART(hour, [Start]) < 12 THEN 'Morning'
	   WHEN DATEPART(hour, [Start]) >= 12 AND DATEPART(hour, [Start]) < 18 THEN 'Afternoon'
	   WHEN DATEPART(hour, [Start]) >= 18 AND DATEPART(hour, [Start]) < 24 THEN 'Evening'
	   END,
	   Duration = CASE
	   WHEN Duration <= 3 THEN 'Extra Short'
	   WHEN Duration BETWEEN 4 AND 6 THEN 'Short'
	   WHEN Duration > 6 THEN 'Long'
	   WHEN Duration IS NULL THEN 'Extra Long'
	   END
FROM Games
ORDER BY [Name], Duration, [Part of the Day]

--exer 18
USE Orders

SELECT ProductName, 
	   OrderDate,
	   DATEADD(day, 3, OrderDate) AS [Pay Due],
	   DATEADD(month, 1, OrderDate) AS [Deliver Due]
FROM Orders

--exer 19
CREATE DATABASE BuiltInFunc

USE BuiltInFunc

CREATE TABLE People
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(20) NOT NULL,
	Birthdate DATE NOT NULL
)

INSERT INTO People VALUES
('Victor',	'2000-12-07'),
('Steven', '1992-09-10'),
('Stephen', '1910-09-19'),
('John', '2010-01-06')

SELECT [Name],
	   DATEDIFF(year, Birthdate, GETDATE()) AS [Age in Years],
	   DATEDIFF(month, Birthdate, GETDATE()) AS [Age in Months],
	   DATEDIFF(day, Birthdate, GETDATE()) AS [Age in Days],
	   DATEDIFF(minute, Birthdate, GETDATE()) AS [Age in Minutes]
FROM People


