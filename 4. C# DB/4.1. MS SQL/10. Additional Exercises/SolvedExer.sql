USE Diablo

--exer 1
SELECT DISTINCT 
	[Email Provider], 
	COUNT([Email Provider]) AS [Number Of Users]
FROM
(
	SELECT 
		RIGHT(Email, LEN(Email) - CHARINDEX('@', Email)) AS [Email Provider]
	FROM Users
)AS a
GROUP BY [Email Provider]
ORDER BY [Number Of Users] DESC, [Email Provider]

--exer 2
SELECT 
	g.[Name] AS Game,
	gt.[Name] AS [Game Type],
	u.Username,
	ug.[Level],
	ug.Cash,
	c.[Name] AS [Character]
FROM Games AS g
JOIN UsersGames AS ug ON ug.GameId = g.Id
JOIN Users AS u ON u.Id = ug.UserId
JOIN GameTypes AS gt ON gt.Id = g.GameTypeId
JOIN Characters AS c ON c.Id = ug.CharacterId
ORDER BY ug.[Level] DESC, u.Username, g.[Name]

--exer 3
SELECT 
	Username,
	Game,
	COUNT(ItemId) AS [Items Count],
	SUM(Price) AS [Items Price]
FROM
(
	SELECT  
		u.Username,
		g.[Name] AS Game,
		i.Id AS ItemId,
		i.Price
	FROM Games AS g
	JOIN UsersGames AS ug ON ug.GameId = g.Id
	JOIN Users AS u ON u.Id = ug.UserId
	JOIN UserGameItems AS ugi ON ugi.UserGameId = ug.Id 
	JOIN Items AS i ON i.Id = ugi.ItemId
)AS a
GROUP BY Username, Game
HAVING COUNT(ItemId) >= 10
ORDER BY [Items Count] DESC, [Items Price] DESC, Username

--exer 4
--extremely haaaard

--exer 5
SELECT 
	i.[Name],
	i.Price,
	i.MinLevel,
	s.Strength,
	s.Defence,
	s.Speed,
	s.Luck,
	s.Mind
FROM [Statistics] AS s
JOIN Items AS i ON i.StatisticId = s.Id
WHERE s.Mind > (SELECT AVG(Mind) FROM [Statistics]) AND 
	  s.Luck > (SELECT AVG(Luck) FROM [Statistics]) AND 
	  s.Speed > (SELECT AVG(Speed) FROM [Statistics])
ORDER BY i.[Name]

--exer 6
SELECT 
	i.[Name] AS [Item],
	i.Price,
	i.MinLevel,
	gt.[Name] AS [Forbidden Game Type]
FROM Items AS i
LEFT JOIN GameTypeForbiddenItems AS gtfi ON gtfi.ItemId = i.Id
LEFT JOIN GameTypes AS gt ON gt.Id = gtfi.GameTypeId
ORDER BY gt.[Name] DESC, i.[Name]

--exer 7
--CREATE PROC usp_BuyItem(@userId INT, @gameId INT, @itemId INT)
--AS 
--BEGIN TRANSACTION
--	UPDATE UsersGames
--	SET Cash -= (SELECT Price FROM Items WHERE Id = @itemId)
--	WHERE UserId = @userId AND GameId = @gameId

--	INSERT INTO UserGameItems VALUES 
--	(@itemId, (SELECT Id FROM UsersGames WHERE UserId = @userId AND GameId = @gameId))
--COMMIT

--EXEC dbo.usp_BuyItem 5, 221, 51
--EXEC dbo.usp_BuyItem 5, 221, 71
--EXEC dbo.usp_BuyItem 5, 221, 157
--EXEC dbo.usp_BuyItem 5, 221, 184
--EXEC dbo.usp_BuyItem 5, 221, 197
--EXEC dbo.usp_BuyItem 5, 221, 223

UPDATE UsersGames
SET Cash -= (SELECT SUM(Price) FROM Items WHERE Id IN (51, 71, 157, 184, 197, 223))
WHERE UserId = 5 AND GameId = 221

INSERT INTO UserGameItems VALUES 
(51, 235),
(71, 235),
(157, 235),
(184, 235),
(197, 235),
(223, 235)

SELECT 
	u.Username,
	g.[Name],
	ug.Cash,
	i.[Name] AS [Item Name]
FROM UsersGames AS ug
JOIN Users AS u ON u.Id = ug.UserId
JOIN Games AS g ON g.Id = ug.GameId
JOIN UserGameItems AS ugi ON ugi.UserGameId = ug.Id
JOIN Items AS i ON i.Id = ugi.ItemId
WHERE g.Id = 221
ORDER BY i.[Name]



