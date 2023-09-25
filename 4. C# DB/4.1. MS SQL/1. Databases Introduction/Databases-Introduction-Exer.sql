--exer 1
CREATE DATABASE [Minions]

USE [Minions]

--exer 2
CREATE TABLE Minions
(
	Id INT NOT NULL PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL,
	Age INT
)

CREATE TABLE Towns
(
	Id INT NOT NULL PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL,
)

--exer 3
ALTER TABLE Minions
ADD TownId INT NOT NULL FOREIGN KEY REFERENCES Towns(Id)

--exer 4
INSERT INTO Towns(Id, [Name]) VALUES 
(1, 'Sofia'),
(2, 'Plovdiv'),
(3, 'Varna')

INSERT INTO Minions(Id, [Name], Age, TownId) VALUES
(1, 'Kevin', 22, 1),
(2, 'Bob', 15, 3),
(3, 'Steward', NULL, 2)

--exer 5
TRUNCATE TABLE Minions

--exer 6
DROP TABLE Minions

DROP TABLE Towns

--exer 7
CREATE TABLE People
(
	Id INT PRIMARY KEY IDENTITY,
	Username NVARCHAR(200) NOT NULL,
	Picture VARBINARY(MAX)
	CHECK (DATALENGTH(Picture) <= 2000000),
	Height DECIMAL(3, 2),
	[Weight] DECIMAL(5, 2),
	Gender CHAR(1) NOT NULL,
	Birthdate DATE NOT NULL,
	Biography NVARCHAR(MAX)
)

INSERT INTO People(Username, Picture, Height, [Weight], Gender, Birthdate, Biography) VALUES
('Kevin', NULL, 1.78, 70, 'm', '1991-02-01', NULL),
('Bob', NULL, 1.80, 95.6, 'm', '1971-02-19', NULL),
('Steward', NULL, 1.70, 70, 'm', '1991-02-01', 'Hello, I am Steward'),
('Katrin', NULL, 1.68, 49.5, 'f', '2000-02-23', NULL),
('Lilly', NULL, 1.70, 70, 'f', '1995-08-01', 'Hi, I am friendly')

--exer 8
CREATE TABLE Users
(
	Id BIGINT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) UNIQUE NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	ProfilePicture VARBINARY(MAX)
	CHECK (DATALENGTH(ProfilePicture) <= 900000),
	LastLoginTime DATETIME2 NOT NULL,
	IsDeleted BIT NOT NULL
)

INSERT INTO Users(Username, [Password], ProfilePicture, LastLoginTime, IsDeleted) VALUES
('Kevin', 'aaaa45', NULL, '1991-02-01 09:59:35', 'true'),
('Bob', 'bbb58', NULL, '1971-02-19 12:12:01', 'false'),
('Steward', '59895', NULL, '1991-02-01 02:55:45', 'true'),
('Katrin', '154hhh', NULL, '2000-02-23 05:05:05', 'false'),
('Lilly', 'dgeydge', NULL, '1995-08-01 08:06:59', 'false')

--exer 9
ALTER TABLE Users
DROP CONSTRAINT PK__Users__3214EC07DB82F871

ALTER TABLE Users
ADD CONSTRAINT PK__UsersCompositeIdUsername PRIMARY KEY(Id, Username)

--exer 10
ALTER TABLE Users
ADD CHECK (LEN([Password]) >= 5)

--exer 11
ALTER TABLE Users
ADD CONSTRAINT DF_UsersLastLoginTime DEFAULT GETDATE() FOR LastLoginTime

--exer 12
ALTER TABLE Users
DROP CONSTRAINT PK__UsersCompositeIdUsername

ALTER TABLE Users
ADD CONSTRAINT PK__UsersId PRIMARY KEY(Id)

ALTER TABLE Users
ADD CHECK (LEN(Username) >= 3)

--exer 13
CREATE DATABASE Movies

USE Movies

CREATE TABLE Directors
(
	Id INT PRIMARY KEY IDENTITY,
	DirectorName NVARCHAR(200) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Directors(DirectorName, Notes) VALUES
('Kevin Johnson', NULL),
('Bob Leyva', 'Best director'),
('Steward Stamatov', 'Awesome director'),
('Katrin Miteva', NULL),
('Lilly Reinhart', NULL)

CREATE TABLE Genres
(
	Id INT PRIMARY KEY IDENTITY,
	GenreName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Genres(GenreName, Notes) VALUES
('Romance', NULL),
('Action', 'Best genre'),
('Drama', 'Awesome genre'),
('Sci-fi', NULL),
('Sitcom', NULL)

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY,
	CategoryName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Categories(CategoryName, Notes) VALUES
('Horror', NULL),
('Mystery', 'Best category'),
('Thriller', 'Awesome category'),
('Comedy', NULL),
('Fantasy', NULL)

CREATE TABLE Movies
(
	Id INT PRIMARY KEY IDENTITY,
	Title NVARCHAR(100) NOT NULL,
	DirectorId INT NOT NULL FOREIGN KEY REFERENCES Directors(Id),
	CopyrightYear DATE,
	[Length] TIME NOT NULL,
	GenreId INT NOT NULL FOREIGN KEY REFERENCES Genres(Id),
	CategoryId INT NOT NULL FOREIGN KEY REFERENCES Categories(Id),
	Rating INT NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Movies(Title, DirectorId, CopyrightYear, [Length], GenreId, CategoryId, Rating, Notes) VALUES
('Love', 1, NULL, '01:00:00', 1, 2, 10000, NULL),
('Fear', 5, '2022', '01:00:00', 3, 4, 200, 'Nice movie'),
('Avengers', 4, NULL, '02:30:00', 5, 1, 2500, NULL),
('Spiderman', 2, '2019', '00:59:00', 2, 3, 12345, 'Fascinating film'),
('After', 3, '2035', '01:45:00', 4, 5, 15, NULL)

--exer 14
CREATE DATABASE CarRental

USE CarRental

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY,
	CategoryName NVARCHAR(50) NOT NULL,
	DailyRate DECIMAL(6, 2) NOT NULL,
	WeeklyRate DECIMAL(6, 2) NOT NULL,
	MonthlyRate DECIMAL(6, 2) NOT NULL,
	WeekendRate DECIMAL(6, 2) NOT NULL,
)

INSERT INTO Categories(CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate) VALUES
('Sports Cars', 100, 600, 2050.60, 300.33),
('Hybrid Cars',  50, 300.65, 1265, 100.25),
('Electric Cars',  70, 451.26, 1500, 215)

CREATE TABLE Cars
(
	Id INT PRIMARY KEY IDENTITY,
	PlateNumber VARCHAR(8) NOT NULL,
	Manufacturer VARCHAR(100) NOT NULL,
	Model VARCHAR(30) NOT NULL,
	CarYear DATE NOT NULL,
	CategoryId INT NOT NULL FOREIGN KEY REFERENCES Categories(Id),
	Doors DECIMAL(1) NOT NULL,
	Picture VARBINARY(MAX),
	Condition NVARCHAR(MAX) NOT NULL,
	Available BIT NOT NULL
)

INSERT INTO Cars(PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available) VALUES
('P1234HO', 'Toyota', 'Auris', '2010', 2, 3, NULL, 'Excellent', 'true'),
('B5555KP', 'Honda', 'Sport', '2016', 1, 2, NULL, 'Very good', 'false'),
('CA9900KK', 'Tesla', 'Model S', '2007', 3, 5, NULL, 'Poor', 'true')

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(20) NOT NULL,
	LastName NVARCHAR(20) NOT NULL,
	Title NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Employees(FirstName, LastName, Title, Notes) VALUES
('Ivan', 'Ivanov', 'CEO', NULL),
('Pesho', 'Peshov', 'Manager', 'Newbie'),
('James', 'Carter', 'Car mechanic', 'Expert')

CREATE TABLE Customers
(
	Id INT PRIMARY KEY IDENTITY,
	DriverLicenceNumber CHAR(9) NOT NULL
	CHECK(LEN(DriverLicenceNumber) = 9),
	FullName NVARCHAR(100) NOT NULL,
	[Address] NVARCHAR(100) NOT NULL,
	City NVARCHAR(50) NOT NULL,
	ZIPCode DECIMAL(4)
	CHECK(LEN(ZIPCode) = 4),
	Notes NVARCHAR(MAX)
)

INSERT INTO Customers(DriverLicenceNumber, FullName, [Address], City, ZIPCode, Notes) VALUES
('123456789', 'Kati Miteva Pisheva', '36 Hope str.', 'Rousse', 7000, NUll),
('111111222', 'Georgi Peshov Petrov', '14 Life bul.', 'Sofia', NULL, 'Frequent customer'),
('114400220', 'Simeon Simeonov Aleksandrov', '7 Levski bul.', 'London', 5487, 'New customer')

CREATE TABLE RentalOrders 
(
	Id INT PRIMARY KEY IDENTITY, 
	EmployeeId INT NOT NULL FOREIGN KEY REFERENCES Employees(Id), 
	CustomerId INT NOT NULL FOREIGN KEY REFERENCES Customers(Id), 
	CarId INT NOT NULL FOREIGN KEY REFERENCES Cars(Id), 
	TankLevel DECIMAL(3) NOT NULL, 
	KilometrageStart DECIMAL(6) NOT NULL, 
	KilometrageEnd DECIMAL(6) NOT NULL, 
	TotalKilometrage AS (KilometrageEnd - KilometrageStart) PERSISTED, 
	StartDate DATE NOT NULL, 
	EndDate DATE NOT NULL, 
	TotalDays AS (DAY(EndDate) - DAY(StartDate)) PERSISTED, 
	RateApplied DECIMAL(6, 2) NOT NULL, 
	TaxRate DECIMAL(6, 2), 
	OrderStatus NVARCHAR(30) NOT NULL, 
	Notes NVARCHAR(MAX)
)

INSERT INTO RentalOrders(EmployeeId, CustomerId, CarId, TankLevel, 
KilometrageStart, KilometrageEnd, StartDate, EndDate,
RateApplied, TaxRate, OrderStatus, Notes)VALUES
(1, 3, 2, 50, 70000, 70520, '2020-09-18', '2020-09-19', 555.3, 50.69, 'Ended', NULL),
(2, 1, 3, 70, 155080, 155795, '2021-09-18', '2021-09-30', 1204.39, 542, 'In progress', NULL),
(3, 2, 1, 100, 754102, 755000, '2022-12-01', '2022-12-05', 567, 78.54, 'Forthcoming', NULL)

--exer 15
CREATE DATABASE Hotel

USE Hotel

CREATE TABLE Employees 
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(20) NOT NULL,
	LastName NVARCHAR(20) NOT NULL,
	Title NVARCHAR(50) NOT NULL, 
	Notes NVARCHAR(MAX)
)

INSERT INTO Employees(FirstName, LastName, Title, Notes) VALUES
('Ivan', 'Ivanov', 'Cook', NULL),
('Pesho', 'Peshov', 'Manager', 'Newbie'),
('James', 'Carter', 'Cleaner', 'Expert')

CREATE TABLE Customers 
(
	AccountNumber INT PRIMARY KEY IDENTITY, 
	FirstName NVARCHAR(20) NOT NULL, 
	LastName NVARCHAR(20) NOT NULL, 
	PhoneNumber CHAR(10) NOT NULL
	CHECK (LEN(PhoneNumber) = 10), 
	EmergencyName NVARCHAR(20) NOT NULL, 
	EmergencyNumber CHAR(10) NOT NULL
	CHECK (LEN(EmergencyNumber) = 10), 
	Notes NVARCHAR(MAX)
)

INSERT INTO Customers(FirstName, LastName, PhoneNumber,
EmergencyName, EmergencyNumber) VALUES
('Kevin', 'Johnson', '0884747519', 'Mathew Mitev', '0555555555'),
('Bob', 'Leyva', '0812345768', 'Georgi Bobev', '0214571419'),
('Steward', 'Stamatov', '0957225255', 'Alex Guneva', '0511515151')

CREATE TABLE RoomStatus 
(
	RoomStatus DECIMAL(2) PRIMARY KEY,
	Notes NVARCHAR(MAX) NOT NULL
)

INSERT INTO RoomStatus VALUES
(0, 'Free'),
(1, 'Occupied'),
(2, 'Out of Order')

CREATE TABLE RoomTypes
(
	RoomType DECIMAL(2) PRIMARY KEY,
	Notes NVARCHAR(MAX) NOT NULL
)

INSERT INTO RoomTypes VALUES
(0, 'Single bedroom'),
(1, 'Double bedroom'),
(2, 'Family room')

CREATE TABLE BedTypes
(
	BedType DECIMAL(2) PRIMARY KEY,
	Notes NVARCHAR(MAX) NOT NULL
)

INSERT INTO BedTypes VALUES
(0, 'Single bed'),
(1, 'Double bed'),
(2, 'Family bed')

CREATE TABLE Rooms 
(
	RoomNumber INT PRIMARY KEY,
	RoomType DECIMAL(2) NOT NULL FOREIGN KEY REFERENCES RoomTypes(RoomType),
	BedType DECIMAL(2) NOT NULL FOREIGN KEY REFERENCES BedTypes(BedType),
	Rate DECIMAL(6, 2) NOT NULL, 
	RoomStatus DECIMAL(2) NOT NULL FOREIGN KEY REFERENCES RoomStatus(RoomStatus),
	Notes NVARCHAR(MAX)
)

INSERT INTO Rooms VALUES
(100, 0, 0, 500, 2, NULL),
(75, 1, 1, 705.63, 0, 'Luxurious'),
(223, 2, 2, 1452.2, 1, 'Enormous')

CREATE TABLE Payments
(
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT NOT NULL FOREIGN KEY REFERENCES Employees(Id),
	PaymentDate DATE,
	AccountNumber INT NOT NULL FOREIGN KEY REFERENCES Customers(AccountNumber), 
	FirstDateOccupied DATE NOT NULL,
	LastDateOccupied DATE NOT NULL,
	TotalDays AS (DAY(LastDateOccupied) - DAY(FirstDateOccupied)) PERSISTED, 
	AmountCharged DECIMAL(7, 2) NOT NULL,
	TaxRate DECIMAL(2, 2) NOT NULL,
	TaxAmount DECIMAL(7, 2) NOT NULL,
	PaymentTotal AS (TaxAmount + AmountCharged) PERSISTED,
	Notes NVARCHAR(MAX)
)

INSERT INTO Payments VALUES
(1, '2020-05-23', 2, '2020-05-15', '2020-05-23', 1545.23, 0.5, 745.2, NULL),
(2, '2020-10-14', 1, '2020-10-13', '2020-05-14', 125.5, 0.1, 50.26, NULL),
(3, '2021-09-06', 3, '2020-09-01', '2020-09-07', 8457, 0.7, 6110, NULL)

CREATE TABLE Occupancies 
(
	Id INT PRIMARY KEY IDENTITY, 
	EmployeeId  INT NOT NULL FOREIGN KEY REFERENCES Employees(Id), 
	DateOccupied DATE NOT NULL, 
	AccountNumber INT NOT NULL FOREIGN KEY REFERENCES Customers(AccountNumber), 
	RoomNumber INT NOT NULL FOREIGN KEY REFERENCES Rooms(RoomNumber), 
	RateApplied DECIMAL(6, 2) NOT NULL, 
	PhoneCharge DECIMAL(5, 2), 
	Notes NVARCHAR(MAX)
)

INSERT INTO Occupancies VALUES
(1, '2020-05-23', 2, 75, 325.26, 25.32, NULL),
(2, '2020-10-14', 1, 100, 251.05, 0, NULL),
(3, '2021-09-06', 3, 223, 1452, 10.2, NULL)

--exer 16
CREATE DATABASE SoftUni

USE SoftUni

CREATE TABLE Towns
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL
)

CREATE TABLE Addresses
(
	Id INT PRIMARY KEY IDENTITY,
	AddressText NVARCHAR(50) NOT NULL,
	TownId INT NOT NULL FOREIGN KEY REFERENCES Towns(Id)
)

CREATE TABLE Departments
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL
)

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(20) NOT NULL,
	MiddleName NVARCHAR(20) NOT NULL,
	LastName NVARCHAR(20) NOT NULL,
	JobTitle NVARCHAR(50) NOT NULL,
	DepartmentId INT NOT NULL FOREIGN KEY REFERENCES Departments(Id),
	HireDate DATE NOT NULL,
	Salary DECIMAL(7, 2) NOT NULL,
	AddressId INT NOT NULL FOREIGN KEY REFERENCES Addresses(Id)
)

--exer 17
BACKUP DATABASE SoftUni
TO DISK = 'D:\c# programmes SoftUni alex\4. C# DB\4.1. MS SQL\1. Databases Introduction\softuni-backup.bak'

DROP DATABASE SoftUni

RESTORE DATABASE SoftUni 
FROM DISK = 'D:\c# programmes SoftUni alex\4. C# DB\4.1. MS SQL\1. Databases Introduction\softuni-backup.bak'

USE SoftUni

--exer 18
INSERT INTO Towns VALUES
('Sofia'), 
('Plovdiv'), 
('Varna'), 
('Burgas')

INSERT INTO Addresses VALUES
('85 Hope str.', 1), 
('25 Chaos bul.', 2), 
('17 Ivan Vazov str.', 3), 
('44 Spring Valey bul.', 4)

INSERT INTO Departments VALUES
('Engineering'), 
('Sales'), 
('Marketing'), 
('Software Development'),
('Quality Assurance')

INSERT INTO Employees VALUES
('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '2013-02-01', 3500, 1), 
('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '2004-03-02', 4000, 2), 
('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '2016-08-28', 525.25, 1), 
('Georgi', 'Teziev', 'Ivanov', 'CEO', 2, '2007-12-09', 3000, 3),
('Peter', 'Pan', 'Pan', 'Intern', 3, '2016-08-28', 599.88, 4)

--exer 19
SELECT * FROM Towns

SELECT * FROM Departments

SELECT * FROM Employees

--exer 20
SELECT * FROM Towns
ORDER BY [Name]

SELECT * FROM Departments
ORDER BY [Name]

SELECT * FROM Employees
ORDER BY Salary DESC

--exer 21
SELECT [Name] FROM Towns
ORDER BY [Name]

SELECT [Name] FROM Departments
ORDER BY [Name]

SELECT FirstName, LastName, JobTitle, Salary FROM Employees
ORDER BY Salary DESC

--exer 22
UPDATE Employees
SET Salary = Salary * 1.1

SELECT Salary FROM Employees

--exer 23
USE Hotel

UPDATE Payments
SET TaxRate -= 0.3

SELECT TaxRate FROM Payments

--exer 24
TRUNCATE TABLE Occupancies