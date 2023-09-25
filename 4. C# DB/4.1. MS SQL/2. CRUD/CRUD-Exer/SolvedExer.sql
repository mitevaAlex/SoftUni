--exer 2
USE SoftuniCRUD

SELECT * FROM Departments

--exer 3
SELECT [Name] FROM Departments

--exer 4
SELECT FirstName, LastName, Salary FROM Employees

--exer 5
SELECT FirstName, MiddleName, LastName FROM Employees

--exer 6
SELECT CONCAT(FirstName, '.',  LastName, '@softuni.bg')  AS [Full Email Address] FROM Employees

--exer 7
SELECT DISTINCT Salary FROM Employees

--exer 8
SELECT * FROM Employees
WHERE JobTitle = 'Sales Representative'

--exer 9
SELECT FirstName, LastName, JobTitle FROM Employees
WHERE Salary BETWEEN 20000 AND 30000

--exer 10
--for newer versions of SQL: SELECT CONCAT_WS(' ', FirstName, MiddleName, LastName) FROM Employees

SELECT CONCAT(FirstName, ' ', CONCAT(MiddleName, ' '), LastName) FROM Employees
WHERE Salary IN (25000, 14000, 12500, 23600)

--exer 11
SELECT FirstName, LastName FROM Employees
WHERE ManagerID IS NULL

--exer 12
SELECT FirstName, LastName, Salary FROM Employees
WHERE Salary > 50000
ORDER BY Salary DESC

--exer 13
SELECT TOP (5) FirstName, LastName FROM Employees
ORDER BY Salary DESC

--exer 14
SELECT FirstName, LastName FROM Employees
WHERE NOT DepartmentID = 4

--exer 15
SELECT * FROM Employees
ORDER BY Salary DESC, FirstName, LastName DESC, MiddleName

--exer 16
CREATE VIEW V_EmployeesSalaries AS
SELECT FirstName, LastName, Salary FROM Employees

SELECT * FROM V_EmployeesSalaries

--exer 17
CREATE VIEW V_EmployeeNameJobTitle AS
SELECT CONCAT(FirstName, ' ', CONCAT(MiddleName, ' '), LastName) AS [Full Name],
	   JobTitle AS [Job Title]
FROM Employees

SELECT * FROM V_EmployeeNameJobTitle		

--exer 18
SELECT DISTINCT JobTitle FROM Employees

--exer 19
SELECT TOP(10) * FROM Projects
ORDER BY StartDate, [Name]

--exer 20
SELECT TOP(7) FirstName, LastName, HireDate FROM Employees
ORDER BY HireDate DESC

--exer 21
UPDATE Employees
SET Salary *= 1.12
WHERE DepartmentID IN (1, 2, 4, 11)

SELECT Salary FROM Employees

UPDATE Employees
SET Salary /= 1.12
WHERE DepartmentID IN (1, 2, 4, 11)

--exer 22
USE [Geography]

SELECT PeakName FROM Peaks
ORDER BY PeakName

--exer 23
SELECT TOP(30) CountryName, [Population] FROM Countries
WHERE ContinentCode = 'EU'
ORDER BY [Population] DESC, CountryName

--exer 24
SELECT CountryName, 
	   CountryCode, 
	   [Currency] = CASE CurrencyCode  
         WHEN 'EUR' THEN 'Euro'
         ELSE 'Not Euro' 
	   END 
FROM Countries
ORDER BY CountryName

--exer 25
USE Diablo

SELECT [Name] FROM Characters
ORDER BY [Name]
