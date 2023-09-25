using System;
using System.Linq;

namespace Super_Mario
{
    class Program
    {
        static void Main(string[] args)
        {
            int lives = int.Parse(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());
            char[][] maze = new char[rows][];
            int[] marioCoordinates = new int[2];
            for (int row = 0; row < rows; row++)
            {
                string currentRow = Console.ReadLine();
                maze[row] = new char[currentRow.Length];
                for (int col = 0; col < currentRow.Length; col++)
                {
                    maze[row][col] = currentRow[col];
                    if (currentRow[col] == 'M')
                    {
                        marioCoordinates[0] = row;
                        marioCoordinates[1] = col;
                    }
                }
            }

            int cols = maze[0].Length;
            while (true)
            {
                string[] command = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                maze[int.Parse(command[1])][int.Parse(command[2])] = 'B';
                string move = command[0];
                lives--;
                switch (move)
                {
                    case "W":
                        if (marioCoordinates[0] - 1 < 0)
                        {
                            continue;
                        }
                        maze[marioCoordinates[0]][marioCoordinates[1]] = '-';
                        marioCoordinates[0]--;
                        break;
                    case "S":
                        if (marioCoordinates[0] + 1 == rows)
                        {
                            continue;
                        }
                        maze[marioCoordinates[0]][marioCoordinates[1]] = '-';
                        marioCoordinates[0]++;
                        break;
                    case "A":
                        if (marioCoordinates[1] - 1 < 0)
                        {
                            continue;
                        }
                        maze[marioCoordinates[0]][marioCoordinates[1]] = '-';
                        marioCoordinates[1]--;
                        break;
                    case "D":
                        if (marioCoordinates[1] + 1 == cols)
                        {
                            continue;
                        }
                        maze[marioCoordinates[0]][marioCoordinates[1]] = '-';
                        marioCoordinates[1]++;
                        break;
                }

                if (lives <= 0)
                {
                    maze[marioCoordinates[0]][marioCoordinates[1]] = 'X';
                    Console.WriteLine($"Mario died at {marioCoordinates[0]};{marioCoordinates[1]}.");
                    break;
                }
                else if (maze[marioCoordinates[0]][marioCoordinates[1]] == 'B')
                {
                    lives -= 2;
                    if (lives <= 0)
                    {
                        maze[marioCoordinates[0]][marioCoordinates[1]] = 'X';
                        Console.WriteLine($"Mario died at {marioCoordinates[0]};{marioCoordinates[1]}.");
                        break;
                    }
                    else
                    {
                        maze[marioCoordinates[0]][marioCoordinates[1]] = 'M';
                    }
                }
                else if (maze[marioCoordinates[0]][marioCoordinates[1]] == 'P')
                {
                    maze[marioCoordinates[0]][marioCoordinates[1]] = '-';
                    Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lives}");
                    break;
                }
                else
                {
                    maze[marioCoordinates[0]][marioCoordinates[1]] = 'M';
                }
            }

            for (int row = 0; row < rows; row++)
            {
                Console.WriteLine(string.Join("", maze[row]));
            }
        }
    }
}
