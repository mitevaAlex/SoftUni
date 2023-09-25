USE Bank

--exer 1
CREATE TABLE Logs
(
	LogId INT PRIMARY KEY IDENTITY,
	AccountId INT NOT NULL, 
	OldSum MONEY NOT NULL, 
	NewSum MONEY NOT NULL
) 

CREATE TRIGGER tr_LogSumChange
ON Accounts FOR UPDATE
AS
	INSERT INTO Logs
	SELECT i.AccountHolderId, d.Balance, i.Balance 
	FROM inserted AS i
	JOIN deleted AS d ON d.Id = i.Id

--exer 2
CREATE TABLE NotificationEmails
(
	Id INT PRIMARY KEY IDENTITY,
	Recipient INT NOT NULL, 
	[Subject] VARCHAR(40) NOT NULL, 
	Body VARCHAR(100) NOT NULL
) 

CREATE TRIGGER tr_CreateEmailOnNewLog
ON Logs FOR INSERT
AS
	INSERT INTO NotificationEmails
	SELECT 
		i.AccountId, 
		CONCAT('Balance change for account: ', i.AccountId),
		CONCAT('On ', GETDATE(),' your balance was changed from ', i.OldSum,' to ', i.NewSum,'.')
	FROM inserted AS i

--exer 3
CREATE OR ALTER PROC usp_DepositMoney(@accountId INT, @moneyAmount DECIMAL(14, 4)) 
AS
BEGIN TRANSACTION
	UPDATE Accounts
	SET Balance += @moneyAmount
	WHERE Id = @accountId

	IF(@moneyAmount <= 0)
	BEGIN
		ROLLBACK
		RETURN
	END
COMMIT

EXEC dbo.usp_DepositMoney 1, 10
EXEC dbo.usp_DepositMoney -1, 10
EXEC dbo.usp_DepositMoney NULL, 10
EXEC dbo.usp_DepositMoney 1, -10
EXEC dbo.usp_DepositMoney 23, 10

--exer 4
CREATE OR ALTER PROC usp_WithdrawMoney(@accountId INT, @moneyAmount DECIMAL(14, 4)) 
AS
BEGIN TRANSACTION
	UPDATE Accounts
	SET Balance -= @moneyAmount
	WHERE Id = @accountId

	IF(@moneyAmount <= 0)
	BEGIN
		ROLLBACK
		RETURN
	END
COMMIT

EXEC dbo.usp_WithdrawMoney 1, 10

--exer 5
CREATE OR ALTER PROC usp_TransferMoney(@senderId INT, @receiverId INT, @amount DECIMAL(14, 4)) 
AS
BEGIN TRANSACTION
	EXEC dbo.usp_WithdrawMoney @senderId, @amount
	EXEC dbo.usp_DepositMoney @receiverId, @amount
	IF(@amount <= 0)
	BEGIN
		ROLLBACK
		RETURN
	END
COMMIT

EXEC dbo.usp_TransferMoney 5, 1, 5000

--exer 6
--not included in judge

--exer 7


--exer 8
USE SoftUniCRUD

CREATE PROC usp_AssignProject(@emloyeeId INT, @projectID INT) 
AS
BEGIN TRANSACTION
	INSERT INTO EmployeesProjects VALUES (@emloyeeId, @projectID)
	DECLARE @projectsCount INT  = (SELECT COUNT(*) FROM EmployeesProjects
		WHERE EmployeeID = @emloyeeId)
	IF(@projectsCount > 3) 
	BEGIN
		ROLLBACK;
		THROW 50001, 'The employee has too many projects!', 1
		RETURN
	END
COMMIT

--exer 9
CREATE TABLE Deleted_Employees
(
	EmployeeId INT PRIMARY KEY NOT NULL,
	FirstName VARCHAR(50) NOT NULL, 
	LastName VARCHAR(50) NOT NULL, 
	MiddleName VARCHAR(50) NOT NULL, 
	JobTitle VARCHAR(50) NOT NULL, 
	DepartmentId INT NOT NULL, 
	Salary MONEY NOT NULL
) 

CREATE TRIGGER tr_InsertIntoDeletedAfterDelete
ON Employees FOR DELETE
AS
	INSERT INTO Deleted_Employees
	SELECT 
		EmployeeID, 
		FirstName, 
		LastName, 
		MiddleName, 
		JobTitle, 
		DepartmentID, 
		Salary 
	FROM deleted