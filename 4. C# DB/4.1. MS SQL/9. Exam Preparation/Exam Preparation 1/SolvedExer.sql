CREATE DATABASE Airport

USE Airport

--exer 1
CREATE TABLE Planes
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL,
	Seats INT NOT NULL,
	[Range] INT NOT NULL
)

CREATE TABLE Flights
(
	Id INT PRIMARY KEY IDENTITY,
	DepartureTime DATETIME2,
	ArrivalTime DATETIME2,
	Origin VARCHAR(50) NOT NULL,
	Destination VARCHAR(50) NOT NULL,
	PlaneId INT NOT NULL FOREIGN KEY REFERENCES Planes(Id)
)

CREATE TABLE Passengers
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(30) NOT NULL,
	LastName VARCHAR(30) NOT NULL,
	Age INT NOT NULL,
	[Address] VARCHAR(30) NOT NULL,
	PassportId VARCHAR(11) NOT NULL
)

CREATE TABLE LuggageTypes
(
	Id INT PRIMARY KEY IDENTITY,
	[Type] VARCHAR(30) NOT NULL
)

CREATE TABLE Luggages
(
	Id INT PRIMARY KEY IDENTITY,
	LuggageTypeId INT NOT NULL FOREIGN KEY REFERENCES LuggageTypes(Id),
	PassengerId INT NOT NULL FOREIGN KEY REFERENCES Passengers(Id)
)

CREATE TABLE Tickets
(
	Id INT PRIMARY KEY IDENTITY,
	PassengerId INT NOT NULL FOREIGN KEY REFERENCES Passengers(Id),
	FlightId INT NOT NULL FOREIGN KEY REFERENCES Flights(Id),
	LuggageId INT NOT NULL FOREIGN KEY REFERENCES Luggages(Id),
	Price DECIMAL(7, 2) NOT NULL
)

--exer 2
INSERT INTO Planes VALUES
('Airbus 336', 112, 5132),
('Airbus 330', 432, 5325),
('Boeing 369', 231, 2355),
('Stelt 297', 254, 2143),
('Boeing 338', 165, 5111),
('Airbus 558', 387, 1342),
('Boeing 128', 345, 5541)

INSERT INTO LuggageTypes VALUES
('Crossbody Bag'),
('School Backpack'),
('Shoulder Bag')

--exer 3
UPDATE Tickets
SET Price *= 1.13
WHERE Id IN (SELECT t.Id 
FROM Tickets AS t 
JOIN Flights AS f ON f.Id = t.FlightId
WHERE f.Destination = 'Carlsbad')

--exer 4
DELETE FROM Tickets
WHERE FlightId IN (SELECT Id 
FROM Flights
WHERE Destination = 'Ayn Halagim')

DELETE FROM Flights
WHERE Destination = 'Ayn Halagim'

--exer 5
SELECT * FROM Planes
WHERE CHARINDEX('tr', [Name]) <> 0
ORDER BY Id, [Name], Seats, [Range]

--exer 6
SELECT FlightId, SUM(Price) AS Price
FROM Tickets
GROUP BY FlightId
ORDER BY SUM(Price) DESC, FlightId

--exer 7
SELECT
	CONCAT(p.FirstName, ' ', p.LastName) AS [Full Name],
	f.Origin,
	f.Destination
FROM Tickets AS t
JOIN Passengers AS p ON p.Id = t.PassengerId
JOIN Flights AS f ON f.Id = t.FlightId
ORDER BY [Full Name], f.Origin, f.Destination

--exer 8
SELECT 
	FirstName,
	LastName,
	Age
FROM Passengers
WHERE Id NOT IN (SELECT PassengerId
	FROM Tickets)
ORDER BY Age DESC, FirstName, LastName

--exer 9
SELECT
	CONCAT(p.FirstName, ' ', p.LastName) AS [Full Name],
	pl.[Name] AS [Plane Name],
	CONCAT(f.Origin, ' - ', f.Destination) AS [Trip],
	lt.[Type] AS [Luggage Type]
FROM Tickets AS t
LEFT JOIN Passengers AS p ON p.Id = t.PassengerId
LEFT JOIN Flights AS f ON f.Id = t.FlightId
LEFT JOIN Planes AS pl ON pl.Id = f.PlaneId
LEFT JOIN Luggages AS l ON l.Id = t.LuggageId
LEFT JOIN LuggageTypes AS lt ON lt.Id = l.LuggageTypeId
ORDER BY [Full Name], pl.[Name], f.Origin, f.Destination, lt.[Type]

--exer 10
SELECT 
	p.[Name],
	p.Seats,
	COUNT(t.Id) AS [Passengers Count]
FROM Tickets AS t
RIGHT JOIN Flights AS f ON f.Id = t.FlightId
RIGHT JOIN Planes AS p ON p.Id = f.PlaneId 
GROUP BY p.[Name], p.Seats
ORDER BY COUNT(t.Id) DESC, p.[Name], p.Seats

--exer 11
CREATE FUNCTION udf_CalculateTickets(
	@origin VARCHAR(50), @destination VARCHAR(50), @peopleCount INT)
RETURNS VARCHAR(30)
AS
BEGIN 
	DECLARE @flightId INT = (SELECT Id 
			FROM Flights 
			WHERE Origin = @origin AND Destination = @destination)

	IF(@peopleCount <= 0)
		RETURN 'Invalid people count!'

	IF(@flightId IS NULL)
		RETURN 'Invalid flight!'

	DECLARE @totalPrice DECIMAL(10, 2) = @peopleCount * (SELECT Price FROM Tickets
		WHERE FlightId = @flightId)
	RETURN CONCAT('Total price ', @totalPrice)
END

--exer 12
CREATE PROC usp_CancelFlights
AS
	UPDATE Flights
	SET DepartureTime = NULL, ArrivalTime = NULL
	WHERE DepartureTime < ArrivalTime
