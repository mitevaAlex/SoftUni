using System;
using System.Linq;

namespace LadyBugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            int[] ladybugsIndexes = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] field = new int[fieldSize];

            for (int j = 0; j < ladybugsIndexes.Length; j++)
            {
                if (ladybugsIndexes[j] < 0 || ladybugsIndexes[j] >= field.Length)
                {
                    continue;
                }
                else
                {
                    field[ladybugsIndexes[j]] = 1;
                }
            }

            string[] command = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);//"{ladybug index} {direction} {fly length}" or "end"

            while (!command.Contains("end"))
            {
                int ladybugIndex = int.Parse(command[0]);
                string direction = command[1];
                int flightLength = int.Parse(command[2]);
                if (ladybugIndex < fieldSize && ladybugIndex >= 0 && flightLength != 0)
                {
                    if (field[ladybugIndex] == 1)
                    {
                        if (direction == "right")
                        {
                            if (flightLength > 0)
                            {
                                MoveRight(ladybugIndex, flightLength, field);
                            }
                            else if (flightLength < 0)
                            {
                                MoveLeft(ladybugIndex, Math.Abs(flightLength), field);
                            }
                        }
                        else if (direction == "left")
                        {
                            if (flightLength > 0)
                            {
                                MoveLeft(ladybugIndex, flightLength, field);
                            }
                            else if (flightLength < 0)
                            {
                                MoveRight(ladybugIndex, Math.Abs(flightLength), field);
                            }
                        }
                    }
                }
                command = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }
            string finalField = string.Join(' ', field);
            Console.WriteLine(finalField);
        }

        static void MoveRight(int ladybugIndex, int flightLength, int[] field)
        {
            int flightLengthCopy = flightLength;
            while (true)
            {
                if (ladybugIndex + flightLength < field.Length)
                {
                    if (field[ladybugIndex + flightLength] == 1)
                    {
                        flightLength += flightLengthCopy;
                    }
                    else
                    {
                        field[ladybugIndex] = 0;
                        field[ladybugIndex + flightLength] = 1;
                        break;
                    }
                }
                else
                {
                    field[ladybugIndex] = 0;
                    break;
                }
            }
        }

        static void MoveLeft(int ladybugIndex, int flightLength, int[] field)
        {
            int flightLengthCopy = flightLength;
            while (true)
            {
                if (ladybugIndex - flightLength >= 0)
                {
                    if (field[ladybugIndex - flightLength] == 1)
                    {
                        flightLength += flightLengthCopy;
                    }
                    else
                    {
                        field[ladybugIndex] = 0;
                        field[ladybugIndex - flightLength] = 1;
                        break;
                    }
                }
                else
                {
                    field[ladybugIndex] = 0;
                    break;
                }
            }
        }
    }

}

