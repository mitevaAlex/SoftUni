USE SoftUniCRUD

--exer 1
CREATE PROC usp_GetEmployeesSalaryAbove35000 
AS
	SELECT FirstName, LastName 
	FROM Employees
	WHERE Salary > 35000

EXEC dbo.usp_GetEmployeesSalaryAbove35000 

--exer 2
CREATE PROC usp_GetEmployeesSalaryAboveNumber(@MinSalary DECIMAL(18,4))
AS
	SELECT FirstName, LastName FROM Employees
	WHERE Salary >= @MinSalary

EXEC dbo.usp_GetEmployeesSalaryAboveNumber 48100

--exer 3
CREATE PROC usp_GetTownsStartingWith(@StartString VARCHAR(15))
AS
	SELECT [Name] AS Town FROM Towns
	WHERE LEFT([Name], LEN(@StartString)) = @StartString

EXEC dbo.usp_GetTownsStartingWith 'b'

--exer 4
CREATE PROC usp_GetEmployeesFromTown(@TownName VARCHAR(50))
AS
	SELECT FirstName, LastName FROM Employees AS e 
	JOIN Addresses AS a ON a.AddressID = e.AddressID
	JOIN Towns AS t ON t.TownID = a.TownID
	WHERE t.[Name] = @TownName

EXEC dbo.usp_GetEmployeesFromTown Sofia

--exer 5
CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4)) 
RETURNS VARCHAR(10)
AS
BEGIN
	DECLARE @SalaryLevel VARCHAR(10) 

	IF(@salary < 30000)
		SET @SalaryLevel = 'Low'
	ELSE IF(@salary <= 50000)
		SET @SalaryLevel = 'Average'
	ELSE
		SET @SalaryLevel = 'High'

	RETURN @SalaryLevel
END

SELECT 
	Salary, 
	dbo.ufn_GetSalaryLevel(Salary) AS [Salary Level]
FROM Employees

--exer 6
CREATE PROC usp_EmployeesBySalaryLevel(@SalaryLevel VARCHAR(10))
AS
	SELECT FirstName, LastName FROM Employees
	WHERE dbo.ufn_GetSalaryLevel(Salary) = @SalaryLevel

EXEC dbo.usp_EmployeesBySalaryLevel 'High'

--exer 7
CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(50), @word VARCHAR(50))
RETURNS BIT
AS
BEGIN
	DECLARE @Counter INT = 1
	WHILE (@Counter <= LEN(@word))
	BEGIN
		IF(CHARINDEX(SUBSTRING(@word, @Counter, 1), @setOfLetters) = 0)
			RETURN 0
		SET @Counter += 1
	END
	RETURN 1
END	

SELECT dbo.ufn_IsWordComprised('oistmiahf', 'Sofia')
SELECT dbo.ufn_IsWordComprised('oistmiahf', 'halves')
SELECT dbo.ufn_IsWordComprised('bobr', 'Rob')
SELECT dbo.ufn_IsWordComprised('pppp', 'Guy')

--exer 8
CREATE PROC usp_DeleteEmployeesFromDepartment(@departmentId INT) 
AS
BEGIN
	DELETE FROM EmployeesProjects
	WHERE EmployeeID IN (SELECT EmployeeID FROM Employees 
		WHERE DepartmentID = @departmentId)

	UPDATE Employees
	SET ManagerID = NULL
	WHERE ManagerID IN (SELECT EmployeeID FROM Employees 
		WHERE DepartmentID = @departmentId)

	ALTER TABLE Departments
	ALTER COLUMN ManagerId INT NULL

	UPDATE Departments
	SET ManagerID = NULL
	WHERE ManagerID IN (SELECT EmployeeID FROM Employees 
		WHERE DepartmentID = @departmentId)

	DELETE FROM Employees 
	WHERE DepartmentID = @departmentId

	DELETE FROM Departments
	WHERE DepartmentID = @departmentId

	SELECT COUNT(*) FROM Employees
	WHERE DepartmentID = @departmentId
END

--exer 9
USE Bank

CREATE PROC usp_GetHoldersFullName
AS
	SELECT CONCAT(FirstName,' ', LastName) AS [Full Name] FROM AccountHolders

EXEC dbo.usp_GetHoldersFullName

--exer 10
CREATE PROC usp_GetHoldersWithBalanceHigherThan(@MinBalance MONEY)
AS
	SELECT FirstName, LastName FROM AccountHolders AS ah
	JOIN Accounts AS a ON a.AccountHolderId = ah.Id
	GROUP BY a.AccountHolderId, ah.FirstName, ah.LastName
	HAVING SUM(a.Balance) > @MinBalance
	ORDER BY ah.FirstName, ah.LastName

EXEC dbo.usp_GetHoldersWithBalanceHigherThan 200000

--exer 11
CREATE FUNCTION ufn_CalculateFutureValue(@sum DECIMAL(12, 2), @yearlyInterestRate FLOAT, @years INT)
RETURNS DECIMAL(14, 4)
AS
BEGIN
	RETURN @sum * POWER(1 + @yearlyInterestRate, @years)
END

SELECT dbo.ufn_CalculateFutureValue(1000, 0.1, 5)

--exer 12
CREATE PROC usp_CalculateFutureValueForAccount(@accountId INT, @yearlyInterestRate FLOAT)
AS
BEGIN
	SELECT TOP(1)
		ah.Id AS [Account Id],
		ah.FirstName AS [First Name],
		ah.LastName AS [Last Name],
		a.Balance AS [Current Balance],
		dbo.ufn_CalculateFutureValue(a.Balance, @yearlyInterestRate, 5) AS [Balance in 5 years]
	FROM AccountHolders AS ah
	JOIN Accounts AS a ON a.AccountHolderId = ah.Id
	WHERE ah.Id = @accountId
END

EXEC dbo.usp_CalculateFutureValueForAccount 1, 0.1

--exer 13
USE Diablo

CREATE FUNCTION ufn_CashInUsersGames(@gameName NVARCHAR(50))
RETURNS TABLE
AS
RETURN
(
	SELECT SUM(Cash) AS SumCash FROM
	(
		SELECT 
			Cash,
			ROW_NUMBER() OVER(ORDER BY Cash DESC) AS RowNumber
		FROM UsersGames
		JOIN Games AS g ON g.Id = GameId
		WHERE g.[Name] = @gameName
	) AS a
	WHERE RowNumber % 2 = 1
)

SELECT * FROM dbo.ufn_CashInUsersGames('Love in a mist')