--exer 1
CREATE DATABASE WMS

USE WMS

CREATE TABLE Clients
(
	ClientId INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Phone CHAR(12) NOT NULL
	CHECK(LEN(Phone) = 12)
)

CREATE TABLE Mechanics
(
	MechanicId INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	[Address] VARCHAR(255)
)

CREATE TABLE Models
(
	ModelId INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL UNIQUE
)

CREATE TABLE Jobs
(
	JobId INT PRIMARY KEY IDENTITY,
	ModelId INT NOT NULL FOREIGN KEY REFERENCES Models(ModelId),
	[Status] VARCHAR(11) NOT NULL DEFAULT('Pending')
	CHECK(Status IN ('Pending', 'In Progress', 'Finished')),
	ClientId INT NOT NULL FOREIGN KEY REFERENCES Clients(ClientId),
	MechanicId INT FOREIGN KEY REFERENCES Mechanics(MechanicId),
	IssueDate DATE NOT NULL,
	FinishDate DATE
)

CREATE TABLE Orders
(
	OrderId INT PRIMARY KEY IDENTITY,
	JobId INT NOT NULL FOREIGN KEY REFERENCES Jobs(JobId),
	IssueDate DATE,
	Delivered BIT NOT NULL DEFAULT(0)
)

CREATE TABLE Vendors
(
	VendorId INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL UNIQUE
)

CREATE TABLE Parts
(
	PartId INT PRIMARY KEY IDENTITY,
	SerialNumber VARCHAR(50) NOT NULL UNIQUE,
	[Description] VARCHAR(255),
	Price DECIMAL(6, 2) NOT NULL
	CHECK(Price > 0),
	VendorId INT NOT NULL FOREIGN KEY REFERENCES Vendors(VendorId),
	StockQty INT NOT NULL DEFAULT(0)
	CHECK(StockQty >= 0)
)

CREATE TABLE OrderParts
(
	OrderId INT NOT NULL FOREIGN KEY REFERENCES Orders(OrderId),
	PartId INT NOT NULL FOREIGN KEY REFERENCES Parts(PartId),
	Quantity INT NOT NULL DEFAULT(1)
	CHECK(Quantity > 0),
	PRIMARY KEY(OrderId, PartId)
)

CREATE TABLE PartsNeeded
(
	JobId INT NOT NULL FOREIGN KEY REFERENCES Jobs(JobId),
	PartId INT NOT NULL FOREIGN KEY REFERENCES Parts(PartId),
	Quantity INT NOT NULL DEFAULT(1)
	CHECK(Quantity > 0),
	PRIMARY KEY(JobId, PartId)
)

--exer 2
INSERT INTO Clients VALUES 
('Teri', 'Ennaco', '570-889-5187'),
('Merlyn', 'Lawler', '201-588-7810'),
('Georgene', 'Montezuma', '925-615-5185'),
('Jettie', 'Mconnell', '908-802-3564'),
('Lemuel', 'Latzke', '631-748-6479'),
('Melodie', 'Knipp', '805-690-1682'),
('Candida', 'Corbley', '908-275-8357')

INSERT INTO Parts VALUES 
('WP8182119', 'Door Boot Seal', 117.86, 2, DEFAULT),
('W10780048', 'Suspension Rod', 42.81, 1, DEFAULT),
('W10841140', 'Silicone Adhesive ', 6.77, 4, DEFAULT),
('WPY055980', 'High Temperature Adhesive', 13.94, 3, DEFAULT)

--exer 3
UPDATE Jobs
SET MechanicId = 3
WHERE [Status] = 'Pending'

UPDATE Jobs
SET [Status] = 'In Progress'
WHERE MechanicId = 3 AND [Status] = 'Pending'

--exer 4
DELETE FROM OrderParts
WHERE OrderId = 19

DELETE FROM Orders
WHERE OrderId = 19

--exer 5
SELECT  
	CONCAT(m.FirstName, ' ', m.LastName) AS [Mechanic Full Name],
	j.[Status] AS [Job Status],
	j.IssueDate AS [Job Issue Date]
FROM Jobs AS j
JOIN Mechanics AS m ON m.MechanicId = j.MechanicId
ORDER BY j.MechanicId, j.IssueDate, j.JobId 

--exer 6
SELECT 
	CONCAT(c.FirstName, ' ', c.LastName) AS [Client Full Name],
	DATEDIFF(DAY, j.IssueDate, '2017-04-24') AS [Days going],
	j.[Status]
FROM Jobs AS j
JOIN Clients AS c ON c.ClientId = j.ClientId
WHERE j.[Status] <> 'Finished'
ORDER BY DATEDIFF(DAY, j.IssueDate, '2017-04-24') DESC, j.ClientId

--exer 7
SELECT
	CONCAT(m.FirstName, ' ', m.LastName) AS [Mechanic Full Name],
	AVG(DATEDIFF(DAY, j.IssueDate, j.FinishDate)) AS [Average Days]
FROM Jobs AS j
JOIN Mechanics AS m ON m.MechanicId = j.MechanicId
WHERE [Status] = 'Finished'
GROUP BY j.MechanicId, m.FirstName, m.LastName
ORDER BY j.MechanicId

--exer 8
SELECT
	CONCAT(FirstName, ' ', LastName) AS [Mechanic Full Name]
FROM Mechanics
WHERE MechanicId NOT IN (SELECT MechanicId 
	FROM Jobs WHERE [Status] = 'In Progress' 
	GROUP BY MechanicId)

--exer 9
SELECT
	j.JobId AS [Job ID],
	ISNULL(SUM(p.Price * op.Quantity), 0) AS [Total Parts Cost]
FROM Jobs AS j
LEFT JOIN Orders AS o ON o.JobId = j.JobId
LEFT JOIN OrderParts AS op ON op.OrderId = o.OrderId
LEFT JOIN Parts AS p ON p.PartId = op.PartId
WHERE j.[Status] = 'Finished'
GROUP BY j.JobId
ORDER BY  [Total Parts Cost] DESC, j.JobId

--exer 10
SELECT j.JobId FROM Jobs AS j
JOIN
WHERE j.[Status] <> 'Finished'




SELECT
	p.PartId,
	p.[Description],
	SUM(op.Quantity) AS [Required],
	p.StockQty AS [In Stock]
FROM Parts AS p
JOIN PartsNeeded AS pn ON pn.PartId = p.PartId
JOIN Jobs AS j ON j.JobId = pn.JobId
JOIN Orders AS o ON o.JobId = j.JobId
JOIN OrderParts AS op ON op.PartId = p.PartId
WHERE j.[Status] <> 'Finished' AND o.Delivered = 0
GROUP BY p.PartId
HAVING SUM(op.Quantity) < p.StockQty
ORDER BY p.PartId 

--exer 11
CREATE PROC usp_PlaceOrder(@jobId INT, @serialNumber VARCHAR(50), @quantity INT)
AS
BEGIN TRANSACTION
	INSERT INTO Orders VALUES
	()
COMMIT

--exer 12
CREATE FUNCTION udf_GetCost(@jobId INT)
RETURNS TABLE AS
RETURN
(
	SELECT 
		j.JobId AS Id,
		ISNULL(SUM(p.Price * op.Quantity), 0) AS Result
	FROM Jobs AS j
	LEFT JOIN Orders AS o ON o.JobId = j.JobId
	LEFT JOIN OrderParts AS op ON op.OrderId = o.OrderId
	LEFT JOIN Parts AS p ON p.PartId = op.PartId
	WHERE j.JobId = @jobId
	GROUP BY j.JobId
)

SELECT * FROM dbo.udf_GetCost(1)
