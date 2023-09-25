namespace SimpleSnake.GameObjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Snake
    {
        private const char snakeSymbol = '\u25CF';
        private const char emptySpace = ' ';

        private Queue<Point> parts;
        private Food[] food;
        private int foodIndex;
        private Wall wall;
        private int nextLeftX;
        private int nextTopY;

        public Snake(Wall wall)
        {
            this.wall = wall;
            parts = new Queue<Point>();
            food = new Food[3];
            foodIndex = RandomFoodNumber;
            GetFoods();
            CreateSnake();
        }

        private int RandomFoodNumber => new Random().Next(0, food.Length);

        private void CreateSnake()
        {
            for (int topY = 1; topY <= 6; topY++)
            {
                parts.Enqueue(new Point(2, topY));
            }
        }

        private void GetFoods()
        {
            food[0] = new FoodHash(wall);
            food[1] = new FoodDollar(wall);
            food[2] = new FoodAsterisk(wall);
            food[foodIndex].SetRandomPosition(parts);
        }

        private void Eat(Point direction, Point currentSnakeHead)
        {
            int length = food[foodIndex].FoodPoints;

            for (int i = 0; i < length; i++)
            {
                parts.Enqueue(new Point(nextLeftX, nextTopY));
                GetNextPoint(direction, currentSnakeHead);
            }

            foodIndex = RandomFoodNumber;
            food[foodIndex].SetRandomPosition(parts);
        }

        private void GetNextPoint(Point direction, Point snakeHead)
        {
            nextLeftX = snakeHead.LeftX + direction.LeftX;
            nextTopY = snakeHead.TopY + direction.TopY;
        }

        public bool IsMoving(Point direction)
        {
            Point currentSnakeHead = parts.Last();
            GetNextPoint(direction, currentSnakeHead);

            bool isPointOfSnake = parts
                .Any(x => x.LeftX == nextLeftX && x.TopY == nextTopY);
            if (isPointOfSnake)
            {
                return false;
            }

            Point newSnakeHead = new Point(nextLeftX, nextTopY);

            if (wall.IsPointOfWall(newSnakeHead))
            {
                return false;
            }

            parts.Enqueue(newSnakeHead);
            newSnakeHead.Draw(snakeSymbol);

            if (food[foodIndex].IsFoodPoint(newSnakeHead))
            {
                Eat(direction, currentSnakeHead);
            }

            Point snakeTail = parts.Dequeue();
            snakeTail.Draw(emptySpace);
            return true;
        }
    }
}
