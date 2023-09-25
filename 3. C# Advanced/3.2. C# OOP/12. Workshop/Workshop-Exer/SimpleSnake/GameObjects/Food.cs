namespace SimpleSnake.GameObjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Food : Point
    {
        private Wall wall;
        private Random random;
        private char foodSymbol;

        protected Food(Wall wall, char foodSymbol, int points)
            : base(wall.LeftX, wall.TopY)
        {
            this.wall = wall;
            FoodPoints = points;
            this.foodSymbol = foodSymbol;
            random = new Random();
        }

        public int FoodPoints { get; }

        public void SetRandomPosition(Queue<Point> snakeParts)
        {
            bool isPointOfSnake;
            do
            {
                LeftX = random.Next(2, wall.LeftX - 2);
                TopY = random.Next(2, wall.TopY - 2);

                isPointOfSnake = snakeParts
                    .Any(x => x.LeftX == LeftX && x.TopY == TopY);
            } while (isPointOfSnake);

            Console.BackgroundColor = ConsoleColor.Red;
            Draw(foodSymbol);
            Console.BackgroundColor = ConsoleColor.White;
        }

        public bool IsFoodPoint(Point snake)
        {
            return snake.LeftX == LeftX &&
                snake.TopY == TopY;
        }
    }
}
