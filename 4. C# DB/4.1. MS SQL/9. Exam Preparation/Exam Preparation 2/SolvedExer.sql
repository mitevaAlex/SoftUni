CREATE DATABASE School

USE School

--exer 1
CREATE TABLE Students
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	MiddleName NVARCHAR(25),
	LastName NVARCHAR(30) NOT NULL,
	Age INT NOT NULL
	CHECK(Age >= 5 AND Age <= 100),
	[Address] NVARCHAR(50),
	Phone NCHAR(10)
	CHECK(LEN(Phone) = 10)
)

CREATE TABLE Subjects
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(20) NOT NULL,
	Lessons INT NOT NULL
	CHECK(Lessons > 0)
)

CREATE TABLE StudentsSubjects
(
	Id INT PRIMARY KEY IDENTITY,
	StudentId INT NOT NULL FOREIGN KEY REFERENCES Students(Id),
	SubjectId INT NOT NULL FOREIGN KEY REFERENCES Subjects(Id),
	Grade DECIMAL(3, 2) NOT NULL
	CHECK(Grade BETWEEN 2 AND 6)
)

CREATE TABLE Exams
(
	Id INT PRIMARY KEY IDENTITY,
	[Date] DATETIME2,
	SubjectId INT NOT NULL FOREIGN KEY REFERENCES Subjects(Id)
)

CREATE TABLE StudentsExams
(	
	StudentId INT NOT NULL FOREIGN KEY REFERENCES Students(Id),
	ExamId INT NOT NULL FOREIGN KEY REFERENCES Exams(Id),
	Grade DECIMAL(3, 2) NOT NULL
	CHECK(Grade BETWEEN 2 AND 6),
	PRIMARY KEY(StudentId, ExamId)
)

CREATE TABLE Teachers
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(20) NOT NULL,
	LastName NVARCHAR(20) NOT NULL,
	[Address] NVARCHAR(20) NOT NULL,
	Phone NCHAR(10)
	CHECK(LEN(Phone) = 10),
	SubjectId INT NOT NULL FOREIGN KEY REFERENCES Subjects(Id)
)

CREATE TABLE StudentsTeachers
(
	StudentId INT NOT NULL FOREIGN KEY REFERENCES Students(Id),
	TeacherId INT NOT NULL FOREIGN KEY REFERENCES Teachers(Id),
	PRIMARY KEY(StudentId, TeacherId)
)

--exer 2
INSERT INTO Teachers VALUES
('Ruthanne', 'Bamb', '84948 Mesta Junction', '3105500146', 6),
('Gerrard', 'Lowin', '370 Talisman Plaza', '3324874824', 2),
('Merrile', 'Lambdin', '81 Dahle Plaza', '4373065154', 5),
('Bert', 'Ivie', '2 Gateway Circle', '4409584510', 4)

INSERT INTO Subjects VALUES
('Geometry', 12),
('Health', 10),
('Drama', 7),
('Sports', 9)

--exer 3
UPDATE StudentsSubjects
SET Grade = 6
WHERE (SubjectId = 1 OR SubjectId = 2) AND Grade >= 5.5

--exer 4
DELETE FROM StudentsTeachers
WHERE teacherId IN(SELECT Id FROM Teachers
WHERE CHARINDEX('72', Phone) > 0)

DELETE FROM Teachers
WHERE CHARINDEX('72', Phone) > 0

--exer 5
SELECT FirstName, LastName, Age FROM Students
WHERE Age >= 12
ORDER BY FirstName, LastName

--exer 6
SELECT 
	s.FirstName,
	s.LastName,
	COUNT(st.TeacherId) AS TeachersCount
FROM StudentsTeachers AS st
RIGHT JOIN Students AS s ON s.Id = st.StudentId
GROUP BY st.StudentId, s.FirstName, s.LastName
ORDER BY s.LastName

--exer 7
SELECT 
	CONCAT(FirstName, ' ', LastName) AS [Full Name] 
FROM Students
WHERE Id NOT IN (SELECT StudentId FROM StudentsExams)
ORDER BY [Full Name]

--exer 8
SELECT TOP(10)
	s.FirstName,
	s.LastName,
	CONVERT(DECIMAL(3, 2), ROUND(AVG(Grade), 2)) AS Grade
FROM StudentsExams AS se
JOIN Students AS s ON s.Id = se.StudentId
GROUP BY se.StudentId, s.FirstName, s.LastName
ORDER BY AVG(se.Grade) DESC, s.FirstName, s.LastName

--exer 9
SELECT 
	CONCAT_WS(' ', FirstName, MiddleName, LastName) AS [Full Name] 
FROM Students
WHERE Id NOT IN (SELECT StudentId FROM StudentsSubjects)
ORDER BY [Full Name]

--exer 10
SELECT 
	s.[Name],
	AVG(Grade) AS AverageGrade
FROM StudentsSubjects AS ss
JOIN Subjects AS s ON s.Id =  ss.SubjectId
GROUP BY ss.SubjectId, s.[Name]
ORDER BY ss.SubjectId

--exer 11
CREATE FUNCTION udf_ExamGradesToUpdate(@studentId INT , @grade DECIMAL(3, 2))
RETURNS VARCHAR(100)
AS
BEGIN 
	IF(@studentId NOT IN (SELECT Id FROM Students))
		RETURN 'The student with provided id does not exist in the school!'

	IF(@grade < 2 OR @grade > 6)
		RETURN 'Grade cannot be above 6.00!'

	DECLARE @firstName NVARCHAR(30) = (SELECT FirstName FROM Students 
		WHERE Id = @studentId)
	DECLARE @count INT = (SELECT COUNT(a.Grade) FROM (SELECT Grade 
		FROM StudentsExams
		WHERE StudentId = @studentId AND Grade >= @grade AND Grade <= @grade + 0.5) AS a)

		RETURN CONCAT('You have to update ', @count, ' grades for the student ', @firstName)
END

--exer 12
CREATE PROC usp_ExcludeFromSchool(@StudentId INT)
AS
BEGIN
	IF(@studentId NOT IN (SELECT Id FROM Students))
	BEGIN;
		THROW 50001,'This school has no student with the provided id!', 1
		RETURN 
	END

	DELETE FROM StudentsTeachers
	WHERE StudentId = @StudentId

	DELETE FROM StudentsSubjects
	WHERE StudentId = @StudentId

	DELETE FROM StudentsExams
	WHERE StudentId = @StudentId

	DELETE FROM Students
	WHERE Id = @StudentId
END