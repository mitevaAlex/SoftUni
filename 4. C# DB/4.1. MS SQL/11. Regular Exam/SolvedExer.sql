CREATE DATABASE CigarShop

USE CigarShop

--exer 1
CREATE TABLE Sizes
(
	Id INT PRIMARY KEY IDENTITY,
	[Length] INT NOT NULL
	CHECK([Length] >= 10 AND [Length] <= 25),
	RingRange DECIMAL(3, 2) NOT NULL
	CHECK(RingRange >= 1.5 AND RingRange <= 7.5)
)

CREATE TABLE Tastes
(
	Id INT PRIMARY KEY IDENTITY,
	TasteType VARCHAR(20) NOT NULL,
	TasteStrength VARCHAR(15) NOT NULL,
	ImageURL NVARCHAR(100) NOT NULL
)

CREATE TABLE Brands
(
	Id INT PRIMARY KEY IDENTITY,
	BrandName VARCHAR(30) UNIQUE NOT NULL,
	BrandDescription VARCHAR(MAX)
)

CREATE TABLE Cigars
(
	Id INT PRIMARY KEY IDENTITY,
	CigarName VARCHAR(80) NOT NULL,
	BrandId INT NOT NULL FOREIGN KEY REFERENCES Brands(Id),
	TastId INT NOT NULL FOREIGN KEY REFERENCES Tastes(Id),
	SizeId INT NOT NULL FOREIGN KEY REFERENCES Sizes(Id),
	PriceForSingleCigar MONEY NOT NULL,
	ImageURL NVARCHAR(100) NOT NULL
)

CREATE TABLE Addresses
(
	Id INT PRIMARY KEY IDENTITY,
	Town VARCHAR(30) NOT NULL,
	Country NVARCHAR(30) NOT NULL,
	Streat NVARCHAR(100) NOT NULL,
	ZIP VARCHAR(20) NOT NULL
)

CREATE TABLE Clients
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	LastName NVARCHAR(30) NOT NULL,
	Email NVARCHAR(50) NOT NULL,
	AddressId INT NOT NULL FOREIGN KEY REFERENCES Addresses(Id),
)

CREATE TABLE ClientsCigars
(
	ClientId INT NOT NULL FOREIGN KEY REFERENCES Clients(Id),
	CigarId INT NOT NULL FOREIGN KEY REFERENCES Cigars(Id),
	PRIMARY KEY(ClientId, CigarId)
)

--exer 2
INSERT INTO Cigars VALUES
('COHIBA ROBUSTO', 9, 1, 5, 15.50, 'cohiba-robusto-stick_18.jpg'),
('COHIBA SIGLO I', 9, 1, 10, 410.00, 'cohiba-siglo-i-stick_12.jpg'),
('HOYO DE MONTERREY LE HOYO DU MAIRE', 14, 5, 11, 7.50, 'hoyo-du-maire-stick_17.jpg'),
('HOYO DE MONTERREY LE HOYO DE SAN JUAN', 14, 4, 15, 32.00, 'hoyo-de-san-juan-stick_20.jpg'),
('TRINIDAD COLONIALES', 2, 3, 8, 85.21, 'trinidad-coloniales-stick_30.jpg')

INSERT INTO Addresses VALUES
('Sofia', 'Bulgaria', '18 Bul. Vasil levski', '1000'),
('Athens', 'Greece', '4342 McDonald Avenue', '10435'),
('Zagreb', 'Croatia', '4333 Lauren Drive', '10000')

--exer 3
UPDATE Cigars
SET PriceForSingleCigar *= 1.2
WHERE TastId = (SELECT Id FROM Tastes WHERE TasteType = 'Spicy')

UPDATE Brands
SET BrandDescription = 'New description'
WHERE BrandDescription IS NULL

--exer 4
DELETE FROM ClientsCigars
WHERE ClientId IN (SELECT c.Id FROM Clients AS c
	JOIN Addresses AS a ON a.Id = c.AddressId
	WHERE LEFT(Country, 1) = 'C')

DELETE FROM Clients
WHERE AddressId IN (SELECT Id FROM Addresses 
	WHERE LEFT(Country, 1) = 'C')

DELETE FROM Addresses
WHERE LEFT(Country, 1) = 'C'

--exer 5
SELECT 
	CigarName,
	PriceForSingleCigar,
	ImageURL
FROM Cigars
ORDER BY PriceForSingleCigar, CigarName DESC

--exer 6
SELECT 
	c.Id,
	CigarName,
	PriceForSingleCigar,
	t.TasteType,
	t.TasteStrength
FROM Cigars AS c
JOIN Tastes AS t ON t.Id = c.TastId
WHERE t.TasteType IN ('Earthy', 'Woody') 
ORDER BY PriceForSingleCigar DESC

--exer 7
SELECT
	Id,
	CONCAT(FirstName, ' ', LastName) AS ClientName,
	Email
FROM Clients
WHERE Id NOT IN (SELECT ClientId FROM ClientsCigars)
ORDER BY ClientName

--exer 8
SELECT TOP(5)
	c.CigarName,
	c.PriceForSingleCigar,
	c.ImageURL
FROM Cigars AS c
JOIN Sizes AS s ON s.Id = c.SizeId 
WHERE (c.PriceForSingleCigar > 50 OR 
	  CHARINDEX('ci', c.CigarName) > 0) AND 
	  s.[Length] >= 12 AND
	  s.RingRange > 2.55
ORDER BY c.CigarName, c.PriceForSingleCigar DESC

--exer 9
SELECT 
	CONCAT(c.FirstName, ' ', c.LastName) AS FullName,
	a.Country,
	a.ZIP,
	CONCAT('$', MAX(ci.PriceForSingleCigar)) AS CigarPrice
FROM Clients AS c
LEFT JOIN Addresses AS a ON a.Id = c.AddressId
LEFT JOIN ClientsCigars AS cc ON cc.ClientId = c.Id
LEFT JOIN Cigars AS ci ON ci.Id = cc.CigarId
WHERE ISNUMERIC(a.ZIP) = 1
GROUP BY c.Id, c.FirstName, c.LastName, a.Country, a.ZIP
ORDER BY FullName

--exer 10
SELECT
	LastName,
	CEILING(AVG(s.[Length])) AS CigarLength,
	CEILING(AVG(s.RingRange)) AS CigarRingRange
FROM Clients AS c
RIGHT JOIN ClientsCigars AS cc ON cc.ClientId = c.Id
LEFT JOIN Cigars AS ci ON ci.Id = cc.CigarId
LEFT JOIN Sizes AS s ON s.Id = ci.SizeId
GROUP BY c.LastName
ORDER BY CigarLength DESC

--exer 11
CREATE FUNCTION udf_ClientWithCigars(@name NVARCHAR(30)) 
RETURNS INT
AS
BEGIN 
	DECLARE @totalCigars INT = (SELECT COUNT(CigarId) FROM ClientsCigars
		WHERE ClientId = (SELECT TOP(1) Id FROM Clients WHERE FirstName = @name)
		GROUP BY ClientId)

	IF(@totalCigars IS NULL)
		RETURN 0

	RETURN @totalCigars
END

--exer 12
CREATE PROC usp_SearchByTaste(@taste VARCHAR(20))
AS 
BEGIN 
	SELECT
		c.CigarName,
		CONCAT('$', c.PriceForSingleCigar) AS Price,
		t.TasteType,
		b.BrandName,
		CONCAT(s.[Length], ' cm') AS CigarLength,
		CONCAT(s.RingRange, ' cm') AS CigarRingRange
	FROM Cigars AS c
	JOIN Tastes AS t ON t.Id = c.TastId
	JOIN Sizes AS s ON s.Id = c.SizeId
	JOIN Brands AS b ON b.Id = c.BrandId
	WHERE t.TasteType = @taste
	ORDER BY CigarLength, CigarRingRange DESC
END

