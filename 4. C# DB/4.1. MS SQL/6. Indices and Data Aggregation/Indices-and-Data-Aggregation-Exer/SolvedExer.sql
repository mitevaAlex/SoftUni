USE Gringotts

--exer 1
SELECT COUNT(*) AS [Count] FROM WizzardDeposits

--exer 2
SELECT MAX(MagicWandSize) AS LongestMagicWand FROM WizzardDeposits

--exer 3
SELECT 
	DepositGroup,
	MAX(MagicWandSize) AS LongestMagicWand 
FROM WizzardDeposits
GROUP BY DepositGroup

--exer 4
SELECT TOP(2) DepositGroup FROM
(
	SELECT 
		DepositGroup,
		AVG(MagicWandSize) AS AverageWandSize
	FROM WizzardDeposits
	GROUP BY DepositGroup
) AS AvgMagicWandSizeTable
ORDER BY AverageWandSize

--exer 5
SELECT 
	DepositGroup,
	SUM(DepositAmount) AS TotalSum 
FROM WizzardDeposits
GROUP BY DepositGroup

--exer 6
SELECT 
	DepositGroup,
	SUM(DepositAmount) AS TotalSum 
FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup

--exer 7
SELECT 
	DepositGroup,
	SUM(DepositAmount) AS TotalSum 
FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup
HAVING SUM(DepositAmount) < 150000
ORDER BY TotalSum DESC

--exer 8
SELECT 
	DepositGroup,
	MagicWandCreator,
	MIN(DepositCharge) AS MinDepositCharge 
FROM WizzardDeposits
GROUP BY DepositGroup, MagicWandCreator
ORDER BY MagicWandCreator, DepositGroup

--exer 9
SELECT 
	AgeGroup, 
	COUNT(Age) AS WizardCount
FROM
(
	SELECT
		AgeGroup = CASE 
		WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
		WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
		WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
		WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
		WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
		WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
		WHEN Age >= 61 THEN '[61+]'
		END,
		Age
	FROM WizzardDeposits
) AS AgeGroups
GROUP BY AgeGroup

--exer 10
SELECT
	 DISTINCT SUBSTRING(FirstName, 1, 1) AS FirstLetter
FROM WizzardDeposits
WHERE DepositGroup = 'Troll Chest'
ORDER BY FirstLetter

--exer 11
SELECT
	DepositGroup,
	IsDepositExpired,
	AVG(DepositInterest) AS AverageInterest
FROM WizzardDeposits
WHERE DepositStartDate > '1985-01-01'
GROUP BY DepositGroup, IsDepositExpired
ORDER BY DepositGroup DESC, IsDepositExpired 

--exer 12
SELECT SUM(a.[Difference]) AS SumDifference
FROM 
(
	SELECT 
		DiffTable.DepositAmount - (
			SELECT DepositAmount 
			FROM WizzardDeposits 
			WHERE Id = DiffTable.Id + 1) AS [Difference]
	FROM WizzardDeposits AS DiffTable
) AS a

--exer 13
USE SoftUniCRUD

SELECT 
	DepartmentID,
	SUM(Salary) AS TotalSalary
FROM Employees
GROUP BY DepartmentID

--exer 14
SELECT 
	DepartmentID,
	MIN(Salary) AS MinimumSalary
FROM Employees
WHERE DepartmentID IN (2, 5, 7) AND HireDate > '2000-01-01' 
GROUP BY DepartmentID

--exer 15
SELECT * 
INTO EmployeesOver30000
FROM Employees
WHERE Salary > 30000

DELETE FROM EmployeesOver30000
WHERE ManagerID = 42

UPDATE EmployeesOver30000
SET Salary += 5000
WHERE DepartmentID = 1

SELECT 
	DepartmentID,
	AVG(Salary) AS AverageSalary
FROM EmployeesOver30000
GROUP BY DepartmentID

--exer 16
SELECT 
	DepartmentID,
	MAX(Salary) AS MaxSalary
FROM Employees
GROUP BY DepartmentID
HAVING MAX(Salary) NOT BETWEEN 30000 AND 70000

--exer 17
SELECT 
	[Count] = COUNT(Salary)
FROM Employees
WHERE ManagerID IS NULL

--exer 18
SELECT DISTINCT
	DepartmentID,
	Salary AS ThirdHighestSalary
FROM
(
	SELECT
		DepartmentID,
		Salary,
		DENSE_RANK() OVER(PARTITION BY DepartmentID ORDER BY Salary DESC) AS SalaryRank
	FROM Employees
) AS a
WHERE SalaryRank = 3

--exer 19
SELECT TOP(10)
	FirstName,
	LastName,
	DepartmentID
FROM Employees AS e1
WHERE Salary > (
	SELECT AVG(Salary) FROM Employees AS e2
	WHERE e1.DepartmentID = e2.DepartmentID
	GROUP BY DepartmentID)
ORDER BY e1.DepartmentID