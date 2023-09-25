USE SoftUniCRUD

--exer 1
SELECT TOP(5) e.EmployeeId,
	   e.JobTitle,
	   e.AddressId,
	   a.AddressText
FROM Employees AS e
JOIN Addresses AS a ON e.AddressID = a.AddressID
ORDER BY a.AddressID

--exer 2
SELECT TOP(50) e.FirstName,
	   e.LastName,
	   t.[Name] AS Town,
	   a.AddressText
FROM Employees AS e
JOIN Addresses AS a ON e.AddressID = a.AddressID
JOIN Towns AS t ON a.TownID = t.TownID
ORDER BY e.FirstName, e.LastName

--exer 3
SELECT e.EmployeeId,
	   e.FirstName,
	   e.LastName,
	   d.[Name] AS DepartmentName
FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'
ORDER BY e.EmployeeID

--exer 4
SELECT TOP(5) e.EmployeeId,
	   e.FirstName,
	   e.Salary,
	   d.[Name] AS DepartmentName
FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE e.Salary > 15000
ORDER BY e.DepartmentID

--exer 5
SELECT TOP(3) e.EmployeeId,
	   e.FirstName
FROM Employees AS e
WHERE e.EmployeeID NOT IN
(
	SELECT ep.EmployeeId FROM EmployeesProjects AS ep
)
ORDER BY e.EmployeeId

--exer 6
SELECT e.FirstName,
	   e.LastName,
	   e.HireDate,
	   d.[Name] AS DeptName
FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE e.HireDate > '1999-01-01' AND d.[Name] IN ('Sales', 'Finance')
ORDER BY e.HireDate

--exer 7
SELECT TOP(5) e.EmployeeId,
	   e.FirstName,
	   p.[Name] AS ProjectName
FROM Employees AS e
JOIN EmployeesProjects AS ep ON e.EmployeeID = EP.EmployeeID
JOIN Projects AS p ON ep.ProjectID = p.ProjectID
WHERE p.StartDate > '2002-08-13' AND p.EndDate IS NULL
ORDER BY e.EmployeeId

--exer 8
SELECT TOP(5) e.EmployeeId,
	   e.FirstName,
	   ProjectName = CASE
	   WHEN p.StartDate >= '2005-01-01' THEN NULL
	   ELSE p.[Name]
	   END
FROM Employees AS e
JOIN EmployeesProjects AS ep ON e.EmployeeID = EP.EmployeeID
JOIN Projects AS p ON ep.ProjectID = p.ProjectID
WHERE ep.EmployeeID = 24
ORDER BY e.EmployeeId

--exer 9
SELECT e.EmployeeId,
	   e.FirstName,
	   e.ManagerId,
	   m.FirstName AS ManagerName
FROM Employees AS e
JOIN Employees AS m ON e.ManagerID = m.EmployeeID
WHERE e.ManagerID IN (3, 7)
ORDER BY e.EmployeeID

--exer 10
SELECT TOP(50) e.EmployeeID,
	   CONCAT(e.FirstName, ' ', e.LastName) AS EmployeeName,
	   CONCAT(m.FirstName, ' ', m.LastName) AS ManagerName,
	   d.[Name] AS DepartmentName
FROM Employees AS e
JOIN Employees AS m ON e.ManagerID = m.EmployeeID
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
ORDER BY e.EmployeeID

--exer 11
SELECT TOP(1) a.AverageSalary AS MinAverageSalary FROM ( 
	SELECT 
	AverageSalary = AVG(e.Salary)
	FROM Employees AS e
	GROUP BY e.DepartmentID) AS a
ORDER BY a.AverageSalary

--exer 12
USE [Geography]

SELECT 
	mc.CountryCode,
	m.MountainRange,
	p.PeakName,
	p.Elevation
FROM Peaks AS p
JOIN MountainsCountries AS mc ON p.MountainId = mc.MountainId
JOIN Mountains AS m ON p.MountainId = m.Id
WHERE mc.CountryCode = 'BG' AND p.Elevation > 2835
ORDER BY p.Elevation DESC

--exer 13
SELECT 
	mc.CountryCode,
	MountainRages = COUNT(mc.MountainId)
FROM MountainsCountries AS mc
WHERE mc.CountryCode IN ('BG', 'RU', 'US')
GROUP BY mc.CountryCode

--exer 14
SELECT TOP(5)
	c.CountryName,
	r.RiverName
FROM Rivers AS r
JOIN CountriesRivers AS cr ON r.Id = cr.RiverId
RIGHT JOIN Countries AS c ON cr.CountryCode = c.CountryCode
WHERE c.ContinentCode = 'AF'
ORDER BY c.CountryName

--exer 15
SELECT 
	b.ContinentCode,
	b.CurrencyCode,
	b.CurrencyUsage
FROM
(
	SELECT *,
	DENSE_RANK() OVER(PARTITION BY a.ContinentCode ORDER BY a.CurrencyUsage DESC) AS CurrencyUsageRank
	FROM 
	(	
		SELECT 
			c.ContinentCode,
			c.CurrencyCode,
			CurrencyUsage = COUNT(c.CurrencyCode)
		FROM Countries AS c
		GROUP BY c.ContinentCode, c.CurrencyCode
	) AS a
	WHERE a.CurrencyUsage > 1
) AS b
WHERE b.CurrencyUsageRank = 1
ORDER BY b.ContinentCode

--exer 16
SELECT 
	[Count] = COUNT(c.CountryCode) 
FROM Countries AS c 
LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
WHERE mc.MountainId IS NULL

--exer 17
SELECT TOP(5)
	c.CountryName,
	HighestPeakElevation = MAX(p.Elevation),
	LongestRiverLength = MAX(r.[Length])
FROM Countries AS c
LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
JOIN Peaks AS p ON p.MountainId = mc.MountainId
LEFT JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
JOIN Rivers AS r ON r.Id = cr.RiverId
GROUP BY c.CountryName
ORDER BY HighestPeakElevation DESC, LongestRiverLength DESC, c.CountryName

--exer 18
SELECT TOP(5)
	b.Country,
	[Highest Peak Name] = ISNULL(b.PeakName, '(no highest peak)'),
	[Highest Peak Elevation] = ISNULL(b.Elevation, 0),
	[Mountain] = ISNULL(b.MountainRange, '(no mountain)')
FROM
(
	SELECT *,
	DENSE_RANK() OVER(PARTITION BY a.Country ORDER BY a.Elevation DESC) AS ElevationRank
	FROM
	(
		SELECT 
			c.CountryName AS Country,
			p.PeakName,
			p.Elevation,
			m.MountainRange
		FROM Countries AS c
		LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
		LEFT JOIN Peaks AS p ON p.MountainId = mc.MountainId
		LEFT JOIN Mountains AS m ON m.Id = p.MountainId
	) AS a
) AS b 
WHERE b.ElevationRank = 1
ORDER BY b.Country, [Highest Peak Name]

